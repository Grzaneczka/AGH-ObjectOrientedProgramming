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
            /*
            Person person1 = new Person("Adam", "Adamski", Sex.Man, "678-658-789", "DSC 234561");
            //Console.WriteLine(person1);
            //Console.WriteLine();

            Employee employee1 = new Employee("Andzej", "Kosa", "768-987-234", Sex.Man, "Recepcjonista");
            //Console.WriteLine(employee1);
            //Console.WriteLine();

            Client client1 = new Client("Joanna", "Suwaj", "876-543-456", Sex.Woman, "joannasuwaj@gmail.com", "DGC 654329");
            //Console.WriteLine(client1);
            //Console.WriteLine();

            Room room1 = new Room(1, 0, 1, false, false);
            //Console.WriteLine(room1.NumberOfPeople());
            //Console.WriteLine();

            Room room2 = new Room(2, 1, 0, false, true);
            //Console.WriteLine(room2.NumberOfPeople());
            //Console.WriteLine();

            SinglePayment singlePayment1 = new SinglePayment("Kawusia", 11.69, 2, false);
            //Console.WriteLine(singlePayment1);
            //Console.WriteLine();

            Reservation reservation1 = new Reservation(client1, "2019/06/30", "2019/07/02", 2, 1, 0, false, false, true);
            //Console.WriteLine(reservation1);
            //Console.WriteLine();

            Console.WriteLine("-----------------RESERVATION--------------------------------");
            reservation1.AddRoom(room1);
            reservation1.AddRoom(room2);
            Console.WriteLine(reservation1);
            Console.WriteLine();

            Console.WriteLine("-----------------PAYMENT--------------------------------");
            Payment payment1 = new Payment(client1);
            payment1.AddSinglePayment(singlePayment1);
            payment1.AddReserwation(reservation1);
            payment1.AddAdvance(reservation1);

            Console.WriteLine(payment1);
            */

            /* SQL test */
            List<Employee> AllEmployees = Sql.LoadAllEmployees();
            foreach(Employee employee in AllEmployees)
            {
                Console.WriteLine(employee.ToString());
            }

            List<List<string>> querry_output = Sql.ExecuteSelectQuerry("SELECT * FROM Employees");
            AllEmployees = Sql.ConvertToEmployee(querry_output);
            foreach (Employee employee in AllEmployees)
            {
                Console.WriteLine(employee.ToString());
            }

            List<List<string>> querry_output2 = Sql.ExecuteSelectQuerry("SELECT * FROM Clients");
            List<Client> AllClients = Sql.ConvertToClient(querry_output2);
            foreach (Client client in AllClients)
            {
                Console.WriteLine(client.ToString());
            }

            List<List<string>> querry_output3 = Sql.ExecuteSelectQuerry("SELECT * FROM Rooms");
            List<Room> AllRooms = Sql.ConvertToRoom(querry_output3);
            foreach (Room room in AllRooms)
            {
                Console.WriteLine(room.ToString());
            }

            Console.ReadLine();
        }
    }
}
