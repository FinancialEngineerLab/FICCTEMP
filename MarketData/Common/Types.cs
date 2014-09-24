using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHS.MarketData
{
    public interface IValue
    {
        double value(double v);
    }

    public struct Const
    {
        public const double Epsilon = 2.2204460492503131e-016;
        public const double QL_MAX_double = 1.7976931348623158e+308;
        public const double QL_MIN_double = -1.7976931348623158e+308;

        public const double M_SQRT_2 = 0.7071067811865475244008443621048490392848359376887;
        public const double M_1_SQRTPI = 0.564189583547756286948;

        public const double M_LN2 = 0.693147180559945309417;
        public const double M_PI = 3.141592653589793238462643383280;
        public const double M_PI_2 = 1.57079632679489661923;
    }

    public struct tag
    {
        // Market property
        public const string Attribute = "Attribute";
        public const string Calendar = "Calendar";
        public const string EffectivePeriod = "EffectivePeriod";
        public const string Maturity = "Maturity";
        public const string Marketdata = "Data";
        public const string BusinessDayConvention = "BusinessDayConvention";
        public const string IsEndOfMonth = "IsEndOfMonth";
        public const string DayCounter = "DayCounter";
        public const string CashFlowPeriod = "CashFlowPeriod";

        // Curve property
        public const string Method = "Method";
        public const string CurveParameter = "CurveParameter";
    }

    public enum Compounding
    {
        Simple = 0,
        Compounded = 1,
        Continuous = 2,
        SimpleThenCompounded
    };

    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12,
        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr = 4,
        Jun = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12,
        jan = 1,
        feb = 2,
        mar = 3,
        apr = 4,
        jun = 6,
        jul = 7,
        aug = 8,
        sep = 9,
        oct = 10,
        nov = 11,
        dec = 12,
        JAN = 1,
        FEB = 2,
        MAR = 3,
        APR = 4,
        JUN = 6,
        JUL = 7,
        AUG = 8,
        SEP = 9,
        OCT = 10,
        NOV = 11,
        DEC = 12
    };

    public enum BusinessDayConvention
    {
        // ISDA
        Following,
        ModifiedFollowing,
        Preceding,
        // NON ISDA
        ModifiedPreceding,
        Unadjusted
    };

    public enum TimeUnit
    {
        Days,
        Weeks,
        Months,
        Years
    };

    public enum Frequency
    {
        NoFrequency = -1,
        Once = 0,
        Annual = 1,
        Semiannual = 2,
        EveryFourthMonth = 3,
        Quarterly = 4,
        Bimonthly = 6,
        Monthly = 12,
        EveryFourthWeek = 13,
        Biweekly = 26,
        Weekly = 52,
        Daily = 365,
        OtherFrequency = 999
    };

    public struct DateGeneration
    {
        public enum Rule
        {
            Backward,
            Forward,
            Zero,
            ThirdWednesday,
            Twentieth,
            TwentiethIMM,
            OldCDS,
            CDS
        }
    };

    public enum CapFloorType { Cap, Floor, Collar };
    
    public class TimeSeries<T> : Dictionary<Date, T>
    {
        // constructors
        public TimeSeries() : base() { }
        public TimeSeries(int size) : base(size) { }
    }

    public static partial class Utils
    {
        public static BusinessDayConvention BizDayConvention(String bdc)
        {
            BusinessDayConvention _bizDayConvention;
            switch (bdc)
            {
                case "MF":
                    _bizDayConvention = BusinessDayConvention.ModifiedFollowing;
                    break;
                case "F":
                    _bizDayConvention = BusinessDayConvention.Following;
                    break;
                case "MP":
                    _bizDayConvention = BusinessDayConvention.ModifiedPreceding;
                    break;
                case "P":
                    _bizDayConvention = BusinessDayConvention.Preceding;
                    break;
                case "1":
                    _bizDayConvention = BusinessDayConvention.Following;
                    break;
                case "2":
                    _bizDayConvention = BusinessDayConvention.ModifiedFollowing;
                    break;
                case "3":
                    _bizDayConvention = BusinessDayConvention.Preceding;
                    break;
                case "4":
                    _bizDayConvention = BusinessDayConvention.ModifiedPreceding;
                    break;
                default:
                    _bizDayConvention = BusinessDayConvention.Unadjusted;
                    break;
            }
            return _bizDayConvention;
        }
    }

    public struct Position
    {
        public enum Type { Long, Short };
    };
}