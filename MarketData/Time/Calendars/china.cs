using System;
using System.Text;

namespace FHS.MarketData {
    
    public class China : Calendar {
        public China() : base(Impl.Singleton) { }

		
        class Impl : Calendar {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }

            public override string name() { return "Shanghai stock exchange"; }
            public override bool isWeekend(DayOfWeek w) {
                return w == DayOfWeek.Saturday || w == DayOfWeek.Sunday;
            }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day;
                Month m = (Month)date.Month;
                int y = date.Year;

                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1 && m == Month.January)
                    || (d == 3 && m == Month.January && y == 2005)
                    || ((d == 2 || d == 3) && m == Month.January && y == 2006)
                    || (d <= 3 && m == Month.January && y == 2007)
                    || (d == 31 && m == Month.December && y == 2007)
                    || (d == 1 && m == Month.January && y == 2008)
                            // Chinese New Year
                    || (d >= 19 && d <= 28 && m == Month.January && y == 2004)
                    || (d >= 7 && d <= 15 && m == Month.February && y == 2005)
                    || (((d >= 26 && m == Month.January) || (d <= 3 && m == Month.February))
                        && y == 2006)
                    || (d >= 17 && d <= 25 && m == Month.February && y == 2007)
                    || (d >= 6 && d <= 12 && m == Month.February && y == 2008)
                            // Ching Ming Festival
                    || (d == 4 && m == Month.April && y <= 2008)
                            // Labor Day
                    || (d >= 1 && d <= 7 && m == Month.May && y <= 2007)
                    || (d >= 1 && d <= 2 && m == Month.May && y == 2008)
                            // Tuen Ng Festival
                    || (d == 9 && m == Month.June && y <= 2008)
                            // Mid-Autumn Festival
                    || (d == 15 && m == Month.September && y <= 2008)
                            // National Day
                    || (d >= 1 && d <= 7 && m == Month.October && y <= 2007)
                    || (d >= 29 && m == Month.September && y == 2008)
                    || (d <= 3 && m == Month.October && y == 2008)
                    )
                    return false;
                return true;
            }
        }
    }
}

