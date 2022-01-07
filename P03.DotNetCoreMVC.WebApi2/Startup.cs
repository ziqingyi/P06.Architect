using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using P03.DotNetCoreMVC.Utility.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.WebApi2
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
            services.AddRazorPages();


            #region add for Swagger

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Doc-V1",
                    new OpenApiInfo
                    {
                        Title = "test",
                        Version = "v1",
                        Description = "SwaggerDoc test v1"
                    });
            });

            #endregion

            #region for attribute

            services.AddScoped(typeof(CustomActionFilterLogLogAttribute));//attribute injected by container

            #endregion

            #region for Global attribute, all controller 

            services.AddMvc(option =>
            {
                option.Filters.Add( typeof(CustomGlobalParaFilterAttribute),order:0 );
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
                app.UseExceptionHandler("/Error");
            }

            #region add swagger middleware

            app.UseSwagger();
            app.UseSwaggerUI(
                s =>
                {
                    s.SwaggerEndpoint("/swagger/Doc-V1/swagger.json", "test1");
                });

            #endregion


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
