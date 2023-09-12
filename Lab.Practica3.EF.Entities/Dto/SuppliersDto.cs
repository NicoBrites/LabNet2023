using System.ComponentModel.DataAnnotations;

namespace Lab.Practica3.EF.Entities.Dto
{
    public class SuppliersDto
    {
        [Required(ErrorMessage = "El SupplierID es obligatorio")]
        public int SupplierID { get; set; }

        [StringLength(40, MinimumLength = 2, ErrorMessage = "El CompanyName debe tener entre 2 y 40 caracteres")]
        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

    }
}
