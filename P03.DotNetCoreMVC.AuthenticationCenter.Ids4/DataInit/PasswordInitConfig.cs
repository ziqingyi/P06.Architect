using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;


namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit
{
    public class PasswordInitConfig
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("UserApi","user api", new List<string>{IdentityModel.JwtClaimTypes.Role,"Email"}),

                new ApiResource("TestApi","test api",new List<string>{IdentityModel.JwtClaimTypes.Role,"Email"})
            };
        }

        public static List<TestUser> GetUsers()
        {

            return new List<TestUser>()
            {
                new TestUser()
                {
                    Username="adminUser1",
                    Password="123456",
                    SubjectId="0",
                    Claims = new List<Claim>()
                    {
                        new Claim(IdentityModel.JwtClaimTypes.Role,"Admin"),
                        new Claim(IdentityModel.JwtClaimTypes.NickName, "admin User 1"),
                        new Claim(IdentityModel.JwtClaimTypes.Email,"abcdefg@gmail.com")
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "ids4client",
                    ClientSecrets = new []{ new Secret("test123".Sha256())  },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = new []{ "UserApi", "TestApi" }
                    //no claim. 
                }
            };

        }




    }
}
