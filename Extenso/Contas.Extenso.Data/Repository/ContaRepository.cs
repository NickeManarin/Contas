using System.Collections.Generic;
using System.Threading.Tasks;
using Contas.Extenso.Data.Context;
using Contas.Extenso.Domain.Interfaces;
using Contas.Extenso.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contas.Extenso.Data.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly DataContext _context;

        public ContaRepository(DataContext context)
        {
            _context = context;
        }
        
        
        public async Task<IEnumerable<Conta>> GetContas()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task CreateConta(Conta conta)
        {
            await _context.Contas.AddAsync(conta);
            await _context.SaveChangesAsync();
        }
    }
}