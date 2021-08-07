using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomActionCacheFilterAttribute :ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($" this is {nameof(CustomActionCacheFilterAttribute)} OnActionExecuting" +
                              $" with order {this.Order}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //cache content in browser, will not request backend
            context.HttpContext.Response.Headers.Add("Cache-Control","public,max-age=6000");


            Console.WriteLine($" this is {nameof(CustomActionCacheFilterAttribute)} OnActionExecuted" +
                              $" with order {this.Order}");
        }



        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($" this is {nameof(CustomActionCacheFilterAttribute)} OnResultExecuting" +
                              $" with order {this.Order}");
            //base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($" this is {nameof(CustomActionCacheFilterAttribute)} OnResultExecuted" +
                              $" with order {this.Order}");
            //base.OnResultExecuted(context);
        }


    }
}
