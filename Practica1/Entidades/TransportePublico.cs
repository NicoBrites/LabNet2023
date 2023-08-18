using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public abstract class TransportePublico
    {
        #region Atributos

        private int pasajeros;

        #endregion

        #region Constructor
        public TransportePublico(int pasajeros)
        {
            this.pasajeros = pasajeros;         
        }
        #endregion

        #region Propiedades
        public int Pasajeros { get { return pasajeros; } }
        #endregion

        #region Metodos Abstractos
        public abstract string Avanzar();

        public abstract string Detenerse();
        
        #endregion

    }
}
