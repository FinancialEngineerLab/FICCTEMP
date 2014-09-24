using System;
using System.Collections.Generic;

namespace FHS.MarketData
{
	
    public class Thirty360 : DayCounter
    {
		
        public enum Thirty360Convention { USA, BondBasis, European, EurobondBasis, Italian };

        public Thirty360() : base(US_Impl.Singleton) { }
        public Thirty360(Thirty360Convention c) : base(conventions(c)) { }

        private static DayCounter conventions(Thirty360Convention c)
        {
            switch (c)
            {
                case Thirty360Convention.USA:
                case Thirty360Convention.BondBasis:
                    return US_Impl.Singleton;
                case Thirty360Convention.European:
                case Thirty360Convention.EurobondBasis:
                    return EU_Impl.Singleton;
                case Thirty360Convention.Italian:
                    return IT_Impl.Singleton;
                default:
                    throw new ArgumentException("Unknown 30/360 convention: " + c); ;
            }
        }

		
        public class US_Impl : DayCounter
        {
            public static readonly US_Impl Singleton = new US_Impl();
            private US_Impl() { }

            public override string name() { return "30/360 (Bond Basis)"; }
            public override int dayCount(Date d1, Date d2)
            {
                int dd1 = d1.Day, dd2 = d2.Day;
                int mm1 = d1.Month, mm2 = d2.Month;
                int yy1 = d1.Year, yy2 = d2.Year;

                if (dd2 == 31 && dd1 < 30) { dd2 = 1; mm2++; }

                return 360 * (yy2 - yy1) + 30 * (mm2 - mm1 - 1) + System.Math.Max(0, 30 - dd1) + System.Math.Min(30, dd2);
            }

            public override double yearFraction(Date d1, Date d2, Date d3, Date d4) { return dayCount(d1, d2) / 360.0; }
        };

		
        private class EU_Impl : DayCounter
        {
            public static readonly EU_Impl Singleton = new EU_Impl();
            private EU_Impl() { }

            public override string name() { return "30E/360 (Eurobond Basis)"; }
            public override int dayCount(Date d1, Date d2)
            {
                int dd1 = d1.Day, dd2 = d2.Day;
                int mm1 = d1.Month, mm2 = d2.Month;
                int yy1 = d1.Year, yy2 = d2.Year;

                return 360 * (yy2 - yy1) + 30 * (mm2 - mm1 - 1) + System.Math.Max(0, 30 - dd1) + System.Math.Min(30, dd2);
            }

            public override double yearFraction(Date d1, Date d2, Date d3, Date d4) { return dayCount(d1, d2) / 360.0; }
        };

		
        private class IT_Impl : DayCounter
        {
            public static readonly IT_Impl Singleton = new IT_Impl();
            private IT_Impl() { }

            public override string name() { return "30/360 (Italian)"; }
            public override int dayCount(Date d1, Date d2)
            {
                int dd1 = d1.Day, dd2 = d2.Day;
                int mm1 = d1.Month, mm2 = d2.Month;
                int yy1 = d1.Year, yy2 = d2.Year;

                if (mm1 == 2 && dd1 > 27) dd1 = 30;
                if (mm2 == 2 && dd2 > 27) dd2 = 30;

                return 360 * (yy2 - yy1) + 30 * (mm2 - mm1 - 1) + System.Math.Max(0, 30 - dd1) + System.Math.Min(30, dd2);
            }

            public override double yearFraction(Date d1, Date d2, Date d3, Date d4) { return dayCount(d1, d2) / 360.0; }
        };

    }
}