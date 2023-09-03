﻿using Lab.Practica4.EF.Data;
using Lab.Practica4.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica4.EF.Menu
{
    public class Functions
    {
        public static void ReturnCustomerObjectById()
        {
            while (true)
            {
                //string opcion = RequestIdString();

                CustomerLogic customers = new CustomerLogic();
                List<Customers> customer = customers.ReturnObject();

                Console.WriteLine("La lista de customers es:");
                foreach (Customers customerItem in customer)
                {
                    Console.WriteLine(customerItem);

                }

                Console.ReadLine();
            }

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
                    Console.WriteLine("Error! No ingreso un numero");
                }
            }
        }
        public static string RequestIdString()
        {
            while (true)
            {
                Console.WriteLine("Ingrese el id: ");
                string opcion = Console.ReadLine();
                if (opcion.Trim() != null && opcion.Length <= 5)
                {
                    return opcion;
                }
                else
                {
                    Console.WriteLine("Error! No ingreso un numero");
                }
            }
        }

        public static void ReturnAllProductsOutOfStock()
        {
            ProductLogic products = new ProductLogic();
            List<Products> productList = products.ReturnProductsOutOfStock();

            Console.WriteLine("La lista de productos sin stock es:");
            foreach (var product in productList)
            {
                Console.WriteLine($"ID: {product.ProductID} - {product.ProductName}");
            }
            Console.ReadLine();
        }
        public static void ReturnAllProductsInStockAnd3Value()
        {
            ProductLogic products = new ProductLogic();
            List<Products> productList = products.ReturnProductsInStockAnd3Value();

            Console.WriteLine("La lista de productos con stock es y valor mayor a 3 es:");
            foreach (var product in productList)
            {
                Console.WriteLine($"ID: {product.ProductID} - {product.ProductName}");
            }
            Console.ReadLine();
        }
        public static void ReturnAllCustomersFromWA()
        {
            CustomerLogic customers = new CustomerLogic();
            List<Customers> customersList = customers.ReturnCustomersFromWA();

            Console.WriteLine("La lista de customers de la region WA es:");
            foreach (var customer in customersList)
            {
                Console.WriteLine($"ID: {customer.CustomerID} - {customer.CompanyName}");
            }
            Console.ReadLine();
        }
        public static void ReturnCustomersName()
        {
            CustomerLogic customers = new CustomerLogic();
            List<Customers> customersList = customers.ReturnCustomersNames();
            Console.WriteLine("Ingrese 1 para los nombres en mayuscula o 2 para los nombres en minuscula.");
            try
            {
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.WriteLine("La lista de nombres de los contactos de las customers es:");
                    foreach (var customer in customersList)
                    {
                        Console.WriteLine($"{customer.ContactName.ToUpper()}");
                    }
                }
                else if (opcion == 2)
                {
                    Console.WriteLine("La lista de nombres de los contactos de las customers es:");
                    foreach (var customer in customersList)
                    {
                        Console.WriteLine($"{customer.ContactName.ToLower()}");
                    }
                }
                else
                {
                    Console.WriteLine("Error! No ingreso una opcion correcta");
                }
            }
            catch
            {
                Console.WriteLine("Error! No ingreso un numero.");
            }
            Console.ReadLine();
        }

        public static void ReturnCustomersFromWaAndOrderDate()
        {
            CustomerLogic customers = new CustomerLogic();
            List<Customers> customersList = customers.ReturnCustomersFromWaAndOrderDate();

            Console.WriteLine("La lista de customers de la region WA con fecha de orden despues del 1/1/97 es:");
            foreach (var customer in customersList)
            {
                Console.WriteLine($"ID: {customer.CustomerID} - {customer.CompanyName} - {customer.Orders}");
            }
            Console.ReadLine();
        }
        public static void ReturnAllCustomersFromWAOnly3()
        {
            CustomerLogic customers = new CustomerLogic();
            List<Customers> customersList = customers.ReturnCustomersFromWAOnly3();

            Console.WriteLine("La lista de los 3 primeros customers de la region WA es:");
            foreach (var customer in customersList)
            {
                Console.WriteLine($"ID: {customer.CustomerID} - {customer.CompanyName}");
            }
            Console.ReadLine();
        }
        public static void ReturnProductsOrderByName()
        {
            ProductLogic products = new ProductLogic();
            List<Products> productList = products.ReturnProductsOrderByName();

            Console.WriteLine("La lista de productos ordenada por nombre es:");
            foreach (var product in productList)
            {
                Console.WriteLine($"{product.ProductName} - ID: {product.ProductID}");
            }
            Console.ReadLine();
        }
        public static void ReturnProductsOrderByUnitsInStock()
        {
            ProductLogic products = new ProductLogic();
            List<Products> productList = products.ReturnProductsOrderByUnitsInStock();

            Console.WriteLine("La lista de productos ordenada por Unidades en stock es:");
            foreach (var product in productList)
            {
                Console.WriteLine($"Stock: {product.UnitsInStock} - {product.ProductName} - Id: {product.ProductID}");
            }
            Console.ReadLine();
        }

    }
}
