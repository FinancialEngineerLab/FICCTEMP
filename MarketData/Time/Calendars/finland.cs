using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Finland : Calendar {
        public Finland() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
          
            public override string name() { return "Finland"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1 && m == Month.January)
                    // Epiphany
                    || (d == 6 && m == Month.January)
                    // Good Friday
                    || (dd == em - 3)
                    // Easter Monday
                    || (dd == em)
                    // Ascension Thursday
                    || (dd == em + 38)
                    // Labour Day
                    || (d == 1 && m == Month.May)
                    // Midsummer Eve (Friday between June 18-24)
                    || (w == DayOfWeek.Friday && (d >= 18 && d <= 24) && m == Month.June)
                    // Independence Day
                    || (d == 6 && m == Month.December)
                    // Christmas Eve
                    || (d == 24 && m == Month.December)
                    // Christmas
                    || (d == 25 && m == Month.December)
                    // Boxing Day
                    || (d == 26 && m == Month.December))
                    return false;
                return true;
            }
        }
    }
}

