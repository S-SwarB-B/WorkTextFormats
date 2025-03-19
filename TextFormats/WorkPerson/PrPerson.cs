using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFormats.WorkPerson
{
    public class PrPerson
    {
        public void PrintClassPerson(Person[]? person) //Метод вывода пользователей из структуры на консоль
        {
            for (int i = 0; i < person.Length; i++)
            {
                Console.WriteLine($"{person[i].Id} - {person[i].Name}\n" + //Перевод в строки файла в удобную для пользователя форму
                    $"Роль - {person[i].Role}\n" +
                    $"Дата регистрации - {person[i].Date_Reg}\n" +
                    $"Текущая активность - {person[i].Activity}\n");
            }
        }
    }
}
