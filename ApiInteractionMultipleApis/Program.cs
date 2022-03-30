using ApiInteractionMultipleApis;
using ApiInteractionMultipleApis.Utilities;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomHttpClient>();

builder.Services.AddHttpClient("First API", httpClient => httpClient.BaseAddress = new("http://localhost:5165"));
builder.Services.AddHttpClient("Second API", httpClient => httpClient.BaseAddress = new("http://localhost:5276"));

builder.Services.AddHttpClient<SecondApiHttpClientWrapper>(httpClient => httpClient.BaseAddress = new("http://localhost:5276"));

builder.Services.AddTransient<FirstMiddleware>();
builder.Services.AddTransient<SecondMiddleware>();
builder.Services.AddHttpClient("HttpClient with Middlewares", httpClient => httpClient.BaseAddress = new("http://localhost:5276"))
       .AddHttpMessageHandler<FirstMiddleware>()
       .AddHttpMessageHandler<SecondMiddleware>();

builder.Services.AddHttpClient<InterfereByHttpClientWrapper>(httpClient => httpClient.BaseAddress = new("http://localhost:5276"));

builder.Services.AddHttpClient("InterfereWithHttpClientExtension", httpClient => httpClient.BaseAddress = new("http://localhost:5165"));

await builder.Build().RunAsync();