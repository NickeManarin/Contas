using System;
using System.Collections.Generic;
using Contas.Extenso.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contas.Extenso.Data.Context
{
    public class DataContext : DbContext
    {
        //Migrations:
        //Add-Migration "Version0001" -Context DataContext -verbose -Project Contas.Extenso.Data
        //Remove-Migration -Context DataContext -verbose -Project Contas.Extenso.Data

        //Common SQL commands:
        //Open SQL Server Object Explorer, right click the server, click on "New query".
        //Drop Database ContasExtensoDatabase;

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Regra> Regras { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
#if DEBUG
            options.EnableSensitiveDataLogging();
#endif

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Seed data

            var contas = new List<Conta>
            {
                new Conta { Id = 1, Nome = "Computadores", Valor = 3_500.67m, Vencimento = new DateTime(2020, 11, 15), Pagamento = new DateTime(2020, 12, 1), DiasDeAtraso = 16, ValorAjustado = 3_843.73566m },
                new Conta { Id = 2, Nome = "Alimentos", Valor = 60.10m, Vencimento = new DateTime(2020, 12, 20), Pagamento = new DateTime(2020, 12, 10), DiasDeAtraso = -10, ValorAjustado = 60.1m },
                new Conta { Id = 3, Nome = "Equipamentos de segurança", Valor = 1_560.90m, Vencimento = new DateTime(2020, 10, 21), Pagamento = new DateTime(2020, 10, 20), DiasDeAtraso = -1, ValorAjustado = 1_560.9m },
                new Conta { Id = 4, Nome = "Equipamentos de limpeza", Valor = 234.20m, Vencimento = new DateTime(2020, 11, 7), Pagamento = new DateTime(2020, 11, 7), DiasDeAtraso = 0, ValorAjustado = 234.20m }
            };

            builder.Entity<Conta>().HasData(contas);

            var regras = new List<Regra>
            {
                new Regra { Id = 1, Superior = false, Dias = 3, Multa = 0.02m, JurosAoDia = 0.001m },
                new Regra { Id = 2, Superior = true, Dias = 3, Multa = 0.03m, JurosAoDia = 0.002m },
                new Regra { Id = 3, Superior = true, Dias = 5, Multa = 0.05m, JurosAoDia = 0.003m }
            };

            builder.Entity<Regra>().HasData(regras);

            #endregion

            base.OnModelCreating(builder);
        }
    }
}