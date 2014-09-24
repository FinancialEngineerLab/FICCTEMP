using System;
using System.Text;

namespace FHS.MarketData {
    
    public class SouthKorea : Calendar {
		
        public enum Market { Settlement,  //!< Public holidays
                      KRX          //!< Korea exchange
        }

        public SouthKorea() : this(Market.KRX) { }
        public SouthKorea(Market m)
            : base() {
            // all calendar instances on the same market share the same
            // implementation instance
            switch (m) {
                case Market.Settlement:
                    calendar_ = Settlement.Singleton;
                    break;
                case Market.KRX:
                    calendar_ = KRX.Singleton;
                    break;
                default:
                    throw new ArgumentException("Unknown market: " + m); ;
            }
        }

		
        class Settlement : Calendar {
            public static readonly Settlement Singleton = new Settlement();
            public Settlement() { }
          
            public override string name() { return "South-Korean settlement"; }
            public override bool isWeekend(DayOfWeek w) {
                return w == DayOfWeek.Saturday || w == DayOfWeek.Sunday;
            }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;

                if (isWeekend(w)
                    // New Year's Day
                    || (d == 1 && m == Month.January)
                    // Independence Day
                    || (d == 1 && m == Month.March)
                    // Arbour Day
                    || (d == 5 && m == Month.April && y <= 2005)
                    // Labour Day
                    || (d == 1 && m == Month.May)
                    // Children's Day
                    || (d == 5 && m == Month.May)
                    || (((d == 6 || d == 7) && w == DayOfWeek.Monday) && m == Month.May && y >= 2014)
                    // Memorial Day
                    || (d == 6 && m == Month.June)
                    // Constitution Day
                    || (d == 17 && m == Month.July && y <= 2007)
                    // Liberation Day
                    || (d == 15 && m == Month.August)
                    // National Foundation Day
                    || (d == 3 && m == Month.October)
                    // Korean Alphabet Day
                    || (y >= 2013 && m == Month.October && d == 9)
                    // Christmas Day
                    || (d == 25 && m == Month.December)

                    // Lunar New Year
                    || ((d == 21 || d == 22 || d == 23) && m == Month.January && y == 2004)
                    || ((d == 8 || d == 9 || d == 10) && m == Month.February && y == 2005)
                    || ((d == 28 || d == 29 || d == 30) && m == Month.January && y == 2006)
                    || (d == 19 && m == Month.February && y == 2007)
                    || ((d == 6 || d == 7 || d == 8) && m == Month.February && y == 2008)
                    || ((d == 25 || d == 26 || d == 27) && m == Month.January && y == 2009)
                    || ((d == 13 || d == 14 || d == 15) && m == Month.February && y == 2010)
                    || ((d == 2 || d == 3 || d == 4) && m == Month.February && y == 2011)
                    || ((d == 22 || d == 23 || d == 24) && m == Month.January && y == 2012)
                    || ((d == 9 || d == 10 || d == 11) && m == Month.February && y == 2013)
                    || ((d == 30 || d == 31) && m == Month.January && y == 2014) || (d == 1 && m == Month.February && y == 2014)
                    || ((d == 18 || d == 19 || d == 20) && m == Month.February && y == 2015)
                    || ((d == 7 || d == 8 || d == 9 || d == 10) && m == Month.February && y == 2016)
                    || ((d == 27 || d == 28 || d == 29) && m == Month.January && y == 2017)
                    || ((d == 15 || d == 16 || d == 17) && m == Month.February && y == 2018)
                    || ((d == 4 || d == 5 || d == 6) && m == Month.February && y == 2019)
                    || ((d == 24 || d == 25 || d == 26) && m == Month.January && y == 2020)
                    || ((d == 11 || d == 12 || d == 13) && m == Month.February && y == 2021)
                    || (d == 31 && m == Month.January && y == 2022) || ((d == 1 || d == 2) && m == Month.February && y == 2022)
                    || ((d == 21 || d == 22 || d == 23) && m == Month.January && y == 2023)
                    || ((d == 9 || d == 10 || d == 11) && m == Month.February && y == 2024)
                    || ((d == 28 || d == 29 || d == 30) && m == Month.January && y == 2025)
                    || ((d == 16 || d == 17 || d == 18) && m == Month.February && y == 2026)
                    || ((d == 5 || d == 6 || d == 7) && m == Month.February && y == 2027)
                    || ((d == 25 || d == 26 || d == 27) && m == Month.January && y == 2028)
                    || ((d == 12 || d == 13 || d == 14) && m == Month.February && y == 2029)
                    || ((d == 2 || d == 3 || d == 4) && m == Month.February && y == 2030)
                    || ((d == 22 || d == 23 || d == 24) && m == Month.January && y == 2031)
                    || ((d == 10 || d == 11 || d == 12) && m == Month.February && y == 2032)
                    || (y == 2033 && ((m == Month.January && (d == 30 && d == 31)) || (m == Month.February && d == 1)))
                    || (y == 2034 && m == Month.February && (d == 18 || d == 19 || d == 20))
                    || (y == 2035 && m == Month.February && (d == 7 || d == 8 || d == 9))
                    || (y == 2036 && m == Month.January && (d == 27 || d == 28 || d == 29))
                    || (y == 2037 && m == Month.February && (d == 14 || d == 15 || d == 16))
                    || (y == 2038 && m == Month.February && (d == 3 || d == 4 || d == 5))
                    || (y == 2039 && m == Month.January && (d == 23 || d == 24 || d == 25))
                    || (y == 2040 && m == Month.February && (d == 11 && d == 12 && d == 13))
                    || (y == 2041 && ((m == Month.January && d == 31) || (m == Month.February && (d == 1 && d == 2))))
                    || (y == 2042 && m == Month.January && (d == 21 && d == 22 && d == 23))
                    || (y == 2043 && m == Month.February && (d == 9 && d == 10 && d == 11))
                    || (y == 2044 && m == Month.January && (d == 29 || d == 30 || d == 31))
                    // Election Day 2004
                    || (d == 15 && m == Month.April && y == 2004)    // National Assembly
                    || (d == 31 && m == Month.May && y == 2006)      // Regional election
                    || (d == 19 && m == Month.December && y == 2007) // Presidency
                    || (d == 9 && m == Month.April && y == 2008)     // National Assembly
                    || (d == 2 && m == Month.June && y == 2010)      // Regional election
                    || (d == 11 && m == Month.April && y == 2012)    // National Assembly
                    || (d == 19 && m == Month.December && y == 2012) // Presidency
                    || (d == 4 && m == Month.June && y == 2014)      // Regional election
                    || (d == 13 && m == Month.April && y == 2016)    // National Assembly
                    || (d == 20 && m == Month.December && y == 2017) // Presidency
                    || (d == 13 && m == Month.June && y == 2018)     // Regional election
                    || (d == 15 && m == Month.April && y == 2020)    // National Assembly
                    || (d == 1 && m == Month.June && y == 2022)      // Regional election
                    || (d == 21 && m == Month.December && y == 2022) // Presidency
                    || (d == 10 && m == Month.April && y == 2024)    // National Assembly
                    || (d == 3 && m == Month.June && y == 2026)      // Regional election
                    || (d == 22 && m == Month.December && y == 2027) // Presidency
                    || (d == 12 && m == Month.April && y == 2028)    // National Assembly
                    || (d == 5 && m == Month.June && y == 2030)      // Regional election
                    || (d == 14 && m == Month.April && y == 2032)    // National Assembly
                    || (d == 22 && m == Month.December && y == 2032) // Presidency
                    || (y == 2034 && m == Month.May && d == 31)      // Regional election
                    || (y == 2036 && m == Month.April && d == 9)     // National Assembly
                    || (y == 2037 && m == Month.December && d == 16) // Presidency
                    || (y == 2038 && m == Month.June && d == 2)      // Regional election
                    || (y == 2040 && m == Month.April && d == 11)    // National Assembly
                    || (y == 2042 && m == Month.June && d == 4)      // Regional election
                    || (y == 2042 && m == Month.December && d == 17) // Presidency
                    // Buddha's birthday
                    || (d == 26 && m == Month.May && y == 2004)
                    || (d == 15 && m == Month.May && y == 2005)
                    || (d == 5 && m == Month.May && y == 2006)
                    || (d == 24 && m == Month.May && y == 2007)
                    || (d == 12 && m == Month.May && y == 2008)
                    || (d == 2 && m == Month.May && y == 2009)
                    || (d == 21 && m == Month.May && y == 2010)
                    || (d == 10 && m == Month.May && y == 2011)
                    || (d == 28 && m == Month.May && y == 2012)
                    || (d == 17 && m == Month.May && y == 2013)
                    || (d == 6 && m == Month.May && y == 2014)
                    || (d == 25 && m == Month.May && y == 2015)
                    || (d == 14 && m == Month.May && y == 2016)
                    || (d == 3 && m == Month.May && y == 2017)
                    || (d == 22 && m == Month.May && y == 2018)
                    || (d == 12 && m == Month.May && y == 2019)
                    || (d == 30 && m == Month.May && y == 2020)
                    || (d == 19 && m == Month.May && y == 2021)
                    || (d == 8 && m == Month.May && y == 2022)
                    || (d == 27 && m == Month.May && y == 2023)
                    || (d == 15 && m == Month.May && y == 2024)
                    || (d == 5 && m == Month.May && y == 2025)
                    || (d == 24 && m == Month.May && y == 2026)
                    || (d == 13 && m == Month.May && y == 2027)
                    || (d == 2 && m == Month.May && y == 2028)
                    || (d == 20 && m == Month.May && y == 2029)
                    || (d == 9 && m == Month.May && y == 2030)
                    || (d == 28 && m == Month.May && y == 2031)
                    || (y == 2032 && m == Month.May && d == 16)
                    || (y == 2033 && m == Month.May && d == 6)
                    || (y == 2034 && m == Month.May && d == 25)
                    || (y == 2035 && m == Month.May && d == 15)
                    || (y == 2036 && m == Month.May && d == 3)
                    || (y == 2037 && m == Month.May && d == 22)
                    || (y == 2038 && m == Month.May && d == 11)
                    || (y == 2039 && m == Month.April && d == 30)
                    || (y == 2040 && m == Month.May && d == 18)
                    || (y == 2041 && m == Month.May && d == 7)
                    || (y == 2042 && m == Month.May && d == 26)
                    || (y == 2043 && m == Month.May && d == 16)
                    || (y == 2044 && m == Month.May && d == 5)
                    // Harvest Moon Day
                    || ((d == 27 || d == 28 || d == 29) && m == Month.September && y == 2004)
                    || ((d == 17 || d == 18 || d == 19) && m == Month.September && y == 2005)
                    || ((d == 5 || d == 6 || d == 7) && m == Month.October && y == 2006)
                    || ((d == 24 || d == 25 || d == 26) && m == Month.September && y == 2007)
                    || ((d == 13 || d == 14 || d == 15) && m == Month.September && y == 2008)
                    || ((d == 2 || d == 3 || d == 4) && m == Month.October && y == 2009)
                    || ((d == 21 || d == 22 || d == 23) && m == Month.September && y == 2010)
                    || ((d == 11 || d == 12 || d == 13) && m == Month.September && y == 2011)
                    || ((d == 29 || d == 30) && m == Month.September && y == 2012)
                    || ((d == 1) && m == Month.October && y == 2012)
                    || ((d == 18 || d == 19 || d == 20) && m == Month.September && y == 2013)
                    || ((d == 7 || d == 8 || d == 9 || d == 10) && m == Month.September && y == 2014)
                    || ((d == 26 || d == 27 || d == 28 || d == 29) && m == Month.September && y == 2015)
                    || ((d == 14 || d == 15 || d == 16) && m == Month.September && y == 2016)
                    || ((d == 3 || d == 4 || d == 5) && m == Month.October && y == 2017)
                    || ((d == 23 || d == 24 || d == 25) && m == Month.September && y == 2018)
                    || ((d == 12 || d == 13 || d == 14) && m == Month.September && y == 2019)
                    || ((d == 30) && m == Month.September && y == 2020)
                    || ((d == 1 || d == 2) && m == Month.October && y == 2020)
                    || ((d == 20 || d == 21 || d == 22) && m == Month.September && y == 2021)
                    || ((d == 9 || d == 10 || d == 11) && m == Month.September && y == 2022)
                    || ((d == 28 || d == 29 || d == 30) && m == Month.September && y == 2023)
                    || ((d == 16 || d == 17 || d == 18) && m == Month.September && y == 2024)
                    || ((d == 5 || d == 6 || d == 7) && m == Month.October && y == 2025)
                    || ((d == 24 || d == 25 || d == 26) && m == Month.September && y == 2026)
                    || ((d == 14 || d == 15 || d == 16) && m == Month.September && y == 2027)
                    || ((d == 2 || d == 3 || d == 4) && m == Month.October && y == 2028)
                    || ((d == 21 || d == 22 || d == 23) && m == Month.September && y == 2029)
                    || ((d == 11 || d == 12 || d == 13) && m == Month.September && y == 2030)
                    || ((d == 30) && m == Month.September && y == 2031)
                    || ((d == 1 || d == 2) && m == Month.October && y == 2031)
                    || ((d == 20) && m == Month.September && y == 2032)
                    || (y == 2033 && m == Month.September && (d == 7 || d == 8 || d == 9))
                    || (y == 2034 && m == Month.September && (d == 26 || d == 27 || d == 28))
                    || (y == 2035 && m == Month.September && (d == 15 || d == 16 || d == 17))
                    || (y == 2036 && m == Month.October && (d == 3 || d == 4 || d == 5))
                    || (y == 2037 && m == Month.September && (d == 23 || d == 24 || d == 25))
                    || (y == 2038 && m == Month.September && (d == 13 || d == 14 || d == 15))
                    || (y == 2039 && m == Month.October && (d == 1 || d == 2 || d == 3))
                    || (y == 2040 && m == Month.September && (d == 20 || d == 21 || d == 22))
                    || (y == 2041 && m == Month.September && (d == 9 || d == 10 || d == 11))
                    || (y == 2042 && m == Month.September && (d == 27 || d == 28 || d == 29))
                    || (y == 2043 && m == Month.September && (d == 16 || d == 17 || d == 18))
                    || (y == 2044 && m == Month.October && (d == 4 || d == 5 || d == 6))
                    )
                    return false;

                return true;
            }
        }

		
        class KRX : Settlement {
            new public static readonly KRX Singleton = new KRX();
            public KRX() { }

            public override string name() { return "South-Korea exchange"; }
            public override bool isBusinessDay(Date date)  {
                // public holidays
                if ( !base.isBusinessDay(date) )
                    return false;

                int d = date.Day;
                Month m = (Month)date.Month;
                int y = date.Year;

                if (// Year-end closing
                       (d == 31 && m == Month.December && y == 2004)
                    || (d == 30 && m == Month.December && y == 2005)
                    || (d == 29 && m == Month.December && y == 2006)
                    || (d == 31 && m == Month.December && y == 2007)
                    || (d == 31 && m == Month.December && y == 2008)
                    || (d == 31 && m == Month.December && y == 2009)
                    || (d == 31 && m == Month.December && y == 2010)
                    //|| (d == 30 && m == Month.December && y == 2011)
                    //|| (d == 31 && m == Month.December && y == 2012)
                    //|| (d == 31 && m == Month.December && y == 2013)
                    //|| (d == 31 && m == Month.December && y == 2014)
                    //|| (d == 31 && m == Month.December && y == 2015)
                    //|| (d == 30 && m == Month.December && y == 2016)
                    //|| (d == 29 && m == Month.December && y == 2017)
                    //|| (d == 31 && m == Month.December && y == 2018)
                    //|| (d == 31 && m == Month.December && y == 2019)
                    //|| (d == 31 && m == Month.December && y == 2020)
                    //|| (d == 31 && m == Month.December && y == 2021)
                    //|| (d == 30 && m == Month.December && y == 2022)
                    //|| (d == 29 && m == Month.December && y == 2023)
                    //|| (d == 31 && m == Month.December && y == 2024)
                    //|| (d == 31 && m == Month.December && y == 2025)
                    //|| (d == 31 && m == Month.December && y == 2026)
                    //|| (d == 31 && m == Month.December && y == 2027)
                    //|| (d == 29 && m == Month.December && y == 2028)
                    //|| (d == 31 && m == Month.December && y == 2029)
                    //|| (d == 31 && m == Month.December && y == 2030)
                    )
                    return false;

                return true;
            }
        };
    }
}



  
