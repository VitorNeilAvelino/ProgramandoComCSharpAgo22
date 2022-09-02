using System;
using System.Collections.Generic;

namespace Fintech.Dominio.Entidades
{
    // ToDo: OO - abstração (classe).
    public class Cliente
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public List<Conta> Contas { get; set; } = new List<Conta>();
    }
}