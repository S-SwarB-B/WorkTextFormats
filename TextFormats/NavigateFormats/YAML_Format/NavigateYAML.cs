using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFormats.NavigateFormats.XML_Format;
using TextFormats.NavigateFormats.YAML_Format;
using TextFormats.WorkPerson;

namespace TextFormats.NavigateFormats.TXT_Format
{
    public class NavigateYAML
    {
        public void WorkYAML(string path)
        {
            int Error = 1; //Переменная ошибки
            NavigateProgram navigateProgram = new NavigateProgram(); //Вызов навигационного интерфейса
            navigateProgram.NavigateInterface();
            string? YAML_Button = Console.ReadLine();
            CommonTextFormat commonTextFormat = new CommonTextFormat();
            YAMLTextFormat yAMLTextFormat = new YAMLTextFormat();
            Person[]? person = yAMLTextFormat.YamlMethodReading(path);
            if (YAML_Button == "1")
            {
                PrPerson prPerson = new PrPerson(); //Вызов класса записи на консоль
                prPerson.PrintClassPerson(person);
            }
            else if (YAML_Button == "2")
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
                Error = yAMLTextFormat.YamlMethodWriting(path,pers);
            }
            else if (YAML_Button == "3") //Сортировка данных файла по выбранному полю
            {
                Person[] pers = commonTextFormat.GeneralizedSortTextFormat(path, person);
                PrPerson prPerson = new PrPerson();
                prPerson.PrintClassPerson(pers);
            }
            else if (YAML_Button == "4") //Поиск данных файла по введенной подстроке
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