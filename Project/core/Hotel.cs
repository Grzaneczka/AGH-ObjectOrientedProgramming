using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project
{
    [Serializable]
    public class Hotel
    {
        private string name;
        private List<Reservation> cancelingReservations;
        private List<Reservation> reservations;
        private List<Room> rooms;
        private List<Client> clients;
        private List<Employee> employees;
        private List<Log> logs;
        private List<Account> accounts;

        // Konstruktory 

        public Hotel()
        {
            this.Name = null;
            this.reservations = new List<Reservation>();
            this.cancelingReservations = new List<Reservation>();
            this.rooms = new List<Room>();
            this.clients = new List<Client>();
            this.employees = new List<Employee>();
            this.logs = new List<Log>();
            this.accounts = new List<Account>();
        }

        public Hotel(string name): this()
        {
            this.Name =  name;
            
        }

        // Getery i setery 

        public string Name { get => name; set => name = value; }

        public List<Reservation> Reservations { get => reservations; set => reservations = value; }

        public List<Room> Rooms { get => rooms; set => rooms = value; }

        public List<Client> Clients { get => clients; set => clients = value; }

        public List<Employee> Employees { get => employees; set => employees = value; }

        public List<Log> Logs { get => logs; set => logs = value; }

        public List<Account> Accounts { get => accounts; set => accounts = value; }

        // Metody dodatkowe => dotyczące rezerwacji 

        public Reservation CreateReservation(string title, Client client, string checkInDate, string checkOutDate, int numberOfAdults, int numberOfChildren, int numberOfBabies, Employee employee, Room room)
        {
            Reservation reservation = new Reservation(title, client, checkInDate, checkOutDate, numberOfAdults, numberOfChildren, numberOfBabies, false, false, false);
            reservations.Add(reservation);
            reservation.AddRoom(room);
            accounts.Find(a => a.Client == client).AddPayment(reservation);

            string contents = "Create reservation: " + title;
            AddLog(employee, LogType.CREATE_RESERWATION, contents);

            return reservation;
        }

        public bool ExtendReservations(DateTime date, Reservation reservation, Employee employee)
        {
            bool canBeExtended = reservation.Rooms.All(room => !IsRoomReserved(room, reservation.CheckOutDate, date));

            if (!canBeExtended)
                return false;

            string contents = "Extend reservation " + reservation.Title;
            AddLog(employee, LogType.EXTEND_RESERVATIONS, contents);

            reservation.CheckOutDate = date;
            return true;
        }

        public void CanceledReservation(Reservation reservation, Employee employee)
        {
            reservation.Canceled = true;

            string contents = "Canceled reservation " + reservation.Title;
            AddLog(employee, LogType.CANCELED_RESERVATIONS, contents);
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

        public void RestoredCanceledReservation(Reservation reservation, Employee employee)
        {
            reservation.Canceled = false;

            string contents = "Restored canceled reservation " + reservation.Title;
            AddLog(employee, LogType.RESTOR_CANCELED_RESERVATION, contents);
        }

        public void CheckIn(Reservation reservation, Employee employee)
        {
            reservation.CheckIn();

            string contents = "Checki in reservation " + reservation.Title;
            AddLog(employee, LogType.CHECK_IN, contents);
        }

        public void ChecOut(Reservation reservation, Employee employee)
        {
            if (accounts.Find(a => a.Client == reservation.Client).AccountDebt() == 0)
            {
                reservation.CheckOut();

                string contents = "Checki out reservation " + reservation.Title;
                AddLog(employee, LogType.CHECK_OUT, contents);
            }
            else
                throw new WrongCheckOutException();
        }

        // Metody dodatkowe => dotyczące pokoju 

        public Room CreateRoom(int roomNumber, int numberOfSingleBeds, int numberOfMarriageBeds, bool isBalcony, Employee employee)
        {
            Room room = new Room(roomNumber, numberOfSingleBeds, numberOfMarriageBeds, isBalcony, false, true);
            rooms.Add(room);

            string contents = "Create room " + roomNumber;
            AddLog(employee, LogType.CREATE_ROOM, contents);

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

        public void Cleaned(int roomNumber, Employee employee)
        {
            rooms.Find(r => r.RoomNumber == roomNumber).IsClear = true;

            string contents = "Cleaned room " + roomNumber;
            AddLog(employee, LogType.CLEANING, contents);

        }

        // Metody dodatkowe => dotyczące clienta

        public Client CreateClient(string name, string surname, string phone, Sex sex, string email, string idNumber, Employee employee)
        {
            Client client = new Client(name, surname, phone, sex, email, idNumber);
            clients.Add(client);

            CreateAccount(client);

            string contents = "Create client " + idNumber;
            AddLog(employee, LogType.CREATE_CLIENT, contents);

            return client;
        }

        // Metody dodatkowe => dotyczące pracownika

        public Employee CreateEmplyee(string name, string surname, string phone, Sex sex, string function)
        {
            Employee employee = new Employee(name, surname, phone, sex, function);
            employees.Add(employee);

            string contents = "Create emplyee " + name + " " + surname;
            AddLog(employee, LogType.CREATE_EMPLYEE, contents);

            return employee;
        }

        public void AddLog(Employee employee, LogType type, string contents)
        {
            logs.Add(new Log(employee, type, contents));
        }

        // Metody dodatkowe => dotyczące rachunku 

        public Account CreateAccount(Client client)
        {
            Account account = new Account(client);
            accounts.Add(account);

            return account;
        }

        public void AddSinglePayment(Client client, SinglePayment singlePayment)
        {
            accounts.Find(a => a.Client == client).AddPayment(singlePayment);
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

        // Serializacja XML

        public static void SaveXML(string name, Hotel hotel)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Hotel), new Type[] { typeof(SinglePayment) });
            StreamWriter writer = new StreamWriter(name);
            serializer.Serialize(writer, hotel);
            writer.Close();
        }

        public static Hotel ReadXML(string name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Hotel), new Type[] { typeof(SinglePayment) });
            using (StreamReader reader = new StreamReader(name))
            {
                Hotel score = serializer.Deserialize(reader) as Hotel;
                return score;
            }
        }
    }
}
