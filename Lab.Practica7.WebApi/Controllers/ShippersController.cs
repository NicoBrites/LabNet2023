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

        // POST: api/Shippers
        /*
         {
            "CompanyName": "ejemplo",
            "Phone": "123"
         } 
        */
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
        // PUT: api/Shippers/5
        /*
        {
           "CompanyName": "ejemplo",
           "Phone": "123"
        } 
       */
        public IHttpActionResult Put(int id,[FromBody] ShippersDto shippersDto)
        {
            try
            {
                Shippers shippers = new Shippers
                {
                    ShipperID= id,
                    CompanyName = shippersDto.CompanyName,
                    Phone = shippersDto.Phone,
                };

                shippersLogic.Update(shippers);
                return Ok("El Shipper se updateo correctamente");

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Shippers/5
        public IHttpActionResult Delete(int id)
        {

            try
            {
                shippersLogic.Delete(id);
                return Ok("El Shipper se elimino correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
