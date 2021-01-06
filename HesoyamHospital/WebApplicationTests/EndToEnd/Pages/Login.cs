using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebApplicationTests.EndToEnd.Pages
{
    public class Login
    {
        private readonly IWebDriver driver;
        public string URI = "http://localhost:4200/login";
        private IWebElement Username => driver.FindElement(By.Id("usernameInput"));
        private IWebElement Password => driver.FindElement(By.Id("passwordInput"));
        private IWebElement PatientRadioButton => driver.FindElement(By.Id("patientRole"));
        private IWebElement AdminRadioButton => driver.FindElement(By.Id("adminRole"));
        private IWebElement LoginButton => driver.FindElement(By.Id("loginButton"));
        public Login(IWebDriver driver)
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
                    return Username.Displayed &&
                           Password.Displayed &&
                           PatientRadioButton.Displayed &&
                           AdminRadioButton.Displayed &&
                           LoginButton.Displayed;
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
        public void EnterUsername(string username)
            => Username.SendKeys(username);
        public void EnterPassword(string password)
            => Password.SendKeys(password);
        public void SelectPatientRole()
            => PatientRadioButton.Click();
        public void SelectAdminRole()
            => AdminRadioButton.Click();
        public void LogIn()
        {
            LoginButton.Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

            wait.Until(condition =>
            {
                try
                {
                    return !driver.Url.Equals(URI);
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
    }
}
