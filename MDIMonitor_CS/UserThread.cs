using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Xml.Linq;
using System.Xml;
using System.Management;
using System.Timers;
using System.Data.SQLite;
using System.IO;
namespace MDIMonitor_CS
{
    public class UserThread
    {
        SerialPort portSensor = null;
        SerialPort portPhone = null;
        private bool portSensor_ShouldOpen = false;
        private bool portPhone_ShouldOpen = false;
        private bool PhoneDataRecFuncSetted = false;
        private bool SensorDataRecFuncSetted = false;
        private int[] portPhoneAttribute = new int[4];
        private int[] portSensorAttribute = new int[4];
        private SQLiteConnection dataBase = null;
        private SQLiteCommand sqlCommand = null;
        private static string xmlName;
        public int totalNodeCount = 0;
        public int[] nodeChNum = null;
        public int ScanTimeStep = 2000;//默认延时2s间隔遍历节点一次
        public int delayTime = 500;//默认延时0.5s间隔扫描每个节点
        private bool end = false;//结束线程标志
        private bool kill = false;//终结线程标志
        private bool stop = false;//暂停线程标志
        private Thread thread = null;
        private Queue<int> msgQueue = null;//存储消息队列
        public bool auto_measure = false;
        FrameWin Parent = null;//用于传入其他线程句柄，一般通过线程刷新某个窗口UI,FrameWin是需要控制的窗口类，自行修改

        public UserThread(Form parent)
        {
            Parent = (FrameWin)parent;//强制转换
            xmlName = "config.xml";
            msgQueue = new Queue<int>();
            dataBase = new SQLiteConnection();
            sqlCommand = new SQLiteCommand();
            thread = new Thread(new ThreadStart(Run));//真正定义线程
            nodeChNum = new int[4];
            UpdateXml();
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
                        case 10:
                            {
                                msgFunction_10();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        case 11:
                            {
                                msgFunction_11();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        case 12:
                            {
                                msgFunction_12();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        case 13:
                            {
                                msgFunction_13();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
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

        #region 设置测量端口
        private bool SetSensorPort()
        {
            if (!portSensor.IsOpen)
            {
                if (Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex == -1)
                    return false;
                portSensor.PortName = Parent.SerialForm.cbox_Sensor_PortName.Text;
            }
            else
            {
                Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(portSensor.PortName);
                if (Parent.SerialForm.cbox_Phone_PortName.Text == Parent.SerialForm.cbox_Sensor_PortName.Text)
                {
                    if (portPhone.IsOpen)
                    {
                        Parent.statusLabel.Text = "手机端口与测量端口不能相同";
                        return false;
                    }
                }
            }

            int[] tempPortSensorAttribute = new int[4];
            tempPortSensorAttribute[0] = Parent.SerialForm.cbox_Sensor_Baud.SelectedIndex;//比特率
            tempPortSensorAttribute[1] = Parent.SerialForm.cbox_Sensor_Parity.SelectedIndex;//校验位
            tempPortSensorAttribute[2] = Parent.SerialForm.cbox_Sensor_Bits.SelectedIndex;//数据位
            tempPortSensorAttribute[3] = Parent.SerialForm.cbox_Sensor_Stop.SelectedIndex;//停止位
            for (int i = 0; i < 4; i++)
            {
                if (tempPortSensorAttribute[i] == -1)
                {
                    if (i == 0)
                    {
                        Parent.statusLabel.Text = "请确认测量端口比特率";
                        return false;
                    }
                    if (i == 1)
                    {
                        Parent.statusLabel.Text = "请确认测量端口奇偶校验位";
                        return false;
                    }
                    if (i == 2)
                    {
                        Parent.statusLabel.Text = "请确认测量端口数据位";
                        return false;
                    }
                    if (i == 3)
                    {
                        Parent.statusLabel.Text = "请确认测量端口停止位";
                        return false;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    portSensor.BaudRate = Convert.ToInt32(Parent.SerialForm.cbox_Sensor_Baud.SelectedItem.ToString());
                }
                if (i == 1)
                {
                    if (tempPortSensorAttribute[i] == 0)
                        portSensor.Parity = Parity.Even;
                    if (tempPortSensorAttribute[i] == 1)
                        portSensor.Parity = Parity.Mark;
                    if (tempPortSensorAttribute[i] == 2)
                        portSensor.Parity = Parity.None;
                    if (tempPortSensorAttribute[i] == 3)
                        portSensor.Parity = Parity.Odd;
                    if (tempPortSensorAttribute[i] == 4)
                        portSensor.Parity = Parity.Space;
                }
                if (i == 2)
                {
                    portSensor.DataBits = Convert.ToInt32(Parent.SerialForm.cbox_Sensor_Bits.SelectedItem.ToString());
                }
                if (i == 3)
                {
                    if (tempPortSensorAttribute[i] == 0)
                        portSensor.StopBits = StopBits.One;
                    if (tempPortSensorAttribute[i] == 1)
                        portSensor.StopBits = StopBits.OnePointFive;
                    if (tempPortSensorAttribute[i] == 2)
                        portSensor.StopBits = StopBits.Two;
                }
            }
            portSensor.ReceivedBytesThreshold = 1;
            portSensor.ReadBufferSize = 2048;
            portSensor.WriteBufferSize = 2048;

            //根据选择的数据，设置奇偶校验位

            //此委托应该是异步获取数据的触发事件，即是：当有串口有数据传过来时触发
            //if (!SensorDataRecFuncSetted)
            //{
            //    portSensor.DataReceived += new SerialDataReceivedEventHandler(SensorRecFun);//DataPhoneeived事件委托
            //    SensorDataRecFuncSetted = !SensorDataRecFuncSetted;
            //}
            //打开串口的方法
            try
            {
                if (portSensor_ShouldOpen)
                {
                    if (!portSensor.IsOpen)
                        portSensor.Open();
                }
                else
                {
                    this.Parent.statusLabel.Text = "设置已生效";
                    portSensorAttribute[0] = Parent.SerialForm.cbox_Sensor_Baud.SelectedIndex;//比特率
                    portSensorAttribute[1] = Parent.SerialForm.cbox_Sensor_Parity.SelectedIndex;//校验位
                    portSensorAttribute[2] = Parent.SerialForm.cbox_Sensor_Bits.SelectedIndex;//数据位
                    portSensorAttribute[3] = Parent.SerialForm.cbox_Sensor_Stop.SelectedIndex;//停止位
                    string COM_id = "Sensor";
                    setXmlValue("COM", "id", COM_id, "Last_id", portSensor.PortName);
                    setXmlValue("COM", "id", COM_id, "Baud", tempPortSensorAttribute[0].ToString());
                    setXmlValue("COM", "id", COM_id, "Parity", tempPortSensorAttribute[1].ToString());
                    setXmlValue("COM", "id", COM_id, "Bits", tempPortSensorAttribute[2].ToString());
                    setXmlValue("COM", "id", COM_id, "Stop", tempPortSensorAttribute[3].ToString());
                    return true;
                }
                if (portSensor_ShouldOpen && portSensor.IsOpen)
                {
                    //MessageBox.Show("the port is opened!");
                    this.Parent.statusLabel.Text = "测量端口已开启";
                    portSensorAttribute[0] = Parent.SerialForm.cbox_Sensor_Baud.SelectedIndex;//比特率
                    portSensorAttribute[1] = Parent.SerialForm.cbox_Sensor_Parity.SelectedIndex;//校验位
                    portSensorAttribute[2] = Parent.SerialForm.cbox_Sensor_Bits.SelectedIndex;//数据位
                    portSensorAttribute[3] = Parent.SerialForm.cbox_Sensor_Stop.SelectedIndex;//停止位
                    string COM_id = "Sensor";
                    setXmlValue("COM", "id", COM_id, "Last_id", portSensor.PortName);
                    setXmlValue("COM", "id", COM_id, "Baud", tempPortSensorAttribute[0].ToString());
                    setXmlValue("COM", "id", COM_id, "Parity", tempPortSensorAttribute[1].ToString());
                    setXmlValue("COM", "id", COM_id, "Bits", tempPortSensorAttribute[2].ToString());
                    setXmlValue("COM", "id", COM_id, "Stop", tempPortSensorAttribute[3].ToString());
                    return true;
                }
                else
                {
                    this.Parent.statusLabel.Text = "测量端口开启失败";
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("测量端口开启失败：" + ex.ToString());
                return false;
            }

        }
        #endregion

        #region 设置手机端口
        private bool SetPhonePort()
        {
            if (!portPhone.IsOpen)
            {
                if (Parent.SerialForm.cbox_Phone_PortName.SelectedIndex == -1)
                    return false;
                portPhone.PortName = Parent.SerialForm.cbox_Phone_PortName.Text;
            }
            else
            {
                Parent.SerialForm.cbox_Phone_PortName.SelectedIndex = Parent.SerialForm.cbox_Phone_PortName.FindString(portPhone.PortName);
                if (Parent.SerialForm.cbox_Phone_PortName.Text == Parent.SerialForm.cbox_Sensor_PortName.Text)
                {
                    if (portSensor.IsOpen)
                    {
                        Parent.statusLabel.Text = "手机端口与测量端口不能相同";
                        return false;
                    }
                }
            }

            int[] tempPortPhoneAttribute = new int[4];//临时存储属性
            tempPortPhoneAttribute[0] = Parent.SerialForm.cbox_Phone_Baud.SelectedIndex;//比特率
            tempPortPhoneAttribute[1] = Parent.SerialForm.cbox_Phone_Parity.SelectedIndex;//校验位
            tempPortPhoneAttribute[2] = Parent.SerialForm.cbox_Phone_Bits.SelectedIndex;//数据位
            tempPortPhoneAttribute[3] = Parent.SerialForm.cbox_Phone_Stop.SelectedIndex;//停止位
            for (int i = 0; i < 4; i++)
            {
                if (tempPortPhoneAttribute[i] == -1)
                {
                    if (i == 0)
                    {
                        Parent.statusLabel.Text = "请确认手机端口比特率";
                        return false;
                    }
                    if (i == 1)
                    {
                        Parent.statusLabel.Text = "请确认手机端口奇偶校验位";
                        return false;
                    }
                    if (i == 2)
                    {
                        Parent.statusLabel.Text = "请确认手机端口数据位";
                        return false;
                    }
                    if (i == 3)
                    {
                        Parent.statusLabel.Text = "请确认手机端口停止位";
                        return false;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    portPhone.BaudRate = Convert.ToInt32(Parent.SerialForm.cbox_Phone_Baud.SelectedItem.ToString());
                }
                if (i == 1)
                {
                    if (tempPortPhoneAttribute[i] == 0)
                        portPhone.Parity = Parity.Even;
                    if (tempPortPhoneAttribute[i] == 1)
                        portPhone.Parity = Parity.Mark;
                    if (tempPortPhoneAttribute[i] == 2)
                        portPhone.Parity = Parity.None;
                    if (tempPortPhoneAttribute[i] == 3)
                        portPhone.Parity = Parity.Odd;
                    if (tempPortPhoneAttribute[i] == 4)
                        portPhone.Parity = Parity.Space;
                }
                if (i == 2)
                {
                    portPhone.DataBits = Convert.ToInt32(Parent.SerialForm.cbox_Phone_Bits.SelectedItem.ToString());
                }
                if (i == 3)
                {
                    if (tempPortPhoneAttribute[i] == 0)
                        portPhone.StopBits = StopBits.One;
                    if (tempPortPhoneAttribute[i] == 1)
                        portPhone.StopBits = StopBits.OnePointFive;
                    if (tempPortPhoneAttribute[i] == 2)
                        portPhone.StopBits = StopBits.Two;
                }
            }
            portPhone.ReceivedBytesThreshold = 1;
            portPhone.ReadBufferSize = 2048;
            portPhone.WriteBufferSize = 2048;
            portPhone.Encoding = System.Text.Encoding.ASCII;

            //根据选择的数据，设置奇偶校验位

            //此委托应该是异步获取数据的触发事件，即是：当有串口有数据传过来时触发
            //portPhone.DataPhoneeived -= new SerialDataPhoneeivedEventHandler(PhonePort_DataPhoneeived);
            if (!PhoneDataRecFuncSetted)
            {
                portPhone.DataReceived += new SerialDataReceivedEventHandler(PhoneRecFun);//DataPhoneeived事件委托
                PhoneDataRecFuncSetted = !PhoneDataRecFuncSetted;
            }
            //打开串口的方法
            try
            {
                if (portPhone_ShouldOpen)
                {
                    if (!portPhone.IsOpen)
                        portPhone.Open();
                }
                else
                {
                    this.Parent.statusLabel.Text = "设置已生效";
                    portPhoneAttribute[0] = Parent.SerialForm.cbox_Phone_Baud.SelectedIndex;//比特率
                    portPhoneAttribute[1] = Parent.SerialForm.cbox_Phone_Parity.SelectedIndex;//校验位
                    portPhoneAttribute[2] = Parent.SerialForm.cbox_Phone_Bits.SelectedIndex;//数据位
                    portPhoneAttribute[3] = Parent.SerialForm.cbox_Phone_Stop.SelectedIndex;//停止位
                    string COM_id = "Phone";
                    setXmlValue("COM", "id", COM_id, "Last_id", portPhone.PortName);
                    setXmlValue("COM", "id", COM_id, "Baud", tempPortPhoneAttribute[0].ToString());
                    setXmlValue("COM", "id", COM_id, "Parity", tempPortPhoneAttribute[1].ToString());
                    setXmlValue("COM", "id", COM_id, "Bits", tempPortPhoneAttribute[2].ToString());
                    setXmlValue("COM", "id", COM_id, "Stop", tempPortPhoneAttribute[3].ToString());
                    return true;
                }
                if (portPhone_ShouldOpen && portPhone.IsOpen)
                {
                    //MessageBox.Show("the port is opened!");
                    this.Parent.statusLabel.Text = "通讯端口已开启";
                    portPhoneAttribute[0] = Parent.SerialForm.cbox_Phone_Baud.SelectedIndex;//比特率
                    portPhoneAttribute[1] = Parent.SerialForm.cbox_Phone_Parity.SelectedIndex;//校验位
                    portPhoneAttribute[2] = Parent.SerialForm.cbox_Phone_Bits.SelectedIndex;//数据位
                    portPhoneAttribute[3] = Parent.SerialForm.cbox_Phone_Stop.SelectedIndex;//停止位
                    string COM_id = "Phone";
                    setXmlValue("COM", "id", COM_id, "Last_id", portPhone.PortName);
                    setXmlValue("COM", "id", COM_id, "Baud", tempPortPhoneAttribute[0].ToString());
                    setXmlValue("COM", "id", COM_id, "Parity", tempPortPhoneAttribute[1].ToString());
                    setXmlValue("COM", "id", COM_id, "Bits", tempPortPhoneAttribute[2].ToString());
                    setXmlValue("COM", "id", COM_id, "Stop", tempPortPhoneAttribute[3].ToString());

                    return true;
                }
                else
                {
                    this.Parent.statusLabel.Text = "通讯端口开启失败";
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("通讯端口开启失败：" + ex.ToString());
                return false;
            }

        }
        #endregion

        private void PhoneRecFun(object Sensorer, SerialDataReceivedEventArgs e)
        {
            try
            {
                string currentline = "";
                //循环接收串口中的数据
                byte[] getbuffer = new byte[200];
                int i = 0;
                while (portPhone.BytesToRead > 0)
                {
                    getbuffer[i++] = (byte)portPhone.ReadByte();
                }
                //getbuffer.
                //getbuffer[i]=0;
                //byte[] getbuffer = Encoding.UTF8.GetBytes(currentline);
                currentline = Encoding.Default.GetString((getbuffer));
                currentline.Replace("\n", "");
                currentline.Replace(" ", "");
                currentline.Replace("\r", "");
                currentline.Replace("\0", "");
                if (currentline == "" || currentline.IndexOf("OK") != -1)
                    return;
                if (currentline.IndexOf("+EAIC") >= 0 || currentline.IndexOf("RING") >= 0 || currentline.IndexOf("+CLIP") >= 0)
                {
                    this.Parent.statusLabel_phone.Text = "手机收到来电";
                    return;
                }
                if (currentline.IndexOf("CARRIER") >= 0)
                {
                    this.Parent.statusLabel_phone.Text = "手机来电已挂断";
                    return;
                }
                if (currentline.Substring(0, 6) != "+CISMS")
                {
                    this.Parent.statusLabel_phone.Text = "手机收到非短信指令";
                    return;
                }
                string number = currentline.Substring(10, 11);
                string time = currentline.Substring(22, 16);
                string cmd = currentline.Substring(39);
                this.Parent.statusLabel_phone.Text = string.Format("[{0}]{1}>>{2}",time,number,cmd);
                //PhoneCommand(currentline, "18326077303");
                //ASCIIEncoding AE2 = new ASCIIEncoding();
                //char[] CharArray = AE2.GetChars(getbuffer);
                //foreach (var item in CharArray)
                //{
                //    currentline = currentline + item;
                //}
                //"+CISMS:+8618326077303,17-2-16-20:57:16,ÌÚÑ¶QQ\r\n"腾讯QQ
                //\ucc\uda\ud1\ub6//\u817e\u8baf
                //currentline = Encoding.ASCII.GetString(getbuffer);
                MessageBox.Show(number + "~" + time + "~" + cmd);
                //char[] trimChars = new char[] { '\r', '\t', '\n' };
                //currentline = currentline.Trim(trimChars).ToString();
                //string unicode_sms = currentline.Substring(currentline.LastIndexOf(',') + 1);
                //UnicodeEncoding.
                //    Parent.statusLabel.Text = ;

                //string sms = "";
                //int length = 0;
                //MessageBox.Show(sms);

                //for (int i = 0; ; i++)
                //{
                //    if (length == -1)
                //        break;
                //    length = currentline.IndexOf(',');
                //    sms = sms + currentline.Substring(0, length) + "_";
                //    currentline.Remove(0, length + 1);
                //}
                //MessageBox.Show(sms);
                //if (currentline.IndexOf("+CISMS") != -1)
                //{
                //}
                //+CISMS:+8613866120701,15-12-29-19:35,Cb15_1Ce
                //接收到的信息模板13855170145
                //portPhone.DiscardInBuffer();
                //MessageBox.Show(currentline);
                //在这里对接收到的数据进行显示
                //如果不在窗体加载的事件里写上：Form.CheckForIllegalCrossThreadCalls = false; 就会报错）
                //Parent.CurForm.richText_DataRec.AppendText("[" + DateTime.Now.TimeOfDay.ToString() + "]:" + currentline + "\n");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        /// <summary>
        /// 向手机发送短信
        /// </summary>
        /// <param name="CommandString">短信内容</param>
        /// <param name="phoneNumber">手机号码</param>
        private void PhoneCommand(string CommandString, string phoneNumber)
        {

            ////转换
            ////串口只能读取ASCII码或者进制数（1，2，3.....的进制，一般是16进制）
            //try
            //{, DateTime.Now.ToLongTimeString,phoneNumber, CommandString
            //string str = DateTime.Now.ToLongTimeString;
            //byte[] WriteBuffer = Encoding.Default.GetBytes(String.Format("AT+CMGC={0},3,{1}\r\n", phoneNumber, CommandString));//
            //byte[] WriteBuffer = Encoding.Default.GetBytes(String.Format("ATD{0}\r\n", phoneNumber));
            byte[] WriteBuffer = Encoding.Default.GetBytes(String.Format("AT+CISMSSEND={0},3,{1}\r\n", phoneNumber, CommandString));
            portPhone.Write(WriteBuffer, 0, WriteBuffer.Length);//("AT+CISMSSEND=18326077303,3,你好\r\n"); //AT+CSCA?     //获取短信中心号
            this.Parent.statusLabel_phone.Text = String.Format("[{0}]>>{1}>>【{2}】", DateTime.Now.ToLongTimeString(), phoneNumber, CommandString);
            this.Parent.statusLabel_phone.ToolTipText = this.Parent.statusLabel_phone.Text;
            //this.Parent.statusLabel.Text = "通讯端口未开启";
            Thread.Sleep(500);             //延迟1000毫秒 
            //string response = portPhone.ReadExisting(); //读取串口中返回的数据 
            //string smsCenterNum = null;
            //if (response.Length > 0)
            //{//判断是否有数据返回
            //    smsCenterNum = response.Substring(21, 13);  //对数据进行截取
            //}

            //PDUdecoding sms = new PDUdecoding();
            //string decodedSMS = sms.smsDecodedsms(smsCenterNum, phoneNumber, CommandString);
            //portPhone.Write("AT+CMGS=" + sms.nLength.ToString() + "\r\n");  //发送短信
            //Thread.Sleep(1000);
            //response = portPhone.ReadExisting();
            //string SendState = "";
            //if (response.Length > 0 && response.EndsWith("> "))
            //{
            //    byte[] buf = (Encoding.ASCII.GetBytes(String.Format("{0}\x01a", decodedSMS)));
            //    portPhone.Write(buf, 0, buf.Length);
            //    Thread.Sleep(1000);
            //    response = portPhone.ReadExisting();
            //    if (!response.EndsWith("ERROR\r\n") || !response.EndsWith(""))
            //    {
            //        SendState = "发送成功！";
            //    }
            //    else
            //    {
            //        SendState = "发送失败！";
            //    }
            //}
            //else
            //{
            //    SendState = "对方不在服务区！";
            //}
            //string Result = String.Format("{0},{1},{2}\n\r", phoneNumber, smsCenterNum, SendState);
            //this.Parent.statusLabel.Text = SendState;


        }

        /// <summary>
        /// 扫描测量端口
        /// </summary>
        private void SensorRecFun()//测量端口需主动扫描，因此不委托接收事件
        {
            //if (auto_measure == false)
            //{
            //    Parent.statusLabel.Text = String.Format("自动测量未选中");
            //    return;
            //}
            if (!portSensor.IsOpen)
            {
                Parent.statusLabel.Text = String.Format("测量端口未开启");
                return;
            }
            try
            {
                for (int i = 0; i < totalNodeCount; i++)
                {
                    TakeMeasure485((byte)(i + 1));
                    System.Threading.Thread.Sleep(delayTime);//测量时间间隔

                    int bufferSize = portSensor.ReadBufferSize;
                    byte[] readBuffer = new byte[bufferSize];
                    int bufferLength = portSensor.Read(readBuffer, 0, bufferSize);
                    if (bufferLength == 21)//
                    {
                        //MessageBox.Show("ok");
                        uint CRC16Code = CRC16Caclu(readBuffer, bufferLength - 2);
                        uint rcCRC = (uint)readBuffer[bufferLength - 1];
                        rcCRC = (rcCRC << 8) & 0x0ff00;
                        rcCRC += (uint)readBuffer[bufferLength - 2];
                        if (rcCRC == CRC16Code)
                        {
                            for (int j = 0; j < nodeChNum[i]; j++)
                            {//节点 通道 感应器名称 时间 灵敏度 测量值 单位 位置
                                //System.Threading.Thread.Sleep(2000);//测量时间间隔
                                Parent.statusLabel.Text = String.Format("测量{0}", j);
                                string[] dataUnit = new string[8];
                                dataUnit[0] = String.Format("{0}", i + 1);//节点
                                dataUnit[1] = String.Format("{0}", j + 1);//通道
                                dataUnit[2] = String.Format("名称");//名称
                                dataUnit[3] = String.Format("{0}", DateTime.Now.ToString("HH:mm:ss"));//时间

                                double InitVal = 0.0;
                                double LMD = 0.0;
                                if (this.Parent.UIthread.userDataTable[0].Rows.Count > i && this.Parent.UIthread.userDataTable[0].Columns.Count > j + 1)
                                {
                                    InitVal = Convert.ToDouble(this.Parent.UIthread.userDataTable[0].Rows[i][j + 1]);
                                    LMD = Convert.ToDouble(this.Parent.UIthread.userDataTable[1].Rows[i][j + 1]);
                                }
                                else
                                    this.Parent.statusLabel.Text = "测量配置文件数据不足，按默认值0.0计算，请及时检查";
                                //if(LMD<=0.0)
                                dataUnit[4] = String.Format("{0}", LMD);//灵敏度
                                if (j * 2 + 3 >= bufferSize)
                                {
                                    Parent.statusLabel.Text = String.Format("配置文件通道数多于总线通道数，请更正配置文件");
                                    break;
                                }

                                uint dataValue = readBuffer[j * 2 + 3];
                                dataValue = (dataValue << 8) & 0x0ff00;
                                dataValue = dataValue + readBuffer[j * 2 + 4];
                                //Random ran = new Random();
                                int value = (int)dataValue;
                                double dValue = value - InitVal;
                                if (LMD > 0)
                                    dValue = value / LMD;
                                else
                                    dValue = 0.0;
                                dataUnit[5] = String.Format("{0}", dValue);//测量值
                                dataUnit[6] = String.Format("单位");
                                dataUnit[7] = String.Format("位置");
                                SendDataToChartSQL(dataUnit);//发送扫描数据并存储与打印
                                WarningFunc(dataUnit);
                                //string strview = "";
                                //for (int k = 0; k < 8; k++)
                                //{
                                //    strview += dataUnit[k];
                                //    strview += ",";
                                //}
                                //MessageBox.Show(strview);
                            }
                        }
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message.ToString());
                return;
            }
        }

        private bool WarningFunc(string[] dataUnit)
        {
            int node = Convert.ToInt16(dataUnit[0]);
            int ch = Convert.ToInt16(dataUnit[1]);
            double value = Convert.ToDouble(dataUnit[5]);
            double WarningVal = Convert.ToDouble(this.Parent.UIthread.userDataTable[3].Rows[node - 1][ch]);
            if (value < WarningVal)
            {
                //this.Parent.statusLabel_warning.Text = "无报警信息";
                return false;
            }
            else
            {
                this.Parent.statusLabel_warning.Text = String.Format("节点{0}通道{1}感应器报警，时间{6}，报警限值{2}{3}，实测值{4}{3}，位置{5}", node, ch, WarningVal, dataUnit[6], value, dataUnit[7], dataUnit[3]);
                return true;
            }
            //return false;
        }


        /// <summary>
        /// 向测量端口发送命令
        /// </summary>
        /// <param name="CommandString">命令字符串</param>
        private void SensorCommand(string CommandString)
        {

            //转换
            //串口只能读取ASCII码或者进制数（1，2，3.....的进制，一般是16进制）
            try
            {
                byte[] WriteBuffer = new byte[2048];
                WriteBuffer = Encoding.Default.GetBytes(CommandString);
                //将数据缓冲区的数据写入到串口端口
                portSensor.Write(WriteBuffer, 0, WriteBuffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        ///// <summary>
        ///// 计算CRC16校验码
        ///// </summary>
        ///// <param name="buffer">数据缓存</param>
        ///// <param name="length">数据长度</param>
        ///// <returns></returns>
        //private uint CRC16Caclu(ref uint[] buffer, int length)
        //{
        //    uint checkCode = 0x0ffff;
        //    uint tempCode;
        //    for (int i = 0; i < length; i++)
        //    {
        //        tempCode = buffer[i];
        //        checkCode = checkCode ^ tempCode;
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if ((checkCode & 0x1) == 1)
        //            {
        //                checkCode = checkCode >> 1;
        //                checkCode = checkCode ^ 0x0a001;
        //            }
        //            else
        //                checkCode = checkCode >> 1;
        //        }
        //    }
        //    return checkCode;
        //}

        /// <summary>
        /// 网上找的CRC16校验码计算算法并修改
        /// </summary>
        /// <param name="data">待计算数据</param>
        /// <param name="len">数据长度</param>
        /// <returns>校验码</returns>
        private uint CRC16Caclu(byte[] data, int len)
        {
            uint xda;
            int i, j;
            xda = 0xFFFF;
            for (i = 0; i < len; i++)
            {
                xda ^= data[i];
                for (j = 0; j < 8; j++)
                {
                    if ((xda & 0x01) == 1)
                        xda = (xda >> 1) ^ 0xA001;
                    else
                        xda >>= 1;
                }
            }
            return xda;
        }

        /// <summary>
        /// 测控485网络
        /// </summary>
        /// <param name="addr_id">节点id</param>
        private void TakeMeasure485(byte addr_id)
        {
            byte[] sendDataPack = new byte[2048];
            int packLength = 0;
            sendDataPack[packLength++] = addr_id;
            sendDataPack[packLength++] = 4;
            sendDataPack[packLength++] = 0;
            sendDataPack[packLength++] = 0;
            sendDataPack[packLength++] = 0;
            sendDataPack[packLength++] = 8;
            uint CRC16Code = CRC16Caclu(sendDataPack, packLength);
            sendDataPack[packLength++] = (byte)(CRC16Code & 0x0ff);
            sendDataPack[packLength++] = (byte)((CRC16Code >> 8) & 0x0ff);
            portSensor.Write(sendDataPack, 0, packLength);
            //待继续添加发送数据方法，疑惑是已二进制发送还是16进制发送
        }

        /// <summary>
        /// 返回XMl文件指定元素的指定属性值
        /// </summary>
        /// <param name="xmlElement">指定元素</param>
        /// <param name="elementKey">元素识别键</param>
        /// <param name="keyValue">元素识别键键值</param>
        /// <param name="xmlAttribute">需要获得的元素属性</param>
        /// <returns>返回需要的属性值</returns>
        public static string getXmlValue(string xmlElement, string elementKey, string keyValue, string xmlAttribute)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlName);
            Application.Exit();
            XmlNodeList xnlist = xmlDoc.SelectNodes("//" + xmlElement);
            string str = "";
            foreach (XmlNode xn in xnlist)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.HasAttribute(elementKey))
                {
                    string Key = xe.GetAttribute(elementKey);
                    if (Key == keyValue && xe.HasAttribute(xmlAttribute))
                    {
                        str = xe.GetAttribute(xmlAttribute);
                        break;
                    }
                    //Parent.statusLabel.Text = string.Format("id={0},Parity:{1},DataBits:{2},BaudRate{3}", id, Parity, DataBits, BaudRate);
                }
            }
            return str;
        }

        /// <summary>
        /// 设置XMl文件指定元素的指定属性的值
        /// </summary>
        /// <param name="xmlElement">指定元素</param>
        /// <param name="elementKey">元素识别键</param>
        /// <param name="keyValue">元素识别键键值</param>
        /// <param name="xmlAttribute">需要设置的元素属性</param>
        /// <param name="attributeValue">需要设置的属性值</param>
        public static void setXmlValue(string xmlElement, string elementKey, string keyValue, string xmlAttribute, string attributeValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlName);
            XmlNodeList xnlist = xmlDoc.SelectNodes("//" + xmlElement);
            foreach (XmlNode xn in xnlist)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.HasAttribute(elementKey))
                {
                    string Key = xe.GetAttribute(elementKey);
                    if (Key == keyValue)
                    {
                        xe.SetAttribute(xmlAttribute, attributeValue);
                        xmlDoc.Save(xmlName);
                        break;
                    }
                }
            }
        }

        /// <summary>  
        /// 删除XMl文件指定元素的指定属性的值  
        /// </summary>  
        /// <param name="xmlElement">指定元素</param>  
        /// <param name="xmlAttribute">指定属性</param>  
        /// <param name="xmlValue">指定属性值</param>  
        public static void removeXmlElement(string xmlElement, string elementKey, string keyValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlName);
            XmlNodeList xnlist = xmlDoc.SelectNodes("//" + xmlElement);
            foreach (XmlNode xn in xnlist)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.HasAttribute(elementKey))
                {
                    string Key = xe.GetAttribute(elementKey);
                    if (Key == keyValue)
                    {
                        xe.RemoveChild(xn);
                        xmlDoc.Save(xmlName);
                        break;
                    }
                }
            }
        }

        public void UpdateXml()
        {
            totalNodeCount = Convert.ToInt16(getXmlValue("NODE", "id", "0", "Count"));

            for (int i = 0; i < 4; i++)
            {
                nodeChNum[i] = Convert.ToInt16(getXmlValue("NODE", "id", String.Format("{0}", i + 1), "Count"));
            }

        }
        /// <summary>
        /// 发送扫描到的数据到Chart控件并存储到数据库
        /// </summary>
        /// <param name="datastr">扫描到的节点数据集合</param>
        private void SendDataToChartSQL(string[] datastr)
        {
            Parent.curDataValue = datastr;
            WriteDataToSQL(datastr);
            //
            //Parent.PostMessage(3, 1);//向UI线程发送消息存储数据
            Parent.PostMessage(2, 1);//向UI线程发送消息刷新chart

        }

        /// <summary>
        /// 创建并以以节点号_通道号命名数据库，所有数据库存放在以日期命名的数据文件夹下
        /// 每个数据库内部按时间段将该节点该通道的数据存放在不同的表中，表名称以时间段命名
        /// </summary>
        /// <param name="node">节点号</param>
        /// <param name="ch">通道号</param>
        /// <returns></returns>

        private bool CreateDataSQL(int node, int ch)
        {
            string fileName = String.Format("NODE{0}CH{1}", node, ch);
            string path = "Database";
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
            path = path + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd");
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
            try
            {

                FileInfo DatabaseFile = new FileInfo(path + "\\" + fileName);
                if (!DatabaseFile.Exists)
                {
                    //if (!DatabaseFile.Directory.Exists)
                    //{
                    //    DatabaseFile.Directory.Create();
                    //}
                    SQLiteConnection.CreateFile(DatabaseFile.FullName);
                }
                dataBase = new SQLiteConnection("Data Source=" + path + "\\" + fileName + ";Version=3;");
                dataBase.Open();
                sqlCommand.Connection = dataBase;
                string sqlcmd = null;
                sqlcmd = String.Format("create table if not exists {0} (NUM integer primary key autoincrement, Count integer)", "TableRows");
                sqlCommand.CommandText = sqlcmd;
                sqlCommand.ExecuteNonQuery();
                for (int i = 0; i < 12; i++)//表名字数据对应当天的时间段,每两小时为一个表
                {
                    string tableName = String.Format("_{0}_00_00", (i * 2).ToString().PadLeft(2, '0'));
                    sqlcmd = "create table if not exists " + tableName +
                        "(NUM integer primary key autoincrement, DataTime varchar(50),LMD varchar(20),SensorVal varchar(20),Unit varchar(20),Pos varchar(50))";
                    sqlCommand.CommandText = sqlcmd;
                    sqlCommand.ExecuteNonQuery();
                    sqlcmd = "insert into TableRows (Count) values (0)";
                    sqlCommand.CommandText = sqlcmd;
                    sqlCommand.ExecuteNonQuery();
                }
                dataBase.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return File.Exists(path + "\\" + fileName);
        }


        /// <summary>
        /// 将扫描到的节点数据写入数据库
        /// </summary>
        /// <param name="datastr">8个字符串[节点 通道 感应器名称 时间 灵敏度 测量值 单位 位置]</param>
        /// <returns>是否写入成功</returns>
        public bool WriteDataToSQL(string[] datastr)//
        {
            string fileName = String.Format("NODE{0}CH{1}", datastr[0], datastr[1]);
            string path = "Database";
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
            path = path + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd");
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
            if (!File.Exists(path + "\\" + fileName))
            {
                if (!CreateDataSQL(Convert.ToInt16(datastr[0]), Convert.ToInt16(datastr[1])))
                    return false;
            }
            try
            {
                dataBase = new SQLiteConnection("Data Source=" + path + "\\" + fileName + ";Version=3;");
                dataBase.Open();
                sqlCommand.Connection = dataBase;
                string tableName = String.Format("_{0}_00_00", (Convert.ToInt16(datastr[3].Substring(0, 2)) - (Convert.ToInt16(datastr[3].Substring(0, 2))) % 2).ToString().PadLeft(2, '0'));
                string sqlcmd = String.Format("insert into {0} (DataTime,LMD,SensorVal,Unit,Pos) values ('{1}','{2}','{3}','{4}','{5}')", tableName, datastr[3], datastr[4], datastr[5], datastr[6], datastr[7]);
                sqlCommand.CommandText = sqlcmd;
                sqlCommand.ExecuteNonQuery();
                sqlcmd = String.Format("select Count from TableRows where NUM={0}", ((Convert.ToInt16(datastr[3].Substring(0, 2)) / 2) + 1));
                sqlCommand.CommandText = sqlcmd;
                SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
                string count = null;
                while (sqlReader.Read())
                {
                    count = String.Format("{0}", sqlReader[0]);
                }
                sqlReader.Close();
                if (count != null)
                {
                    sqlcmd = String.Format("update TableRows set Count={0} where NUM={1}", Convert.ToInt16(count) + 1, ((Convert.ToInt16(datastr[3].Substring(0, 2)) / 2) + 1));
                    sqlCommand.CommandText = sqlcmd;
                    sqlCommand.ExecuteNonQuery();
                }
                dataBase.Close();
                Parent.statusLabel.Text = String.Format("数据已写入");
                return true;

            }
            catch (Exception)
            {
                Parent.statusLabel.Text = String.Format("数据写入失败");
                return false;
            }
        }


        private void msgFunction_1()//对应消息码为1的时要执行的函数
        {
            if (portSensor.IsOpen)
            {
                SensorRecFun();
                if (!auto_measure)
                    Parent.statusLabel.Text = "单次扫描测量端口成功";
                else
                    Parent.statusLabel.Text = "自动扫描测量端口中...";
            }
            else
            {
                Parent.statusLabel.Text = "测量端口未开启";
            }
        }
        private void msgFunction_2()//对应消息码为2的时要执行的函数
        {
            for (int i = 0; i < 1; i++)
            {
                Random ran = new Random();
                PhoneCommand(String.Format("你好世界"), "18326077303");//,ran.Next(100000,999999)),//13100716778
            }
        }
        private void msgFunction_3()//对应消息码为3的时要执行的函数
        {
        }
        private void msgFunction_4()//对应消息码为3的时要执行的函数
        {
        }
        private void msgFunction_5()////发送测量数据
        {
            if (!portSensor.IsOpen)
            {
                this.Parent.statusLabel.Text = "测量端口未开启";
                return;
            }
            SensorCommand(Parent.SerialForm.rich_Send.Text);
        }
        private void msgFunction_11()//发送手机数据
        {
            if (!portPhone.IsOpen)
            {
                this.Parent.statusLabel.Text = "通讯端口未开启";
                return;
            }
            string number = "18326077303";
            PhoneCommand(Parent.SerialForm.rich_Send.Text, number);
        }
        private void msgFunction_6()//初始化Serial窗口UI
        {
            portSensor = new SerialPort();
            portPhone = new SerialPort();
            //让壮态栏控件的宽度与显示器的分辨率宽度一致
            //this.Parent.this.m_ParentForm.statusLabel.Text = "就绪";
            //实例化
            //这里需要添加引用Microsoft.VisualBasic的引用，提供操作计算机组件（如：音频，时钟，键盘文件系统等）的属性
            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            //循环该计算机上所有串行端口的集合
            #region Sensor控件初始化
            this.Parent.SerialForm.check_SensorPort.Checked = portSensor_ShouldOpen;
            //Parent.SerialForm.cbox_Sensor_PortName.Enabled = false;
            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Sensor_PortName.Items.Add(s);
            }
            if (pc.Ports.SerialPortNames.Contains(getXmlValue("COM", "id", "Sensor", "Last_id")))
            {
                Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(getXmlValue("COM", "id", "Sensor", "Last_id"));
            }
            Parent.SerialForm.cbox_Sensor_Bits.Items.Add("5");
            Parent.SerialForm.cbox_Sensor_Bits.Items.Add("7");
            Parent.SerialForm.cbox_Sensor_Bits.Items.Add("8");
            Parent.SerialForm.cbox_Sensor_Bits.SelectedIndex = Convert.ToInt32(getXmlValue("COM", "id", "Sensor", "Bits"));//读取xml参数

            Parent.SerialForm.cbox_Sensor_Baud.Items.AddRange(new object[] {
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
            Parent.SerialForm.cbox_Sensor_Baud.SelectedIndex = Convert.ToInt32(getXmlValue("COM", "id", "Sensor", "Baud"));//读取xml参数

            Parent.SerialForm.cbox_Sensor_Parity.Items.AddRange(new object[] {
            "Even",
            "Mark",
            "None",
            "Odd",
            "Space"});
            Parent.SerialForm.cbox_Sensor_Parity.SelectedIndex = Convert.ToInt32(getXmlValue("COM", "id", "Sensor", "Parity"));//读取xml参数

            Parent.SerialForm.cbox_Sensor_Stop.Items.Add("1");
            Parent.SerialForm.cbox_Sensor_Stop.Items.Add("1.5");
            Parent.SerialForm.cbox_Sensor_Stop.Items.Add("2");
            Parent.SerialForm.cbox_Sensor_Stop.SelectedIndex = Convert.ToInt32(getXmlValue("COM", "id", "Sensor", "Stop"));//读取xml参数

            portSensorAttribute[0] = Convert.ToInt32(getXmlValue("COM", "id", "Sensor", "Baud"));//比特率
            portSensorAttribute[1] = Convert.ToInt32(getXmlValue("COM", "id", "Sensor", "Parity"));//校验位
            portSensorAttribute[2] = Convert.ToInt32(getXmlValue("COM", "id", "Sensor", "Bits"));//数据位
            portSensorAttribute[3] = Convert.ToInt32(getXmlValue("COM", "id", "Sensor", "Stop"));//停止位
            #endregion

            #region Phone控件初始化
            this.Parent.SerialForm.check_PhonePort.Checked = portPhone_ShouldOpen;
            //Parent.SerialForm.cbox_Phone_PortName.Enabled = false;
            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Phone_PortName.Items.Add(s);
            }
            if (pc.Ports.SerialPortNames.Contains(getXmlValue("COM", "id", "Phone", "Last_id")))
            {
                Parent.SerialForm.cbox_Phone_PortName.SelectedIndex = Parent.SerialForm.cbox_Phone_PortName.FindString(getXmlValue("COM", "id", "Phone", "Last_id"));
            }
            Parent.SerialForm.cbox_Phone_Bits.Items.Add("5");
            Parent.SerialForm.cbox_Phone_Bits.Items.Add("7");
            Parent.SerialForm.cbox_Phone_Bits.Items.Add("8");
            Parent.SerialForm.cbox_Phone_Bits.SelectedIndex = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Bits"));//读取xml参数

            Parent.SerialForm.cbox_Phone_Baud.Items.AddRange(new object[] {
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
            Parent.SerialForm.cbox_Phone_Baud.SelectedIndex = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Baud"));//读取xml参数

            Parent.SerialForm.cbox_Phone_Parity.Items.AddRange(new object[] {
            "Even",
            "Mark",
            "None",
            "Odd",
            "Space"});
            Parent.SerialForm.cbox_Phone_Parity.SelectedIndex = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Parity"));//读取xml参数

            Parent.SerialForm.cbox_Phone_Stop.Items.Add("1");
            Parent.SerialForm.cbox_Phone_Stop.Items.Add("1.5");
            Parent.SerialForm.cbox_Phone_Stop.Items.Add("2");
            Parent.SerialForm.cbox_Phone_Stop.SelectedIndex = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Stop"));//读取xml参数

            portPhoneAttribute[0] = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Baud"));//比特率
            portPhoneAttribute[1] = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Parity"));//校验位
            portPhoneAttribute[2] = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Bits"));//数据位
            portPhoneAttribute[3] = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Stop"));//停止位
            #endregion
        }
        private void msgFunction_7()//确认端口修改
        {
            if (SetPhonePort() && SetSensorPort())
                Parent.statusLabel.Text = "端口修改成功";
        }
        private void msgFunction_8()//取消端口修改
        { }
        private void msgFunction_9()//变更Sensor端口开关
        {
            try
            {
                portSensor_ShouldOpen = !portSensor_ShouldOpen;
                if (portSensor.IsOpen && !portSensor_ShouldOpen)
                    portSensor.Close();
                if (!portSensor.IsOpen && portSensor_ShouldOpen)
                {
                    if (!SetSensorPort())
                        portSensor_ShouldOpen = !portSensor_ShouldOpen;
                }
                this.Parent.SerialForm.check_SensorPort.Checked = portSensor_ShouldOpen;
                Parent.SerialForm.cbox_Sensor_PortName.Enabled = !portSensor_ShouldOpen;
                if (!portSensor.IsOpen)
                {
                    Parent.statusLabel.Text = String.Format("测量端口开关已关闭");
                    this.Parent.menu_auto.Enabled = false;
                    //this.Parent.menu_auto.Checked = false;
                }
                else
                {
                    Parent.statusLabel.Text = String.Format("测量端口开关已开启");
                    this.Parent.menu_auto.Enabled = true;
                }
                return;
            }
            catch (Exception)
            {
                Parent.statusLabel.Text = String.Format("测量端口开关变更失败");
                throw;
            }
        }
        private void msgFunction_10()//变更Phone端口开关
        {
            try
            {
                portPhone_ShouldOpen = !portPhone_ShouldOpen;
                if (portPhone.IsOpen && !portPhone_ShouldOpen)
                    portPhone.Close();
                if (!portPhone.IsOpen && portPhone_ShouldOpen)
                {
                    if (!SetPhonePort())
                        portPhone_ShouldOpen = !portPhone_ShouldOpen;
                }
                this.Parent.SerialForm.check_PhonePort.Checked = portPhone_ShouldOpen;
                Parent.SerialForm.cbox_Phone_PortName.Enabled = !portPhone_ShouldOpen;
                if (portPhone.IsOpen)
                    Parent.statusLabel.Text = String.Format("通讯端口开关已开启");
                else
                    Parent.statusLabel.Text = String.Format("通讯端口开关已关闭");
            }
            catch (Exception)
            {
                Parent.statusLabel.Text = String.Format("通讯端口开关变更失败");
                throw;
            }
        }
        private void msgFunction_12()//设置SerialForm窗口控件状态
        {
            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            //循环该计算机上所有串行端口的集合
            Parent.SerialForm.cbox_Sensor_PortName.Items.Clear();
            Parent.SerialForm.cbox_Phone_PortName.Items.Clear();
            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Sensor_PortName.Items.Add(s);
                Parent.SerialForm.cbox_Phone_PortName.Items.Add(s);
            }
            if (pc.Ports.SerialPortNames.Count > 0)
            {
                Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = 0;
                Parent.SerialForm.cbox_Phone_PortName.SelectedIndex = 0;
            }

            Parent.SerialForm.cbox_Phone_Baud.SelectedIndex = portPhoneAttribute[0];//比特率
            Parent.SerialForm.cbox_Phone_Parity.SelectedIndex = portPhoneAttribute[1];//校验位
            Parent.SerialForm.cbox_Phone_Bits.SelectedIndex = portPhoneAttribute[2];//数据位
            Parent.SerialForm.cbox_Phone_Stop.SelectedIndex = portPhoneAttribute[3];//停止位

            Parent.SerialForm.cbox_Sensor_Baud.SelectedIndex = portSensorAttribute[0];//比特率
            Parent.SerialForm.cbox_Sensor_Parity.SelectedIndex = portSensorAttribute[1];//校验位
            Parent.SerialForm.cbox_Sensor_Bits.SelectedIndex = portSensorAttribute[2];//数据位
            Parent.SerialForm.cbox_Sensor_Stop.SelectedIndex = portSensorAttribute[3];//停止位

        }
        private void msgFunction_13()//主动扫描测量节点内数据
        {
        }
    }
}
