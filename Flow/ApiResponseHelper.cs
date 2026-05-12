using System.Text.Json;

public static class ApiResponseHelper
{
    public static void EnsureSuccessStatusCode(HttpResponseMessage response, string responseText, string action)
    {
        if (response.IsSuccessStatusCode)
        {
            return;
        }

        if ((int)response.StatusCode == 401 || IsUnauthorizedResponse(responseText))
        {
            throw new InvalidOperationException($"{action}失败：接口未授权，请检查目标环境地址和 Token。response={responseText}");
        }

        throw new InvalidOperationException(
            $"{action}失败，status={(int)response.StatusCode}, response={responseText}");
    }

    public static void EnsureGeneralResponseSuccess(JsonElement root, string responseText, string action)
    {
        if (IsUnauthorizedResponse(root))
        {
            throw new InvalidOperationException($"{action}失败：接口未授权，请检查目标环境地址和 Token。response={responseText}");
        }

        if (!root.TryGetProperty("err_code", out var errCodeElement) ||
            !TryReadInt32(errCodeElement, out var errCode))
        {
            throw new InvalidOperationException($"{action}失败：接口响应缺少 err_code。response={responseText}");
        }

        if (errCode == 0)
        {
            return;
        }

        var errMessage = root.TryGetProperty("err_message", out var errMessageElement)
            ? errMessageElement.ToString()
            : $"接口返回错误，err_code={errCode}。";
        throw new InvalidOperationException($"{action}失败：{errMessage}");
    }

    public static bool IsUnauthorizedResponse(string responseText)
    {
        if (string.IsNullOrWhiteSpace(responseText))
        {
            return false;
        }

        try
        {
            using var document = JsonDocument.Parse(responseText);
            return IsUnauthorizedResponse(document.RootElement);
        }
        catch (JsonException)
        {
            return false;
        }
    }

    public static bool IsUnauthorizedResponse(JsonElement root)
    {
        return root.TryGetProperty("unauthorized", out var unauthorized) &&
            TryReadInt32(unauthorized, out var unauthorizedCode) &&
            unauthorizedCode == 401;
    }

    public static bool TryReadInt32(JsonElement element, out int value)
    {
        value = default;

        return element.ValueKind switch
        {
            JsonValueKind.Number => element.TryGetInt32(out value),
            JsonValueKind.String => int.TryParse(element.GetString(), out value),
            _ => false
        };
    }
}
