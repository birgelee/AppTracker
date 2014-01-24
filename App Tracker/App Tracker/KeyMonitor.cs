using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppTracker;
using System.Threading;

namespace Project1
    {
    public partial class KeyMonitor : Form
        {
        public KeyMonitor()
            {
            InitializeComponent();
            
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Size = new System.Drawing.Size(0, 0);
            this.Location = new Point(200000, 200000);
            mouseKeyEventProvider1.KeyDown += new KeyEventHandler(keyDown);
            mouseKeyEventProvider1.KeyUp += keyUp;
            mouseKeyEventProvider1.Enabled = true;
            }
        Keys altcode;
        private bool ctrl, alt, T;
        public void keyDown(object sender, KeyEventArgs ke)
            {

            if (Program.EndProgram)
                {
                this.Close();
                this.Dispose();
                }
            if (this.WindowState != FormWindowState.Minimized)
                {
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                }
            if (ke.KeyCode == Keys.Control || ke.KeyCode == Keys.ControlKey || ke.KeyCode == Keys.LControlKey || ke.KeyCode == Keys.RControlKey)
                {
                ctrl = true;
                }
            if (ke.KeyCode == Keys.Alt || ke.KeyCode == Keys.LMenu || ke.KeyCode == Keys.RMenu)
                {
                    altcode = ke.KeyCode;
                alt = true;
                }
            if (ke.KeyCode == Keys.T)
                {
                T = true;
                }
            if ((ctrl && alt)  && T)
                {
                UIManager.ShowWindow = true;
                }
            }
        public void keyUp(object sender, KeyEventArgs ke)
            {
            if (Program.EndProgram)
                {
                this.Close();
                this.Dispose();
                }
            if (this.WindowState != FormWindowState.Minimized)
                {
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                }
            if (ke.KeyCode == Keys.Control || ke.KeyCode == Keys.ControlKey || ke.KeyCode == Keys.LControlKey || ke.KeyCode == Keys.RControlKey)
                {
                ctrl = false;
                }
            if (ke.KeyCode == Keys.Alt || ke.KeyCode == Keys.LMenu || ke.KeyCode == Keys.RMenu)
                {
                alt = false;
                }
            if (ke.KeyCode == Keys.T)
                {
                T = false;
                }
            }
        delegate void SetTextCallback(bool visable);
        public void SetVisable(bool visable)
            {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
                {
                SetTextCallback d = new SetTextCallback(SetVisable);
                this.Invoke(d, new object[] { visable });
                }
            else
                {
                this.Visible = visable;
                }
            }


        }
    }
