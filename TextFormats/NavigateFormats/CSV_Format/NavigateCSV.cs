using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFormats.NavigateFormats.CSV_Format;
using TextFormats.WorkPerson;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextFormats.NavigateFormats.TXT_Format
{
    public class NavigateCSV
    {
        public void WorkCSV(string path)
        {
            int Error = 1;
            NavigateProgram navigateProgram = new NavigateProgram();
            navigateProgram.NavigateInterface();
            string? CSV_Button = Console.ReadLine();
            CSVTextFormat cSVTextFormat = new CSVTextFormat();
            CommonTextFormat commonTextFormat = new CommonTextFormat();
            Person[]? person = cSVTextFormat.CsvMethodReading(path);
            if (CSV_Button == "1")
            {
                PrPerson pers = new PrPerson();
                pers.PrintClassPerson(person);
            }
            else if (CSV_Button == "2")
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
                Error = cSVTextFormat.CsvMethodWriting(path, pers);
            }
            else if (CSV_Button == "3") //Сортировка данных файла по выбранному полю
            {
                Person[] pers = commonTextFormat.GeneralizedSortTextFormat(path, person);
                PrPerson prPerson = new PrPerson();
                prPerson.PrintClassPerson(pers);
            }
            else if (CSV_Button == "4") //Поиск данных файла по введенной подстроке
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
