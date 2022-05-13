


using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace P06.BlazorWebAssemblyApp.Client
{
    public class Startup
    {
        private readonly WebAssemblyHostBuilder _builder;
        public Startup(WebAssemblyHostBuilder builder)
        {
            _builder = builder;
            
        }

        //public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(_builder.HostEnvironment.BaseAddress) });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure()
        {

            _builder.RootComponents.Add<App>("#app");
            _builder.RootComponents.Add<HeadOutlet>("head::after");

        }

    }



}
