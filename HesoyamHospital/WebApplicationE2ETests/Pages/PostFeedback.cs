using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationE2ETests.Pages
{
    public class PostFeedback
    {
        public IWebDriver WebDriver { get; }
        public const string Url = "http://localhost:52166/feedback/patient/post";
        ///html/body/app-root/app-post-feedback/div/mat-card/form/div[3]/button
        // mat-focus-indicator mat-raised-button mat-button-base mat-primary mat-button-disabled
        IWebElement radioButton1 => WebDriver.FindElement(By.Id("mat-radio-2-input"));
        IWebElement radioButton2 => WebDriver.FindElement(By.Id("mat-radio-5-input"));
        IWebElement submitButton => WebDriver.FindElement(By.XPath("html/body/app-root/app-post-feedback/div/mat-card/form/div[3]/button"));
        IWebElement txtFeedback => WebDriver.FindElement(By.Id("mat-input-0"));
        public PostFeedback(IWebDriver webDriver) {
            WebDriver = webDriver;
        }
        public void SendPost(string feedbackText) 
        {
            txtFeedback.SendKeys(feedbackText);
        }
    }
}
