
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Ids4.DataInit
{
    public class ClientInitConfig
    {

        public static IEnumerable<ApiScope> Apis()
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

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "idsclient",//Client Id
                    ClientSecrets = new [] { new Secret("test123".Sha256()) },//client security
                     //ClientSecrets = new [] { new Secret("test123123") },//client security
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    

                    //https://identityserver4.readthedocs.io/en/latest/topics/resources.html?highlight=IResourceStore#migration-steps-to-v4
                    AllowedScopes = new [] {  "read", "write", "TestApi.delete" },//accessible resources

                    ClientClaimsPrefix = "",
                    Claims=new List<ClientClaim>(){
                        new ClientClaim(IdentityModel.JwtClaimTypes.Role,"Admin"),
                        new ClientClaim(IdentityModel.JwtClaimTypes.NickName,"Admin"),
                        new ClientClaim(ClaimTypes.Email,"abcdefg@gmail.com")
                    }
                    ,AllowOfflineAccess = true
                }
            };
        }



    }
}
/*https://identityserver4.readthedocs.io/en/latest/endpoints/token.html
 * 
 * 1 Post
 * 2 body, x-www-form-urlencoded
 * 3 Scope
 *    https://github.com/IdentityServer/IdentityServer4/issues/4508 
 *    https://identityserver4.readthedocs.io/en/latest/topics/resources.html?highlight=IResourceStore#migration-steps-to-v4
 *  To migrate to v4 you need to split up scope and resource registration, 
 *  typically by first registering all your scopes (e.g. using the AddInMemoryApiScopes method), 
 *  and then register the API resources (if any) afterwards. 
 *  The API resources will then reference the prior registered scopes by name.
 * 
 * 
 * 4 audience: 
 *   https://identityserver4.readthedocs.io/en/latest/topics/resources.html?highlight=API%20resource#api-resources
 *   https://stackoverflow.com/questions/62645604/asp-net-core-3-0-identity-server-4-4-0-0-securitytokeninvalidaudienceexception
 */



