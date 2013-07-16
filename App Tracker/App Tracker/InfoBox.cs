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
    public partial class InfoBox : Form
        {
        public InfoBox(string text)
            {
            InitializeComponent();
            textBox1.Text = text;
            }

        private void InfoBox_Load(object sender, EventArgs e)
            {
            
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }
        }
    }
