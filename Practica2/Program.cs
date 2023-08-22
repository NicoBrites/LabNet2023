using Practica2.Entidades;
using Practica2.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class Program
    {
        static void Main(string[] args)
        {

            int num = 10;
            int divisorError = 0;
            int divisor = 2;

            //EJ 1)
            num.DividirPorCero();
            Console.WriteLine("--------");
            Console.ReadLine();

            //EJ 2)
            num.DivisionIngresandoDivisor(divisorError);
            Console.WriteLine("--------");

            num.DivisionIngresandoDivisor(divisor);
            Console.WriteLine("--------");

            Console.ReadLine();

            //EJ 3)

            try
            {
                Logic.LanzarExcepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType().ToString());
            }
            Console.WriteLine("--------");
            Console.ReadLine();

            //EJ 4)

            try
            {
                Logic.LanzarExcepcionPropia("Mensaje de la Excepcion propia.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("--------");
            Console.ReadLine();










        }

    }
}
