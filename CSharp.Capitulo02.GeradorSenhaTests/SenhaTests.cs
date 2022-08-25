using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp.Capitulo02.GeradorSenha.Tests
{
    [TestClass()]
    public class SenhaTests
    {
        //[TestMethod()]
        //public void GerarSenhaTest()
        //{
        //    var senha = new Senha();
        //    senha.Tamanho = 8;
        //    var valorSenha = senha.Gerar();

        //    Assert.AreEqual(valorSenha.Length, 8);

        //    Console.WriteLine(valorSenha);
        //}

        [TestMethod]
        public void ConstrutorPadraoDeveRetornarSenhaMinima()
        {
            var senha = new Senha();

            Assert.AreEqual(senha.Valor.Length, Senha.TamanhoMinimo);

            Console.WriteLine(senha.Valor);
        }

        [TestMethod]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(10)]
        public void ConstrutorParametrizadoDeveRetornarSenhaEspecifica(int tamanho)
        {
            var senha = new Senha(tamanho);

            Console.WriteLine(senha.Valor);
        }
    }
}