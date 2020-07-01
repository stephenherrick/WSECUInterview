using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WSECU.SeleniumTest.PageObjects;
using OpenQA.Selenium.Support.UI;

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
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
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
            driver.Url = BaseUrl;
            var login = new LandingPage(driver);
            login.EnterUsernameClickSignIn(incorrectUsername);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) =>
            {
                var element = d.FindElement(By.Name("password"));
                return element.Displayed ? element : null;
            });

            Assert.AreEqual($"https://digital.wsecu.org/banking/signin", driver.Url);

            var signIn = new SignIn(driver);
            signIn.EnterPasswordClickSignIn("hunter");
            Assert.AreEqual("Sorry, incorrect username.", signIn.GetErrorMessage().Trim());
        }
    }
}
