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
        private DateTime date;
        private DateTime checkOutDate;

        private int numberOfAdults;
        private int numberOfChildren;
        private int numberOfBabies;

        private bool isCheckIn;
        private bool isCheckOut;

        // Konstruktory 

        public Reservation()
        {
            rooms = new List<Room>();
        }

        public Reservation(Client client, string checkInDate, string checkOutDate,int numberOfAdults, int numberOfChildren, int numberOfBabies, bool checkIn, bool checkOut, bool advance) : this()
        {
            if (!DateTime.TryParseExact(checkInDate, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out this.date)) 
                throw new FormatException("Invalid date format");

            if (!DateTime.TryParseExact(checkOutDate, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out this.checkOutDate))
                throw new FormatException("Invalid date format");

            this.client = client;
            this.NumberOfAdults = numberOfAdults;
            this.NumberOfChildren = numberOfChildren;
            this.NumberOfBabies = NumberOfBabies;
            this.IsCheckIn = checkIn;
            this.IsCheckOut = checkOut;

        }

        // Getery i setery 

        public DateTime CheckInDate { get => date; set => date = value; }

        public DateTime CheckOutDate { get => checkOutDate; set => checkOutDate = value; }

        public int NumberOfAdults { get => numberOfAdults; set => numberOfAdults = value; }

        public int NumberOfChildren { get => numberOfChildren; set => numberOfChildren = value; }

        public int NumberOfBabies { get => numberOfBabies; set => numberOfBabies = value; }

        public bool IsCheckIn { get => isCheckIn; set => isCheckIn = value; }

        public bool IsCheckOut { get => isCheckOut; set => isCheckOut = value; }

        // Metody dodatkowe

        public int Days()
        {
            TimeSpan days = checkOutDate - date;
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

        public void Remove(Room room)
        {
            rooms.Remove(room);
        }

        // Cena wyliczana ze wzoru = ((Cena pokoju * Wskaźnik sezonu) * Ilość dzni) + zniżka za dzieci. Eventualnei Cena jest obliżana dla grup lub dla pobytu minimum 2 tygodnie.
        
        public double CostSeason(DateTime date)
        {
            double costSeason = 0;

            if (date >= Contig.mediumSeasonStart && date <= Contig.mediumSeasonFinish)
                costSeason = Contig.priceOfMediumSeason;
            else if (date >= Contig.mediumSeasonFinish && date <= Contig.highSeasonFinish)
                costSeason = Contig.priceOfHighSeason;
            else if (date >= Contig.specialSeasonStart && date <= Contig.specialSeasonFinish)
                costSeason = Contig.priceOfSpecialSeason;
            else
                costSeason = Contig.priceOfLowSeason;

                return costSeason;
        }

        public double CostRoom(Room room)
        {
            double costRoom = 0;
            double cost = 0;

            switch (room.NumberOfPeople())
            {
                case 1:
                    costRoom = Contig.priceRoom1;
                    break;
                case 2:
                    costRoom = Contig.priceRoom2;
                    break;
                case 3:
                    costRoom = Contig.priceRoom3;
                    break;
                case 4:
                    costRoom = Contig.priceRoom4;
                    break;
                case 5:
                    costRoom = Contig.priceRoom5;
                    break;
                case 6:
                    costRoom = Contig.priceRoom6;
                    break;
            }

            for (int i = 0; i < Days(); i++)
            {
                cost = cost + costRoom * CostSeason(CheckInDate.AddDays(i));
            }
            
            return cost;
        }

        public double CostPeople()
        {
            double cost = 0;

            foreach (Room room in rooms)
            {
                cost = cost + CostRoom(room);      
            }

            return ((cost/NumberOfPeople()) * numberOfAdults * Contig.priceForPerson + (cost / NumberOfPeople()) * numberOfChildren * Contig.priceForChild + (cost / NumberOfPeople()) * numberOfBabies * Contig.priceForBabies);
        }

        public double Cost()
        {
            double cost = CostPeople();
            
            if(rooms.Count() >= 3)
                cost = cost * Contig.priceGroups;
            if (Days() >= 14)
                cost = cost * Contig.priceLongStay;

            return cost;
        }

        public int Advance()
        {
            return (int)(Cost() * Contig.priceAdvances);
        }

        public void CheckIn(Payment payment)
        {
            if (payment.AdvanceIsPaid() == true)
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

        public void CheckOut(Payment payment)
        {
            if (payment.GetCountOfNotPaiedSinglePayment() == 0)
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

            builder.AppendLine("Check-in date: " + this.date + "  Check-out date: " + this.checkOutDate);
            builder.AppendLine("Is check-in: " + this.isCheckIn + "  Is check-out: " + this.isCheckOut + "  Advance: " + Advance());
            builder.AppendLine("Quantity of days: " + Days() + "  Cost of reservation: " + Cost());

            return builder.ToString();
        }
       
    }
}
