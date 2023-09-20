using Lab.Practica3.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Practica3.EF.Logic
{
    public class SuppliersLogic : BaseLogic, ILogic<Suppliers>
    {
        public SuppliersLogic() : base() { }

        public List<Suppliers> GetAll()
        {
            return context.Suppliers.ToList();
        }

        public Suppliers GetById(int id)
        {
            Suppliers supplier = context.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new Exception("No existe ese ID");
            }
            else
            {
                return supplier;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var supplierAEliminar = context.Suppliers.Find(id);

                context.Suppliers.Remove(supplierAEliminar);

                var productosRelacionados = context.Products
                    .Where(p => p.SupplierID == supplierAEliminar.SupplierID);

                // Actualiza SupplierID a NULL (u otro valor válido) para esos productos
                foreach (var producto in productosRelacionados)
                {
                    producto.SupplierID = null; // O cualquier otro valor de SupplierID válido
                }

                return context.SaveChanges() > 0;
            }
            catch (Exception) 
            {
                throw new Exception("El id ingresado no existe");
            }
        }
        public bool Add(Suppliers supplier)
        {
            if (Validator.ValidarCaracteresEspeciales(supplier))
            {
                if (supplier.CompanyName != null && supplier.CompanyName.Length > 40 ||
                    (supplier.ContactName != null && supplier.ContactName.Length > 30) ||
                    (supplier.ContactTitle != null && supplier.ContactTitle.Length > 30))
                {
                    throw new Exception("Error! Te excediste de la cantidad maxima de caracteres");
                }
                else if (supplier.CompanyName == null || supplier.CompanyName == "")
                {
                    throw new Exception("Error! El companyName no puede ser nulo");
                }
                else
                {
                    context.Suppliers.Add(supplier);
                    return context.SaveChanges() > 0;
                }
            }
            throw new Exception("Error! Los datos que ingresaste no pueden contener caracteres especiales");
        }

        public bool Update(Suppliers supplier)
        {
            var supplierUpdate = context.Suppliers.Find(supplier.SupplierID);
            if (supplierUpdate != null)
            {
                if (Validator.ValidarCaracteresEspeciales(supplier))
                {
                    if (supplier.CompanyName != null && supplier.CompanyName.Length > 40 ||
                    (supplier.ContactName != null && supplier.ContactName.Length > 30) ||
                    (supplier.ContactTitle != null && supplier.ContactTitle.Length > 30))
                    {
                        throw new Exception("Error! Te excediste de la cantidad maxima de caracteres");
                    }
                    else if (supplier.CompanyName == null || supplier.CompanyName == "")
                    {
                        throw new Exception("Error! El companyName no puede ser nulo");
                    }
                    else
                    {
                        supplierUpdate.CompanyName = supplier.CompanyName;
                        supplierUpdate.ContactName = supplier.ContactName;
                        supplierUpdate.ContactTitle = supplier.ContactTitle;

                        return context.SaveChanges() > 0;
                    }
                }
                throw new Exception("Error! Los datos que ingresaste no pueden contener caracteres especiales");

            }
            else
            {
                throw new Exception("Error! Ingreso un id inexistente");
            }
        }
    }
}
