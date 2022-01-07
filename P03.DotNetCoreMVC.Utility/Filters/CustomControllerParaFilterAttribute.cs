using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomControllerParaFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {

        private ILogger<CustomControllerParaFilterAttribute> _logger = null;

        public int Order
        {
            get;
            set;
        }

        public CustomControllerParaFilterAttribute(ILogger<CustomControllerParaFilterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomControllerParaFilterAttribute)} OnActionExecuting" + $" with order {this.Order}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($" this is {nameof(CustomControllerParaFilterAttribute)} OnActionExecuted" + $" with order {this.Order}");
        }


        //public void OnResultExecuting(ResultExecutingContext context)
        //{
        //    _logger.LogInformation($" this is {nameof(CustomControllerParaFilterAttribute)} OnResultExecuting");
        //    //base.OnResultExecuting(context);
        //}

        //public void OnResultExecuted(ResultExecutedContext context)
        //{
        //    _logger.LogInformation($" this is {nameof(CustomControllerParaFilterAttribute)} OnResultExecuted");
        //    //base.OnResultExecuted(context);
        //}


    }
}
