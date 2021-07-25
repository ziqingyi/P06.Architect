using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Hangfire.MemoryStorage;


namespace P06.CustomHangFire
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseDefaultTypeSerializer()
                    .UseSqlServerStorage("Data Source=.;Initial Catalog=advanced7;User ID=adrian;Password=adrian")
            );
            services.AddHangfireServer();


            services.AddSingleton<IPrintJob,PrintJob>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env,
            IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHangfireDashboard();


            backgroundJobClient.Enqueue(
                () => Console.WriteLine("Hello Hangfire Job 1"));

            recurringJobManager.AddOrUpdate(
                "Run Every Minute",
                ()=> Console.WriteLine("Test recurring job"), "* * * * *");


            recurringJobManager.AddOrUpdate("Run Print Job",
                ()=> serviceProvider.GetService<IPrintJob>().Print(),
                "* * * * *");


        }
    }
}
