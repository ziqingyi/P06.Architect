using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.Utility.AuthExtension
{
    public class DoubleEMailRequirement:IAuthorizationRequirement
    {


    }



    public class GMailHandler : AuthorizationHandler<DoubleEMailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DoubleEMailRequirement requirement)
        {
            if(context.User != null && context.User.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                var email = context.User.FindFirst(c => c.Type == ClaimTypes.Email).Value;
                if(email.EndsWith("@gmail.com",StringComparison.OrdinalIgnoreCase))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    //do not set fail()
                    //context.Fail();
                }
            }
            return Task.CompletedTask;
        }
    }

    public class OutlookMailHandler : AuthorizationHandler<DoubleEMailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DoubleEMailRequirement requirement)
        {
            if (context.User != null && context.User.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                var email = context.User.FindFirst(c => c.Type == ClaimTypes.Email).Value;
                if (email.EndsWith("@outlook.com", StringComparison.OrdinalIgnoreCase))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    //do not set fail()
                    //context.Fail();
                }
            }
            return Task.CompletedTask;
        }
    }























}
