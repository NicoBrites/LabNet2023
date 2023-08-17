using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppPOO
{
    public abstract class Animal : Idialogar
    {
        private int cantidadPatas;

        public Animal(int cantidadPatas, string mensaje)
        {
              GetPatas = cantidadPatas;
              GetMensaje = mensaje;
        }

        protected Animal(int cantidadPatas)
        {
            this.cantidadPatas = cantidadPatas;
        }

        public int GetPatas { get;}
        public string GetMensaje { get; }

        public abstract string Caminar();

        public string Dialogar()
        {
            return GetMensaje;
        }
    }
}
