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
            Person person1 = new Person("Adam", "Adamski", Sex.Man, "678-658-789", "DSC 234561");
            Console.WriteLine(person1);
            Console.WriteLine();

            Employee employee1 = new Employee("Andzej", "Kosa", "768-987-234", Sex.Man, "Recepcjonista");
            Console.WriteLine(employee1);
            Console.WriteLine();

            Client client1 = new Client("Joanna", "Suwaj", "876-543-456", Sex.Woman, "joannasuwaj@gmail.com", "DGC 654329");
            Console.WriteLine(client1);
            Console.WriteLine();

            Room room1 = new Room(1, 1, 1, false, true);
            Console.WriteLine(room1);
            Console.WriteLine();

            SinglePayment singlePayment1 = new SinglePayment("Kawusia", 11.69, 2, false);
            Console.WriteLine(singlePayment1);
            Console.WriteLine();

            // COŚ JEST BŁĘDNIE W REZERWACJI NIE DZIAŁA POKÓJ
            Reservation reservation1 = new Reservation(client1, "2019/01/12", "2019/01/21", 3, 1, 0, false, false, true);
            Console.WriteLine(reservation1);
            Console.WriteLine();

            reservation1.AddRoom(room1);
            Console.WriteLine(reservation1);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
