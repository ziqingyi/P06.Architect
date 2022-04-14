using System;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit.DB
{
    public class CustomGrantValidator: IExtensionGrantValidator
    {
        public string GrantType => "CustomGrantType";

        private readonly IUserServiceTest _iUserServiceTest;

        public CustomGrantValidator(IUserServiceTest userServiceTest)
        {
            this._iUserServiceTest = userServiceTest;
        }

        public Task ValidateAsync(ExtensionGrantValidationContext context)
        {

            var CE_name = context.Request.Raw.Get("CE_name");
            var CE_password = context.Request.Raw.Get("CE_password");
            Console.WriteLine($"This is CustomGrantValidator CE_name = {CE_name}--CE_password = {CE_password}");

            if (string.IsNullOrEmpty(CE_name) || string.IsNullOrEmpty(CE_password))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
            }
            var result = this._iUserServiceTest.Login(CE_name, CE_password);

            if (result == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
            }
            else
            {
                Console.WriteLine($"This is CustomElevenGrantValidator CE_name = {CE_name}--CE_password = {CE_password}");
                context.Result = new GrantValidationResult(
                    subject: result.UId.ToString(),
                    authenticationMethod: GrantType,
                    claims: result.Claims);
            }
            return Task.CompletedTask;

        }


    }
}
