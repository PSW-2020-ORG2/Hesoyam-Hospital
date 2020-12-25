using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;


namespace WebApplicationTests.EndToEnd.Pages
{
    public class FeedbackPublishList
    {
        private readonly IWebDriver driver;
        public string URI = "http://localhost:4200/feedback/admin/publishlist";
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='feedbackTable']/ng-container/tr"));
        private IWebElement LastRowFeedback => driver.FindElement(By.XPath("//table[@id='feedbackTable']/ng-container/tr[last()]/td[1]"));
        private IWebElement LastRowUsername => driver.FindElement(By.XPath("//table[@id='feedbackTable']/ng-container/tr[last()]/td[2]"));
        private IWebElement LastRowText => driver.FindElement(By.XPath("//table[@id='feedbackTable']/ng-container/tr[last()]/td[3]"));
        private IWebElement LastRowButton => driver.FindElement(By.XPath("//table[@id='feedbackTable']/ng-container/tr[last()]/td[4]"));
        public FeedbackPublishList(IWebDriver driver)
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

        public int FeedbackCount()
            => Rows.Count;

        public string GetLastRowFeedback()
            => LastRowFeedback.Text;

        public string GetLastRowUsername()
            => LastRowUsername.Text;

        public string GetLastRowText()
            => LastRowText.Text;

        public void Navigate()
            => driver.Navigate().GoToUrl(URI);

        public void PublishFeedback()
          => LastRowButton.Click();

        

    }
}
