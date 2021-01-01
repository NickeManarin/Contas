using System.Threading.Tasks;
using Contas.Simples.Controllers.Services;
using Contas.Simples.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contas.Simples.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContasController : ControllerBase
    {
        private readonly ILogger<ContasController> _logger;
        private readonly IContaService _contaService;

        public ContasController(ILogger<ContasController> logger, IContaService contaService)
        {
            _logger = logger;
            _contaService = contaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await _contaService.GetAll();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Conta request)
        {
            return await _contaService.Create(request);
        }
    }
}