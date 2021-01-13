using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSeleniumTests.Pages;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Support.UI;

namespace WebApplicationSeleniumTests
{
    public class SubmitFeedback
    {
        private IWebDriver driver;
        public const string URI = "http://localhost:52166/feedback/patient/post";
        private PostFeedback postFeedback;
        private ViewFeedbacks viewFeedbacks;
        private string text = "Everything's OK";

        public SubmitFeedback()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\..\driver", options);
            Console.WriteLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\..\driver", options);

            //WebDriverWait wait = new WebDriverWait(driver, 3);

            //wait.Until(ExpectedConditions.elementToBeClickable(By.id("ID")));


            postFeedback = new PostFeedback(driver);
            viewFeedbacks = new ViewFeedbacks(driver);
        }

        [Fact]
        public void Test_feedback_input()
        {
            postFeedback.Navigate();
            postFeedback.SendPost(text);

            viewFeedbacks.Navigate();
            List<String> data = viewFeedbacks.GetTableData();

            Assert.Contains(text, data);
        }
    }
}
