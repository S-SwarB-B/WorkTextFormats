using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFormats.NavigateFormats.JSON_Format;
using TextFormats.NavigateFormats.XML_Format;
using TextFormats.WorkPerson;

namespace TextFormats.NavigateFormats.TXT_Format
{
    public class NavigateXAML
    {
        public void WorkXAML(string path)
        {
            int Error = 1; //Переменная ошибки
            NavigateProgram navigateProgram = new NavigateProgram(); //Вызов навигационного интерфейса
            navigateProgram.NavigateInterface();
            string? XML_Button = Console.ReadLine();
            CommonTextFormat commonTextFormat = new CommonTextFormat();
            XMLTextFormat xMLTextFormat = new XMLTextFormat();
            Person[]? person = xMLTextFormat.XMLMethodReading(path);
            if (XML_Button == "1")
            {
                PrPerson prPerson = new PrPerson(); //Вызов класса записи на консоль
                prPerson.PrintClassPerson(person);
            }
            else if (XML_Button == "2")
            {
                Console.Write("Имя: "); //Ввод имени
                string? Name = Console.ReadLine();
                Console.Write("Роль: "); //Ввод роли
                string? Role = Console.ReadLine();
                Console.Write("Дата регистрации: "); //Ввод даты
                string? Date_Reg = Console.ReadLine();
                Console.Write("Активность: "); //Ввод активности
                string? Activity = Console.ReadLine();
                Person pers = new Person(0, Name, Role, Date_Reg, Activity); //Запись в файл
                Error = xMLTextFormat.XMLMethodWriting(path, pers);
            }
            else if (XML_Button == "3") //Сортировка данных файла по выбранному полю
            {
                Person[] pers = commonTextFormat.GeneralizedSortTextFormat(path, person);
                PrPerson prPerson = new PrPerson();
                prPerson.PrintClassPerson(pers);
            }
            else if (XML_Button == "4") //Поиск данных файла по введенной подстроке
            {
                string? str = Console.ReadLine();
                Error = commonTextFormat.GeneralizedStringCheck(str, person);
            }
            else
            {
                Console.WriteLine("Неправильный символ"); //Неправильно введенный символ
            }
            if (Error == 0)
            {
                Console.WriteLine("Error -_-"); //На случай ошибки
            }
        }
    }
}
