using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SupportApi;
using WebApi.Models;

namespace Tests.WebDriver
{
    [TestFixture]
    public class When_creating_a_new_contact
    {
        private IWebDriver browser;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void Setup()
        {
            FirefoxOptions opts = new FirefoxOptions();
            opts.BrowserExecutableLocation = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";
            browser = new FirefoxDriver(opts);
            //browser.Navigate().GoToUrl("http://jhdemos.azurewebsites.net/KendoGrid.html");
            browser.Navigate().GoToUrl("http://demosite.com/KendoGrid.html");
            

            wait = new WebDriverWait(browser, new TimeSpan(30000000));
            wait.Until(ExpectedConditions.ElementExists(By.Id("create_btn")));
            browser.FindElement(By.Id("create_btn")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Name("Region")));
            browser.FindElement(By.Name("Region")).SendKeys("Bellvue");
            browser.FindElement(By.Name("Company")).SendKeys("Companions United");
            browser.FindElement(By.Name("LName")).SendKeys("Whitehall");
            browser.FindElement(By.Name("FName")).SendKeys("Raj");
            browser.FindElement(By.ClassName("k-grid-update")).Click();
            wait.Until(ExpectedConditions.ElementExists(
                By.CssSelector("#flags > div")));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            browser.Quit();
        }

        [Test]
        public void user_shows_on_grid()
        {
            //Re-read grid since it was updated. Avoid StaleElemRef Exceptions
            IWebElement grid = browser.FindElement(By.Id("grid"));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("tr[id$='Whitehall']")));
        }

        [Test]
        public void user_shows_in_db()
        {
            var id = DataHelpers.get_high_contact_id();
            Contact contact = DataHelpers.get_contact_by_id(id);

            Assert.AreEqual(
                "Whitehall",
                contact.LName);
        }
    

}
}
