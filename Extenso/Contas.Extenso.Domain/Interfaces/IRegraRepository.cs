using System.Collections.Generic;
using System.Threading.Tasks;
using Contas.Extenso.Domain.Models;

namespace Contas.Extenso.Domain.Interfaces
{
    public interface IRegraRepository
    {
        Task<IEnumerable<Regra>> GetRegras();
    }
}