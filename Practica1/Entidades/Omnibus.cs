using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Omnibus : TransportePublico
    {
        #region Atributos
        private string nombre;
        #endregion

        #region Constructor
        public Omnibus(int pasajeros, string nombre) : base(pasajeros)
        {
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades
        public string Nombre { get { return nombre; } }
        #endregion

        #region Metodos
        public override string Avanzar()
        {
            return "El Omnibus esta avanzando";
        }
        public override string Detenerse()
        {
            return "El Omnibus se esta deteniendo";
        }
        #endregion
    }


}
