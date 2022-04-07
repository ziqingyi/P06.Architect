using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;


namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit
{
    //provided by client when user access 
    //https://localhost:44398/connect/authorize?client_id=idsclient&redirect_uri=https://localhost:44350/Ids4/IndexToken&response_type=token&scope=UserApi
    //
    /*
     https://localhost:44350/Ids4/IndexToken#access_token=eyJhbGciOiJSUzI1NiIsImtpZCI6IjUxOTBCMjc3NTRFNjBBQjBFRERFNUNGNEFDNUQ3MEVEIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2NDkwNTYzODYsImV4cCI6MTY0OTA1OTk4NiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzOTgiLCJjbGllbnRfaWQiOiJpZHNjbGllbnQiLCJzdWIiOiIwIiwiYXV0aF90aW1lIjoxNjQ5MDU2Mzg2LCJpZHAiOiJsb2NhbCIsImp0aSI6IkU1MDZDQTk5OTcyQTY5Q0VEQjE0NDI2QTI4RjU5MzBEIiwic2lkIjoiRTk5QkUxOThGREQ4QTZERjk0OUYzNjZFQjIyRDYwMUMiLCJpYXQiOjE2NDkwNTYzODYsInNjb3BlIjpbIlVzZXJBcGkiXSwiYW1yIjpbInB3ZCJdfQ.j6N_UvB-bUZ4TpcN8_xsnJRkCmEd8zAaiHfos3nAA9WhG_obPALrcVgTCBZANRcwrBVkvvVmDrK5lBle3cI4kNoX2qiLt_Y6RjMRTmZnBW8I74K9CcprLzxwK4TR4JpmUFWcEhom9rJxdiFTI47ynSGW2wweW0d9bOInJWfLv6JQzEYzvK04cHjgA3FjtiqjhHtIiWHiz9ioio9Hf7m4dTeYboRijIAebnAjp1euNnpCoFPhQjvyEknVqDFiu4fG0WElndZ7LgNZ15uHuSv3T4H_zaSRrLTcWR03cwZrPsDeGNQAGIJR1Hg9CyHxPTVHeL0i3RlOP6kXQcAEuplYxA&token_type=Bearer&expires_in=3600&scope=UserApi
     
     */
    public class ImplicitInitConfig
    {
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
                    new List<string>{IdentityModel.JwtClaimTypes.Role})
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
                    ClientName = "ApiClient for Implicit",
                    //ClientSecrets = new []{ new Secret("test123".Sha256())  },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new []{"read", "write", "TestApi.delete"},

                    RedirectUris = {"https://localhost:44350/Ids4/IndexToken"},//client not keep password, can be multiple uri.
                    AllowAccessTokensViaBrowser = true //via browser


                    //no claim here

                }
            };


        }




    }
}




/*
 
 
 
 
 
 
 */