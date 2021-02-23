using Learn_Specflow.Hooks;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_Specflow.CustomMethods
{
    class SeleniumGetMethods
    {
        private IWebDriver driver;

        public SeleniumGetMethods()
        {
            this.driver = Hook1.GetDriver();
        }

        //Return the current URL of the page
        public string GetURL()
        {
            return driver.Url;
        }

        //This function only switches the frames 
        public void SwitchFrame(string tabName)
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(tabName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //method for switching to recent Popup
        public void SwitchToNewWindowPopup()
        {
            string newTabHandle = driver.WindowHandles.Last();
            var newTab = driver.SwitchTo().Window(newTabHandle);
        }

        //method for go back to previous window
        public void getBackToPreviousWindow()
        {
            try
            {
                driver.SwitchTo().Window(driver.WindowHandles.First());
                driver.SwitchTo().DefaultContent();
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

       
    }
}
