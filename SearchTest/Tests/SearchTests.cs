using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SearchTest.PageObjects;

namespace SearchTest.Tests
{
    public class SearchTests : BaseTest
    {
        private ResultPage resultPage;
        private List<String[]> firstResultPage;
        private List<String[]> secondResultPage;
        String askTerm = "seleniumcamp";

        [Test]
        public void runTest()
        {
            resultPage = homePage.SearchText(askTerm);
            firstResultPage = resultPage.printResult(10);
            resultPage.goSecondPage();
            secondResultPage = resultPage.printResult(10);
            Console.WriteLine();
            Console.WriteLine("DONE");
            int cnt = countWord(askTerm);
            Console.WriteLine("\nNumber of found term '" + askTerm + "' equal " + cnt);
        }

        private int countWord(String text)
        {
            StringBuilder sb = new StringBuilder();
            //*Find from all stored data
            /*
            foreach (String[] line in firstResultPage) {
                foreach(String el in line) {
                    sb.Append(el.ToLower());
                }
            }
            foreach(String[] line in secondResultPage) {
                foreach(String el in line) {
                    sb.Append(el.ToLower());
                }
            }
            */            
            //*Find from only 'description'
            foreach (String[] line in firstResultPage)
            {
                sb.Append(line[2].ToLower());
            }
            foreach (String[] line in secondResultPage)
            {
                sb.Append(line[2].ToLower());
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine(sb);
            Console.WriteLine("--------------------------------");
            //*Search and count the number of times string appears
            int count = (sb.Length - sb.Replace(text, "").Length) / text.Length;
            return count;
        }
    }
}
