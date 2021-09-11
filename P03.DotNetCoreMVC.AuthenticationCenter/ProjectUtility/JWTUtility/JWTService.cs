using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility.JWTUtility
{
    public class JWTService:IJWTService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /*  Claim: some info about the token

                Issuer: The issuer of the token，token ,   A name that refers to the issuer of the claim.
                Subject: The subject of the token，token, Gets the subject of the claim
                Expired: Expiration Time。 token expired time, Unix time
                iat: Issued At。 token create time， Unix time
                jti: JWT ID
         * 
         *
         *
         */
        public string GetToken(string userName)
        {
            var claims = new []
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim("Name", "User1"),
                new Claim("Role", "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["issuer"],
                audience: _configuration["audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds
            );

            string returnToken = new JwtSecurityTokenHandler().WriteToken(token);

            return returnToken;
        }





    }
}
