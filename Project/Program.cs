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
            Employee employee = new Employee("Karolina", "Grzanka","879-987-987", Sex.Woman, "Administrator");

            Console.WriteLine("-----------------HOTEL--------------------------------");

            Hotel hotel = new Hotel("NAJLEPSZY HOTEL NA ŚWIACIE");

            Room room01 = hotel.CreateRoom(01, 0, 1, false, employee);
            Room room02 = hotel.CreateRoom(02, 1, 1, false, employee);

            Client client = hotel.CreateClient("Jan", "Główka", "765-234-567", Sex.Man, "janglowka@add.asd", "RSE 654332", employee);

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

            List<List<string>> querry_output = Sql.ExecuteSelectQuerry("SELECT * FROM Employees");
            List<Employee> AllEmployees = Sql.ConvertToEmployee(querry_output);
            foreach (Employee employee in AllEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
            Client client2 = hotel.CreateClient("Zosia", "Samosia", "546-653-765", Sex.Woman, "Zosia_samosia@gsr.dkfi", "RES 645378", employee);
           
            hotel.CreateReservation("Reservation room 1 28/09/2019 - 30/09/2019", client, "2019/09/28", "2019/09/30", 2, 0, 0, employee, room01);
       
            Console.WriteLine(hotel);

            Console.WriteLine("-----------------ACCOUNTS--------------------------------");


            foreach (Account account in hotel.Accounts)
            {
                Console.WriteLine(account.ToString());
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
            //Console.WriteLine("-----------------SERIALIZACJA--------------------------------");

            //Hotel.SaveXML("hotel.xml", hotel);
            //Console.WriteLine("Odczyt XML");
            //Hotel hotel2 = Hotel.ReadXML("hotel.xml");
            //Console.WriteLine(hotel2);
            List<List<string>> querry_output4 = Sql.ExecuteSelectQuerry("SELECT * FROM SinglePayment");
            List<SinglePayment> AllSinglePayments = Sql.ConvertToSinglePayment(querry_output4);
            foreach (SinglePayment single_payment in AllSinglePayments)
            {
                Console.WriteLine(single_payment.ToString());
            }

            Console.ReadLine();
        }
    }
}
