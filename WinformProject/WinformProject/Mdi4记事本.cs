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
    public partial class Mdi4记事本 : Form
    {
        //保存文件列表路径的list
        List<string> TxtPathList = new List<string>();
        //当前打开的是list第几个文档 索引从0开始 ， 主要用于保存当前文件时候，找到正确的保存对象 路径
        private int Index = 0;


        public Mdi4记事本()
        {
            InitializeComponent();
        }
        //等待获取默认长宽的变量
        int FontDefaultWidth = 0;
        int FontDefaultHeight = 0;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //重新规划tbxTxt的尺寸
            tbxTxt.Width = 210/*tbxTxt.DefaultWidth*/ + this.Size.Width - FontDefaultWidth;
            tbxTxt.Height = 210/*tbxTxt.DefaultWidth*/ + this.Size.Height - FontDefaultHeight;
            //重新规划按键位置
            btnOpen.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnOpen.Location.Y);
            btnSaveOther.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnSaveOther.Location.Y);
            btnSave.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnSave.Location.Y);
            btnFont.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnFont.Location.Y);
            btnColor.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnColor.Location.Y);
            btnRemove.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnRemove.Location.Y);
            btnDelete.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnDelete.Location.Y);
            //重新规划list 的高度
            lbxTxt.Height = 208/*lbxTxt.DefaultHeight*/+ this.Size.Height - FontDefaultHeight;
        }

        private void MdiForm4_Load(object sender, EventArgs e)
        {
            //获取默认长宽
            FontDefaultWidth = this.Width = 377;
            FontDefaultHeight = this.Height =  286;
            //重新规划tbxTxt的尺寸
            tbxTxt.Width = 210/*tbxTxt.DefaultWidth*/ + this.Size.Width - FontDefaultWidth;
            tbxTxt.Height = 210/*tbxTxt.DefaultWidth*/ + this.Size.Height - FontDefaultHeight;
            //重新规划按键位置
            btnOpen.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnOpen.Location.Y);
            btnSaveOther.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnSaveOther.Location.Y);
            btnSave.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnSave.Location.Y);
            btnFont.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnFont.Location.Y);
            btnColor.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnColor.Location.Y);
            btnRemove.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnRemove.Location.Y);
            btnDelete.Location = new Point(293 + this.Size.Width - FontDefaultWidth, btnDelete.Location.Y);
            //重新规划list 的高度
            lbxTxt.Height = 208/*tbxTxt.DefaultWidth*/+ this.Size.Height - FontDefaultHeight;

            //skinEngine1.Active = true;
            ////skinEngine1.SkinFile += Path.GetFullPath(Path.GetDirectoryName(System.Environment.CurrentDirectory) + "\\Skins");//获取当前路径
            //skinEngine1.SkinFile += @"E:\练习\Project - Test\VisualStdio_2015\Winform入门经典\WinformProject\WinformProject\bin\Debug\Skins";
            ////skinEngine1.SkinFile = @"\DeepOrange.ssk";
            //skinEngine1.SkinFile = @"\Skins\DiamondBlue.ssk";


            //添加文本框的鼠标滚轮事件
            tbxTxt.MouseWheel += tbxTxtMouseWheel;
        }
        private void tbxTxtMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)//文本框鼠标滚轮事件
        {
            //tbxTxt.Text =   "Button:" + e.Button.ToString() + "\r\n" +
            //                "Clicks:" + e.Clicks.ToString() + "\r\n" +
            //                "Delta:" + e.Delta.ToString() + "\r\n" +
            //                "Location:" + e.Location.ToString() + "\r\n" +
            //                "X:" + e.X.ToString() + "\r\n" +
            //                "Y:" + e.Y.ToString() + "\r\n";

            float newSize = tbxTxt.Font.Size;
            //鼠标往上滑 e.Delta = 120
            //鼠标往下滑 e.Delta = -120

            if(Control.ModifierKeys == Keys.Control)//如果Ctrl键按下
            {
                if (e.Delta > 0 && newSize < 120)//鼠标上滑 且 最大尺寸必须小于120
                {
                    newSize += 1;//字体大小加1
                }
                else if (e.Delta < 0 && newSize > 1)//鼠标下滑 且 最大尺寸必须大于1
                {
                    newSize -= 1;//字体大小减1
                }
                tbxTxt.Font = new Font(tbxTxt.Font.FontFamily, newSize, tbxTxt.Font.Style);//设置新字体 ： 只更改了Font.Size
            }
        }




        private void btnOpen_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();//创建一个文件选择对话框            
            ofd.Title = "请选择需要打开的TXT文档";//设置对话框标题            
            ofd.Multiselect = true;//设置对话框可以多选            
            ofd.InitialDirectory = @"C:\Users\obil\Desktop";//设置对话框的初始目录           
            ofd.Filter = "文本文件|*.txt|所有文件|*.*";  //设置打开对话框的文件类型//"文本文件|*.txt|媒体文件|*.mp3|图片文件|*.jpg|所有文件|*.*";            
            ofd.ShowDialog();//展示对话框           
            string path = ofd.FileName;//获取打开对话框中选择文件的路径
            //获取内容
            if (path == "")
            {
                return;
            }
            else
            {
                bool repeat = false;                
                for(int i = 0;i< TxtPathList.Count;i++)//避免重复添加，先循环路径列表检测一下
                {
                    if(TxtPathList[i] == path)
                    {
                        repeat = true;//有重复的路径
                        break;
                    }
                }
                if(repeat == false)
                {                                      
                    using (FileStream fs_r = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))//读取数据
                    {
                        tbxTxt.Text = "";
                        //string[] path = Directory.GetFiles(@"E:\音乐\歌曲1", "*.wav");    //获取某种类型的所有文件路径
                        TxtPathList.Add(path);                                                     //添加路径
                        lbxTxt.Items.Add(Path.GetFileName(path));                           //获取路径下的文件名

                        Index = lbxTxt.Items.Count - 1 ;//记录当前打开的文本框内容对应的文档的索引 （List最后一个）

                        byte[] buffer = new byte[1024 * 1024 * 5];
                        while (true)
                        {
                            int num = fs_r.Read(buffer, 0, buffer.Length);
                            if (num == 0)break;
                            string s = Encoding.Default.GetString(buffer);
                            tbxTxt.Text += s;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("已经添加过该文件了");
                }
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if(TxtPathList.Count != 0 && Index < TxtPathList.Count )//当前打开文档不空 且 索引是列表其中一个文档
            {
                if (File.Exists(TxtPathList[  Index/*指定索引保存*/  ])) //如果路径存在  TxtPathList[lbxTxt.SelectedIndex]
                {
                    System.IO.File.WriteAllText(TxtPathList[Index/*指定索引保存*/  ], string.Empty);//清空当前文件
                    using (FileStream fs_w = new FileStream(TxtPathList[Index/*指定索引保存*/  ], FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        byte[] buffer = Encoding.Default.GetBytes(tbxTxt.Text);
                        fs_w.Write(buffer, 0, buffer.Length);
                    }
                }
                else
                {
                    MessageBox.Show("不存在该文件或已被删除");
                    //如果文件不存在了，则移除路径列表
                    TxtPathList.RemoveAt(lbxTxt.SelectedIndex);
                    //移除listbox显示列表
                    lbxTxt.Items.RemoveAt(lbxTxt.SelectedIndex);

                    tbxTxt.Text = "";//清空显示
                }
            }
            else
            {
                //如果没有打开过
                MessageBox.Show("请选择被保存的对象");
            }
        }

        private void btnSaveOther_Click(object sender, EventArgs e)
        {            
            SaveFileDialog sfd = new SaveFileDialog();//创建一个文件选择对话框            
            sfd.Title = "选择要保存TXT的路径";//设置对话框标题            
            sfd.InitialDirectory = @"C:\Users\obil\Desktop";//设置对话框的初始目录            
            sfd.Filter = "文本文件|*.txt|所有文件|*.*"; //设置打开对话框的文件类型//"文本文件|*.txt|媒体文件|*.mp3|图片文件|*.jpg|所有文件|*.*";          
            sfd.ShowDialog();//展示对话框           
            string path = sfd.FileName;//拿到 将要保存的路径  //获取打开对话框中选择文件的路径
            //获取内容
            if (path == "")
            {
                return;
            }
            else
            {
                //读取数据
                using (FileStream fs_w = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.Default.GetBytes(tbxTxt.Text);
                    fs_w.Write(buffer, 0, buffer.Length);
                }
                TxtPathList.Add(path);                                                     //添加路径
                lbxTxt.Items.Add(Path.GetFileName(path));                           //获取路径下的文件名
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            tbxTxt.Font = fd.Font;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            tbxTxt.ForeColor = cd.Color;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否确定移除",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1)
                
                == DialogResult.Yes)
            {               
                TxtPathList.RemoveAt(lbxTxt.SelectedIndex);  //如果文件不存在了，则移除路径列表              
                lbxTxt.Items.RemoveAt(lbxTxt.SelectedIndex); //移除listbox显示列表
                tbxTxt.Text = "";//清空显示
            }
        }

        private void lbxTxt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(TxtPathList[lbxTxt.SelectedIndex])) //如果路径存在
            {
                Index = lbxTxt.SelectedIndex;//双击打开后记录当前文本框内容对应的文档的索引
                //读取数据
                using (FileStream fs_r = new FileStream(TxtPathList[lbxTxt.SelectedIndex], FileMode.OpenOrCreate, FileAccess.Read))
                {
                    tbxTxt.Text = "";
                    //string[] path = Directory.GetFiles(@"E:\音乐\歌曲1", "*.wav");    //获取某种类型的所有文件路径
                    //list.Add(path);                                                     //添加路径
                    //lbxTxt.Items.Add(Path.GetFileName(path));                           //获取路径下的文件名

                    byte[] buffer = new byte[1024 * 1024 * 5];
                    while (true)
                    {
                        int num = fs_r.Read(buffer, 0, buffer.Length);
                        if (num == 0)
                            break;
                        string s = Encoding.Default.GetString(buffer);
                        tbxTxt.Text += s;
                    }
                }
            }
            else
            {
                MessageBox.Show("不存在该文件或已被删除");                
                TxtPathList.RemoveAt(lbxTxt.SelectedIndex);//如果文件不存在了，则移除路径列表                
                lbxTxt.Items.RemoveAt(lbxTxt.SelectedIndex);//移除listbox显示列表
                tbxTxt.Text = "";//清空显示
            }
        }



        //通过委托 调用 别的窗口 判断是否 移除 并 删除源文件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定移除并删除源文件",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1)

                == DialogResult.Yes)
            {
                //警告：此处必须先执行本地文件删除，再移除列表操作
                //      不然如果先移除列表的是最后一项，则 lbxTxt.SelectedIndex 已经不再是指向最后一项的数据了，
                //      路径也移除了，已经找不到待删除的文件了


                //删除本地文件操作
                File.Delete(TxtPathList[lbxTxt.SelectedIndex]);


                //移除操作
                TxtPathList.RemoveAt(lbxTxt.SelectedIndex);  //如果文件不存在了，则移除路径列表              
                lbxTxt.Items.RemoveAt(lbxTxt.SelectedIndex); //移除listbox显示列表
                tbxTxt.Text = "";//清空显示                
            }
        }
    }
}
