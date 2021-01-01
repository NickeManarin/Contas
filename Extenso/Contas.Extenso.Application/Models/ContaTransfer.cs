using System;
using System.ComponentModel.DataAnnotations;

namespace Contas.Extenso.Application.Models
{
    public class ContaTransfer
    {
        [Required, StringLength(50, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Vencimento { get; set; }

        [Required]
        public DateTime Pagamento { get; set; }
    }
}