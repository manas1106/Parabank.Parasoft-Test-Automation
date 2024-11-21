using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaBankWebsite.TestScripts
{
    [TestClass]
    public class ReadDataFromBookstoreservicesTable
    {
        [TestMethod]
        public void BookServicesTble()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\manas.bisen\Documents\C# Practice\ParaBankWebsite\Drivers");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            SeleniumSetMethods.Click(driver, "LinkText", "Services");

            string ExpectedOutcome = "submitOrder";
            string ActualOutcome = SeleniumSetMethods.ReadDataFromTable(driver, 2, ExpectedOutcome );
            Assert.AreEqual(ExpectedOutcome, ActualOutcome);
        }
    }
}
