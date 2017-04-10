using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace MDIMonitor_CS
{
    public class WarningThread
    {
        public SerialPort portWarn = null;
        private bool portWarn_ShouldOpen = false;
        private bool WarnDataRecFuncSetted = false;
        private int[] portWarnAttribute = new int[4];
        public cmd_buffer Warn_cmd_buffer = new cmd_buffer();
        //cmd_buffer cmd = new cmd_buffer();
        private Queue<cmd_buffer> Warn_cmd_Queue = null;
        int cmd_count = 0;
        public byte[] Warn_back_buffer = new byte[8];
        public int Warn_cmd_id = -1;
        private static string xmlName;
        private bool end = false;//结束线程标志
        private bool kill = false;//终结线程标志
        private bool stop = false;//暂停线程标志
        private Thread thread = null;
        private Queue<int> msgQueue = null;//存储消息队列
        public bool auto_measure = false;
        FrameWin Parent = null;//用于传入其他线程句柄，一般通过线程刷新某个窗口UI,FrameWin是需要控制的窗口类，自行修改

        public WarningThread(Form parent)
        {
            Parent = (FrameWin)parent;//强制转换
            xmlName = "config.xml";
            msgQueue = new Queue<int>();
            Warn_cmd_Queue = new Queue<cmd_buffer>();
            thread = new Thread(new ThreadStart(Run));//真正定义线程
            thread.IsBackground = true;
        }

        ~WarningThread()
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
            Parent.statusLabel.Text = String.Format("结束线程");
        }

        public void Kill()
        {
            kill = true;//如果线程终止，将终止标识设为真，线程将不再执行消息队列中剩余消息
            Parent.statusLabel.Text = String.Format("终止线程");
        }

        public void Stop()
        {
            stop = true;//如果线程暂停，将暂停标识设为真，线程将暂不执行消息队列中剩余消息，
            //但是消息队列仍然在接收消息，一旦线程恢复，继续执行所接收消息
            Parent.statusLabel.Text = String.Format("暂停线程");
        }

        public void Resume()
        {
            stop = false;//如果线程恢复，将恢复标识设为真，线程将继续执行消息队列中剩余消息
            Parent.statusLabel.Text = String.Format("恢复线程");
        }

        #region 消息循环函数
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
                        case 7:
                            {
                                msgFunction_7();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        case 8:
                            {
                                msgFunction_8();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        case 9:
                            {
                                msgFunction_9();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        //case 10:
                        //    {
                        //        msgFunction_10();//例如消息码为2是，执行msgFunction_2()函数
                        //    } break;
                        //case 11:
                        //    {
                        //        msgFunction_11();//例如消息码为2是，执行msgFunction_2()函数
                        //    } break;
                        //case 12:
                        //    {
                        //        msgFunction_12();//例如消息码为2是，执行msgFunction_2()函数
                        //    } break;
                        //case 13:
                        //    {
                        //        msgFunction_13();//例如消息码为2是，执行msgFunction_2()函数
                        //    } break;
                        //case 14:
                        //    {
                        //        msgFunction_14();//例如消息码为2是，执行msgFunction_2()函数
                        //    } break;
                        //case 15:
                        //    {
                        //        msgFunction_15();//例如消息码为2是，执行msgFunction_2()函数
                        //    } break;
                    }
                    msgQueue.Dequeue();//比对完当前消息并执行相应动作后，消息队列扔掉当前消息
                }
                if (msgQueue.Count == 0 && end)//如果线程被结束时当前消息队列中没有消息，将结束此线程
                    //如果当前消息队列中仍有未执行消息，线程将执行完所有消息后结束
                    break;
                //if (auto_measure == true)
                //{
                //    SensorRecFun();
                //    System.Threading.Thread.Sleep(ScanTimeStep);
                //    //Parent.statusLabel.Text = String.Format("自动测量未选中");
                //    //return;
                //}
                System.Threading.Thread.Sleep(1);//每次循环间隔1ms，我还不知道到底有没有必要
            }
        }
        #endregion


        #region 设置报警端口
        private bool SetWarnPort()
        {
            if (!portWarn.IsOpen)
            {
                if (Parent.SerialForm.cbox_Warn_PortName.SelectedIndex == -1)
                    return false;
                portWarn.PortName = Parent.SerialForm.cbox_Warn_PortName.Text;
            }
            else
            {
                Parent.SerialForm.cbox_Warn_PortName.SelectedIndex = Parent.SerialForm.cbox_Warn_PortName.FindString(portWarn.PortName);
                if (Parent.SerialForm.cbox_Phone_PortName.Text == Parent.SerialForm.cbox_Warn_PortName.Text || Parent.SerialForm.cbox_Sensor_PortName.Text == Parent.SerialForm.cbox_Warn_PortName.Text)
                {
                    if (Parent.thread.portPhone.IsOpen || Parent.thread.portSensor.IsOpen)
                    {
                        Parent.statusLabel.Text = "警报端口不能与手机端口或测量端口相同";
                        return false;
                    }
                }
            }

            int[] tempPortWarnAttribute = new int[4];
            tempPortWarnAttribute[0] = Parent.SerialForm.cbox_Warn_Baud.SelectedIndex;//比特率
            tempPortWarnAttribute[1] = Parent.SerialForm.cbox_Warn_Parity.SelectedIndex;//校验位
            tempPortWarnAttribute[2] = Parent.SerialForm.cbox_Warn_Bits.SelectedIndex;//数据位
            tempPortWarnAttribute[3] = Parent.SerialForm.cbox_Warn_Stop.SelectedIndex;//停止位
            for (int i = 0; i < 4; i++)
            {
                if (tempPortWarnAttribute[i] == -1)
                {
                    if (i == 0)
                    {
                        Parent.statusLabel.Text = "请确认警报端口比特率";
                        return false;
                    }
                    if (i == 1)
                    {
                        Parent.statusLabel.Text = "请确认警报端口奇偶校验位";
                        return false;
                    }
                    if (i == 2)
                    {
                        Parent.statusLabel.Text = "请确认警报端口数据位";
                        return false;
                    }
                    if (i == 3)
                    {
                        Parent.statusLabel.Text = "请确认警报端口停止位";
                        return false;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    portWarn.BaudRate = Convert.ToInt32(Parent.SerialForm.cbox_Warn_Baud.SelectedItem.ToString());
                }
                if (i == 1)
                {
                    if (tempPortWarnAttribute[i] == 0)
                        portWarn.Parity = Parity.Even;
                    if (tempPortWarnAttribute[i] == 1)
                        portWarn.Parity = Parity.Mark;
                    if (tempPortWarnAttribute[i] == 2)
                        portWarn.Parity = Parity.None;
                    if (tempPortWarnAttribute[i] == 3)
                        portWarn.Parity = Parity.Odd;
                    if (tempPortWarnAttribute[i] == 4)
                        portWarn.Parity = Parity.Space;
                }
                if (i == 2)
                {
                    portWarn.DataBits = Convert.ToInt32(Parent.SerialForm.cbox_Warn_Bits.SelectedItem.ToString());
                }
                if (i == 3)
                {
                    if (tempPortWarnAttribute[i] == 0)
                        portWarn.StopBits = StopBits.One;
                    if (tempPortWarnAttribute[i] == 1)
                        portWarn.StopBits = StopBits.OnePointFive;
                    if (tempPortWarnAttribute[i] == 2)
                        portWarn.StopBits = StopBits.Two;
                }
            }
            if (!portWarn.IsOpen)
            {
                portWarn.Handshake = Handshake.None;
            }
            //portWarn.ReceivedBytesThreshold = 1;
            //portWarn.ReadBufferSize = 2048;
            //portWarn.WriteBufferSize = 2048;

            //根据选择的数据，设置奇偶校验位

            //此委托应该是异步获取数据的触发事件，即是：当有串口有数据传过来时触发
            if (!WarnDataRecFuncSetted)
            {
                portWarn.DataReceived += new SerialDataReceivedEventHandler(WarnRecFun);//DataPhoneeived事件委托
                WarnDataRecFuncSetted = !WarnDataRecFuncSetted;
            }
            //打开串口的方法
            try
            {
                if (portWarn_ShouldOpen)
                {
                    if (!portWarn.IsOpen)
                        portWarn.Open();
                }
                else
                {
                    this.Parent.statusLabel.Text = "设置已生效";
                    portWarnAttribute[0] = Parent.SerialForm.cbox_Warn_Baud.SelectedIndex;//比特率
                    portWarnAttribute[1] = Parent.SerialForm.cbox_Warn_Parity.SelectedIndex;//校验位
                    portWarnAttribute[2] = Parent.SerialForm.cbox_Warn_Bits.SelectedIndex;//数据位
                    portWarnAttribute[3] = Parent.SerialForm.cbox_Warn_Stop.SelectedIndex;//停止位
                    string COM_id = "Warn";
                    UserThread.setXmlValue("COM", "id", COM_id, "Last_id", portWarn.PortName);
                    UserThread.setXmlValue("COM", "id", COM_id, "Baud", tempPortWarnAttribute[0].ToString());
                    UserThread.setXmlValue("COM", "id", COM_id, "Parity", tempPortWarnAttribute[1].ToString());
                    UserThread.setXmlValue("COM", "id", COM_id, "Bits", tempPortWarnAttribute[2].ToString());
                    UserThread.setXmlValue("COM", "id", COM_id, "Stop", tempPortWarnAttribute[3].ToString());
                    return true;
                }
                if (portWarn_ShouldOpen && portWarn.IsOpen)
                {
                    //MessageBox.Show("the port is opened!");
                    this.Parent.statusLabel.Text = "警报端口已开启";
                    portWarnAttribute[0] = Parent.SerialForm.cbox_Warn_Baud.SelectedIndex;//比特率
                    portWarnAttribute[1] = Parent.SerialForm.cbox_Warn_Parity.SelectedIndex;//校验位
                    portWarnAttribute[2] = Parent.SerialForm.cbox_Warn_Bits.SelectedIndex;//数据位
                    portWarnAttribute[3] = Parent.SerialForm.cbox_Warn_Stop.SelectedIndex;//停止位
                    string COM_id = "Warn";
                    UserThread.setXmlValue("COM", "id", COM_id, "Last_id", portWarn.PortName);
                    UserThread.setXmlValue("COM", "id", COM_id, "Baud", tempPortWarnAttribute[0].ToString());
                    UserThread.setXmlValue("COM", "id", COM_id, "Parity", tempPortWarnAttribute[1].ToString());
                    UserThread.setXmlValue("COM", "id", COM_id, "Bits", tempPortWarnAttribute[2].ToString());
                    UserThread.setXmlValue("COM", "id", COM_id, "Stop", tempPortWarnAttribute[3].ToString());
                    return true;
                }
                else
                {
                    this.Parent.statusLabel.Text = "警报端口开启失败";
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("警报端口开启失败：" + ex.ToString());
                return false;
            }

        }
        #endregion



        private void WarnRecFun(object Sensorer, SerialDataReceivedEventArgs e)
        {
            return;
            if (portWarn.IsOpen == false)
            {
                Parent.statusLabel.Text = "警报端口未开启";
                return;
            }
            try
            {
                string currentline = "";
                //循环接收串口中的数据
                byte[] getbuffer = new byte[200];
                int i = 0;
                while (portWarn.BytesToRead > 0)
                {
                    getbuffer[i++] = (byte)portWarn.ReadByte();
                }
                for (i = 0; i < 8; i++)
                {
                    Warn_back_buffer[i] = getbuffer[i];
                }
                currentline = Encoding.Default.GetString((getbuffer));
                //currentline.Replace("\n", "");
                //currentline.Replace(" ", "");
                //currentline.Replace("\r", "");
                //currentline.Replace("\t", "");
                //currentline.Replace("\0", "");
                //Parent.statusLabel.Text = String.Format("返回值:[{0}]",currentline);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void msgFunction_1()//修改报警端口
        {
            SetWarnPort();
            //if(!SetWarnPort())
            //    Parent.statusLabel.Text = "报警端口修改失败";
        }

        private void msgFunction_2()//变更报警端口开关
        {
            try
            {
                portWarn_ShouldOpen = !portWarn_ShouldOpen;
                if (portWarn.IsOpen && !portWarn_ShouldOpen)
                {
                    this.Parent.SerialForm.WarnOpen = false;

                    this.Parent.SerialForm.check_light.Checked = false;
                    this.Parent.SerialForm.check_circulate.Checked = true;
                    this.Parent.SerialForm.cbox_warnlist.SelectedIndex = 6;
                    this.Parent.SerialForm.trackBar_vol.Value = 1;

                    this.Parent.SerialForm.trackBar_vol.Enabled = false;
                    this.Parent.SerialForm.check_light.Enabled = false;
                    this.Parent.SerialForm.check_circulate.Enabled = false;
                    this.Parent.SerialForm.cbox_warnlist.Enabled = false;
                    //Warn_cmd_buffer.buffer[5] = 0x06;//循环静音
                    //Warn_cmd_buffer.buffer[6] = 0x01;//闪光关
                    Warn_cmd_Queue.Clear();
                    Warn_cmd_buffer = new cmd_buffer();
                    Warn_cmd_buffer.buffer[5] = 0x06;
                    Warn_cmd_buffer.buffer[6] = 0x01;
                    portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
                    //Thread.Sleep(200);
                    //msgFunction_4();
                    //msgFunction_3();
                    //this.PostMessage(15);//向端口发送声音初始化指令
                    Thread.Sleep(20);
                    portWarn.Close();

                }
                if (!portWarn.IsOpen && portWarn_ShouldOpen)
                {
                    if (!SetWarnPort())
                        portWarn_ShouldOpen = !portWarn_ShouldOpen;
                }
                //this.Parent.SerialForm.check_WarnPort.Checked = portWarn_ShouldOpen;
                Parent.SerialForm.cbox_Warn_PortName.Enabled = !portWarn_ShouldOpen;
                if (!portWarn.IsOpen)
                {

                    Parent.statusLabel.Text = String.Format("警报端口已关闭");
                    //this.Parent.menu_auto.Enabled = false;
                    //this.Parent.menu_auto.Checked = false;
                }
                else
                {
                    //byte[] tempWarn_cmd = Warn_cmd_buffer.buffer;
                    //byte buffer3 = Warn_cmd_buffer.buffer[3];
                    //byte buffer5 = Warn_cmd_buffer.buffer[5];
                    //byte buffer6 = Warn_cmd_buffer.buffer[6];
                    //Warn_cmd_buffer.buffer[3] = 0x06;
                    //Warn_cmd_buffer.buffer[5] = 0x00;
                    //Warn_cmd_buffer.buffer[6] = (byte)(this.Parent.SerialForm.trackBar_vol.Value);
                    ////this.PostMessage(15);//向端口发送声音指令
                    //msgFunction_4();
                    //msgFunction_3();
                    //Thread.Sleep(20);
                    //Warn_cmd_buffer.buffer[3] = buffer3;
                    //Warn_cmd_buffer.buffer[5] = buffer5;
                    //Warn_cmd_buffer.buffer[6] = buffer6;

                    //Warn_cmd_buffer.buffer[6] = 0x01;//闪光关
                    //Warn_cmd_buffer.buffer[5] = 0x06;//一次静音
                    this.Parent.SerialForm.WarnOpen = true;

                    this.Parent.SerialForm.check_light.Enabled = true;
                    this.Parent.SerialForm.check_circulate.Enabled = true;
                    this.Parent.SerialForm.cbox_warnlist.Enabled = true;
                    this.Parent.SerialForm.trackBar_vol.Enabled = true;

                    this.Parent.SerialForm.trackBar_vol.Value = 1;
                    this.Parent.SerialForm.check_light.Checked = true;
                    this.Parent.SerialForm.check_circulate.Checked = true;
                    this.Parent.SerialForm.cbox_warnlist.SelectedIndex = 6;
                    //Warn_cmd_buffer.buffer[3]= 0x06;
                    //Warn_cmd_buffer.buffer[5] = 0x00;
                    //Warn_cmd_buffer.buffer[6] = (byte)this.Parent.SerialForm.trackBar_vol.Value;
                    //this.PostMessage(15);//向端口发送声音初始化指令
                    Warn_cmd_Queue.Clear();
                    Warn_cmd_buffer = new cmd_buffer();
                    Warn_cmd_buffer.buffer[5] = 0x86;
                    Warn_cmd_buffer.buffer[6] = 0x01;
                    portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
                    //msgFunction_4();
                    //msgFunction_3();
                    //portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
                    Parent.statusLabel.Text = String.Format("警报端口已开启");
                    //this.Parent.menu_auto.Enabled = true;
                }
                Thread.Sleep(1000);
                return;
            }
            catch (Exception e)
            {
                Parent.statusLabel.Text = String.Format("警报端口开关变更失败");
                MessageBox.Show(e.Message);
            }
        }

        private void msgFunction_3()//发送报警命令
        {
            if (!portWarn.IsOpen)
            {
                Parent.statusLabel.Text = "警报端口未开启";
                return;
            }
            //if (Warn_back_buffer[3] == 0x70 && Warn_back_buffer[5] == Warn_cmd_buffer.buffer[5] && Warn_back_buffer[6] == Warn_cmd_buffer.buffer[6])
            //    return;
            if (Warn_cmd_Queue.Count == 0)
                return;
            if (Warn_cmd_Queue.Peek().buffer[3] == 0x06)
                portWarn.Write(Warn_cmd_Queue.Peek().buffer, 0, Warn_cmd_Queue.Peek().buffer.Length);
            else
            {
                Warn_cmd_buffer = Warn_cmd_Queue.Peek();
                portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
            }
            Parent.statusLabel.Text = "警报命令已发送";
            Warn_cmd_Queue.Dequeue();
            //Thread.Sleep(20);
        }

        private void msgFunction_4()//更新命令队列
        {
            if(Warn_cmd_Queue.Count >100)
            {
                Parent.statusLabel.Text = "警报命令队列过长，暂停接收";
                return;
            }
            Warn_cmd_Queue.Enqueue(Warn_cmd_buffer);
        }

        private void msgFunction_5()//初始化端口及相关UI
        {
            #region Warn控件初始化
            portWarn = new SerialPort();
            this.Parent.SerialForm.check_WarnPort.Checked = portWarn_ShouldOpen;
            //Parent.SerialForm.cbox_Warn_PortName.Enabled = false;
            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Warn_PortName.Items.Add(s);
            }
            if (pc.Ports.SerialPortNames.Contains(UserThread.getXmlValue("COM", "id", "Warn", "Last_id")))
            {
                Parent.SerialForm.cbox_Warn_PortName.SelectedIndex = Parent.SerialForm.cbox_Warn_PortName.FindString(UserThread.getXmlValue("COM", "id", "Warn", "Last_id"));
            }
            //Parent.SerialForm.cbox_Warn_Bits.Items.Add("1");
            Parent.SerialForm.cbox_Warn_Bits.Items.Add("5");
            Parent.SerialForm.cbox_Warn_Bits.Items.Add("6");
            Parent.SerialForm.cbox_Warn_Bits.Items.Add("7");
            Parent.SerialForm.cbox_Warn_Bits.Items.Add("8");
            Parent.SerialForm.cbox_Warn_Bits.SelectedIndex = Convert.ToInt32(UserThread.getXmlValue("COM", "id", "Warn", "Bits"));//读取xml参数

            Parent.SerialForm.cbox_Warn_Baud.Items.AddRange(new object[] {
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
            Parent.SerialForm.cbox_Warn_Baud.SelectedIndex = Convert.ToInt32(UserThread.getXmlValue("COM", "id", "Warn", "Baud"));//读取xml参数

            Parent.SerialForm.cbox_Warn_Parity.Items.AddRange(new object[] {
            "Even",
            "Mark",
            "None",
            "Odd",
            "Space"});
            Parent.SerialForm.cbox_Warn_Parity.SelectedIndex = Convert.ToInt32(UserThread.getXmlValue("COM", "id", "Warn", "Parity"));//读取xml参数

            Parent.SerialForm.cbox_Warn_Stop.Items.Add("1");
            Parent.SerialForm.cbox_Warn_Stop.Items.Add("1.5");
            Parent.SerialForm.cbox_Warn_Stop.Items.Add("2");
            Parent.SerialForm.cbox_Warn_Stop.SelectedIndex = Convert.ToInt32(UserThread.getXmlValue("COM", "id", "Warn", "Stop"));//读取xml参数

            portWarnAttribute[0] = Convert.ToInt32(UserThread.getXmlValue("COM", "id", "Warn", "Baud"));//比特率
            portWarnAttribute[1] = Convert.ToInt32(UserThread.getXmlValue("COM", "id", "Warn", "Parity"));//校验位
            portWarnAttribute[2] = Convert.ToInt32(UserThread.getXmlValue("COM", "id", "Warn", "Bits"));//数据位
            portWarnAttribute[3] = Convert.ToInt32(UserThread.getXmlValue("COM", "id", "Warn", "Stop"));//停止位
            #endregion
        }

        private void msgFunction_6()//一级报警，不闪灯光
        {
            if (!portWarn.IsOpen)
            {
                Parent.statusLabel_warning.Text = String.Format("[{0}]一级报警已触发，但警报端口未打开", DateTime.Now.ToLongTimeString());
                return;
            }
            Warn_cmd_Queue.Clear();
            Warn_cmd_buffer = new cmd_buffer();
            if (this.Parent.SerialForm.check_circulate.Checked)
            {
                Warn_cmd_buffer.buffer[5] = (byte)(0x80 + this.Parent.SerialForm.cbox_warnlist.SelectedIndex + 1);
            }
            else
            {
                Warn_cmd_buffer.buffer[5] = (byte)(0x00 + this.Parent.SerialForm.cbox_warnlist.SelectedIndex + 1);
            }   
            Warn_cmd_buffer.buffer[6] = 0x01;
            portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
            //msgFunction_4();
            //msgFunction_3();
            //portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
           
            Parent.statusLabel_warning.Text = String.Format("[{0}]一级报警已响应", DateTime.Now.ToLongTimeString());
        }

        private void msgFunction_7()//二级报警，闪烁灯光
        {
            if (!portWarn.IsOpen)
            {
                Parent.statusLabel_warning.Text = String.Format("[{0}]二级报警已触发，但警报端口未打开", DateTime.Now.ToLongTimeString());
                return;
            }
            Warn_cmd_Queue.Clear();
            Warn_cmd_buffer = new cmd_buffer();
            if (this.Parent.SerialForm.check_circulate.Checked)
            {
                Warn_cmd_buffer.buffer[5] = (byte)(0x80 + this.Parent.SerialForm.cbox_warnlist.SelectedIndex + 1);
            }
            else
            {
                Warn_cmd_buffer.buffer[5] = (byte)(0x00 + this.Parent.SerialForm.cbox_warnlist.SelectedIndex + 1);
            }     
            Warn_cmd_buffer.buffer[6] = 0x00;
            portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
            //msgFunction_4();
            //msgFunction_3();
            //portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
            Parent.statusLabel_warning.Text = String.Format("[{0}]二级报警已响应", DateTime.Now.ToLongTimeString());
        }

        private void msgFunction_8()//手机指令报警
        {
            if (!portWarn.IsOpen)
            {
                Parent.statusLabel_warning.Text = String.Format("[{0}]手机远程指令报警，但警报端口未打开", DateTime.Now.ToLongTimeString());
                return;
            }
            Warn_cmd_Queue.Clear();
            Warn_cmd_buffer = new cmd_buffer();
            if (this.Parent.SerialForm.check_circulate.Checked)
            {
                Warn_cmd_buffer.buffer[5] = (byte)(0x80 + this.Parent.SerialForm.cbox_warnlist.SelectedIndex + 1);
            }
            else
            {
                Warn_cmd_buffer.buffer[5] = (byte)(0x00 + this.Parent.SerialForm.cbox_warnlist.SelectedIndex + 1);
            }
            Warn_cmd_buffer.buffer[6] = 0x01;
            portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
            //msgFunction_4();
            //msgFunction_3();
            //portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
            Parent.statusLabel_warning.Text = String.Format("[{0}]手机远程报警指令已响应", DateTime.Now.ToLongTimeString());
        }

        private void msgFunction_9()//手机指令熄警
        {
            if (!portWarn.IsOpen)
            {
                Parent.statusLabel_warning.Text = String.Format("[{0}]手机远程指令熄警，但警报端口未打开", DateTime.Now.ToLongTimeString());
                return;
            }
            Warn_cmd_Queue.Clear();
            Warn_cmd_buffer = new cmd_buffer();
            if (this.Parent.SerialForm.check_circulate.Checked)
            {
                Warn_cmd_buffer.buffer[5] = 0x86;
            }
            else
            {
                Warn_cmd_buffer.buffer[5] = 0x06;
            }
            Warn_cmd_buffer.buffer[6] = 0x01;
            portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
            //msgFunction_4();
            //msgFunction_3();
            //portWarn.Write(Warn_cmd_buffer.buffer, 0, Warn_cmd_buffer.buffer.Length);
            Parent.statusLabel_warning.Text = String.Format("[{0}]手机远程熄警指令已响应", DateTime.Now.ToLongTimeString());
        }
    }
}
