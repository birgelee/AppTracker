using AppTracker.Watch;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Project1
    {
    public class MainWindow : Form
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MainWindow()
            {
            InitializeComponent();
            }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.panel1 = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.refreshButton = new Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            refreshButton.Location = new System.Drawing.Point(3, 3);
            refreshButton.Name = "AddWatch";
            refreshButton.Size = new System.Drawing.Size(75, 23);
            refreshButton.TabIndex = 0;
            refreshButton.Text = "Add Watch";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += (obj, e) => (new AddWatchForm()).ShowDialog();


            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 190);
            this.panel1.TabIndex = 0;
            for (int i = 0; i < WatchManager.Watches.Count; i++)
                {
                ShowWatchTab(WatchManager.Watches[i], i);
                }
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.TabIndex = 0;
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Scroll += (sender, e) => { panel1.VerticalScroll.Value = vScrollBar1.Value; };
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 327);
            this.Controls.Add(this.panel1);
            this.Controls.Add(refreshButton);
            this.Controls.Add(this.vScrollBar1);
            this.Name = "MainWindow";
            this.Text = "App Tracker";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private Button refreshButton;

        public void RefreshTabs(Watch removedWatch)
            {
            this.panel1.Controls.Clear();
            tabs.Clear();
            for (int i = 0; i < WatchManager.Watches.Count; i++)
                {
                ShowWatchTab(WatchManager.Watches[i], i);
                }
            

            }

        private Dictionary<Watch, GroupBox> tabs = new Dictionary<Watch, GroupBox>();
        private void ShowWatchTab(Watch watch, int position)
            {
            System.Windows.Forms.GroupBox groupBox1 = new GroupBox();

            groupBox1.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(watch.watchTab.TabTextBox);
            groupBox1.Controls.Add(watch.watchTab.TabPictureBox);
            groupBox1.Controls.Add(watch.watchTab.TabButton);
            groupBox1.Location = new System.Drawing.Point(3, 3 + 77 * position);
            groupBox1.Name = "groupBox" + position;
            groupBox1.Size = new System.Drawing.Size(546, 74);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = watch.Name;

            this.panel1.Controls.Add(groupBox1);
            tabs.Add(watch, groupBox1);
            }

        }
    }
