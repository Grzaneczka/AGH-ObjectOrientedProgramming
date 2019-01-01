using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Contig
    {
        // Cena wyliczana ze wzoru = (cena za osobę * ilość osób + cena wyporzyczanego pokoju (zależny od wielkości)) * cena za sezon 

        internal static DateTime mediumSeasonStart = new DateTime(2019, 04, 01);
        internal static DateTime mediumSeasonFinish = new DateTime(2019, 06, 30);
        internal static DateTime highSeasonFinish = new DateTime(2019, 08, 31);
        internal static DateTime specialSeasonStart = new DateTime(2019, 12, 23);
        internal static DateTime specialSeasonFinish = new DateTime(2020, 12, 03);

        internal static double priceOfLowSeason = 1;
        internal static double priceOfMediumSeason = 1.20;
        internal static double priceOfHighSeason = 1.50;
        internal static double priceOfSpecialSeason = 1.60;

        internal static double priceForChild = 0.5;
        internal static double priceForBabies = 0;
        internal static double priceForPerson = 1;

        internal static double priceRoom1 = 30;
        internal static double priceRoom2 = 65;
        internal static double priceRoom3 = 100;
        internal static double priceRoom4 = 130;
        internal static double priceRoom5 = 150;
        internal static double priceRoom6 = 215;

        internal static double priceAdvances = 0.05;
    }
}
