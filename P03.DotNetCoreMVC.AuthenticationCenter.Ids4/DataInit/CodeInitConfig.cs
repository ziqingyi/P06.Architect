using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;


namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit
{
    public class CodeInitConfig
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("UserApi",
                "user api",
                new List<string>{IdentityModel.JwtClaimTypes.Role,IdentityModel.JwtClaimTypes.Email}),

                new ApiResource("TestApi",
                "test api",
                new List<string>{IdentityModel.JwtClaimTypes.Role,IdentityModel.JwtClaimTypes.Email})
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
                    ClientName = "ApiClient for Implicit",
                    ClientSecrets = new []{ new Secret("test123".Sha256())  },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new []{ "UserApi", "TestApi" },

                    RedirectUris = {"http://localhost:44398/Ids4/IndexToken"},
                    AllowAccessTokensViaBrowser = true
                }
            };

        }





    }
}
