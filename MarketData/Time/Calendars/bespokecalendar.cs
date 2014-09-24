using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHS.MarketData {
    
    public class BespokeCalendar : Calendar {
        private string name_;
        public override string name() { return name_; }

        /*! \warning different bespoke calendars created with the same
                     name (or different bespoke calendars created with
                     no name) will compare as equal.
        */
        public BespokeCalendar() : this("") { }
        public BespokeCalendar(string name) : base(new Impl()) { 
            name_ = name;
        }

        //! marks the passed day as part of the weekend
        public void addWeekend(DayOfWeek w) {
            (calendar_ as Impl).addWeekend(w);
        }

        // here implementation does not follow a singleton pattern
		
        class Impl : Calendar.WesternImpl {
            public Impl() { }

            public override bool isWeekend(DayOfWeek w) { return (weekend_.Contains(w)); }
            public override bool isBusinessDay(Date date) { return !isWeekend(date.DayOfWeek); }
            public void addWeekend(DayOfWeek w) { weekend_.Add(w); }

            private List<DayOfWeek> weekend_ = new List<DayOfWeek>();
        }
    }
}
