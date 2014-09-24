using System;
using System.Text;

namespace FHS.MarketData {
    
    public class HongKong : Calendar {
        public HongKong() : base(Impl.Singleton) { }

		
        class Impl : Calendar.WesternImpl {
            public static readonly Impl Singleton = new Impl();
            private Impl() { }
        
            public override string name() { return "Hong Kong stock exchange"; }
            public override bool isBusinessDay(Date date) {
                DayOfWeek w = date.DayOfWeek;
                int d = date.Day, dd = date.DayOfYear;
                Month m = (Month)date.Month;
                int y = date.Year;
                int em = easterMonday(y);

                if (isWeekend(w)
                    // New Year's Day
                    || ((d == 1 || ((d == 2 || d == 3) && w == DayOfWeek.Monday))
                        && m == Month.January)                    
                    // Good Friday
                    || (dd == em-3)
                    // Easter Monday
                    || (dd == em)
                    // Labor Day
                    || (d == 1 && m == Month.May)
                    // SAR Establishment Day
                    || ((d == 1 || ((d == 2 || d == 3) && w == DayOfWeek.Monday)) && m == Month.July)
                    // National Day
                    || ((d == 1 || ((d == 2 || d == 3) && w == DayOfWeek.Monday))
                        && m == Month.October)
                    // Christmas Day
                    || (d == 25 && m == Month.December)
                    // Boxing Day
                    || ((d == 26 || ((d == 27 || d == 28) && w == DayOfWeek.Monday))
                        && m == Month.December))
                    return false;

                if (y == 2004) {
                    if (// Lunar New Year
                        ((d==22 || d==23 || d==24) && m == Month.January)
                        // Buddha's birthday
                        || (d == 26 && m == Month.May)
                        // Tuen NG festival
                        || (d == 22 && m == Month.June)
                        // Mid-autumn festival
                        || (d == 29 && m == Month.September)
                        // Chung Yeung
                        || (d == 29 && m == Month.September))
                        return false;
                }

                if (y == 2005) {
                    if (// Lunar New Year
                        ((d==9 || d==10 || d==11) && m == Month.February)
                        // Buddha's birthday
                        || (d == 16 && m == Month.May)
                        // Tuen NG festival
                        || (d == 11 && m == Month.June)
                        // Mid-autumn festival
                        || (d == 19 && m == Month.September)
                        // Chung Yeung festival
                        || (d == 11 && m == Month.October))
                    return false;
                }

                if (y == 2006) {
                    if (// Lunar New Year
                        ((d >= 28 && d <= 31) && m == Month.January)
                        // Buddha's birthday
                        || (d == 5 && m == Month.May)
                        // Tuen NG festival
                        || (d == 31 && m == Month.May)
                        // Mid-autumn festival
                        || (d == 7 && m == Month.October)
                        // Chung Yeung festival
                        || (d == 30 && m == Month.October))
                    return false;
                }

                if (y == 2007) {
                    if (// Lunar New Year
                        ((d >= 17 && d <= 20) && m == Month.February)
                        // Buddha's birthday
                        || (d == 24 && m == Month.May)
                        // Tuen NG festival
                        || (d == 19 && m == Month.June)
                        // Mid-autumn festival
                        || (d == 26 && m == Month.September)
                        // Chung Yeung festival
                        || (d == 19 && m == Month.October))
                    return false;
                }

                if (y == 2008) {
                    if (// Lunar New Year
                        ((d >= 7 && d <= 9) && m == Month.February)
                        // Ching Ming Festival
                        || (d == 4 && m == Month.April)
                        // Buddha's birthday
                        || (d == 12 && m == Month.May)
                        // Tuen NG festival
                        || (d == 9 && m == Month.June)
                        // Mid-autumn festival
                        || (d == 15 && m == Month.September)
                        // Chung Yeung festival
                        || (d == 7 && m == Month.October))
                    return false;
                }

                // Lunar New Year
                if ((y == 2009 && m == Month.January && (d == 26 || d == 27 || d == 28))
                    || (y == 2010 && m == Month.February && (d == 14 || d == 15 || d == 16))
                    || (y == 2011 && m == Month.February && (d == 3 || d == 4 || d == 5))
                    || (y == 2012 && m == Month.January && (d == 23 || d == 24 || d == 25))
                    || (y == 2013 && m == Month.February && (d == 10 || d == 11 || d == 12))
                    || (y == 2014 && m == Month.January && d == 31) || (y == 2014 && m == Month.February && (d >= 1 && d <= 3))
                    || (y == 2015 && m == Month.February && (d == 19 || d == 20 || d == 21))
                    || (y == 2016 && m == Month.February && (d >= 8 && d <= 10))
                    || (y == 2017 && m == Month.January && (d == 28 || d == 29 || d == 30))
                    || (y == 2018 && m == Month.February && (d == 16 || d == 17 || d == 18))
                    || (y == 2019 && m == Month.February && (d == 5 || d == 6 || d == 7))
                    || (y == 2020 && m == Month.January && (d == 25 || d == 26 || d == 27))
                    || (y == 2021 && m == Month.February && (d == 12 || d == 13 || d == 14))
                    || (y == 2022 && m == Month.February && (d == 1 || d == 2 || d == 3))
                    || (y == 2023 && m == Month.January && (d == 22 || d == 23 || d == 24))
                    || (y == 2024 && m == Month.February && (d == 10 || d == 11 || d == 12))
                    || (y == 2025 && m == Month.January && (d == 28 || d == 29 || d == 30))
                    || (y == 2026 && m == Month.February && (d == 17 || d == 18 || d == 19))
                    || (y == 2027 && m == Month.February && (d == 6 || d == 7 || d == 8))
                    || (y == 2028 && m == Month.January && (d == 26 || d == 27 || d == 28))
                    || (y == 2029 && m == Month.February && (d == 13 || d == 14 || d == 15))
                    || (y == 2030 && m == Month.February && (d == 3 || d == 4 || d == 5))
                    || (y == 2031 && m == Month.January && (d == 23 || d == 24 || d == 25))
                    || (y == 2032 && m == Month.February && (d == 11 || d == 12 || d == 13))
                    || (y == 2033 && ((m == Month.January && (d == 31)) || (m == Month.February && (d == 1 || d == 2))))
                    || (y == 2034 && m == Month.February && (d == 19 || d == 20 || d == 21))
                    || (y == 2035 && m == Month.February && (d == 8 || d == 9 || d == 10))
                    || (y == 2036 && m == Month.January && (d == 28 || d == 29 || d == 30))
                    || (y == 2037 && m == Month.February && (d == 15 || d == 16 || d == 17))
                    || (y == 2038 && m == Month.February && (d == 4 || d == 5 || d == 6))
                    || (y == 2039 && m == Month.January && (d == 24 || d == 25 || d == 26))
                    || (y == 2040 && m == Month.February && (d == 12 && d == 13 && d == 14))
                    || (y == 2041 && m == Month.February && (d == 1 && d == 2 && d == 3))
                    || (y == 2042 && m == Month.January && (d == 22 && d == 23 && d == 24))
                    || (y == 2043 && m == Month.February && (d == 10 && d == 11 && d == 12))
                    || (y == 2044 && ((m == Month.January && (d == 30 || d == 31)) || (m == Month.February && d == 1)))
                    )
                    return false;

                // Buddha's birthday
                if ((d == 2 && m == Month.May && y == 2009)
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
                    )
                    return false;

                // Day after Mid-autumn festival
                if ((y == 2009 && m == Month.October && d == 3)
                    || (y == 2010 && m == Month.September && d == 23)
                    || (y == 2011 && m == Month.September && d == 13)
                    || (y == 2012 && m == Month.October && d == 1)
                    || (y == 2013 && m == Month.September && d == 20)
                    || (y == 2014 && m == Month.September && d == 9)
                    || (y == 2015 && m == Month.September && d == 28)
                    || (y == 2016 && m == Month.September && d == 16)
                    || (y == 2017 && m == Month.October && d == 5)
                    || (y == 2018 && m == Month.September && d == 25)
                    || (y == 2019 && m == Month.September && d == 14)
                    || (y == 2020 && m == Month.October && d == 2)
                    || (y == 2021 && m == Month.September && d == 22)
                    || (y == 2022 && m == Month.September && d == 11)
                    || (y == 2023 && m == Month.September && d == 30)
                    || (y == 2024 && m == Month.September && d == 18)
                    || (y == 2025 && m == Month.October && d == 7)
                    || (y == 2026 && m == Month.September && d == 26)
                    || (y == 2027 && m == Month.September && d == 16)
                    || (y == 2028 && m == Month.October && d == 4)
                    || (y == 2029 && m == Month.September && d == 23)
                    || (y == 2030 && m == Month.September && d == 13)
                    || (y == 2031 && m == Month.October && d == 2)
                    || (y == 2032 && m == Month.September && d == 20)
                    || (y == 2033 && m == Month.September && d == 9)
                    || (y == 2034 && m == Month.September && d == 28)
                    || (y == 2035 && m == Month.September && d == 17)
                    || (y == 2036 && m == Month.October && d == 5)
                    || (y == 2037 && m == Month.September && d == 25)
                    || (y == 2038 && m == Month.September && d == 15)
                    || (y == 2039 && m == Month.October && d == 3)
                    || (y == 2040 && m == Month.September && d == 22)
                    || (y == 2041 && m == Month.September && d == 11)
                    || (y == 2042 && m == Month.September && d == 29)
                    || (y == 2043 && m == Month.September && d == 18)
                    || (y == 2044 && m == Month.October && d == 6)
                    )
                    return false;

                // Ching Ming festival
                if ((y == 2009 && m == Month.April && d == 4)
                    || (y == 2010 && m == Month.April && d == 5)
                    || (y == 2011 && m == Month.April && d == 5)
                    || (y == 2012 && m == Month.April && d == 4)
                    || (y == 2013 && m == Month.April && d == 4)
                    || (y == 2014 && m == Month.April && d == 5)
                    || (y == 2015 && m == Month.April && d == 4)
                    || (y == 2016 && m == Month.April && d == 4)
                    || (y == 2017 && m == Month.April && d == 5)
                    || (y == 2018 && m == Month.April && d == 5)
                    || (y == 2019 && m == Month.April && d == 5)
                    || (y == 2020 && m == Month.April && d == 4)
                    || (y == 2021 && m == Month.April && d == 5)
                    || (y == 2022 && m == Month.April && d == 5)
                    || (y == 2023 && m == Month.April && d == 5)
                    || (y == 2024 && m == Month.April && d == 4)
                    || (y == 2025 && m == Month.April && d == 5)
                    || (y == 2026 && m == Month.April && d == 4)
                    || (y == 2027 && m == Month.April && d == 5)
                    || (y == 2028 && m == Month.April && d == 4)
                    || (y == 2029 && m == Month.April && d == 5)
                    || (y == 2030 && m == Month.April && d == 5)
                    || (y == 2030 && m == Month.April && d == 5)
                    || (y == 2031 && m == Month.April && d == 5)
                    || (y == 2032 && m == Month.April && d == 3)
                    || (y == 2033 && m == Month.April && d == 5)
                    || (y == 2034 && m == Month.April && d == 5)
                    || (y == 2035 && m == Month.April && d == 5)
                    || (y == 2036 && m == Month.April && d == 4)
                    || (y == 2037 && m == Month.April && d == 4)
                    || (y == 2038 && m == Month.April && d == 5)
                    || (y == 2039 && m == Month.April && d == 5)
                    || (y == 2040 && m == Month.April && d == 4)
                    || (y == 2041 && m == Month.April && d == 5)
                    || (y == 2042 && m == Month.April && d == 5)
                    || (y == 2043 && m == Month.April && d == 4)
                    || (y == 2044 && m == Month.April && d == 4)
                    )
                    return false;

                // Tuen Ng festival
                if ((y == 2009 && m == Month.June && d == 2)
                    || (y == 2010 && m == Month.June && d == 2)
                    || (y == 2011 && m == Month.June && d == 2)
                    || (y == 2012 && m == Month.June && d == 2)
                    || (y == 2013 && m == Month.June && d == 2)
                    || (y == 2014 && m == Month.June && d == 2)
                    || (y == 2015 && m == Month.June && d == 20)
                    || (y == 2016 && m == Month.June && d == 9)
                    || (y == 2017 && m == Month.May && d == 30)
                    || (y == 2018 && m == Month.June && d == 18)
                    || (y == 2019 && m == Month.June && d == 7)
                    || (y == 2020 && m == Month.June && d == 25)
                    || (y == 2021 && m == Month.June && d == 14)
                    || (y == 2022 && m == Month.June && d == 3)
                    || (y == 2023 && m == Month.June && d == 22)
                    || (y == 2024 && m == Month.June && d == 10)
                    || (y == 2025 && m == Month.May && d == 31)
                    || (y == 2026 && m == Month.June && d == 19)
                    || (y == 2027 && m == Month.June && d == 9)
                    || (y == 2028 && m == Month.May && d == 29)
                    || (y == 2029 && m == Month.June && d == 16)
                    || (y == 2030 && m == Month.June && d == 5)
                    || (y == 2031 && m == Month.June && d == 24)
                    || (y == 2032 && m == Month.June && d == 12)
                    || (y == 2033 && m == Month.June && d == 1)
                    || (y == 2034 && m == Month.June && d == 20)
                    || (y == 2035 && m == Month.June && d == 11)
                    || (y == 2036 && m == Month.May && d == 30)
                    || (y == 2037 && m == Month.June && d == 18)
                    || (y == 2038 && m == Month.June && d == 7)
                    || (y == 2039 && m == Month.May && d == 27)
                    || (y == 2040 && m == Month.June && d == 14)
                    || (y == 2041 && m == Month.June && d == 3)
                    || (y == 2042 && m == Month.June && d == 23)
                    || (y == 2043 && m == Month.June && d == 11)
                    || (y == 2044 && m == Month.May && d == 31)
                    )
                    return false;

                // Chung Yeung festival
                if ((y == 2009 && m == Month.October && d == 26)
                    || (y == 2010 && m == Month.October && d == 16)
                    || (y == 2011 && m == Month.October && d == 5)
                    || (y == 2012 && m == Month.October && d == 23)
                    || (y == 2013 && m == Month.October && d == 14)
                    || (y == 2014 && m == Month.October && d == 2)
                    || (y == 2015 && m == Month.October && d == 21)
                    || (y == 2016 && m == Month.October && d == 10)
                    || (y == 2017 && m == Month.October && d == 28)
                    || (y == 2018 && m == Month.October && d == 17)
                    || (y == 2019 && m == Month.October && d == 7)
                    || (y == 2020 && m == Month.October && d == 26)
                    || (y == 2021 && m == Month.October && d == 14)
                    || (y == 2022 && m == Month.October && d == 4)
                    || (y == 2023 && m == Month.October && d == 23)
                    || (y == 2024 && m == Month.October && d == 11)
                    || (y == 2025 && m == Month.October && d == 29)
                    || (y == 2026 && m == Month.October && d == 19)
                    || (y == 2027 && m == Month.October && d == 8)
                    || (y == 2028 && m == Month.October && d == 26)
                    || (y == 2029 && m == Month.October && d == 16)
                    || (y == 2030 && m == Month.October && d == 5)
                    || (y == 2031 && m == Month.October && d == 24)
                    || (y == 2032 && m == Month.October && d == 12)
                    || (y == 2033 && m == Month.October && d == 1)
                    || (y == 2034 && m == Month.October && d == 20)
                    || (y == 2035 && m == Month.October && d == 9)
                    || (y == 2036 && m == Month.October && d == 27)
                    || (y == 2037 && m == Month.October && d == 17)
                    || (y == 2038 && m == Month.October && d == 7)
                    || (y == 2039 && m == Month.October && d == 26)
                    || (y == 2040 && m == Month.October && d == 15)
                    || (y == 2041 && m == Month.October && d == 3)
                    || (y == 2042 && m == Month.October && d == 22)
                    || (y == 2043 && m == Month.October && d == 12)
                    || (y == 2044 && m == Month.October && d == 29)
                    )
                    return false;

                return true;
            }
        }
    }
}