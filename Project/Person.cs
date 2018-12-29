using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project
{
    public enum Sex { Woman, Man, Company }

    class Person
    {

        private string name;
        private string surname;
        private string iD_number;  // Numer dowodu osobistego 
        private string phone;
        private Sex sex;

        // Konstruktory 

        public Person(string name, string surname, Sex sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.Sex = sex;
        }

        public Person(string name, string surname, string phone, Sex sex) : this(name, surname, sex)
        {
            this.Phone = phone;
        }

        public Person(string name, string surname, string phone, Sex sex, string iD_number) : this(name, surname, phone, sex)
        {
            this.ID_numer = iD_number;
        }

        // Getery i setery 

        public string Name { get => name; set => name = value; }

        public string Surname { get => surname; set => surname = value; }

        public string ID_numer
        {
            get { return iD_number; }
            set
            {
                if (!validateID_number(value))
                    throw new WrongID_numberException(value);
                iD_number = value;
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                if (!validatePhone(value))
                    throw new WrongPhoneException(value);
                phone = value;
            }
        }

        public Sex Sex { get => sex; set => sex = value; }

        // To string 

        public override string ToString()
        {
            return this.name + " " + this.surname + " " + this.phone + " " + this.sex + " " + this.iD_number;
        }

        // Metody sprawdzające poprawność

        private static readonly Regex ID_numberRegex = new Regex(@"([A-Z]{3})(\s)(\d{6})");

        private bool validateID_number(string iD_number)
        {
            Match match = ID_numberRegex.Match(iD_number);

            if (!match.Success)
                return false;
            return true;
        }

        private static readonly Regex PhoneRegex = new Regex(@"(\d{3}-\d{3}-\d{3})");

        private bool validatePhone(string phone)
        {
            Match match = PhoneRegex.Match(phone);

            if (!match.Success)
                return false;
            return true;
        }
    }
}
