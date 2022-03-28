using System.Net.Http.Json;

namespace ApiInteractionMultipleApis.Utilities;

public class SecondApiHttpClientWrapper
{
    private readonly HttpClient _httpClient;

    public SecondApiHttpClientWrapper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BookDetail>> GetBookDetailsAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<BookDetail>>("BookDetail") ?? new();

        return result;
    }
}
