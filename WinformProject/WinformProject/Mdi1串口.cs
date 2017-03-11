using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using System.IO.Ports;
using System.IO;

namespace WinformProject
{
    enum ShowType
    {
        Normal,
        Simple,
        FullScreen
    }


    public partial class Mdi1串口 : Form
    {
        public uint totalReceBytes = 0;
        public uint totalSendBytes = 0;

        SerialCom comm = new SerialCom();
        ShowType showtype = ShowType.Normal;


        public Mdi1串口()
        {
            InitializeComponent();
        }

        //重绘窗口大小 - 设置接收区大小（跟随窗口尺寸变化而变化）
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AllVisible(true);
            //更新接收区域SIZE大小
            if (showtype == ShowType.Normal)
            {
                //Size sizeTextBox = new System.Drawing.Size();
                //sizeTextBox.Width = 281 + this.Size.Width - 451;
                //sizeTextBox.Height = 228 + this.Size.Height - 400;
                //textBox_Rece.Size = sizeTextBox; 
                textBox_Rece.Location = new Point(153, 6);
                textBox_Rece.Width = 281 + this.Size.Width - 451;
                textBox_Rece.Height = 228 + this.Size.Height - 400;
            }
            else if (showtype == ShowType.Simple)
            {
                textBox_Rece.Location = new Point(153, 6);
                textBox_Rece.Height = this.ClientSize.Height - 12;//this.ClientSize.Height
            }
            else if (showtype == ShowType.FullScreen)
            {
                //Size sizeTextBox = new System.Drawing.Size();
                //sizeTextBox.Width = this.ClientSize.Width;
                //sizeTextBox.Height =this.ClientSize.Height;
                AllVisible(false);
                textBox_Rece.Location = new Point(5, 5);
                textBox_Rece.Width = this.ClientSize.Width - 10;
                textBox_Rece.Height = this.ClientSize.Height - 10;   

            }
            else
            {
            }
        }
        public void InitAll()
        {
            //波特率赋值
            string[] BaudRate = { "1200", "2400", "4800", "9600", "14400", "19200", "38400", "57600", "115200", "128000", "256000" };
            ComboBoxBaudRate.Items.AddRange(BaudRate);
            ComboBoxBaudRate.SelectedIndex = 8;
            //奇偶校验赋值
            string[] Parity = { "无", "奇校验", "偶校验", "SPACE(0)", "MARK(1)" };
            ComboBoxParity.Items.AddRange(Parity);
            ComboBoxParity.SelectedIndex = 0;
            //数据位
            string[] DataBits = { "5位", "6位", "7位", "8位" };
            ComboBoxDataBits.Items.AddRange(DataBits);
            ComboBoxDataBits.SelectedIndex = 3;
            //停止位
            string[] StopBits = { "0位", "1位", "1.5位", "2位" };

            ComboBoxStopBits.Items.AddRange(StopBits);
            ComboBoxStopBits.SelectedIndex = 1;

            comm.serialPort.ReadTimeout = 200;
            comm.serialPort.WriteTimeout = 200;
            //检测可用串口 
            bool ReadyFlag  = CheckAvailablePorts();
            if (ReadyFlag == true)
            {
                comm.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.comm_DataReceived);
            }
            else
            {

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //显示窗口
            this.Visible = true;
            //关闭跨线程调用报错
            Control.CheckForIllegalCrossThreadCalls = false;
            //初始化窗口控件和串口
            InitAll();
            //添加扩展按键程序
            button1.Click += new EventHandler(CheckClick);
            button2.Click += new EventHandler(CheckClick);
            button3.Click += new EventHandler(CheckClick);
            button4.Click += new EventHandler(CheckClick);
            button5.Click += new EventHandler(CheckClick);
            button6.Click += new EventHandler(CheckClick);
            button7.Click += new EventHandler(CheckClick);
            button8.Click += new EventHandler(CheckClick);
            button9.Click += new EventHandler(CheckClick);
            button10.Click += new EventHandler(CheckClick);
            button11.Click += new EventHandler(CheckClick);
            button12.Click += new EventHandler(CheckClick);
            button13.Click += new EventHandler(CheckClick);
            button14.Click += new EventHandler(CheckClick);
            button15.Click += new EventHandler(CheckClick);
        }
        // 检测扩展中按键，具体哪个按下了，以此分别发送不同的任务
        public void CheckClick(object sender, EventArgs e)
        {
            if (comm.IsOpen)
            {
                Button btn = (Button)sender;
                switch (btn.Text)
                {
                    case "1":  ExtendSend(checkBox1.Checked, textBox1); break;
                    case "2":  ExtendSend(checkBox2.Checked, textBox2); break;
                    case "3":  ExtendSend(checkBox3.Checked, textBox3); break;
                    case "4":  ExtendSend(checkBox4.Checked, textBox4); break;
                    case "5":  ExtendSend(checkBox5.Checked, textBox5); break;
                    case "6":  ExtendSend(checkBox6.Checked, textBox6); break;
                    case "7":  ExtendSend(checkBox7.Checked, textBox7); break;
                    case "8":  ExtendSend(checkBox8.Checked, textBox8); break;
                    case "9":  ExtendSend(checkBox9.Checked, textBox9); break;
                    case "10": ExtendSend(checkBox10.Checked, textBox10); break;
                    case "11": ExtendSend(checkBox11.Checked, textBox11); break;
                    case "12": ExtendSend(checkBox12.Checked, textBox12); break;
                    case "13": ExtendSend(checkBox13.Checked, textBox13); break;
                    case "14": ExtendSend(checkBox14.Checked, textBox14); break;
                    case "15": ExtendSend(checkBox15.Checked, textBox15); break;

                    default: break;
                }
            }
        }
        void ExtendSend(bool HexFlag, TextBox tbx)
        {
            if(tbx.Text != "")
            {
                byte[] buffer;
                string str = tbx.Text;
                if (HexFlag == true)
                {
                    buffer = new byte[(str.Length % 2 == 0) ? (str.Length / 2) : (str.Length / 2 + 1)];
                    String2Hex(str, ref buffer); //转为16进制输出
                }
                else
                {
                    //发送新行
                    if (checkBoxSendNewline.Checked == true)
                    {
                        str += "\r\n";
                    }
                    buffer = Encoding.GetEncoding("GBK").GetBytes(str);
                }

                comm.WritePort(buffer, 0, buffer.Length);

                //更新发送字节数
                totalSendBytes += (uint)buffer.Length;
                labelSendNum.Text = "S:" + totalSendBytes.ToString();
            }
        }

        //打开/关闭串口
        public void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnOpen.Text == "打开串口")
                {
                    //串口名
                    comm.serialPort.PortName = ComboBoxPortName.SelectedItem.ToString();
                    //波特率
                    comm.serialPort.BaudRate = Convert.ToInt32(ComboBoxBaudRate.SelectedItem);
                    //奇偶校验位
                    switch(ComboBoxParity.SelectedIndex)
                    {
                        case 0: comm.serialPort.Parity = System.IO.Ports.Parity.None;  break;
                        case 1: comm.serialPort.Parity = System.IO.Ports.Parity.Even;  break;
                        case 2: comm.serialPort.Parity = System.IO.Ports.Parity.Odd;   break;
                        case 3: comm.serialPort.Parity = System.IO.Ports.Parity.Space; break;
                        case 4: comm.serialPort.Parity = System.IO.Ports.Parity.Mark;  break; 
                        default: comm.serialPort.Parity = System.IO.Ports.Parity.None; break;
                    }
                    //数据位comm.serialPort.DataBits
                    switch(ComboBoxDataBits.SelectedIndex)
                    {
                        case 0: comm.serialPort.DataBits = 5; break;
                        case 1: comm.serialPort.DataBits = 6; break;
                        case 2: comm.serialPort.DataBits = 7; break;
                        case 3: comm.serialPort.DataBits = 8; break;
                        default: comm.serialPort.DataBits = 8; break; 
                    }
                    switch (ComboBoxStopBits.SelectedIndex)
                    {
                        case 0: comm.serialPort.StopBits = System.IO.Ports.StopBits.None; break;
                        case 1: comm.serialPort.StopBits = System.IO.Ports.StopBits.One; break;
                        case 2: comm.serialPort.StopBits = System.IO.Ports.StopBits.OnePointFive; break;
                        case 3: comm.serialPort.StopBits = System.IO.Ports.StopBits.Two; break;
                        default: comm.serialPort.StopBits = System.IO.Ports.StopBits.One; break;
                    }              
                    comm.serialPort.ReadTimeout = 100;
                    comm.serialPort.WriteTimeout = -1;

                    ComboBoxPortName.Enabled = false;
                    ComboBoxBaudRate.Enabled = false;
                    ComboBoxDataBits.Enabled = false;
                    ComboBoxStopBits.Enabled = false;
                    ComboBoxParity.Enabled = false;

                    comm.Open();
                    btnOpen.Text = "关闭串口";
                }
                else
                {
                    comm.Close();
                    ////清除接收字节数
                    //totalReceBytes = 0;
                    //labelReceNum.Text = "R:0";
                    ////清除发送字节数
                    //totalSendBytes = 0;
                    //labelSendNum.Text = "S:0";

                    btnOpen.Text = "打开串口";
                    ComboBoxPortName.Enabled = true;
                    ComboBoxBaudRate.Enabled = true;
                    ComboBoxDataBits.Enabled = true;
                    ComboBoxStopBits.Enabled = true;
                    ComboBoxParity.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                comm.Close();
                btnOpen.Text = "打开串口";
                ComboBoxPortName.Enabled = true;
                ComboBoxBaudRate.Enabled = true;
                ComboBoxDataBits.Enabled = true;
                ComboBoxStopBits.Enabled = true;
                ComboBoxParity.Enabled = true;
            }
        }
        //发送数据
        private void btnSend_Click(object sender, EventArgs e)
        {
            
            if (comm.IsOpen)
            {
                byte[] buffer;
                string str = textBox_Send.Text;
                if(checkBoxSend.Checked == true)
                {
                    buffer = new byte[(str.Length % 2 == 0) ? (str.Length / 2) : (str.Length/2+1)];
                    String2Hex(str, ref buffer); //转为16进制输出
                }   
                else
                {                 
                    if (checkBoxSendNewline.Checked == true)
                    {
                        str += "\r\n";
                    }
                    buffer = Encoding.GetEncoding("GBK").GetBytes(str);
                }            

                comm.WritePort(buffer, 0, buffer.Length);
                //更新发送字节数
                totalSendBytes += (uint)buffer.Length;
                labelSendNum.Text = "S:" + totalSendBytes.ToString();
            }
        }
        //接收数据
        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;//sp 其实就是 comm.serialPort
            if (sp.IsOpen)
            {
                int count = sp.BytesToRead;
                if (count > 0)
                {
                    byte[] readBuffer = new byte[count];
                    //更新接收字节数
                    totalReceBytes += (uint)count;
                    labelReceNum.Text = "R:" + totalReceBytes.ToString();


                    try
                    {
                        Application.DoEvents();//实时响应文本框中的值
                        sp.Read(readBuffer, 0, count);
                    }
                    catch (TimeoutException)
                    {

                    }
                    //HEX接收
                    if (checkBoxRece.Checked == true)
                    {
                        for (int i = 0; i < readBuffer.Length; i++)
                        {
                            textBox_Rece.AppendText(readBuffer[i].ToString("X2"));//16进制
                        }
                    }
                    //字符接收
                    else
                    {
                        byte[] buffer = readBuffer;
                        if (checkBoxReceNewline.Checked == true)
                        {
                            textBox_Rece.AppendText(Encoding.GetEncoding("GBK").GetString(buffer) + "\r\n");
                        }
                        else
                        {
                            textBox_Rece.AppendText(Encoding.GetEncoding("GBK").GetString(buffer));
                        }
                    }

                }
            }


            //if (comm.serialPort.IsOpen)
            //{
            //    int count = comm.serialPort.BytesToRead;
            //    if (count > 0)
            //    {
            //        byte[] readBuffer = new byte[count];
            //        try
            //        {
            //            Application.DoEvents();
            //            comm.serialPort.Read(readBuffer, 0, count);
            //        }
            //        catch (TimeoutException)
            //        {
            //        }
            //        if (checkBoxRece.Checked == true)
            //        {
            //            for (int i = 0; i < readBuffer.Length; i++)
            //            {
            //                textBox_Rece.AppendText(readBuffer[i].ToString("X2"));//16进制
            //            }
            //        }
            //        else
            //        {
            //            byte[] buffer = readBuffer;
            //            if (checkBoxReceNewline.Checked == true)
            //            {
            //                textBox_Rece.AppendText(Encoding.GetEncoding("GBK").GetString(buffer) + "\r\n");
            //            }
            //            else
            //            {
            //                textBox_Rece.AppendText(Encoding.GetEncoding("GBK").GetString(buffer));
            //            }
            //        }

            //    }
            //}
        }
        // 获取可用的端口名，并添加到选择框中，同时设置相关
        public bool CheckAvailablePorts()
        {
            bool flag = false;

            ComboBoxPortName.Items.Clear();
            string[] allAvailablePorts = SerialPort.GetPortNames();
            Array.Sort(allAvailablePorts);
            //判断是否有可用的端口
            if (allAvailablePorts.Length > 0)
            {
                flag = true;
                //使能控件portNamesComboBox，openOrCloseButton
                //openOrClosePortButton.Enabled = true;
                ComboBoxPortName.Enabled = true;
                //添加检测到全部的串口
                //ComboBoxPortName.Items.AddRange(allAvailablePorts);

                //添加可以打开的串口
                for (int i = 0; i < allAvailablePorts.Length;i++ )
                {
                    comm.serialPort.PortName = allAvailablePorts[i];
                    try
                    {
                        comm.serialPort.Open();
                    }
                    catch { }
                    if(comm.serialPort.IsOpen)
                    {
                        ComboBoxPortName.Items.Add(allAvailablePorts[i]);
                        comm.serialPort.Close();
                    }
                }

                if (ComboBoxPortName.Items.Count>0)
                {
                    //添加一个重新检测串口
                    ComboBoxPortName.Items.Add("检测串口");
                    //默认选中第一个项
                    ComboBoxPortName.SelectedIndex = 0;
                    btnOpen.Enabled = true ;
                }
                else
                {
                    ComboBoxPortName.Items.Clear();
                    //ComboBoxPortName.Enabled = false;
                    ComboBoxPortName.Items.Add("检测串口");
                    btnOpen.Enabled = false;

                    MessageBox.Show("没有可用的串口","提示");
                }

            }
            else
            {
                ComboBoxPortName.Items.Clear();
                //ComboBoxPortName.Enabled = false;
                ComboBoxPortName.Items.Add("检测串口");
                btnOpen.Enabled = false;
                MessageBox.Show("没有可用的串口", "提示");
            }
            return flag;
        }
        // 弹出扩展窗口（原本想设置为退出按钮 Environment.Exit(0)）
        private void btnEixt_Click(object sender, EventArgs e)
        {
            Application.DoEvents();//实时响应文本框中的值
            全屏ToolStripMenuItem.Enabled = false;//接收框全屏模式失效
            checkBoxTimeSend.Checked = false;//关闭主页的定时发送
            timerAutoSend.Enabled = false;
            panelExtend.Visible = true;//显示扩展面板

            showtype = ShowType.Simple;//扩展自动进入简洁模式
            textBox_Rece.Location = new Point(153, 6);
            textBox_Rece.Height = this.ClientSize.Height - 12;//this.ClientSize.Height
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose(true);
        }
        private void buttonTool_Click(object sender, EventArgs e)
        {
        }

        private void trackBarTrans_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = (float)((float)(100 - trackBarTrans.Value) / 100); //透明度
        }

        private void buttonCleanR_Click(object sender, EventArgs e)
        {
            //清除接收字节数
            textBox_Rece.Text = "";
            totalReceBytes = 0;
            labelReceNum.Text = "R:0";
        }
        private void buttonCleanS_Click(object sender, EventArgs e)
        {
            //清除发送字节数
            textBox_Send.Text = "";
            totalSendBytes = 0;
            labelSendNum.Text = "S:0";
        }
        private void 接收内容导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存接收内容到……";
            sfd.InitialDirectory = @"C:\Users\";
            sfd.Filter = "文本文件|*.txt|.c文件|*.c|.cpp文件|*.cpp|.h文件|*.h|.cs文件|*.cs|.java文件|*.java|所有文件|*.*";
            sfd.ShowDialog();
            string path = sfd.FileName;
            if (path == "") return;
            using (FileStream fs_w = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = Encoding.Default.GetBytes( textBox_Rece.Text);
                fs_w.Write(buffer, 0, buffer.Length);
            }
        }
        private void 导入文本文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开文档………（TXT）";
            ofd.InitialDirectory = @"C:\Users\";
            ofd.Filter = "文本文件|*.txt|.c文件|*.c|.cpp文件|*.cpp|.h文件|*.h|.cs文件|*.cs|.java文件|*.java|所有文件|*.*";
            ofd.ShowDialog();
            string path = ofd.FileName;
            if (path == "")return;
            using (FileStream fs_r = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                while (true)
                {
                    int num = fs_r.Read(buffer, 0, buffer.Length);
                    if (num == 0)
                    {
                        break;
                    }
                    string s = Encoding.Default.GetString(buffer);
                    textBox_Send.AppendText(s);
                }
            }
        }
        //清除接收字节数
        private void 清空接收区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Rece.Text = "";
            totalReceBytes = 0;
            labelReceNum.Text = "R:0";

        }
        //bool FullScreenFlag = false;
        private void 全屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(showtype != ShowType.FullScreen)
            {
                showtype = ShowType.FullScreen;
                全屏ToolStripMenuItem.Text = "退出全屏";
                AllVisible(false);
                textBox_Rece.Location = new Point(5, 5);
                textBox_Rece.Width = this.ClientSize.Width - 10;
                textBox_Rece.Height = this.ClientSize.Height - 10;         
            }
            else
            {
                全屏ToolStripMenuItem.Text = "全屏";
                if(checkBoxSimple.Checked)
                {
                    showtype = ShowType.Simple;
                    AllVisible(true);
                    //接收文本框高度等于 窗口客户区高度
                    textBox_Rece.Location = new Point(153, 6);
                    textBox_Rece.Height = this.ClientSize.Height - 12;//this.ClientSize.Height
                }
                else
                {
                    showtype = ShowType.Normal;
                    textBox_Rece.Location = new Point(153, 6);
                    textBox_Rece.Width = 281 + this.Size.Width - 451;
                    textBox_Rece.Height = 228 + this.Size.Height - 400;
                    AllVisible(true);
                }
            }


            //if (FullScreenFlag == false)
            //{
            //    FullScreenFlag = true;
            //    全屏ToolStripMenuItem.Text = "退出全屏";
            //    //Size sizeTextBox = new System.Drawing.Size();
            //    //sizeTextBox.Width = this.ClientSize.Width;
            //    //sizeTextBox.Height =this.ClientSize.Height;
            //    AllVisible(false);
            //    textBox_Rece.Location = new Point(5, 5);
            //    textBox_Rece.Width = this.ClientSize.Width-10;
            //    textBox_Rece.Height = this.ClientSize.Height-10;             
            //}
            //else
            //{
            //    FullScreenFlag = false;
            //    全屏ToolStripMenuItem.Text = "全屏";
            //    //textBox_Rece.PointToClient(new Point(153, 6));
            //    textBox_Rece.Location = new Point(153, 6);
            //    textBox_Rece.Width = 281 + this.Size.Width - 451;
            //    textBox_Rece.Height = 228 + this.Size.Height - 400;
            //    AllVisible(true);
            //}
        }
        public void AllVisible(bool flag)
        {
            label1.Visible = flag; label2.Visible = flag; label3.Visible = flag;
            label4.Visible = flag; label5.Visible = flag; label6.Visible = flag;
            label7.Visible = flag;
            ComboBoxBaudRate.Visible = flag;
            ComboBoxDataBits.Visible = flag;
            ComboBoxPortName.Visible = flag;
            ComboBoxStopBits.Visible = flag;
            ComboBoxParity.Visible = flag;
            checkBoxRece.Visible = flag; checkBoxReceNewline.Visible = flag;
            checkBoxSend.Visible = flag; checkBoxSendNewline.Visible = flag;
            checkBoxSimple.Visible = flag; checkBoxTimeSend.Visible = flag;
            checkBoxTop.Visible = flag;
            btnExtend.Visible = flag;
            btnOpen.Visible = flag;
            btnSend.Visible = flag;
            buttonCleanR.Visible = flag;
            buttonCleanS.Visible = flag;
            buttonTool.Visible = flag;
            textBoxTime.Visible = flag;
            trackBarTrans.Visible = flag;
            textBox_Send.Visible = flag;
            labelReceNum.Visible = flag;
            labelSendNum.Visible = flag;
        }
        private void 清空发送区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Send.Text = "";
            //清除发送字节数
            totalSendBytes = 0;
            labelSendNum.Text = "S:0";
        }
        // 发送框右键菜单粘贴功能 -- 还未处理完善 --- 暂时隐藏掉没用
        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // GetDataObject检索当前剪贴板上的数据
            IDataObject iData = Clipboard.GetDataObject();
            // 将数据与指定的格式进行匹配，返回bool
            if (iData.GetDataPresent(DataFormats.Text))
            {
                // GetData检索数据并指定一个格式
                //if (this.textBox_Send.SelectedText != "")
                //{
                //    this.textBox_Send.Text.Replace(this.textBox_Send.SelectedText, (string)iData.GetData(DataFormats.Text));
                //}
                //else
                //{
                //    this.textBox_Send.Text.Insert(, (string)iData.GetData(DataFormats.Text));
                //}
                //string[] str = this.textBox_Send.Text.Split(new string[]{ this.textBox_Send.SelectedText},StringSplitOptions.RemoveEmptyEntries);
                //if (this.textBox_Send.Text.StartsWith((string)iData.GetData(DataFormats.Text)))
                //{
                //    this.textBox_Send.Text = (string)iData.GetData(DataFormats.Text) + str[0];
                //}
                //else if (this.textBox_Send.Text.EndsWith((string)iData.GetData(DataFormats.Text)))
                //{
                //    this.textBox_Send.Text = str[0] + ((string)iData.GetData(DataFormats.Text));
                //}
                //else if (this.textBox_Send.Text.Contains((string)iData.GetData(DataFormats.Text)))
                //{
                //    this.textBox_Send.Text = str[0] + ((string)iData.GetData(DataFormats.Text)) + str[1]; 
                //}
                //else
                //{
                    this.textBox_Send.Text = (string)iData.GetData(DataFormats.Text);
                //}
            }
            else
            {
                MessageBox.Show("剪贴板中数据不可转换为文本", "错误");
            }
        }

        // 发送框右键菜单复制功能
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Takes the selected text from a text box and puts it on the clipboard.
            if (textBox_Send.SelectedText != "")
                Clipboard.SetDataObject(textBox_Send.SelectedText);
        }
        // 鼠标左键弹出工具箱菜单
        private void buttonTool_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                contextMenuStrip3.Show((Button)sender, new Point(e.X, e.Y));
            }
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            //Info.FileName = "calc.exe ";
            //System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            //Info.FileName = "notepad.exe ";
            //System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            System.Diagnostics.Process.Start("notepad.exe");
        }
        private void 设备管理器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("devmgmt.msc");
        }

        //再次检测串口
        private void ComboBoxPortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboBoxPortName.SelectedIndex == ComboBoxPortName.Items.Count-1)
            {
                CheckAvailablePorts();
            }
        }
        private void checkBoxTop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTop.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
        private void checkBoxSimple_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSimple.Checked == true)
            {
                //textBox_Rece.Text = textBox_Send.Size.Width + "..." + textBox_Send.Size.Height;
                showtype = ShowType.Simple;
                textBox_Rece.Height = this.ClientSize.Height - 12;
                //textBox_Rece.Text = textBox_Rece.Location.X + "---" + textBox_Rece.Location.Y;//153---6
            }
            else
            {
                showtype = ShowType.Normal;
                //sizeTextBox.Width = 281 + this.Size.Width - 451;
                textBox_Rece.Height = 228 + this.Size.Height - 400;
            }
        }
        // 自动发送开关
        private void checkBoxTimeSend_CheckedChanged(object sender, EventArgs e)
        {        
            if(checkBoxTimeSend.Checked == true)
            {
                if (comm.serialPort.IsOpen == false)
                {
                    checkBoxTimeSend.Checked = false;
                    MessageBox.Show("当前串口未打开", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(textBox_Send.Text !="")
                {
                    //使扩展自动发送失效
                    checkBoxCycleSend.Checked = false;
                    timerCycleSend.Enabled = false;                    
                    
                    int num;
                    if (int.TryParse(textBoxTime.Text, out num) == true)
                    {
                        if (num < 10)
                        {
                            num = 10;
                            textBoxTime.Text = "10";
                        }
                        timerAutoSend.Interval = num;
                        timerAutoSend.Enabled = true;
                        textBoxTime.Enabled = false;//将定时发送时间选项失效，避免自动发送过程中，更改时间错误（输入字符之类的）
                        //btnSend.Enabled = false;//使打开/关闭串口按键失效
                        buttonCleanS.Enabled = false;//清除发送区按键失效
                        清空发送区ToolStripMenuItem.Enabled = false;//清除发送区菜单选项失效
                    }
                    else
                    {
                        textBoxTime.Text = "100";
                        timerAutoSend.Interval = 100;
                        checkBoxTimeSend.Checked = false;
                        textBoxTime.Enabled = true;//将定时发送时间选项使能
                        MessageBox.Show("请勿输入数字以外字符", "警告",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    checkBoxTimeSend.Checked = false;
                    timerAutoSend.Enabled = false;
                    textBoxTime.Enabled = true;//将定时发送时间选项使能
                    MessageBox.Show("发送内容不能为空", "警告",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                timerAutoSend.Enabled = false;
                textBoxTime.Enabled = true; //将定时发送时间选项使能
                //btnSend.Enabled = true;
                buttonCleanS.Enabled = true;//清除发送区按键使能
                清空发送区ToolStripMenuItem.Enabled = true;//清除发送区菜单选项使能

            }
        
        }
        // 自动发送定时器
        private void timerAutoSend_Tick(object sender, EventArgs e)
        {
            if (comm.IsOpen)
            {
                if(textBox_Send.Text == "")
                {
                    checkBoxTimeSend.Checked = false;
                    timerAutoSend.Enabled = false;
                    //MessageBox.Show("发送内容不能为空", "警告",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                byte[] buffer;
                string str = textBox_Send.Text;
                if (checkBoxSend.Checked == true)
                {
                    buffer = new byte[(str.Length % 2 == 0) ? (str.Length / 2) : (str.Length / 2 + 1)];
                    String2Hex(str, ref buffer); //转为16进制输出
                }
                else
                {
                    //发送新行
                    if (checkBoxSendNewline.Checked == true)
                    {
                        str += "\r\n";
                    }
                    buffer = Encoding.GetEncoding("GBK").GetBytes(str);
                }
                comm.WritePort(buffer, 0, buffer.Length);
                //更新发送字节数
                totalSendBytes += (uint)buffer.Length;
                labelSendNum.Text = "S:" + totalSendBytes.ToString();
            }
        }

        // 实时同步定时器发送的时间
        private void textBoxTime_TextChanged(object sender, EventArgs e)
        {
            //int num;
            //if (int.TryParse(textBoxTime.Text, out num) == true)
            //{
            //    if (num < 10) num = 0;
            //    timerAutoSend.Interval = num;
            //}
            //else
            //{
            //    textBoxTime.Text = "100";
            //    timerAutoSend.Interval = 100;
            //    MessageBox.Show("请勿输入数字以外字符", "警告",
            //           MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        private void Form1_MaximumSizeChanged(object sender, EventArgs e)
        {
        }
        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
        }
        private void checkBoxRece_CheckedChanged(object sender, EventArgs e)
        {
            //HEX模式关闭 接收新行
            if(checkBoxRece.Checked)
            {
                checkBoxReceNewline.Enabled = false;
            }
            else
            {
                checkBoxReceNewline.Enabled = true;
            }
        }

        private void checkBoxSend_CheckedChanged(object sender, EventArgs e)
        {
            //HEX模式关闭 发送新行
            if (checkBoxSend.Checked)
            {
                checkBoxSendNewline.Enabled = false;
            }
            else
            {
                checkBoxSendNewline.Enabled = true;
            }
        }



        public void String2Hex(String str, ref Byte[] senddata)
        {
            int hexdata, lowhexdata;
            int hexdatalen = 0;
            int len = str.Length;

            for (int i = 0; i < len; )
            {
                byte lstr, hstr = (byte)str[i];
                if (hstr == ' ')
                {
                    i++;
                    continue;
                }
                i++;
                if (i >= len)
                    break;
                lstr = (byte)str[i];
                hexdata = ConvertHexChar(hstr);
                lowhexdata = ConvertHexChar(lstr);
                if ((hexdata == 16) || (lowhexdata == 16))
                    break;
                else
                    hexdata = hexdata * 16 + lowhexdata;
                i++;
                senddata[hexdatalen] = (byte)hexdata;
                hexdatalen++;
            }
        }

        public byte ConvertHexChar(byte ch)
        {
            if ((ch >= '0') && (ch <= '9'))
                return (byte)(ch - 0x30);
            else if ((ch >= 'A') && (ch <= 'F'))
                return (byte)(ch - 'A' + 10);
            else if ((ch >= 'a') && (ch <= 'f'))
                return (byte)(ch - 'a' + 10);
            else return 0;
        }

        private void btnCloseExtend_Click(object sender, EventArgs e)
        {
            Application.DoEvents();//实时响应文本框中的值
            全屏ToolStripMenuItem.Enabled = true;//接收框全屏模式恢复
            checkBoxCycleSend.Checked = false;//关闭扩展的定时循环发送
            timerCycleSend.Enabled = false;
            panelExtend.Visible = false;//隐藏扩展界面
            if (checkBoxSimple.Checked == true)
            {
                showtype = ShowType.Simple;
                textBox_Rece.Location = new Point(153, 6);
                textBox_Rece.Height = this.ClientSize.Height - 12;//this.ClientSize.Height
            }
            else
            {
                showtype = ShowType.Normal;
                textBox_Rece.Location = new Point(153, 6);
                textBox_Rece.Width = 281 + this.Size.Width - 451;
                textBox_Rece.Height = 228 + this.Size.Height - 400;
            }
        }
        //清除接收字节数
        private void labelReceNum_DoubleClick(object sender, EventArgs e)
        {
            totalReceBytes = 0;
            labelReceNum.Text = "R:0";
        }
        //清除发送字节数
        private void labelSendNum_DoubleClick(object sender, EventArgs e)
        {
            totalSendBytes = 0;
            labelSendNum.Text = "S:0";
        }
        private void textBoxExtendTime_TextChanged(object sender, EventArgs e)
        {
        }

        private void checkBoxCycleSend_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxCycleSend.Checked)
            {
                if (comm.serialPort.IsOpen == false)
                {
                    MessageBox.Show("当前串口未打开", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBoxCycleSend.Checked = false;
                    return;
                }
                //扩展发送文本框不能全为空
                if (ExtendTextBoxCheck())
                {
                    checkBoxTimeSend.Checked = false;//关闭主页自动定时发送
                    timerAutoSend.Enabled = false;

                    int num;
                    if (int.TryParse(textBoxExtendTime.Text, out num) == true)
                    {
                        if (num < 10)
                        {
                            num = 10;
                            textBoxExtendTime.Text = "10";
                        }
                        timerCycleSend.Interval = num;//设置循环时间
                        timerCycleSend.Enabled = true;//使能扩展自动循环发送wth
                        textBoxExtendTime.Enabled = false;//将定时发送时间选项失效，避免自动发送过程中，更改时间错误（输入字符之类的）
                    }
                    else
                    {
                        textBoxExtendTime.Enabled = true;//将定时发送时间选项使能
                        checkBoxCycleSend.Checked = false;//输入时间有误，清除自动发送选项
                        timerCycleSend.Interval = 100;
                        textBoxExtendTime.Text = "100";
                        MessageBox.Show("请勿输入数字以外字符", "警告",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    textBoxExtendTime.Enabled = true;//将定时发送时间选项使能
                    checkBoxCycleSend.Checked = false;
                    MessageBox.Show("扩展发送栏不能全为空", "提示", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                textBoxExtendTime.Enabled = true;//将定时发送时间选项使能
                timerCycleSend.Enabled = false;//关闭扩展自动循环发送
            }
        }
        public bool ExtendTextBoxCheck()
        {
            if (textBox1.Text +textBox1.Text +
                textBox3.Text +textBox4.Text +
                textBox5.Text +textBox6.Text +
                textBox7.Text +textBox8.Text +
                textBox9.Text +textBox10.Text +
                textBox11.Text +textBox12.Text +
                textBox13.Text +textBox14.Text +
                textBox15.Text  == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static int SNum = 1;
        private void timerCycleSend_Tick(object sender, EventArgs e)
        {
            if (ExtendTextBoxCheck() == false)
            {
                checkBoxCycleSend.Checked = false;//清除单选框
                textBoxExtendTime.Enabled = true;//将定时发送时间选项使能
                timerCycleSend.Enabled = false;//关闭扩展自动循环发送
                return;
            }           
            if (comm.IsOpen)
            {
                string str = "";
                while(true)
                {
                    switch (SNum)
                    {
                        case 1: str = textBox1.Text; ExtendSend(checkBox1.Checked, textBox1); break;
                        case 2: str = textBox2.Text; ExtendSend(checkBox2.Checked, textBox2); break;
                        case 3: str = textBox3.Text; ExtendSend(checkBox3.Checked, textBox3); break;
                        case 4: str = textBox4.Text; ExtendSend(checkBox4.Checked, textBox4); break;
                        case 5: str = textBox5.Text; ExtendSend(checkBox5.Checked, textBox5); break;
                        case 6: str = textBox6.Text; ExtendSend(checkBox6.Checked, textBox6); break;
                        case 7: str = textBox7.Text; ExtendSend(checkBox7.Checked, textBox7); break;
                        case 8: str = textBox8.Text; ExtendSend(checkBox8.Checked, textBox8); break;
                        case 9: str = textBox9.Text; ExtendSend(checkBox9.Checked, textBox9); break;
                        case 10: str = textBox10.Text; ExtendSend(checkBox10.Checked, textBox10); break;
                        case 11: str = textBox11.Text; ExtendSend(checkBox11.Checked, textBox11); break;
                        case 12: str = textBox12.Text; ExtendSend(checkBox12.Checked, textBox12); break;
                        case 13: str = textBox13.Text; ExtendSend(checkBox13.Checked, textBox13); break;
                        case 14: str = textBox14.Text; ExtendSend(checkBox14.Checked, textBox14); break;
                        case 15: str = textBox15.Text; ExtendSend(checkBox15.Checked, textBox15); break;

                        default: break;
                    }
                    SNum++;
                    if(SNum == 16)  SNum = 1;
                    if (str != "")  break;
                    else continue;               
                }
            }
        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mdi1串口_帮助 fhelp = new Mdi1串口_帮助();
            fhelp.Location = new Point(this.Location.X+60,this.Location.Y+10);
            //fhelp.Visible = true;
            fhelp.ShowDialog();
        }
    }
}
