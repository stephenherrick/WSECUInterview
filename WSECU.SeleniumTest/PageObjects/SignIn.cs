using OpenQA.Selenium;

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

        /// <summary>
        /// BaseUrl/Banking/signin page for WSECU.org
        /// </summary>
        /// <param name="driver"><see cref="IWebDriver"/></param>
        public SignIn(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Enters the password into the password field and clicks the Sign In button
        /// </summary>
        /// <param name="password"></param>
        public void EnterPasswordClickSignIn(string password)
        {
            passwordField.SendKeys(password);
            signInButton.Click();
        }

        public void EnterUserName(string username)
        {
            usernameField.SendKeys(username);
        }

        /// <summary>
        /// Returns the error message when an input error is handled on the page
        /// </summary>
        /// <returns></returns>
        public string GetErrorMessage()
        {
            return errorMessage.Text;
        }
    }
}
