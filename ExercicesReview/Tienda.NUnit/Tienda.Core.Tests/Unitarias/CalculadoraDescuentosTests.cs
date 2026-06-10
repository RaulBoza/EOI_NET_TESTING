using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Core;

namespace Tienda.Core.Tests.Unitarias
{
     [TestFixture]
    public class CalculadoraDescuentosTests
    {
        [Test]
        public void AplicarDescuento_ConDatosValidos_DevuelveResultado()
        {
            CalculadoraDescuentos calculadora = new();
            decimal precio = 100m;
            decimal porcentajeDescuento = 10m;
            decimal resultado = calculadora.AplicarDescuento(precio, porcentajeDescuento);
            Assert.That(resultado, Is.EqualTo(90m));
        }

        [Test]
        [TestCase(100, 0, 100)]
        [TestCase(100, 10, 90)]
        [TestCase(100, 50, 50)]
        [TestCase(100, 100, 0)]
        [TestCase(0,50, 0)]
        public void AplicarDescuento_CasosValidos_DevuelveResultado(decimal precio, decimal porcentajeDescuento, decimal resultadoEsperado)
        {
            CalculadoraDescuentos calculadora = new();
            decimal resultado = calculadora.AplicarDescuento(precio, porcentajeDescuento);
            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
        }

        public static IEnumerable<TestCaseData> CasosValidos()
        {
            yield return new TestCaseData(100m, 0m, 100m).SetName("DescuentoCero");
            yield return new TestCaseData(100m, 10m, 90m).SetName("DescuentoDiezPorciento");
            yield return new TestCaseData(100m, 50m, 50m).SetName("DescuentoCincuentaPorciento");
            yield return new TestCaseData(100m, 100m, 0m).SetName("DescuentoCienPorciento");
            yield return new TestCaseData(0m, 50m, 0m).SetName("PrecioCero");
        }

        [TestCaseSource(nameof(CasosValidos))]
        public void AplicarDescuento_CasosValidos_DevuelveResultado_UsandoTestCaseSource(decimal precio, decimal porcentajeDescuento, decimal resultadoEsperado)
        {
            CalculadoraDescuentos calculadora = new();
            decimal resultado = calculadora.AplicarDescuento(precio, porcentajeDescuento);
            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
        }
        public static IEnumerable<TestCaseData> CasosInvalidos()
        {
            yield return new TestCaseData(-1m, 10m).SetName("PrecioNegativo");
            yield return new TestCaseData(100m, -1m).SetName("PorcentajeNegativo");
            yield return new TestCaseData(100m, 101m).SetName("PorcentajeMayorA100");
        }

        [TestCaseSource(nameof(CasosInvalidos))]
        public void AplicarDescuento_CasosInvalidos_LanzaExcepcion(decimal precio, decimal porcentajeDescuento)
        {
            CalculadoraDescuentos calculadora = new();
            Assert.Throws<ArgumentOutOfRangeException>(() => calculadora.AplicarDescuento(precio, porcentajeDescuento));
        }

        
    }
}
