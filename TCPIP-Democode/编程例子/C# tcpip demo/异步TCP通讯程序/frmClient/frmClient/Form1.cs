using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;

namespace frmClient
{
    public partial class Form1 : Form
    {
        private IPAddress IP;//ip   
        private EndPoint endpoint;//point  
        private Socket socket;//socket      
        private Thread MyThread;

        private System.IO.Stream stream = null;      
        private System.Reflection.Assembly ass = null;   
        private System.Media.SoundPlayer pl = null;  
        private string txt;  
        
        public class StateObjcet
        {
            public Socket workSocket = null;
            public const int BufferSize =256;
            
            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new StringBuilder();
        }
        
        public Form1()
        {
            InitializeComponent();
            UpdateList += new UpdateControlList(this.listTest);
            UpdateStatus += new UpdateControl(this.Status);
            
        }



        public delegate void UpdateControlList(Object sender, EventArgs e, String Str);
        public static UpdateControlList UpdateList;

        public delegate void UpdateControl(Object sender, EventArgs e);
        public static UpdateControl UpdateStatus;
        private void button1_Click(object sender, EventArgs e)
        {
            ///线程调用连接
            System.Threading.Thread th = new System.Threading.Thread(this.ToConnect);
            th.Start();
        }
        // 获取本机IP
        public static IPAddress GetServerIP()        //静态函数, 无需实例化即可调用.
        {
            IPHostEntry ieh = Dns.GetHostByName(Dns.GetHostName()); //不多说了, Dns类的两个静态函数

            //或用DNS.Resolve()代替GetHostName()
            return ieh.AddressList[0];                  //返回Address类的一个实例. 这里AddressList是数组并不奇怪,一个Server有N个IP都有可能
        }

        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        private static string response = string.Empty;


        //连接服务器  
        private void ToConnect()       
        {
            Control.CheckForIllegalCrossThreadCalls = false;

                try
                {
                    //连接成功   
                    socket.BeginConnect(endpoint, new AsyncCallback(ConnectCallback), socket);
                    String str=button1.Text.ToString();
                   //Receive(socket);
                }
                catch (FormatException)
                {
                    MessageBox.Show("IP error OR Point error");

                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("IP error OR Point error");


                }
                catch (Exception)
                {
                    lblStatus.Text = "连接失败，原因: 服务器已停止.";
            }
                
        }


        // 接收数据信息


        public void ReceiveMsg()
        {

            while (true)
            {

                try
                {

                    byte[] date = new byte[1024];
                   
                     int recv = socket.Receive(date);
                     string str = Encoding.UTF8.GetString(date,0,recv);
                }
                catch (SocketException ex)
                { 
                
                }
            }

        }


        public void listTest(Object o, EventArgs e, String str)
        {
            this.richTextBox1.Text = str;
        }

        //设置控件状态
        public void Status(Object o, EventArgs e)
        {
            lblStatus.Text = "连接成功.";
            button1.Enabled = false;
        }

        //回调（异步调用连接请求）
        private static void ConnectCallback(IAsyncResult er)
        {
            try
            {
               
                // 获取到异步操作信息
                Socket client = (Socket)er.AsyncState;
                UpdateStatus(new Form1(), new EventArgs());
                StateObjcet state = new StateObjcet();
                state.workSocket = client;

                client.BeginReceive(state.buffer, 0, StateObjcet.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

              //  Receive(client);
                // 结束挂起异步连接操作请求
                //client.EndConnect(er);
                

            }
            catch(Exception e) 
            { 
            MessageBox.Show(e.ToString());
            return;
            
            }
        
        }
        
        //异步发送信息
        /// <summary>
        /// 异步发送
        /// </summary>
        /// <param name="er"></param>
        private static void SendCallback(IAsyncResult er)
        {

            try
            {
                //获取异步对象异步操作信息
                Socket Client = (Socket)er.AsyncState;
                //挂起异步 发送请求
                int byteSend = Client.EndSend(er);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
/// <summary>
///读取Socket 套接字
/// </summary>
/// <param name="client"></param>
      private static  void Receive(Socket client)
      {
         try
          {
                StateObjcet state = new StateObjcet();
                state.workSocket=client;

                client.BeginReceive(state.buffer,0,StateObjcet.BufferSize,0,new AsyncCallback(ReceiveCallback),state);

            }catch(Exception e)
            {
              MessageBox.Show(e.ToString());
            }
      
      }
/// <summary>
/// 异步挂起
/// </summary>
/// <param name="er"></param>
      private static void ReceiveCallback(IAsyncResult er)
      {
          try
          {
              //异步操作获取用户定义信息
              StateObjcet state = (StateObjcet)er.AsyncState;
              Socket client = state.workSocket;
              
              //结束挂起异步读取
             int bytebuffer = client.EndReceive(er);
              if (bytebuffer > 0)
              {

                  UpdateList(new Form1(), new EventArgs(), Encoding.ASCII.GetString(state.buffer, 0, state.buffer.Length));
                  state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytebuffer));           
                  client.BeginReceive(state.buffer, 0, StateObjcet.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                
              }
              else
              {
                  if (state.sb.Length > 1)
                  {
                      response = state.sb.ToString();
                  }
                  receiveDone.Set();
                  client.Close();
              }

          }
          catch (Exception e)
          {
              MessageBox.Show(e.ToString());
          }
        
      }


        private void button2_Click(object sender, EventArgs e)
        {
           
            if (richTextBox2.Text.Trim() == "")
                return;
            else if (richTextBox2.Text.Trim().ToLower() == "clear()")
            {
                richTextBox1.Clear();
                richTextBox2.Text = ""; 
                return;
            }
            else if (Regex.IsMatch(richTextBox2.Text.Trim().ToLower(), @"^[zoom(]+[\d]+[)]$"))
                {
                    string str = richTextBox2.Text.ToLower(); 
                    int size = Convert.ToInt32(str.Substring(str.LastIndexOf('(') + 1, str.IndexOf(')') - str.LastIndexOf('(') - 1));
                    richTextBox1.Font = new Font("宋体", size, FontStyle.Bold);
                    return;
                }

            try
            {
                     
                Byte[] bs;
             
                string user = null;             
                if (txtUser.Text.Trim() == "在此输入你的名字" || txtUser.Text.Trim() == "")        
                {                  
                    user = "我";                
                    bs = Encoding.Unicode.GetBytes(string.Format("对方说:({0})\r\n{1}\r\n", DateTime.Now.ToString(),richTextBox2.Text.Trim()));  
                }            
                else            
                {                 
                    bs = Encoding.Unicode.GetBytes(string.Format("{0}说:({1})\r\n{2}\r\n", txtUser.Text.Trim(),DateTime.Now.ToString(),richTextBox2.Text.Trim()));          
                    user = txtUser.Text.Trim();               
                }
             
                bs = System.Text.Encoding.UTF8.GetBytes(richTextBox2.Text); //发现UTF8可支持中文,就用之
               
                socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);

                txt = string.Format("{0}说:({1})\r\n{2}\r\n", user, DateTime.Now.ToString(), richTextBox2.Text.Trim());      
                int tempLen = richTextBox1.Text.Length;          
                richTextBox1.AppendText(txt);              
                richTextBox1.Select(tempLen, txt.Length);         
                richTextBox1.SelectionFont = new Font("宋体", 10);         
                richTextBox1.SelectionColor = Color.Red;              
                richTextBox2.Clear();         
            }           
            catch(Exception ex)      
            { 
                MessageBox.Show("连接尚未建立！无法发送数据!" + ex.Message);
            }    
         }


   

        private void Form1_Load(object sender, EventArgs e)
        {
       
          
            // 获取到本机IP
         GetServerIP();

            //自动获取到本机电脑端口
         IP = IPAddress.Parse(txtIP.Text.Trim());
         int point = Convert.ToInt32(txtPoint.Text.Trim());
         endpoint = new IPEndPoint(IP, point);                //建立Socket       
         socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }


        private void TheradScoket()
        {
            Thread TempThread;
            //开启接收线程    
            TempThread = new Thread(new ThreadStart(this.ToConnect));
            TempThread.IsBackground = true;//设置为后台线程    
            TempThread.Start();
            TempThread.Abort();//关闭线程   
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //关闭套接字    
            client.Close();
            

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TheradScoket();
           // socket.Close();
            
        }
        }        


    
}
