using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformProject
{
    public partial class MdiO1_2窗口互调测试 : Form
    {
        
        public MdiO1_2窗口互调测试()
        {
            InitializeComponent();
        }

        //private MdiO1_1窗口互调测试 mdi_1;

        //在"MdiO1_1"方法中 将 "MdiO1_1" 整个窗体作为值传给"MdiO1_2"，所以  "MdiO1_2"  必须含有带 Form1参数的构造函数
        //public MdiO1_2窗口互调测试(MdiO1_1窗口互调测试 mdio1_1)
        //{
        //    InitializeComponent();
            //提取参数
        //    mdi_1 = mdio1_1;
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //mdi_1.Tbx1Change(textBox1.Text);
        }
    }
}
