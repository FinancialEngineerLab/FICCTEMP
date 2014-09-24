using System;
using System.Collections.Generic;
using System.Text;

namespace FHS.MarketData {
    
    public class SaudiArabia : Calendar {
        public SaudiArabia() : base(Impl.Singleton) { }

		
        class Impl : Calendar {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
          
            public override string name() { return "Tadawul"; }
            public override bool isWeekend(DayOfWeek w) {
                return w == DayOfWeek.Thursday || w == DayOfWeek.Friday;
            }

            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;

                if (isWeekend(w)
                    // National Day
                    || (d == 23 && m == Month.September)
                    // Eid Al-Adha
                    || (d >= 1 && d <= 6 && m == Month.February && y==2004)
                    || (d >= 21 && d <= 25 && m == Month.January && y==2005)
                    // Eid Al-Fitr
                    || (d >= 25 && d <= 29 && m == Month.November && y==2004)
                    || (d >= 14 && d <= 18 && m == Month.November && y==2005)
                    )
                    return false;
                return true;
            }
        }
    }
}