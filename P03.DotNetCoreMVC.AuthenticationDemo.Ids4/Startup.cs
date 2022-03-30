using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.AuthenticationDemo.Ids4
{
    //dotnet P03.DotNetCoreMVC.AuthenticationDemo.Ids4.dll  --urls="https://*:44350" --ip="127.0.0.1"
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


            #region Ids4--client credentials
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:44398";//ids4 address,ids4 authenticaion center. get public key. 
                    options.ApiName = "UserApi";
                    options.RequireHttpsMetadata = false;
                });

            services.AddAuthorization(options => 
            {
                options.AddPolicy(
                    "MailPolicy",
                policyBuilder =>
                policyBuilder.RequireAssertion(
                    context =>
                    context.User.HasClaim(c => c.Type == ClaimTypes.Email)
                    && context.User.Claims.First(c => c.Type.Equals(ClaimTypes.Email)).Value.EndsWith("@gmail.com")
                    )
                    );                
            });


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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            #region Ids4 

            app.UseAuthentication();

            #endregion


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
