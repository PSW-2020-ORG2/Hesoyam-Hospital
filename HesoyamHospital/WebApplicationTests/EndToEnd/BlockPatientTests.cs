using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
using System.Threading;
using WebApplicationTests.EndToEnd.Pages;
using Xunit;

namespace WebApplicationTests.EndToEnd
{
    public class BlockPatientTests : IDisposable
    {
        private IWebDriver driver;
        private readonly BlockPatientList blockPatientList;
        private int blockPatientCount;

        public BlockPatientTests()
        {
            InitializeDriver();
            blockPatientList = new BlockPatientList(driver);
            blockPatientList.Navigate();
            blockPatientList.EnsurePageIsDisplayed();
            Thread.Sleep(5000);
            blockPatientCount = blockPatientList.BlockButtonCount();
            blockPatientList.URI.ShouldBeEquivalentTo(driver.Url);
        }


        [Fact]
        public void Successful_blocking()
        {
            blockPatientList.BlockFirstPatient();
            Thread.Sleep(5000);
            blockPatientList.BlockButtonCount().ShouldBe(blockPatientCount - 1);
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
