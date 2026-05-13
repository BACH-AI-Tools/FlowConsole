using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Flow.DbModels;
using Microsoft.Data.Sqlite;
using System.Text.Json;

var exitCode = 0;
try
{
    // 统一入口：根据命令行参数或交互菜单调度不同的流程步骤。
    exitCode = await RunAsync(args);
}
catch (Exception ex)
{
    Console.Error.WriteLine($"程序执行失败: {ex.Message}");
    exitCode = 1;
}

// 等待用户确认后再关闭控制台窗口，方便查看执行结果。
PromptBeforeExit();
return exitCode;

// 读取基础配置，并根据命令行参数选择要执行的功能。
static async Task<int> RunAsync(string[] args)
{
    // 配置文件固定从程序输出目录读取，便于发布后按环境替换 appsettings.json。
    var configuration = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
        .Build();

    var sourceGetFlowUrl = GetRequiredConfigurationValue(configuration, "SourceFlowApi:GetFlowUrl");
    var sourceFlowApiToken = GetRequiredConfigurationValue(configuration, "SourceFlowApi:Token");
    var databaseConnectionString = GetRequiredConfigurationValue(configuration, "ConnectionStrings:DefaultConnection");

    // 命令行参数用于自动化执行；无参数时进入交互菜单。
    if (args.Contains("--test-db"))
    {
        return await TestDatabaseAsync(databaseConnectionString);
    }

    if (args.Contains("--list-flow-ids"))
    {
        return await ListFlowIdsAsync(sourceGetFlowUrl, sourceFlowApiToken);
    }

    if (args.Contains("--download-sqlite"))
    {
        return await DownloadSqliteFromConfigurationAsync(
            configuration,
            sourceGetFlowUrl,
            sourceFlowApiToken,
            databaseConnectionString);
    }

    if (args.Contains("--generate-mapping-excel"))
    {
        return await GenerateMappingExcelAsync(databaseConnectionString);
    }

    if (args.Contains("--repair-exported-sqlite"))
    {
        return await RepairExportedSqliteFromConfigurationAsync(configuration, databaseConnectionString);
    }

    if (args.Contains("--import-new-sqlite"))
    {
        return await ImportNewSqliteFromConfigurationAsync(configuration, databaseConnectionString);
    }

    return await RunInteractiveMenuAsync(
        configuration,
        sourceGetFlowUrl,
        sourceFlowApiToken,
        databaseConnectionString);
}

// 控制台退出前暂停，避免双击运行时窗口立即关闭。
static void PromptBeforeExit()
{
    Console.WriteLine();
    Console.Write("按任意键退出...");
    Console.ReadKey(intercept: true);
    Console.WriteLine();
}

// 读取必填配置项，缺失时直接中止当前流程。
static string GetRequiredConfigurationValue(IConfiguration configuration, string key)
{
    var value = configuration[key];

    if (string.IsNullOrWhiteSpace(value))
    {
        throw new InvalidOperationException($"配置项缺失: {key}");
    }

    return value;
}

// 读取整数配置项，未配置时使用调用方提供的默认值。
static int GetConfigurationIntOrDefault(IConfiguration configuration, string key, int defaultValue)
{
    var value = configuration[key];

    if (string.IsNullOrWhiteSpace(value))
    {
        return defaultValue;
    }

    if (!int.TryParse(value, out var result))
    {
        throw new InvalidOperationException($"配置项不是有效数字: {key}");
    }

    return result;
}

// 展示交互菜单，并按用户选择串联执行导出、修复、导入等步骤。
static async Task<int> RunInteractiveMenuAsync(
    IConfiguration configuration,
    string sourceGetFlowUrl,
    string sourceFlowApiToken,
    string databaseConnectionString)
{
    Console.WriteLine("请选择要开始执行的步骤：");
    Console.WriteLine();
    Console.WriteLine("完整流程执行顺序：");
    Console.WriteLine("1. 读取 flowExt/flow_ids.txt，递归收集并去重所有 flow_id。");
    Console.WriteLine("2. 从源环境导出 sqlite 到 flowExt/sqlite。");
    Console.WriteLine("3. 扫描 flowExt/sqlite 生成 flowExt/excel/mapping.xlsx，生成后需要人工补全 Excel。");
    Console.WriteLine("4. 根据已补全的 mapping.xlsx 修复 sqlite，输出到 flowExt/newSqlite。");
    Console.WriteLine("5. 导入 flowExt/newSqlite 到目标环境，并修复目标库主流程与子流程映射。");
    Console.WriteLine();
    Console.WriteLine("可选操作：");
    Console.WriteLine("1 - 从步骤 1 开始：导出 sqlite 并生成 mapping.xlsx（执行到步骤 3 后暂停，等待人工填写 Excel）");
    Console.WriteLine("3 - 从步骤 3 开始：仅根据现有 flowExt/sqlite 重新生成 mapping.xlsx（执行后暂停）");
    Console.WriteLine("4 - 从步骤 4 开始：根据已填写的 mapping.xlsx 生成 newSqlite，并继续执行步骤 5 导入");
    Console.WriteLine("5 - 从步骤 5 开始：仅导入现有 flowExt/newSqlite 并修复子流程映射");
    Console.WriteLine("L - 仅递归列出 flow_id");
    Console.WriteLine("T - 测试数据库连接");
    Console.WriteLine("0 - 退出");
    Console.WriteLine();
    Console.Write("请输入选项：");

    var option = Console.ReadLine()?.Trim();
    Console.WriteLine();

    // 选项编号与业务步骤保持一致，便于从中间步骤恢复执行。
    switch (option?.ToUpperInvariant())
    {
        case "1":
            return await DownloadSqliteFromConfigurationAsync(
                configuration,
                sourceGetFlowUrl,
                sourceFlowApiToken,
                databaseConnectionString);
        case "3":
            return await GenerateMappingExcelAsync(databaseConnectionString);
        case "4":
            {
                // 步骤 4 成功生成 newSqlite 后，继续执行步骤 5 导入目标环境。
                var repairCode = await RepairExportedSqliteFromConfigurationAsync(configuration, databaseConnectionString);
                if (repairCode != 0)
                {
                    return repairCode;
                }

                return await ImportNewSqliteFromConfigurationAsync(configuration, databaseConnectionString);
            }
        case "5":
            return await ImportNewSqliteFromConfigurationAsync(configuration, databaseConnectionString);
        case "L":
            return await ListFlowIdsAsync(sourceGetFlowUrl, sourceFlowApiToken);
        case "T":
            return await TestDatabaseAsync(databaseConnectionString);
        case "0":
            Console.WriteLine("已退出。");
            return 0;
        default:
            Console.Error.WriteLine("无效选项。");
            return 1;
    }
}

// 从配置读取源环境导出参数，并启动 sqlite 导出下载流程。
static async Task<int> DownloadSqliteFromConfigurationAsync(
    IConfiguration configuration,
    string sourceGetFlowUrl,
    string sourceFlowApiToken,
    string databaseConnectionString)
{
    var exportSqliteUrl = GetRequiredConfigurationValue(configuration, "SourceFlowApi:ExportSqliteUrl");
    var exportStatusUrl = GetRequiredConfigurationValue(configuration, "SourceFlowApi:ExportStatusUrl");
    var pollIntervalSeconds = GetConfigurationIntOrDefault(configuration, "SourceFlowApi:ExportPollIntervalSeconds", 2);
    var maxWaitSeconds = GetConfigurationIntOrDefault(configuration, "SourceFlowApi:ExportMaxWaitSeconds", 600);

    return await DownloadSqliteAsync(
        sourceGetFlowUrl,
        exportSqliteUrl,
        exportStatusUrl,
        sourceFlowApiToken,
        databaseConnectionString,
        TimeSpan.FromSeconds(pollIntervalSeconds),
        TimeSpan.FromSeconds(maxWaitSeconds));
}

// 从配置读取目标环境密钥接口参数，并启动已导出 sqlite 的修复流程。
static async Task<int> RepairExportedSqliteFromConfigurationAsync(
    IConfiguration configuration,
    string databaseConnectionString)
{
    var targetSaveSecretUrl = GetRequiredConfigurationValue(configuration, "TargetFlowApi:SaveSecretUrl");
    var targetFlowApiToken = GetRequiredConfigurationValue(configuration, "TargetFlowApi:Token");
    return await RepairExportedSqliteAsync(databaseConnectionString, targetSaveSecretUrl, targetFlowApiToken);
}

// 从配置读取目标环境导入参数，并启动 newSqlite 导入流程。
static async Task<int> ImportNewSqliteFromConfigurationAsync(
    IConfiguration configuration,
    string databaseConnectionString)
{
    var targetSaveSecretUrl = GetRequiredConfigurationValue(configuration, "TargetFlowApi:SaveSecretUrl");
    var targetImportSqliteUrl = GetRequiredConfigurationValue(configuration, "TargetFlowApi:ImportSqliteUrl");
    var targetImportStatusUrl = GetRequiredConfigurationValue(configuration, "TargetFlowApi:ImportStatusUrl");
    var targetCategoryUrl = GetRequiredConfigurationValue(configuration, "TargetFlowApi:CategoryUrl");
    var targetFlowApiToken = GetRequiredConfigurationValue(configuration, "TargetFlowApi:Token");
    var pollIntervalSeconds = GetConfigurationIntOrDefault(configuration, "TargetFlowApi:ImportPollIntervalSeconds", 2);
    var maxWaitSeconds = GetConfigurationIntOrDefault(configuration, "TargetFlowApi:ImportMaxWaitSeconds", 600);

    // 导入前让用户选择目标分类，并把分类 ID 追加到导入接口地址。
    var targetCategoryId = await SelectTargetCategoryIdAsync(targetCategoryUrl, targetFlowApiToken);
    targetImportSqliteUrl = BuildImportSqliteUrl(targetImportSqliteUrl, targetCategoryId);

    return await ImportNewSqliteAsync(
        databaseConnectionString,
        targetSaveSecretUrl,
        targetImportSqliteUrl,
        targetImportStatusUrl,
        targetFlowApiToken,
        TimeSpan.FromSeconds(pollIntervalSeconds),
        TimeSpan.FromSeconds(maxWaitSeconds));
}

// 查询目标环境分类列表，并要求用户选择导入分类。
static async Task<int> SelectTargetCategoryIdAsync(string categoryUrl, string token)
{
    using var httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(60)
    };
    using var request = new HttpRequestMessage(HttpMethod.Get, categoryUrl);
    request.Headers.TryAddWithoutValidation("token", token);

    // 目标分类用于导入接口的 target_category_id 参数。
    using var response = await httpClient.SendAsync(request);
    var responseText = await response.Content.ReadAsStringAsync();

    ApiResponseHelper.EnsureSuccessStatusCode(response, responseText, "查询目标分类");

    using var document = JsonDocument.Parse(responseText);
    var root = document.RootElement;
    ApiResponseHelper.EnsureGeneralResponseSuccess(root, responseText, "查询目标分类");

    if (!root.TryGetProperty("body", out var body) || body.ValueKind != JsonValueKind.Array)
    {
        throw new InvalidOperationException("目标分类接口响应缺少 body 数组。");
    }

    var categories = new List<TargetCategoryOption>();
    foreach (var item in body.EnumerateArray())
    {
        // 分类接口返回多语言名称，这里优先取 tw，兼容没有 tw 时取 cn。
        if (!item.TryGetProperty("super_agent_category_id", out var idElement) ||
            !idElement.TryGetInt32(out var id))
        {
            continue;
        }

        var nameJson = item.TryGetProperty("name", out var nameElement)
            ? nameElement.GetString()
            : null;
        var twName = ReadTwName(nameJson);
        if (string.Equals(twName, "全部", StringComparison.OrdinalIgnoreCase))
        {
            // “全部”不是具体导入目标，避免误选后导入到聚合分类。
            continue;
        }

        categories.Add(new TargetCategoryOption(id, twName));
    }

    if (categories.Count == 0)
    {
        throw new InvalidOperationException("目标环境没有可选择的分类。");
    }

    Console.WriteLine("请选择导入目标分类：");
    foreach (var category in categories)
    {
        Console.WriteLine($"{category.SuperAgentCategoryId} - {category.TwName}");
    }
    Console.WriteLine();

    while (true)
    {
        Console.Write("请输入分类编号：");
        var input = Console.ReadLine()?.Trim();
        // 只允许选择接口返回的分类 ID，避免构造不存在的目标分类。
        if (int.TryParse(input, out var selectedId) &&
            categories.Any(category => category.SuperAgentCategoryId == selectedId))
        {
            return selectedId;
        }

        Console.WriteLine("输入的分类编号不在列表中，请重新输入。");
    }
}

// 从分类名称的多语言 JSON 中读取繁体名称，失败时保留原始字符串。
static string ReadTwName(string? nameJson)
{
    if (string.IsNullOrWhiteSpace(nameJson))
    {
        return string.Empty;
    }

    try
    {
        // name 通常是 {"tw":"...","cn":"..."}，优先使用目标环境显示的 tw 名称。
        using var document = JsonDocument.Parse(nameJson);
        var root = document.RootElement;
        if (root.TryGetProperty("tw", out var twElement))
        {
            return twElement.GetString() ?? string.Empty;
        }

        if (root.TryGetProperty("cn", out var cnElement))
        {
            return cnElement.GetString() ?? string.Empty;
        }
    }
    catch (JsonException)
    {
        return nameJson;
    }

    return nameJson;
}

// 将用户选择的目标分类 ID 拼接到 sqlite 导入接口地址。
static string BuildImportSqliteUrl(string importSqliteUrl, int targetCategoryId)
{
    var separator = importSqliteUrl.Contains('?') ? '&' : '?';
    return $"{importSqliteUrl}{separator}target_category_id={targetCategoryId}";
}

// 通过读取 t_flow 首条数据验证数据库连接和 EF 映射是否可用。
static async Task<int> TestDatabaseAsync(string connectionString)
{
    var options = new DbContextOptionsBuilder<FlowDbContext>()
        .UseSqlServer(connectionString)
        .Options;

    await using var dbContext = new FlowDbContext(options);
    // 只查询必要字段，避免测试连接时加载完整流程内容。
    var flow = await dbContext.TFlows
        .AsNoTracking()
        .OrderBy(item => item.FlowId)
        .Select(item => new
        {
            item.FlowId,
            item.Name
        })
        .FirstOrDefaultAsync();

    if (flow is null)
    {
        Console.WriteLine("数据库连接成功，但 t_flow 表没有查询到数据。");
        return 2;
    }

    Console.WriteLine("数据库查询成功");
    Console.WriteLine($"table: t_flow");
    Console.WriteLine($"flow_id: {flow.FlowId}");
    Console.WriteLine($"name: {flow.Name}");
    return 0;
}

// 读取根流程 ID，并递归列出主流程和子流程的去重结果。
static async Task<int> ListFlowIdsAsync(string getFlowUrl, string token)
{
    try
    {
        using var httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(60)
        };

        var rootFlowIds = await ReadRootFlowIdsAsync();
        var flowIds = await CollectDistinctFlowIdsAsync(httpClient, rootFlowIds, getFlowUrl, token);

        // 输出根流程和递归收集后的完整列表，方便人工核对导出范围。
        Console.WriteLine("流程 ID 收集完成");
        Console.WriteLine($"root_flow_ids: {string.Join(", ", rootFlowIds)}");
        Console.WriteLine($"flow_count: {flowIds.Count}");
        Console.WriteLine($"flow_ids: {string.Join(", ", flowIds)}");
        return 0;
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"流程 ID 收集失败: {ex.Message}");
        return 1;
    }
}

// 递归收集流程 ID，批量导出 sqlite，并在下载完成后生成映射 Excel。
static async Task<int> DownloadSqliteAsync(
    string getFlowUrl,
    string exportSqliteUrl,
    string exportStatusUrl,
    string token,
    string databaseConnectionString,
    TimeSpan pollInterval,
    TimeSpan maxWaitTime)
{
    try
    {
        using var httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(60)
        };

        var rootFlowIds = await ReadRootFlowIdsAsync();
        var flowIds = await CollectDistinctFlowIdsAsync(httpClient, rootFlowIds, getFlowUrl, token);

        // 导出器负责发起导出、轮询状态并下载 sqlite 文件。
        var exporter = new FlowSqliteExporter(
            httpClient,
            exportSqliteUrl,
            exportStatusUrl,
            token,
            pollInterval,
            maxWaitTime);

        // 每次导出前清理旧文件，避免后续 Excel 和导入步骤混入历史数据。
        FlowSqliteExporter.ClearSqliteDirectory();
        ClearNewSqliteDirectory();

        Console.WriteLine("流程 ID 收集完成");
        Console.WriteLine($"root_flow_ids: {string.Join(", ", rootFlowIds)}");
        Console.WriteLine($"flow_count: {flowIds.Count}");
        Console.WriteLine($"flow_ids: {string.Join(", ", flowIds)}");

        var downloadResults = new List<(string FlowId, string FlowName, string SqlitePath)>();

        foreach (var flowIdBatch in flowIds.Chunk(5))
        {
            // 分批并发下载，降低接口压力的同时提升导出效率。
            var batchResults = await Task.WhenAll(flowIdBatch.Select(async flowId =>
            {
                var flowName = await GetFlowNameAsync(httpClient, flowId, getFlowUrl, token);
                var sqlitePath = await exporter.ExportAndDownloadAsync(flowId, flowName);

                return (FlowId: flowId, FlowName: flowName, SqlitePath: sqlitePath);
            }));

            downloadResults.AddRange(batchResults);

            foreach (var result in batchResults)
            {
                Console.WriteLine("sqlite 下载完成");
                Console.WriteLine($"flow_id: {result.FlowId}");
                Console.WriteLine($"flow_name: {result.FlowName}");
                Console.WriteLine($"sqlite_path: {result.SqlitePath}");
            }
        }

        Console.WriteLine("全部 sqlite 下载完成");
        Console.WriteLine($"download_count: {downloadResults.Count}");

        return await GenerateMappingExcelAsync(databaseConnectionString);
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"sqlite 下载失败: {ex.Message}");
        return 1;
    }
}

// 扫描导出的 sqlite，并生成需要人工补全的映射 Excel。
static async Task<int> GenerateMappingExcelAsync(string databaseConnectionString)
{
    try
    {
        // Excel 中汇总模型、知识库、apiCaller 密钥等跨环境映射项。
        var excelGenerator = new FlowExportPreCheckExcelGenerator();
        var excelResult = await excelGenerator.GenerateAsync(databaseConnectionString);

        Console.WriteLine("PreCheck 映射 Excel 生成完成");
        Console.WriteLine($"sqlite_file_count: {excelResult.SqliteFileCount}");
        Console.WriteLine($"model_count: {excelResult.ModelCount}");
        Console.WriteLine($"knowledge_base_count: {excelResult.KnowledgeBaseCount}");
        Console.WriteLine($"api_caller_secret_count: {excelResult.ApiCallerSecretCount}");
        Console.WriteLine($"excel_path: {excelResult.ExcelPath}");
        return 0;
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"PreCheck 映射 Excel 生成失败: {ex.Message}");
        return 1;
    }
}

// 按 mapping.xlsx 修复导出的 sqlite，并同步 apiCaller 密钥到目标环境。
static async Task<int> RepairExportedSqliteAsync(
    string databaseConnectionString,
    string saveSecretUrl,
    string token)
{
    try
    {
        var sqliteDirectory = Path.Combine(AppContext.BaseDirectory, "flowExt", "sqlite");
        var newSqliteDirectory = Path.Combine(AppContext.BaseDirectory, "flowExt", "newSqlite");
        var mappingPath = Path.Combine(AppContext.BaseDirectory, "flowExt", "excel", "mapping.xlsx");

        // 修复步骤依赖导出的 sqlite 和人工补全后的 mapping.xlsx。
        if (!Directory.Exists(sqliteDirectory))
        {
            throw new DirectoryNotFoundException($"找不到 sqlite 目录: {sqliteDirectory}");
        }

        if (!File.Exists(mappingPath))
        {
            throw new FileNotFoundException("找不到映射 Excel。", mappingPath);
        }

        // 先校验映射文件完整性，避免修复到一半才发现人工填写缺失。
        ModelMappingRepairer.ValidateMappingFile(mappingPath);
        ClearNewSqliteDirectory();

        var sqlitePaths = Directory
            .EnumerateFiles(sqliteDirectory, "*.db", SearchOption.TopDirectoryOnly)
            .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (sqlitePaths.Count == 0)
        {
            throw new InvalidOperationException($"sqlite 目录下没有 db 文件: {sqliteDirectory}");
        }

        var repairer = new ModelMappingRepairer();
        var results = new List<RepairResult>();

        foreach (var sqlitePath in sqlitePaths)
        {
            // 每个源 sqlite 独立修复并输出到 newSqlite 目录，保留原始文件不变。
            var result = await repairer.RepairAsync(new RepairOptions(
                sqlitePath,
                mappingPath,
                newSqliteDirectory,
                databaseConnectionString));
            results.Add(result);

            Console.WriteLine("sqlite 修复完成");
            Console.WriteLine($"input: {sqlitePath}");
            Console.WriteLine($"output: {result.OutputPath}");
            Console.WriteLine($"flow_count: {result.FlowCount}");
            Console.WriteLine($"changed_flow_count: {result.ChangedFlowCount}");
            Console.WriteLine($"replacement_count: {result.Replacements.Count}");
            Console.WriteLine($"knowledge_base_replacement_count: {result.KnowledgeBaseReplacements.Count}");
        }

        Console.WriteLine("全部 sqlite 修复完成");
        Console.WriteLine($"sqlite_file_count: {results.Count}");
        Console.WriteLine($"new_sqlite_directory: {newSqliteDirectory}");

        // apiCaller 密钥需要在导入前写入目标环境，确保修复后的引用可用。
        var secretSynchronizer = new MappingExcelSecretSynchronizer();
        var secretSyncResult = await secretSynchronizer.SyncAsync(
            mappingPath,
            databaseConnectionString,
            saveSecretUrl,
            token);

        Console.WriteLine("apiCaller 密钥同步完成");
        Console.WriteLine($"secret_total_count: {secretSyncResult.TotalCount}");
        Console.WriteLine($"secret_created_count: {secretSyncResult.CreatedCount}");
        Console.WriteLine($"secret_updated_count: {secretSyncResult.UpdatedCount}");
        return 0;
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"sqlite 批量修复失败: {ex.Message}");
        return 1;
    }
}

// 同步密钥后导入 newSqlite，并修复导入后主流程与子流程 ID 映射。
static async Task<int> ImportNewSqliteAsync(
    string databaseConnectionString,
    string saveSecretUrl,
    string importSqliteUrl,
    string importStatusUrl,
    string token,
    TimeSpan pollInterval,
    TimeSpan maxWaitTime)
{
    try
    {
        var mappingPath = Path.Combine(AppContext.BaseDirectory, "flowExt", "excel", "mapping.xlsx");
        if (!File.Exists(mappingPath))
        {
            throw new FileNotFoundException("找不到映射 Excel。", mappingPath);
        }

        // 导入入口也同步一次密钥，支持用户直接从步骤 5 恢复执行。
        var secretSynchronizer = new MappingExcelSecretSynchronizer();
        var secretSyncResult = await secretSynchronizer.SyncAsync(
            mappingPath,
            databaseConnectionString,
            saveSecretUrl,
            token);

        Console.WriteLine("apiCaller 密钥同步完成");
        Console.WriteLine($"secret_total_count: {secretSyncResult.TotalCount}");
        Console.WriteLine($"secret_created_count: {secretSyncResult.CreatedCount}");
        Console.WriteLine($"secret_updated_count: {secretSyncResult.UpdatedCount}");

        using var httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(60)
        };
        var importer = new FlowSqliteImporter(
            httpClient,
            importSqliteUrl,
            importStatusUrl,
            token,
            pollInterval,
            maxWaitTime);

        // 导入器负责上传所有 newSqlite 文件，并根据返回的新 flow_id 修复子流程引用。
        var importResult = await importer.ImportAllAsync(databaseConnectionString);

        Console.WriteLine("全部 sqlite 导入完成");
        Console.WriteLine($"sqlite_file_count: {importResult.SqliteFileCount}");
        Console.WriteLine($"flow_mapping_count: {importResult.FlowIdMap.Count}");
        foreach (var item in importResult.FlowIdMap.OrderBy(item => item.Key))
        {
            Console.WriteLine($"{item.Key}:{item.Value}");
        }

        Console.WriteLine($"updated_subprocess_node_count: {importResult.UpdatedSubProcessNodeCount}");
        Console.WriteLine($"updated_subprocess_publish_count: {importResult.UpdatedSubProcessPublishCount}");
        return 0;
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"sqlite 导入失败: {ex.Message}");
        return 1;
    }
}

// 清空目录中的文件，并返回成功删除的文件数量。
static int ClearDirectoryFiles(string directory)
{
    // SQLite 连接池可能仍占用 db 文件，删除前先释放池和终结器。
    SqliteConnection.ClearAllPools();
    GC.Collect();
    GC.WaitForPendingFinalizers();

    var deletedCount = 0;
    foreach (var filePath in Directory.EnumerateFiles(directory))
    {
        DeleteFileWithRetry(filePath);
        deletedCount++;
    }

    return deletedCount;
}

// 清空 newSqlite 输出目录，为本次修复结果预留干净目录。
static void ClearNewSqliteDirectory()
{
    var newSqliteDirectory = Path.Combine(AppContext.BaseDirectory, "flowExt", "newSqlite");
    Directory.CreateDirectory(newSqliteDirectory);
    var deletedCount = ClearDirectoryFiles(newSqliteDirectory);
    if (deletedCount > 0)
    {
        Console.WriteLine($"已清空旧 newSqlite 目录: {newSqliteDirectory}");
    }
}

// 删除文件时处理短暂占用，重试后仍失败则给出明确提示。
static void DeleteFileWithRetry(string filePath)
{
    const int maxAttemptCount = 3;

    for (var attempt = 1; attempt <= maxAttemptCount; attempt++)
    {
        try
        {
            File.Delete(filePath);
            return;
        }
        catch (IOException) when (attempt < maxAttemptCount)
        {
            // 外部程序或 SQLite 连接释放可能有延迟，短暂等待后重试。
            Thread.Sleep(500);
        }
        catch (UnauthorizedAccessException) when (attempt < maxAttemptCount)
        {
            // 权限或占用状态有时会在连接释放后恢复，保持与 IO 异常相同的重试策略。
            Thread.Sleep(500);
        }
    }

    try
    {
        File.Delete(filePath);
    }
    catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
    {
        throw new IOException($"删除旧文件失败，请先关闭占用该文件的程序: {filePath}", ex);
    }
}

// 从 flowExt/flow_ids.txt 读取根流程 ID，并保持文件中的首次出现顺序。
static async Task<IReadOnlyList<string>> ReadRootFlowIdsAsync()
{
    var flowExtDirectory = Path.Combine(AppContext.BaseDirectory, "flowExt");
    if (!Directory.Exists(flowExtDirectory))
    {
        Directory.CreateDirectory(flowExtDirectory);
    }

    var flowIdsPath = Path.Combine(flowExtDirectory, "flow_ids.txt");

    if (!File.Exists(flowIdsPath))
    {
        throw new InvalidOperationException($"flow_ids 文件不存在: {flowIdsPath}");
    }

    var lines = await File.ReadAllLinesAsync(flowIdsPath);
    var rootFlowIds = new List<string>();
    var seenFlowIds = new HashSet<string>(StringComparer.Ordinal);

    for (var index = 0; index < lines.Length; index++)
    {
        var line = lines[index].Trim();

        // 允许文件中用空行分隔不同批次的 flow_id。
        if (string.IsNullOrWhiteSpace(line))
        {
            continue;
        }

        var flowId = line.Trim();
        if (seenFlowIds.Add(flowId))
        {
            // 去重但不排序，避免改变人工维护的根流程顺序。
            rootFlowIds.Add(flowId);
        }
    }

    if (rootFlowIds.Count == 0)
    {
        throw new InvalidOperationException($"flow_ids 文件内容为空: {flowIdsPath}");
    }

    return rootFlowIds;
}

// 从根流程开始递归收集子流程 ID，并对结果去重。
static async Task<IReadOnlyList<string>> CollectDistinctFlowIdsAsync(
    HttpClient httpClient,
    IReadOnlyList<string> rootFlowIds,
    string getFlowUrl,
    string token)
{
    var collector = new FlowSubProcessFlowIdCollector(httpClient, getFlowUrl, token);
    var flowIds = new List<string>();
    var seenFlowIds = new HashSet<string>(StringComparer.Ordinal);

    foreach (var rootFlowId in rootFlowIds)
    {
        // CollectAsync 会返回根流程和它引用的子流程，这里合并多个根流程的结果。
        foreach (var flowId in await collector.CollectAsync(rootFlowId))
        {
            if (seenFlowIds.Add(flowId))
            {
                flowIds.Add(flowId);
            }
        }
    }

    return flowIds;
}

// 查询单个流程名称，用于导出文件命名和下载结果展示。
static async Task<string> GetFlowNameAsync(
    HttpClient httpClient,
    string flowId,
    string getFlowUrl,
    string token,
    CancellationToken cancellationToken = default)
{
    using var request = new HttpRequestMessage(HttpMethod.Get, BuildGetFlowUrl(getFlowUrl, flowId));
    request.Headers.TryAddWithoutValidation("token", token);

    // 流程名称来自源环境详情接口，和 sqlite 导出接口使用同一个 token。
    using var response = await httpClient.SendAsync(request, cancellationToken);

    if (!response.IsSuccessStatusCode)
    {
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);
        throw new InvalidOperationException(
            $"查询流程名称失败，flow_id={flowId}, status={(int)response.StatusCode}, response={responseText}");
    }

    await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);
    using var document = await JsonDocument.ParseAsync(responseStream, cancellationToken: cancellationToken);
    var root = document.RootElement;

    // 业务错误可能以 200 HTTP 状态返回，需要额外检查 err_code。
    if (root.TryGetProperty("err_code", out var errCodeElement)
        && errCodeElement.TryGetInt32(out var errCode)
        && errCode != 0)
    {
        var errMessage = root.TryGetProperty("err_message", out var errMessageElement)
            ? errMessageElement.GetString()
            : null;

        throw new InvalidOperationException(
            string.IsNullOrWhiteSpace(errMessage)
                ? $"查询流程名称失败，err_code={errCode}。"
                : errMessage);
    }

    // 兼容接口 body 包裹和直接返回流程对象两种响应结构。
    var flow = root.TryGetProperty("body", out var body) && body.ValueKind == JsonValueKind.Object
        ? body
        : root;

    if (!flow.TryGetProperty("name", out var nameElement)
        || nameElement.ValueKind != JsonValueKind.String
        || string.IsNullOrWhiteSpace(nameElement.GetString()))
    {
        throw new InvalidOperationException($"流程接口响应缺少 name，flow_id={flowId}");
    }

    return nameElement.GetString()!;
}

// 构造流程详情接口地址，兼容配置中的 {flowId} 占位符和普通查询参数形式。
static string BuildGetFlowUrl(string getFlowUrl, string flowId)
{
    const string flowIdPlaceholder = "{flowId}";
    var escapedFlowId = Uri.EscapeDataString(flowId);

    // 优先替换显式占位符，避免重复追加 flowId 参数。
    if (getFlowUrl.Contains(flowIdPlaceholder, StringComparison.OrdinalIgnoreCase))
    {
        return getFlowUrl.Replace(flowIdPlaceholder, escapedFlowId, StringComparison.OrdinalIgnoreCase);
    }

    var separator = getFlowUrl.Contains('?') ? '&' : '?';
    return $"{getFlowUrl}{separator}flowId={escapedFlowId}";
}

// 目标分类选项，包含分类 ID 和展示用繁体名称。
public sealed record TargetCategoryOption(int SuperAgentCategoryId, string TwName);
