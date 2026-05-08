using ClosedXML.Excel;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// 表示一条旧模型配置到新模型配置的映射关系。
/// </summary>
/// <param name="OldModelName">旧模型名称。</param>
/// <param name="OldSettingName">旧模型配置名称。</param>
/// <param name="NewModelName">替换后的新模型名称。</param>
/// <param name="NewSettingName">替换后的新模型配置名称。</param>
/// <param name="NewProvider">替换后的模型提供方编号；为空表示不更新提供方。</param>
/// <param name="NewSettingLabel">替换后的模型配置显示名称；为空表示不更新显示名称。</param>
public sealed record ModelMapping(
    string OldModelName,
    string OldSettingName,
    string NewModelName,
    string NewSettingName,
    int? NewProvider,
    string? NewSettingLabel);

/// <summary>
/// 表示第三方知识库名称到当前系统知识库 ID 的映射关系。
/// </summary>
/// <param name="KnowledgeBaseName">第三方小程序中的知识库名称。</param>
/// <param name="LibraryId">当前系统中的知识库 ID。</param>
public sealed record KnowledgeBaseMapping(
    string KnowledgeBaseName,
    string LibraryId);

/// <summary>
/// 表示执行模型映射修复时使用的命令参数。
/// </summary>
/// <param name="InputPath">待修复的原始 SQLite 数据库文件路径。</param>
/// <param name="MappingPath">模型映射 Excel 文件路径。</param>
/// <param name="OutputPath">修复后 SQLite 数据库文件的输出目录。</param>
public sealed record RepairOptions(
    string InputPath,
    string MappingPath,
    string OutputPath);

/// <summary>
/// 表示一次成功替换模型配置的记录。
/// </summary>
/// <param name="FlowId">发生替换的流程 ID。</param>
/// <param name="FlowName">发生替换的流程名称。</param>
/// <param name="NodeId">发生替换的节点 ID。</param>
/// <param name="NodeName">发生替换的节点名称。</param>
/// <param name="OldModelName">被替换的旧模型名称。</param>
/// <param name="OldSettingName">被替换的旧模型配置名称。</param>
/// <param name="NewModelName">替换后的新模型名称。</param>
/// <param name="NewSettingName">替换后的新模型配置名称。</param>
/// <param name="OldSettingLabel">被替换的旧模型配置显示名称。</param>
/// <param name="NewSettingLabel">替换后的新模型配置显示名称。</param>
public sealed record ReplacementRecord(
    string FlowId,
    string FlowName,
    string NodeId,
    string NodeName,
    string OldModelName,
    string OldSettingName,
    string NewModelName,
    string NewSettingName,
    string OldSettingLabel,
    string NewSettingLabel);

/// <summary>
/// 表示未在映射表中找到匹配规则的模型配置记录。
/// </summary>
/// <param name="FlowId">包含未映射模型配置的流程 ID。</param>
/// <param name="FlowName">包含未映射模型配置的流程名称。</param>
/// <param name="NodeId">包含未映射模型配置的节点 ID。</param>
/// <param name="NodeName">包含未映射模型配置的节点名称。</param>
/// <param name="ModelName">未找到映射规则的模型名称。</param>
/// <param name="SettingName">未找到映射规则的模型配置名称。</param>
public sealed record UnmappedModelRecord(
    string FlowId,
    string FlowName,
    string NodeId,
    string NodeName,
    string ModelName,
    string SettingName);

/// <summary>
/// 表示一次知识库插件参数替换记录。
/// </summary>
/// <param name="FlowId">发生替换的流程 ID。</param>
/// <param name="FlowName">发生替换的流程名称。</param>
/// <param name="NodeId">发生替换的节点 ID。</param>
/// <param name="NodeName">发生替换的节点名称。</param>
/// <param name="KnowledgeBaseName">第三方小程序中的知识库名称。</param>
/// <param name="LibraryId">替换后的当前系统知识库 ID。</param>
public sealed record KnowledgeBaseReplacementRecord(
    string FlowId,
    string FlowName,
    string NodeId,
    string NodeName,
    string KnowledgeBaseName,
    string LibraryId);

/// <summary>
/// 表示未在映射表中找到对应 libraryid 的知识库插件参数。
/// </summary>
/// <param name="FlowId">包含未映射知识库参数的流程 ID。</param>
/// <param name="FlowName">包含未映射知识库参数的流程名称。</param>
/// <param name="NodeId">包含未映射知识库参数的节点 ID。</param>
/// <param name="NodeName">包含未映射知识库参数的节点名称。</param>
/// <param name="KnowledgeBaseName">未找到映射规则的知识库名称。</param>
public sealed record UnmappedKnowledgeBaseRecord(
    string FlowId,
    string FlowName,
    string NodeId,
    string NodeName,
    string KnowledgeBaseName);

public sealed class RepairResult
{
    public int FlowCount { get; init; }
    public int ChangedFlowCount { get; init; }
    public IReadOnlyList<ReplacementRecord> Replacements { get; init; } = [];
    public IReadOnlyList<UnmappedModelRecord> UnmappedModels { get; init; } = [];
    public IReadOnlyList<KnowledgeBaseReplacementRecord> KnowledgeBaseReplacements { get; init; } = [];
    public IReadOnlyList<UnmappedKnowledgeBaseRecord> UnmappedKnowledgeBases { get; init; } = [];
    public string OutputPath { get; init; } = string.Empty;
}

/// <summary>
/// 负责按照模型映射清单修复流程数据库中的模型配置。
/// </summary>
public sealed class ModelMappingRepairer
{
    /// <summary>
    /// 写回流程 JSON 时使用的格式化配置，保持中文可读并输出紧凑 JSON。
    /// </summary>
    private const Formatting WriteJsonFormatting = Formatting.None;

    /// <summary>
    /// 将 JSON 节点转换为调试和写回时一致的中文可读 JSON 文本。
    /// </summary>
    /// <param name="node">待转换的 JSON 节点。</param>
    /// <returns>中文可读的 JSON 文本；节点为空时返回 null。</returns>
    private static string? ToReadableJson(JToken? node)
    {
        return node?.ToString(WriteJsonFormatting);
    }

    /// <summary>
    /// 模型映射键比较器，匹配旧模型和旧配置时忽略大小写。
    /// </summary>
    private static readonly StringComparer MappingKeyComparer = StringComparer.OrdinalIgnoreCase;

    /// <summary>
    /// 允许执行模型映射修复的节点类型。
    /// </summary>
    private static readonly HashSet<string> RepairableNodeTypes = new(StringComparer.OrdinalIgnoreCase)
    {
        "General",
        "MultiMCP",
        "entityExtraction",
        "emotionJudgment",
        "IntentRecognition"
    };

    /// <summary>
    /// 知识库插件 UUID，用于定位需要迁移知识库参数的插件节点。
    /// </summary>
    private const string KnowledgeBasePluginUuid = "b3e1a8d45f3b4b8e9c2e1f2a3b4c5d6e";

    /// <summary>
    /// 知识库插件迁移后的展示名称。
    /// </summary>
    private const string KnowledgeBasePluginName = "知识库插件Pro";

    /// <summary>
    /// 执行完整的模型映射修复流程。
    /// </summary>
    /// <param name="options">修复命令参数。</param>
    /// <param name="cancellationToken">取消异步操作的令牌。</param>
    /// <returns>修复统计结果和明细记录。</returns>
    public async Task<RepairResult> RepairAsync(RepairOptions options, CancellationToken cancellationToken = default)
    {
        ValidateOptions(options);

        // 先读取映射清单，并构造成按“旧模型 + 旧配置”快速查找的字典。
        var mappingWorkbook = LoadMappings(options.MappingPath);
        var map = mappingWorkbook.ModelMappings.ToDictionary(
            mapping => MakeKey(mapping.OldModelName, mapping.OldSettingName),
            mapping => mapping,
            MappingKeyComparer);
        var knowledgeBaseMap = mappingWorkbook.KnowledgeBaseMappings.ToDictionary(
            mapping => mapping.KnowledgeBaseName.Trim(),
            mapping => mapping.LibraryId.Trim(),
            MappingKeyComparer);

        // 先复制一份 SQLite 到输出目录下的时间戳文件，后续只修改这个新文件，避免改动原始文件。
        var sqlitePath = CreateTimestampedOutputPath(options.InputPath, options.OutputPath);
        File.Copy(options.InputPath, sqlitePath);

        var replacements = new List<ReplacementRecord>();
        var unmappedModels = new List<UnmappedModelRecord>();
        var knowledgeBaseReplacements = new List<KnowledgeBaseReplacementRecord>();
        var unmappedKnowledgeBases = new List<UnmappedKnowledgeBaseRecord>();
        var changedFlowIds = new HashSet<string>(StringComparer.Ordinal);
        var rows = new List<FlowContextRow>();

        // 打开待处理的 SQLite，并确认流程信息表存在。
        await using var connection = new SqliteConnection($"Data Source={sqlitePath}");
        await connection.OpenAsync(cancellationToken);

        await EnsureFlowInfoTableExists(connection, cancellationToken);

        // 先把所有流程 context 读到内存，避免遍历 reader 时同时执行更新命令。
        await using (var command = connection.CreateCommand())
        {
            command.CommandText = "SELECT rowid, flow_id, flow_name, context FROM t_flow_info";
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
            {
                rows.Add(new FlowContextRow(
                    reader.GetInt64(0),
                    reader.IsDBNull(1) ? string.Empty : Convert.ToString(reader.GetValue(1)) ?? string.Empty,
                    reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    reader.IsDBNull(3) ? string.Empty : reader.GetString(3)));
            }
        }

        // 逐条修复流程 JSON，并写回复制出来的新 SQLite 文件。
        foreach (var row in rows)
        {
            // 修复当前流程的 context JSON，并返回替换、未映射和是否变更等结果。
            var repairOutcome = RepairContext(row, map, knowledgeBaseMap);
            replacements.AddRange(repairOutcome.Replacements);
            unmappedModels.AddRange(repairOutcome.UnmappedModels);
            knowledgeBaseReplacements.AddRange(repairOutcome.KnowledgeBaseReplacements);
            unmappedKnowledgeBases.AddRange(repairOutcome.UnmappedKnowledgeBases);

            if (!repairOutcome.Changed)
            {
                continue;
            }

            changedFlowIds.Add(row.FlowId);

            await using var updateCommand = connection.CreateCommand();
            updateCommand.CommandText = "UPDATE t_flow_info SET context = @context WHERE rowid = @rowid";
            updateCommand.Parameters.AddWithValue("@context", repairOutcome.Context);
            updateCommand.Parameters.AddWithValue("@rowid", row.RowId);
            await updateCommand.ExecuteNonQueryAsync(cancellationToken);
        }

        // 汇总修复结果，并对未映射记录去重，避免同一节点重复出现在报告中。
        return new RepairResult
        {
            FlowCount = rows.Count,
            ChangedFlowCount = changedFlowIds.Count,
            Replacements = replacements,
            UnmappedModels = unmappedModels
                .DistinctBy(item => new { item.FlowId, item.NodeId, item.ModelName, item.SettingName })
                .ToList(),
            KnowledgeBaseReplacements = knowledgeBaseReplacements,
            UnmappedKnowledgeBases = unmappedKnowledgeBases
                .DistinctBy(item => new { item.FlowId, item.NodeId, item.KnowledgeBaseName })
                .ToList(),
            OutputPath = sqlitePath
        };
    }

    /// <summary>
    /// 校验命令参数和输入文件是否满足修复要求。
    /// </summary>
    /// <param name="options">修复命令参数。</param>
    private static void ValidateOptions(RepairOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.InputPath))
        {
            throw new ArgumentException("缺少 --input 参数。");
        }

        if (string.IsNullOrWhiteSpace(options.MappingPath))
        {
            throw new ArgumentException("缺少 --mapping 参数。");
        }

        if (string.IsNullOrWhiteSpace(options.OutputPath))
        {
            throw new ArgumentException("缺少 --output 参数。");
        }

        if (!Directory.Exists(options.OutputPath))
        {
            throw new DirectoryNotFoundException($"找不到输出目录: {options.OutputPath}");
        }

        if (!File.Exists(options.InputPath))
        {
            throw new FileNotFoundException("找不到输入 SQLite 文件。", options.InputPath);
        }

        if (!File.Exists(options.MappingPath))
        {
            throw new FileNotFoundException("找不到模型映射清单。", options.MappingPath);
        }
    }

    /// <summary>
    /// 根据输入文件名和输出目录生成带年月日时分秒的实际输出文件路径。
    /// </summary>
    /// <param name="inputPath">待修复的原始 SQLite 数据库文件路径。</param>
    /// <param name="outputDirectory">输出目录。</param>
    /// <returns>追加时间戳后的输出文件路径。</returns>
    private static string CreateTimestampedOutputPath(string inputPath, string outputDirectory)
    {
        var fileName = Path.GetFileNameWithoutExtension(inputPath);
        var extension = Path.GetExtension(inputPath);
        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        var timestampedFileName = $"{fileName}_{timestamp}{extension}";

        return Path.Combine(outputDirectory, timestampedFileName);
    }

    /// <summary>
    /// 确认 SQLite 中存在保存流程信息的 t_flow_info 表。
    /// </summary>
    /// <param name="connection">已打开的 SQLite 连接。</param>
    /// <param name="cancellationToken">取消异步操作的令牌。</param>
    private static async Task EnsureFlowInfoTableExists(SqliteConnection connection, CancellationToken cancellationToken)
    {
        await using var command = connection.CreateCommand();
        command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name = 't_flow_info'";
        var result = await command.ExecuteScalarAsync(cancellationToken);
        if (result == null)
        {
            throw new InvalidOperationException("SQLite 文件中不存在 t_flow_info 表。");
        }
    }

    /// <summary>
    /// 修复单条流程记录中的 context JSON。
    /// </summary>
    /// <param name="row">数据库中的流程记录。</param>
    /// <param name="mappings">按旧模型和旧配置名称索引的映射字典。</param>
    /// <returns>修复后的 JSON、是否变更以及替换/未映射明细。</returns>
    private static RepairContextOutcome RepairContext(
        FlowContextRow row,
        IReadOnlyDictionary<string, ModelMapping> mappings,
        IReadOnlyDictionary<string, string> knowledgeBaseMappings)
    {
        if (string.IsNullOrWhiteSpace(row.Context))
        {
            return RepairContextOutcome.Empty(row.Context);
        }

        JToken rootNode;
        try
        {
            rootNode = JToken.Parse(row.Context);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException($"流程 {row.FlowName}({row.FlowId}) 的 context 不是有效 JSON: {ex.Message}", ex);
        }

        // 只处理对象结构的 context，其他 JSON 类型保持原样。
        if (rootNode is not JObject root)
        {
            return RepairContextOutcome.Empty(row.Context);
        }

        // 流程节点列表位于 mage_flow_node_request.nodes；缺少该结构则无需修复。
        var nodes = root["mage_flow_node_request"]?["nodes"] as JArray;
        if (nodes == null)
        {
            return RepairContextOutcome.Empty(row.Context);
        }

        var replacements = new List<ReplacementRecord>();
        var unmappedModels = new List<UnmappedModelRecord>();
        var knowledgeBaseReplacements = new List<KnowledgeBaseReplacementRecord>();
        var unmappedKnowledgeBases = new List<UnmappedKnowledgeBaseRecord>();
        var changed = false;

        foreach (var node in nodes)
        {
            if (node is not JObject nodeObject)
            {
                continue;
            }

            if (nodeObject["designParams"] is JObject pluginDesignParams &&
                //知识库插件参数替换
                TryRepairKnowledgeBasePlugin(
                    row,
                    nodeObject,
                    pluginDesignParams,
                    knowledgeBaseMappings,
                    knowledgeBaseReplacements,
                    unmappedKnowledgeBases))
            {
                changed = true;
            }

            if (mappings.Count == 0)
            {
                continue;
            }

            // 只处理支持模型配置的节点类型，其他节点不参与模型映射修复。
            var nodeType = ReadString(nodeObject["nodeType"]);
            if (nodeType == null || !RepairableNodeTypes.Contains(nodeType))
            {
                continue;
            }

            // 只有包含 designParams 的语义节点才可能保存模型配置。
            if (nodeObject["designParams"] is not JObject designParams)
            {
                continue;
            }

            // 先过滤掉没有 llm_setting_name 的节点，避免无效节点进入映射匹配。
            var currentSettingName = ReadString(designParams["llm_setting_name"]);
            if (string.IsNullOrWhiteSpace(currentSettingName))
            {
                continue;
            }

            // 同时读取模型名称和配置名称，二者共同决定映射规则。
            var currentModelName = ReadModelName(designParams);

            var nodeId = ReadString(nodeObject["nodeId"]) ?? ReadString(nodeObject["id"]) ?? string.Empty;
            var nodeName = ReadString(nodeObject["name"]) ?? ReadString(designParams["name"]) ?? string.Empty;
            var currentSettingLabel = ReadString(designParams["llm_setting_label"]);
            var key = MakeKey(currentModelName, currentSettingName);

            if (!mappings.TryGetValue(key, out var mapping))
            {
                // 找不到映射时不修改节点，只记录下来供人工补充映射清单。
                unmappedModels.Add(new UnmappedModelRecord(
                    row.FlowId,
                    row.FlowName,
                    nodeId,
                    nodeName,
                    currentModelName ?? string.Empty,
                    currentSettingName ?? string.Empty));
                continue;
            }

            // 找到映射后更新节点中的多个冗余字段，并记录替换明细。
            var newSettingLabel = string.IsNullOrWhiteSpace(mapping.NewSettingLabel)
                ? currentSettingLabel
                : mapping.NewSettingLabel;
            ApplyMapping(designParams, mapping);
            replacements.Add(new ReplacementRecord(
                row.FlowId,
                row.FlowName,
                nodeId,
                nodeName,
                mapping.OldModelName,
                mapping.OldSettingName,
                mapping.NewModelName,
                mapping.NewSettingName,
                currentSettingLabel ?? string.Empty,
                newSettingLabel ?? string.Empty));
            changed = true;
        }

        if (!changed)
        {
            return new RepairContextOutcome(
                row.Context,
                false,
                replacements,
                unmappedModels,
                knowledgeBaseReplacements,
                unmappedKnowledgeBases);
        }

        // 发生修改后重新序列化整个 context，确保写回的是最新 JSON。
        return new RepairContextOutcome(
            ToReadableJson(root) ?? string.Empty,
            true,
            replacements,
            unmappedModels,
            knowledgeBaseReplacements,
            unmappedKnowledgeBases);
    }

    /// <summary>
    /// 把一条映射规则应用到节点的 designParams 上。
    /// </summary>
    /// <param name="designParams">流程节点的设计参数 JSON 对象。</param>
    /// <param name="mapping">匹配到的模型映射规则。</param>
    private static void ApplyMapping(JObject designParams, ModelMapping mapping)
    {
        // llm_model_name 是前端选择器使用的对象结构，需要同时更新 label 和 value。
        if (designParams["llm_model_name"] is JObject modelNameObject)
        {
            modelNameObject["label"] = mapping.NewModelName;
            modelNameObject["value"] = mapping.NewModelName;
            if (mapping.NewProvider.HasValue)
            {
                modelNameObject["provider"] = mapping.NewProvider.Value;
            }
        }

        // 顶层配置名称用于流程运行时读取。
        designParams["llm_setting_name"] = mapping.NewSettingName;
        if (!string.IsNullOrWhiteSpace(mapping.NewSettingLabel))
        {
            designParams["llm_setting_label"] = mapping.NewSettingLabel;
        }

        // LLMSetting 是另一份冗余配置，也需要同步更新以保持一致。
        if (designParams["LLMSetting"] is JObject llmSettingObject)
        {
            llmSettingObject["llm_model_name"] = mapping.NewModelName;
            llmSettingObject["llm_setting_name"] = mapping.NewSettingName;
            if (mapping.NewProvider.HasValue)
            {
                llmSettingObject["llm_provider"] = mapping.NewProvider.Value;
            }
        }
    }

    /// <summary>
    /// 修复知识库插件参数，把第三方的 knowledgeBaseName 参数迁移为当前系统的 libraryid。
    /// </summary>
    /// <param name="row">数据库中的流程记录。</param>
    /// <param name="nodeObject">流程节点 JSON 对象。</param>
    /// <param name="designParams">流程节点的设计参数 JSON 对象。</param>
    /// <param name="knowledgeBaseMappings">知识库名称到当前系统知识库 ID 的映射字典。</param>
    /// <param name="replacements">知识库替换明细列表。</param>
    /// <param name="unmappedKnowledgeBases">未命中知识库映射的记录列表。</param>
    /// <returns>当前节点是否发生变更。</returns>
    private static bool TryRepairKnowledgeBasePlugin(
        FlowContextRow row,
        JObject nodeObject,
        JObject designParams,
        IReadOnlyDictionary<string, string> knowledgeBaseMappings,
        List<KnowledgeBaseReplacementRecord> replacements,
        List<UnmappedKnowledgeBaseRecord> unmappedKnowledgeBases)
    {
        if (designParams["plugin"] is not JObject pluginObject ||
            !string.Equals(ReadString(pluginObject["pluginUUID"]), KnowledgeBasePluginUuid, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        designParams["module"] = KnowledgeBasePluginName;
        pluginObject["pluginName"] = KnowledgeBasePluginName;
        var changed = true;

        if (knowledgeBaseMappings.Count == 0)
        {
            return changed;
        }

        var nodeId = ReadString(nodeObject["nodeId"]) ?? ReadString(nodeObject["id"]) ?? string.Empty;
        var nodeName = ReadString(nodeObject["name"]) ?? ReadString(designParams["name"]) ?? string.Empty;
        var inputs = designParams["input"] as JArray;

        if (pluginObject["functions"] is JArray functions)
        {
            foreach (var function in functions.OfType<JObject>())
            {
                if (function["parameters"] is not JArray parameters)
                {
                    continue;
                }

                foreach (var parameter in parameters.OfType<JObject>())
                {
                    if (!string.Equals(ReadString(parameter["param_name"]), "knowledgeBaseName", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    var paramValue = parameter["param_value"] as JObject;
                    var variableId = ReadString(paramValue?["variableId"]);
                    var input = FindInputByVariableId(inputs, variableId);
                    var knowledgeBaseName = ReadString(input?["value"]) ?? ReadString(paramValue?["value"]);
                    if (string.IsNullOrWhiteSpace(knowledgeBaseName) ||
                        !knowledgeBaseMappings.TryGetValue(knowledgeBaseName.Trim(), out var libraryId))
                    {
                        unmappedKnowledgeBases.Add(new UnmappedKnowledgeBaseRecord(
                            row.FlowId,
                            row.FlowName,
                            nodeId,
                            nodeName,
                            knowledgeBaseName ?? string.Empty));
                        continue;
                    }

                    parameter["param_name"] = "libraryid";
                    parameter["description"] = "知识库id";
                    if (parameter["description_dic"] is JObject descriptionDic)
                    {
                        descriptionDic["x-description-cn"] = "知识库id";
                    }

                    if (paramValue != null)
                    {
                        paramValue["value"] = libraryId;
                    }
                    if (input != null)
                    {
                        // input 中的 name/variable 等字段保持原样，只把 value 替换为 libraryid。
                        input["value"] = libraryId;
                    }

                    replacements.Add(new KnowledgeBaseReplacementRecord(
                        row.FlowId,
                        row.FlowName,
                        nodeId,
                        nodeName,
                        knowledgeBaseName,
                        libraryId));
                    changed = true;
                }
            }
        }

        return changed;
    }

    /// <summary>
    /// 根据函数参数中的 variableId 找到 designParams.input 中对应的输入参数。
    /// </summary>
    /// <param name="inputs">designParams.input 数组。</param>
    /// <param name="variableId">函数参数 param_value 中的 variableId。</param>
    /// <returns>匹配的输入参数；找不到时返回 null。</returns>
    private static JObject? FindInputByVariableId(JArray? inputs, string? variableId)
    {
        if (inputs == null || string.IsNullOrWhiteSpace(variableId))
        {
            return null;
        }

        foreach (var input in inputs.OfType<JObject>())
        {
            if (string.Equals(ReadString(input["variableId"]), variableId, StringComparison.Ordinal))
            {
                return input;
            }
        }

        return null;
    }

    /// <summary>
    /// 从 designParams 中读取当前模型名称。
    /// </summary>
    /// <param name="designParams">流程节点的设计参数 JSON 对象。</param>
    /// <returns>模型名称；找不到时返回 null。</returns>
    private static string? ReadModelName(JObject designParams)
    {
        // 优先读取前端选择器结构中的 label/value。
        if (designParams["llm_model_name"] is JObject modelNameObject)
        {
            return ReadString(modelNameObject["label"]) ?? ReadString(modelNameObject["value"]);
        }

        // 兼容保存在 LLMSetting 里的模型名称。
        if (designParams["LLMSetting"] is JObject llmSettingObject)
        {
            return ReadString(llmSettingObject["llm_model_name"]);
        }

        return null;
    }

    /// <summary>
    /// 将 JSON 节点安全读取为字符串。
    /// </summary>
    /// <param name="node">待读取的 JSON 节点。</param>
    /// <returns>字符串值；节点为空时返回 null。</returns>
    private static string? ReadString(JToken? node)
    {
        if (node is null)
        {
            return null;
        }

        if (node.Type == JTokenType.Null)
        {
            return null;
        }

        if (node.Type == JTokenType.String)
        {
            return node.Value<string>();
        }

        // 非字符串节点也保留其 JSON 文本，避免读取失败导致信息丢失。
        return ToReadableJson(node);
    }

    /// <summary>
    /// 加载 Excel 模型映射清单。
    /// </summary>
    /// <param name="mappingPath">映射清单文件路径。</param>
    /// <returns>通过校验的模型映射和知识库映射。</returns>
    private static MappingWorkbook LoadMappings(string mappingPath)
    {
        var extension = Path.GetExtension(mappingPath).ToLowerInvariant();
        if (extension != ".xlsx")
        {
            throw new InvalidOperationException("模型映射清单必须是 .xlsx Excel 文件。");
        }

        using var workbook = new XLWorkbook(mappingPath);
        return new MappingWorkbook(
            LoadModelMappings(workbook),
            LoadKnowledgeBaseMappings(workbook));
    }

    /// <summary>
    /// 从 Excel 文件的第一个 sheet 加载模型映射清单。
    /// </summary>
    /// <param name="workbook">Excel 工作簿。</param>
    /// <returns>通过校验的模型映射列表。</returns>
    private static IReadOnlyList<ModelMapping> LoadModelMappings(XLWorkbook workbook)
    {
        var worksheet = workbook.Worksheets.FirstOrDefault()
            ?? throw new InvalidOperationException("Excel 映射清单没有任何 sheet。");

        var usedRange = worksheet.RangeUsed();
        if (usedRange == null)
        {
            throw new InvalidOperationException("Excel 第一个 sheet 至少需要表头。");
        }

        // 归一化表头后再匹配，允许用户在表头中加入空格、下划线或连字符。
        var headers = usedRange.FirstRow()
            .Cells()
            .Select(cell => NormalizeHeader(cell.GetString()))
            .ToList();

        if (usedRange.RowCount() < 2)
        {
            return [];
        }

        var mappings = new List<ModelMapping>();
        foreach (var row in usedRange.RowsUsed().Skip(1))
        {
            // 在当前行中按候选表头名称取值。
            string GetValue(params string[] names)
            {
                foreach (var name in names.Select(NormalizeHeader))
                {
                    var index = headers.FindIndex(header => header == name);
                    if (index >= 0)
                    {
                        return row.Cell(index + 1).GetString().Trim();
                    }
                }

                return string.Empty;
            }

            mappings.Add(CreateMapping(
                GetValue("要替换的模型名称", "oldModelName", "old_model", "sourceModelName"),
                GetValue("要替换的模型参数名称", "oldSettingName", "old_setting", "sourceSettingName"),
                GetValue("替换后的模型名称", "newModelName", "new_model", "targetModelName"),
                GetValue("替换后的模型参数名称", "newSettingName", "new_setting", "targetSettingName"),
                GetValue("替换后的模型provider", "newProvider", "new_provider", "provider"),
                GetValue("替换后的模型参数显示名称", "newSettingLabel", "new_setting_label", "settingLabel")));
        }

        return ValidateMappings(mappings);
    }

    /// <summary>
    /// 从 Excel 第二个 sheet 加载知识库名称到 libraryid 的映射清单。
    /// </summary>
    /// <param name="workbook">Excel 工作簿。</param>
    /// <returns>通过校验的知识库映射列表；没有第二个 sheet 时返回空列表。</returns>
    private static IReadOnlyList<KnowledgeBaseMapping> LoadKnowledgeBaseMappings(XLWorkbook workbook)
    {
        var worksheet = workbook.Worksheets.Skip(1).FirstOrDefault();
        if (worksheet == null)
        {
            return [];
        }

        var usedRange = worksheet.RangeUsed();
        if (usedRange == null || usedRange.RowCount() < 2)
        {
            return [];
        }

        var headers = usedRange.FirstRow()
            .Cells()
            .Select(cell => NormalizeHeader(cell.GetString()))
            .ToList();

        var mappings = new List<KnowledgeBaseMapping>();
        foreach (var row in usedRange.RowsUsed().Skip(1))
        {
            string GetValue(params string[] names)
            {
                foreach (var name in names.Select(NormalizeHeader))
                {
                    var index = headers.FindIndex(header => header == name);
                    if (index >= 0)
                    {
                        return row.Cell(index + 1).GetString().Trim();
                    }
                }

                return string.Empty;
            }

            mappings.Add(new KnowledgeBaseMapping(
                GetValue("knowledgeBaseName", "knowledge_base_name", "知识库名称", "第三方知识库名称"),
                GetValue("libraryid", "libraryId", "library_id", "知识库id", "知识库ID")));
        }

        return ValidateKnowledgeBaseMappings(mappings);
    }

    /// <summary>
    /// 将读取到的原始字段值转换成模型映射对象。
    /// </summary>
    /// <param name="oldModelName">旧模型名称。</param>
    /// <param name="oldSettingName">旧模型配置名称。</param>
    /// <param name="newModelName">新模型名称。</param>
    /// <param name="newSettingName">新模型配置名称。</param>
    /// <param name="newProvider">新模型提供方编号文本。</param>
    /// <param name="newSettingLabel">新模型配置显示名称。</param>
    /// <returns>清理空白并转换 provider 后的映射对象。</returns>
    private static ModelMapping CreateMapping(
        string oldModelName,
        string oldSettingName,
        string newModelName,
        string newSettingName,
        string newProvider,
        string newSettingLabel)
    {
        return new ModelMapping(
            oldModelName.Trim(),
            oldSettingName.Trim(),
            newModelName.Trim(),
            newSettingName.Trim(),
            int.TryParse(newProvider, out var provider) ? provider : null,
            string.IsNullOrWhiteSpace(newSettingLabel) ? null : newSettingLabel.Trim());
    }

    /// <summary>
    /// 校验映射清单内容，并过滤完全空白的行。
    /// </summary>
    /// <param name="mappings">待校验的映射列表。</param>
    /// <returns>可用于修复的有效映射列表。</returns>
    private static IReadOnlyList<ModelMapping> ValidateMappings(List<ModelMapping> mappings)
    {
        // 完全空白的行通常是 Excel 尾部空行，直接忽略。
        var validMappings = mappings
            .Where(mapping =>
                !string.IsNullOrWhiteSpace(mapping.OldModelName) ||
                !string.IsNullOrWhiteSpace(mapping.OldSettingName) ||
                !string.IsNullOrWhiteSpace(mapping.NewModelName) ||
                !string.IsNullOrWhiteSpace(mapping.NewSettingName))
            .ToList();

        foreach (var mapping in validMappings)
        {
            // 旧模型、旧配置、新模型、新配置是构成映射的必填字段。
            if (string.IsNullOrWhiteSpace(mapping.OldModelName) ||
                string.IsNullOrWhiteSpace(mapping.OldSettingName) ||
                string.IsNullOrWhiteSpace(mapping.NewModelName) ||
                string.IsNullOrWhiteSpace(mapping.NewSettingName))
            {
                throw new InvalidOperationException("映射清单存在空字段：旧模型、旧参数、新模型、新参数都必须填写。");
            }
        }

        // 同一组旧模型/旧配置只能对应一条目标映射，避免修复结果不确定。
        var duplicate = validMappings
            .GroupBy(mapping => MakeKey(mapping.OldModelName, mapping.OldSettingName), MappingKeyComparer)
            .FirstOrDefault(group => group.Count() > 1);
        if (duplicate != null)
        {
            throw new InvalidOperationException($"映射清单存在重复旧模型组合: {duplicate.First().OldModelName}/{duplicate.First().OldSettingName}");
        }

        return validMappings;
    }

    /// <summary>
    /// 校验知识库映射清单内容，并过滤完全空白的行。
    /// </summary>
    /// <param name="mappings">待校验的知识库映射列表。</param>
    /// <returns>可用于修复的有效知识库映射列表。</returns>
    private static IReadOnlyList<KnowledgeBaseMapping> ValidateKnowledgeBaseMappings(List<KnowledgeBaseMapping> mappings)
    {
        var validMappings = mappings
            .Where(mapping =>
                !string.IsNullOrWhiteSpace(mapping.KnowledgeBaseName) ||
                !string.IsNullOrWhiteSpace(mapping.LibraryId))
            .ToList();

        foreach (var mapping in validMappings)
        {
            if (string.IsNullOrWhiteSpace(mapping.KnowledgeBaseName) ||
                string.IsNullOrWhiteSpace(mapping.LibraryId))
            {
                throw new InvalidOperationException("知识库映射清单存在空字段：knowledgeBaseName 和 libraryid 都必须填写。");
            }
        }

        var duplicate = validMappings
            .GroupBy(mapping => mapping.KnowledgeBaseName.Trim(), MappingKeyComparer)
            .FirstOrDefault(group => group.Count() > 1);
        if (duplicate != null)
        {
            throw new InvalidOperationException($"知识库映射清单存在重复知识库名称: {duplicate.First().KnowledgeBaseName}");
        }

        return validMappings;
    }

    /// <summary>
    /// 归一化表头，提升中文/英文表头匹配的容错性。
    /// </summary>
    /// <param name="value">原始表头。</param>
    /// <returns>去除常见分隔符并转小写后的表头。</returns>
    private static string NormalizeHeader(string value)
    {
        return value
            .Trim()
            .Replace(" ", string.Empty)
            .Replace("_", string.Empty)
            .Replace("-", string.Empty)
            .ToLowerInvariant();
    }

    /// <summary>
    /// 生成模型名称和配置名称组成的字典键。
    /// </summary>
    /// <param name="modelName">模型名称。</param>
    /// <param name="settingName">配置名称。</param>
    /// <returns>可安全区分两个字段边界的组合键。</returns>
    private static string MakeKey(string? modelName, string? settingName)
    {
        // 使用固定分隔符组合两个字段；实际比较由 MappingKeyComparer 控制为大小写不敏感。
        return $"{modelName?.Trim() ?? string.Empty}&&{settingName?.Trim() ?? string.Empty}";
    }

    /// <summary>
    /// 表示从 t_flow_info 读取到的一条流程 context 记录。
    /// </summary>
    /// <param name="RowId">SQLite 内部 rowid，用于精确写回当前行。</param>
    /// <param name="FlowId">流程 ID。</param>
    /// <param name="FlowName">流程名称。</param>
    /// <param name="Context">流程 JSON 上下文。</param>
    private sealed record FlowContextRow(long RowId, string FlowId, string FlowName, string Context);

    /// <summary>
    /// 表示从 Excel 映射文件读取到的全部映射数据。
    /// </summary>
    /// <param name="ModelMappings">模型配置映射列表。</param>
    /// <param name="KnowledgeBaseMappings">知识库名称到 libraryid 的映射列表。</param>
    private sealed record MappingWorkbook(
        IReadOnlyList<ModelMapping> ModelMappings,
        IReadOnlyList<KnowledgeBaseMapping> KnowledgeBaseMappings);

    /// <summary>
    /// 表示单条流程 context 的修复结果。
    /// </summary>
    /// <param name="Context">修复后的流程 JSON；未修改时保持原文。</param>
    /// <param name="Changed">当前流程 context 是否发生变更。</param>
    /// <param name="Replacements">当前流程中的替换明细。</param>
    /// <param name="UnmappedModels">当前流程中未找到映射的模型配置。</param>
    /// <param name="KnowledgeBaseReplacements">当前流程中的知识库插件参数替换明细。</param>
    /// <param name="UnmappedKnowledgeBases">当前流程中未找到映射的知识库名称。</param>
    private sealed record RepairContextOutcome(
        string Context,
        bool Changed,
        IReadOnlyList<ReplacementRecord> Replacements,
        IReadOnlyList<UnmappedModelRecord> UnmappedModels,
        IReadOnlyList<KnowledgeBaseReplacementRecord> KnowledgeBaseReplacements,
        IReadOnlyList<UnmappedKnowledgeBaseRecord> UnmappedKnowledgeBases)
    {
        /// <summary>
        /// 创建一个表示未发生变更的修复结果。
        /// </summary>
        /// <param name="context">原始流程 JSON。</param>
        /// <returns>未变更的修复结果。</returns>
        public static RepairContextOutcome Empty(string context)
        {
            return new RepairContextOutcome(context, false, [], [], [], []);
        }
    }
}
