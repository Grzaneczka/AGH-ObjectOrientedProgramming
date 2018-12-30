using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project
{
    class Client : Person
    {
        private string email;

        // Konstruktory 

        public Client(string name, string surname, string phone, Sex sex, string email, string idNumber) : base(name, surname, phone, sex, idNumber)
        {
            this.Email = email;
        }

        // Getery i Setery 

        public string Email
        {
            get { return email; }
            set
            {
                if (!validateEmail(value))
                    throw new WrongEmailException(value);
                email = value;
            }
        }

        // To string 

        public override string ToString()
        {
            return "Client: " + FullName() + " " + this.ID_numer + " " + this.Phone + " " + this.Email;
        }

        // Metody sprawdzające poprawność

        private static readonly Regex EmailRegex = new Regex(@"(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)");

        private bool validateEmail(string email)
        {
            Match match = EmailRegex.Match(email);

            if (!match.Success)
                return false;
            return true;
        }
         
        // Metoda Pełna nazwa 

        public virtual string FullName()
        {
            if (this.Sex == Sex.Man)
                return (string)("Pan " + this.Name + " " + this.Surname);
            else
                return (string)("Pani " + this.Name + " " + this.Surname);
        }
    }
}
