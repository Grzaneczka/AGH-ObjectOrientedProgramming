using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]

    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Karolina", "Grzanka","879-987-987", Sex.Woman, "Administrator");

            Console.WriteLine("-----------------HOTEL--------------------------------");

            Hotel hotel = new Hotel("NAJLEPSZY HOTEL NA ŚWIACIE");

            Room room01 = hotel.CreateRoom(01, 0, 1, false, employee);
            Room room02 = hotel.CreateRoom(02, 1, 1, false, employee);

            SinglePayment singlePayment = new SinglePayment("Kawa late", 10.50, 2);
            
            Client client1 = hotel.CreateClient("Jan", "Główka", "765-234-567", Sex.Man, "janglowka@add.asd", "RSE 654332", employee);

            Client client2 = hotel.CreateClient("Zosia", "Samosia", "546-653-765", Sex.Woman, "Zosia_samosia@gsr.dkfi", "RES 645378", employee);
           
            hotel.CreateReservation("Reservation room 1 28/09/2019 - 30/09/2019", client1, "2019/09/28", "2019/09/30", 2, 0, 0, employee, room01);

            hotel.AddSinglePayment(client1, singlePayment);

            

            Console.WriteLine(hotel);

            Console.WriteLine("-----------------ACCOUNTS--------------------------------");

            foreach (Account account in hotel.Accounts)
            {
                Console.WriteLine(account.ToString());
                Console.WriteLine("Debet: ");
                Console.WriteLine(account.AccountDebt());
            }

            Console.WriteLine("-----------------SERIALIZACJA--------------------------------");

            Hotel.SaveXML("hotel.xml", hotel);
            Console.WriteLine("Odczyt XML");
            Hotel hotel2 = Hotel.ReadXML("hotel.xml");
            Console.WriteLine(hotel2);


            /* SQL test */
            Console.WriteLine("-----------------TEST SQL--------------------------------");

            Console.WriteLine("\nWpisywanie do bazy");

            Employee employee_test = new Employee("Szymon", "Bednarek", "222-333-222", Sex.Man, "Szef");
            Sql.InsertEmployee(employee_test);
            Console.WriteLine("Wpisano nowego pracownika");


            Console.WriteLine("\nAll Employees:");
            List<List<string>> querry_output = Sql.ExecuteSelectQuerry("SELECT * FROM Employees");
            List<Employee> AllEmployees = Sql.ConvertToEmployee(querry_output);
            foreach (Employee employee1 in AllEmployees)
            {
                Console.WriteLine(employee1.ToString());
            }

            Console.WriteLine("\nAll Clients:");
            List<List<string>> querry_output2 = Sql.ExecuteSelectQuerry("SELECT * FROM Clients");
            List<Client> AllClients = Sql.ConvertToClient(querry_output2);
            foreach (Client client in AllClients)
            {
                Console.WriteLine(client.ToString());
            }

            Console.WriteLine("\nAll Rooms:");
            List<List<string>> querry_output3 = Sql.ExecuteSelectQuerry("SELECT * FROM Rooms");
            List<Room> AllRooms = Sql.ConvertToRoom(querry_output3);
            foreach (Room room in AllRooms)
            {
                Console.WriteLine(room.ToString());
            }

            Console.WriteLine("\nAll single payments:");
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
