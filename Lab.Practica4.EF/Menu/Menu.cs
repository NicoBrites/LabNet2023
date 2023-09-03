using Lab.Practica4.EF.Data;
using Lab.Practica4.EF.Logic;
using Lab.Practica4.EF.Logic.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica4.EF.Menu
{
    public class Menu
    {
        public static void PrintText(string text)
        {
            Console.WriteLine(text);
        }
        public static void PrintMenu()
        {
            Console.Clear();
            string menu = @"
Menu Principal :
1) PRUEBA 1 PRIMER LINQ
2) Devolver todos los productos sin stock.
3) Devolver todos los productos en stock y con valor mayor a 3 por unidad.
4) Devolver todos los customer de la region WA.
5) Devolver los nombres de los customers en mayuscula y minuscula.
6) Inserta nuevo shipper
7) Actualiza la descripcion de una categoria por id
8) Actualiza el telefono de un shipper por id
9) Devolver los productos ordenados de manera descendente por unidades en stock
0) Cerrar la aplicacion
_______________________________________________________________________________________
            ";
            PrintText(menu);
        }
        public static int PrincipalMenu()
        {

            PrintMenu();
            int opcion;
            try
            {
                Console.WriteLine("Ingrese la opción deseada: ");
                opcion = int.Parse(Console.ReadLine());
                return opcion;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public static void StartProgram()
        {

            while (true)
            {
                int opcion = PrincipalMenu();
                bool flagApagar = false;

                switch (opcion)
                {
                    case 1:
                        Functions.ReturnCustomerObjectById();
                        break;
                    case 2:
                        Functions.ReturnAllProductsOutOfStock();
                        break;
                    case 3:
                        Functions.ReturnAllProductsInStockAnd3Value();
                        break;
                    case 4:
                        Functions.ReturnAllCustomersFromWA();
                        break;
                    case 5:
                        Functions.ReturnCustomersName();
                        break;
                    case 6:
                        Functions.ReturnCustomersFromWaAndOrderDate();
                        break;
                    case 7:
                        Functions.ReturnAllCustomersFromWAOnly3();
                        break;
                    case 8:
                        Functions.ReturnProductsOrderByName();
                        break;
                    case 9:
                        Functions.ReturnProductsOrderByUnitsInStock();
                        break;
                    case 0:
                        Console.WriteLine("Gracias por usar mi aplicacion. Presione Enter para cerrar.");
                        Console.ReadLine();
                        flagApagar = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        Console.ReadLine();
                        break;
                }
                if (flagApagar) { break; }
            }
        }
    }
}
