using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFormats.NavigateFormats;
using TextFormats.WorkPerson;


namespace TextFormats.NavigateFormats.TXT_Format
{
    public class NavigateTXT
    {
        public void WorkTXT(string path) //Метод навигации для формата TXT
        {
            int Error = 1; //Переменная ошибки
            NavigateProgram navigateProgram = new NavigateProgram(); //Вызов навигационного интерфейса
            navigateProgram.NavigateInterface();
            CommonTextFormat commonTextFormat = new CommonTextFormat(); //Считывание файла
            Person[]? person = commonTextFormat.GeneralizedMethodReading(path);
            string? TXT_Button = Console.ReadLine();
            if (TXT_Button == "1") //Вывод данных файла на консоль
            {
                PrPerson prPerson = new PrPerson(); //Вызов класса записи на консоль
                prPerson.PrintClassPerson(person);
            }
            else if (TXT_Button == "2") //Запись в файл через консоль
            {      
                Console.Write("Имя: "); //Ввод имени
                string? Name = Console.ReadLine();
                Console.Write("Роль: "); //Ввод роли
                string? Role = Console.ReadLine();
                Console.Write("Дата регистрации: "); //Ввод даты
                string? Date_Reg = Console.ReadLine();
                Console.Write("Активность: "); //Ввод активности
                string? Activity = Console.ReadLine();
                Person pers = new Person(0,Name,Role,Date_Reg,Activity); //Запись в файл
                Error = commonTextFormat.GeneralizedMethodWriting(path, pers);
            }
            else if (TXT_Button == "3") //Сортировка данных файла по выбранному полю
            {
                Person[] pers = commonTextFormat.GeneralizedSortTextFormat(path, person);
                PrPerson prPerson = new PrPerson();
                prPerson.PrintClassPerson(pers);
            }
            else if (TXT_Button == "4") //Поиск данных файла по введенной подстроке
            {
                string? str = Console.ReadLine();
                Error = commonTextFormat.GeneralizedStringCheck(str,person);
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
