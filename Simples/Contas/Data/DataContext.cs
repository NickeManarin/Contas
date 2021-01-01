using System;
using System.Collections.Generic;
using Contas.Simples.Model;
using Microsoft.EntityFrameworkCore;

namespace Contas.Simples.Data
{
    public class DataContext : DbContext
    {
        //Migrations:
        //Add-Migration "Version0001" -Project Contas.Simples -StartupProject Contas.Simples
        //Remove-Migration -Project Contas.Simples -StartupProject Contas.Simples

        //Common SQL commands:
        //Open SQL Server Object Explorer, right click the server, click on "New query".
        //Drop Database ContasDatabase;

        public DbSet<Conta> Contas { get; set; }

        
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
                new Conta { Id = 1, Nome = "Computadores", Valor = 3_500.67m, Vencimento = new DateTime(2020, 11, 15), Pagamento = new DateTime(2020, 12, 1)},
                new Conta { Id = 2, Nome = "Alimentos", Valor = 60.10m, Vencimento = new DateTime(2020, 12, 20), Pagamento = new DateTime(2020, 12, 10)},
                new Conta { Id = 3, Nome = "Equipamentos de segurança", Valor = 1_560.90m, Vencimento = new DateTime(2020, 10, 21), Pagamento = new DateTime(2020, 10, 20)},
                new Conta { Id = 4, Nome = "Equipamentos de limpeza", Valor = 234.20m, Vencimento = new DateTime(2020, 11, 7), Pagamento = new DateTime(2020, 11, 7)},
            };
            
            builder.Entity<Conta>().HasData(contas);

            #endregion

            base.OnModelCreating(builder);
        }
    }
}