using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebApplicationTests.EndToEnd.Pages
{
    public class PostFeedback
    {
        private readonly IWebDriver driver;
        public string URI = "http://localhost:4200/feedback/patient/post";
        private IWebElement InputTextField => driver.FindElement(By.Id("inputTextField"));
        private IWebElement PublicRadioButton => driver.FindElement(By.Id("publicRadioButton"));
        private IWebElement PrivateRadioButton => driver.FindElement(By.Id("privateRadioButton"));
        private IWebElement AnonymousRadioButton => driver.FindElement(By.Id("anonymousRadioButton"));
        private IWebElement NotAnonymousRadioButton => driver.FindElement(By.Id("notAnonymousRadioButton"));
        private IWebElement SubmitButton => driver.FindElement(By.Id("submitButton"));

        public PostFeedback(IWebDriver driver)
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
                    return InputTextField.Displayed && 
                           PublicRadioButton.Displayed && 
                           PrivateRadioButton.Displayed &&
                           AnonymousRadioButton.Displayed && 
                           NotAnonymousRadioButton.Displayed && 
                           SubmitButton.Displayed;
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

        public bool InputTextFieldDisplayed()
            => InputTextField.Displayed;

        public bool PublicRadioButtonDisplayed()
            => PublicRadioButton.Displayed;

        public bool PrivateRadioButtonDisplayed()
            => PrivateRadioButton.Displayed;

        public bool AnonymousRadioButtonDisplayed()
            => AnonymousRadioButton.Displayed;

        public bool NotAnonymousRadioButtonDisplayed()
            => NotAnonymousRadioButton.Displayed;

        public bool PublicRadioButtonSelected()
            => PublicRadioButton.Selected;

        public bool PrivateRadioButtonSelected()
            => PrivateRadioButton.Selected;

        public bool AnonymousRadioButtonSelected()
            => AnonymousRadioButton.Selected;

        public bool NotAnonymousRadioButtonSelected()
            => PublicRadioButton.Selected;

        public bool SubmitButtonDisplayed()
            => SubmitButton.Displayed;

        public bool SubmitButtonEnabled()
            => SubmitButton.Enabled;

        public void InsertFeedback(string feedback)
            => InputTextField.SendKeys(feedback);

        public void SubmitFeedback()
            => SubmitButton.Click();

        public void Navigate() 
            => driver.Navigate().GoToUrl(URI);

        public void SelectPublicRadioButton()
            => PublicRadioButton.Click();

        public void SelectPrivateRadioButton()
            => PrivateRadioButton.Click();

        public void SelectAnonymousRadioButton()
            => AnonymousRadioButton.Click();

        public void SelectNotAnonymousRadioButton()
            => NotAnonymousRadioButton.Click();
    }
}
