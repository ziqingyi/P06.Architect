using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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





            #region 1 test Use() ,  use middleware and  test application builder process 
            //ApplicationBuilder.cs
            //Func<RequestDelegate, RequestDelegate> func1 = new Func<RequestDelegate, RequestDelegate>(
            //next =>
            //{
            //    Console.WriteLine("This is middleware 1 ");
            //    return new RequestDelegate(
            //        async context =>
            //        {
            //            await context.Response.WriteAsync("This is hello world in HttpContext Response 1 begin ");

            //            await next.Invoke(context);

            //            await context.Response.WriteAsync("This is hello world in HttpContext Response 1 end ");
            //        });
            //}
            //);

            //app.Use(func1);

            //Func<RequestDelegate, RequestDelegate> func2 = new Func<RequestDelegate, RequestDelegate>(
            //    next =>
            //    {
            //        Console.WriteLine("This is middleware 2 ");
            //        return new RequestDelegate(
            //            async context =>
            //            {
            //                await context.Response.WriteAsync("This is hello world in HttpContext 2 Response begin ");

            //                await next.Invoke(context);

            //                await context.Response.WriteAsync("This is hello world in HttpContext 2 Response end ");
            //            });
            //    }
            //);

            //app.Use(func2);

            //Func<RequestDelegate, RequestDelegate> func3 = new Func<RequestDelegate, RequestDelegate>(
            //    next =>
            //    {
            //        Console.WriteLine("This is middleware 3 ");
            //        return new RequestDelegate(
            //            async context =>
            //            {
            //                await context.Response.WriteAsync("This is hello world in HttpContext 3 Response begin ");

            //                //await next.Invoke(context); //no next , the final.

            //                await context.Response.WriteAsync("This is hello world in HttpContext 3 Response end ");
            //            });
            //    }
            //);

            //app.Use(func3);

            #endregion


            #region 2 test  run   middleware , Adds a terminal middleware delegate

            ////  test Run()
            //app.Run(c=> c.Response.WriteAsync("hello"));

            /*  source code RunExtensions.cs :  just run the delegate and return , without following steps

            //Adds a terminal middleware delegate to the application's request pipeline.

            public static void Run(this IApplicationBuilder app, RequestDelegate handler)
            {
                if (app == null)
                {
                    throw new ArgumentNullException(nameof(app));
                }

                if (handler == null)
                {
                    throw new ArgumentNullException(nameof(handler));
                }

                app.Use(_ => handler);
            }
            */

            #endregion



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
            loggerFactory.AddLog4Net("CfgFiles\\log4net.config");//replace or override .net core internal Logger, so no need to add service. 
            #endregion


            app.UseHttpsRedirection();


            #region UseStaticFiles update with static file options

            //difference between debug and publish: publish has web.config file and may has wwwroot folder.
            //web.config file is required for IIS.

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

            #region config 2, self-host
            //dotnet P03.DotNetCoreMVC.dll            access by: http://localhost:5000/, port from launch setting
            //dotnet P03.DotNetCoreMVC.dll --urls="http:/*:5177" --127.0.0.1 --port=5177 access by: http://localhost:5177/

            //by default, the static file is in wwwroot, but if no such file, program still run and accept request
            //if in config 1, the missing of wwwroot will lead to failure of the program. 
            //app.UseStaticFiles();

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
