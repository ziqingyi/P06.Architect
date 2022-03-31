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
using Microsoft.OpenApi.Models;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4
{
    //dotnet P03.DotNetCoreMVC.AuthenticationCenter.Ids4.dll  --urls="http://*:44398" --ip="127.0.0.1"
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

            //http://localhost:44398/.well-known/openid-configuration



            #region  client credentials
            // get token from http://localhost:44398/connect/token
            //client_id: ids4client
            //client_secret:test123
            //grant_type:client_credentials

            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()//generate temp pub/pri key. In production, pub/pri key should not be temp. 
            //    .AddInMemoryClients(ClientInitConfig.GetClients())//Adds the Clients's info in RAM memory.
            //    .AddInMemoryApiResources(ClientInitConfig.GetApiResources());// the resource which can access, can add multi api info inside the class

            #endregion




            #region password, client get username and password, get token and public key. 

            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()//developer credential
            //    .AddInMemoryApiResources(PasswordInitConfig.GetApiResources())//get resources
            //    .AddInMemoryClients(PasswordInitConfig.GetClients())//get clients
            //    .AddTestUsers(PasswordInitConfig.GetUsers());//get users

            #endregion



            #region Implicit

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(ImplicitInitConfig.GetApiResources())
                .AddInMemoryClients(ImplicitInitConfig.GetClients())
                .AddTestUsers(ImplicitInitConfig.GetUsers());

            #endregion




            #region Code

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(CodeInitConfig.GetApiResources())
                .AddInMemoryClients(CodeInitConfig.GetClients())
                .AddTestUsers(CodeInitConfig.GetUsers());

            #endregion



            #region add swagger
            // Note: Add this service at the end after AddMvc() or AddMvcCore().
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "test",
                        Email = string.Empty
                    },
                });
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                #region add swagger, http://localhost:44398/index.html
                app.UseSwagger();
                app.UseSwaggerUI();
                #endregion
            }

            app.UseHttpsRedirection();




            #region add swagger

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });

            #endregion

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
