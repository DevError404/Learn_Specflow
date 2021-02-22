using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Learn_Specflow.Hooks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace Learn_Specflow.Steps
{
    [Binding]
    public sealed class BasicFeatures
    {

        IWebDriver _driver;
        private String searchKeyword;
        public BasicFeatures() => _driver = Hook1.GetDriver();

        [Given(@"I navigate to the youtube URL")]
        public void GivenINavigateToTheURL()
        {
            _driver.Navigate().GoToUrl("https://www.youtube.com");
            Assert.IsTrue(_driver.Title.ToLower().Contains("youtube"));
        }

        [Given(@"I have entered (.*) as search keyword")]
        public void GivenIHaveEnteredApoorvaGuptaOfficialAsSearchKeyword(string strSearch)
        {
            this.searchKeyword = strSearch.ToLower();
            var searchInputBox = _driver.FindElement(By.Id("search"));
            searchInputBox.SendKeys(searchKeyword);
        }

        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            var searchButton = _driver.FindElement(By.CssSelector("button#search-icon-legacy"));
            searchButton.Click();
        }

        [Then(@"I should navigate to search results page")]
        public void ThenIShouldNavigateToSearchResultsPage()
        {
            Assert.IsTrue(_driver.Url.ToLower().Contains(searchKeyword));
            Assert.IsTrue(_driver.Title.ToLower().Contains(searchKeyword));
        }


    }
}
