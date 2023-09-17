using Lab.Practica3.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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

            Shippers shipper = context.Shippers.Find(id);
            if (shipper == null)
            {
                throw new Exception("No existe ese ID");
            }
            else
            {
                return shipper;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var shipperAEliminar = context.Shippers.Find(id);

                context.Shippers.Remove(shipperAEliminar);

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw new Exception("El id ingresado no existe");
            }
        }
        public bool Add(Shippers shipper)
        {
            if (shipper.CompanyName != null && shipper.CompanyName.Length > 40 ||
                (shipper.Phone != null && shipper.Phone.Length > 24))
            {
                throw new Exception("Error! Te excediste de la cantidad maxima de caracteres");
            }
            else if (shipper.CompanyName == null || shipper.CompanyName == "")
            {
                throw new Exception("Error! El companyName no puede ser nulo");
            }
            else
            {
                context.Shippers.Add(shipper);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Shippers shipper)
        {
            var shipperUpdate = context.Shippers.Find(shipper.ShipperID);
            if (shipperUpdate != null)
            {
                if (shipper.CompanyName != null && shipper.CompanyName.Length > 40 ||
                    (shipper.Phone != null && shipper.Phone.Length > 24))
                {
                    throw new Exception("Error! Te excediste de la cantidad maxima de caracteres");
                }
                else if (shipper.CompanyName == null || shipper.CompanyName == "")
                {
                    throw new Exception("Error! El companyName no puede ser nulo");
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
