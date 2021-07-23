using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC
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
            #region add session
            services.AddSession();
            #endregion


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            #region add session
            app.UseSession();
            #endregion

            #region add log factory
            loggerFactory.AddLog4Net("CfgFiles\\log4net.config");
            #endregion


            app.UseHttpsRedirection();


            #region UseStaticFiles update with static file options

            #region config 1
            //wwwroot folder is must
            //StaticFileOptions sfo = new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(),
            //            @"wwwroot"))
            //};
            //app.UseStaticFiles(sfo);
            #endregion

            #region config 2, self-host
            //dotnet P03.DotNetCoreMVC.dll            access by: http://localhost:5000/, port from launch setting
            //dotnet P03.DotNetCoreMVC.dll --urls="http:/*:5177" --127.0.0.1 --port=5177 access by: http://localhost:5177/
            
            //by default, the static file is in wwwroot, but if no such file, program still run and accept request
            //if in config 1, the missing of wwwroot will lead to failure of the program. 
            app.UseStaticFiles();
            #endregion

            #endregion
            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
