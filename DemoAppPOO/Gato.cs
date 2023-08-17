using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppPOO
{
    public class Gato : Animal
    {
        public Gato(int cantidadPatas, string mensaje) : base(cantidadPatas, mensaje)
        {
        }

        public override string Caminar()
        {
            return $"Soy un gato y camino en {GetPatas} patas.";
        }
    }
}
