using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using WSECU.SeleniumTest.PageObjects;

namespace WSECU.SeleniumTest
{
    [TestClass]
    public class LoginTest
    {
        private static string BaseUrl;
        private IWebDriver driver;

        [AssemblyInitialize]
        public static void TestSuiteStartUp(TestContext context)
        {
            BaseUrl = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build()
                .GetSection("BaseUrl").Value;
        }

        [TestInitialize]
        public void TestStartUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

        [DataTestMethod]
        [DataRow("youcanthavethisusername")]
        public void EnterWrongUsername(string incorrectUsername)
        {
            driver.Url = $"https://{BaseUrl}";
            var login = new LandingPage(driver);
            login.EnterUsernameClickSignIn(incorrectUsername);
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) =>
            {
                var element = d.FindElement(By.Name("password"));
                return element.Displayed ? element : null;
            });

            var onlineLoginUrl = $"https://digital.{BaseUrl}/banking/signin";
            Assert.AreEqual(onlineLoginUrl, driver.Url);

            var signIn = new SignIn(driver);
            signIn.EnterPasswordClickSignIn("hunter");
            Assert.AreEqual("Sorry, incorrect username.", signIn.GetErrorMessage().Trim());
        }
    }
}
