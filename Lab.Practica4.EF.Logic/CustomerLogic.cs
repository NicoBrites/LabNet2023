using Lab.Practica4.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica4.EF.Logic
{
    public class CustomerLogic : BaseLogic
    {
        public CustomerLogic() : base()
        {
        }

        public Customers ReturnObject()
        {
            var query = from c in context.Customers
                        select c;

            return query.First();
        }

        public List<Customers> ReturnCustomersFromWA()
        {
            return context.Customers.Where(c => c.Region == "WA").ToList();
        }

        public List<Customers> ReturnCustomersNames()
        {

            var query = from c in context.Customers
                        select c;

            return query.ToList();
        }

        public List<Customers> ReturnCustomersFromWaAndOrderDate()
        {
            var query = from c in context.Customers
                        join o in context.Orders
                        on c.CustomerID equals o.CustomerID
                        where c.Region == "WA" && o.OrderDate > new DateTime(1997, 1, 1)
                        select c;

            return query.ToList();
        }

        public List<Customers> ReturnCustomersFromWAOnly3()
        {
            return context.Customers.Where(c => c.Region == "WA").Take(3).ToList();
        }

        
        public IEnumerable<dynamic> ReturnCustomersWithOrders()
        {
            var query = from customers in context.Customers
                        join orders in context.Orders
                        on customers.CustomerID
                            equals orders.CustomerID
                        into count
                        select new
                        {
                            ID = customers.CustomerID,
                            ContactName = customers.ContactName,
                            OrdersCuantity = count.Count()
                        };
            return query.ToList();
        }
   
        
    }
}
