using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace ApiInteractionMultipleApis.Utilities;

public class InterfereByHttpClientWrapper
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;

    public InterfereByHttpClientWrapper(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    public async Task<T?> GetAsync<T>(string requestUrl)
    {
        await _jsRuntime.InvokeVoidAsync("alert", $"{nameof(InterfereByHttpClientWrapper)} interfere BEFORE sending request");
        var response = await _httpClient.GetFromJsonAsync<T>(requestUrl);
        await _jsRuntime.InvokeVoidAsync("alert", $"{nameof(InterfereByHttpClientWrapper)} interfere AFTER sending request");

        return response;
    }
}