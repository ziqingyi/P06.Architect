using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomActionFilterAttribute:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($" this is {nameof(CustomActionFilterAttribute)} OnActionExecuting" +
                              $" with order {this.Order}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($" this is {nameof(CustomActionFilterAttribute)} OnActionExecuted" +
                              $" with order {this.Order}");
        }



        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($" this is {nameof(CustomActionFilterAttribute)} OnResultExecuting" +
                              $" with order {this.Order}");
            //base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($" this is {nameof(CustomActionFilterAttribute)} OnResultExecuted" +
                              $" with order {this.Order}");
            //base.OnResultExecuted(context);
        }


    }
}
