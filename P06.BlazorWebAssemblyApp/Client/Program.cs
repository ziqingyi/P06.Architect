using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using P06.BlazorWebAssemblyApp.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


#region add startup

var startup = new Startup(builder);
startup.Configure();
startup.ConfigureServices(builder.Services);

#endregion


await builder.Build().RunAsync();
