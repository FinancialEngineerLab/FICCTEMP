using System;
using System.Collections.Generic;

namespace FHS.MarketData {
    
    public class Turkey :  Calendar {
        public Turkey() : base(Impl.Singleton) { }

		
        class Impl : Calendar {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }

            public override string name() { return "Turkey"; }
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
                    // 23 nisan / National Holiday
                    || (d == 23 && m == Month.April)
                    // 19 may/ National Holiday
                    || (d == 19 && m == Month.May)
                    // 30 aug/ National Holiday
                    || (d == 30 && m == Month.August)
                    ///29 ekim  National Holiday
                    || (d == 29 && m == Month.October))
                    return false;

                // Local Holidays
                if (y == 2004) {
                    // kurban
                    if ((m == Month.February && d <= 4)
                    // ramazan
                        || (m == Month.November && d >= 14 && d <= 16))
                        return false;
                } else if (y == 2005) {
                    // kurban
                    if ((m == Month.January && d >= 19 && d <= 21)
                    // ramazan
                        || (m == Month.November && d >= 2 && d <= 5))
                        return false;
                } else if (y == 2006) {
                    // kurban
                    if ((m == Month.January && d >= 9 && d <= 13)
                    // ramazan
                        || (m == Month.October && d >= 23 && d <= 25)
                    // kurban
                        || (m == Month.December && d >= 30))
                        return false;
                } else if (y == 2007) {
                    // kurban
                    if ((m == Month.January && d <= 4)
                    // ramazan
                        || (m == Month.October && d >= 11 && d <= 14)
                    // kurban
                        || (m == Month.December && d >= 19 && d <= 23))
                        return false;
                } else if (y == 2008) {
                    // ramazan
                    if ((m == Month.September && d >= 29)
                        || (m == Month.October && d <= 2)
                        // kurban
                        || (m == Month.December && d >= 7 && d <= 11))
                        return false;
                }
                return true;
            }
        };
    }
}




