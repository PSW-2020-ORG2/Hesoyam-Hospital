using OpenQA.Selenium;
using System;
using WebApplicationTests.EndToEnd.Pages;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Shouldly;
using Xunit;

namespace WebApplicationTests.EndToEnd
{
    public class CancelAppointmentTests : IDisposable
    {
        private IWebDriver driver;
        private readonly AppointmentsList appointmentsList;

        public CancelAppointmentTests()
        {
            InitializeDriver();
            appointmentsList = new AppointmentsList(driver);
            appointmentsList.Navigate();
            appointmentsList.EnsurePageIsDisplayed();
            Thread.Sleep(5000);
            appointmentsList.URI.ShouldBeEquivalentTo(driver.Url);
        }

        [Fact]
        public void Successful_canceling()
        {
            appointmentsList.CancelAppointment();
            Thread.Sleep(5000);
            appointmentsList.CheckState().ShouldBe("CANCELLED");
        }

        [Fact]
        public void Unsuccessful_canceling()
        {
            appointmentsList.CheckState().ShouldBe("INCOMING");
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
    }
}
