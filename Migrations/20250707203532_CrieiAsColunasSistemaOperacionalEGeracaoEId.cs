using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeComputadores.Migrations
{
    /// <inheritdoc />
    public partial class CrieiAsColunasSistemaOperacionalEGeracaoEId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cadastro",
                table: "Cadastro");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Cadastro",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cadastro",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Geracao",
                table: "Cadastro",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SistemaOperacional",
                table: "Cadastro",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cadastro",
                table: "Cadastro",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cadastro",
                table: "Cadastro");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cadastro");

            migrationBuilder.DropColumn(
                name: "Geracao",
                table: "Cadastro");

            migrationBuilder.DropColumn(
                name: "SistemaOperacional",
                table: "Cadastro");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Cadastro",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cadastro",
                table: "Cadastro",
                column: "Tag");
        }
    }
}
