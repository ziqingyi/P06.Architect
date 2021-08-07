using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    //For FilterFactory: implement IFilterMetadata
    public class CustomResourceFilterAttribute : Attribute, IResourceFilter,IFilterMetadata
    {
        private static Dictionary<string, IActionResult> CustomCache = new Dictionary<string, IActionResult>();
        
        //before execution
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"This is {nameof(CustomResourceFilterAttribute)} OnResourceExecuting....");
            //check cache
            string key = context.HttpContext.Request.Path;
            if (CustomCache.ContainsKey(key))
            {
                context.Result = CustomCache[key];//context stopping executing.Result will be converted to HTML.
            }
        }

        //after execution
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"This is {nameof(CustomResourceFilterAttribute)} OnResourceExecuted....");
            //keep cache
            string key = context.HttpContext.Request.Path;
            if (!CustomCache.ContainsKey(key))
            {
                CustomCache.Add(key,context.Result);
            }

        }


    }
}
