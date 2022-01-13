using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomCorsFilterAttribute:Attribute, IActionFilter
    {
        //private ILogger<CustomCorsFilterAttribute> _Logger = null;

        //public CustomCorsFilterAttribute(ILogger<CustomCorsFilterAttribute> logger)
        //{
        //    _Logger = logger;
        //}

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
