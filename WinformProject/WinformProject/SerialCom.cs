using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformProject
{
    class SerialCom
    {
        //public delegate void EventHandle(byte[] readBuffer);
        //public delegate void EventHandle( );
        //public event EventHandle DataReceived;

        public SerialPort serialPort;
        //Thread thread;

        //volatile bool _keepReading;





        public SerialCom()
        {
            serialPort = new SerialPort();

            //serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MyReadPort); 

            //thread = null;

            //_keepReading = false;
        }

        public bool IsOpen
        {
            get
            {
                return serialPort.IsOpen;
            }
        }
        //private void StartReading()
        //{
        //if(!_keepReading)
        //{
        //    _keepReading = true;
        //    thread = new Thread(new ThreadStart(ReadPort));

        //    thread.IsBackground = true;
        //    thread.Start();
        //}
        //}
        //private void StopReading()
        //{
        //    if(_keepReading)
        //    {
        //        _keepReading = false;
        //        thread.Join();
        //        thread = null;
        //    }
        //}

        //void MyReadPort(object sender, SerialDataReceivedEventArgs e)
        //{

        //}


        //private void ReadPort()
        //{
        //    while(_keepReading)
        //    {
        //        if(serialPort.IsOpen)
        //        {
        //            int count = serialPort.BytesToRead;
        //            if(count > 0)
        //            {
        //                byte[] readBuffer = new byte[count];
        //                try
        //                {
        //                    Application.DoEvents();
        //                    serialPort.Read(readBuffer,0,count);

        //                    //if(DataReceived != null)
        //                    //{
        //                        //DataReceived(readBuffer);
        //                   // }
        //                    Thread.Sleep(100);
        //                }
        //                catch(TimeoutException)
        //                {

        //                }
        //            }
        //        }
        //    }
        //}




        public void Open()
        {
            Close();
            //try
            //{
            serialPort.Open();
            //if(serialPort.IsOpen)
            //{}
            //}
            //catch
            //{
            //    MessageBox.Show(
            //        "串口打开失败",
            //        "警告",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //}
        }
        public void Close()
        {
            serialPort.Close();
        }

        public void WritePort(byte[] send, int offSet, int count)
        {
            if (IsOpen)
            {
                serialPort.Write(send, offSet, count);
            }
        }

    }
}


