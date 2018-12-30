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

            Employee employee1 = new Employee("Andzej", "Kosa", "768-987-234", Sex.Man, "Recepcjonista");
            Console.WriteLine(employee1);

            Client client1 = new Client("Joanna", "Suwaj", "876-543-456", Sex.Woman, "joannasuwaj@gmail.com", "DGC 654329");
            Console.WriteLine(client1);

            Room room1 = new Room(13, 15, 234, false, true, true);
            Console.WriteLine(room1);

            Console.ReadLine();


        }
    }
}
