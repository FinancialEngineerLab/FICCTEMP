using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Japan : Calendar {
        public Japan() : base(Impl.Singleton) { }

		
        class Impl : Calendar {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
        
            public override string name() { return "Japan"; }
            public override bool isWeekend(DayOfWeek w) {
                return w == DayOfWeek.Saturday || w == DayOfWeek.Sunday;
            }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;

                // equinox calculation
                double exact_vernal_equinox_time = 20.69115;
                double exact_autumnal_equinox_time = 23.09;
                double diff_per_year = 0.242194;
                double moving_amount = (y - 2000) * diff_per_year;
                int number_of_leap_years = (y-2000)/4+(y-2000)/100-(y-2000)/400;
                int ve = (int)( exact_vernal_equinox_time + moving_amount - number_of_leap_years);// vernal equinox day
                int ae = (int)( exact_autumnal_equinox_time + moving_amount - number_of_leap_years ); // autumnal equinox day
                // checks
                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1  && m == Month.January)
                    // Bank Holiday
                    || (d == 2  && m == Month.January)
                    // Bank Holiday
                    || (d == 3  && m == Month.January)
                    // Coming of Age Day (2nd Monday in January),
                    // was January 15th until 2000
                    || (w == DayOfWeek.Monday && (d >= 8 && d <= 14) && m == Month.January
                        && y >= 2000)
                    || ((d == 15 || (d == 16 && w == DayOfWeek.Monday)) && m == Month.January
                        && y < 2000)
                    // National Foundation Day
                    || ((d == 11 || (d == 12 && w == DayOfWeek.Monday)) && m == Month.February)
                    // Vernal Equinox
                    || ((d == ve || (d == ve + 1 && w == DayOfWeek.Monday)) && m == Month.March)
                    // Constitution Memorial Day
                    || (d == 3 && m == Month.May)
                    || ((d == 3 || (d == 6 && w == DayOfWeek.Wednesday)) && m == Month.May && y >= 2007)
                    // Greenery Day
                    || ((d == 4 || (d == 6 && w == DayOfWeek.Tuesday)) && m == Month.May && y >= 2007)
                    || ((d == 29 || (d == 30 && w == DayOfWeek.Monday)) && m == Month.April && y < 2007)
                    // Holiday for a Nation (Showa's Day)
                    || ((d == 29 || (d == 30 && w == DayOfWeek.Monday)) && m == Month.April && y >= 2007)
                    || (d == 4 && m == Month.May && y < 2007)                    
                    // Children's Day
                    || ((d == 5 || (d == 6 && w == DayOfWeek.Monday)) && m == Month.May)
                    // Marine Day (3rd Monday in July),
                    // was July 20th until 2003, not a holiday before 1996
                    || (w == DayOfWeek.Monday && (d >= 15 && d <= 21) && m == Month.July
                        && y >= 2003)
                    || ((d == 20 || (d == 21 && w == DayOfWeek.Monday)) && m == Month.July
                        && y >= 1996 && y < 2003)
                    // Respect for the Aged Day (3rd Monday in September),
                    // was September 15th until 2003
                    || (w == DayOfWeek.Monday && (d >= 15 && d <= 21) && m == Month.September
                        && y >= 2003)
                    || ((d == 15 || (d == 16 && w == DayOfWeek.Monday)) && m == Month.September
                        && y < 2003)
                    // If a single day falls between Respect for the Aged Day
                    // and the Autumnal Equinox, it is holiday
                    || (w == DayOfWeek.Tuesday && d + 1 == ae && d >= 16 && d <= 22
                        && m == Month.September && y >= 2003)
                    // Autumnal Equinox
                    || ((d == ae || (d == ae + 1 && w == DayOfWeek.Monday)) && m == Month.September)
                    // Health and Sports Day (2nd Monday in October),
                    // was October 10th until 2000
                    || (w == DayOfWeek.Monday && (d >= 8 && d <= 14) && m == Month.October
                        && y >= 2000)
                    || ((d == 10 || (d == 11 && w == DayOfWeek.Monday)) && m == Month.October
                        && y < 2000)
                    // National Culture Day
                    || ((d == 3 || (d == 4 && w == DayOfWeek.Monday)) && m == Month.November)
                    // Labor Thanksgiving Day
                    || ((d == 23 || (d == 24 && w == DayOfWeek.Monday)) && m == Month.November)
                    // Emperor's Birthday
                    || ((d == 23 || (d == 24 && w == DayOfWeek.Monday)) && m == Month.December
                        && y >= 1989)
                    // Bank Holiday
                    || (d == 31 && m == Month.December)
                    // one-shot holidays
                    // Marriage of Prince Akihito
                    || (d == 10 && m == Month.April && y == 1959)
                    // Rites of Imperial Funeral
                    || (d == 24 && m == Month.February && y == 1989)
                    // Enthronement Ceremony
                    || (d == 12 && m == Month.November && y == 1990)
                    // Marriage of Prince Naruhito
                    || (d == 9 && m == Month.June && y == 1993))
                    return false;
                return true;
            }
        };
    };
}

