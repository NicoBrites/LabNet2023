using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Omnibus : TransportePublico
    {
        public Omnibus(int pasajeros, string nombre) : base(pasajeros)
        {
            GetNombre = nombre;
        }

        public string GetNombre { get; }

    }
}
