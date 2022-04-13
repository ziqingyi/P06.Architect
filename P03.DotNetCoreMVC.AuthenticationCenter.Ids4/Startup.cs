using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit.DB;
using P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit;

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

            //https://localhost:44398/.well-known/openid-configuration



            #region  client credentials
            // get token from https://localhost:44398/connect/token
            //client_id: idsclient
            //client_secret:test123
            //grant_type:client_credentials

            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()//generate temp pub/pri key. In production, pub/pri key should not be temp. 
            //    .AddInMemoryClients(ClientInitConfig.GetClients())//Adds the Clients's info in RAM memory.
            //    .AddInMemoryApiResources(ClientInitConfig.GetApiResources())// the resource which can access, can add multi api info inside the class
            //    .AddInMemoryApiScopes(ClientInitConfig.ApiScopes());
            #endregion




            #region password, client get username and password, get token and public key. 

            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()//developer credential
            //    .AddInMemoryClients(PasswordInitConfig.GetClients())//get clients
            //    .AddInMemoryApiResources(PasswordInitConfig.GetApiResources())//get resources
            //    .AddTestUsers(PasswordInitConfig.GetUsers())//get users                                                                              //
            //    .AddInMemoryApiScopes(PasswordInitConfig.ApiScopes());

            #endregion


            #region Implicit flow

            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryClients(ImplicitInitConfig.GetClients())
            //    .AddInMemoryApiResources(ImplicitInitConfig.GetApiResources())              
            //    .AddTestUsers(ImplicitInitConfig.GetUsers())
            //    .AddInMemoryApiScopes(ImplicitInitConfig.ApiScopes()); 

            #endregion



            #region Authorization code flow

            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryApiResources(CodeInitConfig.GetApiResources())
            //    .AddInMemoryClients(CodeInitConfig.GetClients())
            //    .AddTestUsers(CodeInitConfig.GetUsers())
            //    .AddInMemoryApiScopes(CodeInitConfig.ApiScopes());
            #endregion



            #region Hybrid flow

            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryIdentityResources(HybridInitConfig.GetIdentityResources())
            //    .AddInMemoryApiResources(HybridInitConfig.GetApiResources())
            //    .AddInMemoryClients(HybridInitConfig.GetClients())
            //    .AddTestUsers(HybridInitConfig.GetUsers())
            //    .AddInMemoryApiScopes(HybridInitConfig.ApiScopes());

            #endregion


            #region password flow with Entity Framework

            //ConfigurationDbContext: keep Client, IdentityResource,ApiScopes, ApiResources
            //PersistedGrantDbContext: keep PersistedGrants,DeviceFlowCodes
            //    CustomUserDbContext: need to implement. 

            ////  add-migration InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb 
            ////  add-migration InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb

            string connectionString = this.Configuration.GetConnectionString("DefaultConnection");
            string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;//P03.DotNetCoreMVC.AuthenticationCenter.Ids4

            /*
            //services.AddDbContext<ConfigurationDbContext>(
            //    opt =>
            //        opt.UseSqlServer(
            //            connectionString,
            //            b => b.MigrationsAssembly(migrationsAssembly)
            //            )
            //        );
            //services.AddDbContext<PersistedGrantDbContext>(
            //    opt =>
            //        opt.UseSqlServer(
            //            connectionString,
            //            b => b.MigrationsAssembly(migrationsAssembly)
            //            )
            //        );
            */

            services.InitSeedDataForPassword(connectionString);
            services.AddIdentityServer()
                .AddDeveloperSigningCredential() //developer credential
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                    {
                        builder.UseSqlServer(connectionString);
                    };
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                    {
                        builder.UseSqlServer(connectionString);
                    };
                })
                .AddTestUsers(PasswordInitConfig.GetUsers());
            ////memory mode
            //    .AddInMemoryClients(PasswordInitConfig.GetClients())//get clients
            //    .AddInMemoryApiResources(PasswordInitConfig.GetApiResources())//get resources
            //    .AddTestUsers(PasswordInitConfig.GetUsers())//get users                                                                              //
            //    .AddInMemoryApiScopes(PasswordInitConfig.ApiScopes())
            //    ;

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

                #region add swagger, https://localhost:44398/index.html
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


//https://stackoverflow.com/questions/60055581/how-to-use-persistedgrantdbcontext-to-select-persistedgrant
//https://stackoverflow.com/questions/44618235/using-identityserver4-with-custom-configration-dbcontext