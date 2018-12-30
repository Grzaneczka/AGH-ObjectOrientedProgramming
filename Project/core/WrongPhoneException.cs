using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class WrongPhoneException : FormatException
    {
        public WrongPhoneException(string phone) : base("Invalid phone number: " + phone) { }
    }
}
