namespace Project1
    {
    partial class StatSheet
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.left1 = new System.Windows.Forms.TextBox();
            this.right1 = new System.Windows.Forms.TextBox();
            this.right4 = new System.Windows.Forms.TextBox();
            this.left4 = new System.Windows.Forms.TextBox();
            this.right3 = new System.Windows.Forms.TextBox();
            this.left3 = new System.Windows.Forms.TextBox();
            this.right2 = new System.Windows.Forms.TextBox();
            this.left2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.right5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // left1
            // 
            this.left1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.left1.Location = new System.Drawing.Point(13, 13);
            this.left1.Multiline = true;
            this.left1.Name = "left1";
            this.left1.ReadOnly = true;
            this.left1.Size = new System.Drawing.Size(171, 20);
            this.left1.TabIndex = 0;
            this.left1.Text = "Time played last 24h:";
            // 
            // right1
            // 
            this.right1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.right1.Location = new System.Drawing.Point(190, 13);
            this.right1.Name = "right1";
            this.right1.ReadOnly = true;
            this.right1.Size = new System.Drawing.Size(176, 13);
            this.right1.TabIndex = 1;
            // 
            // right4
            // 
            this.right4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.right4.Location = new System.Drawing.Point(191, 70);
            this.right4.Name = "right4";
            this.right4.ReadOnly = true;
            this.right4.Size = new System.Drawing.Size(176, 13);
            this.right4.TabIndex = 3;
            // 
            // left4
            // 
            this.left4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.left4.Location = new System.Drawing.Point(13, 70);
            this.left4.Name = "left4";
            this.left4.ReadOnly = true;
            this.left4.Size = new System.Drawing.Size(172, 13);
            this.left4.TabIndex = 2;
            this.left4.Text = "Avrage time a week (last month):";
            // 
            // right3
            // 
            this.right3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.right3.Location = new System.Drawing.Point(191, 51);
            this.right3.Name = "right3";
            this.right3.ReadOnly = true;
            this.right3.Size = new System.Drawing.Size(176, 13);
            this.right3.TabIndex = 5;
            // 
            // left3
            // 
            this.left3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.left3.Location = new System.Drawing.Point(13, 51);
            this.left3.Name = "left3";
            this.left3.ReadOnly = true;
            this.left3.Size = new System.Drawing.Size(172, 13);
            this.left3.TabIndex = 4;
            this.left3.Text = "Time played last 7 days:";
            // 
            // right2
            // 
            this.right2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.right2.Location = new System.Drawing.Point(190, 32);
            this.right2.Name = "right2";
            this.right2.ReadOnly = true;
            this.right2.Size = new System.Drawing.Size(176, 13);
            this.right2.TabIndex = 7;
            // 
            // left2
            // 
            this.left2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.left2.Location = new System.Drawing.Point(13, 32);
            this.left2.Name = "left2";
            this.left2.ReadOnly = true;
            this.left2.Size = new System.Drawing.Size(171, 13);
            this.left2.TabIndex = 6;
            this.left2.Text = "Avrage time a day (last week):";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(172, 13);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Total time:";
            // 
            // right5
            // 
            this.right5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.right5.Location = new System.Drawing.Point(190, 89);
            this.right5.Name = "right5";
            this.right5.ReadOnly = true;
            this.right5.Size = new System.Drawing.Size(176, 13);
            this.right5.TabIndex = 9;
            // 
            // StatSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 262);
            this.Controls.Add(this.right5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.right2);
            this.Controls.Add(this.left2);
            this.Controls.Add(this.right3);
            this.Controls.Add(this.left3);
            this.Controls.Add(this.right4);
            this.Controls.Add(this.left4);
            this.Controls.Add(this.right1);
            this.Controls.Add(this.left1);
            this.Name = "StatSheet";
            this.Text = "StatSheet";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.TextBox left1;
        private System.Windows.Forms.TextBox right1;
        private System.Windows.Forms.TextBox right4;
        private System.Windows.Forms.TextBox left4;
        private System.Windows.Forms.TextBox right3;
        private System.Windows.Forms.TextBox left3;
        private System.Windows.Forms.TextBox right2;
        private System.Windows.Forms.TextBox left2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox right5;
        }
    }