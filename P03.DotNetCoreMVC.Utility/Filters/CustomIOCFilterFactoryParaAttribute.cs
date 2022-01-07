using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.Filters
{
    public class CustomIOCFilterFactoryParaAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => true;

        public Type _filterType = null;

        public CustomIOCFilterFactoryParaAttribute(Type type)
        {
            _filterType = type;
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return (IFilterMetadata)serviceProvider.GetService(_filterType);
        }



    }
}
