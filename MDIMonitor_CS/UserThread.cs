using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace MDIMonitor_CS
{
    public class UserThread
    {
        SerialPort MyportSend = null;
        SerialPort MyportRec = null;
        private bool end = false;//结束线程标志
        private bool kill = false;//终结线程标志
        private bool stop = false;//暂停线程标志
        private Thread thread = null;//恢复线程标志
        private Queue<int> msgQueue = null;//存储消息队列
        FrameWin Parent = null;//用于传入其他线程句柄，一般通过线程刷新某个窗口UI,FrameWin是需要控制的窗口类，自行修改
        public UserThread(Form parent)
        {
            Parent = (FrameWin)parent;//强制转换
            msgQueue = new Queue<int>();
            thread = new Thread(new ThreadStart(Run));//真正定义线程
        }
        ~UserThread()
        {
            this.End();//析构时结束线程
        }
        public void PostMessage(int id)//id为传入的消息标识
        {
            if (end || kill)//如果线程结束或终止，不执行任何动作
                return;
            if (id > 0)
                msgQueue.Enqueue(id);//将post来的消息添加到消息队列
            if (stop)
                return;//如果线程暂停，将只接受消息，暂不执行，一旦线程恢复，继续执行所接收消息
            if (!this.thread.IsAlive)//如果线程未开启，将启动线程
                this.thread.Start();
        }
        public void Start()
        {
            if (end || kill)//如果线程已被结束或终止，将不执行任何动作
                return;
            if (!this.thread.IsAlive)//如果线程未开启，将启动线程
                thread.Start();
        }
        public void End()
        {
            end = true;//如果线程结束，将结束标识设为真，线程将在消息队列中所有消息执行完后终止
            Parent.StatusLabel1.Text = String.Format("结束线程");
        }
        public void Kill()
        {
            kill = true;//如果线程终止，将终止标识设为真，线程将不再执行消息队列中剩余消息
            Parent.StatusLabel1.Text = String.Format("终止线程");
        }
        public void Stop()
        {
            stop = true;//如果线程暂停，将暂停标识设为真，线程将暂不执行消息队列中剩余消息，
                        //但是消息队列仍然在接收消息，一旦线程恢复，继续执行所接收消息
            Parent.StatusLabel1.Text = String.Format("暂停线程");
        }
        public void Resume()
        {
            stop = false;//如果线程恢复，将恢复标识设为真，线程将继续执行消息队列中剩余消息
            Parent.StatusLabel1.Text = String.Format("恢复线程");
        }
        private void Run()
        {
            while (true)
            {
                if (kill)//如果线程终止，线程函数将立即跳出，消息队列里剩余消息不再执行，此线程结束，无法再开启
                    break;
                if (!stop && msgQueue.Count != 0)//如果线程未被暂停且消息队列中有剩余消息，将顺序执行剩余消息
                {
                    switch (msgQueue.Peek())//获取当前消息队列中消息，并一一比对执行相应的动作
                    {
                        case 1:
                            {
                                msgFunction_1();//例如消息码为1是，执行msgFunction_1()函数
                            } break;
                        case 2:
                            {
                                msgFunction_2();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        case 3:
                            {
                                msgFunction_3();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        case 4:
                            {
                                msgFunction_4();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        case 5:
                            {
                                msgFunction_5();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        case 6:
                            {
                                msgFunction_6();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                    }
                    msgQueue.Dequeue();//比对完当前消息并执行相应动作后，消息队列扔掉当前消息
                }
                if (msgQueue.Count == 0 && end)//如果线程被结束时当前消息队列中没有消息，将结束此线程
                                                //如果当前消息队列中仍有未执行消息，线程将执行完所有消息后结束
                    break;
                System.Threading.Thread.Sleep(1);//每次循环间隔1ms，我还不知道到底有没有必要
            }
        }


        private void msgFunction_1()//对应消息码为1的时要执行的函数
        {
            Parent.StatusLabel1.Text = String.Format("id = {0}", msgQueue.Peek());
            System.Threading.Thread.Sleep(5000);
        }
        private void msgFunction_2()//对应消息码为2的时要执行的函数
        {
            Parent.StatusLabel1.Text = String.Format("id = {0}", msgQueue.Peek());
            System.Threading.Thread.Sleep(3000);
        }
        private void msgFunction_3()//对应消息码为3的时要执行的函数
        {
            if (Parent.SerialForm.cbox_PortName.SelectedIndex == -1)
            {
                this.Parent.StatusLabel1.Text = "请确认串口端口";
                return;
            }
            if (Parent.SerialForm.cbox_PortName.Text == "COM2")
            {
                OpenSendPort();
            }
            if (Parent.SerialForm.cbox_PortName.Text == "COM1")
            {
                OpenRecPort();
            }
        }
        private void msgFunction_4()//对应消息码为3的时要执行的函数
        {
            if (MyportSend.IsOpen)
            {
                MyportSend.Close();
            }
            if (MyportRec.IsOpen)
            {
                MyportRec.Close();
            }
            this.Parent.StatusLabel1.Text = "the port is closed";
        }
        private void msgFunction_5()//对应消息码为3的时要执行的函数
        {
            if (!MyportSend.IsOpen)
            {
                this.Parent.StatusLabel1.Text = "the send port has not been opened";
                return;
            }
            SendCommand(Parent.SerialForm.rich_Send.Text);
            if (!MyportRec.IsOpen)
            {
                this.Parent.StatusLabel1.Text = "the receive port has not been opened,you can not view the data sent";
                return;
            }
        }
        private void msgFunction_6()
        {
            MyportSend = new SerialPort();
            MyportRec = new SerialPort();
            //让壮态栏控件的宽度与显示器的分辨率宽度一致
            //this.Parent.this.m_ParentForm.StatusLabel1.Text = "就绪";
            //实例化
            MyportSend = new SerialPort();
            MyportRec = new SerialPort();
            //这里需要添加引用Microsoft.VisualBasic的引用，提供操作计算机组件（如：音频，时钟，键盘文件系统等）的属性
            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            //循环该计算机上所有串行端口的集合
            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_PortName.Items.Add(s);
            }
            if (pc.Ports.SerialPortNames.Count > 0)
            {
                Parent.SerialForm.cbox_PortName.SelectedIndex = 0;
            }
            Parent.SerialForm.cbox_Bits.Items.Add("5");
            Parent.SerialForm.cbox_Bits.Items.Add("7");
            Parent.SerialForm.cbox_Bits.Items.Add("8");
            Parent.SerialForm.cbox_Bits.SelectedIndex = 2;//选择8位数据包

            Parent.SerialForm.cbox_Baud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            Parent.SerialForm.cbox_Baud.SelectedIndex = 11;//选择最大比特率

            Parent.SerialForm.cbox_Parity.Items.AddRange(new object[] {
            "Even",
            "Mark",
            "None",
            "Odd",
            "Space"});
            Parent.SerialForm.cbox_Parity.SelectedIndex = 2;//选中校验位位none表示不设置校验位

            Parent.SerialForm.cbox_Stop.Items.Add("One");
            Parent.SerialForm.cbox_Stop.Items.Add("OnePointFive");
            Parent.SerialForm.cbox_Stop.Items.Add("Two");
            Parent.SerialForm.cbox_Stop.SelectedIndex = 0;//停止位为1
        }
        private void OpenSendPort()
        {
            if (!MyportSend.IsOpen)
            {
                MyportSend.PortName = Parent.SerialForm.cbox_PortName.Text;
            }
            //设置比特率
            if (Parent.SerialForm.cbox_Baud.SelectedIndex == -1)
            {
                Parent.StatusLabel1.Text = "请确认比特率";
                return;
            }
            MyportSend.BaudRate = Convert.ToInt32(Parent.SerialForm.cbox_Baud.Text);
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == -1)
            {
                this.Parent.StatusLabel1.Text = "请确认奇偶校验位";
                return;
            }
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == 0)
                MyportSend.Parity = Parity.Even;
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == 1)
                MyportSend.Parity = Parity.Mark;
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == 2)
                MyportSend.Parity = Parity.None;
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == 3)
                MyportSend.Parity = Parity.Odd;
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == 4)
                MyportSend.Parity = Parity.Space;

            //设置数据位
            if (Parent.SerialForm.cbox_Bits.SelectedIndex == -1)
            {
                this.Parent.StatusLabel1.Text = "请确认数据位";
                return;
            }
            MyportSend.DataBits = Convert.ToInt32(Parent.SerialForm.cbox_Bits.Text);
            //根据选择的数据，设置停止位
            if (Parent.SerialForm.cbox_Stop.SelectedIndex == -1)
            {
                this.Parent.StatusLabel1.Text = "请确认停止位";
                return;
            }
            if (Parent.SerialForm.cbox_Stop.SelectedIndex == 0)
                MyportSend.StopBits = StopBits.One;
            if (Parent.SerialForm.cbox_Stop.SelectedIndex == 1)
                MyportSend.StopBits = StopBits.OnePointFive;
            if (Parent.SerialForm.cbox_Stop.SelectedIndex == 2)
                MyportSend.StopBits = StopBits.Two;

            //根据选择的数据，设置奇偶校验位

            //此委托应该是异步获取数据的触发事件，即是：当有串口有数据传过来时触发
            //MyportSend.DataReceived += new SerialDataReceivedEventHandler(RecPort_DataReceived);//DataReceived事件委托
            //打开串口的方法
            try
            {
                MyportSend.Open();
                if (MyportSend.IsOpen)
                {
                    //MessageBox.Show("the port is opened!");
                    this.Parent.StatusLabel1.Text = "send port is opened";
                }
                else
                {
                    this.Parent.StatusLabel1.Text = "failure to open send port!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failure to open send port!" + ex.ToString());
            }

        }
        private void OpenRecPort()
        {
            if (!MyportRec.IsOpen)
            {
                MyportRec.PortName = Parent.SerialForm.cbox_PortName.Text;
            }
            //设置比特率
            if (Parent.SerialForm.cbox_Baud.SelectedIndex == -1)
            {
                this.Parent.StatusLabel1.Text = "请确认比特率";
                return;
            }
            MyportRec.BaudRate = Convert.ToInt32(Parent.SerialForm.cbox_Baud.Text);
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == -1)
            {
                this.Parent.StatusLabel1.Text = "请确认奇偶校验位";
                return;
            }
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == 0)
                MyportRec.Parity = Parity.Even;
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == 1)
                MyportRec.Parity = Parity.Mark;
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == 2)
                MyportRec.Parity = Parity.None;
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == 3)
                MyportRec.Parity = Parity.Odd;
            if (Parent.SerialForm.cbox_Parity.SelectedIndex == 4)
                MyportRec.Parity = Parity.Space;

            //设置数据位
            if (Parent.SerialForm.cbox_Bits.SelectedIndex == -1)
            {
                this.Parent.StatusLabel1.Text = "请确认数据位";
                return;
            }
            MyportRec.DataBits = Convert.ToInt32(Parent.SerialForm.cbox_Bits.Text);
            //根据选择的数据，设置停止位
            if (Parent.SerialForm.cbox_Stop.SelectedIndex == -1)
            {
                this.Parent.StatusLabel1.Text = "请确认停止位";
                return;
            }
            if (Parent.SerialForm.cbox_Stop.SelectedIndex == 0)
                MyportRec.StopBits = StopBits.One;
            if (Parent.SerialForm.cbox_Stop.SelectedIndex == 1)
                MyportRec.StopBits = StopBits.OnePointFive;
            if (Parent.SerialForm.cbox_Stop.SelectedIndex == 2)
                MyportRec.StopBits = StopBits.Two;

            //根据选择的数据，设置奇偶校验位

            //此委托应该是异步获取数据的触发事件，即是：当有串口有数据传过来时触发
            MyportRec.DataReceived -= new SerialDataReceivedEventHandler(RecPort_DataReceived);
            MyportRec.DataReceived += new SerialDataReceivedEventHandler(RecPort_DataReceived);//DataReceived事件委托
            //打开串口的方法
            try
            {
                MyportRec.Open();
                if (MyportRec.IsOpen)
                {
                    //MessageBox.Show("the port is opened!");
                    this.Parent.StatusLabel1.Text = "receive port is opened";
                }
                else
                {
                    this.Parent.StatusLabel1.Text = "failure to open receive port!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failure to open receive port!" + ex.ToString());
            }

        }
        private void RecPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string currentline = "";
                //循环接收串口中的数据
                while (MyportRec.BytesToRead > 0)
                {
                    char ch = (char)MyportRec.ReadByte();
                    currentline += ch.ToString();
                }
                //MyportRec.DiscardInBuffer();
                //MessageBox.Show(currentline);
                //在这里对接收到的数据进行显示
                //如果不在窗体加载的事件里写上：Form.CheckForIllegalCrossThreadCalls = false; 就会报错）
                Parent.SerialForm.rich_Receive.Text = currentline;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        private void SendCommand(string CommandString)
        {
            //转换
            //串口只能读取ASCII码或者进制数（1，2，3.....的进制，一般是16进制）
            byte[] WriteBuffer = new byte[2048];
            WriteBuffer = Encoding.Default.GetBytes(CommandString);
            //将数据缓冲区的数据写入到串口端口
            MyportSend.Write(WriteBuffer, 0, WriteBuffer.Length);
        }
    }
}
