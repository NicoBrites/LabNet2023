using System;

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

