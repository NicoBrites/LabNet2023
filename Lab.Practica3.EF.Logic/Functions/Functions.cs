using Lab.Practica3.EF.Data;
using Lab.Practica3.EF.Logic;
using Lab.Practica3.EF.Logic.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab.Practica3.EF.Functions
{
    public static class Functions
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
1) Recorrer la lista de categorias e imprimir por consola el id y nombre de cada categoria
2) Recorrer la lista de shippers e imprimir por consola el id y nombre de cada shipper
3) Ingresar un id de una category e imprimir por consola el nombre
4) Borra un elemento de la tabla shipper ingresando su id
5) Inserta nueva categoria
6) Actualiza la descripcion de una categoria por id
0) Cerrar la aplicacion
_______________________________________________________________________________________
            ";
            PrintText(menu);
        }
        public static int PrincipalMenu() {

            PrintMenu();
            int opcion;
            try
            {
                Console.WriteLine("Ingrese la opción deseada: ");
                opcion = int.Parse(Console.ReadLine());
                return opcion;
            }
            catch(Exception)
            {
                return -1;
            }
        }
        public static void StartProgram()
        {

            while (true)
            {
                int opcion = PrincipalMenu();

                if (opcion == 1)
                {
                    ListIdAndNameOfEntity("categories");
                }
                else if (opcion == 2)
                {
                    ListIdAndNameOfEntity("shipper");
                }
                else if (opcion == 3)
                {
                    ReturnCategoriNameById();
                }
                else if (opcion == 4)
                {
                    DeleteShipperById();
                }
                else if (opcion == 5)
                {
                    InsertCategory();
                }
                else if (opcion == 6)
                {
                    UpdateCategoryDescriptionById();
                }
                else if (opcion == 0)
                {
                    Console.WriteLine("Gracias por usar mi aplicacion. Presione Enter para cerrar.");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                }    
            }
        }
        public static void ListIdAndNameOfEntity(string tipo)
        {
            if (tipo == "categories")
            {
                CategoriesLogic categories = new CategoriesLogic();
                Console.WriteLine("Las categorias son : ");
                foreach (Categories categorie in categories.GetAll())
                {
                    Console.WriteLine($"{categorie.CategoryID} - {categorie.CategoryName}");
                }
            }
            else if (tipo == "shipper")
            {
                ShippersLogic shippers = new ShippersLogic();
                Console.WriteLine("Los shippers son : ");
                foreach (Shippers shipper in shippers.GetAll())
                {
                    Console.WriteLine($"{shipper.ShipperID} - {shipper.CompanyName}");
                }
            }
            Console.ReadLine();
        }
        public static void ReturnCategoriNameById()
        {

            int opcion = RequestId();

            CategoriesLogic categories = new CategoriesLogic();
            Categories categorie = categories.GetById(opcion);

            if (categorie != null) 
            {
                Console.WriteLine(categorie.CategoryName);
            }
            else
            { 
                Console.WriteLine("No ingreso un ID existente."); 
            }
            Console.ReadLine();
        }
        public static int RequestId()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el id: ");
                    int opcion = int.Parse(Console.ReadLine());
                    return opcion;
                }
                catch (Exception)
                {
                    Console.WriteLine("No ingreso un numero");
                }
            }
        }

        public static void DeleteShipperById()
        {

            int opcion = RequestId();

            ShippersLogic shippers = new ShippersLogic();
            Shippers shipper = shippers.GetById(opcion);

            if ( shipper != null )
            {
                shippers.Delete(opcion);
                Console.WriteLine("Se elimino el shipper con id : {0}",opcion);
            }
            else
            {
                Console.WriteLine("No ingreso un ID existente.");
            }
            Console.ReadLine();

        }
        public static void InsertCategory()
        {

            Console.WriteLine("El id se agrega automaticamente.");
            Console.WriteLine("Ingrese nombre de la categoria :(No mayor a 15 caracteres)");
            string nombreCategoria = Console.ReadLine();

            Console.WriteLine("Ingrese descripcion de la categoria :");
            string descripcionCategoria = Console.ReadLine();

            CategoriesLogic categories = new CategoriesLogic();
            try
            {
                categories.Add(new Categories
                {
                    CategoryName = nombreCategoria,
                    Description = descripcionCategoria

                });
                Console.WriteLine("Se agrego la nueva categoria exitosamente!");
            }
            catch (Exception)
            {
                Console.WriteLine("Se excedio con el numero de caracteres o no ingreso nada en el nombre.");
            }
            Console.ReadLine();
        }
        public static void UpdateCategoryDescriptionById()
        {
            int opcion = RequestId();

            Console.WriteLine("Ingrese descripcion de la categoria :");
            string descripcionCategoria = Console.ReadLine();

            CategoriesLogic categories = new CategoriesLogic();
            Categories categorie = categories.GetById(opcion);

            if (categorie != null)
            {
                categories.Update(new Categories
                {
                    CategoryID = opcion,
                    Description = descripcionCategoria
                });
                Console.WriteLine("Se updateo la categoria exitosamente!");
            }
            else
            {
                Console.WriteLine("No agrego un id Existente");
            }
            Console.ReadLine();
        }
        public static void ThrowOwnException(string mensaje)
        {
            throw new OwnExceptionForced(mensaje);
        }

    }
}
