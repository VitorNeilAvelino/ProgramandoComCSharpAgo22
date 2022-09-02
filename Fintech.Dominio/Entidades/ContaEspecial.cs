namespace Fintech.Dominio.Entidades
{
    public class ContaEspecial : ContaCorrente
    {
        /// <summary>
        /// Construtor sem parâmetros: requisito do Entity Framework.
        /// </summary>
        public ContaEspecial()
        {

        }

        public ContaEspecial(Agencia agencia, int numero, string digitoVerificador, decimal limite) : base(agencia, numero, digitoVerificador)
        {
            Limite = limite;
        }

        public decimal Limite { get; set; }

        // ToDo: OO - polimorfismo por substituição (override).
        public override Movimento EfetuarOperacao(decimal valor, Operacao operacao, decimal limite = 0)
        {
            return base.EfetuarOperacao(valor, operacao, Limite);
        }
    }
}