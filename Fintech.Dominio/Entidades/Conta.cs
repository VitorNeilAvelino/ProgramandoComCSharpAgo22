using System.Collections.Generic;
using System.Linq;

namespace Fintech.Dominio.Entidades
{
    public abstract class Conta
    {
        public int Numero { get; set; }
        public string DigitoVerificador { get; set; }
        public decimal Saldo 
        {
            get { return TotalDeposito - TotalSaque; }
            private set { } 
        }
        public Agencia Agencia { get; set; }
        public Cliente Cliente { get; set; }
        public List<Movimento> Movimentos { get; set; } = new List<Movimento>();
        public decimal TotalDeposito 
        { 
            get
            {
                return Movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(m => m.Valor);
            }            
        }

        public decimal TotalSaque => Movimentos.Where(m => m.Operacao == Operacao.Saque).Sum(m => m.Valor);

        public virtual Movimento EfetuarOperacao(decimal valor, Operacao operacao, decimal limite = 0)
        {
            Movimento movimento = null; 
            var sucesso = true;

            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo + limite >= valor)
                    {
                        Saldo -= valor; 
                    }
                    else
                    {
                        sucesso = false;
                    }
                    break;
            }

            if (sucesso) 
            {
                movimento = new Movimento(valor, operacao);
                movimento.Conta = this;

                Movimentos.Add(movimento); 
            }

            return movimento;
        }
    }
}