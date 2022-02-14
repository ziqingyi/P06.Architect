using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using P03.DotNetCoreMVC.AuthenticationDemo.AuthUtility;
using P03.DotNetCoreMVC.Utility.AuthExtension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.AuthenticationDemo
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
            services.AddControllersWithViews();

            //The default value used for CookieAuthenticationOptions.AuthenticationScheme
            //public const string AuthenticationScheme = "Cookies";

            #region 1 add Authentication for custom handler

            ////just add the service, no need to UseAuthentication() if filtered by cus attribute

            //services.AddAuthentication().AddCookie();

            //services.AddAuthenticationCore(options => options.AddScheme<CustomAuthenticationHandler>("CustomScheme","DemoScheme"));
            #endregion


            #region 2 system authentication

            #region memory cache
            //services.AddScoped<ITicketStore, MemoryCacheTicketStore>();
            //services.AddMemoryCache();
            #endregion
            ////write key into Cookie in server, similar to Session.
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            //    options.DefaultChallengeScheme = "Cookie/Login";
            //}).AddCookie(
            //    options=>
            //    {
            //        options.SessionStore = services.BuildServiceProvider().GetService<ITicketStore>();

            //        options.Events = new CookieAuthenticationEvents()
            //        {
            //            OnSignedIn = new Func<CookieSignedInContext, Task>(
            //                async context =>
            //                {
            //                    Console.WriteLine($"{context.Request.Path} is OnSinged In");
            //                    await Task.CompletedTask;
            //                }
            //                ),
            //            OnSigningOut = new Func<CookieSigningOutContext, Task>(
            //                async context =>
            //                {
            //                    Console.WriteLine($"{context.Request.Path} is OnSinging Out");
            //                    await Task.CompletedTask;
            //                }
            //                )
            //        };
            //    }              
            //    );

            #endregion


            #region  3 Cookie authentication using role

            //services.AddAuthentication(
            //    options =>
            //    {
            //        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    })
            //    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            //    options =>
            //    {
            //        options.LoginPath = "/dAuthorization/Index";
            //        options.AccessDeniedPath = "/dAuthorization/Index";
            //    });



            #endregion


            #region  4 Policy Authorization
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(
                CookieAuthenticationDefaults.AuthenticationScheme,
                options=>
                {
                    options.LoginPath = "/dAuthorization/Index";
                    options.AccessDeniedPath = "/dAuthorization/Index";
                });

            services.AddAuthorization(
                options => 
                {
                    options.AddPolicy("AdminPolicy",
                        policy => policy
                        .RequireRole("Admin")
                        .RequireUserName("AdminUser1")
                        .RequireClaim(ClaimTypes.Email)
                        );

                    options.AddPolicy("UserPolicy",
                        policy =>
                        policy.RequireAssertion(
                            context =>
                                context.User.HasClaim(c =>c.Type == ClaimTypes.Role)
                                &&
                                context.User.Claims.First(c => c.Type.Equals(ClaimTypes.Role)).Value.ToLower() == "userrole"
                            )
                        );

                    #region add custom requirement

                    options.AddPolicy("DoubleEmail", policyBuilder => policyBuilder.Requirements.Add(new DoubleEMailRequirement()));

                    #endregion
                });

            #region add custom requirement

            services.AddSingleton<IAuthorizationHandler,GMailHandler>();
            services.AddSingleton<IAuthorizationHandler,OutlookMailHandler>();

            #endregion



            #endregion







        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


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


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            #region System authorization

            app.UseAuthentication();

            app.UseAuthorization(); //if use your own attribute, don't use core middleware

            #endregion


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }




}
