using DemoQA.Selenium.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Test
{
    [TestFixture]
    [Category("DemoQA")]
    public class DemoQaFramesTests : SeleniumExternoTestBase
    {
        [Test]
        public void Frames_CambiaAlFrameYLeeContenido()
        {
            IrARutaUrlBase("/frames");

            Driver.SwitchTo().Frame("frame1");

            IWebElement heading = BuscarVisible(By.Id("sampleHeading"));

            Assert.That(heading.Text, Is.EqualTo("This is a sample page"));

            Driver.SwitchTo().DefaultContent();

            Assert.That(BuscarVisible(By.TagName("body")).Text, Does.Contain("Frames"));
        }
    }
}
