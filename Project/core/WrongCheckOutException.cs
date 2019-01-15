using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class WrongCheckOutException : Exception
    {
        public WrongCheckOutException() : base("Not all payments have been settled ")
        {
            
        }
    }
}
