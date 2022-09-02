namespace Fintech.Dominio.Entidades
{  
    // ToDo: OO - herança (:).
    public class ContaCorrente : Conta
    {
        /// <summary>
        /// Construtor sem parâmetros: requisito do Entity Framework.
        /// </summary>
        public ContaCorrente()
        {

        }

        public ContaCorrente(Agencia agencia, int numero, string digitoVerificador)
        {
            Agencia = agencia;
            Numero = numero;
            DigitoVerificador = digitoVerificador;
        }

        public bool EmissaoChequeHabilitada { get; set; }
    }
}