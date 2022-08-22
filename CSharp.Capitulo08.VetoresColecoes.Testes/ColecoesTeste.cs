using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo08.VetoresColecoes.Testes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTeste()
        {
            var inteiros = new List<int>() { 1, 9, 3, 1, 0 -85 };
            inteiros.Add(25);
            inteiros.Add(-58);

            inteiros[0] = 34;
            //inteiros[100] = -2;

            var maisInteiros = new List<int> { 16, 38, -7, 8 };

            inteiros.AddRange(maisInteiros);

            inteiros.Insert(2, 42);

            inteiros.Remove(1);

            inteiros.RemoveAt(5);

            inteiros.Sort();

            var primeiro = inteiros[0];
            primeiro = inteiros.First();

            var ultimo = inteiros[inteiros.Count - 1];
            ultimo = inteiros.Last();

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}: {inteiro}");
            }
        }

        [TestMethod]
        public void DictionaryTeste()
        {
            // hash table

            var feriados = new Dictionary<DateTime, string>();
            feriados.Add(new DateTime(2022, 9, 7), "Independência");
            feriados.Add(new DateTime(2022, 11, 15), "República");
            //feriados.Add(new DateTime(2022, 11, 15), "Natal");

            //var republica = feriados[new DateTime(2022, 11, 15)];
            var republica = feriados[Convert.ToDateTime("15/11/2022")];

            foreach (var feriado in feriados)
            {
                Console.WriteLine($"{feriado.Key:d}: {feriado.Value}");
            }

            Console.WriteLine(feriados.ContainsKey(new DateTime(2022, 9, 7)));
            Console.WriteLine(feriados.ContainsValue("República"));
        }
    }
}