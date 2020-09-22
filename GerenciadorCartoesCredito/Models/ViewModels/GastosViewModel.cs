using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCartoesCredito.Models.ViewModels
{
    public class GastosViewModel
    {
        public int CartaoId { get; set; }
        public string NumeroCartao { get; set; }
        public List<Gasto> ListaGastos  { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PorcentagemGasta { get; set; }
    }
}
