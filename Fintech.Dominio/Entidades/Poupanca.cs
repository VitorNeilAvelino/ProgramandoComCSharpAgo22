namespace Fintech.Dominio.Entidades
{
    public class Poupanca : Conta
    {
        /// <summary>
        /// Construtor sem parâmetros: requisito do Entity Framework.
        /// </summary>
        public Poupanca()
        {

        }

        public Poupanca(Agencia agencia, int numero, string digitoVerificador)
        {
            Agencia = agencia;
            Numero = numero;
            DigitoVerificador = digitoVerificador;
        }

        public decimal TaxaRendimento { get; set; }
    }
}