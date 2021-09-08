using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FC.Extension.HTTP.HTTPHandlers
{
    /// <summary>
    /// A helper method to decode JWT Token
    /// </summary>
   public static class DecodeJWTExtension
    {
        /// <summary>
        /// An extension method, to decode JWT token
        /// </summary>
        /// <param name="token">the actual token value</param>
        /// <param name="secret">secret to decode and validate the token</param>
        /// <returns>returns ClaimsPrincipal</returns>
        public static ClaimsPrincipal DecodeJWT(this string token, string secret)
        {
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);
            return claims;
            // Eg. of how to consume the value of claims.
            //var claimList = claims.Claims.ToList<Claim>();
            //UserCredential user = claimList[2].Value.ToModel<UserCredential>();
            //return user;
        }
    }
}
