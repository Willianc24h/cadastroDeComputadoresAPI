using Microsoft.AspNetCore.Mvc;
using CadastroDeComputadores.Models;
using CadastroDeComputadores.DataContext;
using CadastroDeComputadores.Service;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly TokenService _tokenService;
    private readonly AplicationDbContext _context;

    public AuthController(TokenService tokenService, AplicationDbContext context) {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginModel model) {
        if (_context.Login.Any(u => u.Email == model.Email))
            return BadRequest(new { message = "E-mail já está em uso." });

        // Converte a senha para hash antes de salvar
        model.Password = HashPassword(model.Password);

        _context.Login.Add(model);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Usuário cadastrado com sucesso!" });
    }

    // Função para gerar o hash corretamente (hexadecimal)
    private string HashPassword(string password) {
        using (SHA256 sha256 = SHA256.Create()) {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            foreach (byte b in hashedBytes)
                builder.Append(b.ToString("x2"));

            return builder.ToString(); // Retorna o hash hexadecimal
        }
    }
}
