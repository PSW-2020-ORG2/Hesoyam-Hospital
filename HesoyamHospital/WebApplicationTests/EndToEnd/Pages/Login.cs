using OpenQA.Selenium;

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
        public void EnterUsername(string username)
            => Username.SendKeys(username);
        public void EnterPassword(string password)
            => Password.SendKeys(password);
        public void SelectPatientRole()
            => PatientRadioButton.Click();
        public void SelectAdminRole()
            => AdminRadioButton.Click();
        public void LogIn()
            => LoginButton.Click();
        public void Navigate()
            => driver.Navigate().GoToUrl(URI);
    }
}
