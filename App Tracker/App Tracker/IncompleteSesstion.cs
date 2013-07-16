using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppTracker.Watch
    {
    class IncompleteSesstion : Session
        {
        public IncompleteSesstion(TimeSpan duration, DateTime startTime) : base(duration, startTime) { }
        }
    }
