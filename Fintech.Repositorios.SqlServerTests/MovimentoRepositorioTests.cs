using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new MovimentoRepositorio("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Fintech;Integrated Security=True");

        [TestMethod()]
        public void InserirTest()
        {
            var conta = new ContaCorrente(null, 456, "0");
            var movimento = new Movimento(100, Operacao.Deposito, conta);

            repositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarAsyncTest()
        {
            var movimentos = repositorio.SelecionarAsync(0, 456).Result;

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Operacao} - {movimento.Valor}");
            }
        }
    }
}