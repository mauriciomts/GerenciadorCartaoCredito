using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCartoesCredito.Models
{
    public class Cartao
    {
        public int CartaoId { get; set; }
        public string NomeBanco { get; set; }
        public string NumeroCartao { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Limite { get; set; }

        public ICollection<Gasto> Gastos { get; set; }
    }
}
