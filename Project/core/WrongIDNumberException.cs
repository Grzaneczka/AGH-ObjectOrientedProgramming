using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class WrongIDNumberException : FormatException
    {
        readonly string idNumber;

        public WrongIDNumberException(string idNumber) : base("Invalid ID number: " + idNumber)
        {
            this.idNumber = idNumber;
        }

        public string IdNumber => idNumber;
    }
}
