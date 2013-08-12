using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppTracker;
using AppTracker.Watch;

namespace Project1
    {
    public partial class StatSheet : Form
        {
        public StatSheet(List<Session> stats, TimeSpan totalTimePlayed)
            {

            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            right1.Text = Watch.TimePlayedIn(new TimeSpan(1, 0, 0, 0), stats).ToString();
            right2.Text = (new TimeSpan(0,0,(int)(Watch.TimePlayedIn(new TimeSpan(7, 0, 0, 0), stats).TotalSeconds / 7))).ToString();
            right3.Text = Watch.TimePlayedIn(new TimeSpan(7, 0, 0, 0), stats).ToString();
            right4.Text = (new TimeSpan(0, 0, (int) (Watch.TimePlayedIn(new TimeSpan(30, 0, 0, 0, 0), stats).TotalSeconds / 30))).ToString();
            right5.Text = Watch.TimePlayedSince(DateTime.Now.StartOfWeek(DayOfWeek.Monday), stats).ToString();
            right6.Text = totalTimePlayed.ToString();
            }

        }
    }
