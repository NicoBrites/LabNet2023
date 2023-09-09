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

        public void Delete(int id)
        {
            var shipperAEliminar = context.Shippers.Find(id);

            context.Shippers.Remove(shipperAEliminar);

            context.SaveChanges();

        }
        public void Add(Shippers shipper)
        {
            context.Shippers.Add(shipper);
            context.SaveChanges();
        }

        public void Update(Shippers shipper)
        {
            var shipperUpdate = context.Shippers.Find(shipper.ShipperID);
            if (shipperUpdate != null)
            {
                shipperUpdate.CompanyName = shipper.CompanyName;
                shipperUpdate.Phone = shipper.Phone;

                context.SaveChanges();
            }
            else
            {
                throw new Exception("Ingreso un id inexistente");
            }
           
        }
    }
}
