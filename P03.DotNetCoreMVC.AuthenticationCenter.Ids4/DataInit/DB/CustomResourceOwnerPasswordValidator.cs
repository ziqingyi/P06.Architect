using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit.DB
{
    public class CustomResourceOwnerPasswordValidator:IResourceOwnerPasswordValidator
    {
        private readonly IUserServiceTest _iUserServiceTest;

        public CustomResourceOwnerPasswordValidator(IUserServiceTest userService)
        {
            this._iUserServiceTest = userService;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            Console.WriteLine($"This is CustomResourceOwnerPasswordValidator {context.UserName}--{context.Password}");
            var user = this._iUserServiceTest.Login(context.UserName, context.Password);

            if (user is null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
            }
            else
            {
                context.Result = new GrantValidationResult(
                    user.UId.ToString(),
                    OidcConstants.AuthenticationMethods.Password,
                    DateTime.UtcNow,
                    user.Claims);
            }

            return Task.CompletedTask;
        }
    }



    public class UserTestDTO
    {
        public int UId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Claim> Claims { get; set; }
    }
    public interface IUserServiceTest
    {
        UserTestDTO Login(string userName, string password);
    }

    public class UserServiceTest : IUserServiceTest
    {
        public UserTestDTO Login(string userName, string password)
        {
            return new UserTestDTO()
            {
                UId = 123,
                UserName = userName,
                Password = password,
                Claims = new List<Claim>(){
                    new Claim(IdentityModel.JwtClaimTypes.Role,"Admin"),
                    new Claim(IdentityModel.JwtClaimTypes.NickName, "admin User 2"),
                    new Claim(IdentityModel.JwtClaimTypes.Email,"abcdefg@gmail.com")
                }
            };
        }
    }





}
