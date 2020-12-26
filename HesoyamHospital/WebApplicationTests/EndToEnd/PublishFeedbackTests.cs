using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
using System.Threading;
using WebApplicationTests.EndToEnd.Pages;
using Xunit;

namespace WebApplicationTests.EndToEnd
{
    public class PublishFeedbackTests : IDisposable
    {
        private IWebDriver driver;
        private FeedbackPublishList feedbackPublishListPage;
        private PublishedFeedbacks publishedFeedbacksPage;
        private int publishedFeedbackCount;
        private string firstRowText;
        private string firstRowUsername;
        public PublishFeedbackTests()
        {
            InitializeDriver();
            feedbackPublishListPage = new FeedbackPublishList(driver);
            publishedFeedbacksPage = new PublishedFeedbacks(driver);

            publishedFeedbacksPage.Navigate();
            Thread.Sleep(15000);
            publishedFeedbacksPage.URI.ShouldBeEquivalentTo(driver.Url);
            publishedFeedbackCount = publishedFeedbacksPage.PublishedFeedbacksCount();
            

            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();
            feedbackPublishListPage.URI.ShouldBeEquivalentTo(driver.Url);
            firstRowText = feedbackPublishListPage.GetFirstRowFeedback();
            firstRowUsername = feedbackPublishListPage.GetFisrtRowUsername();
        }

        [Fact]
        public void Successful_count_of_published_feedbacks()
        {
            feedbackPublishListPage.PublishFirstFeedback();
            Thread.Sleep(5000);

            publishedFeedbacksPage.Navigate();
            publishedFeedbacksPage.EnsurePageIsDisplayed();
            publishedFeedbackCount.ShouldBe(publishedFeedbacksPage.PublishedFeedbacksCount() - 1);
        }

        [Fact]
        public void Unsuccessful_publish_of_last_feedback()
        {
            publishedFeedbacksPage.Navigate();
            publishedFeedbacksPage.EnsurePageIsDisplayed();
            publishedFeedbackCount.ShouldBe(publishedFeedbacksPage.PublishedFeedbacksCount());
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
