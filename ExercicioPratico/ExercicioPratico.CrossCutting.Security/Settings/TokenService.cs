using ExercicioPratico.CrossCutting.Security.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExercicioPratico.CrossCutting.Security.Settings
{
    public class TokenService
    {
        private readonly AppSettings appSettings;

        public TokenService(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //conteudo do TOKEN
            var tokenDescription = new SecurityTokenDescriptor
            {
                //definições do usuário
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, username) }),
                //tempo de validade do TOKEN
                Expires = DateTime.Now.AddDays(1),
                //criptografia do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
