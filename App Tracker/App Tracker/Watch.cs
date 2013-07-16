using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project1;
using System.Windows.Forms;
using System.Drawing;

namespace AppTracker.Watch
    {
    public class Watch
        {
        public Watch(string name)
            {
            this.Name = name;
            watchTab = new WatchTab("Time Played: none", RemoveWatch);
            }

        public string Name;

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
            SetText("Time Played: " + TotalTimePlayed.Hours + ":" + TotalTimePlayed.Minutes + ":" + TotalTimePlayed.Seconds);
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
                    g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(0, 0, (int) (sessionEnd * watchTab.TabPictureBox.Width), watchTab.TabPictureBox.Height));
                    }
                else
                    {
                    g.FillRectangle(new SolidBrush(Color.Green), new Rectangle((int) (sessionStart * watchTab.TabPictureBox.Width), 0, (int) ((sessionEnd - sessionStart) * watchTab.TabPictureBox.Size.Width), watchTab.TabPictureBox.Height));
                    }
                
                }
            
            watchTab.TabPictureBox.Image = img;
            }
            
        private double ConvertTimeToPosition(DateTime time)
            {

            var benchMark = DateTime.Now.Subtract(new TimeSpan(0, 0, 1, 0, 0));
            if (time.CompareTo(benchMark) > 0)
                {
                return time.Subtract(benchMark).TotalSeconds / (new TimeSpan(0, 0,1, 0, 0)).TotalSeconds;
                }
            else
                {
                return -1;
                }

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
        delegate void SetTextCallback(string text);
        private void SetText(string text)
            {
            TextBox tb = watchTab.TabTextBox;
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (tb.InvokeRequired)
                {
                SetTextCallback d = new SetTextCallback(SetText);
                tb.Invoke(d, new object[] { text });
                }
            else
                {
                tb.Text = text;
                }
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

            WatchManager.Watches.Remove(this);
            UIManager.window.RefreshTabs(this);
            }


        }
    }
