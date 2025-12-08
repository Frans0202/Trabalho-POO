namespace ConexaoBancoDados.Interfaces
{
    internal interface IDao<T>
    {
        void Create(T objeto);
        T GetById(int id);
        void Update(T objeto);
        void Delete(int id);
        List<T> GetAll();
    }
}
