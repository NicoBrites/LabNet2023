using Lab.Practica3.EF.Data;
using Lab.Practica3.EF.Entities.Dto;
using Lab.Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.practica6.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic logic = new ShippersLogic();
        // GET: Shippers
        public ActionResult Index()
        {
            List<Shippers> shippers = logic.GetAll();
            List<ShippersDto> shippersDto = shippers.Select(s => new ShippersDto
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone               
            }).ToList();

            return View(shippersDto);
        }

        public ActionResult ShippersAdministrator()
        {
            return View();
        }

        public ActionResult Administrator(ShippersDto shippersDto)
        {
            bool result;
            try
            {
                Shippers shippersEntity = new Shippers
                {
                    ShipperID = shippersDto.ShipperID,
                    CompanyName = shippersDto.CompanyName,
                    Phone = shippersDto.Phone
                };
                
                if (shippersDto.ShipperID == 0)
                {
                    result = logic.Add(shippersEntity);
                }
                else
                {
                    result = logic.Update(shippersEntity);
                }
                return Json(new { result = result });
                 
            }
            catch (Exception ex) 
            {
                return Json(new { textStatus = ex.Message });
            }
        }
        public ActionResult DeleteShipper(int id)
        {

            bool result = logic.Delete(id);
            return Json(new { result = result });

        }
    }
}