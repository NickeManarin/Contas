﻿// <auto-generated />
using System;
using Contas.Extenso.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Contas.Extenso.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210101155753_Version0001")]
    partial class Version0001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contas.Extenso.Domain.Models.Conta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DiasDeAtraso")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Pagamento")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorAjustado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Contas");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DiasDeAtraso = 16,
                            Nome = "Computadores",
                            Pagamento = new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 3500.67m,
                            ValorAjustado = 3843.73566m,
                            Vencimento = new DateTime(2020, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2L,
                            DiasDeAtraso = -10,
                            Nome = "Alimentos",
                            Pagamento = new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 60.10m,
                            ValorAjustado = 60.1m,
                            Vencimento = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3L,
                            DiasDeAtraso = -1,
                            Nome = "Equipamentos de segurança",
                            Pagamento = new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 1560.90m,
                            ValorAjustado = 1560.9m,
                            Vencimento = new DateTime(2020, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4L,
                            DiasDeAtraso = 0,
                            Nome = "Equipamentos de limpeza",
                            Pagamento = new DateTime(2020, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 234.20m,
                            ValorAjustado = 234.20m,
                            Vencimento = new DateTime(2020, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Contas.Extenso.Domain.Models.Regra", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dias")
                        .HasColumnType("int");

                    b.Property<decimal>("JurosAoDia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Multa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Superior")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Regras");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Dias = 3,
                            JurosAoDia = 0.001m,
                            Multa = 0.02m,
                            Superior = false
                        },
                        new
                        {
                            Id = 2L,
                            Dias = 3,
                            JurosAoDia = 0.002m,
                            Multa = 0.03m,
                            Superior = true
                        },
                        new
                        {
                            Id = 3L,
                            Dias = 5,
                            JurosAoDia = 0.003m,
                            Multa = 0.05m,
                            Superior = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
