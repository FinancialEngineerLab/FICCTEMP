using System;
using System.Collections.Generic;

namespace FHS.MarketData
{
    //! 1/1 day count convention
	
    public class OneDayCounter : DayCounter
    {
        public OneDayCounter() : base(Impl.Singleton) { }

		
        class Impl : DayCounter
        {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }

            public override string name() { return "1/1"; }
            public override int dayCount(Date d1, Date d2)
            {
                // the sign is all we need
                return (d2 >= d1 ? 1 : -1);
            }

            public override double yearFraction(Date d1, Date d2, Date refPeriodStart, Date refPeriodEnd)
            {
                return dayCount(d1, d2);
            }
        }
    }
}