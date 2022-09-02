using Fintech.Dominio.Entidades;
using Fintech.Repositorios.SqlServer.EF.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Repositorios.SqlServer.EF
{
    public class FintechDbContext : DbContext
    {
        public FintechDbContext(DbContextOptions<FintechDbContext> opcoes) : base(opcoes)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
        public DbSet<ContaEspecial> ContasEspeciais { get; set; }
        public DbSet<Poupanca> Poupancas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
