using System;

namespace FHS.MarketData
{
	
    public class Actual365Fixed : DayCounter
    {
        public Actual365Fixed() : base(Impl.Singleton) { }

		
        class Impl : DayCounter
        {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }

            public override string name() { return "Actual/365 (Fixed)"; }
            public override int dayCount(Date d1, Date d2) { return (d2 - d1); }
            public override double yearFraction(Date d1, Date d2, Date refPeriodStart, Date refPeriodEnd)
            {
                return dayCount(d1, d2) / 365.0;
            }

        }
    }
}