using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Fintech.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class FintechDbContextTests
    {
        private readonly FintechDbContext dbContext;
        private readonly DbContextOptions<FintechDbContext> dbContextOptions;

        public FintechDbContextTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<FintechDbContext>()
                .UseSqlServer(new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FintechEF;Integrated Security=True"))
                .Options;

            dbContext = new FintechDbContext(dbContextOptions);
        }

        [TestMethod()]
        public void InserirClienteTeste()
        {
            var endereco = new Endereco();
            endereco.Cep = "12345000";
            endereco.Cidade = "São Paulo";
            endereco.Logradouro = "R. Tal";
            endereco.Numero = "47";
            endereco.Tipo = TipoEndereco.Residencial;

            var banco = new Banco { Numero = 47, Nome = "Banco Um" };
            var agencia = new Agencia { Banco = banco, Numero = 248, DigitoVerificador = 8 };
            var conta = new ContaEspecial(agencia, 2049, "9", 4000);

            var cliente = new Cliente();
            cliente.Cpf = "12345678900";
            cliente.DataNascimento = Convert.ToDateTime("01/01/00");
            cliente.Nome = "Vítor";
            cliente.Sexo = Sexo.Masculino;

            cliente.Enderecos.Add(endereco);
            cliente.Contas.Add(conta);

            dbContext.Clientes.Add(cliente);
            dbContext.SaveChanges();
        }
    }
}