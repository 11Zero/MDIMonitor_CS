using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace MDIMonitor_CS
{
    public partial class SerialPortForm : Form
    {
        SerialPort MyportSend = null;
        SerialPort MyportRec = null;
        //Form ParentForm = null;
        public SerialPortForm(Form parent)
        {
            InitializeComponent();
            //ParentForm = parent;
            //MainFrame_Load();
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        //private void MainFrame_Load()
        //{
        //    //让壮态栏控件的宽度与显示器的分辨率宽度一致
        //    //this.Parent.StatusLabel1.Text = "就绪";
        //    //实例化
        //    MyportSend = new SerialPort();
        //    MyportRec = new SerialPort();
        //    //这里需要添加引用Microsoft.VisualBasic的引用，提供操作计算机组件（如：音频，时钟，键盘文件系统等）的属性
        //    Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
        //    //循环该计算机上所有串行端口的集合
        //    foreach (string s in pc.Ports.SerialPortNames)
        //    {
        //        cbox_PortName.Items.Add(s);
        //    }
        //    if (pc.Ports.SerialPortNames.Count > 0)
        //    {
        //        cbox_PortName.SelectedIndex = 0;
        //    }
        //    cbox_Bits.Items.Add("5");
        //    cbox_Bits.Items.Add("7");
        //    cbox_Bits.Items.Add("8");
        //    cbox_Bits.SelectedIndex = 2;//选择8位数据包

        //    cbox_Baud.Items.AddRange(new object[] {
        //    "300",
        //    "600",
        //    "1200",
        //    "2400",
        //    "4800",
        //    "9600",
        //    "19200",
        //    "38400",
        //    "43000",
        //    "56000",
        //    "57600",
        //    "115200"});
        //    cbox_Baud.SelectedIndex = 11;//选择最大比特率

        //    cbox_Parity.Items.AddRange(new object[] {
        //    "Even",
        //    "Mark",
        //    "None",
        //    "Odd",
        //    "Space"});
        //    cbox_Parity.SelectedIndex = 2;//选中校验位位none表示不设置校验位

        //    cbox_Stop.Items.Add("One");
        //    cbox_Stop.Items.Add("OnePointFive");
        //    cbox_Stop.Items.Add("Two");
        //    cbox_Stop.SelectedIndex = 0;//停止位为1

        //}

        //private void cbox_Baud_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void btn_Open_Click(object sender, EventArgs e)
        //{
        //    //设置串口端口
        //    if (cbox_PortName.SelectedIndex == -1)
        //    {
        //        this.Parent.StatusLabel1.Text = "请确认串口端口";
        //        return;
        //    }
        //    if (cbox_PortName.Text == "COM2")
        //    {
        //        OpenSendPort();
        //    }
        //    if (cbox_PortName.Text == "COM1")
        //    {
        //        OpenRecPort();
        //    }
        //}
        //private void RecPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    try
        //    {
        //        string currentline = "";
        //        //循环接收串口中的数据
        //        while (MyportRec.BytesToRead > 0)
        //        {
        //            char ch = (char)MyportRec.ReadByte();
        //            currentline += ch.ToString();
        //        }
        //        //MyportRec.DiscardInBuffer();
        //        //MessageBox.Show(currentline);
        //        //在这里对接收到的数据进行显示
        //        //如果不在窗体加载的事件里写上：Form.CheckForIllegalCrossThreadCalls = false; 就会报错）
        //        this.rich_Receive.Text = currentline;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message.ToString());
        //    }
        //}

        //private void btn_Close_Click(object sender, EventArgs e)
        //{
        //    if (MyportSend.IsOpen)
        //    {
        //        MyportSend.Close();
        //    }
        //    if (MyportRec.IsOpen)
        //    {
        //        MyportRec.Close();
        //    }
        //    StatusLabel1.Text = "the port is closed";
        //}
        //private void btn_SendData_Click(object sender, EventArgs e)
        //{
        //    if (!MyportSend.IsOpen)
        //    {
        //        StatusLabel1.Text = "the send port has not been opened";
        //        return;
        //    }
        //    SendCommand(rich_Send.Text);
        //    if (!MyportRec.IsOpen)
        //    {
        //        StatusLabel1.Text = "the receive port has not been opened,you can not view the data sent";
        //        return;
        //    }

        //}
        //public void SendCommand(string CommandString)
        //{
        //    //转换
        //    //串口只能读取ASCII码或者进制数（1，2，3.....的进制，一般是16进制）
        //    byte[] WriteBuffer =new byte[2048];
        //    WriteBuffer = Encoding.Default.GetBytes(CommandString);
        //    //将数据缓冲区的数据写入到串口端口
        //    MyportSend.Write(WriteBuffer, 0, WriteBuffer.Length);
        //}
        //private void OpenSendPort()
        //{
        //    if (!MyportSend.IsOpen)
        //    {
        //        MyportSend.PortName = cbox_PortName.Text;
        //    }
        //    //设置比特率
        //    if (cbox_Baud.SelectedIndex == -1)
        //    {
        //        StatusLabel1.Text = "请确认比特率";
        //        return;
        //    }
        //    MyportSend.BaudRate = Convert.ToInt32(cbox_Baud.Text);
        //    if (cbox_Parity.SelectedIndex == -1)
        //    {
        //        StatusLabel1.Text = "请确认奇偶校验位";
        //        return;
        //    }
        //    if (cbox_Parity.SelectedIndex == 0)
        //        MyportSend.Parity = Parity.Even;
        //    if (cbox_Parity.SelectedIndex == 1)
        //        MyportSend.Parity = Parity.Mark;
        //    if (cbox_Parity.SelectedIndex == 2)
        //        MyportSend.Parity = Parity.None;
        //    if (cbox_Parity.SelectedIndex == 3)
        //        MyportSend.Parity = Parity.Odd;
        //    if (cbox_Parity.SelectedIndex == 4)
        //        MyportSend.Parity = Parity.Space;

        //    //设置数据位
        //    if (cbox_Bits.SelectedIndex == -1)
        //    {
        //        StatusLabel1.Text = "请确认数据位";
        //        return;
        //    }
        //    MyportSend.DataBits = Convert.ToInt32(cbox_Bits.Text);
        //    //根据选择的数据，设置停止位
        //    if (cbox_Stop.SelectedIndex == -1)
        //    {
        //        StatusLabel1.Text = "请确认停止位";
        //        return;
        //    }
        //    if (cbox_Stop.SelectedIndex == 0)
        //        MyportSend.StopBits = StopBits.One;
        //    if (cbox_Stop.SelectedIndex == 1)
        //        MyportSend.StopBits = StopBits.OnePointFive;
        //    if (cbox_Stop.SelectedIndex == 2)
        //        MyportSend.StopBits = StopBits.Two;

        //    //根据选择的数据，设置奇偶校验位

        //    //此委托应该是异步获取数据的触发事件，即是：当有串口有数据传过来时触发
        //    //MyportSend.DataReceived += new SerialDataReceivedEventHandler(RecPort_DataReceived);//DataReceived事件委托
        //    //打开串口的方法
        //    try
        //    {
        //        MyportSend.Open();
        //        if (MyportSend.IsOpen)
        //        {
        //            //MessageBox.Show("the port is opened!");
        //            StatusLabel1.Text = "send port is opened";
        //        }
        //        else
        //        {
        //            StatusLabel1.Text = "failure to open send port!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("failure to open send port!" + ex.ToString());
        //    }

        //}
        //private void OpenRecPort()
        //{
        //    if (!MyportRec.IsOpen)
        //    {
        //        MyportRec.PortName = cbox_PortName.Text;
        //    }
        //    //设置比特率
        //    if (cbox_Baud.SelectedIndex == -1)
        //    {
        //        StatusLabel1.Text = "请确认比特率";
        //        return;
        //    }
        //    MyportRec.BaudRate = Convert.ToInt32(cbox_Baud.Text);
        //    if (cbox_Parity.SelectedIndex == -1)
        //    {
        //        StatusLabel1.Text = "请确认奇偶校验位";
        //        return;
        //    }
        //    if (cbox_Parity.SelectedIndex == 0)
        //        MyportRec.Parity = Parity.Even;
        //    if (cbox_Parity.SelectedIndex == 1)
        //        MyportRec.Parity = Parity.Mark;
        //    if (cbox_Parity.SelectedIndex == 2)
        //        MyportRec.Parity = Parity.None;
        //    if (cbox_Parity.SelectedIndex == 3)
        //        MyportRec.Parity = Parity.Odd;
        //    if (cbox_Parity.SelectedIndex == 4)
        //        MyportRec.Parity = Parity.Space;

        //    //设置数据位
        //    if (cbox_Bits.SelectedIndex == -1)
        //    {
        //        StatusLabel1.Text = "请确认数据位";
        //        return;
        //    }
        //    MyportRec.DataBits = Convert.ToInt32(cbox_Bits.Text);
        //    //根据选择的数据，设置停止位
        //    if (cbox_Stop.SelectedIndex == -1)
        //    {
        //        StatusLabel1.Text = "请确认停止位";
        //        return;
        //    }
        //    if (cbox_Stop.SelectedIndex == 0)
        //        MyportRec.StopBits = StopBits.One;
        //    if (cbox_Stop.SelectedIndex == 1)
        //        MyportRec.StopBits = StopBits.OnePointFive;
        //    if (cbox_Stop.SelectedIndex == 2)
        //        MyportRec.StopBits = StopBits.Two;

        //    //根据选择的数据，设置奇偶校验位

        //    //此委托应该是异步获取数据的触发事件，即是：当有串口有数据传过来时触发
        //    MyportRec.DataReceived -= new SerialDataReceivedEventHandler(RecPort_DataReceived);
        //    MyportRec.DataReceived += new SerialDataReceivedEventHandler(RecPort_DataReceived);//DataReceived事件委托
        //    //打开串口的方法
        //    try
        //    {
        //        MyportRec.Open();
        //        if (MyportRec.IsOpen)
        //        {
        //            //MessageBox.Show("the port is opened!");
        //            StatusLabel1.Text = "receive port is opened";
        //        }
        //        else
        //        {
        //            StatusLabel1.Text = "failure to open receive port!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("failure to open receive port!" + ex.ToString());
        //    }

        //}

        //private void btn_Open_Click_1(object sender, EventArgs e)
        //{

        //}
    }
}
