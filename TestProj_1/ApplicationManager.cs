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
    /// Класс, управляющим всеми
    /// </summary>
    public class ApplicationManager
    {
        public IWebDriver Driver { get { return driver; } }
        public NavigationHelper Navigation { get { return navigation; } }
        public LoginHelper Auth { get { return auth; } }
        public NoteHelper Note { get { return note; } }

        private IWebDriver driver; 
        private StringBuilder verificationErrors;
        private string baseURL;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private NoteHelper note;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager() 
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
            note = new NoteHelper(this);
            auth = new LoginHelper(this);
            navigation = new NavigationHelper(this, baseURL);
        }

       /// <summary>
       /// Деструктор
       /// </summary>
        ~ApplicationManager() 
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                //ignore
            }

        }

        public static ApplicationManager GetInstance()
        {
            //проверяем, создан ли уже экземпляр менеджера или нет
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public void Stop()
        {
            driver.Quit();
        }

        
       // private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

    }
}
