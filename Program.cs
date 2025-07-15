using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Text.Json;
using gfcf14_art.Services;
using gfcf14_art;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


using var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
var configJson = await http.GetStringAsync("appsettings.json");
using var doc = JsonDocument.Parse(configJson);
var apiUrl = doc.RootElement.GetProperty("API_URL").GetString();

builder.Services.AddScoped(sp => new HttpClient
{
  BaseAddress = new Uri(apiUrl!)
});

builder.Services.AddScoped<ArtworkService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddSingleton<LoaderService>();

await builder.Build().RunAsync();
