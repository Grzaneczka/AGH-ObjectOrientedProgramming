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

        private int numberOfAdults;
        private int numberOfChildren;
        private int numberOfBabies;

        private bool isCheckIn;
        private bool isCheckOut;
        private bool isAdvancePaid;

        // Konstruktory 

        public Reservation()
        {
            rooms = new List<Room>();
        }

        public Reservation(Client client, string checkInDate, string checkOutDate,int numberOfAdults, int numberOfChildren, int numberOfBabies, bool checkIn, bool checkOut, bool advance) : this()
        {
            if (!DateTime.TryParseExact(checkInDate, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out this.checkInDate)) 
                throw new FormatException("Invalid date format");

            if (!DateTime.TryParseExact(checkOutDate, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out this.checkOutDate))
                throw new FormatException("Invalid date format");

            this.client = client;
            this.NumberOfAdults = numberOfAdults;
            this.NumberOfChildren = numberOfChildren;
            this.NumberOfBabies = NumberOfBabies;
            this.IsCheckIn = checkIn;
            this.IsCheckOut = checkOut;
            this.IsAdvancePaid = advance;
        }

        // Getery i setery 

        public DateTime CheckInDate { get => checkInDate; set => checkInDate = value; }

        public DateTime CheckOutDate { get => checkOutDate; set => checkOutDate = value; }

        public int NumberOfAdults { get => numberOfAdults; set => numberOfAdults = value; }

        public int NumberOfChildren { get => numberOfChildren; set => numberOfChildren = value; }

        public int NumberOfBabies { get => numberOfBabies; set => numberOfBabies = value; }

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

        public int NumberOfPeople()
        {
            return this.NumberOfAdults + this.NumberOfChildren + this.NumberOfBabies;
        }

        // Cena wyliczana ze wzoru = (Cena za pokój * ilosć dni + zniżka za dzieci) * cena za sezon (sezon określany jako dzień zameldowania) 

        public double CostRoom(Room room)
        {
            double costRoom = 0;

            switch (room.NumberOfPeople())
            {
                case 1:
                    costRoom = Contig.priceRoom1 * Days();
                    break;
                case 2:
                    costRoom = Contig.priceRoom2 * Days();
                    break;
                case 3:
                    costRoom = Contig.priceRoom3 * Days();
                    break;
                case 4:
                    costRoom = Contig.priceRoom4 * Days();
                    break;
                case 5:
                    costRoom = Contig.priceRoom5 * Days();
                    break;
                case 6:
                    costRoom = Contig.priceRoom6 * Days();
                    break;
            }

                 return costRoom;
        }

        public double CostSeason()
        {
            double costSeason = 0;

            if (checkInDate >= Contig.mediumSeasonStart && checkInDate <= Contig.mediumSeasonFinish)
                costSeason = Contig.priceOfMediumSeason;
            else if (checkInDate >= Contig.mediumSeasonFinish && checkInDate <= Contig.highSeasonFinish)
                costSeason = Contig.priceOfHighSeason;
            else if (checkInDate >= Contig.specialSeasonStart && checkInDate <= Contig.specialSeasonFinish)
                costSeason = Contig.priceOfSpecialSeason;
            else
                costSeason = Contig.priceOfLowSeason;

                return costSeason;
        }
        
        internal double Cost()
        {
            double cost = 0;
            foreach (Room room in rooms)
            {
                cost = cost + CostRoom(room);      
            }

            return ((cost/NumberOfPeople()) * numberOfAdults * Contig.priceForPerson + (cost / NumberOfPeople()) * numberOfChildren * Contig.priceForChild + (cost / NumberOfPeople()) * numberOfBabies * Contig.priceForBabies) * CostSeason();
        }

        public void CheckIn()
        { 
            this.isCheckIn = true;
        }

        public int Advance()
        {
            return (int)(Cost() * Contig.priceAdvances);
        }






        // To string 

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(this.client.ToString());
            builder.Append("Room:  ");

            foreach (Room room in rooms)
            {
                builder.AppendLine(room.ToString() + " Cost Room: " + CostRoom(room));
            }

            builder.AppendLine("Check-in date: " + this.checkInDate + "  Check-out date: " + this.checkOutDate);
            builder.AppendLine("Is check-in: " + this.isCheckIn + "  Is check-out: " + this.isCheckOut + "  Advance: " + Advance() + "  Is Advance paid: " + this.isAdvancePaid);
            builder.AppendLine("Quantity of days: " + Days() + " Cost Season: " + CostSeason() + "  Cost of reservation: " + Cost());

            return builder.ToString();
        }
       
    }
}
