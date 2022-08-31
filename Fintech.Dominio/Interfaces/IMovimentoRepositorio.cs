using Fintech.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fintech.Dominio.Interfaces
{
    public interface IMovimentoRepositorio
    {
        void Inserir(Movimento movimento);
        Task<List<Movimento>> SelecionarAsync(int numeroAgencia, int numeroConta);
    }
}