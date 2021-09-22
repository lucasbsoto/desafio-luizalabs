using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Shared.Extensions
{
    public static class JwtExtensions
    {
        public static (string, DateTime) GenerateJwtToken(string identifier, string email) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("hsduansd08ahd8ahyhsd087ahsdahdsbajb12u3b1!");
            var dataExpiracao = DateTime.UtcNow.AddHours(4);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, identifier),
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = dataExpiracao,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return (tokenHandler.WriteToken(token), dataExpiracao);
        }
    }
}
