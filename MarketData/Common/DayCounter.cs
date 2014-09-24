using System;

namespace FHS.MarketData
{
    
    public class DayCounter
    {
        protected DayCounter dayCounter_;
        public DayCounter dayCounter
        {
            get { return dayCounter_; }
            set { dayCounter_ = value; }
        }

        public DayCounter() { }
        public DayCounter(DayCounter d) { dayCounter_ = d; }
        public DayCounter(String d)
        {
            String D = d.ToUpper();
            switch (D)
            {
                case "A365":
                case "ACT365":
                case "0001":
                case "0004":
                case "3":
                    dayCounter_ = new Actual365Fixed();
                    break;
                case "A360":
                case "ACT360":
                case "0002":
                case "1":
                    dayCounter_ = new Actual360();
                    break;
                case "30360":
                case "0032":
                case "4":
                    dayCounter_ = new Thirty360();
                    break;
                case "A365FIX":
                    dayCounter_ = new Actual365Fixed();
                    break;
                case "2":
                    dayCounter_ = new ActualActual();
                    break;
                default:
                    dayCounter_ = new Actual365Fixed();
                    break;
            }
        }

        public static bool operator ==(DayCounter d1, DayCounter d2)
        {
            return ((Object)d1 == null || (Object)d2 == null) ?
                   ((Object)d1 == null && (Object)d2 == null) :
                   (d1.empty() && d2.empty()) || (!d1.empty() && !d2.empty() && d1.name() == d2.name());
        }
        public static bool operator !=(DayCounter d1, DayCounter d2) { return !(d1 == d2); }


        public bool empty() { return dayCounter_ == null; }

        public virtual string name()
        {
            if (empty()) return "No implementation provided";
            else return dayCounter_.name();
        }

        public virtual int dayCount(Date d1, Date d2)
        {
            if (empty()) throw new Exception("No implementation provided");
            return dayCounter_.dayCount(d1, d2);
        }

        public double yearFraction(Date d1, Date d2) { return yearFraction(d1, d2, d1, d2); }
        public virtual double yearFraction(Date d1, Date d2, Date refPeriodStart, Date refPeriodEnd)
        {
            if (empty()) throw new Exception("No implementation provided");
            return dayCounter_.yearFraction(d1, d2, refPeriodStart, refPeriodEnd);
        }

        public override bool Equals(object o) { return this == (DayCounter)o; }
        public override int GetHashCode() { return 0; }
        public override string ToString() { return this.name(); }
    }
}