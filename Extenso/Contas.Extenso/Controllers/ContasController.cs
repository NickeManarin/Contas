using System.Threading.Tasks;
using Contas.Extenso.Application.Interfaces;
using Contas.Extenso.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contas.Extenso.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContasController : ControllerBase
    {
        private readonly IContaService _contaService;
        private readonly ILogger<ContasController> _logger;

        public ContasController(IContaService contaService, ILogger<ContasController> logger)
        {
            _contaService = contaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contaService.GetContas());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ContaTransfer request)
        {
            var (status, description) = await _contaService.CreateConta(request);
            
            return StatusCode(status, new { Description = description });
        }
    }
}