using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSECU.SeleniumTest.PageObjects
{
    public class SignIn
    {
        private IWebDriver driver;
        private IWebElement usernameField
        {
            get
            {
                return driver.FindElement(By.Name("username"));
            }
        }

        private IWebElement passwordField
        {
            get
            {
                return driver.FindElement(By.Name("password"));
            }
        }

        private IWebElement signInButton
        {
            get
            {
                return driver.FindElement(By.XPath("//button[@data-role='submit-button']"));
            }
        }

        private IWebElement errorMessage
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@role='alert']/div"));
            }
        }

        public SignIn(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterPasswordClickSignIn(string password)
        {
            passwordField.SendKeys(password);
            signInButton.Click();
        }

        public string GetErrorMessage()
        {
            return errorMessage.Text;
        }
    }
}
