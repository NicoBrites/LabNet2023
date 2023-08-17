using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppPOO
{
    public class Persona : Animal, Idialogar
    {
        public Persona(int cantidadPatas, string mensaje) : base(cantidadPatas, mensaje)
        {
        }

        public override string Caminar()
        {
            return string.Format("Soy una persona y camino en {0} patas.", GetPatas);
        }

    }
}
