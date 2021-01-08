using OpenQA.Selenium;
using System;
using WebApplicationTests.EndToEnd.Pages;
using OpenQA.Selenium.Chrome;
using Shouldly;
using Xunit;

namespace WebApplicationTests.EndToEnd
{
    public class CancelAppointmentTests : IDisposable
    {
        private IWebDriver driver;
        private readonly AppointmentsList appointmentsList;
        private readonly Login loginPage;
        private int cancelButtonCount;
        private int cancelledStatusCount;

        private const string patientUsername = "milijanadj";
        private const string patientPassword = "pera";
        private const string patientRole = "Patient";

        public CancelAppointmentTests()
        {
            InitializeDriver();
            appointmentsList = new AppointmentsList(driver);
            loginPage = new Login(driver);
            LogIn(patientUsername, patientPassword, patientRole);
            appointmentsList.Navigate();
            appointmentsList.EnsurePageIsDisplayed();
            appointmentsList.URI.ShouldBeEquivalentTo(driver.Url);
        }

        [Fact]
        public void Successful_canceling()
        {
            cancelButtonCount = appointmentsList.CancelButtonCount();
            cancelledStatusCount = appointmentsList.GetAppointmentsWithCancelledStatusCount();

            appointmentsList.CancelAppointment();

            cancelButtonCount.ShouldBe(appointmentsList.CancelButtonCount() + 1);
            cancelledStatusCount.ShouldBe(appointmentsList.GetAppointmentsWithCancelledStatusCount() - 1);
        }

        [Fact]
        public void Unsuccessful_canceling()
        {
            cancelButtonCount = appointmentsList.CancelButtonCount();
            cancelledStatusCount = appointmentsList.GetAppointmentsWithCancelledStatusCount();

            cancelButtonCount.ShouldBe(appointmentsList.CancelButtonCount());
            cancelledStatusCount.ShouldBe(appointmentsList.GetAppointmentsWithCancelledStatusCount());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
      
        private void InitializeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");
            driver = new ChromeDriver(options);
        }

        private void LogIn(string username, string password, string role)
        {
            loginPage.Navigate();
            loginPage.EnsurePageIsDisplayed();
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            if (role.Equals("Patient")) loginPage.SelectPatientRole();
            else if (role.Equals("Admin")) loginPage.SelectAdminRole();
            loginPage.LogIn();
        }
    }
}
