using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
using System.Threading;
using WebApplicationTests.EndToEnd.Pages;
using Xunit;

namespace WebApplicationTests.EndToEnd
{
    public class PostFeedbackTests : IDisposable
    {
        private IWebDriver driver;
        private PostFeedback postFeedbackPage;
        private FeedbackPublishList feedbackPublishListPage;
        private int feedbackCount;

        public PostFeedbackTests()
        {
            InitializeDriver();

            postFeedbackPage = new PostFeedback(driver);
            feedbackPublishListPage = new FeedbackPublishList(driver);

            feedbackPublishListPage.Navigate();
            Thread.Sleep(40000);
            feedbackPublishListPage.URI.ShouldBeEquivalentTo(driver.Url);
            feedbackCount = feedbackPublishListPage.FeedbackCount();

            postFeedbackPage.Navigate();
            postFeedbackPage.EnsurePageIsDisplayed();
            postFeedbackPage.URI.ShouldBeEquivalentTo(driver.Url);
        }

        [Fact]
        public void Successful_public_anonymous_feedback()
        {
            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPublicRadioButton();
            postFeedbackPage.SelectAnonymousRadioButton();
            postFeedbackPage.SubmitFeedback();

            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();

            feedbackPublishListPage.GetLastRowUsername().ShouldBeEquivalentTo("Anonymous");
            feedbackCount.ShouldBe(feedbackPublishListPage.FeedbackCount() - 1);
            feedbackPublishListPage.GetLastRowFeedback().ShouldBe(feedback);
        }

        [Fact]
        public void Successful_private_anonymous_feedback()
        {
            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPrivateRadioButton();
            postFeedbackPage.SelectAnonymousRadioButton();
            postFeedbackPage.SubmitFeedback();

            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();

            feedbackPublishListPage.GetLastRowUsername().ShouldBeEquivalentTo("Anonymous");
            feedbackCount.ShouldBe(feedbackPublishListPage.FeedbackCount() - 1);
            feedbackPublishListPage.GetLastRowFeedback().ShouldBe(feedback);
        }

        [Fact]
        public void Successful_public_not_anonymous_feedback()
        {
            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPublicRadioButton();
            postFeedbackPage.SelectNotAnonymousRadioButton();
            postFeedbackPage.SubmitFeedback();

            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();

            feedbackCount.ShouldBe(feedbackPublishListPage.FeedbackCount() - 1);
            feedbackPublishListPage.GetLastRowFeedback().ShouldBe(feedback);
        }

        [Fact]
        public void Successful_private_not_anonymous_feedback()
        {
            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPrivateRadioButton();
            postFeedbackPage.SelectNotAnonymousRadioButton();
            postFeedbackPage.SubmitFeedback();

            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();

            feedbackCount.ShouldBe(feedbackPublishListPage.FeedbackCount() - 1);
            feedbackPublishListPage.GetLastRowFeedback().ShouldBe(feedback);
        }

        [Fact]
        public void Unsuccessful_feedback_empty_text_input_field()
        {
            string feedback = "";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPrivateRadioButton();
            postFeedbackPage.SelectNotAnonymousRadioButton();

            postFeedbackPage.SubmitButtonEnabled().ShouldBe(false);

            postFeedbackPage.SubmitFeedback();

            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();

            feedbackCount.ShouldBe(feedbackPublishListPage.FeedbackCount());
        }

        [Fact]
        public void Unsuccessful_feedback_visibility_radio_button_group_not_selected()
        {
            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectNotAnonymousRadioButton();

            postFeedbackPage.SubmitButtonEnabled().ShouldBe(false);

            postFeedbackPage.SubmitFeedback();

            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();

            feedbackCount.ShouldBe(feedbackPublishListPage.FeedbackCount());
        }

        [Fact]
        public void Unsuccessful_feedback_anonymity_radio_button_group_not_selected()
        {
            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPrivateRadioButton();

            postFeedbackPage.SubmitButtonEnabled().ShouldBe(false);

            postFeedbackPage.SubmitFeedback();

            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.EnsurePageIsDisplayed();

            feedbackCount.ShouldBe(feedbackPublishListPage.FeedbackCount());
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
