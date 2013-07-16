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
        public WatchTab(String timePlayed, WatchRemover remover)
            {
            Button button1 = TabButton;
            PictureBox pictureBox1 = TabPictureBox;
            TextBox textBox1 = TabTextBox;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(461, 29);
            button1.Name = "button";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Delete Watch";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler((obj, e) => remover());
            // 
            // pictureBox1
            // 
            ((System.ComponentModel.ISupportInitialize) (pictureBox1)).BeginInit();
            pictureBox1.Location = new System.Drawing.Point(169, 29);
            pictureBox1.Name = "pictureBox";
            pictureBox1.Size = new System.Drawing.Size(293, 23);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;

            ((System.ComponentModel.ISupportInitialize) (pictureBox1)).EndInit();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Location = new System.Drawing.Point(7, 29);
            textBox1.Name = "textBox";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(100, 13);
            textBox1.TabIndex = 2;
            textBox1.Text = timePlayed;
            }
        public TextBox TabTextBox = new TextBox();
        public Button TabButton = new Button();
        public PictureBox TabPictureBox = new PictureBox();
        }
    }
