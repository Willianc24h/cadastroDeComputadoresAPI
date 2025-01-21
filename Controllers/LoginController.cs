using Microsoft.AspNetCore.Mvc;
using CadastroDeComputadores.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeComputadores.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase {
        private static readonly List<User> users = new List<User>
        {
            new User { Email = "user@example.com", Password = "123456" },
            new User { Email = "admin@example.com", Password = "admin123" },
            new User { Email = "tecnologia@central24horas.com.br", Password = "Ss70945358." },
        };

        [HttpPost]
        public IActionResult Login([FromBody] User loginUser) {
            var user = users.FirstOrDefault(u =>
                u.Email == loginUser.Email && u.Password == loginUser.Password);

            if (user == null) {
                return Unauthorized(new { message = "E-mail e/ou senhas inválidas" });
            }

            return Ok(new { token = "fake-jwt-token", message = "Login bem-sucedido!" });
        }
    }
}