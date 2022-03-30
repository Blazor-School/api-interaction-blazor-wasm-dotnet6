using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace ApiInteractionMultipleApis.Utilities;

public static class HttpClientExtension
{
    public static async Task<T?> GetResponse<T>(this HttpClient httpClient, string url, IJSRuntime jsRuntime)
    {
        await jsRuntime.InvokeVoidAsync("alert", $"{nameof(HttpClientExtension)} interfere BEFORE sending request");
        var result = await httpClient.GetFromJsonAsync<T>(url);
        await jsRuntime.InvokeVoidAsync("alert", $"{nameof(HttpClientExtension)} interfere AFTER sending request");

        return result;
    }
}