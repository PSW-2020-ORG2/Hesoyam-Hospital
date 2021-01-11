using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System;
using WebApplicationTests.EndToEnd.Pages;
using Xunit;

namespace WebApplicationTests.EndToEnd
{
    public class PostFeedbackTests : IDisposable
    {
        private IWebDriver driver;
        private PostFeedback postFeedbackPage;
        private FeedbackPublishList feedbackPublishListPage;
        private Login loginPage;

        private const string patientUsername = "milijanadj";
        private const string patientPassword = "pera";
        private const string patientRole = "Patient";

        private const string adminUsername = "perapera";
        private const string adminPassword = "pera";
        private const string adminRole = "Admin";

        public PostFeedbackTests()
        {
            InitializeDriver();

            postFeedbackPage = new PostFeedback(driver);
            feedbackPublishListPage = new FeedbackPublishList(driver);
            loginPage = new Login(driver);
        }

        [Fact]
        public void Successful_public_anonymous_feedback()
        {
            LogIn(patientUsername, patientPassword, patientRole);
            postFeedbackPage.Navigate();
            postFeedbackPage.EnsurePageIsDisplayed();
            postFeedbackPage.URI.ShouldBeEquivalentTo(driver.Url);

            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPublicRadioButton();
            postFeedbackPage.SelectAnonymousRadioButton();
            postFeedbackPage.SubmitFeedback();

            LogIn(adminUsername, adminPassword, adminRole);
            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.URI.ShouldBeEquivalentTo(driver.Url);
            feedbackPublishListPage.EnsurePageIsDisplayed();
            feedbackPublishListPage.GetLastRowUsername().ShouldBe("Anonymous");
            feedbackPublishListPage.GetLastRowFeedback().ShouldBe(feedback);
        }

        [Fact]
        public void Successful_private_anonymous_feedback()
        {
            LogIn(patientUsername, patientPassword, patientRole);
            postFeedbackPage.Navigate();
            postFeedbackPage.EnsurePageIsDisplayed();
            postFeedbackPage.URI.ShouldBeEquivalentTo(driver.Url);

            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPrivateRadioButton();
            postFeedbackPage.SelectAnonymousRadioButton();
            postFeedbackPage.SubmitFeedback();

            LogIn(adminUsername, adminPassword, adminRole);
            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.URI.ShouldBeEquivalentTo(driver.Url);
            feedbackPublishListPage.EnsurePageIsDisplayed();
            feedbackPublishListPage.GetLastRowUsername().ShouldBeEquivalentTo("Anonymous");
            feedbackPublishListPage.GetLastRowFeedback().ShouldBe(feedback);
        }

        [Fact]
        public void Successful_public_not_anonymous_feedback()
        {
            LogIn(patientUsername, patientPassword, patientRole);
            postFeedbackPage.Navigate();
            postFeedbackPage.EnsurePageIsDisplayed();
            postFeedbackPage.URI.ShouldBeEquivalentTo(driver.Url);

            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPublicRadioButton();
            postFeedbackPage.SelectNotAnonymousRadioButton();
            postFeedbackPage.SubmitFeedback();

            LogIn(adminUsername, adminPassword, adminRole);
            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.URI.ShouldBeEquivalentTo(driver.Url);
            feedbackPublishListPage.EnsurePageIsDisplayed();
            feedbackPublishListPage.GetLastRowUsername().ShouldBeEquivalentTo("milijanadj");
            feedbackPublishListPage.GetLastRowFeedback().ShouldBe(feedback);
        }

        [Fact]
        public void Successful_private_not_anonymous_feedback()
        {
            LogIn(patientUsername, patientPassword, patientRole);
            postFeedbackPage.Navigate();
            postFeedbackPage.EnsurePageIsDisplayed();
            postFeedbackPage.URI.ShouldBeEquivalentTo(driver.Url);

            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPrivateRadioButton();
            postFeedbackPage.SelectNotAnonymousRadioButton();
            postFeedbackPage.SubmitFeedback();

            LogIn(adminUsername, adminPassword, adminRole);
            feedbackPublishListPage.Navigate();
            feedbackPublishListPage.URI.ShouldBeEquivalentTo(driver.Url);
            feedbackPublishListPage.EnsurePageIsDisplayed();
            feedbackPublishListPage.GetLastRowUsername().ShouldBeEquivalentTo("milijanadj");
            feedbackPublishListPage.GetLastRowFeedback().ShouldBe(feedback);
        }

        [Fact]
        public void Unsuccessful_feedback_empty_text_input_field()
        {
            LogIn(patientUsername, patientPassword, patientRole);
            postFeedbackPage.Navigate();
            postFeedbackPage.EnsurePageIsDisplayed();
            postFeedbackPage.URI.ShouldBeEquivalentTo(driver.Url);

            string feedback = "";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPrivateRadioButton();
            postFeedbackPage.SelectNotAnonymousRadioButton();

            postFeedbackPage.SubmitButtonEnabled().ShouldBe(false);
        }

        [Fact]
        public void Unsuccessful_feedback_visibility_radio_button_group_not_selected()
        {
            LogIn(patientUsername, patientPassword, patientRole);
            postFeedbackPage.Navigate();
            postFeedbackPage.EnsurePageIsDisplayed();
            postFeedbackPage.URI.ShouldBeEquivalentTo(driver.Url);

            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectNotAnonymousRadioButton();

            postFeedbackPage.SubmitButtonEnabled().ShouldBe(false);
        }

        [Fact]
        public void Unsuccessful_feedback_anonymity_radio_button_group_not_selected()
        {
            LogIn(patientUsername, patientPassword, patientRole);
            postFeedbackPage.Navigate();
            postFeedbackPage.EnsurePageIsDisplayed();
            postFeedbackPage.URI.ShouldBeEquivalentTo(driver.Url);

            string feedback = "Awesome!";
            postFeedbackPage.InsertFeedback(feedback);
            postFeedbackPage.SelectPrivateRadioButton();

            postFeedbackPage.SubmitButtonEnabled().ShouldBe(false);
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
