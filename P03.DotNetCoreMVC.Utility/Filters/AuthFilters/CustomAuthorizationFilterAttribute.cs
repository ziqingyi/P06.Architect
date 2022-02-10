using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.Utility.Filters.AuthFilters
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.ActionDescriptor.EndpointMetadata.Any(item => item is AllowAnonymousAttribute))
            {
                return;//no check
            }

            if(context.Filters.Any(f => f is IAllowAnonymousFilter))
            {
                return;//bypass check
            }


            string sUser = context.HttpContext.Request.Cookies["CurrentUser"];
            if(sUser == null)
            {
                context.Result = new RedirectResult("~/Home/Index");
            }
            else
            {
                //check authorization details
                // .....
                return;
            }
        }
    }












}
