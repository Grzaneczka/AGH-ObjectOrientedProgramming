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

            Client client2 = hotel.CreateClient("Zosia", "Samosia", "546-653-765", Sex.Woman, "Zosia_samosia@gsr.dkfi", "RES 645378", employee);
           
            hotel.CreateReservation("Reservation room 1 28/09/2019 - 30/09/2019", client, "2019/09/28", "2019/09/30", 2, 0, 0, employee, room01);
       
            Console.WriteLine(hotel);

            Console.WriteLine("-----------------ACCOUNTS--------------------------------");


            foreach (Account account in hotel.Accounts)
            {
                Console.WriteLine(account.ToString());
            }

            //Console.WriteLine("-----------------SERIALIZACJA--------------------------------");

            //Hotel.SaveXML("hotel.xml", hotel);
            //Console.WriteLine("Odczyt XML");
            //Hotel hotel2 = Hotel.ReadXML("hotel.xml");
            //Console.WriteLine(hotel2);

            Console.ReadLine();
        }
    }
}
