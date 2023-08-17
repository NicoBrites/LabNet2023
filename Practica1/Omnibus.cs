using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Omnibus : TransportePublico
    {
        private string nombre;
        public Omnibus(int pasajeros, string nombre) : base(pasajeros)
        {
            this.nombre = nombre;
        }

        public string Nombre { get { return nombre; } }
    }

        
}
