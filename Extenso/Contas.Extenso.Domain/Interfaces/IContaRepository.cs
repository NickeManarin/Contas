using System.Collections.Generic;
using System.Threading.Tasks;
using Contas.Extenso.Domain.Models;

namespace Contas.Extenso.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task<IEnumerable<Conta>> GetContas();
        Task CreateConta(Conta conta);
    }
}