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
    public partial class Mdi1串口_帮助 : Form
    {
        public Mdi1串口_帮助()
        {
            InitializeComponent();
        }
        private void MdiForm1_Help_Load(object sender, EventArgs e)
        {
            textBoxHelp.Select(textBoxHelp.TextLength, 0);
        }

        private void pictureBoxHelp_DoubleClick(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }
    }
}
