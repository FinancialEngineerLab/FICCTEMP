using System;
using System.Collections.Generic;
using System.Text;

namespace FHS.MarketData {
    
    public class Norway : Calendar {
        public Norway() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
          
            public override string name() { return "Norway"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // Holy Thursday
                    || (dd == em-4)
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
                    // May Day
                    || (d == 1 && m == Month.May)
                    // National Independence Day
                    || (d == 17 && m == Month.May)
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

