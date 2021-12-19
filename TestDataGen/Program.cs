using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProj_1;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace TestDataGen
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            if (type == "groups")
            {
                GenerateForNotes(count, filename, format);
            }
            else
            {
                System.Console.Out.Write("Unrecognized type of data" + type);
            }
        }

        static void GenerateForNotes(int count, string filename, string format)
        {
            List<NoteData> notes = new List<NoteData>();
            for (int i = 0; i < count; i++)
            {
                notes.Add(new NoteData(TestBase.GenerateRandomString(10))
                {
                    KeyTag = TestBase.GenerateRandomString(20),
                });
            }
            StreamWriter writer = new StreamWriter(filename);
            if (format == "xml")
            {
                writer = new StreamWriter(filename);
                WriteNotesToXmlFile(notes, writer);

            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
            writer.Close();
        }

        static void WriteNotesToXmlFile(List<NoteData> notes, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<NoteData>)).Serialize(writer, notes);
        }
    }
}