using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProj_1
{
    /// <summary>
    /// Все что связано с перемещением между страницами, навигацией
    /// </summary>
    public class NavigationHelper : HelperBase
    {
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://diary.anek.ws/");
        }

        public void OpenAllNotesPage() 
        {
            driver.FindElement(By.LinkText("Все записи")).Click();
        }
        public void OpenPage(string link)
        {
            driver.Navigate().GoToUrl(link);
        }

        private string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL)
                    : base(manager)
        {
            this.baseURL = baseURL;
        }

    }
}
