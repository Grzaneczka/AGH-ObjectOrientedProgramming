using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class WrongCheckInException : Exception
    {
        public WrongCheckInException() : base("Advance not paid ")
        {

        }
    }
}
