using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Learn_Specflow.Hooks;

namespace Learn_Specflow.Steps
{
    [Binding]
    public sealed class BasicFeatures
    {

        IWebDriver _driver;

        public BasicFeatures() => _driver = Hook1.GetDriver();

        [Given(@"I navigate to the URL")]
        public void GivenINavigateToTheURL()
        {
            _driver.Navigate().GoToUrl("https://www.thetechnicalpedia.com");
        }

       

    }
}
