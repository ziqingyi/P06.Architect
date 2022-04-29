using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using P03.DotNetCoreMVC.Utility.gRPC;
using P05.gRPC.DemoServer.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using P03.DotNetCoreMVC.Utility.AuthExtension;
using P03.DotNetCoreMVC.Utility.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace P05.gRPC.DemoServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(
                option =>
                {
                    option.Interceptors.Add<CustomServerLoggerInterceptor>();

                }
            );

            #region Authentication and Authorization in Server side

            #region JWT HS

            JWTTokenOptions tokenOptions = new JWTTokenOptions();
            this.Configuration.Bind("JWTTokenOptions", tokenOptions);

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


            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            #region jwt

            app.UseAuthentication();

            #endregion

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<CourseService>();

                endpoints.MapGrpcService<GreeterService>();

                endpoints.MapGrpcService<CustomMathService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
