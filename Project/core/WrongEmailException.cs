using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class WrongEmailException : FormatException
    {
        readonly string email;

        public WrongEmailException(string email) : base("Invalid email: " + email)
        {
            this.email = email;
        }

        public string Email => email;
    }
}
