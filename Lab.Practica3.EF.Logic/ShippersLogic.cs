using Lab.Practica3.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica3.EF.Logic
{
    public class ShippersLogic : BaseLogic , ILogic<Shippers>
    {
        public ShippersLogic() : base() { }

        public List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }

        public Shippers GetById(int id)
        {
            return (Shippers)context.Shippers.Find(id);
        }
    }
}
