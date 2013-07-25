using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            mouseKeyEventProvider1.KeyDown += new KeyEventHandler((a, b) => keyDown());
            //this.KeyDown += new KeyEventHandler((a, b) => keyDown());
            //this.KeyPreview = true;
            }
        public void keyDown()
            {
            this.textBox1.Text = "key";
            }
        }
    }
