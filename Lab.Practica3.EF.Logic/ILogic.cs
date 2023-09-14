using System.Collections.Generic;

namespace Lab.Practica3.EF.Logic
{
    public interface ILogic<T>
    {
        List<T> GetAll();

        T GetById(int id);

        bool Delete(int id);

        bool Update(T entity);

        bool Add(T entity);

    }
}
