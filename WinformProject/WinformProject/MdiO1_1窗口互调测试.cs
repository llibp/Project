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
    public partial class MdiO1_1窗口互调测试 : Form
    {
        public MdiO1_1窗口互调测试()
        {
            InitializeComponent();
        }

        /*
            本次实验的目的：3种方法 实现两个窗口直接的 控制 和 传参            
        */


        //方法1:将整个窗体作为值传给Form2
        private void btnMethod_1_Click(object sender, EventArgs e)
        {
            //将 "MdiO1_1" 整个窗体作为值传给"MdiO1_2"，所以  "MdiO1_2"  必须含有带 Form1参数的构造函数
            //MdiO1_2窗口互调测试 MdiO1_2 = new MdiO1_2窗口互调测试(this);
            //MdiO1_2.Parent = Program.mainForm;
            //MdiO1_2.ShowDialog();
        }
        public void Tbx1Change(string str)
        {
            textBox1.Text = str;
        }






        //方法2:将整个窗体作为值传给Form2
        private void btnMethod_2_Click(object sender, EventArgs e)
        {

        }
        //方法3:将整个窗体作为值传给Form2
        private void btnMethod_3_Click(object sender, EventArgs e)
        {

        }
    }
}
