using System;
using System.Linq;
using System.Threading.Tasks;
using Contas.Simples.Data;
using Contas.Simples.Model;
using Contas.Simples.Model.Transient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contas.Simples.Controllers.Services
{
    public class ContaService : IContaService
    {
        private readonly DataContext _context;

        public ContaService(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> GetAll()
        {
            try
            {
                return new OkObjectResult(await _context.Contas.Select(s => new ContaAjustada(s)).ToListAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestResult();
            }
        }

        public async Task<IActionResult> Create(Conta request)
        {
            if (request.Vencimento == DateTime.MinValue)
                return new BadRequestObjectResult("A data de vencimento deve ser uma data válida.");

            if (request.Pagamento == DateTime.MinValue)
                return new BadRequestObjectResult("A data de pagamento deve ser uma data válida.");

            if (request.Valor < 0.01m)
                return new BadRequestObjectResult("O valor da conta a pagar deve ser maior que R$ 0,00.");

            if (await _context.Contas.AnyAsync(a => a.Nome == request.Nome))
                return new BadRequestObjectResult("Já existe uma conta a pagar com o mesmo nome.");

            await using var tra = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.Contas.AddAsync(request);
                await _context.SaveChangesAsync();
                await tra.CommitAsync();

                return new OkResult();
            }
            catch (Exception e)
            {
                await tra.RollbackAsync();
                Console.WriteLine(e);

                return new BadRequestResult();
            }
        }
    }
}