using OpenQA.Selenium;

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

        /// <summary>
        /// Home page for WSECU.org
        /// </summary>
        /// <param name="driver"><see cref="IWebDriver"/></param>
        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Enters the defined username into the username field
        /// </summary>
        /// <param name="username"></param>
        public void EnterUsernameClickSignIn(string username)
        {
            usernameField.SendKeys(username);
            signInButton.Click();
        }
    }
}
