using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public enum Type { Create_Reserwation, Check_In, Check_Out, Extend_Reservations, Canceled_Reservations,  Cleaning, Create_Room, Create_Client, Create_Emplyee, Restor_Canceled_Reservation, Other }

    [Serializable]
    class Log
    {
        private DateTime date;
        private Employee employee;
        private Type type;
        private string contents;

        // Konstruktury 

        internal Log(Employee employee, Type type, string contents)
        {
            this.date = DateTime.Now;
            this.employee = employee;
            this.type = type;
            this.contents = contents;
        }

        // Getery i Setery 

        public DateTime Date { get => date; set => date = value; }

        public Type Type { get => type; set => type = value; }

        public string Contents { get => contents; set => contents = value; }

        internal Employee Employee { get => employee; set => employee = value; }

        // To String 

        public override string ToString()
        {
            return "Pracownik " + this.Employee.ToString() + " " + this.contents;
        }

    }
}
