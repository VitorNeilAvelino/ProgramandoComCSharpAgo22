using Fintech.Dominio.Entidades;

namespace Fintech.Dominio.Interfaces
{
    public interface IClienteRepositorio
    {
        void Inserir(Cliente cliente);
        void Atualizar(Cliente cliente);
        Cliente Selecionar(int id);
        void Excluir(int id);
    }
}