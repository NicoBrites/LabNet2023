using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica3.EF.Logic.Functions
{
    public class OwnExceptionForced : Exception
    {
        public OwnExceptionForced(string message) : base(message)
        {

        }

        public override string Message => $"Forzando la excepcion para Unit Test: {base.Message}";
    }



}

