using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SearchTest.SetUp;
using SearchTest.PageObjects;

namespace SearchTest.Tests
{
    public abstract class BaseTest
    {
        private IWebDriver _driver;
        protected HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            _driver = DriverSetup.Driver;
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            _driver.Navigate().GoToUrl(TestConfiguration.ApplicationUrl);
            homePage = new HomePage(_driver);
        }
    }
}
