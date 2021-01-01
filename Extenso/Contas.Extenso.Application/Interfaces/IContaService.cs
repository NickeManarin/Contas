using System.Collections.Generic;
using System.Threading.Tasks;
using Contas.Extenso.Application.Models;
using Contas.Extenso.Domain.Models;

namespace Contas.Extenso.Application.Interfaces
{
    public interface IContaService
    {
        Task<IEnumerable<Conta>> GetContas();
        Task<(int status, string description)> CreateConta(ContaTransfer transfer);
    }
}