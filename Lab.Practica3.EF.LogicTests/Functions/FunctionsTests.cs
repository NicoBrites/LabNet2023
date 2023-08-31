using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.Practica3.EF.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Practica3.EF.Logic.Functions;

namespace Lab.Practica3.EF.Functions.Tests
{
    [TestClass()]
    public class FunctionsTests
    {
        [TestMethod()]
        public void ThrowOwnExceptionTest()
        {
            string mensaje = "Mensaje para Unit Test";

            try
            {
                // Act
                Functions.ThrowOwnException(mensaje);
                Assert.Fail();

            }
            catch (OwnExceptionForced ex)
            {
                // Assert
                Assert.AreEqual($"Forzando la excepcion para Unit Test: {mensaje}", ex.Message);
            }

        }
    }
}