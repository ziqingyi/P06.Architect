using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomGlobalParaFilterAttribute : ActionFilterAttribute
    {
        private ILogger<CustomGlobalParaFilterAttribute> _logger = null;

        public CustomGlobalParaFilterAttribute(ILogger<CustomGlobalParaFilterAttribute> logger)
        {
            this._logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomGlobalParaFilterAttribute)} OnActionExecuting");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomGlobalParaFilterAttribute)} OnActionExecuted");
        }



        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomGlobalParaFilterAttribute)} OnResultExecuting");
            //base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomGlobalParaFilterAttribute)} OnResultExecuted");
            //base.OnResultExecuted(context);
        }
    }
}
