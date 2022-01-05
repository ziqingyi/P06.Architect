using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomActionFilterLogAttribute:ActionFilterAttribute
    {
        private ILogger<CustomActionFilterLogAttribute> _logger;
        public CustomActionFilterLogAttribute(ILogger<CustomActionFilterLogAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomActionFilterLogAttribute)} OnActionExecuting" +
                              $" with order {this.Order}");

            var actionLog = $"{DateTime.Now} is calling {context.RouteData.Values["action"]} api; Parameter:{Newtonsoft.Json.JsonConvert.SerializeObject(context.ActionArguments)}";
            _logger.LogInformation(actionLog);

        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomActionFilterLogAttribute)} OnActionExecuted" +
                              $" with order {this.Order}");

            var result = context.Result;
            ObjectResult objectResult = result as ObjectResult;
            var actionLog = $"{DateTime.Now} executed {context.RouteData.Values["action"]} api; Result:{Newtonsoft.Json.JsonConvert.SerializeObject(objectResult.Value)}";
            _logger.LogInformation(actionLog);
        }



        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomActionFilterLogAttribute)} OnResultExecuting" +
                              $" with order {this.Order}");
            //base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomActionFilterLogAttribute)} OnResultExecuted" +
                              $" with order {this.Order}");
            //base.OnResultExecuted(context);
        }



    }
}
