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
        private List<Reservation> reservations;
        private List<Room> rooms;
        private List<Client> clients;
        private List<Employee> employees;
        
        // Konstruktory 

        public Hotel(string name)
        {
            this.Name =  name;
            this.reservations = new List<Reservation>();
            this.rooms = new List<Room>();
            this.clients = new List<Client>();
            this.employees = new List<Employee>();
        }

        // Getery i setery 

        public string Name { get => name; set => name = value; }

        internal List<Reservation> Reservations { get => reservations; set => reservations = value; }

        internal List<Room> Rooms { get => rooms; set => rooms = value; }

        internal List<Client> Clients { get => clients; set => clients = value; }

        internal List<Employee> Employees { get => employees; set => employees = value; }

        // Metody dodatkowe => dotyczące rezerwacji 

        public Reservation CreateReserwation(string title, Client client, string checkInDate, string checkOutDate, int numberOfAdults, int numberOfChildren, int numberOfBabies)
        {
            Reservation reservation = new Reservation(title, client, checkInDate, checkOutDate, numberOfAdults, numberOfChildren, numberOfBabies, false, false, false);
            reservations.Add(reservation);
            client.AddPayment(reservation);
            return reservation;
        }

        public bool ExtendReservations(DateTime date, Reservation reservation)
        {
            bool canBeExtended = reservation.Rooms.All(room => !IsRoomReserved(room, reservation.CheckOutDate, date));

            if (!canBeExtended)
                return false;

            reservation.CheckOutDate = date;
            return true;
        }

        public List<Reservation> CanceledReservations()
        {
            return reservations.FindAll(r => r.Canceled);
        }

        public void CancelReservationsAfter2Days()
        {
            reservations
                .FindAll(r => r.CheckInDate.AddDays(Config.AUTOMATIC_CANCEL_DAYS) < DateTime.Now && !r.IsCheckIn && !r.Canceled)
                .ForEach(r => r.Canceled = true);
        }

        // Metody dodatkowe => dotyczące pokoju 

        public Room CreateRoom(int roomNumber, int numberOfSingleBeds, int numberOfMarriageBeds, bool isBalcony)
        {
            Room room = new Room(roomNumber, numberOfSingleBeds, numberOfMarriageBeds, isBalcony, false);
            rooms.Add(room);
            return room;
        }
        
        public List<Room> DirtyFreeRooms()
        {
            return this.rooms.FindAll(r => !r.IsClear && !r.IsFree);
        }

        public bool IsRoomReserved(Room room, DateTime checkIn, DateTime checkOut)
        {
            return reservations
                .Where(r => r.Rooms.Contains(room))
                .Where(r => !(checkOut <= r.CheckInDate || r.CheckOutDate <= checkIn))
                .Count() > 0;
        }

        public List<Room> FreeRooms(DateTime checkIn, DateTime checkOut)
        {
            return rooms.FindAll(room => IsRoomReserved(room, checkIn, checkOut));
        }

        public void Cleaned(int roomNumber)
        {
            rooms.Find(r => r.RoomNumber == roomNumber).IsClear = true;
        }

        // Metody dodatkowe => dotyczące clienta

        public Client CreateClient(string name, string surname, string phone, Sex sex, string email, string idNumber)
        {
            Client client = new Client(name, surname, phone, sex, email, idNumber);
            clients.Add(client);
            return client;
        }

        // Metody dodatkowe => dotyczące pracownika

        public Employee CreateEmplyee(string name, string surname, string phone, Sex sex, string function)
        {
            Employee employee = new Employee(name, surname, phone, sex, function);
            employees.Add(employee);
            return employee;
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
