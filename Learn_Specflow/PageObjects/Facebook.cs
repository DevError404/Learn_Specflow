using Learn_Specflow.Hooks;
using Learn_Specflow.CustomMethods ;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn_Specflow.Config;

namespace Learn_Specflow.PageObjects
{
    class Facebook
    {
        private IWebDriver _driver;

        public Facebook() => _driver = Hook1.GetDriver();

        IWebElement EmailTextBox => _driver.FindElement(By.Id("email"));
        IWebElement PasswordTextBox => _driver.FindElement(By.Id("passContainer"));

        public void EnterCredential(string email, string password)
        {
            EmailTextBox.EnterText(email);
            PasswordTextBox.Clicks();
        }
    }
}
