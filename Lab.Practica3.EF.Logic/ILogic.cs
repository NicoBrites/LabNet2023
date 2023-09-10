using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
