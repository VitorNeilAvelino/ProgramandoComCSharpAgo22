using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Dominio.Entidades
{
    class ContaCorrente
    {
        public int Numero { get; set; }
        public string DigitoVerificador { get; set; }
        public decimal Saldo { get; set; }
        public Agencia Agencia { get; set; }
        public Cliente Cliente { get; set; }

        public void EfetuarOperacao(decimal valor, Operacao operacao)
        {
            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    Saldo -= valor;
                    break;
            }
        }
    }
}