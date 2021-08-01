using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {



        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.Result = new JsonResult(new
                {
                    Result = false,
                    Msg = context.Exception.Message
                });//terminate all following actions.

                context.ExceptionHandled = true;
            }
            //base.OnException(context);
        }

    }
}
