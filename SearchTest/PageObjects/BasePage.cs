using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SearchTest.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
    }
}
