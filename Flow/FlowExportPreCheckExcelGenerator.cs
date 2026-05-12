using ClosedXML.Excel;
using Flow.DbModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public sealed class FlowExportPreCheckExcelGenerator
{
    private static readonly HashSet<string> LlmNodeTypes = new(StringComparer.OrdinalIgnoreCase)
    {
        "General",
        "MultiMCP",
        "entityExtraction",
        "emotionJudgment",
        "IntentRecognition"
    };

    private const string KnowledgeBasePluginUuid = "b3e1a8d45f3b4b8e9c2e1f2a3b4c5d6e";
    private const string GlobalAuthKeyType = "global_auth_key";

    public async Task<PreCheckExcelResult> GenerateAsync(
        string databaseConnectionString,
        CancellationToken cancellationToken = default)
    {
        var sqliteDirectory = Path.Combine(AppContext.BaseDirectory, "flowExt", "sqlite");
        var excelDirectory = Path.Combine(AppContext.BaseDirectory, "flowExt", "excel");
        Directory.CreateDirectory(sqliteDirectory);
        Directory.CreateDirectory(excelDirectory);

        var sqlitePaths = Directory
            .EnumerateFiles(sqliteDirectory, "*.db", SearchOption.TopDirectoryOnly)
            .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
            .ToList();

        var resources = await CollectResourcesAsync(sqlitePaths, cancellationToken);
        var missingModelPairs = await FindMissingModelPairsAsync(
            databaseConnectionString,
            resources.ModelPairs,
            cancellationToken);

        var excelPath = Path.Combine(excelDirectory, "mapping.xlsx");
        WriteExcel(
            excelPath,
            missingModelPairs,
            resources.KnowledgeBaseNames,
            resources.SecretKeys);

        return new PreCheckExcelResult(
            excelPath,
            sqlitePaths.Count,
            missingModelPairs.Count,
            resources.KnowledgeBaseNames.Count,
            resources.SecretKeys.Count);
    }

    private static async Task<CollectedResources> CollectResourcesAsync(
        IReadOnlyList<string> sqlitePaths,
        CancellationToken cancellationToken)
    {
        var resources = new CollectedResources();

        foreach (var sqlitePath in sqlitePaths)
        {
            await using var connection = new SqliteConnection($"Data Source={sqlitePath}");
            await connection.OpenAsync(cancellationToken);

            await EnsureFlowInfoTableExistsAsync(connection, sqlitePath, cancellationToken);

            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT flow_id, flow_name, context FROM t_flow_info";

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                var flowId = reader.IsDBNull(0) ? string.Empty : Convert.ToString(reader.GetValue(0)) ?? string.Empty;
                var flowName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                var context = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

                CollectFromContext(resources, sqlitePath, flowId, flowName, context);
            }
        }

        return resources;
    }

    private static async Task EnsureFlowInfoTableExistsAsync(
        SqliteConnection connection,
        string sqlitePath,
        CancellationToken cancellationToken)
    {
        await using var command = connection.CreateCommand();
        command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name = 't_flow_info'";

        var result = await command.ExecuteScalarAsync(cancellationToken);
        if (result is null)
        {
            throw new InvalidOperationException($"SQLite 文件中不存在 t_flow_info 表: {sqlitePath}");
        }
    }

    private static void CollectFromContext(
        CollectedResources resources,
        string sqlitePath,
        string flowId,
        string flowName,
        string context)
    {
        if (string.IsNullOrWhiteSpace(context))
        {
            return;
        }

        JToken rootToken;
        try
        {
            rootToken = JToken.Parse(context);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(
                $"流程 context 不是有效 JSON，sqlite={sqlitePath}, flow_id={flowId}, flow_name={flowName}: {ex.Message}",
                ex);
        }

        if (rootToken is not JObject root)
        {
            return;
        }

        if (root["mage_flow_node_request"]?["nodes"] is not JArray nodes)
        {
            return;
        }

        foreach (var node in nodes.OfType<JObject>())
        {
            if (node["designParams"] is not JObject designParams)
            {
                continue;
            }

            CollectModelPair(resources, node, designParams);
            CollectKnowledgeBaseName(resources, designParams);
            CollectSecretKey(resources, designParams);
        }
    }

    private static void CollectModelPair(CollectedResources resources, JObject node, JObject designParams)
    {
        var nodeType = ReadString(node["nodeType"]);
        if (nodeType == null || !LlmNodeTypes.Contains(nodeType))
        {
            return;
        }

        var settingName = ReadString(designParams["llm_setting_name"]);
        if (string.IsNullOrWhiteSpace(settingName))
        {
            return;
        }

        var modelName = ReadModelName(designParams);
        resources.ModelPairs.Add(new ModelPair(modelName?.Trim() ?? string.Empty, settingName.Trim()));
    }

    private static void CollectKnowledgeBaseName(CollectedResources resources, JObject designParams)
    {
        if (designParams["plugin"] is not JObject plugin ||
            !string.Equals(ReadString(plugin["pluginUUID"]) ?? ReadString(plugin["PluginUUID"]),
                KnowledgeBasePluginUuid,
                StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        foreach (var parameter in EnumeratePluginParameters(plugin))
        {
            if (!string.Equals(ReadString(parameter["param_name"]), "knowledgeBaseName", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var value = ReadString(parameter["param_value"]?["value"]);
            if (!string.IsNullOrWhiteSpace(value))
            {
                resources.KnowledgeBaseNames.Add(value.Trim());
            }
        }
    }

    private static void CollectSecretKey(CollectedResources resources, JObject designParams)
    {
        if (!string.Equals(ReadString(designParams["module"]), "API CALLER", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        if (designParams["input"] is not JArray inputs)
        {
            return;
        }

        foreach (var input in inputs.OfType<JObject>())
        {
            var inheritParamInfo = input["InheritParamInfo"] as JObject
                ?? input["inheritParamInfo"] as JObject;
            if (inheritParamInfo == null)
            {
                continue;
            }

            var inheritType = ReadString(inheritParamInfo["type"]);
            if (!string.Equals(inheritType, GlobalAuthKeyType, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var secretKey = ReadString(inheritParamInfo["key"]);
            if (!string.IsNullOrWhiteSpace(secretKey))
            {
                resources.SecretKeys.Add(secretKey.Trim());
            }
        }
    }

    private static IEnumerable<JObject> EnumeratePluginParameters(JObject plugin)
    {
        if (plugin["functions"] is not JArray functions)
        {
            yield break;
        }

        foreach (var function in functions.OfType<JObject>())
        {
            var parameters = function["parameters"] as JArray ?? function["Parameters"] as JArray;
            if (parameters == null)
            {
                continue;
            }

            foreach (var parameter in parameters.OfType<JObject>())
            {
                yield return parameter;
            }
        }
    }

    private static async Task<IReadOnlyCollection<ModelPair>> FindMissingModelPairsAsync(
        string databaseConnectionString,
        IReadOnlyCollection<ModelPair> requiredPairs,
        CancellationToken cancellationToken)
    {
        var normalizedPairs = requiredPairs
            .Where(pair => !string.IsNullOrWhiteSpace(pair.ModelName) || !string.IsNullOrWhiteSpace(pair.SettingName))
            .Distinct()
            .ToList();

        if (normalizedPairs.Count == 0)
        {
            return normalizedPairs;
        }

        var options = new DbContextOptionsBuilder<FlowDbContext>()
            .UseSqlServer(databaseConnectionString)
            .Options;

        await using var dbContext = new FlowDbContext(options);

        var modelNames = normalizedPairs
            .Select(pair => pair.ModelName)
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
        var settingNames = normalizedPairs
            .Select(pair => pair.SettingName)
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        var existingModels = await dbContext.TLlmModels
            .AsNoTracking()
            .Where(model => modelNames.Contains(model.Model))
            .Select(model => new { model.Model, model.ModelId })
            .ToListAsync(cancellationToken);
        var existingPromptSettings = await dbContext.TLlmPromptSettings
            .AsNoTracking()
            .Where(setting => settingNames.Contains(setting.Name!) && !setting.IsDelete)
            .Select(setting => new { setting.Name, setting.PromptSettingId })
            .ToListAsync(cancellationToken);

        var modelIdMap = existingModels
            .GroupBy(model => model.Model, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.First().ModelId, StringComparer.OrdinalIgnoreCase);
        var promptSettingIdMap = existingPromptSettings
            .Where(setting => !string.IsNullOrWhiteSpace(setting.Name))
            .GroupBy(setting => setting.Name!, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.First().PromptSettingId, StringComparer.OrdinalIgnoreCase);

        var modelIds = modelIdMap.Values.ToList();
        var promptSettingIds = promptSettingIdMap.Values.ToList();
        var mappings = await dbContext.TLlmModelPromotMappings
            .AsNoTracking()
            .Where(mapping =>
                modelIds.Contains(mapping.LlmModelId) &&
                promptSettingIds.Contains(mapping.LlmPromptSettingId) &&
                mapping.IsValid == true)
            .Select(mapping => new { mapping.LlmModelId, mapping.LlmPromptSettingId })
            .ToListAsync(cancellationToken);
        var mappingSet = mappings
            .Select(mapping => $"{mapping.LlmModelId}_{mapping.LlmPromptSettingId}")
            .ToHashSet(StringComparer.Ordinal);

        var missingPairs = new List<ModelPair>();
        foreach (var pair in normalizedPairs)
        {
            var modelExists = !string.IsNullOrWhiteSpace(pair.ModelName) && modelIdMap.ContainsKey(pair.ModelName);
            var settingExists = !string.IsNullOrWhiteSpace(pair.SettingName) && promptSettingIdMap.ContainsKey(pair.SettingName);

            if (!modelExists || !settingExists)
            {
                missingPairs.Add(pair);
                continue;
            }

            var mappingKey = $"{modelIdMap[pair.ModelName]}_{promptSettingIdMap[pair.SettingName]}";
            if (!mappingSet.Contains(mappingKey))
            {
                missingPairs.Add(pair);
            }
        }

        return missingPairs.Distinct().ToList();
    }

    private static void WriteExcel(
        string excelPath,
        IReadOnlyCollection<ModelPair> modelPairs,
        IReadOnlyCollection<string> knowledgeBaseNames,
        IReadOnlyCollection<string> secretKeys)
    {
        using var workbook = new XLWorkbook();

        var modelSheet = workbook.Worksheets.Add("model");
        modelSheet.Cell(1, 1).Value = "oldModelName";
        modelSheet.Cell(1, 2).Value = "oldSettingName";
        modelSheet.Cell(1, 3).Value = "newModelName";
        modelSheet.Cell(1, 4).Value = "newSettingName";
        var modelRow = 2;
        foreach (var pair in modelPairs.OrderBy(pair => pair.ModelName).ThenBy(pair => pair.SettingName))
        {
            modelSheet.Cell(modelRow, 1).Value = pair.ModelName;
            modelSheet.Cell(modelRow, 2).Value = pair.SettingName;
            modelRow++;
        }

        var knowledgeBaseSheet = workbook.Worksheets.Add("knowledgeBase");
        knowledgeBaseSheet.Cell(1, 1).Value = "knowledgeBaseName";
        knowledgeBaseSheet.Cell(1, 2).Value = "libraryId";
        var knowledgeBaseRow = 2;
        foreach (var knowledgeBaseName in knowledgeBaseNames.OrderBy(name => name, StringComparer.OrdinalIgnoreCase))
        {
            knowledgeBaseSheet.Cell(knowledgeBaseRow, 1).Value = knowledgeBaseName;
            knowledgeBaseRow++;
        }

        var apiCallerSheet = workbook.Worksheets.Add("apiCaller");
        apiCallerSheet.Cell(1, 1).Value = "secretKey";
        apiCallerSheet.Cell(1, 2).Value = "secretValue";
        var apiCallerRow = 2;
        foreach (var secretKey in secretKeys.OrderBy(key => key, StringComparer.OrdinalIgnoreCase))
        {
            apiCallerSheet.Cell(apiCallerRow, 1).Value = secretKey;
            apiCallerRow++;
        }

        foreach (var worksheet in workbook.Worksheets)
        {
            worksheet.Columns().AdjustToContents();
        }

        try
        {
            using var excelStream = new FileStream(excelPath, FileMode.Create, FileAccess.Write, FileShare.None);
            workbook.SaveAs(excelStream);
        }
        catch (IOException ex)
        {
            throw new IOException($"写入 Excel 失败，请先关闭正在打开的文件后重试: {excelPath}", ex);
        }
    }

    private static string? ReadModelName(JObject designParams)
    {
        if (designParams["llm_model_name"] is JObject modelNameObject)
        {
            return ReadString(modelNameObject["label"]) ?? ReadString(modelNameObject["value"]);
        }

        if (designParams["LLMSetting"] is JObject llmSettingObject)
        {
            return ReadString(llmSettingObject["llm_model_name"]);
        }

        return null;
    }

    private static string? ReadString(JToken? token)
    {
        return token?.Type switch
        {
            JTokenType.Null => null,
            JTokenType.Undefined => null,
            _ => token?.ToString()
        };
    }

    private sealed class CollectedResources
    {
        public HashSet<ModelPair> ModelPairs { get; } = new();
        public HashSet<string> KnowledgeBaseNames { get; } = new(StringComparer.OrdinalIgnoreCase);
        public HashSet<string> SecretKeys { get; } = new(StringComparer.OrdinalIgnoreCase);
    }

    private sealed record ModelPair(string ModelName, string SettingName);
}

public sealed record PreCheckExcelResult(
    string ExcelPath,
    int SqliteFileCount,
    int ModelCount,
    int KnowledgeBaseCount,
    int ApiCallerSecretCount);
