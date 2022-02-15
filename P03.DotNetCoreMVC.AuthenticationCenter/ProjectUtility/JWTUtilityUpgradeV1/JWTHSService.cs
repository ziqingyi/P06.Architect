using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using P03.DotNetCoreMVC.Utility.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility.JWTUtilityUpgradeV1
{
    //Hash-based Message Authentication Code (HMAC) using SHA-256, HS256
    public class JWTHSService : IJWTHSService
    {
        #region Inject option

        private readonly JWTTokenOptions _JWTTokenOptions;

        public JWTHSService(IOptionsMonitor<JWTTokenOptions> jwtTokenOptions)
        {
            this._JWTTokenOptions = jwtTokenOptions.CurrentValue;
        }

        #endregion


        /*  Claim: some info about the token
         *  
                Issuer: The issuer of the token，token ,   A name that refers to the issuer of the claim.
                Subject: The subject of the token，token, Gets the subject of the claim
                Expired: Expiration Time。 token expired time, Unix time
                iat: Issued At。 token create time， Unix time
                jti: JWT ID, id of this token
         */
        public string GetToken(CurrentUserCore currentUserInfo)
        {
            var claims = new[]
            {
                new Claim("Id",currentUserInfo.Id.ToString()),
                new Claim("Account",currentUserInfo.Account),
                new Claim(ClaimTypes.Name, currentUserInfo.Name),
                new Claim(ClaimTypes.Email, currentUserInfo.Email),                         
                new Claim("Role",currentUserInfo.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._JWTTokenOptions.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: this._JWTTokenOptions.Issuer,
                audience: this._JWTTokenOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(6),
                notBefore: DateTime.Now.AddSeconds(10),//take effect after 10 seconds
                signingCredentials: creds     
                
                );


            string returnTOken = new JwtSecurityTokenHandler().WriteToken(token);
            return returnTOken;

        }
    }
}
