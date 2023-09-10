using Lab.Practica3.EF.Data;
using Lab.Practica3.EF.Entities.Dto;
using Lab.Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.practica6.MVC.Controllers
{
    public class SuppliersController : Controller
    {
        SuppliersLogic logic = new SuppliersLogic();
        // GET: Shippers
        public ActionResult Index()
        {
            List<Suppliers> suppliers = logic.GetAll();
            List<SuppliersDto> suppliersDto = suppliers.Select(s => new SuppliersDto
            {
                SupplierID = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle

            }).ToList();

            return View(suppliersDto);
        }

        public ActionResult SuppliersAdministrator()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Administrator(SuppliersDto suppliersDto)
        {
            bool result;
            try
            {
                Suppliers supplierEntity = new Suppliers
                {
                    SupplierID = suppliersDto.SupplierID,
                    CompanyName = suppliersDto.CompanyName,
                    ContactName = suppliersDto.ContactName,
                    ContactTitle = suppliersDto.ContactTitle
                };
                if (suppliersDto.SupplierID == 0)
                {
                    result = logic.Add(supplierEntity);
                }
                else
                {
                   result = logic.Update(supplierEntity);
                }
                return Json(new { result = result });
            }
            catch (Exception ex) 
            {
                return Json(new { textStatus = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult DeleteSupplier(int id)
        {

            bool result = logic.Delete(id);
            return Json(new { result = result });

        }
    }
}