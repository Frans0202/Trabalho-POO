using System.Collections.Generic;

namespace ConexaoBancoDados.Interfaces
{
    internal interface IDAO<T>
    {
        void Create(T t);
        void Update(T t);
        void Delete(int id);
        List<T> GetAll();
    }
}