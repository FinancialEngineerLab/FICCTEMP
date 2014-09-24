using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Singapore : Calendar {
        public Singapore() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
          
            public override string name() { return "Singapore exchange"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1 && m == Month.January)
                    // Good Friday
                    || (dd == em - 3)
                    // Labor Day
                    || (d == 1 && m == Month.May)
                    // National Day
                    || (d == 9 && m == Month.August)
                    // Christmas Day
                    || (d == 25 && m == Month.December)

                    // Chinese New Year
                    || ((d == 22 || d == 23) && m == Month.January && y == 2004)
                    || ((d == 9 || d == 10) && m == Month.February && y == 2005)
                    || ((d == 30 || d == 31) && m == Month.January && y == 2006)
                    || ((d == 19 || d == 20) && m == Month.February && y == 2007)
                    || ((d == 7 || d == 8) && m == Month.February && y == 2008)

                    // Hari Raya Haji
                    || ((d == 1 || d == 2) && m == Month.February && y == 2004)
                    || (d == 21 && m == Month.January && y == 2005)
                    || (d == 10 && m == Month.January && y == 2006)
                    || (d == 2 && m == Month.January && y == 2007)
                    || (d == 20 && m == Month.December && y == 2007)
                    || (d == 8 && m == Month.December && y == 2008)

                    // Vesak Poya Day
                    || (d == 2 && m == Month.June && y == 2004)
                    || (d == 22 && m == Month.May && y == 2005)
                    || (d == 12 && m == Month.May && y == 2006)
                    || (d == 31 && m == Month.May && y == 2007)
                    || (d == 18 && m == Month.May && y == 2008)

                    // Deepavali
                    || (d == 11 && m == Month.November && y == 2004)
                    || (d == 8 && m == Month.November && y == 2007)
                    || (d == 28 && m == Month.October && y == 2008)

                    // Diwali
                    || (d == 1 && m == Month.November && y == 2005)

                    // Hari Raya Puasa
                    || ((d == 14 || d == 15) && m == Month.November && y == 2004)
                    || (d == 3 && m == Month.November && y == 2005)
                    || (d == 24 && m == Month.October && y == 2006)
                    || (d == 13 && m == Month.October && y == 2007)
                    || (d == 1 && m == Month.October && y == 2008)
                    )
                    return false;
                return true;
            }
        }
    }
}


