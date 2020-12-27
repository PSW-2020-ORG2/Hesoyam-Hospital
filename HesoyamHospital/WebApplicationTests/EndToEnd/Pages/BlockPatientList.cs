using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace WebApplicationTests.EndToEnd.Pages
{
    class BlockPatientList
    {
        private readonly IWebDriver driver;
        public string URI = "http://localhost:4200/block-patients";

        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table/tbody/tr"));
        private ReadOnlyCollection<IWebElement> Buttons => driver.FindElements(By.Id("blockButton"));
        private IWebElement LastRowUsername => driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[1]"));
        private IWebElement LastRowFullName => driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[2]"));
        private IWebElement LastRowCancelCount => driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[3]"));
        private IWebElement LastRowButton => driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[4]/button"));
        private IWebElement FirstRowUsername => driver.FindElement(By.XPath("//table/tbody/tr/td[1]"));
        private IWebElement FirstRowFullName => driver.FindElement(By.XPath("//table/tbody/tr/td[2]"));
        private IWebElement FirstRowCancelCount => driver.FindElement(By.XPath("//table/tbody/tr/td[3]"));
        private IWebElement FirstRowButton => driver.FindElement(By.XPath("//table/tbody/tr/td[4]/button"));

        public BlockPatientList(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 0;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public int SuspicousPatientsCount()
            => Rows.Count;

        public string GetLastRowUsername()
            => LastRowUsername.Text;

        public string GetLastRowFullName()
            => LastRowFullName.Text;

        public string GetLastRowCancelCount()
            => LastRowCancelCount.Text;

        public string GetFirstRowUsername()
            => FirstRowUsername.Text;

        public string GetFirstRowFullName()
            => FirstRowFullName.Text;

        public string GetFirstRowCancelCount()
            => FirstRowCancelCount.Text;

        public bool LastRowButtonDisplayed()
            => LastRowButton.Displayed;

        public bool FirstRowButtonDisplayed()
            => FirstRowButton.Displayed;

        public int BlockButtonCount()
            => Buttons.Count;

        public void Navigate()
            => driver.Navigate().GoToUrl(URI);

        public void BlockLastPatient()
          => LastRowButton.Click();

        public void BlockFirstPatient()
          => FirstRowButton.Click();
    }
}
