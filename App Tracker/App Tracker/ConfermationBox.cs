using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project1
{
    public partial class ConfermationBox : Form
    {
        public delegate void Commands();
        private Commands action;
        public ConfermationBox(string message, Commands action)
        {
            
            this.action = action;
            InitializeComponent();
            textBox1.Text = message;
        }

        private void ConfermationBox_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Yes_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            action();
        }

        private void No_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
