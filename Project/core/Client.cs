using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
    class Client : Person
    {
        private string email;

        // Konstruktory

        public Client() : base()
        {

        }

        public Client(string name, string surname, string phone, Sex sex, string email, string idNumber) : base(name, surname, sex, phone, idNumber)
        {
            this.Email = email;
        }

        // Getery i Setery 

        public string Email
        {
            get { return email; }
            set
            {
                if (!ValidateEmail(value))
                    throw new WrongEmailException(value);
                email = value;
            }
        }

        // Metody sprawdzające poprawność

        private static readonly Regex EmailRegex = new Regex(@"(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)");

        private bool ValidateEmail(string email)
        {
            return EmailRegex.Match(email).Success;
        }
         
        // Metody dodatkowe

        public virtual string FullName()
        {
            if (this.Sex == Sex.Man)
                return (string)("Pan " + this.Name + " " + this.Surname);
            else 
                return (string)("Pani " + this.Name + " " + this.Surname);
        }

        // To string 

        public override string ToString()
        {
            return "Client: " + FullName() + " " + this.IDNumer + " " + this.Phone + " " + this.Email;
        }
    }
}
