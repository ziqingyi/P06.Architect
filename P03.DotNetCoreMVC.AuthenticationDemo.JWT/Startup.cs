using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using P03.DotNetCoreMVC.Utility.AuthExtension;
using P03.DotNetCoreMVC.Utility.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.AuthenticationDemo.JWT
{
    //dotnet P03.DotNetCoreMVC.AuthenticationDemo.JWT.dll  --urls="https://*:44371" --ip="127.0.0.1"
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
            #region update to controller

            //services.AddRazorPages();
            services.AddControllersWithViews();

            #endregion


            #region JWT HS

            JWTTokenOptions tokenOptions = new JWTTokenOptions();
            Configuration.Bind("JWTTokenOptions", tokenOptions);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = tokenOptions.Audience,
                        ValidIssuer = tokenOptions.Issuer,
                        //get security key
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))


                    };
                });


            services.AddAuthorization(
                options =>
                {

                    #region  add policy 1
                    options.AddPolicy("AdminPolicy",
                        policyBuilder => policyBuilder
                        .RequireRole("Admin")//need to have a role of Admin
                        .RequireUserName("Admin")//name is Admin
                        .RequireClaim(ClaimTypes.Email)//must have Email claim , not "Email"

                        #region add requirement
                        .AddRequirements(new CustomExtendRequirement())
                        #endregion
                        );
                    #endregion


                    #region add policy 2
                    options.AddPolicy("MailPolicy",
                        policyBuilder => policyBuilder

                        #region add requirement
                        .AddRequirements(new CustomExtendRequirement())
                        #endregion

                        .Requirements.Add(new DoubleEMailRequirement())
                        );
                    #endregion


                });


            services.AddSingleton<IAuthorizationHandler, GMailHandler>();
            services.AddSingleton<IAuthorizationHandler, OutlookMailHandler>();

            #region add requirement
            services.AddSingleton<IAuthorizationHandler, CustomExtendRequirementHandler>();
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

            #region jwt 
            
            app.UseAuthentication();
            #endregion
            
            app.UseAuthorization();

            #region update to controller
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=aJWT}/{action=Online}"
                    );

            });
            #endregion

        }
    }
}
