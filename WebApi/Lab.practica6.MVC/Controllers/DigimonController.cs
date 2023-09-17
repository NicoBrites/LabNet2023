using Lab.Practica3.EF.Logic;
using Lab.Practica3.EF.Entities.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using Lab.Practica3.EF.Entities;

namespace Lab.practica6.MVC.Controllers
{
    public class DigimonController : Controller
    {

        DigimonLogic logic = new DigimonLogic();

        // GET: Digimon
        public async  Task<ActionResult> Index()
        {
            List<Digimon> digimons = await logic.GetAll();

            List<DigimonDto> digimonDtos =  digimons.Select(s => new DigimonDto
            {
                Name = s.Name,
                Level = s.Level,
                Img = s.Img
            }).ToList();

            return View(digimonDtos);

        }
    }
     
}