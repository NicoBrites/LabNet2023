using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int contadorOmnibus = 0;
            int contadorTaxi = 0;
  
            List<Omnibus> omnibuses = new List<Omnibus>();
            List<Taxi> taxis = new List<Taxi>();

            while (contadorOmnibus + contadorTaxi < 10)
            {
                if (contadorOmnibus < 5 && contadorTaxi < 5)
                { 
                    Console.WriteLine("Ingrese 1 para omnibus o 2 para taxi");             
                }
                else if (contadorTaxi == 5)
                {
                    Console.WriteLine("Ya se ingresaron los 5 taxis, ingrese 1 (omnibus)");
                }
                else if ( contadorOmnibus == 5)
                {
                    Console.WriteLine("Ya se ingresaron los 5 omnibus, ingrese 2 (taxi)");
                }

                string tipoDeTransporte = Console.ReadLine();

                if (tipoDeTransporte == "1" || tipoDeTransporte == "2")
                {
                    if (tipoDeTransporte == "1" && contadorOmnibus <= 5)
                    {
                        Console.WriteLine("Ingrese cantidad de pasajeros de omnibus: (menor a 70)");
                        string inputCantidadPasajeros = Console.ReadLine();

                        if (int.TryParse(inputCantidadPasajeros, out int cantidadPasajeros))
                        {
                            if (cantidadPasajeros < 71 && cantidadPasajeros > 0)
                            {

                                Omnibus omnibus = new Omnibus(cantidadPasajeros, $"Omnibus {contadorOmnibus+1}");
                                omnibuses.Add(omnibus);

                                contadorOmnibus++;
                            }
                            else
                            {
                                Console.WriteLine("No ingreso un numero valido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No ingreso un numero valido.");
                        }
                    }
                    else if (tipoDeTransporte == "1" && contadorOmnibus == 5)
                    {
                        Console.WriteLine("Ya ingreso los 5 omnibus, no puede ingresar mas");
                    }

                    if (tipoDeTransporte == "2" && contadorTaxi <= 5)
                    {
                        Console.WriteLine("Ingrese cantidad de pasajeros de taxi: (menor a 5)");
                        string inputCantidadPasajeros = Console.ReadLine();

                        if (int.TryParse(inputCantidadPasajeros, out int cantidadPasajeros))
                        {
                            if (cantidadPasajeros < 71 && cantidadPasajeros > 0)
                            {

                                Taxi taxi = new Taxi(cantidadPasajeros, $"Taxi {contadorTaxi+1}");
                                taxis.Add(taxi);
                               
                                contadorTaxi++;
                            }
                            else
                            {
                                Console.WriteLine("No ingreso un numero valido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No ingreso un numero valido.");
                        }  
                    }
                    else if (tipoDeTransporte == "2" && contadorTaxi == 5)
                    {
                        Console.WriteLine("Ya ingreso los 5 taxis, no puede ingresar mas");
                    }
                }
                else
                {
                    Console.WriteLine("No ingreso una opcion valida");
                }
            }
            Console.WriteLine("Ya ingreso todos los transportes solicitados. Muchas gracias.");
            Console.WriteLine("A continuacion se mostraran en lista los datos de los transportes ingresados:");
            Console.ReadLine();

            foreach (var item in omnibuses)
            {
                Console.WriteLine($"{item.GetNombre} : {item.GetPasajeros} pasajeros");
            }
            foreach (var item in taxis)
            {
                Console.WriteLine($"{item.GetNombre} : {item.GetPasajeros} pasajeros");
            }
            Console.ReadLine();

        }
    }
}
