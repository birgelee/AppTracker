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
        private static InfoBox activeBox;
        public static void ShowMessage(string text)
        {
            if (activeBox == null || activeBox.Visible == false)
            {
                activeBox = new InfoBox(text + "\n");
                Thread t = new Thread(() => (activeBox).ShowDialog());
                t.Start();
            }
            else
            {
                activeBox.textBox1.Text += text + "\n";
            }

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
