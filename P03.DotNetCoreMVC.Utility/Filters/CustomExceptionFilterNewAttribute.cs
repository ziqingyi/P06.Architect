﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomExceptionFilterNewAttribute : ExceptionFilterAttribute
    {
        #region Identity, use for logging when error

        private readonly ILogger<CustomExceptionFilterNewAttribute> _logger;

        public CustomExceptionFilterNewAttribute(ILogger<CustomExceptionFilterNewAttribute> logger)
        {
            this._logger = logger;
        }

        #endregion

        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                //log first
                this._logger.LogError($"{context.HttpContext.Request.RouteValues["controller"]} has Error");

                //check request: whether it is Ajax request. 
                //if (context.HttpContext.Request.IsAjax())//.net framework: check header: XMLHttpRequest
                if (this.IsAjaxReqeust(context.HttpContext.Request))
                {
                    context.Result = new JsonResult(new
                    {
                        Result = false,
                        Msg = context.Exception.Message
                    });//terminate all following actions.

                    context.ExceptionHandled = true;
                }
                else
                {
                    context.Result = new RedirectResult("/Home/Error");
                }
                context.ExceptionHandled = true;
            }
            //base.OnException(context);
        }



        private bool IsAjaxReqeust(HttpRequest request)
        {
            string header = request.Headers["X-Requested-With"];
            return "X-Requested-With".Equals(header);
        }


    }
}
