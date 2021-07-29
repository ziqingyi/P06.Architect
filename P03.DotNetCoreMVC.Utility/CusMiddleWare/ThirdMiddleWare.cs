using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace P03.DotNetCoreMVC.Utility.CusMiddleWare
{
    public class ThirdMiddleWare
    {
        private readonly RequestDelegate _next;

        public ThirdMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("stop"))
                await context.Response.WriteAsync($"{nameof(ThirdMiddleWare)}This is End<br/>");

            else
            {
                await context.Response.WriteAsync($"{nameof(ThirdMiddleWare)},ThirdMiddleWare begin!<br/>");
                await _next(context);
                await context.Response.WriteAsync($"{nameof(ThirdMiddleWare)},ThirdMiddleWare end!<br/>");


            }

        }



    }
}
