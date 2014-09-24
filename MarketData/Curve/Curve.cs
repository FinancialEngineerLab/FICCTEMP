using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Interpolation;

namespace FHS.MarketData
{
    public class CurveFactory
    {
        Curve target = null;

        public Curve getCurve(string type = "PiecewiseConstantForward")
        {
            switch (type)
            {
                case "PiecewiseConstantForward": target = new PiecewiseConstantForward(); break;
                default: target = new PiecewiseConstantForward(); break;
            }
            return target;
        }
    }

    // Curve class
    abstract public class Curve
    {
        #region Property
        public Date[] _dates;

        public int _numOfTenors { get; set; }
        public double[] _tenors;
        public double[] _rates { get; set; }
        #endregion

        #region Method
        public virtual void setDates(Date[] dates)
        {
            int n = dates.Length;

            _dates = new Date[n];
            Array.Copy(dates, _dates, n);
        }

        public virtual void setTenors(List<double> tenors)
        {
            _numOfTenors = tenors.Count;
            _tenors = new double[_numOfTenors];
            tenors.CopyTo(_tenors);
        }

        public virtual void setTenors(double[] tenors)
        {
            _numOfTenors = tenors.Length;
            _tenors = new double[_numOfTenors];
            Array.Copy(tenors, _tenors, _numOfTenors);
        }

        public virtual void setTenors(string[] tenors)
        {
            _numOfTenors = tenors.Length;
            _tenors = new double[_numOfTenors];
            for (int i = 0; i < _numOfTenors; i++)
                _tenors[i] = Convert.ToDouble(tenors[i]);
        }

        public virtual void setRates(List<double> rates)
        {
            int n = rates.Count;
            _numOfTenors = (_numOfTenors > 0) ? n : _numOfTenors;   // 이 부분에서 예외처리 필요
            _rates = new double[_numOfTenors];
            rates.CopyTo(_rates);
            updateCurve();
        }

        public virtual void setRates(double[] rates)
        {
            int n = rates.Length;
            _numOfTenors = (_numOfTenors > 0) ? n : _numOfTenors;   // 이 부분에서 예외처리 필요
            _rates = new double[_numOfTenors];
            Array.Copy(rates, _rates, _numOfTenors);
            updateCurve();
        }
        
        public abstract void setCurveParameters(Object Params);

        public abstract void updateCurve();

        public abstract double getDF(double t);

        public abstract double getSpot(double t);

        public abstract double[] getSpot(double[] t);

        public abstract List<double> getSpot(List<double> t);

        public abstract double getForward(double t);
        //public abstract double[] getForward(double[] t);

        public abstract double getForward(double t1, double t2);
        //public abstract List<double> getForward(List<double> T1, List<double> T2);
        //public abstract double[] getForward(double[] T1, double[] T2);
        #endregion
    }

    // Interpolation method 에 따른 class
    public class PiecewiseConstantForward : Curve
    {
        StepInterpolation interpolator;

        public override void setCurveParameters(Object Params) { }

        public override void updateCurve()
        {
            interpolator = new StepInterpolation(_tenors, _rates);    // rate가 변하면 curve에 반영
        }

        // piece wise constant로 되어 있는 forward rate를 이용하여 DF를 계산
        public override double getDF(double t)
        {
            int index;
            double ret = 1.0;

            for (index = 0; index < _tenors.Length; index++)
                if (t < _tenors[index]) break;

            for (int i = 0; i < index; i++)
            {
                if (i == 0)
                    ret *= Math.Exp(-_rates[i] * _tenors[i]);
                else
                    ret *= Math.Exp(-_rates[i] * (_tenors[i] - _tenors[i - 1]));
            }

            ret *= Math.Exp(-interpolator.Interpolate(t) * (t - _tenors[index - 1]));

            return ret;
        }

        // DF를 이용하여 Spot rate 계산
        public override double getSpot(double t)
        {
            return -Math.Log(getDF(t)) / t;
        }

        public override double[] getSpot(double[] t)
        {
            int n = t.Length;
            double[] ret = new double[n];

            for (int i = 0; i < n; i++)
                ret[i] = getSpot(t[i]);

            return ret;
        }

        public override List<double> getSpot(List<double> t)
        {
            int n = t.Count;
            List<double> ret = new List<double>(n);
            
            for (int i = 0; i < n; i++)
                ret.Add(getSpot(t[i]));

            return ret;
        }

        // 시점 t에서의 Forward rate 계산
        public override double getForward(double t)
        {
            return interpolator.Interpolate(t);
        }

        // t1에서 t2사이에 이용되는 Forward rate 계산
        public override double getForward(double t1, double t2)
        {
            double tau = t2 - t1;
            double DF = getDF(t2) / getDF(t1);

            return -Math.Log(DF) / tau;
        }
    }
}
