using System;
using System.Text;

namespace FHS.MarketData {
    
    public class NewZealand : Calendar {
        public NewZealand() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
          
            public override string name() { return "New Zealand"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);
                if (isWeekend(w)
                    // New Year's Day (possibly moved to Monday or Tuesday)
                    || ((d == 1 || (d == 3 && (w == DayOfWeek.Monday || w == DayOfWeek.Tuesday))) &&
                        m == Month.January)
                    // Day after New Year's Day (possibly moved to Mon or Tuesday)
                    || ((d == 2 || (d == 4 && (w == DayOfWeek.Monday || w == DayOfWeek.Tuesday))) &&
                        m == Month.January)
                    // Anniversary Day, Monday nearest January 22nd
                    || ((d >= 19 && d <= 25) && w == DayOfWeek.Monday && m == Month.January)
                    // Waitangi Day. February 6th
                    || (d == 6 && m == Month.February)
                    // Good Friday
                    || (dd == em-3)
                    // Easter Monday
                    || (dd == em)
                    // ANZAC Day. April 25th
                    || (d == 25 && m == Month.April)
                    // Queen's Birthday, first Monday in June
                    || (d <= 7 && w == DayOfWeek.Monday && m == Month.June)
                    // Labour Day, fourth Monday in October
                    || ((d >= 22 && d <= 28) && w == DayOfWeek.Monday && m == Month.October)
                    // Christmas, December 25th (possibly Monday or Tuesday)
                    || ((d == 25 || (d == 27 && (w == DayOfWeek.Monday || w == DayOfWeek.Tuesday)))
                        && m == Month.December)
                    // Boxing Day, December 26th (possibly Monday or Tuesday)
                    || ((d == 26 || (d == 28 && (w == DayOfWeek.Monday || w == DayOfWeek.Tuesday)))
                        && m == Month.December))
                    return false;
                return true;
            }
        }
    }
}