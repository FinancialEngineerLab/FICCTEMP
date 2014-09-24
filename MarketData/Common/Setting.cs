using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHS.MarketData
{
    public static class Settings
    {
        [ThreadStatic]
        private static Date evaluationDate_ = null;

        [ThreadStatic]
        private static bool enforcesTodaysHistoricFixings_ = false;

        public static Date evaluationDate()
        {
            if (evaluationDate_ == null)
                evaluationDate_ = Date.Today;
            return evaluationDate_;
        }

        public static void setEvaluationDate(Date d)
        {
            evaluationDate_ = d;
        }

        public static bool enforcesTodaysHistoricFixings
        {
            get { return enforcesTodaysHistoricFixings_; }
            set { enforcesTodaysHistoricFixings_ = value; }
        }
    }

    public class SavedSettings
    {
        private Date evaluationDate_;
        private bool enforcesTodaysHistoricFixings_;

        public SavedSettings()
        {
            evaluationDate_ = Settings.evaluationDate();
            enforcesTodaysHistoricFixings_ = Settings.enforcesTodaysHistoricFixings;
        }

        ~SavedSettings()
        {
            if (evaluationDate_ != Settings.evaluationDate())
                Settings.setEvaluationDate(evaluationDate_);
            Settings.enforcesTodaysHistoricFixings = enforcesTodaysHistoricFixings_;
        }
    }
}