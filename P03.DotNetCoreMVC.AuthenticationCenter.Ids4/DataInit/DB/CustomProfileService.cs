using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Test;
using Microsoft.Extensions.Logging;


namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit.DB
{
    public class CustomProfileService:IProfileService
    {

        protected readonly ILogger Logger;

        protected readonly IUserServiceTest userService;

        public CustomProfileService(IUserServiceTest user, ILogger<TestUserProfileService> logger)
        {
            userService = user;
            Logger = logger;
        }

        //The API that is expected to load claims for a user.
        // It is passed an instance of ProfileDataRequestContext
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            ////load all claim, not recommended
            //context.IssuedClaims = context.Subject.Claims.ToList();


            context.LogProfileRequest(Logger);
            // any claim requested
            if (context.RequestedClaimTypes.Any())
            {

                if (userService.userDto != null)
                {
                    //filter user's claim only
                    //var user = Users.FindBySubjectId(context.Subject.GetSubjectId());

                    context.AddRequestedClaims(userService.userDto.Claims);
                }
            }
            context.LogIssuedClaims(Logger);



            return Task.CompletedTask;
        }

        //The API that is expected to indicate if a user is currently allowed to obtain tokens.
        // It is passed an instance of IsActiveContext.
        public Task IsActiveAsync(IsActiveContext context)
        {
            Logger.LogDebug("IsActive called from: {caller}", context.Caller);

            //var user = Users.FindBySubjectId(context.Subject.GetSubjectId());

            context.IsActive = true;//user?.IsActive == true;


            return Task.CompletedTask;
        }


    }

    /*

    Often IdentityServer requires identity information about users when creating tokens or 
    when handling requests to the  userinfo or introspection endpoints. 
    By default, IdentityServer only has the claims in the authentication cookie to draw upon for this identity data.

    It is impractical to put all of the possible claims needed for users into the cookie, 
    so IdentityServer defines an extensibility point for allowing claims to be dynamically loaded as needed for a user. 
    This extensibility point is the IProfileService and it is common for a developer to implement this interface 
    to access a custom database or API that contains the identity data for users.


    */
}
