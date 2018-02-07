using GoFinance_API_Sharp.DAL;
using GoFinance_API_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GoFinance_API_Sharp.Controllers
{
    public class LancamentoController : ApiController
    {

        public Contexto ctx = new Contexto();

 
        [Route("Lancamento/GetLancamentos")]
        [HttpGet]
        public IEnumerable<Lancamento> GetLancamentos()
        {
            return (ctx.Lancamento.ToList());
        }

        
        [Route("Lancamento/GetRangeDatasAnalitico")]
        [HttpPost]
        public IEnumerable<Lancamento> GetRangeDatasAnalitico(DateTime dtInicial, DateTime dtFinal)
        {

            return (ctx.Lancamento.Where( x=> x.Data >= DbFunctions.TruncateTime(dtInicial) && x.Data <= DbFunctions.TruncateTime(dtFinal) ).ToList());
        }


       
        [Route("Lancamento/GetRangeDatasSintetico")]
        [HttpPost]
        public  object GetRangeDatasSintetico(DateTime dtInicial, DateTime dtFinal)
        {

            var query = (from l in ctx.Lancamento
                         where l.Data >= DbFunctions.TruncateTime(dtInicial) && l.Data <= DbFunctions.TruncateTime(dtFinal)
                         group l by new { l.Descricao} into g
                         select new
                         {   Descricao = g.Key.Descricao,
                             Valor = g.Sum(x => x.Valor)
                         }).ToList();


            //ALTERNATIVA DE QUERY LINQ
            //var query2 = ctx.Lancamento
            //             .Where(
            //             x => x.Data >= DbFunctions.TruncateTime(dtInicial)
            //             && x.Data <= DbFunctions.TruncateTime(dtFinal)
            //             )
            //             .GroupBy(x => new { Descrição = x.Descrição })
            //             .Select(x => new { Descricao = x.Key.Descrição, Valor = x.Sum(s => s.Valor) })
            //             .ToList();

            return query;
        }

        [Route("api/Lancamento/create")]
        [HttpPost]
        public object create(Lancamento lancamento)
        {
            //ctx.Lancamento.Add(lancamento);
            //ctx.SaveChanges();

            return new { Status = "ok" };
        }

        [Route("Lancamento/delete")]
        [HttpPost]
        public object delete(Lancamento lancamento)
        {
            Lancamento lanc = ctx.Lancamento.Where(x => x.Id == lancamento.Id).FirstOrDefault();
            if (lanc != null)
            {
                try
                {
                    ctx.Lancamento.Remove(lanc);
                    ctx.SaveChanges();
                    return new { Status = "ok" };
                }
                catch (Exception)
                {
                    return new { Status = "Error" };
                    //throw;
                }
            }
            return new { Status = "Error" };
        }

        /*ROTEAMENTO/////////////
          routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
         */

        /*AJAX Jquery/////////////
         var myData = { 'ini':'1', 'fim':'2' }
        $.ajax({
            type: 'GET',
            async: true,
            dataType: "json",
            url: "http://localhost:56071/api/lancamento/GetRangeDatasAnalitico",
            data: myData,
            success: function (data) {
                console.log("Response Data ↓");
                console.log(data);
            },
            error: function (err) {
                console.log(err);
            }
        });         
         */




    }
}
