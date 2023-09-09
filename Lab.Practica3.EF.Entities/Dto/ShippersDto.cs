using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica3.EF.Entities.Dto
{
    public class ShippersDto
    {
        [Required(ErrorMessage = "El ShipperID es obligatorio")]
        public int ShipperID { get; set; }

        [StringLength(40, MinimumLength = 2, ErrorMessage = "El CompanyName debe tener entre 2 y 40 caracteres")]
        public string CompanyName { get; set; }

        public string Phone { get; set; }
    }
}
