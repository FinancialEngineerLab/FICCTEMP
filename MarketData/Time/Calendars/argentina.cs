using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Argentina : Calendar {
        public Argentina() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
         
            public override string name() { return "Buenos Aires stock exchange"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1 && m == Month.January)
                    // Holy Thursday
                    || (dd == em-4)
                    // Good Friday
                    || (dd == em-3)
                    // Labour Day
                    || (d == 1 && m == Month.May)
                    // May Revolution
                    || (d == 25 && m == Month.May)
                    // Death of General Manuel Belgrano
                    || (d >= 15 && d <= 21 && w == DayOfWeek.Monday && m == Month.June)
                    // Independence Day
                    || (d == 9 && m == Month.July)
                    // Death of General Jos?de San Mart?
                    || (d >= 15 && d <= 21 && w == DayOfWeek.Monday && m == Month.August)
                    // Columbus Day
                    || ((d == 10 || d == 11 || d == 12 || d == 15 || d == 16)
                        && w == DayOfWeek.Monday && m == Month.October)
                    // Immaculate Conception
                    || (d == 8 && m == Month.December)
                    // Christmas Eve
                    || (d == 24 && m == Month.December)
                    // New Year's Eve
                    || ((d == 31 || (d == 30 && w == DayOfWeek.Friday)) && m == Month.December))
                    return false;
                return true;
            }
        };
   };
}
