using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Hungary : Calendar {
        public Hungary() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }

            public override string name() { return "Hungary"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);
                if (isWeekend(w)
                    // Easter Monday
                    || (dd == em)
                    // Whit Monday
                    || (dd == em+49)
                    // New Year's Day
                    || (d == 1  && m == Month.January)
                    // National Day
                    || (d == 15  && m == Month.March)
                    // Labour Day
                    || (d == 1  && m == Month.May)
                    // Constitution Day
                    || (d == 20  && m == Month.August)
                    // Republic Day
                    || (d == 23  && m == Month.October)
                    // All Saints Day
                    || (d == 1  && m == Month.November)
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