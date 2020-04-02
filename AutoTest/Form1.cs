using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            this.IsMdiContainer = true;//设置父窗体是容器
        }
        private void ToDimming_Click(object sender, EventArgs e)
        {
            Dimming form1 = new Dimming();
            panel1.Controls.Remove(form1);
            panel1.Controls.Clear();// 移除 panel1内的所有控件  
            form1.FormBorderStyle = FormBorderStyle.None; //隐藏子窗体边框（去除最小花，最大化，关闭等按钮）    
            form1.TopLevel = false; //指示子窗体非顶级窗体         
            this.panel1.Controls.Add(form1);//将子窗体载入panel     
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Line form1 = new Line();
            panel1.Controls.Remove(form1);
            panel1.Controls.Clear();// 移除 panel1内的所有控件  
            form1.FormBorderStyle = FormBorderStyle.None; //隐藏子窗体边框（去除最小花，最大化，关闭等按钮）    
            form1.TopLevel = false; //指示子窗体非顶级窗体         
            this.panel1.Controls.Add(form1);//将子窗体载入panel     
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load form1 = new Load();
            panel1.Controls.Remove(form1);
            panel1.Controls.Clear();// 移除 panel1内的所有控件  
            form1.FormBorderStyle = FormBorderStyle.None; //隐藏子窗体边框（去除最小花，最大化，关闭等按钮）    
            form1.TopLevel = false; //指示子窗体非顶级窗体         
            this.panel1.Controls.Add(form1);//将子窗体载入panel     
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Harmonic form1 = new Harmonic();
            panel1.Controls.Remove(form1);
            panel1.Controls.Clear();// 移除 panel1内的所有控件  
            form1.FormBorderStyle = FormBorderStyle.None; //隐藏子窗体边框（去除最小花，最大化，关闭等按钮）    
            form1.TopLevel = false; //指示子窗体非顶级窗体         
            this.panel1.Controls.Add(form1);//将子窗体载入panel     
            form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         /*   temperature form1 = new temperature();
            panel1.Controls.Remove(form1);
            panel1.Controls.Clear();// 移除 panel1内的所有控件  
            form1.FormBorderStyle = FormBorderStyle.None; //隐藏子窗体边框（去除最小花，最大化，关闭等按钮）    
            form1.TopLevel = false; //指示子窗体非顶级窗体         
            this.panel1.Controls.Add(form1);//将子窗体载入panel     
            form1.Show();*/
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定退出自动测试吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
