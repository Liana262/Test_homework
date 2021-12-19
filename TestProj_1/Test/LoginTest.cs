using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj_1
{
    [TestFixture]
    public class LoginTest : TestBase
    {
        [Test]
        public void LoginWithInvalidData()
        {
            string invalid_data = GenerateRandomString(10);
            app.Navigation.OpenHomePage();
            AccountData user = new AccountData(invalid_data, invalid_data);
            app.Auth.Login(user);
            Assert.AreEqual(app.Driver.Url, "https://diary.anek.ws/");
        }

        [Test]
        public void LoginWithValidData()
        {
            app.Navigation.OpenHomePage();
            AccountData user = new AccountData(Settings.Username, Settings.Password);
            app.Auth.Login(user);
        }


    }
}
