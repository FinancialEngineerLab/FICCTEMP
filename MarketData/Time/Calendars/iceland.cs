using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Iceland : Calendar {
        public Iceland() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
          
            public override string name() { return "Iceland stock exchange"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day (possibly moved to Monday)
                    || ((d == 1 || ((d == 2 || d == 3) && w == DayOfWeek.Monday))
                        && m == Month.January)
                    // Holy Thursday
                    || (dd == em-4)
                    // Good Friday
                    || (dd == em-3)
                    // Easter Monday
                    || (dd == em)
                    // First day of Summer
                    || (d >= 19 && d <= 25 && w == DayOfWeek.Thursday && m == Month.April)
                    // Ascension Thursday
                    || (dd == em+38)
                    // Pentecost Monday
                    || (dd == em+49)
                    // Labour Day
                    || (d == 1 && m == Month.May)
                    // Independence Day
                    || (d == 17 && m == Month.June)
                    // Commerce Day
                    || (d <= 7 && w == DayOfWeek.Monday && m == Month.August)
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
