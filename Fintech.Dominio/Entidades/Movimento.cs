﻿using System;

namespace Fintech.Dominio.Entidades
{
    public class Movimento
    {
        /// <summary>
        /// Construtor sem parâmetros - requisito do Dapper.
        /// </summary>
        public Movimento()
        {

        }

        public Movimento(decimal valor, Operacao operacao)
        {
            Valor = valor;
            Operacao = operacao;
        }

        public Movimento(decimal valor, Operacao operacao, Conta conta) : this(valor, operacao)
        {
            Conta = conta;
        }

        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime Data { get; set; } = DateTime.Now;
        public Operacao Operacao { get; set; }
        public decimal Valor { get; set; }
        public Conta Conta { get; set; }
    }
}