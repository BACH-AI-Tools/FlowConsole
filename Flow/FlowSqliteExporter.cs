using Microsoft.Data.Sqlite;
using System.Text.Json;

/// <summary>
/// 调用流程导出接口并下载生成的 sqlite 文件。
/// </summary>
public sealed class FlowSqliteExporter
{
    private const string FlowIdPlaceholder = "{flowId}";
    private const string ExportIdPlaceholder = "{exportId}";

    private readonly HttpClient _httpClient;
    private readonly string _exportSqliteUrl;
    private readonly string _exportStatusUrl;
    private readonly string _token;
    private readonly TimeSpan _pollInterval;
    private readonly TimeSpan _maxWaitTime;

    public FlowSqliteExporter(
        HttpClient httpClient,
        string exportSqliteUrl,
        string exportStatusUrl,
        string token,
        TimeSpan pollInterval,
        TimeSpan maxWaitTime)
    {
        if (string.IsNullOrWhiteSpace(exportSqliteUrl))
        {
            throw new ArgumentException("sqlite 导出地址不能为空。", nameof(exportSqliteUrl));
        }

        if (string.IsNullOrWhiteSpace(exportStatusUrl))
        {
            throw new ArgumentException("sqlite 导出状态地址不能为空。", nameof(exportStatusUrl));
        }

        if (string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentException("流程接口 token 不能为空。", nameof(token));
        }

        _httpClient = httpClient;
        _exportSqliteUrl = exportSqliteUrl;
        _exportStatusUrl = exportStatusUrl;
        _token = token;
        _pollInterval = pollInterval;
        _maxWaitTime = maxWaitTime;
    }

    public async Task<string> ExportAndDownloadAsync(
        string flowId,
        string sqliteName,
        CancellationToken cancellationToken = default)
    {
        var exportId = await CreateExportAsync(flowId, cancellationToken);
        var blobUrl = await WaitForExportAsync(exportId, cancellationToken);
        return await DownloadSqliteAsync(flowId, blobUrl, sqliteName, cancellationToken);
    }

    private async Task<string> CreateExportAsync(string flowId, CancellationToken cancellationToken)
    {
        var url = BuildFlowExportUrl(flowId);
        using var document = await SendJsonRequestAsync(url, cancellationToken);
        var root = document.RootElement;

        EnsureSuccessResponse(root);

        if (!root.TryGetProperty("body", out var body)
            || body.ValueKind != JsonValueKind.String
            || string.IsNullOrWhiteSpace(body.GetString()))
        {
            throw new InvalidOperationException("sqlite 导出接口响应缺少 export_id。");
        }

        return body.GetString()!;
    }

    private async Task<string> WaitForExportAsync(string exportId, CancellationToken cancellationToken)
    {
        var startedAt = DateTimeOffset.UtcNow;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using var document = await SendJsonRequestAsync(BuildExportStatusUrl(exportId), cancellationToken);
            var root = document.RootElement;

            EnsureSuccessResponse(root);

            if (!root.TryGetProperty("body", out var body) || body.ValueKind != JsonValueKind.Object)
            {
                throw new InvalidOperationException("sqlite 导出状态接口响应缺少 body。");
            }

            var processContent = TryGetString(body, "process_content");
            var status = GetRequiredInt32(body, "status");

            if (status == 2)
            {
                var blobUrl = TryGetString(body, "blob_url");
                if (string.IsNullOrWhiteSpace(blobUrl))
                {
                    throw new InvalidOperationException("sqlite 导出成功，但响应缺少 blob_url。");
                }

                return blobUrl;
            }

            if (status == 9)
            {
                throw new InvalidOperationException(
                    string.IsNullOrWhiteSpace(processContent)
                        ? "sqlite 导出失败。"
                        : processContent);
            }

            if (DateTimeOffset.UtcNow - startedAt > _maxWaitTime)
            {
                throw new TimeoutException($"sqlite 导出超时，export_id={exportId}, 当前状态={status}。");
            }

            Console.WriteLine(
                string.IsNullOrWhiteSpace(processContent)
                    ? $"sqlite 导出中，status={status}"
                    : $"sqlite 导出中，status={status}, {processContent}");

            await Task.Delay(_pollInterval, cancellationToken);
        }
    }

    private async Task<string> DownloadSqliteAsync(
        string flowId,
        string blobUrl,
        string sqliteName,
        CancellationToken cancellationToken)
    {
        using var response = await _httpClient.GetAsync(blobUrl, cancellationToken);

        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);
        ApiResponseHelper.EnsureSuccessStatusCode(response, responseText, "下载 sqlite");

        var sqliteDirectory = GetSqliteDirectory();
        Directory.CreateDirectory(sqliteDirectory);

        var (sqlitePath, sqliteStream) = CreateSqliteFile(sqliteDirectory, sqliteName, flowId);
        await using (sqliteStream)
        {
            await response.Content.CopyToAsync(sqliteStream, cancellationToken);
        }

        return sqlitePath;
    }

    public static void ClearSqliteDirectory()
    {
        var sqliteDirectory = GetSqliteDirectory();
        Directory.CreateDirectory(sqliteDirectory);
        SqliteConnection.ClearAllPools();
        GC.Collect();
        GC.WaitForPendingFinalizers();

        foreach (var filePath in Directory.EnumerateFiles(sqliteDirectory))
        {
            DeleteFileWithRetry(filePath);
        }
    }

    private static void DeleteFileWithRetry(string filePath)
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
                Thread.Sleep(500);
            }
            catch (UnauthorizedAccessException) when (attempt < maxAttemptCount)
            {
                Thread.Sleep(500);
            }
        }

        try
        {
            File.Delete(filePath);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            throw new IOException($"删除旧 sqlite 文件失败，请先关闭占用该文件的程序: {filePath}", ex);
        }
    }

    private static string GetSqliteDirectory()
    {
        return Path.Combine(AppContext.BaseDirectory, "flowExt", "sqlite");
    }

    private static (string SqlitePath, FileStream SqliteStream) CreateSqliteFile(
        string sqliteDirectory,
        string sqliteName,
        string flowId)
    {
        var sanitizedFileName = SanitizeFileName(sqliteName);
        var baseFileName = $"{flowId}_{sanitizedFileName}";
        var sqlitePath = TryCreateSqliteFile(Path.Combine(sqliteDirectory, $"{baseFileName}.db"));

        if (sqlitePath is not null)
        {
            return sqlitePath.Value;
        }

        for (var index = 1; ; index++)
        {
            sqlitePath = TryCreateSqliteFile(Path.Combine(sqliteDirectory, $"{baseFileName}_{index}.db"));

            if (sqlitePath is not null)
            {
                return sqlitePath.Value;
            }
        }
    }

    private static (string SqlitePath, FileStream SqliteStream)? TryCreateSqliteFile(string sqlitePath)
    {
        try
        {
            return (sqlitePath, new FileStream(sqlitePath, FileMode.CreateNew, FileAccess.Write, FileShare.None));
        }
        catch (IOException) when (File.Exists(sqlitePath))
        {
            return null;
        }
    }

    private static string SanitizeFileName(string fileName)
    {
        var sanitizedFileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

        return string.IsNullOrWhiteSpace(sanitizedFileName)
            ? "sqlite"
            : sanitizedFileName.Trim();
    }

    private async Task<JsonDocument> SendJsonRequestAsync(string url, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.TryAddWithoutValidation("token", _token);

        using var response = await _httpClient.SendAsync(request, cancellationToken);

        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);
        ApiResponseHelper.EnsureSuccessStatusCode(response, responseText, "请求接口");

        return JsonDocument.Parse(responseText);
    }

    private string BuildFlowExportUrl(string flowId)
    {
        var escapedFlowId = Uri.EscapeDataString(flowId);
        if (_exportSqliteUrl.Contains(FlowIdPlaceholder, StringComparison.OrdinalIgnoreCase))
        {
            return _exportSqliteUrl.Replace(FlowIdPlaceholder, escapedFlowId, StringComparison.OrdinalIgnoreCase);
        }

        var separator = _exportSqliteUrl.Contains('?') ? '&' : '?';
        return $"{_exportSqliteUrl}{separator}flow_id={escapedFlowId}";
    }

    private string BuildExportStatusUrl(string exportId)
    {
        if (_exportStatusUrl.Contains(ExportIdPlaceholder, StringComparison.OrdinalIgnoreCase))
        {
            return _exportStatusUrl.Replace(ExportIdPlaceholder, Uri.EscapeDataString(exportId), StringComparison.OrdinalIgnoreCase);
        }

        var separator = _exportStatusUrl.Contains('?') ? '&' : '?';
        return $"{_exportStatusUrl}{separator}export_id={Uri.EscapeDataString(exportId)}";
    }

    private static void EnsureSuccessResponse(JsonElement root)
    {
        if (ApiResponseHelper.IsUnauthorizedResponse(root))
        {
            throw new InvalidOperationException($"接口未授权，请检查源环境地址和 Token。response={root}");
        }

        if (!root.TryGetProperty("err_code", out var errCodeElement)
            || !ApiResponseHelper.TryReadInt32(errCodeElement, out var errCode))
        {
            throw new InvalidOperationException($"接口响应缺少 err_code。response={root}");
        }

        if (errCode == 0)
        {
            return;
        }

        var errMessage = TryGetString(root, "err_message");
        throw new InvalidOperationException(
            string.IsNullOrWhiteSpace(errMessage)
                ? $"接口返回错误，err_code={errCode}。"
                : errMessage);
    }

    private static int GetRequiredInt32(JsonElement element, string propertyName)
    {
        if (!element.TryGetProperty(propertyName, out var valueElement)
            || !ApiResponseHelper.TryReadInt32(valueElement, out var value))
        {
            throw new InvalidOperationException($"接口响应缺少有效的 {propertyName}。");
        }

        return value;
    }

    private static string? TryGetString(JsonElement element, string propertyName)
    {
        if (!element.TryGetProperty(propertyName, out var valueElement))
        {
            return null;
        }

        return valueElement.ValueKind == JsonValueKind.String
            ? valueElement.GetString()
            : valueElement.ToString();
    }

}
