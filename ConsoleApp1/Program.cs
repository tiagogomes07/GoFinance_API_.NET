using GoFinance_API_Sharp.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // semThread();
            // ExemplosAcessandoBanco();

            semThreadQueryOtimizadas();

        }

        public static void ExemplosAcessandoBanco()
        { 
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //1- Sem Thread
            //semThread();

            //2- usando métodos assincronos
            //var t1 = ValorPorDescricaoAsync("Luz");
            //var t2 = ValorPorDescricaoAsync("Telefone");
            //var t3 = ValorPorDescricaoAsync("Gas");

            //3 - usando task
            //var t1 = Task<decimal>.Run(() => ValorPorDescricao("Luz"));
            //var t2 = Task<decimal>.Run(() => ValorPorDescricao("Telefone"));
            //var t3 = Task<decimal>.Run(() => ValorPorDescricao("Gas")); ;

            //Console.WriteLine(t1.Result + t2.Result + t3.Result);
            watch.Stop();
            
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine(elapsedMs);
            Console.ReadKey();
        }

        public static decimal ValorPorDescricao(string descricao)
        {
            LancamentoRepository lanc = new LancamentoRepository();
            return lanc.GetDescricao(descricao).Select(x => x.Valor).Sum();
        }

        public static void semThread()
        {
            LancamentoRepository lanc = new LancamentoRepository();
            var watch = System.Diagnostics.Stopwatch.StartNew();


            var Luz = lanc.GetDescricao("Luz").Select(x => x.Valor).Sum();
            var Telefone = lanc.GetDescricao("Telefone").Select(x => x.Valor).Sum();
            var Gas = lanc.GetDescricao("Gas").Select(x => x.Valor).Sum();

            var soma = Luz + Telefone + Gas;

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Tempo decorrido");
            Console.WriteLine(elapsedMs);

            Console.ReadKey();

        }

        public static void semThreadQueryOtimizadas()
        {
            LancamentoRepository lanc = new LancamentoRepository();
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var Luz =       lanc.GetSomaByDescricao("Luz");
            var Telefone =  lanc.GetSomaByDescricao("Telefone");
            var Gas =       lanc.GetSomaByDescricao("Gas");

            var soma = Luz + Telefone + Gas;

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Tempo decorrido");
            Console.WriteLine(elapsedMs);

            Console.ReadKey();
        }


        public async static Task<decimal> ValorPorDescricaoAsync(string descricao) {

           return  ValorPorDescricao(descricao);
        }


    }
}
