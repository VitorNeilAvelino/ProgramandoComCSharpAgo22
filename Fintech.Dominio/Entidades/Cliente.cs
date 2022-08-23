using System;

namespace Fintech.Dominio.Entidades
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public Endereco EnderecoResidencial { get; set; }
    }
}