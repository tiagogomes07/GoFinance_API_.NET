using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoFinance_API_Sharp.Models
{
    [Table("Conta")]
    public class Conta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Login Login { get; set; }

    }
}