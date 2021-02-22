using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_Specflow.Config
{
    static class SeleniumSetMethods
    {
        public static void EnterText(this IWebElement element, string value)
        {
            try
            {
                element.SendKeys(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //This is a extension method for clicking button
        public static void Clicks(this IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        //This is Extention method to return what is the text in side the TextBox
        public static string GetTextBoxText(this IWebElement element)
        {
            try
            {
                string str2 = element.GetAttribute("value");
                return str2;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }

        }
    }
}
