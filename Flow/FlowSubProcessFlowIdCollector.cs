using System.Text.Json;

/// <summary>
/// 根据流程接口返回的节点信息递归收集子流程 ID。
/// </summary>
public sealed class FlowSubProcessFlowIdCollector
{
    private const string FlowIdPlaceholder = "{flowId}";

    private readonly HttpClient _httpClient;
    private readonly string _getFlowUrl;
    private readonly string _token;

    public FlowSubProcessFlowIdCollector(HttpClient httpClient, string getFlowUrl, string token)
    {
        if (string.IsNullOrWhiteSpace(getFlowUrl))
        {
            throw new ArgumentException("流程查询地址不能为空。", nameof(getFlowUrl));
        }

        if (string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentException("流程接口 token 不能为空。", nameof(token));
        }

        _httpClient = httpClient;
        _getFlowUrl = getFlowUrl;
        _token = token;
    }

    public async Task<IReadOnlyList<string>> CollectAsync(string rootFlowId, CancellationToken cancellationToken = default)
    {
        var visitedFlowIds = new HashSet<string>(StringComparer.Ordinal);
        var orderedFlowIds = new List<string>();

        await CollectCoreAsync(rootFlowId, visitedFlowIds, orderedFlowIds, cancellationToken);

        return orderedFlowIds;
    }

    private async Task CollectCoreAsync(
        string flowId,
        HashSet<string> visitedFlowIds,
        List<string> orderedFlowIds,
        CancellationToken cancellationToken)
    {
        flowId = NormalizeFlowId(flowId);
        if (!visitedFlowIds.Add(flowId))
        {
            return;
        }

        orderedFlowIds.Add(flowId);

        using var document = await GetFlowDocumentAsync(flowId, cancellationToken);
        var flow = GetFlowPayload(document.RootElement);

        foreach (var subProcessFlowId in ExtractSubProcessFlowIds(flow))
        {
            await CollectCoreAsync(subProcessFlowId, visitedFlowIds, orderedFlowIds, cancellationToken);
        }
    }

    private async Task<JsonDocument> GetFlowDocumentAsync(string flowId, CancellationToken cancellationToken)
    {
        var url = BuildGetFlowUrl(flowId);
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.TryAddWithoutValidation("token", _token);

        using var response = await _httpClient.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var responseText = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new InvalidOperationException(
                $"查询流程失败，flow_id={flowId}, status={(int)response.StatusCode}, response={responseText}");
        }

        await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var document = await JsonDocument.ParseAsync(responseStream, cancellationToken: cancellationToken);

        ValidateFlowDocument(flowId, GetFlowPayload(document.RootElement));

        return document;
    }

    private string BuildGetFlowUrl(string flowId)
    {
        var escapedFlowId = Uri.EscapeDataString(flowId);
        if (_getFlowUrl.Contains(FlowIdPlaceholder, StringComparison.OrdinalIgnoreCase))
        {
            return _getFlowUrl.Replace(FlowIdPlaceholder, escapedFlowId, StringComparison.OrdinalIgnoreCase);
        }

        var separator = _getFlowUrl.Contains('?') ? '&' : '?';
        return $"{_getFlowUrl}{separator}flowId={escapedFlowId}";
    }

    private static JsonElement GetFlowPayload(JsonElement response)
    {
        if (response.TryGetProperty("body", out var body) && body.ValueKind == JsonValueKind.Object)
        {
            return body;
        }

        return response;
    }

    private static void ValidateFlowDocument(string expectedFlowId, JsonElement flow)
    {
        if (flow.TryGetProperty("unauthorized", out var unauthorized))
        {
            throw new InvalidOperationException(
                $"查询流程未授权，flow_id={expectedFlowId}, unauthorized={unauthorized}");
        }

        if (!flow.TryGetProperty("flowId", out var flowIdElement)
            || string.IsNullOrWhiteSpace(ReadFlowIdString(flowIdElement)))
        {
            throw new InvalidOperationException($"流程接口响应缺少 flowId，flow_id={expectedFlowId}");
        }

        var actualFlowId = NormalizeFlowId(ReadFlowIdString(flowIdElement)!);
        if (!string.Equals(actualFlowId, NormalizeFlowId(expectedFlowId), StringComparison.Ordinal))
        {
            throw new InvalidOperationException(
                $"流程接口响应 flowId 不匹配，请求={expectedFlowId}, 响应={actualFlowId}");
        }
    }

    private static IEnumerable<string> ExtractSubProcessFlowIds(JsonElement flow)
    {
        if (!flow.TryGetProperty("nodes", out var nodes) || nodes.ValueKind != JsonValueKind.Array)
        {
            yield break;
        }

        foreach (var node in nodes.EnumerateArray())
        {
            if (!IsSubProcessNode(node))
            {
                continue;
            }

            if (TryGetSubProcessFlowId(node, out var subProcessFlowId))
            {
                yield return subProcessFlowId;
            }
        }
    }

    private static bool IsSubProcessNode(JsonElement node)
    {
        return node.TryGetProperty("nodeType", out var nodeType)
            && nodeType.ValueKind == JsonValueKind.String
            && string.Equals(nodeType.GetString(), "subProcess", StringComparison.OrdinalIgnoreCase);
    }

    private static bool TryGetSubProcessFlowId(JsonElement node, out string flowId)
    {
        flowId = string.Empty;

        if (!node.TryGetProperty("designParams", out var designParams)
            || !designParams.TryGetProperty("subProcessData", out var subProcessData)
            || !subProcessData.TryGetProperty("flow_id", out var flowIdElement))
        {
            return false;
        }

        var value = ReadFlowIdString(flowIdElement);
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        flowId = NormalizeFlowId(value);
        return true;
    }

    private static string? ReadFlowIdString(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.Number => element.GetRawText(),
            JsonValueKind.String => element.GetString(),
            _ => null
        };
    }

    private static string NormalizeFlowId(string flowId)
    {
        return flowId.Trim();
    }
}
