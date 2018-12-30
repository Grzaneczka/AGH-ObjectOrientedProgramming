using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Room
    {
        int roomNumber;
        int numberOfSingleBeds;
        int numberOfMarriageBeds;

        bool isBalcony;
        bool isClear;
        bool isFree;

        // Konstruktory 

        public Room(int roomNumber, int numberOfSingleBeds, int numberOfMarriageBeds, bool isBalcony, bool isClear, bool isFree)
        {
            this.roomNumber = roomNumber;
            this.numberOfSingleBeds = numberOfSingleBeds;
            this.numberOfMarriageBeds = numberOfMarriageBeds;
            this.isBalcony = isBalcony;
            this.isClear = isClear;
            this.isFree = isFree;
        }

        // Getery i Setery 

        public int RoomNumber { get => roomNumber; set => roomNumber = value; }

        public int NumberOfSingleBeds { get => numberOfSingleBeds; set => numberOfSingleBeds = value; }

        public int NumberOfMarriageBeds { get => numberOfMarriageBeds; set => numberOfMarriageBeds = value; }

        public bool IsBalcony { get => isBalcony; set => isBalcony = value; }

        public bool IsClear { get => isClear; set => isClear = value; }

        public bool IsFree { get => isFree; set => isFree = value; }

        // To string 

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Room number: {0}\n", this.roomNumber);
            builder.AppendFormat("Number of single beds: {0},   Number of marriage beds: {1}\n ", this.numberOfSingleBeds, this.numberOfMarriageBeds);
            builder.AppendFormat("Is balcony: {0},   Is clear: {1},   Is free: {2}\n ", this.isBalcony, this.isClear, this.isFree);

            return builder.ToString();
        }

    }
}
