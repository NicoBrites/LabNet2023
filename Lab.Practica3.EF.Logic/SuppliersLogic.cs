using Lab.Practica3.EF.Data;
using Lab.Practica3.EF.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return (Suppliers)context.Suppliers.Find(id);
        }

        public void Delete(int id)
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

            context.SaveChanges();

        }
        public void Add(Suppliers supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
        }

        public void Update(Suppliers supplier)
        {
            var supplierUpdate = context.Suppliers.Find(supplier.SupplierID);
            if (supplierUpdate != null)
            {
                supplierUpdate.CompanyName = supplier.CompanyName;
                supplierUpdate.ContactName = supplier.ContactName;
                supplierUpdate.ContactTitle = supplier.ContactTitle;

                context.SaveChanges();
            }
            else
            {
                throw new Exception("Ingreso un id inexistente");
            }

        }
    }
}
