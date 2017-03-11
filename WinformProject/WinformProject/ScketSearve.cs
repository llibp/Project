using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


//   客户端                         服务器端
//   Socket()                        Socket()
//                                   Bind()      绑定监听端口
//                                   Listen()    设置监听队列
//   Connect()  建立连接    <----->  Accept()    while(true) 循环等待客户端的接入
//   Send()     发送数据    <----->  Receive()
//   Receive()  接收数据    <----->  Send()
//                                   捕捉异常
//   Close()                <----->  Close()


namespace WinformProject
{

    [Serializable]
    class ScketSearve
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);




        public delegate void Transmit(string str);
        public event Transmit DataTransmit;

        //将远程客户端的IP 地址  和 Socket 存入键值对
        Dictionary<string, Socket> disSocket = new Dictionary<string, Socket>();

        //在发送消息按钮中需要调用 socketSend 所有将其置为方法外
        public Socket socketSend;


        public void StartMonitor()
        {
            try
            {
                //当点击开始监听的时候，在服务器端创建一个负责监听IP地址跟端口号的 Socket
                Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Any;
                //创建端口号对象
                IPEndPoint point = new IPEndPoint(ip, (Int32)55555);//Convert.ToInt32(txtPort.Text)
                //监听端口 - 指定本地地址端口
                socketWatch.Bind(point);
                //MessageBox.Show("监听成功","警告");


                //Thread.Sleep(200);
                ////查找MessageBox的弹出窗口,注意MessageBox对应的标题
                //IntPtr ptr = FindWindow(null, "警告");
                //if (ptr != IntPtr.Zero)
                //{
                //    //public const int WM_CLOSE = 0x10;
                //    //查找到窗口则关闭
                //    PostMessage(ptr, 0x10, IntPtr.Zero, IntPtr.Zero);
                //}


                socketWatch.Listen(10);


                ////Accept() 等待……（一直等待）客户端连接 并创建一个负责通信的Socket
                //Socket socketSend = socketWatch.Accept();
                //ShowMsg(socketSend.RemoteEndPoint.ToString()+":"+"连接成功+通过这个属性拿到远程终结点 - 远程IP 地址
                //
                //在服务器开始等待客户端连接器件，线程一直停在这儿了，直至客户端连接成功
                //所以创建一个新线程来负责连接每一个客户端

                Thread th = new Thread(Listen);
                th.IsBackground = true;//设置为后台线程
                th.Start(socketWatch);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告");
            }
        }
        //等待客户端的连接，并且创建与之通信的 Socket
        void Listen(Object sWatch)
        {
            Socket socketWatch = sWatch as Socket;

            while (true)
            {
                try
                {
                    //等待客户端的连接，并且创建一个负责通信的Socket
                    socketSend = socketWatch.Accept();//等待中ing


                    //获取客户端IP 地址，如果没有添加过，则添加
                    string clientIp = socketSend.RemoteEndPoint.ToString();
                    if (disSocket.Keys.Contains(clientIp) == false)
                    {
                        //添加新接入的客户端 地址（IP地址 和 Socket）
                        //先一对一的存入 键值对
                        disSocket.Add(socketSend.RemoteEndPoint.ToString(), socketSend);
                        //添加IP 到下拉列表框中
                        //cbxServer.Items.Add(socketSend.RemoteEndPoint.ToString());
                    }


                    //连接成功
                    DataTransmit(socketSend.RemoteEndPoint.ToString() + ":" + "连接成功");
                    //客户端连接成功后，服务器应该接受客户发来的消息 - 利用 socketSend.Receive();方法
                    //接收到 字节数组 byte[]里面，返回 int数组，实际接收到的长度
                    //byte[] buffer = new byte[1024*1024*5];  //设置一个5MB的字节数组来接收数据
                    //while(true)
                    //{
                    //    int r = socketSend.Receive(buffer);
                    //    if (r == 0) break;
                    //    string str = Encoding.Default.GetString(buffer, 0, r);
                    //    ShowMsg(socketSend.RemoteEndPoint + ":" + str);
                    //}
                    //如果再次设置死循环，函数会一直死在这儿，所以提前方法 Receive()

                    //开启一个新线程，不停的接收客户端发来的消息
                    Thread th = new Thread(Receive);
                    th.IsBackground = true;
                    th.Start(socketSend);
                }
                catch
                {

                }

            }
        }
        //服务器端不停的接收客户端发过来的消息
        void Receive(Object obj)
        {
            Socket socketSend = obj as Socket;
            //客户端连接成功后，服务器应该接受客户发来的消息 - 利用 socketSend.Receive();方法
            //接收到 字节数组 byte[]里面，返回 int数组，实际接收到的长度
            byte[] buffer = new byte[1024 * 1024 * 5];  //设置一个5MB的字节数组来接收数据
            while (true)
            {
                try
                {
                    int r = socketSend.Receive(buffer);
                    if (r == 0) break;
                    string str = Encoding.Default.GetString(buffer, 0, r);
                    //MessageBox.Show(socketSend.RemoteEndPoint + ":" + str);
                    DataTransmit(str);
                }
                catch
                {

                }
            }
        }
        //服务器给客户端发消息
        public void SocektSend(string str)
        {
            byte[] buffer = Encoding.Default.GetBytes(str);
            //buffer[0] = 0;

            //用集合来保存字节数组，并在前面多添加一位，用于区分不同的文件 --->客户端接收到后，根据第一字节不同数据区分
            //  0 代表文本文件
            //  1 代表其他文件
            //  2 代表震动
            //List<byte> list = new List<byte>();
            //list.Add(0);
            //list.AddRange(buffer);
            //将泛型集合转换为数组
            //byte[] newBuffer = list.ToArray();

            //如果下拉框什么都没选
            //if (cbxServer.SelectedIndex == -1)
            //{
            //    MessageBox.Show("选择 IP 失败");
            //}
            //else
            //{
            //先获得下拉框里面的IP 地址(获得键值对的  键)
            string ip = socketSend.RemoteEndPoint.ToString();
            //string ip = socketSend.RemoteEndPoint.ToString();
            disSocket[ip].Send(buffer);
            //disSocket[ip].Send(newBuffer);
            //}

            //socketSend.Send(buffer);

        }

        //判断客户端是否已经断开
        //client.Poll(10,SelectMode.SelectRead)判断就行了。只要返回True是。就可以认为客户端已经断开了。
        public static bool IsSocketConnected(Socket s)
        {
            return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
            //return s.Poll(10, SelectMode.SelectRead);
        }
    }
}
