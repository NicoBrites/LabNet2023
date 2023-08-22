using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Extensiones
{
    public static class IntegerExtended
    {
        public static int DividirPorCero(this int num)
        {

            try
            {
                int error = num / 0;
                return error;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
 
                return -1;
            }
            finally
            {
                Console.WriteLine("Termino de ejecutarse el metodo.");

            }

        }
        public static int DivisionIngresandoDivisor(this int num, int divisor)
        {
            try
            {
                int error = num / divisor;
                return error;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Asi que queres dividir por 0 ? Te subo el dolar !! ({ex.Message})"  );

                return -1;
            }
            catch (Exception)
            {
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");

                return -1;
            }
            finally
            {
                Console.WriteLine("Termino de ejecutarse el metodo.");

            }
        }
    }
}
