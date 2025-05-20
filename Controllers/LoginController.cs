using Microsoft.AspNetCore.Mvc;
using CadastroDeComputadores.Models;
using CadastroDeComputadores.Service;
using CadastroDeComputadores.DataContext;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase {
    private readonly TokenService _tokenService;
    private readonly AplicationDbContext _context;

    public LoginController(TokenService tokenService, AplicationDbContext context) {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel model) {
        // Busca o usuário pelo e-mail
        var user = await _context.Login.FirstOrDefaultAsync(u => u.Email == model.Email);

        if (user == null)
            return Unauthorized(new { message = "Usuário ou senha inválidos." });

        // Verifica se a senha fornecida bate com a senha armazenada (hash)
        if (!VerifyPassword(model.Password, user.Password))
            return Unauthorized(new { message = "Usuário ou senha inválidos." });

        // Se passou na verificação, gera o token
        var token = _tokenService.GenerateToken(user.Email);
        return Ok(new { token });
    Console.WriteLine($"Login recebido: {model.Email} - {model.Password}");
    }

    private bool VerifyPassword(string password, string storedHash) {
        using (SHA256 sha256 = SHA256.Create()) {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Converte o hash para hexadecimal
            StringBuilder builder = new StringBuilder();
            foreach (byte b in hashedBytes)
                builder.Append(b.ToString("x2"));

            return builder.ToString() == storedHash;
        }
    }

}
