using System;

namespace FHS.MarketData {
    
	public class NullCalendar : Calendar {
        public NullCalendar() : base(Impl.Singleton) { }

		
        class Impl : Calendar {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
            
            public override string name() { return "Null calendar"; }
            public override bool isWeekend(DayOfWeek w) { return false; }
            public override bool isBusinessDay(Date d) { return true; }
        }
	}
}