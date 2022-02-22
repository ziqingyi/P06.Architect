
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
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("UserApi", "User API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "AuthenticationCenter.Ids4.DataInit",//Client Id
                    ClientSecrets = new [] { new Secret("test123123".Sha256()) },//client security
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    
                    AllowedScopes = new [] { "UserApi" },//accessible resources
                    Claims=new List<ClientClaim>(){
                        new ClientClaim(IdentityModel.JwtClaimTypes.Role,"Admin"),
                        new ClientClaim(IdentityModel.JwtClaimTypes.NickName,"Admin"),
                        new ClientClaim(ClaimTypes.Email,"abcdefg@gmail.com")
                    }
                }
            };
        }



    }
}
