using System.Net.Http.Json;
using ClosedXML.Excel;
using Flow.DbModels;
using Microsoft.EntityFrameworkCore;

public sealed class MappingExcelSecretSynchronizer
{
    public async Task<SecretSyncResult> SyncAsync(
        string mappingPath,
        string databaseConnectionString,
        string saveSecretUrl,
        string token,
        CancellationToken cancellationToken = default)
    {
        var secrets = LoadAndValidateApiCallerSecrets(mappingPath);

        if (secrets.Count == 0)
        {
            return new SecretSyncResult(0, 0, 0);
        }

        var options = new DbContextOptionsBuilder<FlowDbContext>()
            .UseSqlServer(databaseConnectionString)
            .Options;
        await using var dbContext = new FlowDbContext(options);

        using var httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(60)
        };

        var createdCount = 0;
        var updatedCount = 0;

        foreach (var secret in secrets)
        {
            var existingSecretId = await QuerySecretIdByKeyAsync(dbContext, secret.SecretKey, cancellationToken);
            await SaveSecretAsync(httpClient, saveSecretUrl, token, existingSecretId, secret, cancellationToken);

            if (string.IsNullOrWhiteSpace(existingSecretId))
            {
                createdCount++;
            }
            else
            {
                updatedCount++;
            }
        }

        return new SecretSyncResult(secrets.Count, createdCount, updatedCount);
    }

    private static async Task<string?> QuerySecretIdByKeyAsync(
        FlowDbContext dbContext,
        string secretKey,
        CancellationToken cancellationToken)
    {
        return await dbContext.TSecretInfos
            .AsNoTracking()
            .Where(secret => secret.SecretKey == secretKey)
            .OrderBy(secret => secret.CreateTime)
            .Select(secret => secret.Id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public static IReadOnlyList<ApiCallerSecretMapping> LoadAndValidateApiCallerSecrets(string mappingPath)
    {
        using var mappingStream = new FileStream(mappingPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var workbook = new XLWorkbook(mappingStream);

        var worksheet = workbook.Worksheets.FirstOrDefault(sheet =>
            string.Equals(sheet.Name, "apiCaller", StringComparison.OrdinalIgnoreCase))
            ?? workbook.Worksheets.Skip(2).FirstOrDefault();

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
        var secretKeyIndex = FindRequiredHeaderIndex(headers, "secretKey", worksheet.Name);
        var secretValueIndex = FindRequiredHeaderIndex(headers, "secretValue", worksheet.Name);

        var secrets = new List<ApiCallerSecretMapping>();
        foreach (var row in usedRange.RowsUsed().Skip(1))
        {
            var secretKey = row.Cell(secretKeyIndex + 1).GetString().Trim();
            var secretValue = row.Cell(secretValueIndex + 1).GetString().Trim();

            if (string.IsNullOrWhiteSpace(secretKey) && string.IsNullOrWhiteSpace(secretValue))
            {
                continue;
            }

            if (string.IsNullOrWhiteSpace(secretKey) || string.IsNullOrWhiteSpace(secretValue))
            {
                throw new InvalidOperationException(
                    $"apiCaller sheet 第 {row.RowNumber()} 行存在空字段：secretKey 和 secretValue 都必须填写。");
            }

            secrets.Add(new ApiCallerSecretMapping(secretKey, secretValue));
        }

        var duplicate = secrets
            .GroupBy(secret => secret.SecretKey, StringComparer.OrdinalIgnoreCase)
            .FirstOrDefault(group => group.Count() > 1);
        if (duplicate != null)
        {
            throw new InvalidOperationException($"apiCaller sheet 存在重复 secretKey: {duplicate.First().SecretKey}");
        }

        return secrets;
    }

    private static async Task SaveSecretAsync(
        HttpClient httpClient,
        string saveSecretUrl,
        string token,
        string? id,
        ApiCallerSecretMapping secret,
        CancellationToken cancellationToken)
    {
        var responseText = await PostSaveSecretAsync(httpClient, saveSecretUrl, token, id, secret, cancellationToken);

        if (!IsErrorResponse(responseText, out var errMessage))
        {
            return;
        }

        throw new InvalidOperationException($"保存 secret 失败，secretKey={secret.SecretKey}, {errMessage}");
    }

    private static async Task<string> PostSaveSecretAsync(
        HttpClient httpClient,
        string saveSecretUrl,
        string token,
        string? id,
        ApiCallerSecretMapping secret,
        CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, saveSecretUrl);
        request.Headers.TryAddWithoutValidation("token", token);
        request.Content = JsonContent.Create(new
        {
            id = id ?? string.Empty,
            system_name = "ms",
            secret_key = secret.SecretKey,
            secret_value = secret.SecretValue
        });

        using var response = await httpClient.SendAsync(request, cancellationToken);
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

        ApiResponseHelper.EnsureSuccessStatusCode(response, responseText, $"保存 secret，secretKey={secret.SecretKey}");

        return responseText;
    }

    private static bool IsErrorResponse(string responseText, out string errMessage)
    {
        errMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(responseText))
        {
            return false;
        }

        using var document = System.Text.Json.JsonDocument.Parse(responseText);
        var root = document.RootElement;
        if (root.TryGetProperty("err_code", out var errCodeElement) &&
            ApiResponseHelper.TryReadInt32(errCodeElement, out var errCode) &&
            errCode != 0)
        {
            errMessage = root.TryGetProperty("err_message", out var errMessageElement)
                ? errMessageElement.ToString()
                : responseText;
            return true;
        }

        return false;
    }

    private static int FindRequiredHeaderIndex(IReadOnlyList<string> headers, string headerName, string sheetName)
    {
        var normalizedHeaderName = NormalizeHeader(headerName);
        var index = headers.ToList().FindIndex(header => header == normalizedHeaderName);
        if (index < 0)
        {
            throw new InvalidOperationException($"{sheetName} sheet 缺少表头: {headerName}");
        }

        return index;
    }

    private static string NormalizeHeader(string value)
    {
        return value
            .Trim()
            .Replace("_", string.Empty)
            .Replace("-", string.Empty)
            .Replace(" ", string.Empty)
            .ToLowerInvariant();
    }

}

public sealed record ApiCallerSecretMapping(string SecretKey, string SecretValue);

public sealed record SecretSyncResult(int TotalCount, int CreatedCount, int UpdatedCount);
