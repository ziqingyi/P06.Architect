using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit
{
    public class HybridInitConfig
    {

        //Scope: the scope of access that the client requests.
        //scope parameter is a list of space delimited values - you need to provide the
        //structure and semantics of it.
        //Some scopes might be exclusive to that resource, and some scopes might be shared.
        /*
         *Given that OAuth 2.0 is all about allowing a client application access to an API,
         *then the scope is simply an abstract identifier for an API.
         * A scope could be as coarse grained as “the calendar API” or “the document storage API”,
         * or as fine grained as “read-only access to the calendar API” or “read-write access to
         * the calendar API”. It’s possible that other semantics could be infused into your
         * scope definitions as well. This scope is an API scope and models an application’s ability
         * to use an API. In IdentityServer, these API scopes are modeled with the ApiResource class.
         * The constructor allows you to pass the name of the scope (e.g. calendar or documents).
         *
         */
        public static IEnumerable<ApiScope> Apis()
        {

            return new List<ApiScope>
            {
                new ApiScope("read", "Read your data."),
                new ApiScope("write", "Write your data."),
                new ApiScope("TestApi.delete", "delete your test api.")
            };
        }



        //represent functionality a client wants to access.(physical or logical API.
        //In turn each API can potentially have scopes as well.Some scopes might be exclusive to that resource,
        //and some scopes Typically, they are HTTP-based endpoints
        // (aka APIs), but could be also message queuing endpoints or similar.
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

        //user info which can send back. identity scopes are modeled with IdentityResource.
        //An identity resource is a named group of claims that can be requested using the scope parameter
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(), //standard scopes
                new IdentityResources.Profile(),
                new IdentityResource(
                    "CustomIdentityResource",
                    "This is Custom Model",
                    new List<string>(){ "phonemodel","phoneprise", IdentityModel.JwtClaimTypes.Email})
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
                    AllowedScopes = new []{ "read", "write","TestApi.delete",
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
