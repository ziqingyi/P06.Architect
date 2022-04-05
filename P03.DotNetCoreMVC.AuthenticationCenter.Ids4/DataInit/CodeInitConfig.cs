using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;


namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit
{
    //provided by client when user access 
    //https://localhost:44398/connect/authorize?client_id=idsclient&redirect_uri=https://localhost:44350/Ids4/IndexCodeToken&response_type=code&scope=UserApi
    //
    public class CodeInitConfig
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("UserApi",
                "user api",
                new List<string>{IdentityModel.JwtClaimTypes.Role })
                {
                    Enabled = true,
                    Scopes = new []{ "UserApi" }
                },

                new ApiResource("TestApi",
                "test api",
                new List<string>{IdentityModel.JwtClaimTypes.Role,IdentityModel.JwtClaimTypes.Email})
                 {
                    Enabled = true,
                    Scopes = new []{ "TestApi" }
                }
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
        public static IEnumerable<ApiScope> Apis()
        {

            return new List<ApiScope>
            {
                new ApiScope("UserApi", "My Api"),
                 new ApiScope("TestApi", "test Api")
            };
        }
        public static IEnumerable<Client> GetClients()
        {

            return new[]
            {
                new Client
                {
                    ClientId = "idsclient",
                    ClientName = "ApiClient for Authorization Code",
                    //ClientSecrets = new []{ new Secret("test123".Sha256())  },

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = new []{ "UserApi", "TestApi" },

                    RequirePkce = false,
                    //in version 4.0 and above, the code flow + PKCE is used by default, so disable it. 
                    RequireClientSecret = false,

                    RedirectUris = {"https://localhost:44350/Ids4/IndexCodeToken"},
                    AllowAccessTokensViaBrowser = true,  //via browser

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse
                }
            };

        }





    }
}
