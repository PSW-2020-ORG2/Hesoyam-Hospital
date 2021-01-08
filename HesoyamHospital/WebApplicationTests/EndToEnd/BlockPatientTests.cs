using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
using WebApplicationTests.EndToEnd.Pages;
using Xunit;

namespace WebApplicationTests.EndToEnd
{
    public class BlockPatientTests : IDisposable
    {
        private IWebDriver driver;
        private readonly BlockPatientList blockPatientList;
        private readonly int blockPatientCount;
        private readonly Login loginPage;

        private const string adminUsername = "perapera";
        private const string adminPassword = "pera";
        private const string role = "Admin";

        public BlockPatientTests()
        {
            InitializeDriver();
            blockPatientList = new BlockPatientList(driver);
            loginPage = new Login(driver);

            LogIn(adminUsername, adminPassword, role);

            blockPatientList.Navigate();
            blockPatientList.EnsurePageIsDisplayed();
            blockPatientList.URI.ShouldBeEquivalentTo(driver.Url);
            blockPatientCount = blockPatientList.BlockButtonCount();
        }


        [Fact]
        public void Successful_blocking()
        {
            blockPatientList.BlockFirstPatient();
            blockPatientList.BlockButtonCount().ShouldBe(blockPatientCount - 1);
        }

        [Fact]
        public void Unsuccessful_blocking()
        {
            blockPatientList.BlockButtonCount().ShouldBe(blockPatientCount);
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
