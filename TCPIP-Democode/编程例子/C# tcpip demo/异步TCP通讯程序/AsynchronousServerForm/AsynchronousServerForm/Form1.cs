using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;
using System.Text.RegularExpressions;


namespace AsynchronousServerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            UpdateControl += new UpdateControlEventHandler(this.Test);  //订阅UpdateControl事件，指定Test方法为事件处理函数
            UpdateList += new UpdateControlListBox(this.listTest);

            UpdateComBox += new UpdateCombox(this.ComboxTest); 
            InitializeComponent();
        }
        //public TcpListener server = null;  
            //创建网络监听  
       private readonly bool m_isSerevr;      
       public Socket sock;          //定义一个Socket类的对象 (默认为protected)
        //Socket Clientsock;
       private Socket soc;
       private IPEndPoint iep;
       private Thread th;
       private bool bol = false;
        List<Socket> arrya = new List<Socket>();
         String str1;
        IPAddress clientIp;
     

        //调用Combox控件的回调函数

        public delegate void OnDisconnectDelegate(Object sender, IPEndPoint peer);
        public event OnDisconnectDelegate OnDisconnect;

        public delegate void UpdateControlEventHandler(Object sender, EventArgs e,Socket sock);
        public static event UpdateControlEventHandler UpdateControl;
        public delegate void UpdateControlListBox(Object sender, EventArgs e,String Str);
        public static event UpdateControlListBox UpdateList;
        //根据客户端IP删除Combox中的IP
        public delegate void UpdateCombox(Object sender, EventArgs e, Socket soc);
        public static event UpdateCombox UpdateComBox;

        public class StateObjcet
        {
            public Socket workSocket ;
            public const int BufferSize = 256;

            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new StringBuilder();
        }
        public static IPAddress GetServerIP()        //静态函数, 无需实例化即可调用.
        {
            IPHostEntry ieh = Dns.GetHostByName(Dns.GetHostName()); //不多说了, Dns类的两个静态函数

            //或用DNS.Resolve()代替GetHostName()
            return ieh.AddressList[0];                  //返回Address类的一个实例. 这里AddressList是数组并不奇怪,一个Server有N个IP都有可能
        }

        private delegate void myDelegate(string str);
        private void setRich(string str)
        {
            if (this.listBox2.InvokeRequired)
            {
                myDelegate md = new myDelegate(this.setRich);
                this.Invoke(md, new object[] { str });
            }
            else
            {
                this.listBox2.Items.Add(str);
            }
        }

        private delegate void myCombox(string str);
        private void setCombox(string str)
        {
            if (this.comboBox1.InvokeRequired)
            {
                myCombox md = new myCombox(this.setCombox);
                this.Invoke(md, new object[] { str });
            }
            else
            {
                this.comboBox1.Items.Add(str);
            }
        }
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private void BeginListen()               //Socket监听函数, 等下作为创建新线程的参数
        {
            // 捕获所有错误的线程调用
          //  Control.CheckForIllegalCrossThreadCalls = false;
            try
            {
                soc.Bind(iep);                                  //Socket类的一个重要函数, 绑定一个IP,
                soc.Listen(1000);//监听状态
                while (true)
                {
                    allDone.Reset();
                    soc.BeginAccept(new AsyncCallback(AcceptCallback), soc);// 异步接收
                    allDone.WaitOne();
                    System.GC.Collect();
                }
            }

            catch (SocketException se)              //捕捉异常,
            {
                MessageBox.Show(se.ToString());
                // listBox1.Text = se.ToString();       //将其显示出来, 在此亦可以自定义错误.
            }
            catch (ObjectDisposedException ex)
            { } 
        }

        /// <summary>
        /// 异步接收信息
        /// </summary>
        /// <param name="er"></param>
        public static void AcceptCallback(IAsyncResult er   )
        {
            try
            {
                allDone.Set();
                // 异步获取用户对象
                Socket listener = (Socket)er.AsyncState;
                //异步接收连接通讯

                Socket handler = listener.EndAccept(er);

                StateObjcet state = new StateObjcet();
                state.workSocket = handler;

                handler.BeginReceive(state.buffer, 0, StateObjcet.BufferSize, 0, new AsyncCallback(ReadCallback), state);
               
                UpdateControl(new Form1(), new EventArgs(), handler);

                string msg = "From [" + handler.RemoteEndPoint.ToString() + "]:" + System.Text.Encoding.UTF8.GetString(state.buffer) + "\n";   //GetString()函数将byte数组转换为string类型.;
            }
            catch (ObjectDisposedException ex)
            {
                return;
            }
           // setRich(msg);

        }
        //combox控件在静态类中赋值
        public void Test(Object o, EventArgs e,Socket sock)  //事件处理函数，用来更新控件
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                this.comboBox1.Items.Add(sock.RemoteEndPoint.ToString());
                arrya.Add(sock);
            }
            catch (ObjectDisposedException ex)
            {
                return;
            }
        }
        //combox控件在静态类中赋值
        public void ComboxTest(Object o, EventArgs e, Socket sock)  //事件处理函数，用来更新控件
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                this.comboBox1.Items.Remove(sock.RemoteEndPoint.ToString());
                arrya.Remove(sock);
            }
            catch (ObjectDisposedException ex)
            {
                return;
            }
        }
        public void listTest(Object o, EventArgs e, String Str)
        {
            this.listBox2.Items.Add(Str);
        }
        //  public  void ReadCallback(IAsyncResult er)
        public static void ReadCallback(IAsyncResult er)
    {
            // 获取异步用户信息
            StateObjcet so = (StateObjcet)er.AsyncState;
            Socket s = so.workSocket;
            try
            {
                //异读取步
                int read = s.EndReceive(er);
                if (read > 0)
                {
                    UpdateList(new Form1(), new EventArgs(), Encoding.ASCII.GetString(so.buffer, 0, so.buffer.Length));
                    so.sb.Append(Encoding.ASCII.GetString(so.buffer, 0, read));
                    s.BeginReceive(so.buffer, 0, StateObjcet.BufferSize, 0, new AsyncCallback(ReadCallback), so);
                }
                else
                {
                    UpdateComBox(new Form1(), new EventArgs(), s);
                    s.Shutdown(SocketShutdown.Both);
                    // s.Close();
                }
            }

            catch (SocketException)
            {
             //   UpdateComBox(new Form1(), new EventArgs(), s);
                s.Shutdown(SocketShutdown.Both);
                return;
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }
        // 开始监听
        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button2.Enabled = false;
            if (!bol)
            {
                try
                {
                    //开启监听
                    th = new Thread(new ThreadStart(BeginListen));          //创建一个新的线程专门用于处理监听,这句话可以分开写的,比如: ThreadStart ts=new ThreadStart(BeginListen); th=new Thread (ts); 不过要注意, ThreadStart的构造函数的参数一定要是无参数的函数. 在此函数名其实就是其指针, 这里是委托吗?
                    th.Start();
                    listBox1.Items.Clear();//启动线程
                    listBox1.Items.Add("Listenning...");
                }
                catch (SocketException se)           //处理异常
                {
                    MessageBox.Show(se.Message, "出现问题", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentNullException ae)   //参数为空异常
                {
                    listBox1.Text = "参数错误";
                    MessageBox.Show(ae.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
              //th = new Thread(new ThreadStart(BeginListen));          //创建一个新的线程专门用于处理监听,这句话可以分开写的,比如: ThreadStart ts=new ThreadStart(BeginListen); th=new Thread (ts); 不过要注意, ThreadStart的构造函数的参数一定要是无参数的函数. 在此函数名其实就是其指针, 这里是委托吗?
               //继续以挂起线程
                th.Resume();
                bol = false;
                //th.Start();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button2.Enabled = true;
            bol = true;
            //MessageBox.Show(arrya.Count.ToString());
            //关闭套接字
            for (int i = 0; i < arrya.Count; i++)
            {
                //Socket ClientSocket = arrya[i];
               // UpdateComBox(new Form1(), new EventArgs(), arrya[i]);
                arrya[i].Shutdown(SocketShutdown.Both);
            }
            //soc.Shutdown(SocketShutdown.Both);
          //  soc.Close();      
            listBox1.Items.Clear();
            listBox1.Items.Add("停止监听");
            //线程挂起
            th.Suspend();
        }
        private void TheradScoket()
        { 
            Thread TempThread;
            //开启接收线程   
            /*
            TempThread = new Thread(new ThreadStart(this.BeginListen));
            TempThread.IsBackground = true;//设置为后台线程    
            TempThread.Start();
            TempThread.Abort();//关闭线程   
             * */
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //关闭套接字    
            client.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count < 0)
            {
                MessageBox.Show("没有建立连接");
                return;
            }
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("没有建立连接");
                return;
            }
            try
            {
                Byte[] byteMessage = new Byte[100]; //存放消息的字节数组缓冲区, 注意数组表示方法,和C不同的.
                Socket SelectSocket = arrya[comboBox1.SelectedIndex];
                byteMessage = System.Text.Encoding.Default.GetBytes(richTextBox1.Text);
                SelectSocket.BeginSend(byteMessage, 0, byteMessage.Length, 0, new AsyncCallback(SendCallback), SelectSocket);
                string msg = "我:" + System.Text.Encoding.Default.GetString(byteMessage) + "\n";   //GetString()函数将byte数组转换为string类型.;
                this.setRich(msg);
                richTextBox1.Clear();
            }
            catch (ArgumentNullException ae)
            {
                MessageBox.Show(ae.Message, "参数为空", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, "出现问题", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show(ex.Message, "已断开连接", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private static void SendCallback(IAsyncResult er)
        {
            try
            {
                Socket handler = (Socket)er.AsyncState;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IPAddress serverIp = GetServerIP();
            //server = new TcpListener(serverIp, Convert.ToInt32(textBox1.Text));
           iep = new IPEndPoint(serverIp, Convert.ToInt32(textBox1.Text));    //本地终结点
            soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);   //实例化内成员soc;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            TheradScoket();
        }
    }
}
