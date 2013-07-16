using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppTracker.Watch
    {
    public class Session
        {
        private TimeSpan mDuration;
        private DateTime mStartTime;
        public TimeSpan Duration { get { return mDuration; } }
        public DateTime StartTime { get { return mStartTime; } }

        public Session(TimeSpan duration, DateTime startTime)
            {
            this.mStartTime = startTime;
            this.mDuration = duration;

            }

        }
    }
