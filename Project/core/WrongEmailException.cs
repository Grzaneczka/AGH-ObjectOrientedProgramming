using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class WrongEmailException : FormatException
    {
        public WrongEmailException(string email) : base("Invalid email: " + email) { }
    }
}
