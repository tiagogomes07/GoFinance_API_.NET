using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoFinance_API_Sharp.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TipoLancamento  TipoDC { get; set; }
        public String Descricao { get; set; }
        public Decimal Valor { get; set; }
        public String Historico { get; set; }
    }

    public enum  TipoLancamento
    {
        Debito,
        Credito
    }
}