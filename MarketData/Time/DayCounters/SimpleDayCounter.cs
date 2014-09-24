using System;
using System.Collections.Generic;

namespace FHS.MarketData
{
	
    public class SimpleDayCounter : DayCounter
    {
        public SimpleDayCounter() : base(Impl.Singleton) { }

		
        class Impl : DayCounter
        {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }

            public override string name() { return "Simple"; }
            public override int dayCount(Date d1, Date d2) { return Thirty360.US_Impl.Singleton.dayCount(d1, d2); }
            public override double yearFraction(Date d1, Date d2, Date d3, Date d4)
            {
                int dm1 = d1.Day,
                    dm2 = d2.Day;

                if (dm1 == dm2 ||
                    // e.g., Aug 30 -> Feb 28 ?
                    (dm1 > dm2 && Date.isEndOfMonth(d2)) ||
                    // e.g., Feb 28 -> Aug 30 ?
                    (dm1 < dm2 && Date.isEndOfMonth(d1)))
                {

                    return (d2.Year - d1.Year) + (d2.Month - d1.Month) / 12.0;
                }
                else
                    return Thirty360.US_Impl.Singleton.yearFraction(d1, d2, d3, d4);
            }
        }
    }
}