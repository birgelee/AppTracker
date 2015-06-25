using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project1;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace AppTracker.Watch
{
    public class Watch
    {
        public Watch(string name, string alias)
        {
            this.Name = name;
            this.Alias = alias;
            watchTab = new WatchTab(RemoveWatch, ShowStats);
        }
        public Watch(string name, string alias, TimeSpan totalTime, List<Session> sessions)
            : this(name, alias)
        {
            this.mTotalTimePlayed = totalTime;
            this.mSessions = sessions;
        }
        public string Name, Alias;

        private List<Session> mSessions = new List<Session>();

        public WatchTab watchTab;

        public List<Session> Sessions
        {
            get
            {
                if (currentSession != null)
                {
                    List<Session> temp = new List<Session>();
                    temp.AddRange(mSessions);
                    temp.Add(currentSession.GetSession());
                    return temp;
                }
                return mSessions;
            }
        }


        private CurrentSession currentSession;

        private TimeSpan mTotalTimePlayed = new TimeSpan();
        public TimeSpan TotalTimePlayed { get { return mTotalTimePlayed; } }

        public void Played()
        {
            mTotalTimePlayed = mTotalTimePlayed.Add(new TimeSpan(0, 0, 1));
            if (currentSession == null)
                currentSession = new CurrentSession();
            currentSession.AddSecond();
        }



        public void UpdateTab()
        {
            if (Sessions.Count > 0)
                SetText("Last Session: " + Sessions.Last().Duration.Hours + ":" + Sessions.Last().Duration.Minutes + ":" + Sessions.Last().Duration.Seconds, watchTab.TabTextBox1);
            else
                SetText("Last Session: 0:0:0", watchTab.TabTextBox1);
            var tpld = TimePlayedIn(new TimeSpan(1, 0, 0, 0, 0), Sessions);
            SetText("Last Day: " + tpld.Hours + ":" + tpld.Minutes + ":" + tpld.Seconds, watchTab.TabTextBox2);
            var tplw = TimePlayedIn(new TimeSpan(7, 0, 0, 0, 0), Sessions);
            SetText("Last Week: " + tplw.Hours + ":" + tplw.Minutes + ":" + tplw.Seconds, watchTab.TabTextBox3);
            var img = new Bitmap(watchTab.TabPictureBox.Width, watchTab.TabPictureBox.Height);
            Graphics g = Graphics.FromImage(img);

            for (int i = Sessions.Count - 1; i >= 0; i--)
            {
                var sessionEnd = ConvertTimeToPosition(Sessions[i].StartTime.Add(Sessions[i].Duration));
                if (sessionEnd == -1)
                    break;
                var sessionStart = ConvertTimeToPosition(Sessions[i].StartTime);
                if (sessionStart == -1)
                {
                    g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(0, 0, (int)(sessionEnd * watchTab.TabPictureBox.Width), watchTab.TabPictureBox.Height));
                }
                else
                {
                    g.FillRectangle(new SolidBrush(Color.Green), new Rectangle((int)(sessionStart * watchTab.TabPictureBox.Width), 0, (int)((sessionEnd - sessionStart) * watchTab.TabPictureBox.Size.Width), watchTab.TabPictureBox.Height));
                }

            }
            g.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, watchTab.TabPictureBox.Width - 1, watchTab.TabPictureBox.Height - 1));

            watchTab.TabPictureBox.Image = img;
        }

        private double ConvertTimeToPosition(DateTime time)
        {

            var benchMark = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0, 0));
            if (time.CompareTo(benchMark) > 0)
            {
                return time.Subtract(benchMark).TotalSeconds / (new TimeSpan(1, 0, 0, 0, 0)).TotalSeconds;
            }
            else
            {
                return -1;
            }

        }


        public static TimeSpan TimePlayedSince(DateTime benchmark, List<Session> sessions)
        {
            var returnVal = new TimeSpan();
            for (int i = sessions.Count - 1; i >= 0; i--)
            {
                if (sessions[i].EndTime < benchmark)
                {
                    return returnVal;
                }
                else if (sessions[i].StartTime > benchmark)
                {
                    returnVal += sessions[i].Duration;
                }
                else
                {
                    returnVal += sessions[i].EndTime.Subtract(benchmark);
                    return returnVal;
                }
            }
            return returnVal;
        }

        public static TimeSpan TimePlayedIn(TimeSpan period, List<Session> sessions)
        {
            DateTime benchmark = DateTime.Now.Subtract(period);
            return TimePlayedSince(benchmark, sessions);
        }


        public void Stopped()
        {
            if (currentSession != null)
            {
                mSessions.Add(currentSession.End());
                currentSession = null;
            }
        }

        public void RemoveWatch()
        {
            (new ConfermationBox("Are you shure you want to remove this watch?", () =>
            {
                WatchManager.Watches.Remove(this);
                UIManager.window.RefreshTabs(this);
            })).ShowDialog();
        }



        public void ShowStats()
        {
            Thread t = new Thread(() => { (new StatSheet(Sessions, TotalTimePlayed)).ShowDialog(); });
            t.Start();
        }

        public JObject ToJObject()
        {
            var returnVal = new JObject();
            returnVal.Add("timeplayed", new JValue(TotalTimePlayed));
            returnVal.Add("sessions", JArray.FromObject(Sessions));
            returnVal.Add("name", JValue.FromObject(Name));
            returnVal.Add("alias", JValue.FromObject(Alias));
            return returnVal;
        }



        delegate void SetImageCallback(Image image);
        private void SetPicture(Image image)
        {
            var pb = watchTab.TabPictureBox;
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (pb.InvokeRequired)
            {
                SetImageCallback d = new SetImageCallback(SetPicture);
                pb.Invoke(d, new object[] { image });
            }
            else
            {
                pb.Image = image;
            }
        }
        delegate void SetTextCallback(string text, TextBox tb);
        private void SetText(string text, TextBox tb)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (tb.InvokeRequired)
            {
                try
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    tb.Invoke(d, new object[] { text, tb });
                }
                catch (ObjectDisposedException ode) {}
            }
            else
            {
                tb.Text = text;
            }
        }


    }
}
