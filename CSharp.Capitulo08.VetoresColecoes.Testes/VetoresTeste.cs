using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp.Capitulo08.VetoresColecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var inteiros = new int[5];
            inteiros[0] = 14;
            inteiros[1] = 4;
            //inteiros[5] = -39; // IndexOutOfRangeException;

            var decimais = new decimal[] { 0.4m, 0.9m, 4, 7.8m };

            string[] nomes = { "Vítor", "Avelino" };

            var chars = new[] { 'a', 'b', 'c' };

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"O tamanho do vetor {nameof(decimais)} é {decimais.Length}.");
        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.4m, 0.9m, 4, 7.8m };

            Array.Resize(ref decimais, 5);

            decimais[4] = 3.1m;
        }

        [TestMethod]
        public void OrdenacaoTeste() // Quicksort
        {
            var decimais = new decimal[] { 0.4m, 0.9m, 4, -7.8m };

            Array.Sort(decimais);

            var primeiro = decimais[0];

            Assert.AreEqual(primeiro, -7.8m);
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            var nome = "Vítor";
            nome += " Avelino";

            Assert.AreEqual(nome[0], 'V');

            // StringBuilder

            foreach (var @char in nome)
            {
                Console.Write(@char);
            }
        }
    }
}
