using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Constant
    {
        // Cena wyliczana ze wzoru = (cena za osobę * ilość osób + cena wyporzyczanego pokoju (zależny od wielkości)) * cena za sezon 

        //public DateTime lowSeason;
        //public DateTime mediumSeason;
        //public DateTime highSeason;
        //public DateTime specialSeason;

        public double priceOfLowSeason;
        public double priceOfMediumSeason;
        public double priceOfHighSeason;
        public double priceOfSpecialSeason;

        public double priceForChild;
        public double priceForBabies;
        public double priceForPerson;

        public double priceRoom1;
        public double priceRoom2;
        public double priceRoom3;
        public double priceRoom4;
        public double priceRoom5;
        public double priceRoom6;


        // Konstruktory 

        public Constant()
        {
            this.priceForBabies = 0;
            this.priceForChild = 30;
            this.priceForPerson = 60;

            this.priceRoom1 = 20;
            this.priceRoom2 = 30;
            this.priceRoom3 = 40;
            this.priceRoom4 = 50;
            this.priceRoom5 = 60;
            this.priceRoom6 = 70;

            this.priceOfLowSeason = 1;
            this.priceOfMediumSeason = 1.20;
            this.priceOfHighSeason = 1.50;
            this.priceOfSpecialSeason = 1.60;
        }

    }
}
