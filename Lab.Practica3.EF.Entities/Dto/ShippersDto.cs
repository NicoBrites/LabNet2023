using System.ComponentModel.DataAnnotations;

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
