using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]

    public class Employee : Person
    {
        private string function;

        // Konstruktory 

        public Employee() : base()
        {

        }

        public Employee(string name, string surname, string phone, Sex sex, string function) : base(name, surname, sex, phone)
        {
            this.Function = function;
        }

        // Getery i Setery 

        public string Function { get => function; set => function = value; }

        // To string 

        public override string ToString()
        {
            return base.ToString() + " " + this.function;
        }

    }
}
