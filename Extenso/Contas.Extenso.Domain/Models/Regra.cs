using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contas.Extenso.Domain.Models
{
    public class Regra
    {
        public long Id { get; set; }

        [Required]
        public bool Superior { get; set; }

        [Required]
        public int Dias { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Multa { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal JurosAoDia { get; set; }
    }
}