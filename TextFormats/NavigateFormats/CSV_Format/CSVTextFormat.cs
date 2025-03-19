using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFormats.WorkPerson;
using System.Globalization;
using System.Collections;
using Microsoft.VisualBasic.FileIO;

namespace TextFormats.NavigateFormats.CSV_Format
{
    public class CSVTextFormat
    {
        public Person[]? CsvMethodReading(string path) //CSV метод считывания файла
        {
            try //Обработка исключений
            {
                int i = 0; //Подключение счетчика
                using (StreamReader sr = new StreamReader(path)) //Первое считывание файла (для подсчета количества строк)
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)  //Цикл для подсчета
                    {
                        i++; //Счетчик +1
                    }
                }

                Person[] persons = new Person[i]; //Создание массива структур (размер зависит от количества строк)

                using (TextFieldParser parser = new TextFieldParser(path)) //Второе считывание файла (для заполнения массива сруктур)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    i = 0;
                    while (!parser.EndOfData) //Цикл для заполнения церез parser
                    {
                        string[]? words = parser.ReadFields();
                        Person person = new Person(Convert.ToInt32(words[0]), words[1], words[2], words[3], words[4]);
                        persons[i] = person;
                        i++;
                    }
                }            
                return persons; //Возврат массива структур
            }
            catch
            {
                return null; //При ошибке вернется пустое значение
            }
        }

        public int CsvMethodWriting(string path, Person person) //Общий метод записи в файл
        {
            try //Обработка исключений
            {
                int count = 0; //Подключение счетчика
                using (StreamReader sr = new StreamReader(path)) //Считывание файла (для подсчета количества строк)
                {
                    while (sr.ReadLine() != null) //Цикл для подсчета
                    {
                        count++; //Счетчик +1
                    }
                }

                string StrWrite = $"{count + 1};{person.Name};{person.Role};{person.Date_Reg};{person.Activity}"; //Строка, с помощью которой будет производится запись в файл

                using (StreamWriter sw = new StreamWriter(path, true)) //Запись в файл
                {
                    sw.WriteLineAsync(StrWrite); //Запись в файл
                }
                return 1; //Если прошло все хорошо, то вернется 1 (true)
            }
            catch
            {
                return 0; //Если прошло все плохо, то вернется 0 (false)
            }
        }
    }
}
