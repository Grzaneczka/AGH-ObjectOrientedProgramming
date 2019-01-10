using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
    class Hotel
    {
        private string name;
        private List<Reservation> reservations;
        private List<Room> rooms;
        List<Employee> employees;
        List<Client> clients;
        List<Payment> payments;
        // Konstruktory 

        public Hotel()
        {
            this.Name = null;
            this.reservations = new List<Reservation>();
            this.rooms = new List<Room>();
            this.employees = new List<Employee>();
            this.clients = new List<Client>();
            this.payments = new List<Payment>();
        }

        public Hotel(string name) : this()
        {
            this.Name = name;
        }

        // Getery i setery 

        public string Name { get => name; set => name = value; }

        /*
         *      METODY DO GUI
         */

        // dodawanie klienta

        // dodawanie pracownika

        // dodawanie pokoju
        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        // dodawanie rezerwacji
        public void AddReserwation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        // usuwanie rezerwacji
        public void CancelReservation(Reservation reservation)
        {
            reservations.Remove(reservation);
            foreach (Room room in reservation.Rooms)
                room.IsFree = true;
        }

        // wolne pokoje
        public List<Room> FreeRooms(DateTime checkIn, DateTime checkOut)
        {
            return rooms.FindAll(room => IsRoomReserved(room, checkIn, checkOut));
        }




        // Metody dodatkowe

        public List<Room> DirtyFreeRooms()
        {
            return this.rooms.FindAll(r => r.IsClear == false && r.IsFree == true);
        }

        public bool IsRoomReserved(Room room, DateTime checkIn, DateTime checkOut)
        {
            return reservations
                .Where(r => r.Rooms.Contains(room))
                .Where(r => !(checkOut <= r.CheckInDate || r.CheckOutDate <= checkIn))
                .Count() > 0;
        }



        public void Cleaned(int roomNumber)
        {
            rooms.Find(r => r.RoomNumber == roomNumber).IsClear = true;
        }

        public void CancelReservationAfter2Days(Reservation reservation)
        {
            CancelReservation(reservations.Find(r => r.CheckInDate.AddDays(2) == DateTime.Now && r.IsCheckIn == false));
        }

        // To string

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(this.name);
            builder.AppendLine("Reservations:  ");

            foreach (Reservation reservation in reservations)
            {
                builder.AppendLine(reservation.ToString());
            }

            builder.AppendLine("Rooms:  ");

            foreach (Room room in rooms)
            {
                builder.AppendLine(room.ToString());
            }

            builder.AppendLine("Dirty Rooms:  ");

            foreach (Room room in DirtyFreeRooms())
            {
                builder.AppendLine(room.ToString());
            }

            return builder.ToString();
        }
    }
}
