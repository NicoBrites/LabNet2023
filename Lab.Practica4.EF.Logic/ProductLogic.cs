using Lab.Practica4.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Products ReturnFirstProductNotNullAndIdEquals789()
        {
            //Method Sintax
            return context.Products.FirstOrDefault(p => p.ProductID == 789);
        }


    }
}
