using System;

namespace FHS.MarketData {
    
    public class Sweden :  Calendar {
        public Sweden() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
         
            public override string name() { return "Sweden"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);
                if (isWeekend(w)
                    // Good Friday
                    || (dd == em-3)
                    // Easter Monday
                    || (dd == em)
                    // Ascension Thursday
                    || (dd == em+38)
                    // Whit Monday
                    || (dd == em+49)
                    // New Year's Day
                    || (d == 1  && m == Month.January)
                    // Epiphany
                    || (d == 6  && m == Month.January)
                    // May Day
                    || (d == 1  && m == Month.May)
                    // June 6 id National Day but is not a holiday.
                    // It has been debated wheter or not this day should be
                    // declared as a holiday.
                    // As of 2002 the Stockholmborsen is open that day
                    // || (d == 6  && m == June)
                    // Midsummer Eve (Friday between June 18-24)
                    || (w == DayOfWeek.Friday && (d >= 18 && d <= 24) && m == Month.June)
                    // Christmas Eve
                    || (d == 24 && m == Month.December)
                    // Christmas Day
                    || (d == 25 && m == Month.December)
                    // Boxing Day
                    || (d == 26 && m == Month.December)
                    // New Year's Eve
                    || (d == 31 && m == Month.December))
                    return false;
                return true;
            }
        }
    }
}

