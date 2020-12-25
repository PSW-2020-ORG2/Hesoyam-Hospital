using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
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

        public PublishFeedbackTests()
        {
            InitializeDriver();
            feedbackPublishListPage = new FeedbackPublishList(driver);
            publishedFeedbacksPage = new PublishedFeedbacks(driver);

            publishedFeedbacksPage.Navigate();
            publishedFeedbacksPage.URI.ShouldBeEquivalentTo(driver.Url);
            publishedFeedbackCount = publishedFeedbacksPage.PublishedFeedbacksCount();

            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();
            feedbackPublishListPage.URI.ShouldBeEquivalentTo(driver.Url);
        }

        [Fact]
        public void Successful_publish_of_last_feedback()
        {
            feedbackPublishListPage.PublishFeedback();
            

            publishedFeedbacksPage.Navigate();
            publishedFeedbacksPage.EnsurePageIsDisplayed();

            publishedFeedbacksPage.GetLastRowPublishedFeedbacksText().ShouldBeEquivalentTo(feedbackPublishListPage.GetLastRowText());
            publishedFeedbacksPage.GetLastRowPublishedFeedbacksUsername().ShouldBeEquivalentTo(feedbackPublishListPage.GetLastRowUsername());
            publishedFeedbackCount.ShouldBe(publishedFeedbacksPage.PublishedFeedbacksCount() - 1);
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
