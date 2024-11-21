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
    public class LoginFunctionality
    {
        IWebDriver driver;

        [TestInitialize] 
        public void NavigatetoParaBank()
        {
            driver = new ChromeDriver(@"C:\Users\manas.bisen\Documents\C# Practice\ParaBankWebsite\Drivers");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestMethod]
        public void UserCanLoginUsingValidCredentials()
        {
            SeleniumSetMethods.InsertText(driver, "Name", "username", "ManasBisen");
            SeleniumSetMethods.InsertText(driver, "Name", "password", "PassWord");
            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Log In']");

            string ExpectedOutcome = "*Balance includes deposits that may be subject to holds";
            string ActualOutcome = SeleniumSetMethods.GetValueFromTextBox(driver, "XPath", "//table[@id='accountTable']/tfoot/tr/td");
            Assert.AreEqual(ExpectedOutcome, ActualOutcome);
        }

        [TestMethod]
        public void LeavingUsernameOrPasswordFieldBlank()
        {
            SeleniumSetMethods.InsertText(driver, "Name", "username", "");
            SeleniumSetMethods.InsertText(driver, "Name", "password", "");
            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Log In']");

            string ExpectedOutcome = "Please enter a username and password.";
            string ActualOutcome = SeleniumSetMethods.GetValueFromTextBox(driver, "XPath", "//*[contains(text(),'Please enter a username and password.')]");
            Assert.AreEqual(ExpectedOutcome, ActualOutcome);
        }

        //Verify User can get Login Credentials using "Forgot Login Info" functionality
        [TestMethod]
        public void VerifyForgotLoginInfo()
        {
            SeleniumSetMethods.Click(driver, "XPath", "//div[@id='loginPanel']/p[1]/a");
            SeleniumSetMethods.InsertText(driver, "Id", "firstName", "Manas");
            SeleniumSetMethods.InsertText(driver, "Id", "lastName", "Bisen");
            SeleniumSetMethods.InsertText(driver, "Id", "address.street", "Abc Colony");
            SeleniumSetMethods.InsertText(driver, "Id", "address.city", "Vadodara");
            SeleniumSetMethods.InsertText(driver, "Id", "address.state", "Gujarat");
            SeleniumSetMethods.InsertText(driver, "Id", "address.zipCode", "111111");
            SeleniumSetMethods.InsertText(driver, "Id", "ssn", "SSN");

            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Find My Login Info']");

            string ExpectedOutcome = "Username";
            string ActualOutcome = SeleniumSetMethods.GetValueFromTextBox(driver, "XPath", "//div[@id=\"rightPanel\"]/p/b[1]");
            Assert.AreEqual(ExpectedOutcome, ActualOutcome);
        }

        //check behaviour of forgot login info functionality if a field is left blank
        //here "SSN" field is left blank
        [TestMethod]
        public void VerifyForgotPasswordInfoIfAnyFieldLeftBlank()
        {
            SeleniumSetMethods.Click(driver, "XPath", "//div[@id='loginPanel']/p[1]/a");
            SeleniumSetMethods.InsertText(driver, "Id", "firstName", "Manas");
            SeleniumSetMethods.InsertText(driver, "Id", "lastName", "Bisen");
            SeleniumSetMethods.InsertText(driver, "Id", "address.street", "Abc Colony");
            SeleniumSetMethods.InsertText(driver, "Id", "address.city", "Vadodara");
            SeleniumSetMethods.InsertText(driver, "Id", "address.state", "Gujarat");
            SeleniumSetMethods.InsertText(driver, "Id", "address.zipCode", "111111");
            SeleniumSetMethods.InsertText(driver, "Id", "ssn", "");

            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Find My Login Info']");

            string ExpectedOutcome = "Social Security Number is required.";
            string ActualOutcome = SeleniumSetMethods.GetValueFromTextBox(driver, "XPath", "//span[@class='error']");
            Assert.AreEqual(ExpectedOutcome, ActualOutcome);
        }

        [TestCleanup]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}
