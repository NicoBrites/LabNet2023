using Lab.Practica4.EF.Logic.Functions;
using System;

namespace Lab.Practica4.EF.Menu
{
    public class Menu
    {
        public static void PrintText(string text)
        {
            Console.WriteLine(text);
        }
        public static void PrintPrincipalMenu()
        {
            Console.Clear();
            string menu = @"
Menu Principal :
1) Menu de Customers
2) Menu de Productos
0) Cerrar la aplicacion
_______________________________________________________________________________________
            ";
            PrintText(menu);
        }
        public static void PrintMenuCustomer()
        {
            Console.Clear();
            string menu = @"
Menu Customer :
1) Devolver un Customer
2) Devolver todos los customer de la region WA.
3) Devolver los nombres de los customers en mayuscula y minuscula.
4) Devolver los customers de WA y la fecha de orden mayor a 1/1/97
5) Devolver los primeros 3 Customers de la Región WA
6) Devolver los customer con la cantidad de ordenes asociadas
0) Volver a menu principal
_______________________________________________________________________________________
            ";
            PrintText(menu);
        }
        public static void PrintMenuProduct()
        {
            Console.Clear();
            string menu = @"
Menu Productos :
1) Devolver todos los productos sin stock.
2) Devolver todos los productos en stock y con valor mayor a 3 por unidad.
3) Devolver el primer elemento o nulo de una lista de productos donde el ID de
producto sea igual a 789
4) Devolver lista de productos ordenados por nombre
5) Devolver los productos ordenados de manera descendente por unidades en stock
6) Devolver las distintas categorías asociadas a los productos
7) Devolver el primer elemento de una lista de productos
0) Volver a menu principal
_______________________________________________________________________________________
            ";
            PrintText(menu);
        }

        public static int PrincipalMenu(string tipoMenu)
        {
            if (tipoMenu == "Principal")
            {
                PrintPrincipalMenu();
            }
            else if (tipoMenu == "Customer")
            {
                PrintMenuCustomer();
            }
            else
            {
                PrintMenuProduct();
            }

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

                int opcion = PrincipalMenu("Principal");
                bool flagApagar = false;

                switch (opcion)
                {
                    case 1:
                        bool flagApagarWhileCustom = false;
                        while (true)
                        {
                            opcion = PrincipalMenu("Customer");
                            switch (opcion)
                            {
                                case 1:
                                    Functions.ReturnCustomerObjectById();
                                    break;
                                case 2:
                                    Functions.ReturnAllCustomersFromWA();
                                    break;
                                case 3:
                                    Functions.ReturnCustomersName();
                                    break;
                                case 4:
                                    Functions.ReturnCustomersFromWaAndOrderDate();
                                    break;
                                case 5:
                                    Functions.ReturnAllCustomersFromWAOnly3();
                                    break;
                                case 6:
                                    Functions.ReturnCustomersWithOrders();
                                    break;
                                case 0:
                                    flagApagarWhileCustom = true;
                                    break;
                                default:
                                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                                    Console.ReadLine();
                                    break;
                            }
                            if (flagApagarWhileCustom) { break; }
                        }
                        break;
                    case 2:
                        bool flagApagarWhileProduct = false;
                        while (true)
                        {
                            opcion = PrincipalMenu("Product");
                            switch (opcion)
                            {
                                case 1:
                                    Functions.ReturnAllProductsOutOfStock();
                                    break;
                                case 2:
                                    Functions.ReturnAllProductsInStockAnd3Value();
                                    break;
                                case 3:
                                    Functions.ReturnFirstProductOrNullAndIdEquals789();
                                    break;
                                case 4:
                                    Functions.ReturnProductsOrderByName();
                                    break;
                                case 5:
                                    Functions.ReturnProductsOrderByUnitsInStock();
                                    break;
                                case 6:
                                    Functions.ReturnDistinctProductCategories();
                                    break;
                                case 7:
                                    Functions.FirstProductOfList();
                                    break;
                                case 0:
                                    flagApagarWhileProduct = true;
                                    break;
                                default:
                                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                                    Console.ReadLine();
                                    break;
                            }
                            if (flagApagarWhileProduct) { break; }
                        }
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
