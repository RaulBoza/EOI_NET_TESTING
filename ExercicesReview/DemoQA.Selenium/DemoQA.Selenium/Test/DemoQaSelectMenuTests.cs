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
    public class DemoQaSelectMenuTests : SeleniumExternoTestBase
    {
        [Test]
        public void SelectMenu_OldStyleSelect_PermiteSeleccionPorTexto()
        {
            IrARutaUrlBase("/select-menu");

            SelectElement oldSelect = new(BuscarVisible(By.Id("oldSelectMenu")));
            oldSelect.SelectByText("Blue");

            Assert.That(oldSelect.SelectedOption.Text, Is.EqualTo("Blue"));
        }

        [Test]
        public void SelectMenu_MultipleSelect_PermiteSeleccionarVariasOpciones()
        {
            IrARutaUrlBase("/select-menu");

            SelectElement cars = new(BuscarVisible(By.Id("cars")));

            cars.SelectByText("Volvo");
            cars.SelectByText("Audi");

            List<string> seleccionados = cars.AllSelectedOptions
                .Select(option => option.Text)
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.That(seleccionados, Does.Contain("Volvo"));
                Assert.That(seleccionados, Does.Contain("Audi"));
            });
        }
    }
}
