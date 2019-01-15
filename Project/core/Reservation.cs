using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]

    public class Reservation : Payment 
    {

        private Client client;
        private List<Room> rooms = new List<Room>();
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

        public Reservation()
        {

        }
        
        public Reservation(string title, Client client, string checkInDate, string checkOutDate,int numberOfAdults, int numberOfChildren, int numberOfBabies, bool checkIn, bool checkOut, bool advance) : base(title)
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

        public List<Room> Rooms { get => rooms; }

        public Client Client { get => client; set => client = value; }

        public bool IsAdvance { get => isAdvance; set => isAdvance = value; }

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
            return (int)(TotalAmonut() * Config.PRICE_ADVANCE);
        }

        public void CheckIn() 
        {
            if (isAdvance) 
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
           
            this.IsCheckOut = true;

            foreach (Room room in rooms)
            {
                room.IsFree = true;
                room.IsClear = false;
            }
           
        }
      
        // Cena wyliczana ze wzoru = ((Cena pokoju * Wskaźnik sezonu) * Ilość dzni) + zniżka za dzieci. Eventualnei Cena jest obliżana dla grup lub dla pobytu minimum 2 tygodnie.

        public double CostSeason(DateTime date)
        {
            double costSeason = 0;

            if (date >= Config.MEDIUM_SEASON_START && date <= Config.MEDIUM_SEASON_FINISH)
                costSeason = Config.PRICE_MEDIUM_SEASON;
            else if (date >= Config.MEDIUM_SEASON_FINISH && date <= Config.HIGH_SEASON_FINISH)
                costSeason = Config.PRICE_HIGH_SEASON;
            else if (date >= Config.SPECIAL_SEASON_START && date <= Config.SPECIAL_SEASON_FINISH)
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

            return ((cost/NumberOfPeople()) * adults * Config.PRICE_FOR_ADULT + (cost / NumberOfPeople()) * children * Config.PRICE_FOR_CHILD + (cost / NumberOfPeople()) * babies * Config.PRICE_FOR_BABIES);
        }

        public double TotalAmonut()
        {
            double cost = CostPeople();

            if (rooms.Count() >= 3)
                cost *= Config.DISCOUNT_GROUPS;     // do poprawy
            if (Days() >= 14)
                cost *= Config.DISCOUNT_LONG_STAY;   // do poprawy

            return cost;
        }

        public override double Amount()
        {
            if(isAdvance)
                return TotalAmonut() - Advance();
            else
                return TotalAmonut();
        }

        // To string 

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" Room:  ");

            foreach (Room room in rooms)
            {
                builder.AppendLine(room.RoomNumber.ToString());
            }


            return base.ToString() + builder.ToString();
        }
    }
}
