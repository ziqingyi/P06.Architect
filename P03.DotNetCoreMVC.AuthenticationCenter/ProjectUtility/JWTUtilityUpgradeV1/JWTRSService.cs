using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using P03.DotNetCoreMVC.Utility.AuthHelper;
using P03.DotNetCoreMVC.Utility.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility.JWTUtilityUpgradeV1
{
    //SHA-256 is a patented cryptographic hash function that outputs a value that is 256 bits long.
    //RS256:(RSA Signature with SHA-256) 
    /* RS256  is an asymmetric algorithm, and it uses a public/private key pair: the identity provider has a private (secret) key 
     * used to generate the signature, and the consumer of the JWT gets a public key to validate the signature.
     * Since the public key, as opposed to the private key, doesn’t need to be kept secured, most identity providers 
     * make it easily available for consumers to obtain and use (usually through a metadata URL).
     */
    public class JWTRSService : IJWTRSService
    {

        #region Inject option

        private readonly JWTTokenOptions _jWTTokenOptions;
        public JWTRSService(IOptionsMonitor<JWTTokenOptions> jwtTokenOptions)
        {
            this._jWTTokenOptions = jwtTokenOptions.CurrentValue;
        }

        #endregion

        public string GetToken(CurrentUserCore currentUserInfo)
        {
            var claims = new[]
           {
                new Claim("Id",currentUserInfo.Id.ToString()),
                new Claim("Account",currentUserInfo.Account),
                new Claim(ClaimTypes.Name, currentUserInfo.Name),
                new Claim(ClaimTypes.Email, currentUserInfo.Email),
                //new Claim("Role",currentUserInfo.Role==""? "staff":currentUserInfo.Role)//error, "Role" is not ClaimTypes.Role 
                new Claim(ClaimTypes.Role,currentUserInfo.Role==""? "staff":currentUserInfo.Role)//correct
            };

            string keyDir = Directory.GetCurrentDirectory();
                
            if(RSAHelper.TryGetKeyParameters(keyDir, true,out RSAParameters keyParams)   == false)
            {
                keyParams = RSAHelper.GenerateAndSaveKey(keyDir);
            }

            var credentials = new SigningCredentials(new RsaSecurityKey(keyParams), SecurityAlgorithms.RsaSha256Signature);

            var token = new JwtSecurityToken(
                issuer: this._jWTTokenOptions.Issuer,
                audience: this._jWTTokenOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials
                );

            var handler = new JwtSecurityTokenHandler();
            string tokenString = handler.WriteToken(token);
            return tokenString;

        }
    }
}
