using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.Utility.AuthExtension
{
    public class CustomExtendRequirement : IAuthorizationRequirement
    {

    }

    public class CustomExtendRequirementHandler : AuthorizationHandler<CustomExtendRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomExtendRequirement requirement)
        {
            var claims = context.User.Identities.First().Claims;
            var jti = context.User.FindFirst("jti")?.Value;

            bool tokenExists = false;
            if(tokenExists)
            {
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);//
            }
            return Task.CompletedTask;
        }
        
    }









}
