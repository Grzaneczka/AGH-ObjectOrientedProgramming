using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project
{
    public enum Sex { Woman, Man, Company, Unknown }

    class Person
    {

        private string name;
        private string surname;
        private string iDNumber;  // Numer dowodu osobistego 
        private string phone;
        private Sex sex;

        // Konstruktory 

        public Person(string name, string surname, Sex sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.Sex = sex;
        }

        public Person(string name, string surname, Sex sex, string phone) : this(name, surname, sex)
        {
            this.Phone = phone;
        }

        public Person(string name, string surname, Sex sex, string phone, string iD_number) : this(name, surname, sex, phone)
        {
            this.ID_numer = iD_number;
        }

        // Getery i setery 

        public string Name { get => name; set => name = value; }

        public string Surname { get => surname; set => surname = value; }

        public string ID_numer
        {
            get { return iDNumber; }
            set
            {
                if (!ValidateID_number(value))
                    throw new WrongIDNumberException(value);
                iDNumber = value;
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                if (!ValidatePhone(value))
                    throw new WrongPhoneException(value);
                phone = value;
            }
        }

        public Sex Sex { get => sex; set => sex = value; }

        // Metody dodatkowe - sprawdzające poprawność

        private static readonly Regex ID_numberRegex = new Regex(@"([A-Z]{3})(\s)(\d{6})");

        private static bool ValidateID_number(string iD_number)
        {
            Match match = ID_numberRegex.Match(iD_number);

            if (!match.Success)
                return false;
            return true;
        }

        private static readonly Regex PhoneRegex = new Regex(@"(\d{3}-\d{3}-\d{3})");

        private static bool ValidatePhone(string phone)
        {
            Match match = PhoneRegex.Match(phone);

            if (!match.Success)
                return false;
            return true;
        }

        // To string 

        public override string ToString()
        {
            return this.name + " " + this.surname + " " + this.phone + " " + this.sex + " " + this.iDNumber;
        }
    }
}
