﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeComputadores.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaTipoDeEquipamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Cadastro",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Cadastro");
        }
    }
}
