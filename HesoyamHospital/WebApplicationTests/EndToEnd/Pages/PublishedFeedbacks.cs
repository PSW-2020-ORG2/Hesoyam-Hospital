using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

using System.Collections.ObjectModel;

namespace WebApplicationTests.EndToEnd.Pages
{
    public class PublishedFeedbacks
    {
        private readonly IWebDriver driver;
        public string URI = "http://localhost:4200/feedback/public/allFeedback";

        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//div[@id='publishedFeedbacks']/mat-card"));
        private IWebElement LastRowText => driver.FindElement(By.XPath("//div[@id='publishedFeedbacks']/mat-card[last()]/mat-card-content/p[@id='text']"));
        private IWebElement LastRowUsername => driver.FindElement(By.XPath("//div[@id='publishedFeedbacks']/mat-card[last()]/mat-card-footer/p[@id='name']"));
        public PublishedFeedbacks(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
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
        public int PublishedFeedbacksCount()
            => Rows.Count;

        public string GetLastRowPublishedFeedbacksText()
            => LastRowText.Text;

        public string GetLastRowPublishedFeedbacksUsername()
            => LastRowUsername.Text;

        public void Navigate()
           => driver.Navigate().GoToUrl(URI);

    }
}
