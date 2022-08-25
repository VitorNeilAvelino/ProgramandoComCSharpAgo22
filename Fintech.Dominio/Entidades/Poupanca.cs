namespace Fintech.Dominio.Entidades
{
    public class Poupanca : Conta
    {
        public Poupanca(Agencia agencia, int numero, string digitoVerificador)
        {
            Agencia = agencia;
            Numero = numero;
            DigitoVerificador = digitoVerificador;
        }

        public decimal TaxaRendimento { get; set; }
    }
}