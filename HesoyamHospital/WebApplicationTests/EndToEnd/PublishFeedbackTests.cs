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
        private int publishButtonCount;
        private Login loginPage;

        private const string adminUsername = "perapera";
        private const string adminPassword = "pera";
        private const string adminRole = "Admin";

        public PublishFeedbackTests()
        {
            InitializeDriver();
            feedbackPublishListPage = new FeedbackPublishList(driver);
            publishedFeedbacksPage = new PublishedFeedbacks(driver);
            loginPage = new Login(driver);

            loginPage.Navigate();
            loginPage.EnsurePageIsDisplayed();
            LogIn(adminUsername, adminPassword, adminRole);
        }

        [Fact]
        public void Successful_count_of_published_feedbacks()
        {
            CountPublishedFeedback();
            CountPublishButtons();

            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.URI.ShouldBeEquivalentTo(driver.Url);
            feedbackPublishListPage.EnsurePageIsDisplayed();
            feedbackPublishListPage.PublishFirstFeedback();

            publishButtonCount.ShouldBe(feedbackPublishListPage.PublishButtonCount() + 1);
            publishedFeedbacksPage.Navigate();
            publishedFeedbacksPage.URI.ShouldBeEquivalentTo(driver.Url);
            publishedFeedbacksPage.EnsurePageIsDisplayed();
            publishedFeedbackCount.ShouldBe(publishedFeedbacksPage.PublishedFeedbacksCount() - 1);
        }

        [Fact]
        public void Unsuccessful_publish_of_last_feedback()
        {
            CountPublishedFeedback();
            CountPublishButtons();

            publishedFeedbacksPage.Navigate();
            publishedFeedbacksPage.EnsurePageIsDisplayed();
            publishedFeedbacksPage.URI.ShouldBeEquivalentTo(driver.Url);
            publishedFeedbackCount.ShouldBe(publishedFeedbacksPage.PublishedFeedbacksCount());
            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();
            feedbackPublishListPage.URI.ShouldBeEquivalentTo(driver.Url);
            publishButtonCount.ShouldBe(feedbackPublishListPage.PublishButtonCount());
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

        private void CountPublishedFeedback()
        {
            publishedFeedbacksPage.Navigate();
            publishedFeedbacksPage.EnsurePageIsDisplayed();
            publishedFeedbacksPage.URI.ShouldBeEquivalentTo(driver.Url);
            publishedFeedbackCount = publishedFeedbacksPage.PublishedFeedbacksCount();
        }

        private void CountPublishButtons()
        {
            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();
            feedbackPublishListPage.URI.ShouldBeEquivalentTo(driver.Url);
            publishButtonCount = feedbackPublishListPage.PublishButtonCount();
        }
    }
}
