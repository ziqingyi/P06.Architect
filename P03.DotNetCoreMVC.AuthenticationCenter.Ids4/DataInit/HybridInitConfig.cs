using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit
{
    public class HybridInitConfig
    {

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(
                     "CustomIdentityResource",
                     "This is Custom Model",
                     new List<string>(){ "phonemodel","phoneprise", "eMail"})
            };

        }


        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                  new ApiResource("UserApi",
                "user api",
                new List<string>{IdentityModel.JwtClaimTypes.Role})
                {
                    Enabled = true,
                    Scopes = new []{ "UserApi" }
                },

                new ApiResource("TestApi",
                "test api",
                new List<string>{IdentityModel.JwtClaimTypes.Role})
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
                        new Claim(IdentityModel.JwtClaimTypes.Email,"abcdefg@gmail.com"),
                        new Claim("phonemodel","iphonex")
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
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,


                    ClientId = "idsclient",
                    ClientName = "ApiClient for Implicit",
                    ClientSecrets = new []{ new Secret("test123".Sha256())  },
                    
                    AccessTokenLifetime = 3600,
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowedScopes = new []{ "UserApi", "TestApi",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "CustomIdentityResource"},

                    RedirectUris = {"https://localhost:44350/Ids4/IndexCodeToken"},//client not keep password, can be multiple uri.
                    AllowAccessTokensViaBrowser = true //via browser
                }
            };

        }








    }
}
