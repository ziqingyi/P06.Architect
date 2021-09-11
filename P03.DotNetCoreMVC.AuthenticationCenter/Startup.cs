using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility.AutofacUtility;
using P03.DotNetCoreMVC.Utility.Filters;

namespace P03.DotNetCoreMVC.AuthenticationCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region  static class use delegate passed and string parameter    to read from configuration

            //only need to keep the way to access configuration, library know what to read

            StaticConstraint.Init(s => configuration[s]);

            #endregion
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();



            #region for attribute

            services.AddScoped(typeof(CustomExceptionFilterAttribute));//attribute generated by container

            services.AddScoped(typeof(CustomExceptionFilterIOCAttribute));//attribute generated by container
            #endregion



        }

        #region update contianer to Autofac and configure, works together with ConfigureServices
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {

            containerBuilder.RegisterModule<CustomAutofacModule>();

        }
        #endregion


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });




            #region add log factory
            loggerFactory.AddLog4Net("CfgFiles\\log4net.config");//replace or override .net core internal Logger, so no need to add service. 
            #endregion



        }
    }
}
