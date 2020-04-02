using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ivi.Visa.Interop;
using OsramDaliApi;

namespace AutoTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public class delay
        {
            /*
            * 
            * 延时函数
            * 执行测试时用于延时
            * 设备之间的时间空余
            */
            public static bool Delay2(int delayTime)
            {
                DateTime now = DateTime.Now;
                int s;
                do
                {
                    TimeSpan spand = DateTime.Now - now;
                    s = spand.Seconds;
                    Application.DoEvents();
                }
                while (s < delayTime);
                return true;
            }
            public static void Delay1(int delayTime)
            {
                DateTime now = DateTime.Now;
                int s;
                do
                {
                    TimeSpan spand = DateTime.Now - now;
                    s = spand.Seconds;
                    Application.DoEvents();
                }
                while (s < delayTime);
            }
        }
        /*
        * 
        * Agilent 34401A
        * 包括对Agilent 34401A的基本类
        */
        public class Agilent34401
        {
            /*
             * 
             * 万用表 连接测试方法
             * 用try将连接代码包括起来判断是否正常连接
             */
            public static bool Link(String IOadress22)
            {
                bool conn = false;
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    String AGILENT_34401A = "GPIB0::" + IOadress22 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(AGILENT_34401A, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("*RST", true);
                    myDmm.WriteString("*IDN?", true);
                    Console.WriteLine(myDmm.ReadString()); //report the DMM's identity
                    conn = true;
                    return conn;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    conn = false;
                    return conn;
                }
            }
            /*
             * 
             * 此函数连接Agilent 34401A
             * 输入命令接收仪器返回值
             * 如果失败则捕获异常并返回error字符串
             */
            public static String Comm(String ToMul, String IOadress22)
            {
                String MulRe = "error";
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    String AGILENT_34401A = "GPIB0::" + IOadress22 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(AGILENT_34401A, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("*RST", true);
                    myDmm.WriteString(ToMul, true);
                    MulRe = myDmm.ReadString();
                    Console.WriteLine(MulRe);
                    return MulRe;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    return MulRe;
                }
            }
        }
        /*
       * 
       * WT210
       * 包括对WT210的基本类
       * 1是VIW
       * 2是VPFW
       */
        public class WT210_1
        {
            /*
             * 
             * 连接测试方法
             * 用try将连接代码包括起来判断是否正常连接
             */
            public static bool Link(String IOadress14)
            {
                bool conn = false;
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string WT210 = "GPIB0::" + IOadress14 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(WT210, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("*RST", true);
                    myDmm.WriteString("*IDN?", true);
                    conn = true;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    conn = false;
                }
                return conn;
            }
            /*
             * 
             * WT210一次性读取出三个值
             * 函数已经将读取出的值分开[0][1][2]三个端口测量结果
             */
            public static float[] ReadValue(String IOadress14)
            {
                string[] conn = { "", "", "" };
                float[] rus = new float[3];
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string WT210 = "GPIB0::" + IOadress14 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(WT210, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("MEAS:NORM:VAL?", true);
                    String aa = myDmm.ReadString();
                    conn = aa.Split(',');
                    rus[0] = Convert.ToSingle(conn[0]);
                    rus[1] = Convert.ToSingle(conn[1]);
                    rus[2] = Convert.ToSingle(conn[2]);
                    if (rus[0]>400||rus[1]>10||rus[2]>100)
                    {
                        delay.Delay1(2);
                        myDmm.WriteString("MEAS:NORM:VAL?", true);
                        aa = myDmm.ReadString();
                        conn = aa.Split(',');
                        rus[0] = Convert.ToSingle(conn[0]);
                        rus[1] = Convert.ToSingle(conn[1]);
                        rus[2] = Convert.ToSingle(conn[2]);
                    }
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("WT210读数出错", "出错提示", MessageBoxButtons.OKCancel);
                }
                return rus;
            }
        }
        public class WT210_2
        {
            /*
             * 
             * 连接测试方法
             * 用try将连接代码包括起来判断是否正常连接
             */
            public static bool Link(String IOadress13)
            {
                bool conn = false;
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string WT210 = "GPIB0::" + IOadress13 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(WT210, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("*RST", true);
                    myDmm.WriteString("*IDN?", true);
                    conn = true;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    conn = false;
                }
                return conn;
            }
            /*
             * 
             * WT210一次性读取出三个值
             * 函数已经将读取出的值分开[0][1][2]三个端口测量结果
             */
            public static float[] ReadValue(String IOadress13)
            {
                string[] conn = { "", "", "" };
                float[] rus = new float[3];
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string WT210 = "GPIB0::" + IOadress13 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(WT210, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("MEAS:NORM:VAL?", true);
                    String aa = myDmm.ReadString();
                    conn = aa.Split(',');
                    rus[0] = Convert.ToSingle(conn[0]);
                    rus[1] = Convert.ToSingle(conn[1]);
                    rus[2] = Convert.ToSingle(conn[2]);
                    if (rus[0] > 400 || rus[1] > 10 || rus[2] > 100)
                    {
                        delay.Delay1(2);
                        myDmm.WriteString("MEAS:NORM:VAL?", true);
                        aa = myDmm.ReadString();
                        conn = aa.Split(',');
                        rus[0] = Convert.ToSingle(conn[0]);
                        rus[1] = Convert.ToSingle(conn[1]);
                        rus[2] = Convert.ToSingle(conn[2]);
                    }
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("WT210读数出错", "出错提示", MessageBoxButtons.OKCancel);
                }
                return rus;
            }
            /*
             *
             *设置机器函数
             * 输入设置命令，不需要返回
             */
            public static void SetReadPF(String IOadress13)
            {
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string WT210 = "GPIB0::" + IOadress13 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(WT210, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("*RST", true);
                    myDmm.WriteString("MEAS:NORM:ITEM:A OFF", true);
                    myDmm.WriteString("MEAS:NORM:ITEM:PF ON", true);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("WT210读数出错", "出错提示", MessageBoxButtons.OKCancel);
                }
            }
            public static String[] ReadHramVal(String IOadress13)
            {
                string[] conn = new string[102];
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string WT210 = "GPIB0::" + IOadress13 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(WT210, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("*RST", true);
                    delay.Delay1(1);
                    myDmm.WriteString("HARM:STAT ON", true);
                    delay.Delay1(4);
                    myDmm.WriteString("MEAS:HARM:ITEM:PRES APAT", true);
                    delay.Delay1(3);
                    myDmm.WriteString("MEAS:HARM:VAL? ", true);
                    String aa = myDmm.ReadString();
                    conn = aa.Split(',');
                    myDmm.WriteString("HARM:STAT OFF", true);
                    myDmm.WriteString("MEAS:NORM:ITEM:A OFF", true);
                    myDmm.WriteString("MEAS:NORM:ITEM:PF ON", true);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("WT210读数出错", "出错提示", MessageBoxButtons.OKCancel);
                }
                return conn;
            }
        }
        /*
        * 
        * Agilent 6063B
        * 包括对Agilent 6063B的基本类
        */
        public class Agilent6063B
        {
            /*
             * 
             * 连接测试方法
             * 用try将连接代码包括起来判断是否正常连接
             */
            public static bool Link(String IOadress5)
            {
                bool conn = false;
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string Agilent6063B = "GPIB0::" + IOadress5 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(Agilent6063B, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("*RST", true);
                    myDmm.WriteString("*IDN?", true);
                    conn = true;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    conn = false;
                }
                return conn;
            }
            /*
             * 
             * 设置SOURCE
             * 将需要设置的参数作为输入
             * 简化需要操作的语言
             */
            public static void InitSetCV(String IOadress5)
            {
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string Agilent6063B = "GPIB0::" + IOadress5 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(Agilent6063B, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("INPUT OFF", true);
                    myDmm.WriteString("MODE:VOLT", true);
                    myDmm.WriteString("INPUT ON", true);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("Agilent6063B设置出错", "出错提示", MessageBoxButtons.OKCancel);
                }
            }
            public static void Close(String IOadress5)
            {
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string Agilent6063B = "GPIB0::" + IOadress5 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(Agilent6063B, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("INPUT OFF", true);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("Agilent6063B设置出错", "出错提示", MessageBoxButtons.OKCancel);
                }
            }
            public static void SetCV(String a, String IOadress5)
            {
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string Agilent6063B = "GPIB0::" + IOadress5 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(Agilent6063B, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("VOLT " + a, true);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("Agilent6063B设置出错", "出错提示", MessageBoxButtons.OKCancel);
                }
            }
        }
        /*
        * 
        * Agilent 6812B
        * 包括对Agilent 6812B的基本类
        */
        public class Agilent6812B
        {
            /*
             * 
             * 连接测试方法
             * 用try将连接代码包括起来判断是否正常连接
             */
            //OUTPUT ON
            //OUTPUT OFF
            //VOLT 230
            //FREQ 50
            //OUTP:COUP DC
            public static bool Link(String IOadress12)
            {
                bool conn = false;
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string Agilent6812B = "GPIB0::" + IOadress12 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(Agilent6812B, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("*RST", true);
                    myDmm.WriteString("*IDN?", true);
                    conn = true;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    conn = false;
                }
                return conn;
            }
            public static bool SetPut(String VOLT, String FREQ, String ACDC, String IOadress12)
            {
                bool conn = false;
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string Agilent6812B = "GPIB0::" + IOadress12 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(Agilent6812B, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("VOLT " + VOLT, true);
                    myDmm.WriteString("FREQ " + FREQ, true);
                    myDmm.WriteString("OUTP:COUP " + ACDC, true);
                    myDmm.WriteString("OUTPUT ON", true);
                    conn = true;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    conn = false;
                }
                return conn;
            }
            public static void Close(String IOadress12)
            {
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string Agilent6812B = "GPIB0::" + IOadress12 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(Agilent6812B, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("OUTPUT OFF", true);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                }
            }
            public static bool OFF(String IOadress12)
            {
                bool conn = false;
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string Agilent6812B = "GPIB0::" + IOadress12 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(Agilent6812B, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("OUTPUT ON", true);
                    conn = true;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    conn = false;
                }
                return conn;
            }
        }
        public class DALImagic
        {
            public static bool Link()
            {
                bool a = false;
                OsramDaliInterface b = new OsramDaliInterface();
                b.Init();
                b.ScanForDaliUnitDevices();
                int c = b.GetDaliUnitCount();
                if (c != 0)
                {
                    a = true;
                }
                return a;
            }
            public static void set_level_max()
            {
                OsramDaliInterface atest = new OsramDaliInterface();
                TypeDaliCommand[] dali_command_1 = new TypeDaliCommand[1];
                dali_command_1[0].type = 0x00;
                dali_command_1[0].highByte = 0xFE;
                dali_command_1[0].lowByte = 0xFF;
                dali_command_1[0].thirdByte = 0xFF;
                dali_command_1[0].replyType = 0x01;
                dali_command_1[0].replyValue = 0x01;
                atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
            }
            public static int per_to_hex(String min)
            {
                int lmin = int.Parse(min);
                OsramDaliInterface atest = new OsramDaliInterface();
                TypeDaliCommand[] dali_command_1 = new TypeDaliCommand[1];
                dali_command_1[0].type = 0x00;
                dali_command_1[0].highByte = 0xFE;
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
                dali_command_1[0].highByte = 0xA3;
                dali_command_1[0].lowByte = 0x01;
                atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
                dali_command_1[0].highByte = 0xC1;
                dali_command_1[0].lowByte = 0x06;
                atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
                dali_command_1[0].highByte = 0xFF;
                dali_command_1[0].lowByte = 0xE3;
                atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
                dali_command_1[0].highByte = 0xFF;
                dali_command_1[0].lowByte = 0xE3;
                atest.SendDaliCommandSequenz(0, 0, dali_command_1, 1);
                return (254 * 100) / lmin;
            }
        }
        public class DALIdemo
        {
            OsramDaliInterface atest = new OsramDaliInterface();
            TypeDaliCommand[] dali_command_1 = new TypeDaliCommand[1];
            public bool link()
            {
                bool a = false;
                dali_command_1[0].type = 0x00;
                dali_command_1[0].highByte = 0xFF;
                dali_command_1[0].lowByte = 0xFF;
                dali_command_1[0].thirdByte = 0xFF;
                dali_command_1[0].replyType = 0x01;
                dali_command_1[0].replyValue = 0x01;
                atest.Init();
                atest.ScanForDaliUnitDevices();
                int c = atest.GetDaliUnitCount();
                if (c != 0)
                {
                    a = true;
                }
                return a;
            }
        }
        public class T2700
        {
            public static bool Link(String IOadress16)
            {
                bool conn = false;
                try
                {
                    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
                    Ivi.Visa.Interop.FormattedIO488 myDmm = new Ivi.Visa.Interop.FormattedIO488();
                    string Agilent6812B = "GPIB0::" + IOadress16 + "::INSTR";
                    myDmm.IO = (IMessage)rm.Open(Agilent6812B, AccessMode.NO_LOCK, 2000, "");
                    myDmm.IO.Clear();
                    myDmm.WriteString("*RST", true);
                    myDmm.WriteString("*IDN?", true);
                    conn = true;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    conn = false;
                }
                return conn;
            }
        }
    }

}
