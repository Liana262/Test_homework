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
    /// Создание/редактирование/(возможно в будущем) удаление записей
    /// </summary>
    public class NoteHelper : HelperBase
    {
        public void CreateNote(NoteData note)
        {
            //driver.FindElement(By.Name("DiText")).Click();
            driver.FindElement(By.Id("DiText")).Click();
            driver.FindElement(By.Id("DiText")).Clear();
            driver.FindElement(By.Id("DiText")).SendKeys(note.Text);
            driver.FindElement(By.Name("Word[]")).Click();
            driver.FindElement(By.Name("Word[]")).Clear();
            if (note.KeyTag != null)
            { 
                driver.FindElement(By.Name("Word[]")).SendKeys(note.KeyTag); 
            }
            //driver.FindElement(By.Id("dop")).Click();
            //driver.FindElement(By.LinkText("Добавить фотографию")).Click();
            driver.FindElement(By.Id("btn_save")).Click();

        }

        /// <summary>
        /// Удаляет последнюю созданную заметку (он типа? просто перед первую на странице и не парится? крутой)
        /// </summary>
        public void DeleteNote() 
        {
            //driver.Navigate().GoToUrl("https://diary.anek.ws/?all=1");
            driver.FindElement(By.LinkText("Править")).Click();
            driver.FindElement(By.Id("DiText")).Click();
            acceptNextAlert = true;
            driver.FindElement(By.Id("DiText")).Clear();
            driver.FindElement(By.Id("DiText")).SendKeys("");
            driver.FindElement(By.Id("btn_save")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Ты хочешь безвозвратно удалить эту запись[\\s\\S]$"));
        }

        /// <summary>
        /// получаем данные из только что созданной заметки для asserts
        /// </summary>
        /// <returns></returns>
        public NoteData GetNoteData() 
        {
            string noteText = driver.FindElement(By.ClassName("dt")).Text;
            string key = driver.FindElement(By.ClassName("dkeys")).Text;
            //string pic = driver.FindElement(By.Name("group_footer")).Text;
            return new NoteData(noteText) { KeyTag = key };
        }

        /// <summary>
        /// Нахождение последней созданной заметки 
        /// по максимальному ID и нажатие кнопки "Править".
        /// Работает корректно (относительно правильности ID), если до начала теста заметок нет.
        /// </summary>
        public void SelectLastCreatedNote() 
        {
            string noteId;
            int max = 0;
            int temp;
            //лист из всех заметок
            var DitList = driver.FindElements(By.ClassName("dit"));

            // можно оставить так, даже если знаю что наибольший
            //айди у первого элемента в списке, но не знаю как достать?
            foreach (var note in DitList) 
            {
                //ID текущей заметки
                noteId = note.GetAttribute("Id");
                temp = Convert.ToInt32(noteId.Remove(0, 3)); //режем айди, потому что он выглядит так "dit******"
                if (temp > max)
                max = temp;//теперь это максимальный ID            
            }

            driver.FindElement(By.XPath($"//div[@id='dit{max}']/div/a")).Click();
        }

        /// <summary>
        /// Редактирует открытую с помощью Select заметку 
        /// </summary>
        public void EditNote() 
        {
            driver.FindElement(By.Id("DiText")).Click();
            driver.FindElement(By.Id("DiText")).SendKeys(" Текст для отредактированной заметки");
            driver.FindElement(By.Id("btn_save")).Click();
        }
        public NoteHelper(ApplicationManager manager)
            : base(manager)
        {
        }

    }
}
