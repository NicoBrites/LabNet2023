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

        public bool Delete(int id)
        {
            var shipperAEliminar = context.Shippers.Find(id);

            context.Shippers.Remove(shipperAEliminar);

            return context.SaveChanges() > 0;

        }
        public bool Add(Shippers shipper)
        {
            context.Shippers.Add(shipper);
            return context.SaveChanges() > 0;

        }

        public bool Update(Shippers shipper)
        {
            bool result = false;
            var shipperUpdate = context.Shippers.Find(shipper.ShipperID);
            if (shipperUpdate != null)
            {
                shipperUpdate.CompanyName = shipper.CompanyName;
                shipperUpdate.Phone = shipper.Phone;

                result = context.SaveChanges() > 0;
            }
            else
            {
                throw new Exception("Error! Ingreso un id inexistente");
            }
            return result;
        }
    }
}
