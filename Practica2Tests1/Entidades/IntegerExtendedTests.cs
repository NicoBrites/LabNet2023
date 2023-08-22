using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica2.Entidades;
using Practica2.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Extensiones.Tests
{
    [TestClass()]
    public class IntegerExtendedTests
    {
        [TestMethod()]
        public void DividirPorCeroTest()
        {
            // Arrange
            int num = 70;
            int esperado = -1;
            int retorno;

            // Act
            retorno = num.DividirPorCero();

            // Assert
            Assert.AreEqual(esperado, retorno);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void LanzarExcepcionTest()
        {
            // Arrange

            // Act
            Logic.LanzarExcepcion();

            // Assert
        }
    }
}