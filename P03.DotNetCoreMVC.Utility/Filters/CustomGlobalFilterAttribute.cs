using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomGlobalFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($" this is {nameof(CustomGlobalFilterAttribute)} OnActionExecuting");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($" this is {nameof(CustomGlobalFilterAttribute)} OnActionExecuted");
        }



        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($" this is {nameof(CustomGlobalFilterAttribute)} OnResultExecuting");
            //base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($" this is {nameof(CustomGlobalFilterAttribute)} OnResultExecuted");
            //base.OnResultExecuted(context);
        }

    }
}
