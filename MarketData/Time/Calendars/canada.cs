using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Canada : Calendar {
		
        public enum Market {
            Settlement,       //!< generic settlement calendar
            TSX               //!< Toronto stock exchange calendar
        };

        public Canada() : this(Market.Settlement) { }
        public Canada(Market m)
            : base() {
            // all calendar instances on the same market share the same
            // implementation instance
            switch (m) {
                case Market.Settlement:
                    calendar_ = Settlement.Singleton;
                    break;
                case Market.TSX:
                    calendar_ = TSX.Singleton;
                    break;
                default:
                    throw new ArgumentException("Unknown market: " + m); ;
            }
        }

		
        class Settlement : Calendar.WesternImpl {
            public static readonly Settlement Singleton = new Settlement();
            private Settlement() { }

            public override string name() { return "Canada"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day (possibly moved to Monday)
                    || ((d == 1 || (d == 2 && w == DayOfWeek.Monday)) && m == Month.January)
                    // Family Day (third Monday in February, since 2008)
                    || ((d >= 15 && d <= 21) && w == DayOfWeek.Monday && m == Month.February
                        && y >= 2008)
                    // Good Friday
                    || (dd == em - 3)
                    // Easter Monday
                    || (dd == em)
                    // The Monday on or preceding 24 May (Victoria Day)
                    || (d > 17 && d <= 24 && w == DayOfWeek.Monday && m == Month.May)
                    // July 1st, possibly moved to Monday (Canada Day)
                    || ((d == 1 || ((d == 2 || d == 3) && w == DayOfWeek.Monday)) && m == Month.July)
                    // first Monday of August (Provincial Holiday)
                    || (d <= 7 && w == DayOfWeek.Monday && m == Month.August)
                    // first Monday of September (Labor Day)
                    || (d <= 7 && w == DayOfWeek.Monday && m == Month.September)
                    // second Monday of October (Thanksgiving Day)
                    || (d > 7 && d <= 14 && w == DayOfWeek.Monday && m == Month.October)
                    // November 11th (possibly moved to Monday)
                    || ((d == 11 || ((d == 12 || d == 13) && w == DayOfWeek.Monday))
                        && m == Month.November)
                    // Christmas (possibly moved to Monday or Tuesday)
                    || ((d == 25 || (d == 27 && (w == DayOfWeek.Monday || w == DayOfWeek.Tuesday)))
                        && m == Month.December)
                    // Boxing Day (possibly moved to Monday or Tuesday)
                    || ((d == 26 || (d == 28 && (w == DayOfWeek.Monday || w == DayOfWeek.Tuesday)))
                        && m == Month.December)
                    )
                    return false;
                return true;
            }
        }

		
        class TSX : Calendar.WesternImpl {
            public static readonly TSX Singleton = new TSX();
            private TSX() { }

            public override string name() { return "TSX"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day (possibly moved to Monday)
                || ((d == 1 || (d == 2 && w == DayOfWeek.Monday)) && m == Month.January)
                    // Family Day (third Monday in February, since 2008)
                || ((d >= 15 && d <= 21) && w == DayOfWeek.Monday && m == Month.February
                    && y >= 2008)
                    // Good Friday
                || (dd == em - 3)
                    // Easter Monday
                || (dd == em)
                    // The Monday on or preceding 24 May (Victoria Day)
                || (d > 17 && d <= 24 && w == DayOfWeek.Monday && m == Month.May)
                    // July 1st, possibly moved to Monday (Canada Day)
                || ((d == 1 || ((d == 2 || d == 3) && w == DayOfWeek.Monday)) && m == Month.July)
                    // first Monday of August (Provincial Holiday)
                || (d <= 7 && w == DayOfWeek.Monday && m == Month.August)
                    // first Monday of September (Labor Day)
                || (d <= 7 && w == DayOfWeek.Monday && m == Month.September)
                    // second Monday of October (Thanksgiving Day)
                || (d > 7 && d <= 14 && w == DayOfWeek.Monday && m == Month.October)
                    // Christmas (possibly moved to Monday or Tuesday)
                || ((d == 25 || (d == 27 && (w == DayOfWeek.Monday || w == DayOfWeek.Tuesday)))
                    && m == Month.December)
                    // Boxing Day (possibly moved to Monday or Tuesday)
                || ((d == 26 || (d == 28 && (w == DayOfWeek.Monday || w == DayOfWeek.Tuesday)))
                    && m == Month.December)
                )
                    return false;
                return true;
            }
        }
    }
}