﻿// <auto-generated />
using System;
using CadastroDeComputadores.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroDeComputadores.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20241217144311_first-migration")]
    partial class firstmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CadastroDeComputadores.models.CadastroModel", b =>
                {
                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeSaida")
                        .HasColumnType("datetime2");

                    b.Property<string>("NFE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Setor")
                        .HasColumnType("int");

                    b.HasKey("Tag");

                    b.ToTable("Cadastro");
                });
#pragma warning restore 612, 618
        }
    }
}
