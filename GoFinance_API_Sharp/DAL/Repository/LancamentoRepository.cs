using GoFinance_API_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoFinance_API_Sharp.DAL.Repository
{
    public class LancamentoRepository
    {
        public Contexto ctx { get; set; }

        public LancamentoRepository()
        {
            ctx = new Contexto();
        }


        public object GetRangeDatasSintetico(DateTime dtInicial, DateTime dtFinal)
        {
            var query = (from l in ctx.Lancamento
                         where (l.Data >= DbFunctions.TruncateTime(dtInicial) && l.Data <= DbFunctions.TruncateTime(dtFinal))
                         group l by new { l.Descricao } into g
                         select new
                         {
                             Descricao = g.Key.Descricao,
                             Valor = g.Sum(x => x.Valor)
                         }).ToList();

            return query;
        }

        public decimal GetSomaByDescricao(string descricao)
        {
            decimal query = (from l in ctx.Lancamento
                            where l.Descricao == descricao
                            select  l.Valor).Sum();

            return query;
        }

        public IList<Lancamento> GetDescricao(string descricao)
        {
            var query = from l in ctx.Lancamento
                        where l.Descricao == descricao
                        select l;
                         
            return query.ToList();
        }

    }
}