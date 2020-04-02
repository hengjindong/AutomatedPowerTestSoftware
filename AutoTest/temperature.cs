using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ivi.Visa.Interop;
using OsramDaliApi;
using Excel = Microsoft.Office.Interop.Excel;

namespace AutoTest
{
    public partial class temperature : Form
    {
        public temperature()
        {
            InitializeComponent();
        }

        private void Temperature_Load(object sender, EventArgs e)
        {

        }

        private void SetIO_Click(object sender, EventArgs e)
        {

        }

        private void TestStart_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            string savepath = "";
            string savename = "";
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            savename = textBox1.Text.ToString();
            savepath = path.SelectedPath;
            object missing = System.Reflection.Missing.Value;
            Excel.Application myExcel = new Excel.Application();
            Excel._Workbook xBk;
            xBk = myExcel.Workbooks.Add(true);



            myExcel.Visible = true;
            xBk.SaveAs(savepath + "\\" + savename + ".xls", missing, missing,
            missing, missing, missing, Excel.XlSaveAsAccessMode.xlShared,
            missing, missing, missing, missing, missing);
            myExcel.Quit();
            MessageBox.Show("已完保存所有测试数据", "保存成功提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
}
