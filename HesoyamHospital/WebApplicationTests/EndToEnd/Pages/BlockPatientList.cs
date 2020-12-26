using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace WebApplicationTests.EndToEnd.Pages
{
    class BlockPatientList
    {
        private readonly IWebDriver driver;
        public string URI = "http://localhost:4200/feedback/admin/block-patients";

        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table/tbody/tr"));
        private IWebElement LastRowUsername => driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[1]"));
        private IWebElement LastRowFullName => driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[2]"));
        private IWebElement LastRowCancelCount => driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[3]"));
        private IWebElement LastRowButton => driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[4]/button"));

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

        public void Navigate()
            => driver.Navigate().GoToUrl(URI);

        public void BlockPatient()
          => LastRowButton.Click();
    }
}
