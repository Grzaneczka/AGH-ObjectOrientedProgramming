using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project
{
    class Client : Person, IComparable
    {
        private static int idClient;
        private string email;

        // Konstruktory 

        static Client()
        {
            idClient = 1;
        }

        public Client(string name, string surname, string phone, Sex sex, string email, string idNumber) : base(name, surname, sex, phone, idNumber)
        {
            this.Email = email;
            idClient = idClient++;
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

        public int IdClient
        {
            get { return idClient; }
        }

        // Metody sprawdzające poprawność

        private static readonly Regex EmailRegex = new Regex(@"(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)");

        private bool ValidateEmail(string email)
        {
            Match match = EmailRegex.Match(email);

            if (!match.Success)
                return false;
            return true;
        }
         
        // Metody dodatkowe

        public virtual string FullName()
        {
            if (this.Sex == Sex.Man)
                return (string)("Pan " + this.Name + " " + this.Surname);
            else if (this.Sex == Sex.Woman)
                return (string)("Pani " + this.Name + " " + this.Surname);
            else 
                return (string)("Firma " + this.Name + " " + this.Surname);
        }

        // To string 

        public override string ToString()
        {
            return "Client: " + FullName() + " " + this.ID_numer + " " + this.Phone + " " + this.Email;
        }

        public int CompareTo(object obj)
        {
            Client client = obj as Client;

            if (obj is Client clientobj && client != null)
            {
                if (Surname.CompareTo(client.Surname) != 0)
                    return Surname.CompareTo(client.Surname);
                else if ((Name.CompareTo(client.Name) != 0))
                    return Name.CompareTo(client.Name);
                else
                    return idClient.CompareTo(client.IdClient);
            }
            return 0;
        }

    }
}
