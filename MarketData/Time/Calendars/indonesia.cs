using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Indonesia : Calendar {
		
        public enum Market {
            BEJ,  //!< Jakarta stock exchange
            JSX   //!< Jakarta stock exchange
        };

        public Indonesia() : this(Market.BEJ) { }
        public Indonesia(Market m)
            : base() {
            // all calendar instances on the same market share the same
            // implementation instance
            switch (m) {
                case Market.BEJ:
                case Market.JSX:
                    calendar_ = BEJ.Singleton;
                    break;
                default:
                    throw new ArgumentException("Unknown market: " + m); ;
            }
        }

		
        class BEJ : Calendar.WesternImpl {
            public static readonly BEJ Singleton = new BEJ();
            private BEJ() { }
        
            public override string name() { return "Jakarta stock exchange"; }
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
                    // Ascension Thursday
                    || (dd == em+38)
                    // Independence Day
                    || (d == 17 && m == Month.August)
                    // Christmas
                    || (d == 25 && m == Month.December)
                    )
                    return false;
                if (y == 2005) {
                    if (// Idul Adha
                        (d == 21 && m == Month.January)
                        // Imlek
                        || (d == 9 && m == Month.February)
                        // Moslem's New Year Day
                        || (d == 10 && m == Month.February)
                        // Nyepi
                        || (d == 11 && m == Month.March)
                        // Birthday of Prophet Muhammad SAW
                        || (d == 22 && m == Month.April)
                        // Waisak
                        || (d == 24 && m == Month.May)
                        // Ascension of Prophet Muhammad SAW
                        || (d == 2 && m == Month.September)
                        // Idul Fitri
                        || ((d == 3 || d == 4) && m == Month.November)
                        // National leaves
                        || ((d == 2 || d == 7 || d == 8) && m == Month.November)
                        || (d == 26 && m == Month.December)
                        )
                        return false;
                }
                if (y == 2006) {
                    if (// Idul Adha
                        (d == 10 && m == Month.January)
                        // Moslem's New Year Day
                        || (d == 31 && m == Month.January)
                        // Nyepi
                        || (d == 30 && m == Month.March)
                        // Birthday of Prophet Muhammad SAW
                        || (d == 10 && m == Month.April)
                        // Ascension of Prophet Muhammad SAW
                        || (d == 21 && m == Month.August)
                        // Idul Fitri
                        || ((d == 24 || d == 25) && m == Month.October)
                        // National leaves
                        || ((d == 23 || d == 26 || d == 27) && m == Month.October)
                        )
                        return false;
                }
                if (y == 2007) {
                    if (// Nyepi
                        (d == 19 && m == Month.March)
                        // Waisak
                        || (d == 1 && m == Month.June)
                        // Ied Adha
                        || (d == 20 && m == Month.December)
                        // National leaves
                        || (d == 18 && m == Month.May)
                        || ((d == 12 || d == 15 || d == 16) && m == Month.October)
                        || ((d == 21 || d == 24) && m == Month.October)
                        )
                        return false;
                }
                if (y == 2007) {
                    if (// Islamic New Year
                        ((d == 10 || d == 11) && m == Month.January)
                        // Chinese New Year
                        || ((d == 7 || d == 8) && m == Month.February)
                        // Saka's New Year
                        || (d == 7 && m == Month.March)
                        // Birthday of the prophet Muhammad SAW
                        || (d == 20 && m == Month.March)
                        // Vesak Day
                        || (d == 20 && m == Month.May)
                        // Isra' Mi'raj of the prophet Muhammad SAW
                        || (d == 30 && m == Month.July)
                        // Ied Fitr
                        || (d == 30 && m == Month.September)
                        || ((d == 1 || d == 2 || d == 3) && m == Month.October)
                        // Ied Adha
                        || (d == 8 && m == Month.December)
                        // Islamic New Year
                        || (d == 29 && m == Month.December)
                        // New Year's Eve
                        || (d == 31 && m == Month.December)
                        // National leave
                        || (d == 18 && m == Month.August)
                        )
                        return false;
                }
                return true;
            }
        }
    }
}
