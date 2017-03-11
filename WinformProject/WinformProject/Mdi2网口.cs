using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformProject
{
    public partial class Mdi2网口 : Form
    {
        public Mdi2网口()
        {
            InitializeComponent();
        }
        bool blnTest = false;
        bool _Result = true;
        private void MdiForm2_Load(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}$");
            bool blnTest = regex.IsMatch(tbxIP.Text);
            if (blnTest == true)
            {
                string[] strTemp = this.tbxIP.Text.Split(new char[] { '.' }); // textBox1.Text.Split(new char[] { '.' });
                for (int i = 0; i < strTemp.Length; i++)
                {
                    if (Convert.ToInt32(strTemp[i]) > 255)
                    { //大于255则提示，不符合IP格式 
                        //MessageBox.Show("不符合IP格式");
                        _Result = false;
                    }
                }
            }
            else
            {
                //输入非数字则提示，不符合IP格式 
                //MessageBox.Show("不符合IP格式");
                _Result = false;
            }
        }


        [System.Runtime.InteropServices.DllImport("user32 ")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);


 //       keybd_event(162, MapVirtualKey(162, 0), 0, 0); //按下CTRL鍵。　　
 //mouse_event(MouseEventFlag.Wheel, 0, 0, 120, UIntPtr.Zero);//滑轮向上滚动
 //keybd_event(162, MapVirtualKey(162, 0), 0x2, 0);//放開CTRL鍵 

    }
}
