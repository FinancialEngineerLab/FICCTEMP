using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Taiwan :  Calendar {
        public Taiwan() : base(Impl.Singleton) { }

		
        class Impl : Calendar {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }

            public override string name() { return "Taiwan stock exchange"; }
            public override bool isWeekend(DayOfWeek w) {
                return w == DayOfWeek.Saturday || w == DayOfWeek.Sunday;
            }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;

                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1 && m == Month.January)
                    // Peace Memorial Day
                    || (d == 28 && m == Month.February)
                    // Labor Day
                    || (d == 1 && m == Month.May)
                    // double Tenth
                    || (d == 10 && m == Month.October)
                    )
                    return false;

                if (y == 2002) {
                    // Dragon Boat Festival and Moon Festival fall on Saturday
                    if (// Chinese Lunar New Year
                        (d >= 9 && d <= 17 && m == Month.February)
                        // Tomb Sweeping Day
                        || (d == 5 && m == Month.April)
                        )
                        return false;
                }
                if (y == 2003) {
                    // Tomb Sweeping Day falls on Saturday
                    if (// Chinese Lunar New Year
                        ((d >= 31 && m == Month.January) || (d <= 5 && m == Month.February))
                        // Dragon Boat Festival
                        || (d == 4 && m == Month.June)
                        // Moon Festival
                        || (d == 11 && m == Month.September)
                        )
                        return false;
                }
                if (y == 2004) {
                    // Tomb Sweeping Day falls on Sunday
                    if (// Chinese Lunar New Year
                        (d >= 21 && d <= 26 && m == Month.January)
                        // Dragon Boat Festival
                        || (d == 22 && m == Month.June)
                        // Moon Festival
                        || (d == 28 && m == Month.September)
                        )
                        return false;
                }
                if (y == 2005) {
                    // Dragon Boat and Moon Festival fall on Saturday or Sunday
                    if (// Chinese Lunar New Year
                        (d >= 6 && d <= 13 && m == Month.February)
                        // Tomb Sweeping Day
                        || (d == 5 && m == Month.April)
                        // make up for Labor Day, not seen in other years
                        || (d == 2 && m == Month.May)
                        )
                        return false;
                }
                if (y == 2006) {
                    // Dragon Boat and Moon Festival fall on Saturday or Sunday
                    if (// Chinese Lunar New Year
                        ((d >= 28 && m == Month.January) || (d <= 5 && m == Month.February))
                        // Tomb Sweeping Day
                        || (d == 5 && m == Month.April)
                        // Dragon Boat Festival
                        || (d == 31 && m == Month.May)
                        // Moon Festival
                        || (d == 6 && m == Month.October)
                        )
                        return false;
                }
                if (y == 2007) {
                    if (// Chinese Lunar New Year
                        (d >= 17 && d <= 25 && m == Month.February)
                        // Tomb Sweeping Day
                        || (d == 5 && m == Month.April)
                        // adjusted holidays
                        || (d == 6 && m == Month.April)
                        || (d == 18 && m == Month.June)
                        // Dragon Boat Festival
                        || (d == 19 && m == Month.June)
                        // adjusted holiday
                        || (d == 24 && m == Month.September)
                        // Moon Festival
                        || (d == 25 && m == Month.September)
                        )
                        return false;
                }
                if (y == 2008) {
                    if (// Chinese Lunar New Year
                        (d >= 4 && d <= 11 && m == Month.February)
                        // Tomb Sweeping Day
                        || (d == 4 && m == Month.April)
                        )
                        return false;
                }
                return true;
            }
        };

    };

}