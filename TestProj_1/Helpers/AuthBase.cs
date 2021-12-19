using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj_1
{
    class AuthBase : TestBase
    {
        AccountData user = new AccountData("liana.test", "1234test");
        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
            app.Navigation.OpenHomePage();
            app.Auth.Login(user);
        }

        public void Login()
        {
            AccountData user = new AccountData(Settings.Username, Settings.Password);
            app.Auth.Login(user);
        }

    }
}
