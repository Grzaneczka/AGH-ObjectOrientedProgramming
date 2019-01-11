using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]

    public static class Config
    {

        public static DateTime MEDIUM_SEASON_START = new DateTime(2019, 04, 01);
        public static DateTime MEDIUM_SEASON_FINISH = new DateTime(2019, 06, 30);
        public static DateTime HIGH_SEASON_FINISH = new DateTime(2019, 08, 31);
        public static DateTime SPECIAL_SEASON_START = new DateTime(2019, 12, 23);
        public static DateTime SPECIAL_SEASON_FINISH = new DateTime(2020, 12, 03);

        public static double PRICE_LOW_SEASON = 1;
        public static double PRICE_MEDIUM_SEASON = 1.20;
        public static double PRICE_HIGH_SEASON = 1.50;
        public static double PRICE_SPECIAL_SEASON = 1.60;

        public static double PRICE_FOR_CHILD = 0.5;
        public static double PRICE_FOR_BABIES = 0;
        public static double PRICE_FOR_ADULT = 1;

        public static double PRICE_ROOM_1 = 30;
        public static double PRICE_ROOM_2 = 65;
        public static double PRICE_ROOM_3 = 100;
        public static double PRICE_ROOM_4 = 130;
        public static double PRICE_ROOM_5 = 150;
        public static double PRICE_ROOM_6 = 215;

        public static double DISCOUNT_GROUPS = 0.75;
        public static double DISCOUNT_LONG_STAY = 0.8;

        public static double PRICE_ADVANCE = 0.05;

        public static int AUTOMATIC_CANCEL_DAYS = 2;
    }
}
