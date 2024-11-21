using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaBankWebsite.TestScripts
{
    [TestClass]
    public class UpdateAccountInfoFunctionality
    {
        IWebDriver driver;
        [TestInitialize] 
        public void NavigateToParabankWebsite()
        {
            driver = new ChromeDriver(@"Put the system path of respective drivers");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [TestMethod]
        public void UpdateAccountInfo()
        {
            SeleniumSetMethods.InsertText(driver, "Name", "username", "ManasBisen");
            SeleniumSetMethods.InsertText(driver, "Name", "password", "PassWord");
            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Log In']");

            SeleniumSetMethods.Click(driver, "XPath", "//*[contains(text(),'Update Contact Info')]");
            //let's say here I want to change first name
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.firstName']", "ManasManasManas");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.lastName']", "Bisen");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.street']", "Abc Colony");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.city']", "Vadodara");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.state']", "Gujarat");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.zipCode']", "111111");

            SeleniumSetMethods.Click(driver, "XPath", "//input[@type='submit']");
        }

        [TestMethod]
        public void VerifyUpdateAccountInfoIfAnyFieldLeftBlank()
        {
            //Here "Zip Code" filed is blank
            SeleniumSetMethods.InsertText(driver, "Name", "username", "ManasBisen");
            SeleniumSetMethods.InsertText(driver, "Name", "password", "PassWord");
            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Log In']");

            SeleniumSetMethods.Click(driver, "XPath", "//*[contains(text(),'Update Contact Info')]");
            
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.firstName']", "ManasManasManas");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.lastName']", "Bisen");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.street']", "Abc Colony");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.city']", "Vadodara");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.state']", "Gujarat");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.zipCode']", "");

            SeleniumSetMethods.Click(driver, "XPath", "//input[@type='submit']");
            string ExpectedOutcome = "Zip Code is required.";
            string ActualOutcome = SeleniumSetMethods.GetValueFromTextBox(driver, "XPath", "//*[contains(text(),'Zip Code is required.')]");

            Assert.AreEqual(ExpectedOutcome, ActualOutcome);
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
