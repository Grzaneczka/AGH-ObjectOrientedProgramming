using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class WrongCheckInException : Exception
    {
        public WrongCheckInException() : base("Advance not paid ")
        {

        }
    }
}
