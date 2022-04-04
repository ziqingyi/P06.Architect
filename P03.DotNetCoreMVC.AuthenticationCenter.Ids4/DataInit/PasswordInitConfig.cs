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
                new ApiResource("UserApi",
                "user api",
                 new List<string> { IdentityModel.JwtClaimTypes.Role })
                {             
                    Enabled = true,
                    Scopes = new []{ "UserApi" }          
                },

                new ApiResource("TestApi",
                "test api",
                new List<string>{IdentityModel.JwtClaimTypes.Role})
                {
                    Enabled = true,
                    Scopes = new []{ "TestApi" }
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
                    ClientId = "idsclient",
                    //ClientSecrets = new []{ new Secret("test123".Sha256())  },

                    AllowAccessTokensViaBrowser = false,//provide password to Client 
                    RequireClientSecret = false,  // no client pass

                    ClientClaimsPrefix = "",

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = new []{ "UserApi", "TestApi" }
                    //no claim. claim will not be passed if password flow. 
                }
            };

        }




    }
}
/*
 
 https://stackoverflow.com/questions/45374721/getting-claims-in-identity-server-using-resource-owner-password
 
 https://stackoverflow.com/questions/61588752/identityserver4-client-for-password-flow-not-including-testuser-claims-in-access
 
 
 
 
 
 
 
 
 
 
 */