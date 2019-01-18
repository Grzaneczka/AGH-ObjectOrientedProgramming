using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public enum LogType { CREATE_RESERWATION, CHECK_IN, CHECK_OUT, EXTEND_RESERVATIONS, CANCELED_RESERVATIONS, CLEANING, CREATE_ROOM, CREATE_CLIENT, CREATE_EMPLYEE, RESTOR_CANCELED_RESERVATION, OTHER }

    [Serializable]

    public class Log
    {
        private DateTime date;
        private Employee employee;
        private LogType type;
        private string contents;

        // Konstruktury 

        public Log()
        {

        }

        public Log(Employee employee, LogType type, string contents)
        {
            this.date = DateTime.Now;
            this.employee = employee;
            this.type = type;
            this.contents = contents;
        }

        // Getery i Setery 

        public DateTime Date { get => date; set => date = value; }

        public LogType Type { get => type; set => type = value; }

        public string Contents { get => contents; set => contents = value; }

        public Employee Employee { get => employee; set => employee = value; }

        // To String 

        public override string ToString()
        {
            return "Pracownik " + this.Employee.ToString() + " " + this.contents;
        }

    }
}
