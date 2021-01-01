using System.Threading.Tasks;
using Contas.Simples.Model;
using Microsoft.AspNetCore.Mvc;

namespace Contas.Simples.Controllers.Services
{
    public interface IContaService
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> Create(Conta request);
    }
}