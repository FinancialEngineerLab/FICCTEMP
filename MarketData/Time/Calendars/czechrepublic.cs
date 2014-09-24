using System;
using System.Text;

namespace FHS.MarketData {
    
    public class CzechRepublic : Calendar {
        public CzechRepublic() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }

            public override string name() { return "Prague stock exchange"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1 && m == Month.January)
                    // Easter Monday
                    || (dd == em)
                    // Labour Day
                    || (d == 1 && m == Month.May)
                    // Liberation Day
                    || (d == 8 && m == Month.May)
                    // SS. Cyril and Methodius
                    || (d == 5 && m == Month.July)
                    // Jan Hus Day
                    || (d == 6 && m == Month.July)
                    // Czech Statehood Day
                    || (d == 28 && m == Month.September)
                    // Independence Day
                    || (d == 28 && m == Month.October)
                    // Struggle for Freedom and Democracy Day
                    || (d == 17 && m == Month.November)
                    // Christmas Eve
                    || (d == 24 && m == Month.December)
                    // Christmas
                    || (d == 25 && m == Month.December)
                    // St. Stephen
                    || (d == 26 && m == Month.December)
                    // unidentified closing days for stock exchange
                    || (d == 2 && m == Month.January && y == 2004)
                    || (d == 31 && m == Month.December && y == 2004))
                    return false;
                return true;
            }
        }
    }
}
