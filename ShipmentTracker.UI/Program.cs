using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShipmentTracker.Domain;
using ShipmentTracker.UI;
using ShipmentTracker.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5001")
});

builder.Services.AddScoped<ShipmentService>();
builder.Services.AddSingleton<FlashMessageService>();
builder.Services.AddSingleton<AuthService>();

await builder.Build().RunAsync();
