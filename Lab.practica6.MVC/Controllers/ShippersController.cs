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

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Administrator(ShippersDto shippersDto)
        {
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
                    logic.Add(shippersEntity);
                }
                else
                {
                    logic.Update(shippersEntity);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex) // HACER ALGO CON ESTE ERROR
            {
                return RedirectToAction("Index", "Error");
            }
        }
        [HttpPost]
        public ActionResult InsertShipper(ShippersDto shippersDto) 
        {
            try
            {
                Shippers shippersEntity = new Shippers { CompanyName = shippersDto.CompanyName,
                                                         Phone = shippersDto.Phone};
                logic.Add(shippersEntity);

                return RedirectToAction("Index");
            }
            catch (Exception ex) // HACER ALGO CON ESTE ERROR
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult DeleteShipper(int id)
        {
            try
            {
                logic.Delete(id);
                return Json(new { textStatus = "success" });
            }
            catch (Exception e)
            {
                return Json(new { textStatus = "error" });
            }
          
        }

    }
}