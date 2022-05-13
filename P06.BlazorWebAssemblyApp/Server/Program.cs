using Microsoft.AspNetCore.ResponseCompression;
using P06.BlazorWebAssemblyApp.Server;

var builder = WebApplication.CreateBuilder(args);


#region add startup

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

#endregion



var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();


app.Run();
