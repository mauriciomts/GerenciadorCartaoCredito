using GerenciadorCartoesCredito.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCartoesCredito.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Gasto> Gastos { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }
    }
}
