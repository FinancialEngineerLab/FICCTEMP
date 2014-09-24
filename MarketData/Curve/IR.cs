using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FHS.MarketData
{
    public class IRFactory
    {
        InterestRateMarket target = null;

        public InterestRateMarket getIR(string type)
        {
            switch (type)
            {
                case "Deposit": target = new Deposit(); break;
                case "Swap": target = new Swap(); break;
                case "Bond": target = new Bond(); break;
                default: target = new Deposit(); break;
            }
            return target;
        }
    }

    // Curve 생성과 관련된 abstract class
    public abstract class InterestRateMarket
    {
        #region Property
        public Date _maturityDate;
        public double _maturity { get; set; }

        protected Period _maturityPeriod, _cashflowPeriod;
        protected Date _today, _effectiveDate;
        protected Calendar _calendar;
        protected DayCounter _dayCounter;

        protected TimeUnit _unit;
        protected BusinessDayConvention _businessDayConvention;

        protected bool _isEndOfMonth;
        protected int _numOfUnit;
        protected int _numOfCF;
        protected double[] _tau;    // 각 Cash Flow가 발생하는 interval의 Year Fraction
        protected double[] _tenor;  // 각 Cash Flow가 발생하는 날짜의 Year Fraction
        protected double[] _DF;
        #endregion

        #region Constructor
        public InterestRateMarket()
        {
            _today = Settings.evaluationDate();
        }
        #endregion

        #region Method
        // 기본적인 Setting을 먼저 해줌
        // calendar, BusinessDayConvention, DayCounter, 계산일 및 만기일, Year Fraction으로 maturity를 Setting함
        // Basis Swap 등의 자료도 여기다가 넣어서 처리하면 될 것으로 판단됨.
        public virtual void setProperty(Dictionary<string, object> property)
        {
            _calendar = new Calendar(property[tag.Calendar].ToString());                                           // Calendar
            _businessDayConvention = (BusinessDayConvention)Enum.Parse(typeof(BusinessDayConvention), property[tag.BusinessDayConvention].ToString());
            _isEndOfMonth = property.ContainsKey(tag.IsEndOfMonth) ? Convert.ToBoolean(property[tag.IsEndOfMonth]) : false;
            _dayCounter = new DayCounter(property[tag.DayCounter].ToString());
            _maturityPeriod = new Period(property[tag.Maturity].ToString());                                       // Maturity -> 거래 만기일 까지의 시간 간격 ex) 3M
            _cashflowPeriod = new Period(property[tag.CashFlowPeriod].ToString()); // CF가 발생하는 날의 Interval ex) 3M
        }
        
        public virtual void setCashFlow()
        {
            Date CF_Date;
            List<Date> cashflowDate = new List<Date>();

            int timeIntervalIndex = 0;
            double pivotInterval;

            // Set maturity date
            _numOfUnit = _maturityPeriod.length();                                                                // ex) if 3M then "3"
            _unit = _maturityPeriod.units();                                                                      // ex) if 3M then "Months"
            _maturityDate = _calendar.advance(_effectiveDate, _numOfUnit, _unit, _businessDayConvention, _isEndOfMonth);
            _maturity = _dayCounter.yearFraction(_today, _maturityDate);

            // Set cashflow
            _numOfUnit = _cashflowPeriod.length();                                // ex) if 3M then "3"
            _unit = _cashflowPeriod.units();                                      // ex) if 3M then "Months"
            CF_Date = _calendar.advance(_effectiveDate, _numOfUnit, _unit, _businessDayConvention, _isEndOfMonth);
            pivotInterval = 0.5 * _dayCounter.yearFraction(_effectiveDate, CF_Date);    // CF가 발생하는 날짜를 추출하기 위한 pivot으로 사용되는 기준

            do                                                                  // CF가 발생하는 날짜를 추출함       
            {
                timeIntervalIndex++;
                CF_Date = _calendar.advance(_effectiveDate, timeIntervalIndex * _numOfUnit, _unit, _businessDayConvention, _isEndOfMonth);
                cashflowDate.Add(CF_Date);
            }
            while (Math.Abs(_dayCounter.yearFraction(CF_Date, _maturityDate)) > pivotInterval);

            _numOfCF = cashflowDate.Count;
            _tenor = new double[_numOfCF];
            _DF = new double[_numOfCF];
            _tau = new double[_numOfCF];

            for (int i = 0; i < _numOfCF; i++)
            {
                _tenor[i] = _dayCounter.yearFraction(_today, cashflowDate[i]);
                _tau[i] = (i == 0) ? _tenor[0] : _tenor[i] - _tenor[i - 1];
            }
        }

        public abstract double getRate(Curve curve);
        #endregion
    }

    public class Deposit : InterestRateMarket
    {
        public override void setProperty(Dictionary<string, object> property)
        {
            base.setProperty(property);
            // Set maturity date
            _maturityPeriod = new Period(property[tag.Maturity].ToString());                                       // Maturity -> 거래 만기일 까지의 시간 간격 ex) 3M
            _numOfUnit = _maturityPeriod.length();                                                                // ex) if 3M then "3"
            _unit = _maturityPeriod.units();                                                                      // ex) if 3M then "Months"
            _maturityDate = _calendar.advance(_today, _numOfUnit, _unit, _businessDayConvention, _isEndOfMonth);
            _maturity = _dayCounter.yearFraction(_today, _maturityDate);
        }
        
        public override double getRate(Curve curve)
        {
            return (1.0 / curve.getDF(_maturity) - 1.0) / _maturity;
        }
    }

    public class Swap : InterestRateMarket
    {
        // Swap을 계산하는데 필요한 정보들을 뽑아냄 (Tau, Tenor, CF의 수)
        public override void setProperty(Dictionary<string, object> property)
        {
            Period effectivePeriod;

            base.setProperty(property);

            // Set effective date
            effectivePeriod = new Period(property[tag.EffectivePeriod].ToString());
            _numOfUnit = effectivePeriod.length();
            _unit = effectivePeriod.units();
            _effectiveDate = _calendar.advance(_today, _numOfUnit, _unit, _businessDayConvention, _isEndOfMonth);

            base.setCashFlow();
        }

        // 미리 계산된 Tenor와 Tau를 이용하여 Swap rate를 계산함
        public override double getRate(Curve curve)
        {
            double denominator = 0;

            for (int i = 0; i < _numOfCF; i++)
            {
                _DF[i] = curve.getDF(_tenor[i]);
                denominator += _tau[i] * _DF[i];
            }
            
            return (1 - _DF[_numOfCF - 1]) / denominator;
        }
    }

    public class Bond : InterestRateMarket
    {
        public override void setProperty(Dictionary<string, object> property)
        {
            base.setProperty(property);

            _effectiveDate = _today;
            base.setCashFlow();
        }

        // 미리 계산된 Tenor와 Tau를 이용하여 Swap rate를 계산함
        public override double getRate(Curve curve)
        {
            double denominator = 0;

            for (int i = 0; i < _numOfCF; i++)
            {
                _DF[i] = curve.getDF(_tenor[i]);
                denominator += _tau[i] * _DF[i];
            }

            return (1 - _DF[_numOfCF - 1]) / denominator;
        }
    }
}
