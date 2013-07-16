using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppTracker.Watch
    {
    class CurrentSession
        {
        public CurrentSession()
            {
            startTime = DateTime.Now;
            }
        private DateTime startTime;
        private TimeSpan duration = new TimeSpan();
        public Session GetSession()
            {
            if (hasEnded)
                return new Session(duration, startTime);
            else
                return new IncompleteSesstion(duration, startTime);

            }
        private bool hasEnded;
        public Session End()
            {
            hasEnded = true;
            return new Session(duration, startTime);
            }
        public void AddSecond()
            {
            duration = duration.Add(new TimeSpan(0, 0, 1));
            }
        }
    }
