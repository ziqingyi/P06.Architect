using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomControllerFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($" this is {nameof(CustomControllerFilterAttribute)} OnActionExecuting");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($" this is {nameof(CustomControllerFilterAttribute)} OnActionExecuted");
        }


        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($" this is {nameof(CustomControllerFilterAttribute)} OnResultExecuting");
            //base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($" this is {nameof(CustomControllerFilterAttribute)} OnResultExecuted");
            //base.OnResultExecuted(context);
        }




    }
}
