using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Utility.Models;
using P03.DotNetCoreMVC.Utility.WebHelper;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomActionCheckFilterAttribute: ActionFilterAttribute
    {
        #region Identity
        private readonly ILogger<CustomActionCheckFilterAttribute> _logger;
        public CustomActionCheckFilterAttribute(ILogger<CustomActionCheckFilterAttribute> logger
        )
        {
            this._logger = logger;
        }
        #endregion

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            CurrentUserCore currentUser = context.HttpContext.GetCurrentUserBySession();

            if (currentUser == null)
            {
                //check request header,whether it's XMLHttpRequest
                if (this.IsAjaxRequestInCore(context.HttpContext.Request))
                {
                    context.Result = new JsonResult(
                        new
                        {
                            Result = false,
                            PromptMsg = "No Session User",
                            DebugMessage = "No Session User"
                        }
                    );

                }
                else
                {
                    string controllerName = context.Controller.GetType().Name;
                    string LoginAddress = "~/" + controllerName.Substring(0, controllerName.Length-10) + "/Login";//"~/DFourth/Login"
                    context.Result = new RedirectResult(LoginAddress);
                }
            }
            else
            {
                this._logger.LogDebug($"{currentUser.Name} visit the system");
            }

        }

        private bool IsAjaxRequestInCore(HttpRequest request)
        {
            string header = request.Headers["X-Requested-With"];
            return "XMLHttpRequest".Equals(header);
        }




















    }
}
