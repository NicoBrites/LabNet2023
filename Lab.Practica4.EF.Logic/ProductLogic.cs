using Lab.Practica4.EF.Data;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Practica4.EF.Logic
{
    public class ProductLogic : BaseLogic
    {
        public ProductLogic() : base()
        {
        }

        public List<Products> ReturnProductsOutOfStock()
        {
            return context.Products.Where(p => p.UnitsInStock == 0).ToList();
        }
        public List<Products> ReturnProductsInStockAnd3Value()
        {
            return context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3).ToList();
        }
        public List<Products> ReturnProductsOrderByName()
        {
            var query = from p in context.Products
                        orderby p.ProductName ascending
                        select p;

            return query.ToList();
        }
        public List<Products> ReturnProductsOrderByUnitsInStock()
        {
            var query = from p in context.Products
                        orderby p.UnitsInStock descending
                        select p;

            return query.ToList();
        }
        public Products ReturnFirstProductOrNullAndIdEquals789()
        {

            return context.Products.FirstOrDefault(p => p.ProductID == 789);
        }
        public List<string> ReturnDistinctProductCategories()
        {

            var query = from p in context.Products
                        join c in context.Categories
                            on p.CategoryID
                            equals c.CategoryID
                        group p by new { p.CategoryID, c.CategoryName }
                        into productsCategories
                        select productsCategories.Key.CategoryName;
            return query.ToList();
        }

        public Products FirstProductOfList()
        { 
            return context.Products.Take(1).First();
        }
    }
}
