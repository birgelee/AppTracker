using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppTracker.Watch;

namespace Project1
    {
    public class WatchTab
        {
        public delegate void WatchRemover();
        public delegate void ShowStatSheet();
        public WatchTab(WatchRemover remover, ShowStatSheet statSheet)
            {
            Button button1 = DeleteButton;
            PictureBox pictureBox1 = TabPictureBox;
            TextBox textBox1 = TabTextBox1;

            // 
            // StatsButton
            // 
            StatsButton.Location = new System.Drawing.Point(420, 29);
            StatsButton.Name = "stats";
            StatsButton.Size = new System.Drawing.Size(80, 23);
            StatsButton.TabIndex = 0;
            StatsButton.Text = "Statistics";
            StatsButton.UseVisualStyleBackColor = true;
            StatsButton.Click += new EventHandler((obj, e) => statSheet());
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(507, 29);
            button1.Name = "button";
            button1.Size = new System.Drawing.Size(80, 23);
            button1.TabIndex = 0;
            button1.Text = "Delete Watch";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler((obj, e) => remover());
            // 
            // pictureBox1
            // 
            ((System.ComponentModel.ISupportInitialize) (pictureBox1)).BeginInit();
            pictureBox1.Location = new System.Drawing.Point(152, 29);
            pictureBox1.Name = "pictureBox";
            pictureBox1.Size = new System.Drawing.Size(243, 23);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;

            ((System.ComponentModel.ISupportInitialize) (pictureBox1)).EndInit();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Location = new System.Drawing.Point(7, 20);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(130, 13);
            textBox1.TabIndex = 2;
            textBox1.Text = "";
            // 
            // textBox2
            // 
            TabTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TabTextBox2.Location = new System.Drawing.Point(7, 36);
            TabTextBox2.Name = "textBox2";
            TabTextBox2.ReadOnly = true;
            TabTextBox2.Size = new System.Drawing.Size(130, 13);
            TabTextBox2.TabIndex = 2;
            TabTextBox2.Text = "";
            // 
            // textBox2
            // 
            TabTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TabTextBox3.Location = new System.Drawing.Point(7, 52);
            TabTextBox3.Name = "textBox2";
            TabTextBox3.ReadOnly = true;
            TabTextBox3.Size = new System.Drawing.Size(130, 13);
            TabTextBox3.TabIndex = 2;
            TabTextBox3.Text = "";
           
            }
        public TextBox TabTextBox1 = new TextBox();
        public TextBox TabTextBox2 = new TextBox();
        public TextBox TabTextBox3 = new TextBox();
        public Button DeleteButton = new Button();
        public Button StatsButton = new Button();
        public PictureBox TabPictureBox = new PictureBox();
        }
    }
