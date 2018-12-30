using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class WrongID_numberException : FormatException
    {
        public WrongID_numberException(string iD_number) : base("Invalid ID number: " + iD_number) { }
    }
}
