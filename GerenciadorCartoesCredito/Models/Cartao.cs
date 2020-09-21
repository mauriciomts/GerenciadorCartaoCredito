using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCartoesCredito.Models
{
    public class Cartao
    {
        public int CartaoId { get; set; }
        public string NomeBanco { get; set; }
        public string NumeroCartao { get; set; }
        public double Limite { get; set; }
        public ICollection<Gasto> Gastos { get; set; }
    }
}
