using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetMatrix;
using Net.Kniaz.LMA;

namespace FHS.MarketData
{
    public class RatesControl : LMAFunction
    {
        #region Property
        int _numOfProperty;
        string _type;                            // Deposit, Futures, Swap, etc...
        double[] _realData;                      // 시장 관찰값 (YTM, etc.)
        List<InterestRateMarket> _marketInfo;    // 시장 data와 관련된 정보를 저장해 두는 부분

        Curve _curve;                            // 결과 (Curve)

        #endregion

        #region Method
        // 외부(DB)로부터 속성 정보를 입력받아 세팅(_MarketInfo)
        public void setProperty(List<Object> pMarketProperty, Dictionary<string, object> CurveProperty)
        {
            IRFactory irFactory = new IRFactory();
            CurveFactory curveFactory = new CurveFactory();

            _numOfProperty = pMarketProperty.Count;
            _realData = new double[_numOfProperty];      // Real Data는 시장에서 관찰되는 값으로, Fitting시 Target이 됨
            _marketInfo = new List<InterestRateMarket>(_numOfProperty);

            Date[] dates = new Date[_numOfProperty];
            double[] tenors = new double[_numOfProperty];

            // Market Properties
            for (int i = 0; i < _numOfProperty; i++)
            {
                Dictionary<String, Object> marketProperty = (Dictionary<String, Object>)pMarketProperty[i];
                _type = marketProperty[tag.Attribute].ToString();
                InterestRateMarket ir = irFactory.getIR(_type);
                ir.setProperty(marketProperty);
                dates[i] = ir._maturityDate;
                tenors[i] = ir._maturity;
                _marketInfo.Add(ir);

                _realData[i] = Convert.ToDouble(marketProperty[tag.Marketdata]);
            }

            // Curve Properties
            _curve = curveFactory.getCurve(CurveProperty[tag.Method].ToString()); // Interpolation 방법을 선택함
            _curve.setDates(dates);
            _curve.setTenors(tenors);
            if (CurveProperty.ContainsKey(tag.CurveParameter)) _curve.setCurveParameters(CurveProperty[tag.CurveParameter]); // 만약 smoothing 등의 tech가 필요한 경우 parameter를 넣어줌
        }

        // Optimizer에서 이용되는 함수임 -> 형태가 별로 마음에 안듬. Optimizer에서 GetY가 있는 두 부분을 수정하여 사용하는 것이 좋아 보인다. 
        // 지금은 Index에 0부터 숫자가 들어가야 하는 형태이나 이는 finance 관련 문제를 풀 때는 별로 좋지 않은 방식으로 생각된다.
        // 따라서 return 값을 array로 변경하는 방식이 더 좋아 보임 -> 하지만 수정이 상당히 많이 들어갈 것으로 생각됨.
        public override double GetY(double index, double[] x)
        {
            _curve.setRates(x);
            return _marketInfo[(int)index].getRate(_curve);
        }

        // 주어진 Curve Model하에서 주어진 input을 이용하여 market rate를 계산하는 부분
        public double[] getModelValue(double[] rates = null)
        {
            int n = _marketInfo.Count;
            double[] modelValue = new double[n];
            if (rates != null)
                _curve.setRates(rates);

            for (int i = 0; i < n; i++)
                modelValue[i] = _marketInfo[i].getRate(_curve);

            return modelValue;
        }

        public void runFit(RatesControl _RatesControl)
        {
            LMA _LMA;   // Levenberg Marquardt Algorithm by Krzysztof Kniaz

            int n = _curve._numOfTenors;
            double[] param = new double[n];
            double[][] dataPoints = new double[2][];

            for (int i = 0; i < 2; i++)
                dataPoints[i] = new double[n];

            for (int i = 0; i < n; i++){
                dataPoints[0][i] = i;
                dataPoints[1][i] = _realData[i];
            }

            Array.Copy(_realData, param, n);
            _LMA = new LMA(_RatesControl, param, dataPoints, null, new GeneralMatrix(n, n), 1e-10, 100);

            _LMA.Fit();
        }

        // 계산된 zero rate를 이용하여 만들어진 Curve를 던져줌
        public Curve getCurve()
        {
            return _curve;
        }

        // 만약 input으로 쓰이는 model rates가 이미 정해져 있으면 아래와 같이 setting후 curve를 던져줌
        public Curve getCurve(double[] rates)
        {
            _curve.setRates(rates);
            return _curve;
        }
        #endregion
    }
}
