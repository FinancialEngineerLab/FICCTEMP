using System;
using System.Text;

namespace FHS.MarketData {
    
    public class India : Calendar {
        public India() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
         
            public override string name() { return "National Stock Exchange of India"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // Republic Day
                    || (d == 26 && m == Month.January)
                    // Good Friday
                    || (dd == em-3)
                    // Ambedkar Jayanti
                    || (d == 14 && m == Month.April)
                    // Independence Day
                    || (d == 15 && m == Month.August)
                    // Gandhi Jayanti
                    || (d == 2 && m == Month.October)
                    // Christmas
                    || (d == 25 && m == Month.December)
                    )
                    return false;
                if (y == 2005) {
                    // Moharram, Holi, Maharashtra Day, and Ramzan Id fall
                    // on Saturday or Sunday in 2005
                    if (// Bakri Id
                        (d == 21 && m == Month.January)
                        // Ganesh Chaturthi
                        || (d == 7 && m == Month.September)
                        // Dasara
                        || (d == 12 && m == Month.October)
                        // Laxmi Puja
                        || (d == 1 && m == Month.November)
                        // Bhaubeej
                        || (d == 3 && m == Month.November)
                        // Guru Nanak Jayanti
                        || (d == 15 && m == Month.November)
                        )
                        return false;
                }
                if (y == 2006) {
                    if (// Bakri Id
                        (d == 11 && m == Month.January)
                        // Moharram
                        || (d == 9 && m == Month.February)
                        // Holi
                        || (d == 15 && m == Month.March)
                        // Ram Navami
                        || (d == 6 && m == Month.April)
                        // Mahavir Jayanti
                        || (d == 11 && m == Month.April)
                        // Maharashtra Day
                        || (d == 1 && m == Month.May)
                        // Bhaubeej
                        || (d == 24 && m == Month.October)
                        // Ramzan Id
                        || (d == 25 && m == Month.October)
                        )
                        return false;
                }
                if (y == 2007) {
                    if (// Bakri Id
                        (d == 1 && m == Month.January)
                        // Moharram
                        || (d == 30 && m == Month.January)
                        // Mahashivratri
                        || (d == 16 && m == Month.February)
                        // Ram Navami
                        || (d == 27 && m == Month.March)
                        // Maharashtra Day
                        || (d == 1 && m == Month.May)
                        // Buddha Pournima 
                        || (d == 2 && m == Month.May)
                        // Laxmi Puja
                        || (d == 9 && m == Month.November)
                        // Bakri Id (again)
                        || (d == 21 && m == Month.December)
                        )
                        return false;
                }
                if (y == 2008) {
                    if (// Mahashivratri
                        (d == 6 && m == Month.March)
                        // Id-E-Milad
                        || (d == 20 && m == Month.March)
                        // Mahavir Jayanti
                        || (d == 18 && m == Month.April)
                        // Maharashtra Day
                        || (d == 1 && m == Month.May)
                        // Buddha Pournima
                        || (d == 19 && m == Month.May)
                        // Ganesh Chaturthi
                        || (d == 3 && m == Month.September)
                        // Ramzan Id
                        || (d == 2 && m == Month.October)
                        // Dasara
                        || (d == 9 && m == Month.October)
                        // Laxmi Puja
                        || (d == 28 && m == Month.October)
                        // Bhau bhij
                        || (d == 30 && m == Month.October)
                        // Gurunanak Jayanti
                        || (d == 13 && m == Month.November)
                        // Bakri Id
                        || (d == 9 && m == Month.December)
                        )
                        return false;
                }
                return true;
            }
        }
    }
}




    