using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Reservation
    {
        private Client client;
        private List<Room> rooms;
        private DateTime checkInDate;
        private DateTime checkOutDate;

        private bool isCheckIn;
        private bool isCheckOut;
        private bool isAdvancePaid;

        // Konstruktory 

        public Reservation()
        {
            rooms = new List<Room>();
        }

        public Reservation(Client client, string checkInDate, string checkOutDate, bool checkIn, bool checkOut, bool advance) : this()
        {
            if (!DateTime.TryParseExact(checkInDate, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out this.checkInDate)) 
                throw new FormatException("Invalid date format");

            if (!DateTime.TryParseExact(checkOutDate, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out this.checkOutDate))
                throw new FormatException("Invalid date format");

            this.client = client;
            this.IsCheckIn = checkIn;
            this.IsCheckOut = checkOut;
            this.IsAdvancePaid = advance;
        }

        // Getery i setery 

        public DateTime CheckInDate { get => checkInDate; set => checkInDate = value; }

        public DateTime CheckOutDate { get => checkOutDate; set => checkOutDate = value; }

        public bool IsCheckIn { get => isCheckIn; set => isCheckIn = value; }

        public bool IsCheckOut { get => isCheckOut; set => isCheckOut = value; }

        public bool IsAdvancePaid { get => isAdvancePaid; set => isAdvancePaid = value; }

        // Metody dodatkowe

        public int Days()
        {
            TimeSpan days = checkOutDate - checkInDate;
            return (int)days.TotalDays;
        }

        public void AddRoom(Room room)  
        {
            this.rooms.Add(room);
        }

        // To string 

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Client: " + this.client);
            builder.Append("Room:  ");

            foreach (Room room in rooms)
            {
                builder.AppendLine(room.ToString());
            }

            builder.AppendLine("Check-in date: " + this.checkInDate + "  Check-out date: " + this.checkOutDate);
            builder.AppendLine("Is check-in: " + this.isCheckIn + "  Is check-out: " + this.isCheckOut + "  Is advance paid: " + this.isAdvancePaid);
            builder.AppendLine("Quantity of days: " + Days());

            return builder.ToString();
        }

       
    }
}
