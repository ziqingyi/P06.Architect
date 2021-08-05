using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Interface.TestServiceInterface;
using P03.DotNetCoreMVC.Services;
using P03.DotNetCoreMVC.Utility.AutofacUtility;
using P03.DotNetCoreMVC.Utility.CusMiddleWare;
using P03.DotNetCoreMVC.Utility.Filters;

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

            #region for attribute

            services.AddScoped(typeof(CustomExceptionFilterAttribute));//attribute generated by container

            services.AddScoped(typeof(CustomExceptionFilterIOCAttribute));//attribute generated by container
            #endregion

            #region Add service IOC

            //default container: inject by ctor only.  find superset of all ctors. 

            services.AddTransient<ITestServiceA, TestServiceA>();
            services.AddSingleton<ITestServiceB, TestServiceB>();
            services.AddScoped<ITestServiceC, TestServiceC>();//singleton in scope
            services.AddTransient<ITestServiceD, TestServiceD>();
            //services.AddTransient<ITestServiceE, TestServiceE>();//move to configure container

            #endregion



            services.AddControllersWithViews();

            #region add attribute to all controller and actions 

            ////can remove AddScoped(), DI automatically. 
            //services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add<CustomExceptionFilterAttribute>(); 

            //});


            #endregion



        }

        #region update contianer to Autofac and configure
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {

            containerBuilder.RegisterModule<CustomAutofacModule>();

            //Register type for Interface.
            containerBuilder.RegisterType<TestServiceE>().As<ITestServiceE>().SingleInstance();

        }
        #endregion



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



            #region 3 Use with Func  

            //app.Use(async (context, next) => { await context.Response.WriteAsync("hello"); });

            /* source code
             
             *         /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
                        /// <param name="middleware">A function that handles the request and calls the given next function.</param>
                        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
                        public static IApplicationBuilder Use(this IApplicationBuilder app, Func<HttpContext, Func<Task>, Task> middleware)
                        {
                            return app.Use(next =>
                            {
                                return context =>
                                {
                                    Func<Task> simpleNext = () => next(context);
                                    return middleware(context, simpleNext);
                                };
                            });
                        }

             */

            #endregion

            #region other implementation of Use()




            #region 4 UseWhen     /index?name=123

            //app.UseWhen(context =>
            //    {
            //        return context.Request.Query.ContainsKey("Name");
            //    },
            //    appBuilder =>
            //    {
            //        appBuilder.Use(async (context, next) =>
            //        {
            //            await context.Response.WriteAsync("hello world UseWhen");
            //            await next();
            //        });
            //    });
            /*
            /// Conditionally creates a branch in the request pipeline that is rejoined to the main pipeline.
            /// </summary>
            /// <param name="app"></param>
            /// <param name="predicate">Invoked with the request environment to determine if the branch should be taken</param>
            /// <param name="configuration">Configures a branch to take</param>
            /// <returns></returns>
            public static IApplicationBuilder UseWhen(this IApplicationBuilder app, Predicate predicate, Action<IApplicationBuilder> configuration)
            {
                if (app == null)
                {
                    throw new ArgumentNullException(nameof(app));
                }

                if (predicate == null)
                {
                    throw new ArgumentNullException(nameof(predicate));
                }

                if (configuration == null)
                {
                    throw new ArgumentNullException(nameof(configuration));
                }

                // Create and configure the branch builder right away; otherwise,
                // we would end up running our branch after all the components
                // that were subsequently added to the main builder.
                var branchBuilder = app.New();
                configuration(branchBuilder);

                return app.Use(main =>
                {
                    // This is called only when the main application builder
                    // is built, not per request.
                    branchBuilder.Run(main);
                    var branch = branchBuilder.Build();

                    return context =>
                    {
                        if (predicate(context))
                        {
                            return branch(context);
                        }
                        else
                        {
                            return main(context);
                        }
                    };
                });
            }

            */
            #endregion

            #region 5 Map 

            //app.Map("/Test", MapTest);

            //app.Map("/mapTest",
            //    a => a.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("This is map to maptext page");
            //    }));

            //app.MapWhen(context =>
            //{
            //    return context.Request.Query.ContainsKey("Name");

            //}, MapTest);



            #endregion

            #region 6 Middleware class, UseMiddlewareExtensions.cs, use reflections

            //app.UseMiddleware<FirstMiddleWare>();
            //app.UseMiddleware<SecondMiddleWare>();
            //app.UseMiddleware<ThirdMiddleWare>();

            #endregion


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
            //dotnet P03.DotNetCoreMVC.dll --urls="http://*:5177" --ip="127.0.0.1" --port=5177 access by: http://localhost:5177/

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


        #region test assist method

        private static void MapTest(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"Url is {context.Request.Path.Value}");
            });
        }
       

        #endregion






    }
}
