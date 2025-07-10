using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using gfcf14_art;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration["API_URL"];

builder.Services.AddScoped(sp => new HttpClient
{
  BaseAddress = new Uri(apiUrl!)
});

await builder.Build().RunAsync();
