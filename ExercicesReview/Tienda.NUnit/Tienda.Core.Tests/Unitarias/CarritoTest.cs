using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Core;

namespace Tienda.Core.Tests.Unitarias
{
    [TestFixture]
    [Category("Unitarias")]
    internal class CarritoTest
    {
        private Carrito _carrito = null!;

        [OneTimeSetUp]
        public void AntesDeTodas()
        {
            TestContext.Out.WriteLine("Se ejecuta una vez antes de la clase");
        }

        [SetUp]
        public void AntesDeCadaTest()
        {
            _carrito = new Carrito();
        }

        [TearDown]
        public void DespuesDeCadaTest()
        {
            _carrito.Limpiar();
        }

        [Test]
        public void Carrito_Nuevo_EstaVacio()
        {
            Assert.That(_carrito.TotalItems, Is.EqualTo(0));
        }
    }
}
