using System;
using System.Text;

namespace FHS.MarketData
{
    
    public class SouthAfrica :  Calendar {
        public SouthAfrica() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }

            public override string name() { return "South Africa"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day (possibly moved to Monday)
                    || ((d == 1 || (d == 2 && w == DayOfWeek.Monday)) && m == Month.January)
                    // Good Friday
                    || (dd == em-3)
                    // Family Day
                    || (dd == em)
                    // Human Rights Day, March 21st (possibly moved to Monday)
                    || ((d == 21 || (d == 22 && w == DayOfWeek.Monday))
                        && m == Month.March)
                    // Freedom Day, April 27th (possibly moved to Monday)
                    || ((d == 27 || (d == 28 && w == DayOfWeek.Monday))
                        && m == Month.April)
                    // Election Day, April 14th 2004
                    || (d == 14 && m == Month.April && y == 2004)
                    // Workers Day, May 1st (possibly moved to Monday)
                    || ((d == 1 || (d == 2 && w == DayOfWeek.Monday))
                        && m == Month.May)
                    // Youth Day, June 16th (possibly moved to Monday)
                    || ((d == 16 || (d == 17 && w == DayOfWeek.Monday))
                        && m == Month.June)
                    // National Women's Day, August 9th (possibly moved to Monday)
                    || ((d == 9 || (d == 10 && w == DayOfWeek.Monday))
                        && m == Month.August)
                    // Heritage Day, September 24th (possibly moved to Monday)
                    || ((d == 24 || (d == 25 && w == DayOfWeek.Monday))
                        && m == Month.September)
                    // Day of Reconciliation, December 16th
                    // (possibly moved to Monday)
                    || ((d == 16 || (d == 17 && w == DayOfWeek.Monday))
                        && m == Month.December)
                    // Christmas
                    || (d == 25 && m == Month.December)
                    // Day of Goodwill (possibly moved to Monday)
                    || ((d == 26 || (d == 27 && w == DayOfWeek.Monday))
                        && m == Month.December)
                    )
                    return false;
                return true;
            }
        }
    }
}

