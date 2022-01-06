using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;


namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomActionFilterLogLogAttribute : ActionFilterAttribute
    {
        private ILogger<CustomActionFilterLogLogAttribute> _logger;
        public CustomActionFilterLogLogAttribute(ILogger<CustomActionFilterLogLogAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomActionFilterLogLogAttribute)} OnActionExecuting" +
                              $" with order {this.Order}");

            var actionLog = $"{DateTime.Now} is calling {context.RouteData.Values["action"]} api; Parameter:{Newtonsoft.Json.JsonConvert.SerializeObject(context.ActionArguments)}";
            _logger.LogInformation(actionLog);

        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomActionFilterLogLogAttribute)} OnActionExecuted" +
                              $" with order {this.Order}");

            var result = context.Result;
            ObjectResult objectResult = result as ObjectResult;
            var actionLog = $"{DateTime.Now} executed {context.RouteData.Values["action"]} api; Result:{Newtonsoft.Json.JsonConvert.SerializeObject(objectResult.Value)}";
            _logger.LogInformation(actionLog);
        }



        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomActionFilterLogLogAttribute)} OnResultExecuting" +
                              $" with order {this.Order}");
            //base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomActionFilterLogLogAttribute)} OnResultExecuted" +
                              $" with order {this.Order}");
            //base.OnResultExecuted(context);
        }



    }
}
