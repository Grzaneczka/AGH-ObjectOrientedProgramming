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
          
            Employee employee1 = new Employee("Andzej", "Kosa", "768-987-234", Sex.Man, "Recepcjonista");
            //Console.WriteLine(employee1);
            //Console.WriteLine();

            Client client1 = new Client("Joanna", "Suwaj", "876-543-456", Sex.Woman, "joannasuwaj@gmail.com", "DGC 654329");
            //Console.WriteLine(client1);
            //Console.WriteLine();

            Console.WriteLine("-----------------ROOM--------------------------------");
            Room room1 = new Room(1, 0, 1, false, false);
            //Console.WriteLine(room1.NumberOfPeople());
            Console.WriteLine();
            Room room3 = (Room) room1.Clone();
            room3.RoomNumber = 3;
            Console.WriteLine(room1);
            Console.WriteLine(room3);

            Room room2 = new Room(2, 1, 0, false, true);
            //Console.WriteLine(room2.NumberOfPeople());
            //Console.WriteLine();

            Reservation reservation1 = new Reservation("Reservation 2019/06/30 - 2019/07/02" ,client1, "2019/06/30", "2019/07/02", 2, 1, 0, false, false, true);
            //Console.WriteLine(reservation1);
            //Console.WriteLine();

            //Console.WriteLine("-----------------RESERVATION--------------------------------");
            //reservation1.AddRoom(room1);
            //reservation1.AddRoom(room2);
            //Console.WriteLine(reservation1);
            //Console.WriteLine();

            //Console.WriteLine("-----------------PAYMENT--------------------------------");
            //Payment payment1 = new Payment(client1);
            //payment1.AddSinglePayment(singlePayment1);
            //payment1.AddReserwation(reservation1);
            //payment1.AddAdvance(reservation1);

            //Console.WriteLine(payment1);
            //Console.WriteLine();

            //Console.WriteLine("-----------------HOTEL--------------------------------");
            //Hotel hotel1 = new Hotel();
            //hotel1.AddReserwation(reservation1);
            //hotel1.CancelReservation(reservation1);
            //hotel1.AddRoom(room1);
            //hotel1.AddRoom(room2);

            //hotel1.DirtyFreeRooms();
            //hotel1.Cleaned(1);


            //Console.WriteLine(hotel1);
            
            Console.ReadLine();
        }
    }
}
