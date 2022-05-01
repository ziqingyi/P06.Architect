using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Core;
using P03.DotNetCoreMVC.Utility.ApiHelper;
using P05.gRPC.DemoServer;
using P03.DotNetCoreMVC.Utility.gRPC;
using P03.DotNetCoreMVC.Utility.Models;
using P05.gRPC.DemoClientWeb.ProjectUtility;
using P05.gRPC.DemoUserServer;

namespace P05.gRPC.DemoClientWeb
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

            #region gRPC clients

            services.AddGrpcClient<CustomMath.CustomMathClient>(
                options =>
                {
                    options.Address = new Uri("https://localhost:5001");
                    //add interceptor
                    options.Interceptors.Add(new CustomClientLoggerInterceptor());
                }
                );


            services.AddGrpcClient<Course.CourseClient>(
                options =>
                {
                    options.Address = new Uri("https://localhost:5001");
                    //add interceptor
                    options.Interceptors.Add(new CustomClientLoggerInterceptor());
                }
                )
                //add token header at start
                //.ConfigureChannel(grpcOption =>  
                //{
                //    var callCredentials = CallCredentials.FromInterceptor(async (context, metadata) =>
                //    {
                        
                //        JWTTokenResult result = GetTokenHelper.GetToken();

                //        Debug.Print("-----------------------Token from startUp: " + result.token);

                //        string token = result?.token;
                //        if (!string.IsNullOrEmpty(token))
                //        {
                //            metadata.Add("Authorization", $"Bearer {token}");
                //        }

                //    });

                //    grpcOption.Credentials = ChannelCredentials.Create(new SslCredentials(), callCredentials);
                //})
                ;
            services.AddGrpcClient<User.UserClient>(
                options =>
                {
                    options.Address = new Uri("https://localhost:5002");
                    //add interceptor
                    options.Interceptors.Add(new CustomClientLoggerInterceptor());
                }
                )
                ////nginx
                //.ConfigureChannel(grpcOptions =>
                //    {
                //        grpcOptions.HttpClient = new HttpClient(
                //            new HttpClientHandler
                //            {
                //                ServerCertificateCustomValidationCallback = (msg,cert,chain,error)=>true
                //            }
                //        );
                //    }
                //)
                ;
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



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=GRpc}/{action=Index}/{id?}");

            });
        }
    }
}
/*
 ssl issue: 
https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-6.0&tabs=visual-studio#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos

dotnet dev-certs https --clean
dotnet dev-certs https --trust

*/