using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestTP4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaPaquetesInstanciada()
        {
            //Arrange
            Correo c1 = new Correo();
            //Assert
            Assert.IsNotNull(c1.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaquetesNoIguales()
        {
            //Arrange
            Correo c1 = new Correo();
            Paquete p1 = new Paquete("Hola", "540");
            Paquete p2 = new Paquete("Chau", "540");
            Paquete p3 = new Paquete("Que", "540");
            //Act
            c1 += p1;
            c1 += p2;
            c1 += p3;
            //Assert
            //[ExpectedException(typeof(TrackingIdRepetidoException))]
        }
    }
}
