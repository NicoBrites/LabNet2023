using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public abstract class TransportePublico
    {
        private int pasajeros;

        public TransportePublico(int pasajeros)
        {
            this.GetPasajeros = pasajeros;         
        }

        public int GetPasajeros { get; }


        public string Avanzar()
        {
            return "Estoy avanzando";
        }
        public string Detenerse()
        {
            return "Estoy deteniendome";
        }


    }
}
