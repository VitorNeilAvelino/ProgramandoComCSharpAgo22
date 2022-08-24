using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha
{
    public class Senha
    {
        public int Tamanho { get; set; }
        public string Valor { get; set; }

        public string Gerar()
        {
            var senha = "";
            var randomico = new Random();

            for (int i = 0; i < Tamanho; i++)
            {
                var digito = randomico.Next(10);
                senha += digito;
            }

            return senha;
        }
    }
}
