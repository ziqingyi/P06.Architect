using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;


namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit
{
    public class PasswordInitConfig
    {
        //The scopes requested by the client control what user claims are returned in the tokens to the client.
        public static IEnumerable<ApiScope> ApiScopes()
        {

            return new List<ApiScope>
            {
                new ApiScope("read", "Read your data."),
                new ApiScope("write", "Write your data."),
                new ApiScope("TestApi.delete", "delete your test api.")
            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource(
                    "UserApi",
                    "user api",
                    new List<string>{IdentityModel.JwtClaimTypes.Role,IdentityModel.JwtClaimTypes.Email})
                {
                    Enabled = true,
                    Scopes = new []{ "read", "write"}
                },

                new ApiResource(
                    "TestApi",
                    "test api",
                    new List<string>{IdentityModel.JwtClaimTypes.Role})
                {
                    Enabled = true,
                    Scopes = new []{ "read", "write", "TestApi.delete" }
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
                    AllowedScopes = new []{ "read", "write", "TestApi.delete" }
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