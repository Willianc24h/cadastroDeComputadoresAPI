using CadastroDeComputadores.models;
using CadastroDeComputadores.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeComputadores.DataContext {
    public class AplicationDbContext: DbContext {


        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options) {

        }

        public DbSet<CadastroModel> Cadastro { get; set; }
        public DbSet<LoginModel> Login { get; set; }


    }
}
