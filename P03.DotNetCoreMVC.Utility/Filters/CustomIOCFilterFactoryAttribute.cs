using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomIOCFilterFactoryAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return (IFilterMetadata)serviceProvider.GetService(typeof(CustomExceptionFilterNewAttribute));
        }
    }
}
