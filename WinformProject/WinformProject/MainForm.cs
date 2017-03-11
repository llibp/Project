using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformProject
{
    public partial class MainForm : Form
    {
        //Socket通信对象
        ScketSearve sck = new ScketSearve();
        public void SocketTransmit(string str)
        {
            //textBoxSocket.AppendText(str + "\r\n");
        }
        public void SocketSendMes(string str)
        {
            //如果客户端还未连接 或者  客户端断开，都不发送
            if (sck.socketSend != null && (ScketSearve.IsSocketConnected(sck.socketSend) == true))
            {
                sck.SocektSend(str);
            }
        }
        public  MainForm()
        {
            InitializeComponent();
            //关闭跨线程调用报错
            Control.CheckForIllegalCrossThreadCalls = false;

            sck.StartMonitor();
            sck.DataTransmit += new ScketSearve.Transmit(SocketTransmit);       
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //注意：设置属性
            //必须：MainForm 窗口属性中 Icon 中 IsMdiContainer 设置为 True

            //设置当前窗体为 MdiForm 的父窗体
            Mdi1串口 mf1 = new Mdi1串口();
            Mdi2网口 mf2 = new Mdi2网口();
            Mdi3USB mf3 = new Mdi3USB();
            Mdi4记事本 mf4 = new Mdi4记事本();
            mf1.MdiParent = this;
            mf2.MdiParent = this;
            mf3.MdiParent = this;
            mf4.MdiParent = this;
            mf1.Show();
            mf2.Show();
            mf3.Show();
            mf4.Show();

            LayoutMdi(MdiLayout.TileVertical);//纵向排序
        }

        private void 横向ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 纵向ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void 排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
            //LayoutMdi(MdiLayout.ArrangeIcons);
        }



        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mdi1串口 mf1 = new Mdi1串口();
            mf1.MdiParent = this;
            mf1.Show();
        }
        private void 网口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mdi2网口 mf2 = new Mdi2网口();
            mf2.MdiParent = this;
            mf2.Show();
        }
        private void uSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mdi3USB mf3 = new Mdi3USB();
            mf3.MdiParent = this;
            mf3.Show();
        }
        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mdi4记事本 mf4 = new Mdi4记事本();
            mf4.MdiParent = this;
            mf4.Show();
        }
        private void 图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mdi5图片 mf5 = new Mdi5图片();
            mf5.Parent = this;
            mf5.Show();
        }
        private void 音乐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mdi6音乐 mf6 = new Mdi6音乐();
            mf6.Parent = this;
            mf6.Show();
        }
        private void 视频ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mdi7视频 mf7 = new Mdi7视频();
            mf7.Parent = this;
            mf7.Show();
        }


            //Mdi7视频 mf7 = new Mdi7视频();
            //mf7.Parent = this;
            //mf7.Show();
            //MdiO1_1窗口互调测试 mfo1_1 = new MdiO1_1窗口互调测试();
            ////mfo1_1.Parent = this;
            //mfo1_1.Show();

    }
}
