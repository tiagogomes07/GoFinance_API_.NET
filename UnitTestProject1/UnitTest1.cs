using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoFinance_API_Sharp.DAL.Repository;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestandoConsultaLancamento()
        {
            LancamentoRepository lanc = new LancamentoRepository();      
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var good = lanc.GetRangeDatasSintetico(new DateTime(2017, 01, 01), new DateTime(2017, 01, 31));
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            
            Console.WriteLine("Tempo decorrido");
            Console.WriteLine(elapsedMs);
        }


        [TestMethod]
        public void ConsultarGastos()
        {
            LancamentoRepository lanc = new LancamentoRepository();
            var watch = System.Diagnostics.Stopwatch.StartNew();


            var Luz = lanc.GetDescricao("Luz").Select( x=> x.Valor).Sum();          
            var Telefone = lanc.GetDescricao("Telefone").Select(x => x.Valor).Sum();
            var Gas = lanc.GetDescricao("Gas").Select(x => x.Valor).Sum();

            var soma = Luz + Telefone + Gas;

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Tempo decorrido");
            Console.WriteLine(elapsedMs);
        }


    }
}
