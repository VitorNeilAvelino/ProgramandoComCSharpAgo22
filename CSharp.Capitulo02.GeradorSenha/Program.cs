using System;

namespace CSharp.Capitulo02.GeradorSenha
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe a quantidade de dígitos da senha (entre 4 e 10 - pares): ");
            
            var quantidadeDigitos = 0;

            while (quantidadeDigitos == 0)
            {
                quantidadeDigitos = ObterQuantidadeDigitos();
            }
            
            var senha = "";
            var randomico = new Random();

            for (int i = 0; i < quantidadeDigitos; i++)
            {
                //var digito = randomico.Next(1, 61);
                var digito = randomico.Next(10);

                senha += digito;
            }

            Console.WriteLine($"Senha: {senha}");
        }

        private static int ObterQuantidadeDigitos()
        {
            int.TryParse(Console.ReadLine(), out int quantidadeDigitos);

            if (quantidadeDigitos < 4 || quantidadeDigitos > 10 || quantidadeDigitos % 2 != 0)
            {
                Console.WriteLine($"O valor {quantidadeDigitos} é inválido de acordo com as regras.");
                quantidadeDigitos = 0;
            }

            return quantidadeDigitos;
        }
    }
}
