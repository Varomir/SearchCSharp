using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace SearchTest.PageObjects
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement QuestionFld;

        [FindsBy(How = How.CssSelector, Using = "input[type=submit]")]
        private IWebElement SearchBtn;

        [FindsBy(How = How.CssSelector, Using = "#paging")]
        private IWebElement Paging;

        public HomePage(IWebDriver driver) : base (driver)
        {
        }

        private void setQuestionFld(String query)
        {
            QuestionFld.SendKeys(query);
        }

        private void clickSearchBtn()
        {
            SearchBtn.Click();
        }

        public ResultPage SearchText(String input)
        {
            setQuestionFld(input);
            clickSearchBtn();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => Paging.Displayed);
            return new ResultPage(_driver);
        }
    }
}
