using System;

namespace CSharp.Capitulo01.ValeTransporte
{
    class Program
    {
        static void Main(string[] args)
        {
            Inicio:
            
            Console.Write("Funcionário: ");
            var nome = Console.ReadLine();

            Console.Write("Salário: ");
            var salario = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Gasto com transporte: ");
            var gastoComTransporte = Convert.ToDecimal(Console.ReadLine());

            var descontoMaximo = salario * 6 / 100;

            var descontoVT = gastoComTransporte > descontoMaximo ? descontoMaximo : gastoComTransporte;

            var resultado = $"\nFuncionário: {nome}\n" +
                $"Salário: {salario:c}\n" +
                $"Desconto VT: {descontoVT:C}";

            Console.WriteLine(resultado);

            Console.WriteLine("\nPressione Enter para novo cálculo ou Esc para sair.");

            var comando = Console.ReadKey();

            if (comando.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            Console.Clear();

            goto Inicio;
        }
    }
}