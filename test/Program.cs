using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FHS.MarketData;

namespace FHS.test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test for Curve
            #region Set Property
            string field;
            int NumOfProperty = 19;

            Dictionary<string, object>[] dict = new Dictionary<string, object>[NumOfProperty];
            for (int i = 0; i < NumOfProperty; i++) dict[i] = new Dictionary<string, object>();

            field = tag.Attribute;
            dict[0][field] = "Deposit";
            dict[1][field] = "Bond";
            dict[2][field] = "Bond";
            dict[3][field] = "Bond";
            dict[4][field] = "Bond";
            dict[5][field] = "Bond";
            dict[6][field] = "Bond";
            dict[7][field] = "Bond";
            dict[8][field] = "Bond";
            dict[9][field] = "Bond";
            dict[10][field] = "Bond";
            dict[11][field] = "Bond";
            dict[12][field] = "Bond";
            dict[13][field] = "Bond";
            dict[14][field] = "Bond";
            dict[15][field] = "Bond";
            dict[16][field] = "Bond";
            dict[17][field] = "Bond";
            dict[18][field] = "Bond";

            field = tag.Calendar;
            dict[0][field] = "KRW";
            dict[1][field] = "KRW";
            dict[2][field] = "KRW";
            dict[3][field] = "KRW";
            dict[4][field] = "KRW";
            dict[5][field] = "KRW";
            dict[6][field] = "KRW";
            dict[7][field] = "KRW";
            dict[8][field] = "KRW";
            dict[9][field] = "KRW";
            dict[10][field] = "KRW";
            dict[11][field] = "KRW";
            dict[12][field] = "KRW";
            dict[13][field] = "KRW";
            dict[14][field] = "KRW";
            dict[15][field] = "KRW";
            dict[16][field] = "KRW";
            dict[17][field] = "KRW";
            dict[18][field] = "KRW";

            field = tag.EffectivePeriod;
            dict[0][field] = "1D";
            dict[1][field] = "1D";
            dict[2][field] = "1D";
            dict[3][field] = "1D";
            dict[4][field] = "1D";
            dict[5][field] = "1D";
            dict[6][field] = "1D";
            dict[7][field] = "1D";
            dict[8][field] = "1D";
            dict[9][field] = "1D";
            dict[10][field] = "1D";
            dict[11][field] = "1D";
            dict[12][field] = "1D";
            dict[13][field] = "1D";
            dict[14][field] = "1D";
            dict[15][field] = "1D";
            dict[16][field] = "1D";
            dict[17][field] = "1D";
            dict[18][field] = "1D";

            field = tag.Maturity;
            dict[0][field] = "1D";
            dict[1][field] = "3M";
            dict[2][field] = "6M";
            dict[3][field] = "9M";
            dict[4][field] = "1Y";
            dict[5][field] = "18M";
            dict[6][field] = "2Y";
            dict[7][field] = "30M";
            dict[8][field] = "3Y";
            dict[9][field] = "4Y";
            dict[10][field] = "5Y";
            dict[11][field] = "7Y";
            dict[12][field] = "10Y";
            dict[13][field] = "12Y";
            dict[14][field] = "15Y";
            dict[15][field] = "17Y";
            dict[16][field] = "20Y";
            dict[17][field] = "25Y";
            dict[18][field] = "30Y";

            field = tag.Marketdata;
            dict[0][field] = 0.023;
            dict[1][field] = 0.02333;
            dict[2][field] = 0.02356;
            dict[3][field] = 0.02388;
            dict[4][field] = 0.02416;
            dict[5][field] = 0.02476;
            dict[6][field] = 0.02559;
            dict[7][field] = 0.02625;
            dict[8][field] = 0.02744;
            dict[9][field] = 0.02821;
            dict[10][field] = 0.0299;
            dict[11][field] = 0.03147;
            dict[12][field] = 0.03351;
            dict[13][field] = 0.03372;
            dict[14][field] = 0.03435;
            dict[15][field] = 0.03465;
            dict[16][field] = 0.03505;
            dict[17][field] = 0.03636;
            dict[18][field] = 0.03701;

            field = tag.BusinessDayConvention;
            dict[0][field] = "Unadjusted";
            dict[1][field] = "Unadjusted";
            dict[2][field] = "Unadjusted";
            dict[3][field] = "Unadjusted";
            dict[4][field] = "Unadjusted";
            dict[5][field] = "Unadjusted";
            dict[6][field] = "Unadjusted";
            dict[7][field] = "Unadjusted";
            dict[8][field] = "Unadjusted";
            dict[9][field] = "Unadjusted";
            dict[10][field] = "Unadjusted";
            dict[11][field] = "Unadjusted";
            dict[12][field] = "Unadjusted";
            dict[13][field] = "Unadjusted";
            dict[14][field] = "Unadjusted";
            dict[15][field] = "Unadjusted";
            dict[16][field] = "Unadjusted";
            dict[17][field] = "Unadjusted";
            dict[18][field] = "Unadjusted";

            field = tag.IsEndOfMonth;
            dict[0][field] = false;
            dict[1][field] = false;
            dict[2][field] = false;
            dict[3][field] = false;
            dict[4][field] = false;
            dict[5][field] = false;
            dict[6][field] = false;
            dict[7][field] = false;
            dict[8][field] = false;
            dict[9][field] = false;
            dict[10][field] = false;
            dict[11][field] = false;
            dict[12][field] = false;
            dict[13][field] = false;
            dict[14][field] = false;
            dict[15][field] = false;
            dict[16][field] = false;
            dict[17][field] = false;
            dict[18][field] = false;

            field = tag.DayCounter;
            dict[0][field] = "A365";
            dict[1][field] = "A365";
            dict[2][field] = "A365";
            dict[3][field] = "A365";
            dict[4][field] = "A365";
            dict[5][field] = "A365";
            dict[6][field] = "A365";
            dict[7][field] = "A365";
            dict[8][field] = "A365";
            dict[9][field] = "A365";
            dict[10][field] = "A365";
            dict[11][field] = "A365";
            dict[12][field] = "A365";
            dict[13][field] = "A365";
            dict[14][field] = "A365";
            dict[15][field] = "A365";
            dict[16][field] = "A365";
            dict[17][field] = "A365";
            dict[18][field] = "A365";

            field = tag.CashFlowPeriod;
            dict[0][field] = "3M";
            dict[1][field] = "3M";
            dict[2][field] = "3M";
            dict[3][field] = "3M";
            dict[4][field] = "3M";
            dict[5][field] = "3M";
            dict[6][field] = "3M";
            dict[7][field] = "3M";
            dict[8][field] = "3M";
            dict[9][field] = "3M";
            dict[10][field] = "3M";
            dict[11][field] = "3M";
            dict[12][field] = "3M";
            dict[13][field] = "3M";
            dict[14][field] = "3M";
            dict[15][field] = "3M";
            dict[16][field] = "3M";
            dict[17][field] = "3M";
            dict[18][field] = "3M";
            
            List<object> MarketInform = new List<object>(NumOfProperty);
            for (int i = 0; i < NumOfProperty; i++)
                MarketInform.Add(dict[i]);
            #endregion

            #region Set Curve Information
            Dictionary<string, object> CurveProperty = new Dictionary<string, object>();
            CurveProperty[tag.Method] = "PiecewiseConstantForward";
            CurveProperty[tag.CurveParameter] = "";

            //double[] tenor = new double[NumOfProperty];
            //tenor[0] = 1.0 / 365.0;
            //tenor[1] = 1.0 / 4.0;
            //tenor[2] = 1.0 / 2.0;
            //tenor[3] = 3.0 / 4.0;
            //tenor[4] = 1.0;
            //tenor[5] = 1.5;
            //tenor[6] = 2.0;
            //tenor[7] = 3.0;
            //tenor[8] = 4.0;
            //tenor[9] = 5.0;
            //tenor[10] = 6.0;
            //tenor[11] = 7.0;
            //tenor[12] = 8.0;
            //tenor[13] = 9.0;
            //tenor[14] = 10.0;
            //tenor[15] = 12.0;
            //tenor[16] = 15.0;
            //tenor[17] = 20.0;
            //tenor[18] = 20.0;

            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < tenor.Length - 1; i++)
            //{
            //    sb.Append(tenor[i].ToString());
            //    sb.Append("|");
            //}
            //sb.Append(tenor[tenor.Length - 1]);
            //CurveProperty["Tenors"] = sb.ToString();
            #endregion

            #region Initializing
            Date d = new Date("20140825");
            Settings.setEvaluationDate(d);
            RatesControl _ratesControl = new RatesControl();            
            _ratesControl.setProperty(MarketInform, CurveProperty);
            #endregion

            #region Execute
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Reset();
            sw.Start();            
            _ratesControl.runFit(_ratesControl);
            sw.Stop();
            #endregion

            #region Result
            Console.WriteLine("It took {0} (milliseconds)\n", sw.ElapsedMilliseconds);

            double[] modelValue = _ratesControl.getModelValue();
            Console.WriteLine("Model Values are below: ");
            for (int i = 0; i < modelValue.Length; i++)
                Console.WriteLine(modelValue[i]);
            Console.WriteLine("");

            Curve curve = _ratesControl.getCurve();
            int n = curve._numOfTenors;
            double[] zero = new double[n];
            double[] tenors = new double[n];
            double[] DF = new double[n];
            for (int i = 0; i < curve._numOfTenors; i++)
            {
                tenors[i] = curve._tenors[i];
                zero[i] = curve.getSpot(tenors[i]);
                DF[i] = curve.getDF(tenors[i]);
                Console.WriteLine("{0} {1} {2} {3}", curve._dates[i], zero[i], tenors[i], DF[i]);
            }

            Console.ReadLine();
            #endregion
            #endregion

            #region Test for another here

            #endregion
        }
    }
}
