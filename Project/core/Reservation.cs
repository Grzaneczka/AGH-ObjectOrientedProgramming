using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
    class Reservation : Payment 
    {

        private Client client;
        private List<Room> rooms;
        private DateTime checkInDate;
        private DateTime checkOutDate;

        private int adults; 
        private int children;
        private int babies;

        private bool isCheckIn;
        private bool isCheckOut;
        private bool canceled;
        private bool isAdvance;

        // Konstruktory

        internal Reservation(string title, Client client, string checkInDate, string checkOutDate,int numberOfAdults, int numberOfChildren, int numberOfBabies, bool checkIn, bool checkOut, bool advance) : base(title)
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
            this.Canceled = false;
            this.isAdvance = advance;

            this.rooms = new List<Room>();
        }

        // Getery i setery 

        public DateTime CheckInDate { get => checkInDate; set => checkInDate = value; }

        public DateTime CheckOutDate { get => checkOutDate; set => checkOutDate = value; }

        public int NumberOfAdults { get => adults; set => adults = value; }

        public int NumberOfChildren { get => children; set => children = value; }

        public int NumberOfBabies { get => babies; set => babies = value; }

        public bool IsCheckIn { get => isCheckIn; set => isCheckIn = value; }

        public bool IsCheckOut { get => isCheckOut; set => isCheckOut = value; }

        public bool Canceled { get => canceled; set => canceled = value; }

        internal List<Room> Rooms { get => rooms; }

        internal Client Client { get => client; set => client = value; }

        // Metody dodatkowe

        public int Days()
        {
            TimeSpan days = checkOutDate - checkInDate;
            return (int)days.TotalDays + 1;
        }

        public void AddRoom(Room room)  
        {
            this.rooms.Add(room);
        }

        public int NumberOfPeople()
        {
            return this.NumberOfAdults + this.NumberOfChildren + this.NumberOfBabies;
        }

        public void RemoveRoom(Room room)
        {
            rooms.Remove(room);
        }

        public int Advance()
        {
            return (int)(Amount() * Config.PRICE_ADVANCE);
        }

        public void CheckIn() 
        {
            if (isAdvance == true) 
            {
                this.isCheckIn = true;

                foreach (Room room in rooms)
                {
                    room.IsFree = false;
                }
            }
            else
                throw new WrongCheckInException();
        }

        public void CheckOut() 
        {
            if (client.PaymentStatus() ==  0)  
            {
                this.IsCheckOut = true;

                foreach (Room room in rooms)
                {
                    room.IsFree = true;
                    room.IsClear = false;
                }
            }
            else
                throw new WrongCheckOutException();
        }
      
        // Cena wyliczana ze wzoru = ((Cena pokoju * Wskaźnik sezonu) * Ilość dzni) + zniżka za dzieci. Eventualnei Cena jest obliżana dla grup lub dla pobytu minimum 2 tygodnie.

        public double CostSeason(DateTime date)
        {
            double costSeason = 0;

            if (date >= Config.MEDIUM_SEASON_START && date <= Config.MEDIUM_SEASON_FINISH)
                costSeason = Config.PRICE_MEDIUM_SEASON;
            else if (date >= Config.MEDIUM_SEASON_FINISH && date <= Config.HIGH_SEASON_FINISH)
                costSeason = Config.PRICE_HIGH_SEASON;
            else if (date >= Config.sPECIAL_SEASON_START && date <= Config.SPECIAL_SEASON_FINISH)
                costSeason = Config.PRICE_SPECIAL_SEASON;
            else
                costSeason = Config.PRICE_LOW_SEASON;

                return costSeason;
        }

        public double CostRoom(Room room)
        {
            double costRoom = 0;
            double cost = 0;

            switch (room.NumberOfPeople())
            {
                case 1:
                    costRoom = Config.PRICE_ROOM_1;
                    break;
                case 2:
                    costRoom = Config.PRICE_ROOM_2;
                    break;
                case 3:
                    costRoom = Config.PRICE_ROOM_3;
                    break;
                case 4:
                    costRoom = Config.PRICE_ROOM_4;
                    break;
                case 5:
                    costRoom = Config.PRICE_ROOM_5;
                    break;
                case 6:
                    costRoom = Config.PRICE_ROOM_6;
                    break;
            }

            for (int i = 0; i < Days(); i++)
            {
                cost += costRoom * CostSeason(CheckInDate.AddDays(i));
            }
            
            return cost;
        }

        public double CostPeople()
        {
            double cost = 0;

            foreach (Room room in rooms)
            {
                cost += CostRoom(room);      
            }

            return ((cost/NumberOfPeople()) * adults * Config.priceForPerson + (cost / NumberOfPeople()) * children * Config.priceForChild + (cost / NumberOfPeople()) * babies * Config.priceForBabies);
        }

        public override double Amount()
        {
            double cost = CostPeople();
            
            if(rooms.Count() >= 3)
                cost = cost * Config.DISCOUNT_GROUPS;
            if (Days() >= 14)
                cost = cost * Config.DISCOUNT_LONG_STAY;

            if(isAdvance == true)
                return cost - Advance();

            return cost;
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
            builder.AppendLine("Is check-in: " + this.isCheckIn + "  Is check-out: " + this.isCheckOut + "  Advance: " + Advance());
            builder.AppendLine("Quantity of days: " + Days() + "  Cost of reservation: " + Amount());

            return builder.ToString();
        }
    }
}
