namespace ApiInteractionMultipleApis.Utilities;

public class CustomHttpClient : HttpClient
{
    public CustomHttpClient()
    {
        BaseAddress = new("http://localhost:5165");
    }
}
