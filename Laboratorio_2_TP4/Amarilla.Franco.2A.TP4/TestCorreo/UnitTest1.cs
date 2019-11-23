using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Entidades;
namespace TestCorreo
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test para verificar si la lista de paquetes esta instanciada
        /// </summary>
        [TestMethod]
        public void TestPaquetes()
        {
            Correo c = new Correo();

            Assert.IsInstanceOfType(c.Paquetes,typeof(List<Paquete>));
        }

        /// <summary>
        /// Test para verificar si se lanza la excepcion TrackingIdRepetidoException
        /// cuando 2 paquetes tienen la misma tracking ID 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestTrackingID()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Belgrano 478","123");
            Paquete p2 = new Paquete("Belgrano 478", "123");
            c += p1;
            c += p2;
            
        }
    }
}
