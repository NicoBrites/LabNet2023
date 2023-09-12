using Lab.Practica3.EF.Data;
using Lab.Practica3.EF.Entities.Dto;
using Lab.Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Lab.Practica7.WebApi.Controllers
{
    public class ShippersController : ApiController
    {
        ShippersLogic shippersLogic = new ShippersLogic();

        // GET: api/Shippers/2
        public ShippersDto GetById(int id)
        {
            Shippers shippers = shippersLogic.GetById(id);

                ShippersDto shippersDto = new ShippersDto
                {
                    ShipperID = shippers.ShipperID,
                    CompanyName = shippers.CompanyName,
                    Phone = shippers.Phone
                };

                return shippersDto;
           
        }

        // GET: api/Shippers
        public List<ShippersDto> GetList()
        {
            List<Shippers> shippers = shippersLogic.GetAll();
            List<ShippersDto> shippersDto = shippers.Select(s => new ShippersDto
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            }).ToList();

            return shippersDto;
        }

        // POST: api/Orders
        public IHttpActionResult Post([FromBody] ShippersDto shippersDto)
        {
            try
            {
                Shippers shippers = new Shippers
                {
                    CompanyName = shippersDto.CompanyName,
                    Phone = shippersDto.Phone,
                };
                shippersLogic.Add(shippers);
                return Ok("El Shipper se creo correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        // PUT: api/Orders/5
        public IHttpActionResult Put([FromBody] Shippers shippers)
        {
            try
            {
                shippersLogic.Update(shippers);
                return Ok("El Shipper se updateo correctamente");

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
