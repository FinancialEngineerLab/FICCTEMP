using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Mexico : Calendar {
        public Mexico() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
        
            public override string name() { return "Mexican stock exchange"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);
                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1 && m == Month.January)
                    // Constitution Day
                    || (d == 5 && m == Month.February)
                    // Birthday of Benito Juarez
                    || (d == 21 && m == Month.March)
                    // Holy Thursday
                    || (dd == em-4)
                    // Good Friday
                    || (dd == em-3)
                    // Labour Day
                    || (d == 1 && m == Month.May)
                    // National Day
                    || (d == 16 && m == Month.September)
                    // Our Lady of Guadalupe
                    || (d == 12 && m == Month.December)
                    // Christmas
                    || (d == 25 && m == Month.December))
                    return false;
                return true;
            }
        }
    }
}