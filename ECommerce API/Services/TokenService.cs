using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce_API.Services
{
    public class TokenService
    {
        // Claims - Informações do Usuario que quero guardar.
        public string GenerateToken(string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            // Criar uma chave de seguranca e criptografar ela.
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai"));

            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "ecommerce",
                audience: "ecommerce",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
