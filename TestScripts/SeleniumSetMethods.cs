using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaBankWebsite.TestScripts
{
    public static class SeleniumSetMethods
    {
        public static string value;
        public static void Click(IWebDriver driver, string elementType, string element)
        {
            if (elementType == "Id")
            {
                driver.FindElement(By.Id(element)).Click();
            }
            if (elementType == "XPath")
            {
                driver.FindElement(By.XPath(element)).Click();
            }
            if (elementType == "Name")
            {
                driver.FindElement(By.Name(element)).Click();
            }
            if (elementType == "ClassName")
            {
                driver.FindElement(By.ClassName(element)).Click();
            }
            if (elementType == "CssSelector")
            {
                driver.FindElement(By.CssSelector(element)).Click();
            }
            if (elementType == "PartialLinkText")
            {
                driver.FindElement(By.PartialLinkText(element)).Click();
            }
            if (elementType == "LinkText")
            {
                driver.FindElement(By.LinkText(element)).Click();
            }
            if (elementType == "TagName")
            {
                driver.FindElement(By.TagName(element)).Click();
            }
        }

        public static void InsertText(IWebDriver driver, string elementType, string element, string text)
        {
            if (elementType == "Id")
            {
                driver.FindElement(By.Id(element)).SendKeys(text);
            }
            if (elementType == "XPath")
            {
                driver.FindElement(By.XPath(element)).SendKeys(text);
            }
            if (elementType == "Name")
            {
                driver.FindElement(By.Name(element)).SendKeys(text);
            }
            if (elementType == "ClassName")
            {
                driver.FindElement(By.ClassName(element)).SendKeys(text);
            }
            if (elementType == "CssSelector")
            {
                driver.FindElement(By.CssSelector(element)).SendKeys(text);
            }
            if (elementType == "TagName")
            {
                driver.FindElement(By.TagName(element)).SendKeys(text);
            }
            if (elementType == "LinkText")
            {
                driver.FindElement(By.LinkText(element)).SendKeys(text);
            }
            if (elementType == "PartialLinkText")
            {
                driver.FindElement(By.PartialLinkText(element)).SendKeys(text);
            }
        }

        public static void SelectElementFromDropdown(IWebDriver driver, string elementType, string element, string text)
        {

            if (elementType == "Id")
            {
                new SelectElement(driver.FindElement(By.Id(element))).SelectByText(text);
            }
            if (elementType == "Name")
            {
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(text);
            }
            if (elementType == "XPath")
            {
                new SelectElement(driver.FindElement(By.XPath(element))).SelectByText(text);
            }
            if (elementType == "ClassName")
            {
                new SelectElement(driver.FindElement(By.ClassName(element))).SelectByText(text);
            }
            if (elementType == "TagName")
            {
                new SelectElement(driver.FindElement(By.TagName(element))).SelectByText(text);
            }
            if (elementType == "CssSelector")
            {
                new SelectElement(driver.FindElement(By.CssSelector(element))).SelectByText(text);
            }
            if (elementType == "LinkText")
            {
                new SelectElement(driver.FindElement(By.LinkText(element))).SelectByText(text);
            }
            if (elementType == "PartialLinkText")
            {
                new SelectElement(driver.FindElement(By.PartialLinkText(element))).SelectByText(text);
            }

        }

        public static string GetValueFromTextBox(IWebDriver driver, string elementType, string element)
        {
            if (elementType == "Id")
            {
                return driver.FindElement(By.Id(element)).Text.Trim();
            }
            else if (elementType == "Name")
            {
                return driver.FindElement(By.Name(element)).Text.Trim();
            }
            else if (elementType == "ClassName")
            {
                return driver.FindElement(By.ClassName(element)).Text.Trim();
            }
            else if (elementType == "TagName")
            {
                return driver.FindElement(By.TagName(element)).Text.Trim();
            }
            else if (elementType == "XPath")
            {
                return driver.FindElement(By.XPath(element)).Text.Trim();
            }
            else if (elementType == "CssSelector")
            {
                return driver.FindElement(By.CssSelector(element)).Text.Trim();
            }
            else if (elementType == "LinkText")
            {
                return driver.FindElement(By.LinkText(element)).Text.Trim();
            }
            else if (elementType == "PartialLinkText")
            {
                return driver.FindElement(By.PartialLinkText(element)).Text.Trim();
            }
            else
            {
                return null;
            }

        }

        public static void HandleAlerrt(IWebDriver driver, string ActionOnAlert)
        {
            //Check if an alert is present
            IAlert TestAlert = driver.SwitchTo().Alert();

            if (TestAlert != null)
            {
                //Get the text of the alert
                //This can be used for validatiion purpose
                //using Assert method, this alert text cann be used
                string TestAlertText = TestAlert.Text;

                //Action on Alert
                if (ActionOnAlert == "Accept")
                {
                    TestAlert.Accept();
                }
                if (TestAlertText == "Dismiss")
                {
                    TestAlert.Dismiss();
                }
            }
        }

        public static void HandleiFrames(IWebDriver driver, string elementType, string element) 
        {
            if (elementType == "Id")
            {
                //Find the IFrame
                IWebElement iframe = driver.FindElement(By.Id(element));
                //Switch to IFrame
                driver.SwitchTo().Frame(iframe);
            }
            if (elementType == "Name")
            {
                //Find the IFrame
                IWebElement iframe = driver.FindElement(By.Name(element));
                //Switch to IFrame
                driver.SwitchTo().Frame(iframe);
            }
            if (elementType == "ClassName")
            {
                //Find the IFrame
                IWebElement iframe = driver.FindElement(By.ClassName(element));
                //Switch to IFrame
                driver.SwitchTo().Frame(iframe);
            }
            if (elementType == "TagName")
            {
                //Find the IFrame
                IWebElement iframe = driver.FindElement(By.TagName(element));
                //Switch to IFrame
                driver.SwitchTo().Frame(iframe);
            }
            if (elementType == "XPath")
            {
                //Find the IFrame
                IWebElement iframe = driver.FindElement(By.XPath(element));
                //Switch to IFrame
                driver.SwitchTo().Frame(iframe);
            }
            if (elementType == "CssSelector")
            {
                //Find the IFrame
                IWebElement iframe = driver.FindElement(By.CssSelector(element));
                //Switch to IFrame
                driver.SwitchTo().Frame(iframe);
            }
            if (elementType == "LinkText")
            {
                //Find the IFrame
                IWebElement iframe = driver.FindElement(By.LinkText(element));
                //Switch to IFrame
                driver.SwitchTo().Frame(iframe);
            }
            if (elementType == "PartialLinkText")
            {
                //Find the IFrame
                IWebElement iframe = driver.FindElement(By.PartialLinkText(element));
                //Switch to IFrame
                driver.SwitchTo().Frame(iframe);
            }
        }

        public static string ReadDataFromTable(IWebDriver driver, int TableNumber, string DataToReadFromTable)
        {
            //code for identifying Row of element of table
            IList<IWebElement> NumberOfRows = driver.FindElements(By.XPath("//table["+ TableNumber+ "]/tbody/tr"));

            //code to locate number of columns in table
            IList<IWebElement> TableColumn = driver.FindElements(By.XPath("//table[" + TableNumber + "]/tbody/tr[1]/td"));
            
            for (int i = 1; i <= NumberOfRows.Count; i++)
            {
                for (int j = 1; j <= TableColumn.Count; j++)
                {
                    value = driver.FindElement(By.XPath("//table[" + TableNumber + "]/tbody/tr[" + i + "]/td[" + j + "]")).Text.Trim();
                     if (value == DataToReadFromTable)
                    {
                        return value;    
                    }
                   
                }

            }
            return value;

        }

        public static void WriteDataIntoTable(IWebDriver driver, string ValueToWrite, int TableNumber, int RowNumber, int ColumnNumber)
        {
            
                //Code for identifying row elements of table
                IList<IWebElement> Tablerow = driver.FindElements(By.XPath("//table[" + TableNumber + "]/tbody/tr"));

                //code to locate number of column in table
                IList<IWebElement> TableColumn = driver.FindElements(By.XPath("//table[" + TableNumber + "]/tbody/tr/td"));

                IWebElement cell = driver.FindElement(By.XPath("//table[" + TableNumber + "]/tbody/tr[" + RowNumber + "]/td[" + ColumnNumber + "]"));

                cell.SendKeys(ValueToWrite);

            
        }

        public static string ReadDataFromFile(string FilePath)
        {
            StreamReader reader = new StreamReader(FilePath);
            string FileData = reader.ReadToEnd();
            return FileData;
        }

        public static void WriteDataIntoFile(string FilePath, string DataToWrite)
        {
            StreamWriter writer = new StreamWriter(FilePath);
            writer.Write(DataToWrite);
            writer.Close();
        }



    }
}
