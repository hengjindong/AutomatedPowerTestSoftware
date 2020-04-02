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

    public partial class Line : Form
    {
        /*
         * 
         * 不记录输入变量current 和 CV
         * 通过分隔符标记current 和 CV
         * 并且记录 I U P 和 U PF P harm
         * 区分是否是dali设备，dali设备使用分隔符记录current
         */
        //用于控制，测试开始时候无法点击其他
        bool start = false;
        bool daliex = false;
        //此处为保存数据时的中间数组
        int[] SET_Vin = new int[8000];
        int[] SET_Vout = new int[8000];
        float[] measure_in_I = new float[8000];
        float[] measure_in_U = new float[8000];
        float[] measure_in_P = new float[8000];
        float[] measure_out_U = new float[8000];
        float[] measure_out_PF = new float[8000];
        float[] measure_out_P = new float[8000];
        int measure_point = 0;
        //用户输入的端口
        string setIO_6063B;
        string setIO_WT210_1;
        string setIO_WT210_2;
        string setIO_6812B;
        //输入的参数，用户输入的测试参数
        int set_U_max = 31;
        int set_U_min = 30;
        int set_U_step = 1;
        int set_Vin_max = 240;
        int set_Vin_min = 220;
        int set_Vin_step = 10;
        int set_I_min = 400;
        int set_I_max = 700;
        int set_I_step = 100;
        string set_Vin_f = "50";
        string set_Vin_M = "AC";
        //DALI的操作
        string dalitext = "";
        OsramDaliInterface atest = new OsramDaliInterface();
        TypeDaliCommand[] dali_command_1 = new TypeDaliCommand[1];
        public Line()
        {
            InitializeComponent();
        }
        private void Line_Load(object sender, EventArgs e)
        {
            //首先加载listview的页面
            listView1.View = View.Details;
            listView1.Columns.Add("inputCV");
            listView1.Columns.Add("Vin");
            listView1.Columns.Add("U_out");
            listView1.Columns.Add("I_out");
            listView1.Columns.Add("P_out");
            listView1.Columns.Add("U_int");
            listView1.Columns.Add("PF_int");
            listView1.Columns.Add("P_int");
            dali_command_1[0].type = 0x00;
            dali_command_1[0].highByte = 0xFF;
            dali_command_1[0].lowByte = 0xFF;
            dali_command_1[0].thirdByte = 0xFF;
            dali_command_1[0].replyType = 0x01;
            dali_command_1[0].replyValue = 0x01;
            atest.Init();
            atest.ScanForDaliUnitDevices();
            atest.GetDaliUnitCount();
            atest.OpenDaliUnit(0);
            atest.DaliVoltageGetState(0, 0);
            atest.DaliSupplyOn(0, 0);
            atest.DaliSupplyGetState(0, 0);
        }
        //确认连接
        private void SetIO_Click(object sender, EventArgs e)
        {
            if (start == false)
            {
                string showSucc = "";
                string showFail = "";
                //读取用户输入的端口
                setIO_6063B = IO6063B.Text.ToString();
                setIO_WT210_1 = IOWT210_1.Text.ToString();
                setIO_WT210_2 = IOWT210_2.Text.ToString();
                setIO_6812B = IO6812B.Text.ToString();
                if (A6063B.Checked)
                {
                    if (Program.Agilent6063B.Link(setIO_6063B))
                    {
                        showSucc += "Agilent 6063B\r\n";
                    }
                    else
                    {
                        showFail += "Agilent 6063B\r\n";
                    }
                }
                if (A6812B.Checked)
                {
                    if (Program.Agilent6812B.Link(setIO_6812B))
                    {
                        showSucc += "Agilent 6812B\r\n";
                    }
                    else
                    {
                        showFail +=  "Agilent 6812B\r\n";
                    }
                }
                if (WT210_1.Checked)
                {
                    if (Program.WT210_1.Link(setIO_WT210_1))
                    {
                        showSucc +=  "WT210_1\r\n";
                    }
                    else
                    {
                        showFail +=  "WT210_1\r\n";
                    }
                }
                if (WT210_2.Checked)
                {
                    if (Program.WT210_2.Link(setIO_WT210_2))
                    {
                        showSucc += "WT210_2\r\n";
                    }
                    else
                    {
                        showFail += "WT210_2\r\n";
                    }
                }
                if (DALImagic.Checked)
                {
                    if (Program.DALImagic.Link())
                    {
                        showSucc += "DALImagic\r\n";
                        daliex = true;
                    }
                    else
                    {
                        showFail += "DALImagic\r\n";
                        daliex = false;
                    }
                }
                MessageBox.Show(showSucc + "连接成功\r\n\r\n" + showFail + "连接失败\r\n");
            }
            else
            {
                MessageBox.Show("正在测试，无法更改");
            }
        }
        //获取设置参数
        private void GetSet_Click(object sender, EventArgs e)
        {
            if (start == false)
            {
                string get1 = textBox7.Text.ToString();
                set_U_min = int.Parse(get1);
                get1 = textBox2.Text.ToString();
                set_U_max = int.Parse(get1);
                get1 = textBox3.Text.ToString();
                set_U_step = int.Parse(get1);
                get1 = textBox4.Text.ToString();
                set_I_min = int.Parse(get1);
                get1 = textBox5.Text.ToString();
                set_I_max = int.Parse(get1);
                get1 = textBox6.Text.ToString();
                set_I_step = int.Parse(get1);
                get1 = textBox13.Text.ToString();
                set_Vin_min = int.Parse(get1);
                get1 = textBox12.Text.ToString();
                set_Vin_max = int.Parse(get1);
                get1 = textBox11.Text.ToString();
                set_Vin_step = int.Parse(get1);
                set_Vin_f = textBox9.Text.ToString();
                set_Vin_M = textBox8.Text.ToString();
            }
            else
            {
                MessageBox.Show("正在测试，无法更改");
            }
        }
        //保存
        private void Save_Click(object sender, EventArgs e)
        {
            //save
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
            myExcel.Cells[1, 1] = "SOURCE :";
            myExcel.Cells[1, 2] = "";
            myExcel.Cells[1, 3] = set_Vin_f + " (HZ)";
            myExcel.Cells[1, 4] = set_Vin_M;
            myExcel.Cells[1, 5] = "";
            myExcel.Cells[1, 6] = "";
            myExcel.Cells[1, 7] = dalitext;
            myExcel.Cells[1, 8] = "";
            myExcel.Cells[2, 1] = "setting Vin";
            myExcel.Cells[2, 2] = "setting Vout";
            myExcel.Cells[2, 3] = "IN voltage (V)";
            myExcel.Cells[2, 4] = "IN current (A)";
            myExcel.Cells[2, 5] = "IN power (W)";
            myExcel.Cells[2, 6] = "OUT voltage (V)";
            myExcel.Cells[2, 7] = "OUT PF";
            myExcel.Cells[2, 8] = "OUT power (W)";
            for (int i = 0; i < 8000; i++)
            {
                myExcel.Cells[i + 3, 1] = SET_Vin[i];
                myExcel.Cells[i + 3, 2] = SET_Vout[i];
                myExcel.Cells[i + 3, 3] = measure_in_U[i];
                myExcel.Cells[i + 3, 4] = measure_in_I[i];
                myExcel.Cells[i + 3, 5] = measure_in_P[i];
                myExcel.Cells[i + 3, 6] = measure_out_U[i];
                myExcel.Cells[i + 3, 7] = measure_out_PF[i];
                myExcel.Cells[i + 3, 8] = measure_out_P[i];
            }
            myExcel.Visible = true;
            xBk.SaveAs(savepath + "\\" + savename + ".xls", missing, missing,
            missing, missing, missing, Excel.XlSaveAsAccessMode.xlShared,
            missing, missing, missing, missing, missing);
            myExcel.Quit();
            MessageBox.Show("已完保存所有测试数据", "保存成功提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private void TestStart_Click(object sender, EventArgs e)
        {
            start = true;
            if (daliex)
            {
                Test_dali();
                dalitext = "dali";
            }
            else
            {
                Test();
            }
            Program.Agilent6812B.Close(setIO_6812B);
            Program.Agilent6063B.Close(setIO_6063B);
            start = false;
            MessageBox.Show("已完成自动测试", "完成测试提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        public void Test_dali()
        {
                measure_point = 0;
                dali_command_1[0].highByte = 0xFE;
                dali_command_1[0].lowByte = 0xFE;
                atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
                Program.delay.Delay1(1);
                Program.WT210_2.SetReadPF(setIO_WT210_2);
                Program.Agilent6063B.InitSetCV(setIO_6063B);
            for (int j = set_Vin_min; j < set_Vin_max; j += set_Vin_step)
                {
                    Program.Agilent6812B.SetPut(j.ToString(), set_Vin_f, set_Vin_M, setIO_6812B);
                for (int i = set_U_min; i < set_U_max; i += set_U_step)
                    {
                        Changevolte(i);
                        Changecurrent(i, j);
                        if (i + set_U_step >= set_U_max)
                        {
                            Changevolte(set_U_max);
                            Changecurrent(i, j);
                        }
                    }
                    if (j + set_Vin_step >= set_Vin_max)
                    {
                        Program.Agilent6812B.SetPut(set_Vin_max.ToString(), set_Vin_f, set_Vin_M, setIO_6812B);
                    for (int i = set_U_min; i < set_U_max; i += set_U_step)
                        {
                            Changevolte(i);
                            Changecurrent(i, j);
                            if (i + set_U_step >= set_U_max)
                            {
                                Changevolte(set_U_max);
                                Changecurrent(i, j);
                            }
                        }
                    }
                }
            }
        public void Test()
        {
            measure_point = 0;
            dali_command_1[0].highByte = 0xFE;
            dali_command_1[0].lowByte = 0xFE;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            Program.delay.Delay1(1);
            Program.WT210_2.SetReadPF(setIO_WT210_2);
            Program.Agilent6063B.InitSetCV(setIO_6063B);
            for (int j = set_Vin_min; j < set_Vin_max; j += set_Vin_step)
            {
                Program.Agilent6812B.SetPut(j.ToString(), set_Vin_f, set_Vin_M, setIO_6812B);
                for (int i = set_U_min; i < set_U_max; i += set_U_step)
                {
                    Program.Agilent6063B.SetCV(i.ToString(), setIO_6063B);
                    Program.delay.Delay1(2);
                    Read(i, j);
                    if (i + set_U_step >= set_U_max)
                    {
                        Program.Agilent6063B.SetCV(set_U_max.ToString(), setIO_6063B);
                        Program.delay.Delay1(2);
                        Read(i, j);
                    }
                }
                if (j + set_Vin_step >= set_Vin_max)
                {
                    Program.Agilent6812B.SetPut(set_Vin_max.ToString(), set_Vin_f, set_Vin_M, setIO_6812B);
                    for (int i = set_U_min; i < set_U_max; i += set_U_step)
                    {
                        Program.Agilent6063B.SetCV(i.ToString(), setIO_6063B);
                        Program.delay.Delay1(2);
                        Read(i, j);
                        if (i + set_U_step >= set_U_max)
                        {
                            Program.Agilent6063B.SetCV(set_U_max.ToString(), setIO_6063B);
                            Program.delay.Delay1(2);
                            Read(i, j);
                        }
                    }
                }
            }
        }
        public void Changecurrent(int vout ,int vin)
        {
            for (int i = set_I_min; i < set_I_max; i += set_I_step)
            {
                Set_current(i);
                Program.delay.Delay1(2);
                Read(vout, vin);
                if (i + set_I_step >= set_I_max)
                {
                    Set_current(set_I_max);
                    Program.delay.Delay1(2);
                    Read(vout, vin);
                }
            }
        }
        public void Read(int Vout, int Vin)
        {
            Program.delay.Delay1(1);
            float[] mesure1 = Program.WT210_1.ReadValue(setIO_WT210_1);
            float[] mesure2 = Program.WT210_2.ReadValue(setIO_WT210_2);
            SET_Vin[measure_point] = Vin;
            SET_Vout[measure_point] = Vout;
            measure_in_U[measure_point] = mesure1[0];
            measure_in_I[measure_point] = mesure1[1];
            measure_in_P[measure_point] = mesure1[2];
            measure_out_U[measure_point] = mesure2[0];
            measure_out_PF[measure_point] = mesure2[2];
            measure_out_P[measure_point] = mesure2[1];
            measure_point++;
            //下面为实时更新数
            ListViewItem lvi = new ListViewItem();
            this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  
            lvi.Text = Vout.ToString();
            lvi.SubItems.Add(Vin.ToString());
            lvi.SubItems.Add(mesure1[0].ToString());
            lvi.SubItems.Add(mesure1[1].ToString());
            lvi.SubItems.Add(mesure1[2].ToString());
            lvi.SubItems.Add(mesure2[0].ToString());
            lvi.SubItems.Add(mesure2[2].ToString());
            lvi.SubItems.Add(mesure2[1].ToString());
            this.listView1.Items.Add(lvi);
            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        public void Changevolte(int i)
        {
            dali_command_1[0].highByte = 0xFE;
            dali_command_1[0].lowByte = 0x00;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            Program.Agilent6063B.SetCV(i.ToString(), setIO_6063B);
            dali_command_1[0].highByte = 0xFE;
            dali_command_1[0].lowByte = 0xFE;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
        }
        public void Set_current(int current)
        {
            byte[] hex = new byte[4];
            hex[0] = (byte)(current & 0x0000FF);
            hex[1] = (byte)((current >> 8) & 0x0000FF);
            hex[2] = (byte)((current >> 16) & 0x0000FF);
            hex[3] = (byte)((current >> 24) & 0x0000FF);
            byte low = hex[0];
            byte high = hex[1];

            dali_command_1[0].highByte = 0xC3;
            dali_command_1[0].lowByte = 0x03;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xA3;
            dali_command_1[0].lowByte = 0x02;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xFF;
            dali_command_1[0].lowByte = 0x81;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xFF;
            dali_command_1[0].lowByte = 0x81;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xC7;
            dali_command_1[0].lowByte = 0x55;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);

            dali_command_1[0].highByte = 0xC3;
            dali_command_1[0].lowByte = 0x03;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xA3;
            dali_command_1[0].lowByte = 0x07;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xFF;
            dali_command_1[0].lowByte = 0x81;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xFF;
            dali_command_1[0].lowByte = 0x81;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xC7;
            dali_command_1[0].lowByte = high;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);

            dali_command_1[0].highByte = 0xC3;
            dali_command_1[0].lowByte = 0x03;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xA3;
            dali_command_1[0].lowByte = 0x08;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xFF;
            dali_command_1[0].lowByte = 0x81;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xFF;
            dali_command_1[0].lowByte = 0x81;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xC7;
            dali_command_1[0].lowByte = low;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);

            dali_command_1[0].highByte = 0xC3;
            dali_command_1[0].lowByte = 0x03;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xA3;
            dali_command_1[0].lowByte = 0x02;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xFF;
            dali_command_1[0].lowByte = 0x81;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xFF;
            dali_command_1[0].lowByte = 0x81;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            dali_command_1[0].highByte = 0xC7;
            dali_command_1[0].lowByte = 0x00;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);

        }
        public void Check_status()
        {
            int i = 10;
            while (Query_status() == false)
            {
                i--;
                if (i == 0)
                {
                    MessageBox.Show("DELI检测为异常状态", "出错提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
            }

        }
        public bool Query_status()
        {
            Program.delay.Delay1(1);
            dali_command_1[0].highByte = 0xFF;
            dali_command_1[0].lowByte = 0x90;
            atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            Program.delay.Delay1(1);
            if (dali_command_1[0].replyType == 0x01 && (byte)(dali_command_1[0].replyValue & 0x07) == 0x04)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
