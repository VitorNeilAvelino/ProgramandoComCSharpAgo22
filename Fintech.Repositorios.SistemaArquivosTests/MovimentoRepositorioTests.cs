using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            var conta = new ContaCorrente(new Agencia { Numero = 123 }, 456, "X");

            var movimento = new Movimento(100, Operacao.Deposito);
            movimento.Conta = conta;

            var repositorio = new MovimentoRepositorio();

            repositorio.Inserir(movimento);
        }
    }
}