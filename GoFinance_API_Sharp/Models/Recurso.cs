using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFinance_API_Sharp.Models
{
    [Table("Recurso")]
    public class Recurso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Saldo { get; set; }

        public virtual Login Login { get; set; }
    }
}