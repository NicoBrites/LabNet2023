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

        public List<Customers> ReturnObject()
        {

            return context.Customers.ToList();
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
                        where c.Region == "WA" && o.OrderDate > DateTime.Parse("1/1/1997")
                        select c;

            return query.ToList();
        }

        public List<Customers> ReturnCustomersFromWAOnly3()
        {
            return context.Customers.Where(c => c.Region == "WA").Take(3).ToList();
        }


    }
}
