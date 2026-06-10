using DemoQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Test
{
    [TestFixture]
    [Category("DemoQA")]
    public class DemoQaButtonsTests : SeleniumExternoTestBase
    {
        [Test]
        public void Buttons_PermiteDobleClickClickDerechoYClickNormal()
        {
            IrARutaUrlBase("/buttons");

            Actions actions = new(Driver);

            IWebElement doubleClickButton = BuscarVisible(By.Id("doubleClickBtn"));
            ScrollHasta(doubleClickButton);
            actions.DoubleClick(doubleClickButton).Perform();

            IWebElement rightClickButton = BuscarVisible(By.Id("rightClickBtn"));
            ScrollHasta(rightClickButton);
            actions.ContextClick(rightClickButton).Perform();

            IWebElement clickMeButton = BuscarVisible(By.XPath("//button[normalize-space()='Click Me']"));
            ClickSeguro(clickMeButton);

            Assert.Multiple(() =>
            {
                Assert.That(BuscarVisible(By.Id("doubleClickMessage")).Text, Does.Contain("double click"));
                Assert.That(BuscarVisible(By.Id("rightClickMessage")).Text, Does.Contain("right click"));
                Assert.That(BuscarVisible(By.Id("dynamicClickMessage")).Text, Does.Contain("dynamic click"));
            });
        }
    }
}
