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
        private readonly int blockPatientCount;

        public BlockPatientTests()
        {
            InitializeDriver();
            blockPatientList = new BlockPatientList(driver);
            blockPatientList.Navigate();
            Thread.Sleep(30000);
            blockPatientList.URI.ShouldBeEquivalentTo(driver.Url);
        }
        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void Successful_blocking()
        {
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
