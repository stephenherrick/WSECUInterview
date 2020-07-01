using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSECU.SeleniumTest.PageObjects
{
    public class LandingPage
    {
        private IWebDriver driver;
        
        private IWebElement usernameField
        {
            get 
            {
                return driver.FindElement(By.Id("digital-banking-username"));
            }
        }

        private IWebElement signInButton
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@value='Sign In']"));
            }
        }

        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterUsernameClickSignIn(string username)
        {
            usernameField.SendKeys(username);
            signInButton.Click();
        }
    }
}
