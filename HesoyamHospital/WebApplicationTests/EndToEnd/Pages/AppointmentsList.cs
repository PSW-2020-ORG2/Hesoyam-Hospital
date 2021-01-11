using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace WebApplicationTests.EndToEnd.Pages
{
    class AppointmentsList
    {
        private readonly IWebDriver driver;
        public string URI = "http://localhost:4200/medical-record";

        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='appointmentsTable']/tbody/tr"));
        private ReadOnlyCollection<IWebElement> Buttons => driver.FindElements(By.Id("cancelButton"));
        private IWebElement FirstRowState => driver.FindElement(By.XPath("//table/tbody/tr/td[1]"));
        private IWebElement FirstRowButton => driver.FindElement(By.XPath("//table/tbody/tr/td[8]/button"));
        private ReadOnlyCollection<IWebElement> RowStates => driver.FindElements(By.XPath("//table/tbody/tr/td[1]"));

        public AppointmentsList(IWebDriver driver)
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

        public void Navigate()
            => driver.Navigate().GoToUrl(URI);

        public void CancelAppointment()
        {
            int btnCount = CancelButtonCount();
            FirstRowButton.Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    return btnCount - 1 == CancelButtonCount();
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

        public string CheckState()
          => FirstRowState.Text;

        public int CancelButtonCount()
            => Buttons.Count;

        public int GetAppointmentsWithCancelledStatusCount()
            => RowStates.Count(state => state.Text.Equals("CANCELLED"));
    }
}
