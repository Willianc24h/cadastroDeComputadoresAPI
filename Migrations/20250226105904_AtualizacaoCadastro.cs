using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeComputadores.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoCadastro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeSaida",
                table: "Cadastro",
                newName: "dataDeSaida");

            migrationBuilder.RenameColumn(
                name: "DataDeEntrada",
                table: "Cadastro",
                newName: "dataDeEntrada");

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Cadastro",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Cadastro");

            migrationBuilder.RenameColumn(
                name: "dataDeSaida",
                table: "Cadastro",
                newName: "DataDeSaida");

            migrationBuilder.RenameColumn(
                name: "dataDeEntrada",
                table: "Cadastro",
                newName: "DataDeEntrada");
        }
    }
}
