using System;
using System.Text;

namespace FHS.MarketData {
    
   public class Italy : Calendar {
       //! Italian calendars
	   
        public enum Market {
            Settlement,     //!< generic settlement calendar
            Exchange        //!< Milan stock-exchange calendar
        };

        public Italy() : this(Market.Settlement) { }
        public Italy(Market m)
            : base() {
            // all calendar instances on the same market share the same
            // implementation instance
            switch (m) {
                case Market.Settlement:
                    calendar_ = Settlement.Singleton;
                    break;
                case Market.Exchange:
                    calendar_ = Exchange.Singleton;
                    break;
                default:
                    throw new ArgumentException("Unknown market: " + m); ;
            }
        }

		
        class Settlement : Calendar.WesternImpl {
            public static readonly Settlement Singleton = new Settlement();
            private Settlement() { }
        
            public override string name() { return "Italian settlement"; }
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
                    // Easter Monday
                    || (dd == em)
                    // Liberation Day
                    || (d == 25 && m == Month.April)
                    // Labour Day
                    || (d == 1 && m == Month.May)
                    // Republic Day
                    || (d == 2 && m == Month.June && y >= 2000)
                    // Assumption
                    || (d == 15 && m == Month.August)
                    // All Saints' Day
                    || (d == 1 && m == Month.November)
                    // Immaculate Conception
                    || (d == 8 && m == Month.December)
                    // Christmas
                    || (d == 25 && m == Month.December)
                    // St. Stephen
                    || (d == 26 && m == Month.December)
                    // December 31st, 1999 only
                    || (d == 31 && m == Month.December && y == 1999))
                    return false;
                return true;
            }
        }

		
        class Exchange : Calendar.WesternImpl {
            public static readonly Exchange Singleton = new Exchange();
            private Exchange() { }
       
            public override string name() { return "Milan stock exchange"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1 && m == Month.January)
                    // Good Friday
                    || (dd == em-3)
                    // Easter Monday
                    || (dd == em)
                    // Labour Day
                    || (d == 1 && m == Month.May)
                    // Assumption
                    || (d == 15 && m == Month.August)
                    // Christmas' Eve
                    || (d == 24 && m == Month.December)
                    // Christmas
                    || (d == 25 && m == Month.December)
                    // St. Stephen
                    || (d == 26 && m == Month.December)
                    // New Year's Eve
                    || (d == 31 && m == Month.December))
                    return false;
                return true;
            }
        };
    };

}
