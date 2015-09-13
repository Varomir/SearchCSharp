using NUnit.Framework;
using OpenQA.Selenium;
using SearchTest.SetUp;

using System;

namespace SearchTest
{
    [SetUpFixture]
    public class DriverSetup
    {
        internal static IWebDriver Driver;

        [SetUp]
        public void StartTestServer()
        {
            Driver = new TestDriverFactory().CreateDriver();
        }

        [TearDown]
        public void StopTestServer()
        {
            Driver.Quit();
        }
    }
}
