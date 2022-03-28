using ApiInteractionMultipleApis;
using ApiInteractionMultipleApis.Utilities;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<CustomHttpClient>();
builder.Services.AddHttpClient("First API", httpClient => httpClient.BaseAddress = new("http://localhost:5165"));
builder.Services.AddHttpClient<SecondApiHttpClientWrapper>(httpClient => httpClient.BaseAddress = new("http://localhost:5276"));

await builder.Build().RunAsync();