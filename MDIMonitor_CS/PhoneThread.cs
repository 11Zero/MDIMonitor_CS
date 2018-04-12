using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace MDIMonitor_CS
{
    public class PhoneThread
    {
        public System.IO.Ports.SerialPort portPhone = null;
        public int portSensorId = -1;
        private bool portPhone_ShouldOpen = false;
        private bool PhoneDataRecFuncSetted = false;
        //private bool WarnDataRecFuncSetted = false;
        private int[] portPhoneAttribute = new int[4];
        public string[] phone_sms_send = new string[2];
        public int delayTime = 500;//默认延时0.5s间隔扫描每个节点
        private bool end = false;//结束线程标志
        private bool kill = false;//终结线程标志
        private bool stop = false;//暂停线程标志
        private System.Threading.Thread thread = null;
        private Queue<int> msgQueue = null;//存储消息队列
        private Queue<string> msginfoQueue = null;//存储消息队列
        public DateTime warn_time_1 = new DateTime(1970, 1, 1, 0, 0, 0);
        public DateTime warn_time_2 = new DateTime(1970, 1, 1, 0, 0, 0);

        public static string xmlName = null;
        FrameWin Parent = null;//用于传入其他线程句柄，一般通过线程刷新某个窗口UI,FrameWin是需要控制的窗口类，自行修改

        public PhoneThread(Form parent)
        {
            Parent = (FrameWin)parent;//强制转换
            xmlName = "config.xml";
            msgQueue = new Queue<int>();
            msginfoQueue = new Queue<string>();
            thread = new Thread(new ThreadStart(Run));//真正定义线程
            thread.IsBackground = true;
            portPhone = new SerialPort();

        }

        ~PhoneThread()
        {
            this.End();//析构时结束线程
        }

        public void PostMessage(int id, string msginfo)//id为传入的消息标识
        {
            if (end || kill)//如果线程结束或终止，不执行任何动作
                return;
            if (id > 0)
            {
                msgQueue.Enqueue(id);//将post来的消息添加到消息队列
                msginfoQueue.Enqueue(msginfo);//将post来的消息添加到消息队列
            }
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
                                msgFunction_1(msginfoQueue.Peek());//例如消息码为1是，执行msgFunction_1()函数
                            }
                            break;
                        case 2:
                            {
                                msgFunction_2(msginfoQueue.Peek());//例如消息码为2是，执行msgFunction_2()函数
                            }
                            break;
                        case 3:
                            {
                                msgFunction_3();//例如消息码为2是，执行msgFunction_2()函数
                            }
                            break;
                        case 4:
                            {
                                msgFunction_4();//例如消息码为2是，执行msgFunction_2()函数
                            }
                            break;
                        case 5:
                            {
                                msgFunction_5();//例如消息码为2是，执行msgFunction_2()函数
                            }
                            break;
                    }
                    msgQueue.Dequeue();//比对完当前消息并执行相应动作后，消息队列扔掉当前消息
                    msginfoQueue.Dequeue();//比对完当前消息并执行相应动作后，消息队列扔掉当前消息

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
                //if (Parent.SerialForm.cbox_Phone_PortName.SelectedText == Parent.SerialForm.cbox_Sensor_PortName.SelectedText)
                //{
                //    if (portSensor.IsOpen)
                //    {
                //        Parent.statusLabel.Text = "手机端口与测量端口不能相同";
                //        return false;
                //    }
                //}
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
            if (!portPhone.IsOpen)
            {
                portPhone.ReceivedBytesThreshold = 1;
                portPhone.ReadBufferSize = 2048;
                portPhone.WriteBufferSize = 2048;
                portPhone.Encoding = System.Text.Encoding.ASCII;
            }

            //根据选择的数据，设置奇偶校验位

            //此委托应该是异步获取数据的触发事件，即是：当有串口有数据传过来时触发
            //portPhone.DataPhoneeived -= new SerialDataPhoneeivedEventHandler(PhonePort_DataPhoneeived);
            if (!PhoneDataRecFuncSetted)
            {
                portPhone.DataReceived += new SerialDataReceivedEventHandler(PhoneRecFun);//DataPhoneeived事件委托
                //portPhone.DataReceived -= new SerialDataReceivedEventHandler(PhoneRecFun);
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
                    Parent.portPhoneAttribute[0] = Parent.SerialForm.cbox_Phone_Baud.SelectedIndex;//比特率
                    Parent.portPhoneAttribute[1] = Parent.SerialForm.cbox_Phone_Parity.SelectedIndex;//校验位
                    Parent.portPhoneAttribute[2] = Parent.SerialForm.cbox_Phone_Bits.SelectedIndex;//数据位
                    Parent.portPhoneAttribute[3] = Parent.SerialForm.cbox_Phone_Stop.SelectedIndex;//停止位
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
                    Parent.portPhoneAttribute[0] = Parent.SerialForm.cbox_Phone_Baud.SelectedIndex;//比特率
                    Parent.portPhoneAttribute[1] = Parent.SerialForm.cbox_Phone_Parity.SelectedIndex;//校验位
                    Parent.portPhoneAttribute[2] = Parent.SerialForm.cbox_Phone_Bits.SelectedIndex;//数据位
                    Parent.portPhoneAttribute[3] = Parent.SerialForm.cbox_Phone_Stop.SelectedIndex;//停止位
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



        private void PhoneRecFun(object Sensorer, SerialDataReceivedEventArgs e)
        {
            if (portPhone.IsOpen == false)
            {
                Parent.statusLabel.Text = "手机通讯端口未开启";
                return;
            }
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
                currentline.Replace("\t", "");
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
                string time = currentline.Substring(currentline.IndexOf(",") + 1, currentline.LastIndexOf(",") - currentline.IndexOf(",") - 1);
                string cmd = currentline.Substring(currentline.LastIndexOf(",") + 1, currentline.LastIndexOf("\0") - currentline.LastIndexOf(",") - 1);
                this.Parent.UIthread.phone_cmd[0] = number;
                this.Parent.UIthread.phone_cmd[1] = time;
                this.Parent.UIthread.phone_cmd[2] = cmd;
                this.Parent.statusLabel_phone.Text = string.Format("[{0}]{1}>>{2}", time, number, cmd);
                this.Parent.PostMessage(6, 1);//能进行到这一行证明接到短信指令，若能解析，将执行解析并返回信息
                return;

            }
            catch (Exception ex)
            {
                this.Parent.statusLabel.Text = ex.Message;
                return;
            }
        }
        /// <summary>
        /// 向手机发送短信
        /// </summary>
        /// <param name="CommandString">短信内容</param>
        /// <param name="phoneNumber">手机号码</param>
        public void PhoneCommand(string CommandString, string phoneNumber)
        {
            if (portPhone.IsOpen == false)
            {
                Parent.statusLabel.Text = "手机通讯端口未开启";
                return;
            }
            byte[] WriteBuffer = Encoding.Default.GetBytes(String.Format("AT+CISMSSEND={0},3,{1}\r\n", phoneNumber, CommandString));
            portPhone.Write(WriteBuffer, 0, WriteBuffer.Length);//("AT+CISMSSEND=18326077303,3,你好\r\n"); //AT+CSCA?     //获取短信中心号
            this.Parent.statusLabel_phone.Text = String.Format("[{0}]>>{1}>>【{2}】", DateTime.Now.ToLongTimeString(), phoneNumber, CommandString);
            this.Parent.statusLabel_phone.ToolTipText = this.Parent.statusLabel_phone.Text;
            //this.Parent.statusLabel.Text = "通讯端口未开启";
            Thread.Sleep(20);             //延迟1000毫秒 

        }


        private void msgFunction_1(string msginfo)//设置手机端口
        {
            SetPhonePort();
        }
        private void msgFunction_2(string msginfo)//发送短信
        {
            if (portPhone.IsOpen == false)
            {
                Parent.statusLabel.Text = "手机通讯端口未开启";
                return;
            }
            string phonenumber = msginfo.Substring(11);
            string gsmmsg = msginfo.Substring(11, msginfo.Length - 11);
            if (phonenumber.Length == 11 && gsmmsg.Replace(" ", "") != "")
                this.PhoneCommand(gsmmsg, phonenumber);
        }

        private void msgFunction_3()
        {

            #region Phone控件初始化
            Parent.SerialForm.cbox_Phone_PortName.Items.Clear();
            Parent.SerialForm.cbox_Phone_Bits.Items.Clear();
            Parent.SerialForm.cbox_Phone_Parity.Items.Clear();
            Parent.SerialForm.cbox_Phone_Stop.Items.Clear();
            Parent.SerialForm.cbox_Phone_Baud.Items.Clear();
            this.Parent.SerialForm.check_PhonePort.Checked = portPhone_ShouldOpen;
            //Parent.SerialForm.cbox_Phone_PortName.Enabled = false;
            foreach (string s in SerialPort.GetPortNames())//pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Phone_PortName.Items.Add(s);
            }
            //string thisstr = getXmlValue("COM", "id", "Phone", "Last_id");
            if (SerialPort.GetPortNames().Contains(getXmlValue("COM", "id", "Phone", "Last_id")))
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

            Parent.portPhoneAttribute[0] = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Baud"));//比特率
            Parent.portPhoneAttribute[1] = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Parity"));//校验位
            Parent.portPhoneAttribute[2] = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Bits"));//数据位
            Parent.portPhoneAttribute[3] = Convert.ToInt32(getXmlValue("COM", "id", "Phone", "Stop"));//停止位

            #endregion
        }

        private void msgFunction_4()
        {
            this.Parent.PostPhoneMessage(2, this.Parent.SerialForm.text_targetphone.Text + this.Parent.SerialForm.rich_smstext.Text);
        }

        private void msgFunction_5()//变更Phone端口开关
        {
            try
            {
                if (portPhone == null)
                    portPhone = new SerialPort();
                portPhone_ShouldOpen = !portPhone_ShouldOpen;
                if (portPhone.IsOpen && !portPhone_ShouldOpen)
                {
                    portPhone.DataReceived -= new SerialDataReceivedEventHandler(PhoneRecFun);
                    PhoneDataRecFuncSetted = !PhoneDataRecFuncSetted;
                    portPhone.ReadExisting();
                    portPhone.Close();
                }
                if (!portPhone.IsOpen && portPhone_ShouldOpen)
                {
                    if (!SetPhonePort())
                        portPhone_ShouldOpen = !portPhone_ShouldOpen;
                }
                this.Parent.SerialForm.check_PhonePort.Checked = portPhone_ShouldOpen;
                Parent.SerialForm.cbox_Phone_PortName.Enabled = !portPhone_ShouldOpen;
                if (portPhone.IsOpen)
                    Parent.statusLabel.Text = String.Format("通讯端口已开启");
                else
                    Parent.statusLabel.Text = String.Format("通讯端口已关闭");
            }
            catch (Exception)
            {
                Parent.statusLabel.Text = String.Format("通讯端口变更失败");
                throw;
            }
        }
    }
}
