using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFormatsPersons
{
    public struct Persons
    {
        int ID { get; set; }
        string Name { get; set; }
        string Role {  get; set; }
        string DateReg {  get; set; }
        string Active { get; set; }

        public Persons(int ID, string Name, string Role, string Date,string Active) { 
            this.ID = ID;
            this.Name = Name;
            this.Role = Role;
            this.DateReg = Date;
            this.Active = Active;
        }
        
        public void PrintPerson()
        {
            Console.WriteLine($"{ID} {Name} {Role} {DateReg} {Active}");
        }
    }
}
