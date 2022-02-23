using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4
{
    //dotnet P03.DotNetCoreMVC.AuthenticationCenter.Ids4.dll  --urls="https://*:44398" --ip="127.0.0.1"
    /* quickstart UI
     https://github.com/IdentityServer/IdentityServer4.Quickstart.UI
          //dotnet new -i identityserver4.templates
          //dotnet new is4ui

     */
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
            //services.AddControllers();
            #region replace with views
            services.AddControllersWithViews();
            #endregion

            #region  client credentials
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()//generate temp pub/pri key. In production, pub/pri key should not be temp. 
                .AddInMemoryClients(ClientInitConfig.GetClients())//Adds the in memory clients.
                .AddInMemoryApiResources(ClientInitConfig.GetApiResources());
            #endregion






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();



            #region config 1
            //wwwroot folder is must for running in console
            StaticFileOptions sfo = new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),
                        @"wwwroot"))
            };
            app.UseStaticFiles(sfo);
            #endregion

            #region IdentityServer Middleware

            app.UseIdentityServer();

            #endregion







            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
