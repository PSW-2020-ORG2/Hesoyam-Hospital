using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebApplicationSeleniumTests.Pages
{
    class PostFeedback
    {
        public IWebDriver WebDriver { get; }
        public const string Url = "http://localhost:52166/feedback/patient/post";
        ///html/body/app-root/app-post-feedback/div/mat-card/form/div[3]/button
        // mat-focus-indicator mat-raised-button mat-button-base mat-primary mat-button-disabled
        IWebElement radioButton1 => WebDriver.FindElement(By.Id("mat-radio-3-input"));
        IWebElement radioButton2 => WebDriver.FindElement(By.Id("mat-radio-6-input"));
        IWebElement submitButton => WebDriver.FindElement(By.XPath("html/body/app-root/app-post-feedback/div/mat-card/form/div[3]/button"));
        IWebElement txtFeedback => WebDriver.FindElement(By.Id("mat-input-0"));
        public PostFeedback(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        public void SendPost(string feedbackText)
        {
            txtFeedback.SendKeys(feedbackText);
            Actions actions = new Actions(WebDriver);

            actions.MoveToElement(radioButton1).Click().Perform();
            actions.MoveToElement(radioButton2).Click().Perform();
            //radioButton1.Click();
            //radioButton2.Click();
            submitButton.Submit();

            Thread.Sleep(5000);

            //WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public void Navigate()
        {
            WebDriver.Navigate().GoToUrl(Url);
        }
    }
}
