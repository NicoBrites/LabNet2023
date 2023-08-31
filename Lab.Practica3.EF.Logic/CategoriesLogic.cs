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

        public void Delete(int id)
        {
            var categoryAEliminar = context.Categories.Find(id);

            context.Categories.Remove(categoryAEliminar);

            context.SaveChanges();

        }
        public void Add(Categories category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void Update(Categories category)
        {
            var categoryUpdate = context.Categories.Find(category.CategoryID);

            categoryUpdate.Description = category.Description;

            context.SaveChanges();
        }
        /*
        public static string ForcedMock(string mensaje)
        {
            return mensaje;
        }*/


    }
}
