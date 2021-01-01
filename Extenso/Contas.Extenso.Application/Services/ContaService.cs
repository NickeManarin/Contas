using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contas.Extenso.Application.Interfaces;
using Contas.Extenso.Application.Models;
using Contas.Extenso.Domain.Interfaces;
using Contas.Extenso.Domain.Models;

namespace Contas.Extenso.Application.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IRegraRepository _regraRepository;

        public ContaService(IContaRepository contaRepository, IRegraRepository regraRepository)
        {
            _contaRepository = contaRepository;
            _regraRepository = regraRepository;
        }
        
        
        public async Task<IEnumerable<Conta>> GetContas()
        {
            return await _contaRepository.GetContas();
        }

        public async Task<(int status, string description)> CreateConta(ContaTransfer transfer)
        {
            //Validate data.
            if (transfer.Vencimento == DateTime.MinValue)
                return (400, "A data de vencimento deve ser uma data válida.");

            if (transfer.Pagamento == DateTime.MinValue)
                return (400, "A data de pagamento deve ser uma data válida.");

            if (transfer.Valor < 0.01m)
                return (400, "O valor da conta a pagar deve ser maior que R$ 0,00.");

            if ((await _contaRepository.GetContas()).Any(a => a.Nome == transfer.Nome))
                return (400, "Já existe uma conta a pagar com o mesmo nome.");
            
            var conta = new Conta
            {
                Nome = transfer.Nome,
                Valor = transfer.Valor,
                Vencimento = transfer.Vencimento,
                Pagamento = transfer.Pagamento,
                DiasDeAtraso = (int)(transfer.Pagamento - transfer.Vencimento).TotalDays
            };

            //Calculate ruleset.
            var regras = await _regraRepository.GetRegras();
            var regra = regras.OrderBy(o => o.Dias).ThenBy(t => !t.Superior).LastOrDefault(l => l.Superior ? (conta.DiasDeAtraso > l.Dias) : conta.DiasDeAtraso <= l.Dias);
            
            conta.ValorAjustado = regra == null ? conta.Valor : conta.Valor + (conta.Valor * regra.Multa) + (conta.Valor * regra.JurosAoDia * (conta.DiasDeAtraso ?? 0));
            
            await _contaRepository.CreateConta(conta);
            return (200, "Ok");
        }
    }
}