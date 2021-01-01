using System.Collections.Generic;
using System.Threading.Tasks;
using Contas.Extenso.Data.Context;
using Contas.Extenso.Domain.Interfaces;
using Contas.Extenso.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contas.Extenso.Data.Repository
{
    public class RegraRepository : IRegraRepository
    {
        private readonly DataContext _context;

        public RegraRepository(DataContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Regra>> GetRegras()
        {
            return await _context.Regras.ToListAsync();
        }
    }
}