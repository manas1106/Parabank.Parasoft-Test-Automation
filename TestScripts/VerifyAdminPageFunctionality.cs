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
    public class VerifyAdminPageFunctionality
    {
        IWebDriver driver;
        [TestInitialize]
        public void NavigateToParabankWebsite() 
        {
            driver = new ChromeDriver(@"C:\Users\manas.bisen\Documents\C# Practice\ParaBankWebsite\Drivers");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [TestMethod]
        public void VerifyUserCanUpdateAdminDetails()
        {
            SeleniumSetMethods.InsertText(driver, "Name", "username", "ManasBisen");
            SeleniumSetMethods.InsertText(driver, "Name", "password", "PassWord");
            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Log In']");

            SeleniumSetMethods.Click(driver, "XPath", "//ul[@class='leftmenu']/li[6]/a");

            SeleniumSetMethods.Click(driver, "XPath", "//input[@id='accessMode1']");
            SeleniumSetMethods.Click(driver, "XPath", "//input[@value='Submit']");

            string ExpectedOutcome = "Settings saved successfully.";
            string ActualOutcome = SeleniumSetMethods.GetValueFromTextBox(driver, "XPath", "//*[contains(text(),'Settings saved successfully.')]");
            Assert.AreEqual(ExpectedOutcome, ActualOutcome);
        }

        [TestCleanup] 
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
