using System;
using System.Collections.Generic;
using System.Text;

namespace FHS.MarketData {
    
    public class Slovakia :  Calendar {
        public Slovakia() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }

            public override string name() { return "Bratislava stock exchange"; }
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
                    || (dd == em-3)
                    // Easter Monday
                    || (dd == em)
                    // May Day
                    || (d == 1 && m == Month.May)
                    // Liberation of the Republic
                    || (d == 8 && m == Month.May)
                    // SS. Cyril and Methodius
                    || (d == 5 && m == Month.July)
                    // Slovak National Uprising
                    || (d == 29 && m == Month.August)
                    // Constitution of the Slovak Republic
                    || (d == 1 && m == Month.September)
                    // Our Lady of the Seven Sorrows
                    || (d == 15 && m == Month.September)
                    // All Saints Day
                    || (d == 1 && m == Month.November)
                    // Freedom and Democracy of the Slovak Republic
                    || (d == 17 && m == Month.November)
                    // Christmas Eve
                    || (d == 24 && m == Month.December)
                    // Christmas
                    || (d == 25 && m == Month.December)
                    // St. Stephen
                    || (d == 26 && m == Month.December)
                    // unidentified closing days for stock exchange
                    || (d >= 24 && d <= 31 && m == Month.December && y == 2004)
                    || (d >= 24 && d <= 31 && m == Month.December && y == 2005))
                    return false;
                return true;
            }
        }
    }
}
