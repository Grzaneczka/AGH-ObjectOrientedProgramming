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
    class Hotel
    {
        private string name;
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

        internal List<Reservation> Reservations { get => reservations; set => reservations = value; }

        internal List<Room> Rooms { get => rooms; set => rooms = value; }

        internal List<Client> Clients { get => clients; set => clients = value; }

        internal List<Employee> Employees { get => employees; set => employees = value; }

        internal List<Log> Logs { get => logs; set => logs = value; }

        internal List<Account> Accounts { get => accounts; set => accounts = value; }

        // Metody dodatkowe => dotyczące rezerwacji 

        public Reservation CreateReservation(string title, Client client, string checkInDate, string checkOutDate, int numberOfAdults, int numberOfChildren, int numberOfBabies, Employee employee, Room room)
        {
            Reservation reservation = new Reservation(title, client, checkInDate, checkOutDate, numberOfAdults, numberOfChildren, numberOfBabies, false, false, false);
            reservations.Add(reservation);
            reservation.AddRoom(room);
            accounts.Find(a => a.Client == client).AddPayment(reservation);

            string contents = "Create reservation: " + title;
            AddLog(employee, Type.Create_Reserwation, contents);

            return reservation;
        }

        public bool ExtendReservations(DateTime date, Reservation reservation, Employee employee)
        {
            string contents = "Extend reservation " + reservation.Title;
            AddLog(employee, Type.Extend_Reservations, contents);

            bool canBeExtended = reservation.Rooms.All(room => !IsRoomReserved(room, reservation.CheckOutDate, date));

            if (!canBeExtended)
                return false;

            reservation.CheckOutDate = date;
            return true;
        }

        public void CanceledReservation(Reservation reservation, Employee employee)
        {
            string contents = "Canceled reservation " + reservation.Title;
            AddLog(employee, Type.Canceled_Reservations, contents);

            reservation.Canceled = true;
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
            AddLog(employee, Type.Restor_Canceled_Reservation, contents);
        }

        public void CheckIn(Reservation reservation, Employee employee)
        {
            reservation.CheckIn();

            string contents = "Checki in reservation " + reservation.Title;
            AddLog(employee, Type.Check_In, contents);
        }

        public void ChecOut(Reservation reservation, Employee employee)
        {
            if (accounts.Find(a => a.Client == reservation.Client).AccountStatus() == 0)
            {
                reservation.CheckOut();

                string contents = "Checki out reservation " + reservation.Title;
                AddLog(employee, Type.Check_Out, contents);
            }
            else
                throw new WrongCheckOutException();
        }

        // Metody dodatkowe => dotyczące pokoju 

        public Room CreateRoom(int roomNumber, int numberOfSingleBeds, int numberOfMarriageBeds, bool isBalcony, Employee employee)
        {
            string contents = "Create room " + roomNumber;
            AddLog(employee, Type.Create_Room, contents);

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

        public void Cleaned(int roomNumber, Employee employee)
        {
            string contents = "Cleaned room " + roomNumber;
            AddLog(employee, Type.Cleaning, contents);

            rooms.Find(r => r.RoomNumber == roomNumber).IsClear = true;
        }

        // Metody dodatkowe => dotyczące clienta

        public Client CreateClient(string name, string surname, string phone, Sex sex, string email, string idNumber, Employee employee)
        {
            string contents = "Create client " + idNumber;
            AddLog(employee, Type.Create_Client, contents);

            Client client = new Client(name, surname, phone, sex, email, idNumber);
            clients.Add(client);

            CreateAccount(client);          

            return client;
        }

        // Metody dodatkowe => dotyczące pracownika

        public Employee CreateEmplyee(string name, string surname, string phone, Sex sex, string function, Employee employee1)
        {
            string contents = "Create emplyee " + name + " " + surname;
            AddLog(employee1, Type.Create_Emplyee, contents);

            Employee employee = new Employee(name, surname, phone, sex, function);
            employees.Add(employee);
            return employee;
        }

        public void AddLog(Employee employee, Type type, string contents)
        {
            Log log = new Log(employee, type, contents);
            logs.Add(log);
        }

        // Metody dodatkowe => dotyczące rachunku 

        public Account CreateAccount(Client client)
        {
            Account account = new Account(client);
            accounts.Add(account);

            return account;
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
            XmlSerializer serializer = new XmlSerializer(typeof(Hotel));
            StreamWriter writer = new StreamWriter(name);
            serializer.Serialize(writer, hotel);
            writer.Close();
        }

        public static Hotel ReadXML(string name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Hotel));
            using (StreamReader reader = new StreamReader(name))
            {
                Hotel score = serializer.Deserialize(reader) as Hotel;
                return score;
            }
        }
    }
}
