namespace Fintech.Dominio.Interfaces
{
    public interface ICrudRepositorio<T>
    {
        void Inserir(T entidade);
        void Atualizar(T entidade);
        T Selecionar(int id);
        void Excluir(int id);
    }
}