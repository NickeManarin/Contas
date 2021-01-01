using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contas.Simples.Controllers;
using Contas.Simples.Controllers.Services;
using Contas.Simples.Data;
using Contas.Simples.Model;
using Contas.Simples.Model.Transient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Contas.Simples.Test
{
    public class Tests
    {
        [Fact]
        public async Task ReturnsList()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ContasDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            var context = new DataContext(optionsBuilder.Options);

            var service = new ContaService(context);
            var sut = new ContasController(new NullLogger<ContasController>(), service);
            var result = await sut.GetAll() as ObjectResult;
            
            Assert.IsType<List<ContaAjustada>>(result.Value);
            Assert.Equal(200, result.StatusCode);
        }
        
        [Fact]
        public async Task FailsToCreateEntry()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabaseName");
            var context = new DataContext(optionsBuilder.Options);

            var service = new ContaService(context);
            var sut = new ContasController(new NullLogger<ContasController>(), service);
            var result = await sut.Create(new Conta
            {
                Nome = "",
                Valor = 0,
                Vencimento = new DateTime(2020, 12, 10),
                Pagamento = new DateTime(2020, 12, 20)
            }) as ObjectResult;

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task CreatesEntry()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabaseName").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            var context = new DataContext(optionsBuilder.Options);

            var service = new ContaService(context);
            var sut = new ContasController(new NullLogger<ContasController>(), service);
            var result = await sut.Create(new Conta
            {
                Nome = "Conta",
                Valor = 20.8m,
                Vencimento = new DateTime(2020, 12, 10),
                Pagamento = new DateTime(2020, 12, 20)
            }) as StatusCodeResult;

            Assert.Equal(200, result.StatusCode);
        }
    }
}