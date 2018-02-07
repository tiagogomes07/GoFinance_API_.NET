using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoFinance_API_Sharp.Models
{
    [Table("Login")]
    public class Login
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string SobreNome { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}