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

       // Konstruktory 

        public Room(int roomNumber, int numberOfSingleBeds, int numberOfMarriageBeds, bool isBalcony, bool isClear)
        {
            this.roomNumber = roomNumber;
            this.numberOfSingleBeds = numberOfSingleBeds;
            this.numberOfMarriageBeds = numberOfMarriageBeds;
            this.isBalcony = isBalcony;
            this.isClear = isClear;
        }

        // Getery i Setery 

        public int RoomNumber { get => roomNumber; set => roomNumber = value; }

        public int NumberOfSingleBeds { get => numberOfSingleBeds; set => numberOfSingleBeds = value; }

        public int NumberOfMarriageBeds { get => numberOfMarriageBeds; set => numberOfMarriageBeds = value; }

        public bool IsBalcony { get => isBalcony; set => isBalcony = value; }

        public bool IsClear { get => isClear; set => isClear = value; }

        // Metody dodatkowe

        public int NumberOfPeople()
        {
            return (numberOfSingleBeds * 1 + numberOfMarriageBeds * 2);
        }

        // To string 

        public override string ToString()
        {
            return "Room number: " + this.roomNumber + " Number of people: " + NumberOfPeople() + "  Number of single beds: " + this.numberOfSingleBeds + "  Number of marriage beds: " + this.numberOfMarriageBeds + "  Is balcony: " + this.isBalcony + "  Is clear: " + this.isClear;
        }

    }
}
