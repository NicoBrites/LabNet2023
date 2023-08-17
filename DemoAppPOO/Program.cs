using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animales = new List<Animal>();
            Animal gato = new Gato(4, "Hola soy un gato, bai");
            Animal persona = new Persona(2, "Hola soy una persona, bai");

            animales.Add(gato);
            animales.Add(persona);

            foreach (var item in animales) 
            {
                Console.WriteLine(item.Caminar());
                Console.WriteLine(item.Dialogar());
            }

            Console.ReadLine();


        }
    }
}
