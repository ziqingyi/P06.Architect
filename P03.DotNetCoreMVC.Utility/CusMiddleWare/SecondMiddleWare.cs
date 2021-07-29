using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace P03.DotNetCoreMVC.Utility.CusMiddleWare
{
    public class SecondMiddleWare
    {
        private readonly RequestDelegate _next;

        public SecondMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"{nameof(SecondMiddleWare)},begin! <br/>");
            await _next(context);
            await context.Response.WriteAsync($"{nameof(SecondMiddleWare)},end! <br/>");
        }

    }
}
