using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project
{
    public enum Sex { Woman, Man, Company, Unknown }

    [Serializable]
    abstract class Person : IComparable<Person>
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

        public Person(string name, string surname, Sex sex, string phone, string idNumber) : this(name, surname, sex, phone)
        {
            this.IDNumer = idNumber;
        }

        // Getery i setery 

        public string Name { get => name; set => name = value; }

        public string Surname { get => surname; set => surname = value; }

        public string IDNumer
        {
            get { return iDNumber; }
            set
            {
                if (!ValidateIDNumber(value))
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
       
        // Metoda porównująca 

        public int CompareTo(Person other)
        {
            if (this.surname == other.surname)
                return this.name.CompareTo(other.name);
            else
                return this.surname.CompareTo(other.surname);
        }

        // Metody dodatkowe - sprawdzające poprawność

        private static readonly Regex ID_NUMBER_REGEX = new Regex(@"([A-Z]{3})(\s)(\d{6})");

        private static bool ValidateIDNumber(string iD_number)
        {
            return ID_NUMBER_REGEX.Match(iD_number).Success;
        }

        private static readonly Regex PHONE_REGEX = new Regex(@"(\d{3}-\d{3}-\d{3})");

        private static bool ValidatePhone(string phone)
        {
            return PHONE_REGEX.Match(phone).Success;
        }

        // To string 

        public override string ToString()
        {
            return this.name + " " + this.surname + " " + this.phone + " " + this.sex + " " + this.iDNumber;
        }

    }
}
