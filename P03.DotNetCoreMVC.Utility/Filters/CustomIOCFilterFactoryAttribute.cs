using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomIOCFilterFactoryAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => true;

        //create filter by IOC instance serviceProvider
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return (IFilterMetadata)serviceProvider.GetService(typeof(CustomExceptionFilterIOCAttribute));
        }




        /*  update to: 

        private readonly Type _FilterType = null;

        public CustomIOCFilterFactoryAttribute(Type type)
        {
            this._FilterType = type;
        }
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            //return (IFilterMetadata)serviceProvider.GetService(typeof(CustomExceptionFilterAttribute));

            return (IFilterMetadata)serviceProvider.GetService(this._FilterType);
        }


        */







    }
}
