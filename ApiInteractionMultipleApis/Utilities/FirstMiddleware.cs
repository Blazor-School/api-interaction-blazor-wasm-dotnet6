using Microsoft.JSInterop;

namespace ApiInteractionMultipleApis.Utilities;

public class FirstMiddleware : DelegatingHandler
{
    private readonly IJSRuntime _jSRuntime;

    public FirstMiddleware(IJSRuntime jSRuntime)
    {
        _jSRuntime = jSRuntime;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        await _jSRuntime.InvokeVoidAsync("alert", $"{nameof(FirstMiddleware)} interfere BEFORE sending request");
        var response = await base.SendAsync(request, cancellationToken);
        await _jSRuntime.InvokeVoidAsync("alert", $"{nameof(FirstMiddleware)} interfere AFTER sending request");

        return response;
    }
}
