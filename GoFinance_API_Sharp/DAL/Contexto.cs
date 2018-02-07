using GoFinance_API_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoFinance_API_Sharp.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Lancamento> Lancamento { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Recurso> Recurso { get; set; }
        public DbSet<Login> Login { get; set; }

        public Contexto() : base("GoFinanceDB")
        {

        }

    }
}