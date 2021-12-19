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
    [TestFixture]
    public class TestCase : TestBase
    {
        //AccountData user = new AccountData("liana.test", "1234test");
        NoteData note1 = new NoteData("Hello World!!!:8/:8/:8/ первая автозапись") { KeyTag ="hello" };
        NoteData note2 = new NoteData("Вторая автозапись edit") { KeyTag ="hello2" };
        NoteData note3 = new NoteData("Третья и последняя автозапись! delete") { KeyTag ="hello2" };
        //[Test]
        //public void AuthTest()
        //{
        //    app.Navigation.OpenHomePage();
        //    app.Auth.Login(user);

        //}
        [Test]
        public void CreateNoteTest()
        {
            app.Note.CreateNote(note1);
            Thread.Sleep(2000);
            app.Note.CreateNote(note2);
            Thread.Sleep(2000);
            app.Note.CreateNote(note3);
            Thread.Sleep(2000);


            app.Navigation.OpenAllNotesPage();
            //проверка, что последняя заметка (сейчас это третья) создалась корректно
            NoteData newnote = app.Note.GetNoteData();
            //Console.WriteLine(newnote.Text);
            //Console.WriteLine(newnote.KeyTag);
            Assert.AreEqual(note3.Text, newnote.Text);
            Assert.AreEqual(note3.KeyTag, newnote.KeyTag);

        }

        [Test]
        public void DeleteNoteTest()
        {
            app.Navigation.OpenAllNotesPage();
            app.Note.DeleteNote();
        }

        [Test]
        public void EditLastCreatedNoteTest()
        {
            app.Navigation.OpenAllNotesPage();
            app.Note.SelectLastCreatedNote(); //Находит последнюю заметку, и открывает в режиме редактирования
            app.Note.EditNote(); //добавляет текст и сохраняет заметку 

            app.Navigation.OpenAllNotesPage();
            //проверка, что последняя заметка (уже вторая, а не третья, так как было удаление) отредактировалась
            NoteData newnote = app.Note.GetNoteData();
            Assert.AreEqual(note2.Text + " Текст для отредактированной заметки", newnote.Text);
            Assert.AreEqual(note2.KeyTag, newnote.KeyTag);
        }

        [Test]
        public void LogoutTest()
        {
            //Thread.Sleep(5000);
            app.Auth.Logout();

        }


    }
}
