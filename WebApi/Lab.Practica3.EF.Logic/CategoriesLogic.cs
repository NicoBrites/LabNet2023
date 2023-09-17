using Lab.Practica3.EF.Data;
using System.Collections.Generic;
using System.Linq;

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

        public bool Delete(int id)
        {
            var categoryAEliminar = context.Categories.Find(id);

            context.Entry(categoryAEliminar).Reference(c => c.Products).Load();
            categoryAEliminar.Products = null;

            context.Categories.Remove(categoryAEliminar);

            return context.SaveChanges() >0;

        }
        public bool Add(Categories category)
        {
            context.Categories.Add(category);
            return context.SaveChanges() > 0;
        }

        public bool Update(Categories category)
        {
            var categoryUpdate = context.Categories.Find(category.CategoryID);

            categoryUpdate.Description = category.Description;

            return context.SaveChanges() > 0;
        }
    }
}
