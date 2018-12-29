using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Adam", "Adamski", "678-658-789", Sex.Man, "DSC 234561");

            Console.WriteLine(person1);

            Console.ReadLine();
        }
    }
}
