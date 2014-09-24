using System;
using System.Text;

namespace FHS.MarketData {
    
    public class Denmark : Calendar {
        public Denmark() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
       
            public override string name() { return "Denmark"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);
                if (isWeekend(w)
                      // Maunday Thursday
                      || (dd == em - 4)
                      // Good Friday
                      || (dd == em - 3)
                      // Easter Monday
                      || (dd == em)
                      // General Prayer Day
                      || (dd == em + 25)
                      // Ascension
                      || (dd == em + 38)
                      // Whit Monday
                      || (dd == em + 49)
                      // New Year's Day
                      || (d == 1 && m == Month.January)
                      // Constitution Day, June 5th
                      || (d == 5 && m == Month.June)
                      // Christmas
                      || (d == 25 && m == Month.December)
                      // Boxing Day
                      || (d == 26 && m == Month.December))
                      return false;
                  return true;
              }
        }
    }
}

