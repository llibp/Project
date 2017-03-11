using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HID;
using System.Globalization;
using System.Diagnostics;
using System.Threading;

namespace WinformProject
{
    public partial class Mdi3USB : Form
    {
        private Hid myHid = new Hid();
        private IntPtr myHidPtr = new IntPtr();

        Byte[] RecDataBuffer = new byte[90];

        public Mdi3USB()
        {
            InitializeComponent();
            myHid.DataReceived += new EventHandler<HID.report>(myhid_DataReceived); //订阅DataRec事件
            myHid.DeviceRemoved += new EventHandler(myhid_DeviceRemoved);
        }

        private void MdiForm3_Load(object sender, EventArgs e)
        {
            stateLabel.Text = "设备未连接";
            this.stateLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            tbxRece.Clear();
        }
        //数据到达事件
        protected void myhid_DataReceived(object sender, report e)
        {
            RecDataBuffer = e.reportBuff;
            string receiveData = new ASCIIEncoding().GetString(RecDataBuffer);

            tbxRece.AppendText(receiveData + "\r\n");


        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "连接设备")
            {
                if (myHid.Opened == false)
                {
                    //获取 ID 号
                    UInt16 myVendorID = Convert.ToUInt16(tbxVendorID.Text, 16);
                    UInt16 myProductID = Convert.ToUInt16(tbxProductID.Text, 16);

                    //myHidPtr = new IntPtr();//定义为类字段

                    if ((int)(myHidPtr = myHid.OpenDevice(myVendorID, myProductID)) != -1)
                    {
                        btnConnect.Text = "断开设备";
                        stateLabel.Text = "设备已连接";
                        stateLabel.BackColor = this.stateLabel.BackColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        stateLabel.Text = "连接失败";
                        stateLabel.BackColor = this.stateLabel.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                btnConnect.Text = "连接设备";
                myHid.CloseDevice(myHidPtr);
                stateLabel.Text = "设备未连接";
                this.stateLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            }
        }



        //设备移除事件
        protected void myhid_DeviceRemoved(object sender, EventArgs e)
        {
            MessageBox.Show("设备意外移除");
            btnConnect.Text = "连接设备";

            myHid.CloseDevice(myHidPtr);
            stateLabel.Text = "设备已关闭";
            this.stateLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxRece.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string str = tbxSend.Text;     //转为字符串了

            Byte[] data = Encoding.Default.GetBytes(str);

            report r = new report(0, data);
            myHid.Write(r);
        }
    }
}
