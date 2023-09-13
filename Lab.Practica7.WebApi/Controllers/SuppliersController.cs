using Lab.Practica3.EF.Data;
using Lab.Practica3.EF.Entities.Dto;
using Lab.Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Lab.Practica7.WebApi.Controllers
{
    public class SuppliersController : ApiController
    {

        SuppliersLogic suppliersLogic = new SuppliersLogic();

        // GET: api/Suppliers/2
        public SuppliersDto GetById(int id)
        {
            Suppliers suppliers = suppliersLogic.GetById(id);

            SuppliersDto suppliersDto = new SuppliersDto
            {
                SupplierID = suppliers.SupplierID,
                CompanyName = suppliers.CompanyName,
                ContactName = suppliers.ContactName,
                ContactTitle = suppliers.ContactTitle
            };

            return suppliersDto;

        }

        // GET: api/Suppliers
        public List<SuppliersDto> GetList()
        {
            List<Suppliers> suppliers = suppliersLogic.GetAll();
            List<SuppliersDto> suppliersDto = suppliers.Select(s => new SuppliersDto
            {
                SupplierID = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle
            }).ToList();

            return suppliersDto;
        }

        // POST: api/Suppliers
        /*
         {
            "CompanyName": "ejemplo",
            "ContactName": "ejemploContact",
            "ContactTitle": "ejemploTitle"
         } 
        */
        public IHttpActionResult Post([FromBody] SuppliersDto suppliersDto)
        {
            try
            {
                Suppliers suppliers = new Suppliers
                {
                    CompanyName = suppliersDto.CompanyName,
                    ContactName = suppliersDto.ContactName,
                    ContactTitle = suppliersDto.ContactTitle
                };
                suppliersLogic.Add(suppliers);

                return Ok("El Supplier se creo correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        // PUT: api/Suppliers/5
        /*
        {
            "CompanyName": "ejemplo",
            "ContactName": "ejemploContact",
            "ContactTitle": "ejemploTitle"
        } 
       */
        public IHttpActionResult Put(int id, [FromBody] SuppliersDto suppliersDto)
        {
            try
            {
                Suppliers suppliers = new Suppliers
                {
                    SupplierID = id,
                    CompanyName = suppliersDto.CompanyName,
                    ContactName = suppliersDto.ContactName,
                    ContactTitle = suppliersDto.ContactTitle
                };

                suppliersLogic.Update(suppliers);
                return Ok("El Supplier se updateo correctamente");

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Suppliers/5
        public IHttpActionResult Delete(int id)
        {

            try
            {
                suppliersLogic.Delete(id);
                return Ok("El Shipper se elimino correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}