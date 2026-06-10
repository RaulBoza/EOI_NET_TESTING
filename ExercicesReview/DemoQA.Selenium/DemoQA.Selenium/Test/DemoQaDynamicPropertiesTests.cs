using DemoQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Test
{
    [TestFixture]
    [Category("DemoQA")]
    public class DemoQaDynamicPropertiesTests : SeleniumExternoTestBase
    {
        [Test]
        public void DynamicProperties_EsperaHastaQueBotonEsteHabilitado()
        {
            IrARutaUrlBase("/dynamic-properties");

            IWebElement boton = Wait.Until(driver =>
            {
                IWebElement element = driver.FindElement(By.Id("enableAfter"));
                return element.Enabled ? element : null;
            })!;

            ClickSeguro(boton);

            Assert.That(boton.Enabled, Is.True);
        }

        [Test]
        public void DynamicProperties_EsperaHastaQueElementoSeaVisible()
        {
            IrARutaUrlBase("/dynamic-properties");

            IWebElement visibleAfter = BuscarVisible(By.Id("visibleAfter"));

            Assert.That(visibleAfter.Displayed, Is.True);
        }
    }
}
