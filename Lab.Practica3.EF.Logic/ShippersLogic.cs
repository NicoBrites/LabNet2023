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

            var shipperUpdate = context.Shippers.Find(shipper.ShipperID);
            if (shipperUpdate != null)
            {
                if (shipperUpdate.CompanyName.Length > 40 || shipperUpdate.Phone.Length > 24)
                {
                    throw new Exception("Error! Te excediste de la cantidad de caracteres");
                }
                else
                {
                    shipperUpdate.CompanyName = shipper.CompanyName;
                    shipperUpdate.Phone = shipper.Phone;

                    return context.SaveChanges() > 0;
                }
            }
            else
            {
                throw new Exception("Error! Ingreso un id inexistente");
            }
        }
    }
}
