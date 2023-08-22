using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Entidades
{
    public static class Logic
    {
        public static void LanzarExcepcion()
        {
            throw new Exception();
        }

        public static void LanzarExcepcionPropia(string mensaje)
        {
            throw new ExcepcionPropia(mensaje);
        }
    }
}
