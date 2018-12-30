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
            return "Room number: " + this.roomNumber + "  Number of single beds: " + this.numberOfSingleBeds + "  Number of marriage beds: " + this.numberOfMarriageBeds + "  Is balcony: " + this.isBalcony + "  Is clear: " + this.isClear + "  Is free: " + this.isFree;
        }

    }
}
