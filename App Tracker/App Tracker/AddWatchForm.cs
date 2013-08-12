using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppTracker.Watch;
using AppTracker;

namespace Project1
    {
    public partial class AddWatchForm : Form
        {
        public AddWatchForm()
            {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            }

        private void button1_Click(object sender, EventArgs e)
            {
            Watch w = new Watch(watchName.Text);
            WatchManager.Watches.Add(w);
            UIManager.window.RefreshTabs(w);
            Program.Save();
            this.Close();
            this.Dispose();
            }
        }
    }
