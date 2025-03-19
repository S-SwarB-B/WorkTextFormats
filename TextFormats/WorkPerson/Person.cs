using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFormats.WorkPerson
{
    public class Person
    {
        public int Id { get; set; } //ID пользователя
        public string? Name { get; set; } //Имя пользователя
        public string? Role { get; set; } //Роль пользователя
        public string? Date_Reg { get; set; } //Дата регистрации пользователя
        public string? Activity { get; set; } //Активность пользователя

        public Person(int id, string? name, string? role, string? date_Reg, string? activity) //Конструктор записи пользователя
        {
            Id = id;
            Name = name;
            Role = role;
            Date_Reg = date_Reg;
            Activity = activity;
        }
    }
}
