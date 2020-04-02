namespace AutoTest
{
    partial class temperature
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
            this.button1 = new System.Windows.Forms.Button();
            this.setIO = new System.Windows.Forms.Button();
            this.IOT2700 = new System.Windows.Forms.TextBox();
            this.T2700 = new System.Windows.Forms.CheckBox();
            this.IO6812B = new System.Windows.Forms.TextBox();
            this.A6812B = new System.Windows.Forms.CheckBox();
            this.IO6063B = new System.Windows.Forms.TextBox();
            this.A6063B = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(904, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 35);
            this.button1.TabIndex = 76;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.TestStart_Click);
            // 
            // setIO
            // 
            this.setIO.Location = new System.Drawing.Point(904, 12);
            this.setIO.Name = "setIO";
            this.setIO.Size = new System.Drawing.Size(135, 41);
            this.setIO.TabIndex = 75;
            this.setIO.Text = "check connect";
            this.setIO.UseVisualStyleBackColor = true;
            this.setIO.Click += new System.EventHandler(this.SetIO_Click);
            // 
            // IOT2700
            // 
            this.IOT2700.Location = new System.Drawing.Point(801, 97);
            this.IOT2700.Name = "IOT2700";
            this.IOT2700.Size = new System.Drawing.Size(68, 26);
            this.IOT2700.TabIndex = 71;
            this.IOT2700.Text = "16";
            // 
            // T2700
            // 
            this.T2700.AutoSize = true;
            this.T2700.Checked = true;
            this.T2700.CheckState = System.Windows.Forms.CheckState.Checked;
            this.T2700.Location = new System.Drawing.Point(656, 99);
            this.T2700.Name = "T2700";
            this.T2700.Size = new System.Drawing.Size(71, 24);
            this.T2700.TabIndex = 70;
            this.T2700.Text = "2700";
            this.T2700.UseVisualStyleBackColor = true;
            // 
            // IO6812B
            // 
            this.IO6812B.Location = new System.Drawing.Point(801, 54);
            this.IO6812B.Name = "IO6812B";
            this.IO6812B.Size = new System.Drawing.Size(68, 26);
            this.IO6812B.TabIndex = 69;
            this.IO6812B.Text = "12";
            // 
            // A6812B
            // 
            this.A6812B.AutoSize = true;
            this.A6812B.Checked = true;
            this.A6812B.CheckState = System.Windows.Forms.CheckState.Checked;
            this.A6812B.Location = new System.Drawing.Point(656, 56);
            this.A6812B.Name = "A6812B";
            this.A6812B.Size = new System.Drawing.Size(135, 24);
            this.A6812B.TabIndex = 68;
            this.A6812B.Text = "Agilent 6812B";
            this.A6812B.UseVisualStyleBackColor = true;
            // 
            // IO6063B
            // 
            this.IO6063B.Location = new System.Drawing.Point(801, 10);
            this.IO6063B.Name = "IO6063B";
            this.IO6063B.Size = new System.Drawing.Size(68, 26);
            this.IO6063B.TabIndex = 67;
            this.IO6063B.Text = "5";
            // 
            // A6063B
            // 
            this.A6063B.AutoSize = true;
            this.A6063B.Checked = true;
            this.A6063B.CheckState = System.Windows.Forms.CheckState.Checked;
            this.A6063B.Location = new System.Drawing.Point(656, 12);
            this.A6063B.Name = "A6063B";
            this.A6063B.Size = new System.Drawing.Size(135, 24);
            this.A6063B.TabIndex = 66;
            this.A6063B.Text = "Agilent 6063B";
            this.A6063B.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(357, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 26);
            this.textBox1.TabIndex = 78;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(462, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 26);
            this.textBox2.TabIndex = 79;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(559, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(70, 26);
            this.textBox3.TabIndex = 80;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(357, 55);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(70, 26);
            this.textBox4.TabIndex = 81;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(462, 55);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(70, 26);
            this.textBox5.TabIndex = 82;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(559, 55);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(70, 26);
            this.textBox6.TabIndex = 83;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(559, 149);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(70, 26);
            this.textBox7.TabIndex = 89;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(462, 149);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(70, 26);
            this.textBox8.TabIndex = 88;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(357, 149);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(70, 26);
            this.textBox9.TabIndex = 87;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(559, 106);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(70, 26);
            this.textBox10.TabIndex = 86;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(462, 106);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(70, 26);
            this.textBox11.TabIndex = 85;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(357, 106);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(70, 26);
            this.textBox12.TabIndex = 84;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(559, 240);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(70, 26);
            this.textBox13.TabIndex = 95;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(462, 240);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(70, 26);
            this.textBox14.TabIndex = 94;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(357, 240);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(70, 26);
            this.textBox15.TabIndex = 93;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(559, 197);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(70, 26);
            this.textBox16.TabIndex = 92;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(462, 197);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(70, 26);
            this.textBox17.TabIndex = 91;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(357, 197);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(70, 26);
            this.textBox18.TabIndex = 90;
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(559, 288);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(70, 26);
            this.textBox19.TabIndex = 98;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(462, 288);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(70, 26);
            this.textBox20.TabIndex = 97;
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(357, 288);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(70, 26);
            this.textBox21.TabIndex = 96;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 10);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(160, 553);
            this.listView1.TabIndex = 99;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 100;
            this.label1.Text = "Voltage(V)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 101;
            this.label2.Text = "Frequency(Hz) ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 102;
            this.label3.Text = "Current(A)  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 103;
            this.label4.Text = "Duration (Min) ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 104;
            this.label5.Text = "Volt No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 105;
            this.label6.Text = "Temp Channel ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(221, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 106;
            this.label7.Text = "Scan Time (s) ";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(826, 493);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(213, 26);
            this.textBox22.TabIndex = 108;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(826, 525);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(213, 38);
            this.button2.TabIndex = 107;
            this.button2.Text = "SAVE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Save_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(225, 332);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(404, 38);
            this.button3.TabIndex = 109;
            this.button3.Text = "确认参数";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // temperature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 575);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.setIO);
            this.Controls.Add(this.IOT2700);
            this.Controls.Add(this.T2700);
            this.Controls.Add(this.IO6812B);
            this.Controls.Add(this.A6812B);
            this.Controls.Add(this.IO6063B);
            this.Controls.Add(this.A6063B);
            this.Name = "temperature";
            this.Text = "temperature";
            this.Load += new System.EventHandler(this.Temperature_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button setIO;
        private System.Windows.Forms.TextBox IOT2700;
        private System.Windows.Forms.CheckBox T2700;
        private System.Windows.Forms.TextBox IO6812B;
        private System.Windows.Forms.CheckBox A6812B;
        private System.Windows.Forms.TextBox IO6063B;
        private System.Windows.Forms.CheckBox A6063B;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}