using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class WrongPhoneException : FormatException
    {
        readonly string phone;

        public WrongPhoneException(string phone) : base("Invalid phone number: " + phone)
        {
            this.phone = phone;
        }

        public string Phone => phone;
    }
}
