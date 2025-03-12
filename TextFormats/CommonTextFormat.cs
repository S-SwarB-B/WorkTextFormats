using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextFormatsPersons;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextFormatsTXT
{
    public class CommonTextFormat
    {
        public Persons[] PersonReadInStruct(string path)
        {
            Persons[]? per = new Persons[20];
            int ID;
            string Name;
            string Role;
            string Date;
            string Active;
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(';');
                    ID = int.Parse(words[0]);
                    Name = words[1];
                    Role = words[2];
                    Date = words[3];
                    Active = words[4];
                    Persons person = new Persons(ID, Name, Role, Date, Active);
                    per.Append(person);     
                }
                return per;
            }
        }
        public void CommonReadFile()
        {
            Persons[] persons = PersonReadInStruct(@"1.txt");
            for (int i = 0; i < persons.Length; i++)
            {
                Persons person = persons[i];
                Console.WriteLine(person.ToString);
            }
        }
    }
}
