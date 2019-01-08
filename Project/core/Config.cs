using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    static class Config
    {

        internal static DateTime MEDIUM_SEASON_START = new DateTime(2019, 04, 01);
        internal static DateTime MEDIUM_SEASON_FINISH = new DateTime(2019, 06, 30);
        internal static DateTime HIGH_SEASON_FINISH = new DateTime(2019, 08, 31);
        internal static DateTime sPECIAL_SEASON_START = new DateTime(2019, 12, 23);
        internal static DateTime SPECIAL_SEASON_FINISH = new DateTime(2020, 12, 03);

        internal static double PRICE_LOW_SEASON = 1;
        internal static double PRICE_MEDIUM_SEASON = 1.20;
        internal static double PRICE_HIGH_SEASON = 1.50;
        internal static double PRICE_SPECIAL_SEASON = 1.60;

        internal static double priceForChild = 0.5;
        internal static double priceForBabies = 0;
        internal static double priceForPerson = 1;

        internal static double PRICE_ROOM_1 = 30;
        internal static double PRICE_ROOM_2 = 65;
        internal static double PRICE_ROOM_3 = 100;
        internal static double PRICE_ROOM_4 = 130;
        internal static double PRICE_ROOM_5 = 150;
        internal static double PRICE_ROOM_6 = 215;

        internal static double DISCOUNT_GROUPS = 0.75; 
        internal static double DISCOUNT_LONG_STAY = 0.8;

        internal static double PRICE_ADVANCE = 0.05;

        internal static int AUTOMATIC_CANCEL_DAYS = 2;
    }
}
