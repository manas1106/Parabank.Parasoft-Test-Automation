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
    public class RegistrationFunctionality
    {
        IWebDriver driver;
        [TestInitialize]
        public void NavigatetoParaBank()
        {
            driver = new ChromeDriver(@"Put the system path of respective drivers");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [TestMethod]
        public void NewUserRegistraton()
        {
            SeleniumSetMethods.Click(driver, "XPath", "//div[@id='loginPanel']/p[2]/a");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.firstName']", "Manas");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.lastName']", "Bisen");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.street']", "Abc Colony");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.city']", "Vadodara");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.state']", "Gujarat");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.zipCode']", "111111");

            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.ssn']", "SSN");

            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.username']", "ManasBisen");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.password']", "PassWord");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='repeatedPassword']", "PassWord");

            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Register']");

            string ExpectedOutcome = "Welcome " + "ManasBisen";
            string ActualOutcome = SeleniumSetMethods.GetValueFromTextBox(driver, "XPath", "//h1[@class='title']");
            Assert.AreEqual(ExpectedOutcome, ActualOutcome);
        }

        //Test the registration functionality if user register using same username
        [TestMethod]
        public void RegistrationUsingExistingUsername()
        {
            SeleniumSetMethods.Click(driver, "XPath", "//div[@id='loginPanel']/p[2]/a");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.firstName']", "Manas");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.lastName']", "Bisen");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.street']", "Abc Colony");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.city']", "Vadodara");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.state']", "Gujarat");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.zipCode']", "111111");

            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.ssn']", "SSN");

            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.username']", "ManasBisen");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.password']", "PassWord");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='repeatedPassword']", "PassWord");

            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Register']");

            string ExpectedOutcome = "This username already exists.";
            string ActualOutcome = SeleniumSetMethods.GetValueFromTextBox(driver, "XPath", "//span[@id='customer.username.errors']");
            Assert.AreEqual(ExpectedOutcome, ActualOutcome);
        }

        //Leaving first name blank while registration
        [TestMethod]
        public void LeavingFirstNameFieldBlank()
        {
            SeleniumSetMethods.Click(driver, "XPath", "//div[@id='loginPanel']/p[2]/a");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.firstName']", "");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.lastName']", "Bisen");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.street']", "Abc Colony");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.city']", "Vadodara");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.state']", "Gujarat");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.address.zipCode']", "111111");

            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.ssn']", "SSN");

            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.username']", "ManasBisen01");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='customer.password']", "PassWord");
            SeleniumSetMethods.InsertText(driver, "XPath", "//input[@id='repeatedPassword']", "PassWord");

            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Register']");

            string ExpectedOutcome = "First name is required.";
            string ActualOutcome = SeleniumSetMethods.GetValueFromTextBox(driver, "Id", "customer.firstName.errors");
            Assert.AreEqual(ExpectedOutcome, ActualOutcome);
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Close();
        }

    }
}
