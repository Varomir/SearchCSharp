using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace SearchTest.PageObjects
{
    public class ResultPage : BasePage
    {
        private IList<IWebElement> resultsTitleList, resultsUrlList, resultsTextList;

        [FindsBy(How = How.Id, Using = "midblock")]
        private IWebElement MidBlock;

        [FindsBy(How = How.CssSelector, Using = ".txt3.title.l_nu")]
        private IWebElement nextPageLink;

        [FindsBy(How = How.CssSelector, Using = "#paging>div.dsi>div.pgc:nth-child(1)")]
        private IWebElement firstBtn;

        [FindsBy(How = How.CssSelector, Using = "#paging>div.dsi>div.pgc:nth-child(2)")]
        private IWebElement secondBtn;

        public ResultPage(IWebDriver driver) : base(driver)
        {
        }
        
        public List<String[]> printResult(int expectedSize)
        {
            checkAllListSize(expectedSize);
            Console.WriteLine("- PRINT RESULTS -");
            List<String[]> resultStore = new List<String[]>();
            for (int i = 0; i < expectedSize; i++)
            {
                String[] line = new String[3];
                Console.WriteLine((i + 1) + ") \t\t     \t| ");
                Console.WriteLine("TITLE:\t\t     \t| " + resultsTitleList[i].Text);
                line[0] = resultsTitleList[i].Text;
                Console.WriteLine("URL:\t\t     \t| " + resultsUrlList[i].Text);
                line[1] = resultsUrlList[i].Text;
                Console.WriteLine("DESCRIPTIONS:\t \t| " + resultsTextList[i].Text.Replace(" Verder lezen »", ""));
                line[2] = resultsTextList[i].Text.Replace(" Verder lezen »", "");
                resultStore.Add(line);
                Console.WriteLine("-----------\t      \t|");
            }
            return resultStore;
        }

        public void goSecondPage()
        {
            Assert.That(firstBtn.GetAttribute("class"), Is.EqualTo("pgc pgcsel"));
            Assert.That(secondBtn.GetAttribute("class"), Is.EqualTo("pgc"));
            nextPageLink.Click();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement message = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#paging>div.dsi>div.pgc.pgcsel:nth-child(2)")));
            Assert.That(firstBtn.GetAttribute("class"), Is.EqualTo("pgc"));
            Assert.That(secondBtn.GetAttribute("class"), Is.EqualTo("pgc pgcsel"));
        }

        private void checkAllListSize(int quantity)
        {
            resultsTitleList = MidBlock.FindElements(By.CssSelector("#lindm .ptbs>div:first-child"));
            resultsUrlList = MidBlock.FindElements(By.CssSelector("#lindm div.durl>span"));
            resultsTextList = MidBlock.FindElements(By.CssSelector("#lindm div.abstract"));
            Assert.That(resultsTitleList.Count, Is.EqualTo(quantity), "Size 'resultTitleList' was not as expected!");
            Assert.That(resultsUrlList.Count, Is.EqualTo(quantity), "Size 'resultUrlList' was not as expected!");
            Assert.That(resultsTextList.Count, Is.EqualTo(quantity), "Size 'resultTextList' was not as expected!");
        }
    }
}
