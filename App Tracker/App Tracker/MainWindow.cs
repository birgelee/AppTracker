using AppTracker.Watch;
using System.Windows.Forms;
using System.Collections.Generic;
using AppTracker;
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
            this.MaximizeBox = false;
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
            this.addWatchButton = new Button();
            this.closeButton = new Button();
            this.showIconCheckBox = new CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

            addWatchButton.Location = new System.Drawing.Point(3, 3);
            addWatchButton.Name = "AddWatch";
            addWatchButton.Size = new System.Drawing.Size(75, 23);
            addWatchButton.TabIndex = 0;
            addWatchButton.Text = "Add Watch";
            addWatchButton.UseVisualStyleBackColor = true;
            addWatchButton.Click += (obj, e) => (new AddWatchForm()).ShowDialog();

            closeButton.Location = new System.Drawing.Point(100, 3);
            closeButton.Name = "Close";
            closeButton.Size = new System.Drawing.Size(75, 23);
            closeButton.TabIndex = 0;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += (obj, e) => exitProgram();

            showIconCheckBox.Location = new System.Drawing.Point(197, 3);
            showIconCheckBox.Name = "ShowIconCheckBox";
            showIconCheckBox.Size = new System.Drawing.Size(100, 23);
            showIconCheckBox.TabIndex = 0;
            showIconCheckBox.Text = "Show Icon";
            showIconCheckBox.UseVisualStyleBackColor = true;
            showIconCheckBox.Checked = true;
            showIconCheckBox.CheckedChanged += (sender, args) => { if (showIconCheckBox.Checked) { UIManager.TrayIcon.Visible = true; } else { UIManager.TrayIcon.Visible = false; } };

            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 330);
            this.panel1.TabIndex = 0;
            for (int i = 0; i < WatchManager.Watches.Count; i++)
            {
                ShowWatchTab(WatchManager.Watches[i], i);
            }
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 427);
            this.Controls.Add(this.panel1);
            this.Controls.Add(addWatchButton);
            this.Controls.Add(closeButton);
            this.Controls.Add(showIconCheckBox);
            this.Name = "MainWindow";
            this.Text = "App Tracker";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Button addWatchButton;
        private Button closeButton;
        private CheckBox showIconCheckBox;

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
            groupBox1.Controls.Add(watch.watchTab.TabTextBox1);
            groupBox1.Controls.Add(watch.watchTab.TabTextBox2);
            groupBox1.Controls.Add(watch.watchTab.TabTextBox3);
            groupBox1.Controls.Add(watch.watchTab.TabPictureBox);
            groupBox1.Controls.Add(watch.watchTab.DeleteButton);
            groupBox1.Controls.Add(watch.watchTab.StatsButton);
            groupBox1.Location = new System.Drawing.Point(3, 3 + 77 * position);
            groupBox1.Name = "groupBox" + position;
            groupBox1.Size = new System.Drawing.Size(590, 74);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = watch.Alias;

            this.panel1.Controls.Add(groupBox1);
            tabs.Add(watch, groupBox1);
        }

        private void exitProgram()
        {
            this.Close();
            this.Dispose();
            Program.EndProgram = true;
        }

        public void InvokeCloseOperation()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate()
                {
                    Close();
                });
            }
            else
            {
                Close();
            }
        }


    }
}
