using DemoQA.Selenium.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Test
{
    [TestFixture]
    [Category("DemoQA")]
    public class DemoQaWebTablesTests : SeleniumExternoTestBase
    {
        [Test]
        public void WebTables_CrearBuscarEditarYEliminarRegistro()
        {
            IrARutaUrlBase("/webtables");

            //string email = $"laura.{Guid.NewGuid():N}@example.com";
            string email = $"laura.perez@example.com";

            CrearRegistro("Laura", "Perez", "34", email, "35000", "QA");
            Buscar(email);

            IWebElement fila = BuscarFilaPorEmail(email);

            Assert.That(fila.Text, Does.Contain("Laura"));
            Assert.That(fila.Text, Does.Contain("QA"));

            EditarEdadDeFila(fila, "35");
            Buscar(email);

            IWebElement filaEditada = BuscarFilaPorEmail(email);
            Assert.That(filaEditada.Text, Does.Contain("35"));

            EliminarFila(filaEditada);

            Wait.Until(driver => !driver.FindElement(By.CssSelector(".table")).Text.Contains(email));

            Assert.That(Driver.FindElement(By.CssSelector(".table")).Text, Does.Not.Contain(email));
        }

        private void CrearRegistro(
            string firstName,
            string lastName,
            string age,
            string email,
            string salary,
            string department)
        {
            ClickSeguro(By.Id("addNewRecordButton"));

            Escribir(By.Id("firstName"), firstName);
            Escribir(By.Id("lastName"), lastName);
            Escribir(By.Id("age"), age);
            Escribir(By.Id("userEmail"), email);
            Escribir(By.Id("salary"), salary);
            Escribir(By.Id("department"), department);

            ClickSeguro(By.Id("submit"));
        }

        private void Buscar(string texto)
        {
            Escribir(By.Id("searchBox"), texto);
        }

        private IWebElement BuscarFilaPorEmail(string email)
        {
            //*[@id="root"]/div/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[4]
            //return BuscarVisible(By.XPath($"//div[contains(@class,'table')][.//div[text()='{email}']]"));
            //return BuscarVisible(By.XPath($"//div[contains(@class,'rt-tr-group')][.//div[text()='{email}']]"));
            //return BuscarVisible(By.XPath($"//*[@id=\"root\"]/div/div/div/div[2]/div[1]/div[2]/table/tbody/tr/td"));
            return BuscarVisible(By.CssSelector($".table>tbody"));
        }

        private void EditarEdadDeFila(IWebElement fila, string nuevaEdad)
        {
            ClickSeguro(fila.FindElement(By.CssSelector("[title='Edit']")));

            IWebElement age = BuscarDisponible(By.Id("age"));
            age.SendKeys(Keys.Control + "a");
            age.SendKeys(nuevaEdad);

            ClickSeguro(By.Id("submit"));
        }

        private void EliminarFila(IWebElement fila)
        {
            ClickSeguro(fila.FindElement(By.CssSelector("[title='Delete']")));
        }


    }
}

