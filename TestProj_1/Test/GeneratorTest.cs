using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TestProj_1
{
    [TestFixture]
    public class GeneratorNoteDataTest : TestBase
    {
        //Метод который вам нужен чтобы распарсить Xml

        public static IEnumerable<NoteData> NoteDataFromXmlFile()
        {
            return (List<NoteData>)new XmlSerializer(typeof(List<NoteData>))
                .Deserialize(new StreamReader(@"notes.xml"));
        }

        [Test, TestCaseSource("NoteDataFromXmlFile")]
        // вы параметром передаете список тестовых данных, которые распарсятся с помощью указанного метода. Вы можете использовать другой тип файла, например json. 

        public void TestMethod(NoteData note)
        //теперь в параметр теста приходят тестовые данные, которые будут использоваться.
        {

        }
    }
}
