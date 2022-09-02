﻿namespace Fintech.Dominio.Entidades
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public TipoEndereco Tipo { get; set; }
    }
}