using Microsoft.JSInterop;

namespace ApiInteractionMultipleApis.Utilities;

public class SecondMiddleware : DelegatingHandler
{
    private readonly IJSRuntime _jSRuntime;

    public SecondMiddleware(IJSRuntime jSRuntime)
    {
        _jSRuntime = jSRuntime;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        await _jSRuntime.InvokeVoidAsync("alert", $"{nameof(SecondMiddleware)} interfere BEFORE sending request");
        var response = await base.SendAsync(request, cancellationToken);
        await _jSRuntime.InvokeVoidAsync("alert", $"{nameof(SecondMiddleware)} interfere AFTER sending request");

        return response;
    }
}