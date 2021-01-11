using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WebApplicationSeleniumTests.Pages
{
    class ViewFeedbacks
    {
        public IWebDriver WebDriver { get; }
        public const string Url = "http://localhost:52166/feedback/admin/publishlist";
        public ViewFeedbacks(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void Navigate()
        {
            WebDriver.Navigate().GoToUrl(Url);
        }

        public int GetFeedbackCount()
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            int count = WebDriver.FindElements(By.CssSelector("tbody tr")).Count;
            return count;
        }

        public List<string> GetTableData()
        {
            List<string> ret = new List<string>();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            ReadOnlyCollection<IWebElement> elements = WebDriver.FindElements(By.CssSelector("tbody tr td"));
            foreach(IWebElement el in elements)
            {
                ret.Add(el.Text);
            }

            return ret;
        }
    }
}
