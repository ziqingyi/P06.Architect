using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureLogging(loggingBuilder =>
                //{
                //    loggingBuilder.AddLog4Net("CfgFiles\\log4net.config");//add configuration file with default location. 

                //})
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())//change service provider
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    #region UseKestrel
                    //webBuilder.UseKestrel(
                    //        o =>
                    //        {
                    //            o.Listen(IPAddress.Loopback, 12344);
                    //        }
                    //    )
                    //    .Configure(app =>
                    //        app.Run(
                    //            async context
                    //                => await context.Response.WriteAsync("Hello from web host builder...."))
                    //    )
                    //    .UseIIS()
                    //    .UseIISIntegration();// integration mode
                    #endregion


                    webBuilder.UseStartup<Startup>();

                });
    }
}
