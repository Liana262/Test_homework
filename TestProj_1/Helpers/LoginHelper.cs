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
    /// Все что связано с входом/выходом
    /// </summary>
    public class LoginHelper : HelperBase
    {
        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                {
                    return;
                }
                Logout();
            }

            driver.FindElement(By.Id("Nik")).Clear();
            driver.FindElement(By.Id("Nik")).SendKeys(user.Username);
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(user.Password);
            driver.FindElement(By.Id("login_subm")).Click();
        }

        public void Logout() 
        {
            driver.FindElement(By.LinkText("Выйти")).Click();
        }

        public bool IsLoggedIn()
        {
            manager.Navigation.OpenHomePage();
            Thread.Sleep(150);
            if (driver.Url == "https://diary.anek.ws/login/") //тут должна быть другая проверка, сам url никак не изменяется, если пользователь залогинен
                                                              //это в коде страницы прописывается где-то в js
            {
                return false;
            }
            return true;
        }
        
        public bool IsLoggedIn(string username)
        {
            manager.Navigation.OpenHomePage();
            driver.FindElement(By.LinkText("Настройки")).Click();
            if (username != driver.FindElement(By.XPath("//*[@id='Nik']")).Text)
            {
                return false;
            }
            return true;
        }


        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }

    }
}
