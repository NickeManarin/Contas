using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contas.Extenso.Domain.Models
{
    public class Conta
    {
        [Key]
        public long Id { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Vencimento { get; set; }

        [Required]
        public DateTime Pagamento { get; set; }

        public int? DiasDeAtraso { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal ValorAjustado { get; set; }
    }
}