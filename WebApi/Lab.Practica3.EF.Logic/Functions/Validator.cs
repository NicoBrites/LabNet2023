using Lab.Practica3.EF.Data;
using Lab.Practica3.EF.Entities.Dto;
using System.Text.RegularExpressions;

namespace Lab.Practica3.EF.Logic
{
    public static class Validator
    {
        public static bool ValidarCaracteresEspeciales(Suppliers suppliers)
        {
            if ( CaracteresEspeciales(suppliers.ContactName) &&
                CaracteresEspeciales(suppliers.ContactTitle))
            {
                return true;
            }
            return false;
           
        }// Solo valido los que no son CompanyName, porque algunos ya tienen caracteres especiales
        public static bool ValidarCaracteresEspeciales(Shippers shippers)
        {
            if (CaracteresEspeciales(shippers.Phone))
            {
                return true;
            }
            return false;

        }
        public static bool CaracteresEspeciales(string propiedad)
        {
            string pattern = "^[a-zA-Z0-9 ]*$";

            if (Regex.IsMatch(propiedad, pattern))
            {
               return true;
            }
            return false;
        }
    }
}
