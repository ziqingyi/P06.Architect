using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.Extensions.RouteUse
{
    public static class RouteExtension
    {

        public static void AddDynamicRoute(this IServiceCollection services)
        {
            services.AddSingleton<TranslationTransformer>();
            services.AddSingleton<TranslationDatabase>();
        }


        public static void UseDynamicRouteDefault(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapDynamicControllerRoute<TranslationTransformer>("{language}/{controller}/{action}");
        }


        public static void UseMapGetDefault(this IEndpointRouteBuilder endpoints)
        {
            RequestDelegate requestDelegate = async context =>
            {
                var name = context.Request.RouteValues["name"];

                await context.Response.WriteAsync($"Hello  {name}!");
            };


            endpoints.MapGet("/hello/{name:alpha}", requestDelegate);
        }

    }
}
