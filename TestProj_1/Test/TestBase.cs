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
    /// Родитель тестов.
    /// Основной класс для тестов, сейчас должны остаться только автоматически созданные методы
    /// </summary>
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int length)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(26 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            return str_build.ToString();
        }

        public static string GenerateRandomDay()
        {
            Random rand = new Random();
            int randInt = rand.Next(19, 27); //циферки че как такие же оставлять?
            return randInt.ToString();
        }

    }
}
