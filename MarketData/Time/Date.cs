using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHS.MarketData
{
    public class Date : IComparable
    {
        private DateTime date;

        public Date() { }
        public Date(int serialNumber)
        {
            date = (new DateTime(1899, 12, 31)).AddDays(serialNumber - 1);
        }
        public Date(int d, Month m, int y) : this(d, (int)m, y) { }
        public Date(int d, int m, int y) :
            this(new DateTime(y, m, d)) { }
        public Date(DateTime d)
        {
            date = d;
        }

        public Date(String yyyyMMdd)
        {
            Int32 y = Convert.ToInt32(yyyyMMdd.Substring(0, 4));
            Int32 m = Convert.ToInt32(yyyyMMdd.Substring(4, 2));
            Int32 d = Convert.ToInt32(yyyyMMdd.Substring(6, 2));

            if (y == 0) y = 1900;
            if (m == 0) m = 1;
            if (d == 0) d = 1;

            date = new DateTime(y, m, d);
        }

        public int serialNumber() { return (date - new DateTime(1899, 12, 31).Date).Days + 1; }
        public int Day { get { return date.Day; } }
        public int Month { get { return date.Month; } }
        public int month() { return date.Month; }
        public int Year { get { return date.Year; } }
        public int year() { return date.Year; }
        public int DayOfYear { get { return date.DayOfYear; } }
        public int weekday() { return (int)date.DayOfWeek + 1; }
        public DayOfWeek DayOfWeek { get { return date.DayOfWeek; } }

        public static Date minDate() { return new Date(1, 1, 1901); }
        public static Date maxDate() { return new Date(31, 12, 2199); }
        public static Date Today { get { return new Date(DateTime.Today); } }
        public static bool IsLeapYear(int y) { return DateTime.IsLeapYear(y); }
        public static int DaysInMonth(int y, int m) { return DateTime.DaysInMonth(y, m); }

        public static Date endOfMonth(Date d) { return (d - d.Day + DaysInMonth(d.Year, d.Month)); }
        public static bool isEndOfMonth(Date d) { return (d.Day == DaysInMonth(d.Year, d.Month)); }

        public static Date nextWeekday(Date d, DayOfWeek dayOfWeek)
        {
            int wd = dayOfWeek - d.DayOfWeek;
            return d + (wd >= 0 ? wd : (7 + wd));
        }

        public static Date nthWeekday(int nth, DayOfWeek dayOfWeek, int m, int y)
        {
            if (nth < 1 || nth > 5)
                throw new ArgumentException("Wrong n-th weekday in a given month/year: " + nth);
            DayOfWeek first = new DateTime(y, m, 1).DayOfWeek;
            int skip = nth - (dayOfWeek >= first ? 1 : 0);
            return new Date(1, m, y) + (int)(dayOfWeek - first + skip * 7);
        }

        public static int monthOffset(int m, bool leapYear)
        {
            int[] MonthOffset = { 0,  31,  59,  90, 120, 151,     // Jan - Jun
                                  181, 212, 243, 273, 304, 334,   // Jun - Dec
                                  365     // used in dayOfMonth to bracket day
                                };
            return (MonthOffset[m - 1] + ((leapYear && m > 1) ? 1 : 0));
        }

        public static Date advance(Date d, int n, TimeUnit u)
        {
            switch (u)
            {
                case TimeUnit.Days:
                    return d + n;
                case TimeUnit.Weeks:
                    return d + 7 * n;
                case TimeUnit.Months: { DateTime t = d.date; return new Date(t.AddMonths(n)); }
                case TimeUnit.Years: { DateTime t = d.date; return new Date(t.AddYears(n)); }
                default:
                    throw new ArgumentException("Unknown TimeUnit: " + u);
            }
        }


        // operator overloads
        public static int operator -(Date d1, Date d2) { return (d1.date - d2.date).Days; }
        public static Date operator +(Date d, int days) { DateTime t = d.date; return new Date(t.AddDays(days)); }
        public static Date operator -(Date d, int days) { DateTime t = d.date; return new Date(t.AddDays(-days)); }
        public static Date operator +(Date d, TimeUnit u) { return advance(d, 1, u); }
        public static Date operator -(Date d, TimeUnit u) { return advance(d, -1, u); }
        public static Date operator +(Date d, Period p) { return advance(d, p.length(), p.units()); }
        public static Date operator -(Date d, Period p) { return advance(d, -p.length(), p.units()); }
        public static Date operator ++(Date d) { d = d + 1; return d; }
        public static Date operator --(Date d) { d = d - 1; return d; }
        public static Date Min(Date d1, Date d2) { return d1 < d2 ? d1 : d2; }
        public static Date Max(Date d1, Date d2) { return d1 > d2 ? d1 : d2; }

        // this is the overload for DateTime operations
        public static implicit operator DateTime(Date d) { return d.date; }

        public static bool operator ==(Date d1, Date d2)
        {
            return ((Object)d1 == null || (Object)d2 == null) ?
                   ((Object)d1 == null && (Object)d2 == null) :
                   d1.date == d2.date;
        }
        public static bool operator !=(Date d1, Date d2) { return (!(d1 == d2)); }
        public static bool operator <(Date d1, Date d2) { return (d1.date < d2.date); }
        public static bool operator <=(Date d1, Date d2) { return (d1.date <= d2.date); }
        public static bool operator >(Date d1, Date d2) { return (d1.date > d2.date); }
        public static bool operator >=(Date d1, Date d2) { return (d1.date >= d2.date); }

        public DateTime ToDateTime() { return date; }
        public string ToLongDateString() { return date.ToLongDateString(); }
        public string ToShortDateString() { return date.ToShortDateString(); }
        public override string ToString() { return date.ToString(); }
        public string ToString(String format) { return date.ToString(format); }
        public override bool Equals(object o) { return (this == (Date)o); }
        public override int GetHashCode() { return 0; }

        // IComparable interface
        public int CompareTo(object obj)
        {
            if (this < (Date)obj)
                return -1;
            else if (this == (Date)obj)
                return 0;
            else return 1;
        }
    }
}
