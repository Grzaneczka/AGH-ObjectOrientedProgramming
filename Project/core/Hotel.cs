using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Hotel
    {
        private string name;
        private List<Reservation> cancelingReservations;
        private List<Reservation> reservations;
        private List<Room> rooms;

        // Konstruktory 

        public Hotel()
        {
            this.Name = null;
            this.reservations = new List<Reservation>();
            this.cancelingReservations = new List<Reservation>();
            this.rooms = new List<Room>();
        }

        public Hotel(string name) : this()
        {
            this.Name = name;
        }

        // Getery i setery 

        public string Name { get => name; set => name = value; }

        // Metody dodatkowe

        public void CancelReservation(Reservation reservation)
        {
            reservations.Remove(reservation);
            cancelingReservations.Add(reservation);

            //TimeSpan days = reservation.CheckInDate -  DateTime.Now;
            //if(days.TotalDays >= 14)
            //{

            //}
        }

        public void RestoreReservations(Reservation reservation)
        {
            reservations.Add(reservation);
            cancelingReservations.Remove(reservation);
        }

        public void AddReserwation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        public List<Room> DirtyFreeRooms()
        {
            return this.rooms.FindAll(r => r.IsClear == false && r.IsFree == true);
        }

        //public List<Room> FreeRooms(DateTime checkIn, DateTime checkOut)
        //{

        //}

        public void Cleaned(int roomNumber)
        {
            rooms.Find(r => r.RoomNumber == roomNumber).IsClear = true;
        }

        public void CancelReservationAfter2Days(Reservation reservation)
        {
            CancelReservation(reservations.Find(r => r.CheckInDate.AddDays(2) == DateTime.Now && r.IsCheckIn == false));
        }

        //public void ExtendReservations(DateTime date, Reservation reservation)
        //{
        //}

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
