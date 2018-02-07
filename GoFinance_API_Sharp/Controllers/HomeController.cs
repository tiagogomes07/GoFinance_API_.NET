using GoFinance_API_Sharp.DAL;
using GoFinance_API_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoFinance_API_Sharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //var ctx = new Contexto();
            //var r = new Random();
            //var listaDespesas = new List<string>()
            //{
            //    "Agua",
            //    "Luz",
            //    "Telefone",
            //    "Gasolina",
            //    "Gas",
            //    "Aluguel",
            //    "Condominio",
            //    "Lazer"
            //};

            //for (int i = 0; i < 1000; i++)
            //{
            //    var lanc = new Lancamento();
            //    lanc.Data = RandomDayFunc();
            //    lanc.Valor = r.Next(1, 2500);
            //    lanc.TipoDC = 0;
            //    lanc.Descrição = listaDespesas.PickRandom();

            //    ctx.Lancamento.Add(lanc);
            //}

            //ctx.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public DateTime RandomDayFunc()
        {
            DateTime start = new DateTime(2017, 1, 1);
            Random gen = new Random();
            int range = ((TimeSpan)(DateTime.Today - start)).Days;
            return  start.AddDays(gen.Next(range));
        }
    }

    public static class EnumerableExtension
    {
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }
    }


}