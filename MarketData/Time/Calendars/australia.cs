using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Australia : Calendar {
        public Australia() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
          
            public override string name() { return "Australia"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day (possibly moved to Monday)
                    || (d == 1  && m == Month.January)
                    // Australia Day, January 26th (possibly moved to Monday)
                    || ((d == 26 || ((d == 27 || d == 28) && w == DayOfWeek.Monday)) &&
                        m == Month.January)
                    // Good Friday
                    || (dd == em-3)
                    // Easter Monday
                    || (dd == em)
                    // ANZAC Day, April 25th (possibly moved to Monday)
                    || ((d == 25 || (d == 26 && w == DayOfWeek.Monday)) && m == Month.April)
                    // Queen's Birthday, second Monday in June
                    || ((d > 7 && d <= 14) && w == DayOfWeek.Monday && m == Month.June)
                    // Bank Holiday, first Monday in August
                    || (d <= 7 && w == DayOfWeek.Monday && m == Month.August)
                    // Labour Day, first Monday in October
                    || (d <= 7 && w == DayOfWeek.Monday && m == Month.October)
                    // Christmas, December 25th (possibly Monday or Tuesday)
                    || ((d == 25 || (d == 27 && (w == DayOfWeek.Monday || w == DayOfWeek.Tuesday)))
                        && m == Month.December)
                    // Boxing Day, December 26th (possibly Monday or Tuesday)
                    || ((d == 26 || (d == 28 && (w == DayOfWeek.Monday || w == DayOfWeek.Tuesday)))
                        && m == Month.December))
                    return false;
                return true;
            }
        };
    };

}



    
