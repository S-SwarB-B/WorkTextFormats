using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextFormats.WorkPerson;

namespace TextFormats.NavigateFormats.TXT_Format
{
    public class CommonTextFormat
    {
        public Person[]? GeneralizedMethodReading(string path) //Общий метод считывания файла
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

                using (StreamReader sw = new StreamReader(path)) //Второе считывание файла (для заполнения массива сруктур)
                {
                    string? line; //Строка файла
                    string[] words; //Массив строк (для записи в структуру)
                    i = 0;
                    while ((line = sw.ReadLine()) != null) //Цикл для заполнения
                    {
                        words = line.Split(';'); //Разделение строки на слова
                        Person person = new Person(Convert.ToInt32(words[0]), words[1], words[2], words[3], words[4]); //Запись в структуру
                        persons[i] = person; //Передача структуры в массив структур
                        i++; //Счетчик +1
                    }
                }
                return persons; //Возврат массива структур
            }
            catch
            {
                return null; //При ошибке вернется пустое значение
            }
        }

        public int GeneralizedMethodWriting(string path, Person person) //Общий метод записи в файл
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
        public int GeneralizedStringCheck(string? str, Person[]? person) //Обший метод поиска строки по всем полям
        {
            try //Обработчик исключений
            {
                for (int i = 0; person.Length > i; i++)
                {
                    if (Convert.ToString(person[i].Id).Contains(str))
                    {
                        Console.WriteLine($"{person[i].Id} - {person[i].Name}\n" + //Перевод в строки файла в удобную для пользователя форму
                        $"Роль - {person[i].Role}\n" +
                        $"Дата регистрации - {person[i].Date_Reg}\n" +
                        $"Текущая активность - {person[i].Activity}\n");
                    }
                    else if (person[i].Name.Contains(str))
                    {
                        Console.WriteLine($"{person[i].Id} - {person[i].Name}\n" + //Перевод в строки файла в удобную для пользователя форму
                        $"Роль - {person[i].Role}\n" +
                        $"Дата регистрации - {person[i].Date_Reg}\n" +
                        $"Текущая активность - {person[i].Activity}\n");
                    }
                    else if (person[i].Role.Contains(str))
                    {
                        Console.WriteLine($"{person[i].Id} - {person[i].Name}\n" + //Перевод в строки файла в удобную для пользователя форму
                        $"Роль - {person[i].Role}\n" +
                        $"Дата регистрации - {person[i].Date_Reg}\n" +
                        $"Текущая активность - {person[i].Activity}\n");
                    }
                    else if (person[i].Date_Reg.Contains(str))
                    {
                        Console.WriteLine($"{person[i].Id} - {person[i].Name}\n" + //Перевод в строки файла в удобную для пользователя форму
                        $"Роль - {person[i].Role}\n" +
                        $"Дата регистрации - {person[i].Date_Reg}\n" +
                        $"Текущая активность - {person[i].Activity}\n");
                    }
                    else if (person[i].Activity.Contains(str))
                    {
                        Console.WriteLine($"{person[i].Id} - {person[i].Name}\n" + //Перевод в строки файла в удобную для пользователя форму
                        $"Роль - {person[i].Role}\n" +
                        $"Дата регистрации - {person[i].Date_Reg}\n" +
                        $"Текущая активность - {person[i].Activity}\n");
                    }
                }
                return 1; //Если прошло все хорошо, то вернется 1 (true)
            }
            catch
            { 
                return 0; //Если прошло все плохо, то вернется 0 (false)
            }
        }
        public Person[] GeneralizedSortTextFormat(string? path, Person[]? person) //Общий метод сортировки
        {
            try //Обработка исключений
            {
                NavigateProgram navigateProgram = new NavigateProgram();
                navigateProgram.SortInterface(); //Вызов сортировочного интерфейса
                string? SortButton = Console.ReadLine(); //Кнопка взаимодействия пользователя с консолью
                if (SortButton == "1") 
                {
                    navigateProgram.SortInterfaceStatus(); //Вызов выбора вида сортировки
                    string? SortButtonStatus = Console.ReadLine();
                    if (SortButtonStatus == "1") //Сортировка по возрастанию
                    {
                        person = person.OrderBy(x => x.Id).ToArray();
                    }
                    else if (SortButtonStatus == "2") //Сортировка по убыванию
                    {
                        person = person.OrderBy(x => x.Id).ToArray();
                        person = person.Reverse().ToArray();
                    }
                    else
                    {
                        Console.WriteLine("Неверное число"); //Неправильный вызов в консоли
                    }
                }
                else if (SortButton == "2") //Аналогично с предыдыщим условием //
                {                                                              //
                    navigateProgram.SortInterfaceStatus();                     //
                    string? SortButtonStatus = Console.ReadLine();             //
                    if (SortButtonStatus == "1")                               //
                    {                                                          //
                        person = person.OrderBy(x => x.Name).ToArray();        //
                    }                                                          //
                    else if (SortButtonStatus == "2")                          //
                    {                                                          //
                        person = person.OrderBy(x => x.Name).ToArray();        //
                        person = person.Reverse().ToArray();                   //
                    }                                                          //
                    else                                                       //
                    {                                                          //
                        Console.WriteLine("Неверное число");                   //
                    }                                                          //
                }                                                              //
                else if (SortButton == "3")                                    //
                {                                                              //
                    navigateProgram.SortInterfaceStatus();                     //
                    string? SortButtonStatus = Console.ReadLine();             //
                    if (SortButtonStatus == "1")                               //
                    {                                                          //
                        person = person.OrderBy(x => x.Role).ToArray();        //
                    }                                                          //
                    else if (SortButtonStatus == "2")                          //
                    {                                                          //
                        person = person.OrderBy(x => x.Role).ToArray();        //
                        person = person.Reverse().ToArray();                   //
                    }                                                          //
                    else                                                       //
                    {                                                          //
                        Console.WriteLine("Неверное число");                   //
                    }                                                          //
                }                                                              //
                else if (SortButton == "4")                                    //
                {                                                              //
                    navigateProgram.SortInterfaceStatus();                     //
                    string? SortButtonStatus = Console.ReadLine();             //
                    if (SortButtonStatus == "1")                               //
                    {                                                          //
                        person = person.OrderBy(x => x.Date_Reg).ToArray();    //
                    }                                                          //
                    else if (SortButtonStatus == "2")                          //
                    {                                                          //
                        person = person.OrderBy(x => x.Date_Reg).ToArray();    //
                        person = person.Reverse().ToArray();                   //
                    }                                                          //
                    else                                                       //
                    {                                                          //
                        Console.WriteLine("Неверное число");                   //
                    }                                                          //
                }                                                              //
                else if (SortButton == "5")                                    //
                {                                                              //
                    navigateProgram.SortInterfaceStatus();                     //
                    string? SortButtonStatus = Console.ReadLine();             //
                    if (SortButtonStatus == "1")                               //
                    {                                                          //
                        person = person.OrderBy(x => x.Activity).ToArray();    //
                    }                                                          //
                    else if (SortButtonStatus == "2")                          //
                    {                                                          //
                        person = person.OrderBy(x => x.Activity).ToArray();    //
                        person = person.Reverse().ToArray();                   //
                    }                                                          //
                    else                                                       //
                    {                                                          //
                        Console.WriteLine("Неверное число");                   //
                    }                                                          //
                }                                                              //
                else
                {
                    Console.WriteLine("Неверное число"); //Неправильный вызов в консоли
                }
                return person; //Возврат нового массива структур
            }
            catch
            {
                return person; //Возврат старого массива структур
            }
        }
    }
}
