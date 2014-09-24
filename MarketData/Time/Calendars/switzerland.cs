using System;

namespace FHS.MarketData {
    
    public class Switzerland : Calendar {
        public Switzerland() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
         
            public override string name() { return "Switzerland"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1  && m == Month.January)
                    // Berchtoldstag
                    || (d == 2  && m == Month.January)
                    // Good Friday
                    || (dd == em-3)
                    // Easter Monday
                    || (dd == em)
                    // Ascension Day
                    || (dd == em+38)
                    // Whit Monday
                    || (dd == em+49)
                    // Labour Day
                    || (d == 1  && m == Month.May)
                    // National Day
                    || (d == 1  && m == Month.August)
                    // Christmas
                    || (d == 25 && m == Month.December)
                    // St. Stephen's Day
                    || (d == 26 && m == Month.December))
                    return false;
                return true;
            }
        };
      };
}


