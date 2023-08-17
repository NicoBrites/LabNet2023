using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Taxi : TransportePublico
    {
        private string nombre;
        public Taxi(int pasajeros, string nombre) : base(pasajeros)
        {
            this.nombre = nombre;
        }

        public string Nombre { get { return nombre; } }
    }
}
