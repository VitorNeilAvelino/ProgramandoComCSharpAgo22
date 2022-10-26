using Fintech.Repositorios.SistemaArquivos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Dominio.Entidades;
using System;
using System.Linq;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new MovimentoRepositorio("Dados\\Movimento.txt");

        [TestMethod()]
        public void InserirTest()
        {
            var conta = new ContaCorrente(new Agencia { Numero = 123 }, 456, "X");

            var movimento = new Movimento(50, Operacao.Deposito);
            movimento.Conta = conta;

            repositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = repositorio.Selecionar(123, 456);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Operacao} - {movimento.Valor:c}");
            }
        }

        [TestMethod]
        public void DelegateActionTeste()
        {
            var movimentos = repositorio.Selecionar(123, 456);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Valor}");
            }

            Action<Movimento> writeLine = m => Console.WriteLine($"{m.Data} - {m.Valor}");

            movimentos.ForEach(EscreverMovimento);
            movimentos.ForEach(writeLine);
            movimentos.ForEach(m => Console.WriteLine($"{m.Data} - {m.Valor}"));
        }

        private void EscreverMovimento(Movimento movimento)
        {
            Console.WriteLine($"{movimento.Data} - {movimento.Valor}");
        }

        [TestMethod]
        public void DelegatePredicateTeste()
        {
            var movimentos = repositorio.Selecionar(123, 456);

            Predicate<Movimento> obterDepositos = m => m.Operacao == Operacao.Deposito;

            var depositos = movimentos.FindAll(EncontrarMovimentoDeposito);
            depositos = movimentos.FindAll(obterDepositos);
            depositos = movimentos.FindAll(m => m.Operacao == Operacao.Deposito);

            depositos.ForEach(d => Console.WriteLine($"{d.Operacao} - {d.Valor}"));
        }

        private bool EncontrarMovimentoDeposito(Movimento m)
        {
            return m.Operacao == Operacao.Deposito;
        }

        [TestMethod]
        public void DelegateFuncTeste()
        {
            var movimentos = repositorio.Selecionar(123, 456);

            Func<Movimento, decimal> obterCampoValor = m => m.Valor;

            var totalDepositos = movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(RetornarCampoSoma);
            totalDepositos = movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(obterCampoValor);
            totalDepositos = movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(m => m.Valor);

            Console.WriteLine(totalDepositos);
        }

        private decimal RetornarCampoSoma(Movimento m)
        {
            return m.Valor;
        }

        [TestMethod]
        public void OrderByTeste()
        {
            var movimentos = repositorio.Selecionar(123, 456)
                //.OrderByDescending(m => m.Operacao)
                .OrderBy(m => m.Operacao)
                .ThenByDescending(m => m.Data)
                .ThenBy(m => m.Valor);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Operacao} - {movimento.Data} - {movimento.Valor:c}");
            }
        }

        [TestMethod]
        public void CountTeste()
        {
            var quantidadeDepositos = repositorio.Selecionar(123, 456).Count(m => m.Operacao == Operacao.Deposito);

            Assert.IsTrue(quantidadeDepositos == 2);
        }

        [TestMethod]
        public void LikeTeste()
        {
            var movimentos = repositorio.Selecionar(123, 456)
                .Where(m => m.Data.ToString().Contains("26/08/2022"));

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Operacao} - {movimento.Data} - {movimento.Valor:c}");
            }
        }

        [TestMethod]
        public void MinTeste()
        {
            var valorMinimoDeposito = repositorio.Selecionar(123, 456)
                .Where(m => m.Operacao == Operacao.Deposito)
                .Min(m => m.Valor);

            //var valorMaximo = repositorio.Selecionar(123, 456).Max(m => m.Valor);
            //var valorMedio = repositorio.Selecionar(123, 456).Average(m => m.Valor);

            Assert.IsTrue(valorMinimoDeposito == 50);
        }

        [TestMethod]
        [DataRow(1, 2)]
        [DataRow(2, 2)]
        //[DataRow(3, 1)]
        public void SkipTakeTeste(int numeroPagina, int quantidadePorPagina)
        {
            var movimentos = repositorio.Selecionar(123, 456)
                .Skip((numeroPagina - 1) * quantidadePorPagina)
                .Take(quantidadePorPagina)
                .ToList();

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Operacao} - {movimento.Data} - {movimento.Valor:c}");
            }
        }

        [TestMethod]
        public void GroupByTeste()
        {
            var agrupamento = repositorio.Selecionar(123, 456)
                .GroupBy(m => m.Operacao)
                .Select(g => new { Operacao = g.Key, Total = g.Sum(m => m.Valor) });

            foreach (var item in agrupamento)
            {
                Console.WriteLine($"{item.Operacao}: {item.Total}");
            }
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var movimento = repositorio.Selecionar(123, 456).First();

            var conta = new ContaCorrente(new Agencia { Numero = 123 }, 456, "X");

            movimento.Valor = 18.11m;
            movimento.Conta = conta;

            repositorio.Atualizar(movimento);
        }
    }
}