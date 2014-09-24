using System;
using System.Collections.Generic;
using System.Text;

namespace FHS.MarketData {
    
    public class Poland : Calendar {
        public Poland() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
          
            public override string name() { return "Poland"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // Easter Monday
                    || (dd == em)
                    // Corpus Christi
                    || (dd == em+59)
                    // New Year's Day
                    || (d == 1  && m == Month.January)
                    // May Day
                    || (d == 1  && m == Month.May)
                    // Constitution Day
                    || (d == 3  && m == Month.May)
                    // Assumption of the Blessed Virgin Mary
                    || (d == 15  && m == Month.August)
                    // All Saints Day
                    || (d == 1  && m == Month.November)
                    // Independence Day
                    || (d ==11  && m == Month.November)
                    // Christmas
                    || (d == 25 && m == Month.December)
                    // 2nd Day of Christmas
                    || (d == 26 && m == Month.December))
                    return false;
                return true;
            }
        }
    }
}

