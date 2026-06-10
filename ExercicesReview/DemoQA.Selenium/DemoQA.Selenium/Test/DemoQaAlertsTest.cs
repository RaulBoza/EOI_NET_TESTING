using DemoQA.Selenium.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Test
{
    [TestFixture]
    [Category("DemoQA")]
    public class DemoQaAlertsTests : SeleniumExternoTestBase
    {
        [Test]
        public void Alerts_AlertNormal_SeAcepta()
        {
            IrARutaUrlBase("/alerts");

            ClickSeguro(By.Id("alertButton"));

            IAlert alert = EsperarAlerta();

            Assert.That(alert.Text, Does.Contain("You clicked a button"));

            alert.Accept();
        }

        [Test]
        public void Alerts_AlertaDiferida_EsperaHastaQueAparece()
        {
            IrARutaUrlBase("/alerts");

            ClickSeguro(By.Id("timerAlertButton"));

            IAlert alert = EsperarAlerta();

            Assert.That(alert.Text, Does.Contain("This alert appeared after 5 seconds"));

            alert.Accept();
        }

        [Test]
        public void Alerts_Confirm_SePuedeCancelar()
        {
            IrARutaUrlBase("/alerts");

            ClickSeguro(By.Id("confirmButton"));

            IAlert alert = EsperarAlerta();
            alert.Dismiss();

            Assert.That(BuscarVisible(By.Id("confirmResult")).Text, Does.Contain("Cancel"));
        }

        [Test]
        public void Alerts_Prompt_EnviaTexto()
        {
            IrARutaUrlBase("/alerts");

            ClickSeguro(By.Id("promtButton"));

            IAlert alert = EsperarAlerta();
            alert.SendKeys("Fran");
            alert.Accept();

            Assert.That(BuscarVisible(By.Id("promptResult")).Text, Does.Contain("Fran"));
        }
    }
}
