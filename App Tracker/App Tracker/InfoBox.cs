using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Project1
    {
    public partial class InfoBox : Form
        {
        public static void ShowMessage(string text)
            {
            Thread t = new Thread(() => (new InfoBox(text)).ShowDialog());
            t.Start();
            }
        public InfoBox(string text)
            {
            InitializeComponent();
            textBox1.Text = text;
            textBox1.BorderStyle = BorderStyle.None;
            }

        private void InfoBox_Load(object sender, EventArgs e)
            {
            
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }
        }
    }
