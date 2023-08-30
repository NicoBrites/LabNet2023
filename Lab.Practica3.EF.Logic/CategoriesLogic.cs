using Lab.Practica3.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica3.EF.Logic
{
    public class CategoriesLogic : BaseLogic , ILogic<Categories>
    {

        public CategoriesLogic() :base() 
        { 
        }
        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public Categories GetById(int id)
        {
            return (Categories)context.Categories.Find(id);
        }


    }
}
