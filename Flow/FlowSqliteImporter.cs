using System.Net.Http.Headers;
using Flow.DbModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public sealed class FlowSqliteImporter
{
    private const string ExportIdPlaceholder = "{exportId}";
    private static readonly HashSet<string> LlmNodeTypes = new(StringComparer.OrdinalIgnoreCase)
    {
        "General",
        "MultiMCP",
        "entityExtraction",
        "emotionJudgment",
        "IntentRecognition"
    };

    private readonly HttpClient _httpClient;
    private readonly string _importSqliteUrl;
    private readonly string _importStatusUrl;
    private readonly string _token;
    private readonly TimeSpan _pollInterval;
    private readonly TimeSpan _maxWaitTime;

    public FlowSqliteImporter(
        HttpClient httpClient,
        string importSqliteUrl,
        string importStatusUrl,
        string token,
        TimeSpan pollInterval,
        TimeSpan maxWaitTime)
    {
        _httpClient = httpClient;
        _importSqliteUrl = importSqliteUrl;
        _importStatusUrl = importStatusUrl;
        _token = token;
        _pollInterval = pollInterval;
        _maxWaitTime = maxWaitTime;
    }

    public async Task<ImportSqliteResult> ImportAllAsync(
        string databaseConnectionString,
        CancellationToken cancellationToken = default)
    {
        var newSqliteDirectory = Path.Combine(AppContext.BaseDirectory, "flowExt", "newSqlite");
        if (!Directory.Exists(newSqliteDirectory))
        {
            throw new DirectoryNotFoundException($"找不到 newSqlite 目录: {newSqliteDirectory}");
        }

        var sqlitePaths = Directory
            .EnumerateFiles(newSqliteDirectory, "*.db", SearchOption.TopDirectoryOnly)
            .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (sqlitePaths.Count == 0)
        {
            throw new InvalidOperationException($"newSqlite 目录下没有 db 文件: {newSqliteDirectory}");
        }

        SqliteConnection.ClearAllPools();
        GC.Collect();
        GC.WaitForPendingFinalizers();

        var flowIdMap = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (var sqlitePath in sqlitePaths)
        {
            Console.WriteLine("准备导入 sqlite");
            Console.WriteLine($"sqlite_path: {sqlitePath}");

            var sourceFlow = await ReadSingleSourceFlowAsync(sqlitePath, cancellationToken);
            Console.WriteLine($"old_flow_id: {sourceFlow.OldFlowId}");
            Console.WriteLine($"flow_name: {sourceFlow.FlowName}");

            Console.WriteLine("正在上传 sqlite 到目标环境...");
            var importId = await CreateImportAsync(sqlitePath, cancellationToken);
            Console.WriteLine($"import_id: {importId}");
            Console.WriteLine("开始轮询导入状态...");

            var importedFlowId = await WaitForImportAsync(importId, cancellationToken);

            if (!flowIdMap.TryAdd(sourceFlow.OldFlowId, importedFlowId))
            {
                throw new InvalidOperationException($"存在重复旧 flow_id: {sourceFlow.OldFlowId}");
            }

            Console.WriteLine("sqlite 导入完成");
            Console.WriteLine($"{sourceFlow.OldFlowId}:{importedFlowId}");
        }

        Console.WriteLine("全部 sqlite 已导入，开始修复目标环境子流程引用...");
        Console.WriteLine($"flow_mapping_count: {flowIdMap.Count}");
        foreach (var item in flowIdMap.OrderBy(item => item.Key))
        {
            Console.WriteLine($"{item.Key}:{item.Value}");
        }

        var repairResult = await RepairSubProcessReferencesAsync(
            databaseConnectionString,
            flowIdMap,
            cancellationToken);

        return new ImportSqliteResult(sqlitePaths.Count, flowIdMap, repairResult.UpdatedNodeCount, repairResult.UpdatedPublishCount);
    }

    private async Task<string> CreateImportAsync(string sqlitePath, CancellationToken cancellationToken)
    {
        await using var fileStream = new FileStream(sqlitePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var content = new MultipartFormDataContent();
        using var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        content.Add(fileContent, "file", Path.GetFileName(sqlitePath));

        using var request = new HttpRequestMessage(HttpMethod.Post, _importSqliteUrl);
        request.Headers.TryAddWithoutValidation("token", _token);
        request.Content = content;

        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

        ApiResponseHelper.EnsureSuccessStatusCode(response, responseText, "导入 sqlite");

        using var document = System.Text.Json.JsonDocument.Parse(responseText);
        var root = document.RootElement;
        ApiResponseHelper.EnsureGeneralResponseSuccess(root, responseText, "导入 sqlite");

        if (!root.TryGetProperty("body", out var body) ||
            body.ValueKind != System.Text.Json.JsonValueKind.String ||
            string.IsNullOrWhiteSpace(body.GetString()))
        {
            throw new InvalidOperationException("导入接口响应缺少 import_id。");
        }

        return body.GetString()!;
    }

    private async Task<int> WaitForImportAsync(string importId, CancellationToken cancellationToken)
    {
        var startedAt = DateTimeOffset.UtcNow;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using var request = new HttpRequestMessage(HttpMethod.Get, BuildImportStatusUrl(importId));
            request.Headers.TryAddWithoutValidation("token", _token);

            using var response = await _httpClient.SendAsync(request, cancellationToken);
            var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

            ApiResponseHelper.EnsureSuccessStatusCode(response, responseText, "查询导入状态");

            using var document = System.Text.Json.JsonDocument.Parse(responseText);
            var root = document.RootElement;
            ApiResponseHelper.EnsureGeneralResponseSuccess(root, responseText, "查询导入状态");

            if (!root.TryGetProperty("body", out var body) ||
                body.ValueKind != System.Text.Json.JsonValueKind.Object)
            {
                throw new InvalidOperationException("导入状态接口响应缺少 body。");
            }

            var processContent = TryGetString(body, "process_content");
            var status = GetRequiredInt32(body, "status");

            if (status == 2)
            {
                return GetRequiredInt32(body, "flow_id");
            }

            if (status == 9)
            {
                throw new InvalidOperationException(
                    string.IsNullOrWhiteSpace(processContent)
                        ? "sqlite 导入失败。"
                        : processContent);
            }

            if (DateTimeOffset.UtcNow - startedAt > _maxWaitTime)
            {
                throw new TimeoutException($"sqlite 导入超时，import_id={importId}, 当前状态={status}。");
            }

            Console.WriteLine(
                string.IsNullOrWhiteSpace(processContent)
                    ? $"sqlite 导入中，status={status}"
                    : $"sqlite 导入中，status={status}, {processContent}");

            await Task.Delay(_pollInterval, cancellationToken);
        }
    }

    private async Task<ImportedFlowSource> ReadSingleSourceFlowAsync(
        string sqlitePath,
        CancellationToken cancellationToken)
    {
        var result = new List<ImportedFlowSource>();

        await using var connection = new SqliteConnection($"Data Source={sqlitePath}");
        await connection.OpenAsync(cancellationToken);

        await using var command = connection.CreateCommand();
        command.CommandText = "SELECT flow_id, flow_name FROM t_flow_info";

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            var flowIdText = reader.IsDBNull(0) ? string.Empty : Convert.ToString(reader.GetValue(0)) ?? string.Empty;
            var oldFlowId = NormalizeFlowId(flowIdText);
            if (string.IsNullOrWhiteSpace(oldFlowId))
            {
                throw new InvalidOperationException($"SQLite 中存在无效 flow_id: {flowIdText}, file={sqlitePath}");
            }

            result.Add(new ImportedFlowSource(
                oldFlowId,
                reader.IsDBNull(1) ? string.Empty : reader.GetString(1)));
        }

        if (result.Count != 1)
        {
            throw new InvalidOperationException(
                $"每个待导入 db 必须只有一个 flow，当前文件包含 {result.Count} 个: {sqlitePath}");
        }

        return result[0];
    }

    private static async Task<SubProcessReferenceRepairResult> RepairSubProcessReferencesAsync(
        string databaseConnectionString,
        IReadOnlyDictionary<string, int> flowIdMap,
        CancellationToken cancellationToken)
    {
        if (flowIdMap.Count == 0)
        {
            return new SubProcessReferenceRepairResult(0, 0);
        }

        var newFlowIds = flowIdMap.Values.Distinct().ToList();
        Console.WriteLine("正在连接目标数据库，准备查询子流程节点和发布态 context...");
        Console.WriteLine($"new_flow_ids: {string.Join(", ", newFlowIds)}");

        var options = new DbContextOptionsBuilder<FlowDbContext>()
            .UseSqlServer(databaseConnectionString)
            .Options;
        await using var dbContext = new FlowDbContext(options);

        var settingLabelByName = await LoadPromptSettingLabelsAsync(dbContext, cancellationToken);

        Console.WriteLine("正在查询 t_flow_node 中的 subProcess 节点...");
        var nodes = await dbContext.TFlowNodes
            .Where(node =>
                node.FlowId.HasValue &&
                newFlowIds.Contains(node.FlowId.Value) &&
                node.NodeType == "subProcess" &&
                !string.IsNullOrWhiteSpace(node.DesignParams))
            .ToListAsync(cancellationToken);
        Console.WriteLine($"待检查 subProcess 节点数: {nodes.Count}");

        var updatedNodeCount = 0;
        foreach (var node in nodes)
        {
            if (TryRepairSubProcessDesignParams(node.DesignParams!, flowIdMap, out var updatedDesignParams))
            {
                node.DesignParams = updatedDesignParams;
                updatedNodeCount++;
            }
        }
        Console.WriteLine($"t_flow_node.design_params 需要更新数量: {updatedNodeCount}");

        Console.WriteLine("正在修复 t_flow_node.design_params 中的语义节点 llm_setting_label...");
        var llmNodes = await dbContext.TFlowNodes
            .Where(node =>
                node.FlowId.HasValue &&
                newFlowIds.Contains(node.FlowId.Value) &&
                node.NodeType != null &&
                LlmNodeTypes.Contains(node.NodeType) &&
                !string.IsNullOrWhiteSpace(node.DesignParams))
            .ToListAsync(cancellationToken);
        var updatedLlmNodeCount = 0;
        foreach (var node in llmNodes)
        {
            if (TryRepairLlmSettingLabel(node.DesignParams!, settingLabelByName, out var updatedDesignParams))
            {
                node.DesignParams = updatedDesignParams;
                updatedLlmNodeCount++;
            }
        }
        Console.WriteLine($"t_flow_node.design_params 语义节点 label 需要更新数量: {updatedLlmNodeCount}");

        Console.WriteLine("正在查询 t_flow_publish.context...");
        var publishes = await dbContext.TFlowPublishes
            .Where(publish =>
                newFlowIds.Contains(publish.FlowId) &&
                !string.IsNullOrWhiteSpace(publish.Context))
            .ToListAsync(cancellationToken);
        Console.WriteLine($"待检查发布记录数: {publishes.Count}");

        var updatedPublishCount = 0;
        foreach (var publish in publishes)
        {
            if (TryRepairPublishContext(publish.Context, flowIdMap, settingLabelByName, out var updatedContext))
            {
                publish.Context = updatedContext;
                updatedPublishCount++;
            }
        }
        Console.WriteLine($"t_flow_publish.context 需要更新数量: {updatedPublishCount}");

        if (updatedNodeCount > 0 || updatedLlmNodeCount > 0 || updatedPublishCount > 0)
        {
            Console.WriteLine("正在保存子流程引用修复结果到目标数据库...");
            await dbContext.SaveChangesAsync(cancellationToken);
            Console.WriteLine("目标数据库子流程引用修复保存完成。");
        }
        else
        {
            Console.WriteLine("没有发现需要修复的子流程引用。");
        }

        return new SubProcessReferenceRepairResult(updatedNodeCount + updatedLlmNodeCount, updatedPublishCount);
    }

    private static async Task<IReadOnlyDictionary<string, string>> LoadPromptSettingLabelsAsync(
        FlowDbContext dbContext,
        CancellationToken cancellationToken)
    {
        var settings = await dbContext.TLlmPromptSettings
            .AsNoTracking()
            .Where(setting => !setting.IsDelete)
            .Select(setting => new
            {
                setting.Name,
                setting.Describe
            })
            .ToListAsync(cancellationToken);

        return settings
            .Where(setting => !string.IsNullOrWhiteSpace(setting.Name))
            .GroupBy(setting => setting.Name!, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(
                group => group.Key,
                group => ReadCnLabel(group.First().Describe) ?? string.Empty,
                StringComparer.OrdinalIgnoreCase);
    }

    private static bool TryRepairSubProcessDesignParams(
        string designParams,
        IReadOnlyDictionary<string, int> flowIdMap,
        out string updatedDesignParams)
    {
        updatedDesignParams = designParams;

        JToken token;
        try
        {
            token = JToken.Parse(designParams);
        }
        catch (JsonException)
        {
            return false;
        }

        if (token is not JObject root ||
            root["subProcessData"] is not JObject subProcessData)
        {
            return false;
        }

        var oldFlowIdText = subProcessData["flow_id"]?.ToString();
        if (string.IsNullOrWhiteSpace(oldFlowIdText) ||
            !flowIdMap.TryGetValue(NormalizeFlowId(oldFlowIdText), out var newFlowId))
        {
            return false;
        }

        subProcessData["flow_id"] = newFlowId;
        updatedDesignParams = root.ToString(Formatting.None);
        return true;
    }

    private static bool TryRepairPublishContext(
        string context,
        IReadOnlyDictionary<string, int> flowIdMap,
        IReadOnlyDictionary<string, string> settingLabelByName,
        out string updatedContext)
    {
        updatedContext = context;

        JToken token;
        try
        {
            token = JToken.Parse(context);
        }
        catch (JsonException)
        {
            return false;
        }

        if (token is not JObject root)
        {
            return false;
        }

        var changed = RepairSubProcessNodes(root["mage_flow_node_request"]?["nodes"] as JArray, flowIdMap);
        changed = RepairSubProcessNodes(root["Nodes"] as JArray, flowIdMap) || changed;
        changed = RepairSubProcessNodes(root["nodes"] as JArray, flowIdMap) || changed;
        changed = RepairLlmSettingLabels(root["mage_flow_node_request"]?["nodes"] as JArray, settingLabelByName) || changed;
        changed = RepairLlmSettingLabels(root["Nodes"] as JArray, settingLabelByName) || changed;
        changed = RepairLlmSettingLabels(root["nodes"] as JArray, settingLabelByName) || changed;

        if (!changed)
        {
            return false;
        }

        updatedContext = root.ToString(Formatting.None);
        return true;
    }

    private static bool RepairSubProcessNodes(JArray? nodes, IReadOnlyDictionary<string, int> flowIdMap)
    {
        if (nodes == null)
        {
            return false;
        }

        var changed = false;
        foreach (var node in nodes.OfType<JObject>())
        {
            var nodeType = node["nodeType"]?.ToString() ?? node["NodeType"]?.ToString();
            if (!string.Equals(nodeType, "subProcess", StringComparison.OrdinalIgnoreCase) ||
                node["designParams"] is not JObject designParams ||
                designParams["subProcessData"] is not JObject subProcessData)
            {
                continue;
            }

            var oldFlowIdText = subProcessData["flow_id"]?.ToString();
            if (string.IsNullOrWhiteSpace(oldFlowIdText) ||
                !flowIdMap.TryGetValue(NormalizeFlowId(oldFlowIdText), out var newFlowId))
            {
                continue;
            }

            subProcessData["flow_id"] = newFlowId;
            changed = true;
        }

        return changed;
    }

    private static bool RepairLlmSettingLabels(
        JArray? nodes,
        IReadOnlyDictionary<string, string> settingLabelByName)
    {
        if (nodes == null)
        {
            return false;
        }

        var changed = false;
        foreach (var node in nodes.OfType<JObject>())
        {
            var nodeType = node["nodeType"]?.ToString() ?? node["NodeType"]?.ToString();
            if (!LlmNodeTypes.Contains(nodeType ?? string.Empty) ||
                node["designParams"] is not JObject designParams)
            {
                continue;
            }

            changed = TryRepairLlmSettingLabel(designParams, settingLabelByName) || changed;
        }

        return changed;
    }

    private static bool TryRepairLlmSettingLabel(
        string designParams,
        IReadOnlyDictionary<string, string> settingLabelByName,
        out string updatedDesignParams)
    {
        updatedDesignParams = designParams;

        JToken token;
        try
        {
            token = JToken.Parse(designParams);
        }
        catch (JsonException)
        {
            return false;
        }

        if (token is not JObject root ||
            !TryRepairLlmSettingLabel(root, settingLabelByName))
        {
            return false;
        }

        updatedDesignParams = root.ToString(Formatting.None);
        return true;
    }

    private static bool TryRepairLlmSettingLabel(
        JObject designParams,
        IReadOnlyDictionary<string, string> settingLabelByName)
    {
        var settingName = designParams["llm_setting_name"]?.ToString();
        if (string.IsNullOrWhiteSpace(settingName) ||
            !settingLabelByName.TryGetValue(settingName, out var label) ||
            string.IsNullOrWhiteSpace(label))
        {
            return false;
        }

        if (string.Equals(designParams["llm_setting_label"]?.ToString(), label, StringComparison.Ordinal))
        {
            return false;
        }

        designParams["llm_setting_label"] = label;
        return true;
    }

    private static string? ReadCnLabel(string? describe)
    {
        if (string.IsNullOrWhiteSpace(describe))
        {
            return null;
        }

        try
        {
            var token = JToken.Parse(describe);
            return token is JObject json ? json["cn"]?.ToString() : describe;
        }
        catch (JsonException)
        {
            return describe;
        }
    }

    private string BuildImportStatusUrl(string importId)
    {
        if (_importStatusUrl.Contains(ExportIdPlaceholder, StringComparison.OrdinalIgnoreCase))
        {
            return _importStatusUrl.Replace(ExportIdPlaceholder, Uri.EscapeDataString(importId), StringComparison.OrdinalIgnoreCase);
        }

        var separator = _importStatusUrl.Contains('?') ? '&' : '?';
        return $"{_importStatusUrl}{separator}export_id={Uri.EscapeDataString(importId)}";
    }

    private static int GetRequiredInt32(System.Text.Json.JsonElement element, string propertyName)
    {
        if (!element.TryGetProperty(propertyName, out var valueElement) ||
            !ApiResponseHelper.TryReadInt32(valueElement, out var value))
        {
            throw new InvalidOperationException($"接口响应缺少有效的 {propertyName}。");
        }

        return value;
    }

    private static string? TryGetString(System.Text.Json.JsonElement element, string propertyName)
    {
        if (!element.TryGetProperty(propertyName, out var valueElement))
        {
            return null;
        }

        return valueElement.ValueKind == System.Text.Json.JsonValueKind.String
            ? valueElement.GetString()
            : valueElement.ToString();
    }

    private static string NormalizeFlowId(string flowId)
    {
        return flowId.Trim();
    }

}

public sealed record ImportedFlowSource(string OldFlowId, string FlowName);

public sealed record ImportSqliteResult(
    int SqliteFileCount,
    IReadOnlyDictionary<string, int> FlowIdMap,
    int UpdatedSubProcessNodeCount,
    int UpdatedSubProcessPublishCount);

public sealed record SubProcessReferenceRepairResult(int UpdatedNodeCount, int UpdatedPublishCount);
