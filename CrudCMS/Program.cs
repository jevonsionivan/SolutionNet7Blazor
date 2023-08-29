using CrudCMS;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using CrudCMS.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5086") });

builder.Services.AddScoped<IMenuMakananService,MenuMakananService>();
builder.Services.AddScoped<IPesananService,PesananService>();

await builder.Build().RunAsync();
