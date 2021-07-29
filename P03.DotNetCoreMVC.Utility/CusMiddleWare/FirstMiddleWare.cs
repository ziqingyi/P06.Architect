﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.Utility.CusMiddleWare
{
    public class FirstMiddleWare
    {
        private readonly RequestDelegate _next;

        public FirstMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"{nameof(FirstMiddleWare)},begin!<br/>");

            await _next(context);

            await context.Response.WriteAsync($"{nameof(FirstMiddleWare)},end!<br/>");
        }

    }
}
