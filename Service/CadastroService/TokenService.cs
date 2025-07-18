using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace CadastroDeComputadores.Service {
    public class TokenService {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config) {
            _config = config;
        }

        public string GenerateToken(string email) {
            // Obtém a chave secreta do arquivo de configuração
            var secretKey = _config["JwtSettings:Secret"];
            if (string.IsNullOrEmpty(secretKey)) {
                throw new InvalidOperationException("A chave secreta JWT não está configurada.");
            }

            var key = Encoding.UTF8.GetBytes(secretKey);
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: new[] { new Claim(ClaimTypes.Email, email) },
                expires: DateTime.UtcNow.AddHours(2), // Token válido por 2 horas
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
