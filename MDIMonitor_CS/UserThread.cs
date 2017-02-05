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
        private static string xmlName;
        private bool end = false;//结束线程标志
        private bool kill = false;//终结线程标志
        private bool stop = false;//暂停线程标志
        private Thread thread = null;//恢复线程标志
        private Queue<int> msgQueue = null;//存储消息队列
        FrameWin Parent = null;//用于传入其他线程句柄，一般通过线程刷新某个窗口UI,FrameWin是需要控制的窗口类，自行修改
        public UserThread(Form parent)
        {
            Parent = (FrameWin)parent;//强制转换
            xmlName = "config.xml";
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
                    }
                    msgQueue.Dequeue();//比对完当前消息并执行相应动作后，消息队列扔掉当前消息
                }
                if (msgQueue.Count == 0 && end)//如果线程被结束时当前消息队列中没有消息，将结束此线程
                    //如果当前消息队列中仍有未执行消息，线程将执行完所有消息后结束
                    break;
                System.Threading.Thread.Sleep(1);//每次循环间隔1ms，我还不知道到底有没有必要
            }
        }
        #endregion

        #region 设置测量端口
        private bool SetSensorPort()
        {
            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            //循环该计算机上所有串行端口的集合
            Parent.SerialForm.cbox_Sensor_PortName.Items.Clear();
            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Sensor_PortName.Items.Add(s);
            }
            if (pc.Ports.SerialPortNames.Count > 0)
            {
                Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = 0;
            }
            else
                return false;

            if (!portSensor.IsOpen)
            {
                portSensor.PortName = Parent.SerialForm.cbox_Sensor_PortName.Text;
            }
            else
            {
                Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(portSensor.PortName);
            }

            string[] portAttribute = new string[4];
            portAttribute[0] = Parent.SerialForm.cbox_Sensor_Baud.Text;//比特率
            portAttribute[1] = Parent.SerialForm.cbox_Sensor_Parity.Text;//校验位
            portAttribute[2] = Parent.SerialForm.cbox_Sensor_Bits.Text;//数据位
            portAttribute[3] = Parent.SerialForm.cbox_Sensor_Stop.Text;//停止位
            for (int i = 0; i < 4; i++)
            {
                if (portAttribute[i] == "")
                {
                    if (i == 0)
                    {
                        Parent.StatusLabel1.Text = "请确认测量端口比特率";
                        return false;
                    }
                    if (i == 1)
                    {
                        Parent.StatusLabel1.Text = "请确认测量端口奇偶校验位";
                        return false;
                    }
                    if (i == 2)
                    {
                        Parent.StatusLabel1.Text = "请确认测量端口数据位";
                        return false;
                    }
                    if (i == 3)
                    {
                        Parent.StatusLabel1.Text = "请确认测量端口停止位";
                        return false;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    portSensor.BaudRate = Convert.ToInt32(portAttribute[i]);
                }
                if (i == 1)
                {
                    if (portAttribute[i] == "0")
                        portSensor.Parity = Parity.Even;
                    if (portAttribute[i] == "1")
                        portSensor.Parity = Parity.Mark;
                    if (portAttribute[i] == "2")
                        portSensor.Parity = Parity.None;
                    if (portAttribute[i] == "3")
                        portSensor.Parity = Parity.Odd;
                    if (portAttribute[i] == "4")
                        portSensor.Parity = Parity.Space;
                }
                if (i == 2)
                {
                    portSensor.DataBits = Convert.ToInt32(portAttribute[i]);
                }
                if (i == 3)
                {
                    if (portAttribute[i] == "1")
                        portSensor.StopBits = StopBits.One;
                    if (portAttribute[i] == "1.5")
                        portSensor.StopBits = StopBits.OnePointFive;
                    if (portAttribute[i] == "2")
                        portSensor.StopBits = StopBits.Two;
                }
            }

            //if (Parent.SerialForm.cbox_Baud.SelectedIndex == -1)
            //{
            //    Parent.StatusLabel1.Text = "请确认比特率";
            //    return;
            //}
            //portSensor.BaudRate = Convert.ToInt32(Parent.SerialForm.cbox_Baud.Text);
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == -1)
            //{
            //    this.Parent.StatusLabel1.Text = "请确认奇偶校验位";
            //    return;
            //}
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == 0)
            //    portSensor.Parity = Parity.Even;
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == 1)
            //    portSensor.Parity = Parity.Mark;
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == 2)
            //    portSensor.Parity = Parity.None;
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == 3)
            //    portSensor.Parity = Parity.Odd;
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == 4)
            //    portSensor.Parity = Parity.Space;

            ////设置数据位
            //if (Parent.SerialForm.cbox_Bits.SelectedIndex == -1)
            //{
            //    this.Parent.StatusLabel1.Text = "请确认数据位";
            //    return;
            //}
            //portSensor.DataBits = Convert.ToInt32(Parent.SerialForm.cbox_Bits.Text);
            ////根据选择的数据，设置停止位
            //if (Parent.SerialForm.cbox_Stop.SelectedIndex == -1)
            //{
            //    this.Parent.StatusLabel1.Text = "请确认停止位";
            //    return;
            //}
            //if (Parent.SerialForm.cbox_Stop.SelectedIndex == 0)
            //    portSensor.StopBits = StopBits.One;
            //if (Parent.SerialForm.cbox_Stop.SelectedIndex == 1)
            //    portSensor.StopBits = StopBits.OnePointFive;
            //if (Parent.SerialForm.cbox_Stop.SelectedIndex == 2)
            //    portSensor.StopBits = StopBits.Two;

            //根据选择的数据，设置奇偶校验位

            //此委托应该是异步获取数据的触发事件，即是：当有串口有数据传过来时触发
            if (!SensorDataRecFuncSetted)
            {
                portSensor.DataReceived += new SerialDataReceivedEventHandler(SensorRecFun);//DataPhoneeived事件委托
                SensorDataRecFuncSetted = !SensorDataRecFuncSetted;
            }
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
                    this.Parent.StatusLabel1.Text = "设置已生效";
                    return true;
                }
                if (portSensor_ShouldOpen && portSensor.IsOpen)
                {
                    //MessageBox.Show("the port is opened!");
                    this.Parent.StatusLabel1.Text = "Sensor port is opened";
                    return true;
                }
                else
                {
                    this.Parent.StatusLabel1.Text = "failure to open Sensor port!";
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failure to open Sensor port!" + ex.ToString());
                return false;
            }

        }
        #endregion

        #region 设置手机端口
        private bool SetPhonePort()
        {
            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            //循环该计算机上所有串行端口的集合
            Parent.SerialForm.cbox_Phone_PortName.Items.Clear();
            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Phone_PortName.Items.Add(s);
            }
            if (pc.Ports.SerialPortNames.Count > 1)
            {
                Parent.SerialForm.cbox_Phone_PortName.SelectedIndex = 1;
            }
            else
                return false;
            if (!portPhone.IsOpen)
            {
                portPhone.PortName = Parent.SerialForm.cbox_Phone_PortName.Text;
            }
            else
            {
                Parent.SerialForm.cbox_Phone_PortName.SelectedIndex = Parent.SerialForm.cbox_Phone_PortName.FindString(portPhone.PortName);
            }

            string[] portAttribute = new string[4];
            portAttribute[0] = Parent.SerialForm.cbox_Sensor_Baud.Text;//比特率
            portAttribute[1] = Parent.SerialForm.cbox_Sensor_Parity.Text;//校验位
            portAttribute[2] = Parent.SerialForm.cbox_Sensor_Bits.Text;//数据位
            portAttribute[3] = Parent.SerialForm.cbox_Sensor_Stop.Text;//停止位
            for (int i = 0; i < 4; i++)
            {
                if (portAttribute[i] == "")
                {
                    if (i == 0)
                    {
                        Parent.StatusLabel1.Text = "请确认手机端口比特率";
                        return false;
                    }
                    if (i == 1)
                    {
                        Parent.StatusLabel1.Text = "请确认手机端口奇偶校验位";
                        return false;
                    }
                    if (i == 2)
                    {
                        Parent.StatusLabel1.Text = "请确认手机端口数据位";
                        return false;
                    }
                    if (i == 3)
                    {
                        Parent.StatusLabel1.Text = "请确认手机端口停止位";
                        return false;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    portPhone.BaudRate = Convert.ToInt32(portAttribute[i]);
                }
                if (i == 1)
                {
                    if (portAttribute[i] == "0")
                        portPhone.Parity = Parity.Even;
                    if (portAttribute[i] == "1")
                        portPhone.Parity = Parity.Mark;
                    if (portAttribute[i] == "2")
                        portPhone.Parity = Parity.None;
                    if (portAttribute[i] == "3")
                        portPhone.Parity = Parity.Odd;
                    if (portAttribute[i] == "4")
                        portPhone.Parity = Parity.Space;
                }
                if (i == 2)
                {
                    portPhone.DataBits = Convert.ToInt32(portAttribute[i]);
                }
                if (i == 3)
                {
                    if (portAttribute[i] == "1")
                        portPhone.StopBits = StopBits.One;
                    if (portAttribute[i] == "1.5")
                        portPhone.StopBits = StopBits.OnePointFive;
                    if (portAttribute[i] == "2")
                        portPhone.StopBits = StopBits.Two;
                }
            }

            //if (Parent.SerialForm.cbox_Baud.SelectedIndex == -1)
            //{
            //    Parent.StatusLabel1.Text = "请确认比特率";
            //    return;
            //}
            //portPhone.BaudRate = Convert.ToInt32(Parent.SerialForm.cbox_Baud.Text);
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == -1)
            //{
            //    this.Parent.StatusLabel1.Text = "请确认奇偶校验位";
            //    return;
            //}
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == 0)
            //    portPhone.Parity = Parity.Even;
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == 1)
            //    portPhone.Parity = Parity.Mark;
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == 2)
            //    portPhone.Parity = Parity.None;
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == 3)
            //    portPhone.Parity = Parity.Odd;
            //if (Parent.SerialForm.cbox_Parity.SelectedIndex == 4)
            //    portPhone.Parity = Parity.Space;

            ////设置数据位
            //if (Parent.SerialForm.cbox_Bits.SelectedIndex == -1)
            //{
            //    this.Parent.StatusLabel1.Text = "请确认数据位";
            //    return;
            //}
            //portPhone.DataBits = Convert.ToInt32(Parent.SerialForm.cbox_Bits.Text);
            ////根据选择的数据，设置停止位
            //if (Parent.SerialForm.cbox_Stop.SelectedIndex == -1)
            //{
            //    this.Parent.StatusLabel1.Text = "请确认停止位";
            //    return;
            //}
            //if (Parent.SerialForm.cbox_Stop.SelectedIndex == 0)
            //    portPhone.StopBits = StopBits.One;
            //if (Parent.SerialForm.cbox_Stop.SelectedIndex == 1)
            //    portPhone.StopBits = StopBits.OnePointFive;
            //if (Parent.SerialForm.cbox_Stop.SelectedIndex == 2)
            //    portPhone.StopBits = StopBits.Two;

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
                    this.Parent.StatusLabel1.Text = "设置已生效";
                    return true;
                }
                if (portPhone_ShouldOpen && portPhone.IsOpen)
                {
                    //MessageBox.Show("the port is opened!");
                    this.Parent.StatusLabel1.Text = "Phone port is opened";
                    return true;
                }
                else
                {
                    this.Parent.StatusLabel1.Text = "failure to open Phone port!";
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failure to open Phone port!" + ex.ToString());
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
                while (portPhone.BytesToRead > 0)
                {
                    char ch = (char)portPhone.ReadByte();
                    currentline += ch.ToString();
                }
                //portPhone.DiscardInBuffer();
                //MessageBox.Show(currentline);
                //在这里对接收到的数据进行显示
                //如果不在窗体加载的事件里写上：Form.CheckForIllegalCrossThreadCalls = false; 就会报错）
                Parent.SerialForm.rich_Receive.Text = currentline;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return ;
            }
        }
        private void PhoneCommand(string CommandString)
        {

            //转换
            //串口只能读取ASCII码或者进制数（1，2，3.....的进制，一般是16进制）
            try
            {
                byte[] WriteBuffer = new byte[2048];
                WriteBuffer = Encoding.Default.GetBytes(CommandString);
                //将数据缓冲区的数据写入到串口端口
                portPhone.Write(WriteBuffer, 0, WriteBuffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        private void SensorRecFun(object Sensorer, SerialDataReceivedEventArgs e)
        {
            try
            {
                string currentline = "";
                //循环接收串口中的数据
                while (portSensor.BytesToRead > 0)
                {
                    char ch = (char)portSensor.ReadByte();
                    currentline += ch.ToString();
                }
                //portPhone.DiscardInBuffer();
                //MessageBox.Show(currentline);
                //在这里对接收到的数据进行显示
                //如果不在窗体加载的事件里写上：Form.CheckForIllegalCrossThreadCalls = false; 就会报错）
                Parent.SerialForm.rich_Receive.Text = currentline;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return;
            }
        }
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

        #region 读XML文件

        /// <summary>  
        /// 返回XMl文件指定元素的指定属性值  
        /// </summary>  
        /// <param name="xmlElement">指定元素</param>  
        /// <param name="xmlAttribute">指定属性</param>  
        /// <returns></returns>  
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
                    //Parent.StatusLabel1.Text = string.Format("id={0},Parity:{1},DataBits:{2},BaudRate{3}", id, Parity, DataBits, BaudRate);
                }
            }
            return str;
        }

        #endregion

        #region 写XML文件

        /// <summary>  
        /// 设置XMl文件指定元素的指定属性的值  
        /// </summary>  
        /// <param name="xmlElement">指定元素</param>  
        /// <param name="xmlAttribute">指定属性</param>  
        /// <param name="xmlValue">指定值</param>  
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
                    //Parent.StatusLabel1.Text = string.Format("id={0},Parity:{1},DataBits:{2},BaudRate{3}", id, Parity, DataBits, BaudRate);
                }
            }
        }
        #endregion

        #region 删除XML元素

        /// <summary>  
        /// 设置XMl文件指定元素的指定属性的值  
        /// </summary>  
        /// <param name="xmlElement">指定元素</param>  
        /// <param name="xmlAttribute">指定属性</param>  
        /// <param name="xmlValue">指定值</param>  
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
                    //Parent.StatusLabel1.Text = string.Format("id={0},Parity:{1},DataBits:{2},BaudRate{3}", id, Parity, DataBits, BaudRate);
                }
            }
        }
        #endregion

        private void msgFunction_1()//对应消息码为1的时要执行的函数
        {
            setXmlValue("COM", "id", "2", "StopBits", "OnePointFive");
        }
        private void msgFunction_2()//对应消息码为2的时要执行的函数
        {
            Parent.StatusLabel1.Text = String.Format("id = {0}", msgQueue.Peek());
            System.Threading.Thread.Sleep(3000);
        }
        private void msgFunction_3()//对应消息码为3的时要执行的函数
        {
            //if (Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex == -1)
            //{
            //    this.Parent.StatusLabel1.Text = "请确认串口端口";
            //    return;
            //}
            //if (Parent.SerialForm.cbox_Sensor_PortName.Text == "COM2")
            //{
            //    OpenSensorPort();
            //}
            //if (Parent.SerialForm.cbox_Sensor_PortName.Text == "COM1")
            //{
            //    OpenPhonePort();
            //}
        }
        private void msgFunction_4()//对应消息码为3的时要执行的函数
        {
            //if (portSensor.IsOpen)
            //{
            //    portSensor.Close();
            //}
            //if (portPhone.IsOpen)
            //{
            //    portPhone.Close();
            //}
            //this.Parent.StatusLabel1.Text = "the port is closed";
        }
        private void msgFunction_5()////发送测量数据
        {
            if (!portSensor.IsOpen)
            {
                this.Parent.StatusLabel1.Text = "the Sensor port has not been opened";
                return;
            }
            SensorCommand(Parent.SerialForm.rich_Send.Text);
        }
        private void msgFunction_11()//发送手机数据
        {
            if (!portPhone.IsOpen)
            {
                this.Parent.StatusLabel1.Text = "the Phone port has not been opened";
                return;
            }
            PhoneCommand(Parent.SerialForm.rich_Send.Text);
        }
        #region 初始化Serial窗口UI
        private void msgFunction_6()
        {
            portSensor = new SerialPort();
            portPhone = new SerialPort();
            //让壮态栏控件的宽度与显示器的分辨率宽度一致
            //this.Parent.this.m_ParentForm.StatusLabel1.Text = "就绪";
            //实例化
            //这里需要添加引用Microsoft.VisualBasic的引用，提供操作计算机组件（如：音频，时钟，键盘文件系统等）的属性
            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            //循环该计算机上所有串行端口的集合
            #region Sensor控件初始化
            this.Parent.SerialForm.check_SensorPort.Checked = portSensor_ShouldOpen;
            Parent.SerialForm.cbox_Sensor_PortName.Enabled = false;
            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Sensor_PortName.Items.Add(s);
            }
            if (pc.Ports.SerialPortNames.Count > 0)
            {
                Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = 0;
            }
            Parent.SerialForm.cbox_Sensor_Bits.Items.Add("5");
            Parent.SerialForm.cbox_Sensor_Bits.Items.Add("7");
            Parent.SerialForm.cbox_Sensor_Bits.Items.Add("8");
            Parent.SerialForm.cbox_Sensor_Bits.SelectedIndex = 2;//选择8位数据包

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
            Parent.SerialForm.cbox_Sensor_Baud.SelectedIndex = 11;//选择最大比特率

            Parent.SerialForm.cbox_Sensor_Parity.Items.AddRange(new object[] {
            "Even",
            "Mark",
            "None",
            "Odd",
            "Space"});
            Parent.SerialForm.cbox_Sensor_Parity.SelectedIndex = 2;//选中校验位位none表示不设置校验位

            Parent.SerialForm.cbox_Sensor_Stop.Items.Add("1");
            Parent.SerialForm.cbox_Sensor_Stop.Items.Add("1.5");
            Parent.SerialForm.cbox_Sensor_Stop.Items.Add("2");
            Parent.SerialForm.cbox_Sensor_Stop.SelectedIndex = 0;//停止位为1
            #endregion

            #region Phone控件初始化
            this.Parent.SerialForm.check_PhonePort.Checked = portPhone_ShouldOpen;
            Parent.SerialForm.cbox_Phone_PortName.Enabled = false;
            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Phone_PortName.Items.Add(s);
            }
            if (pc.Ports.SerialPortNames.Count > 1)
            {
                Parent.SerialForm.cbox_Phone_PortName.SelectedIndex = 1;
            }
            Parent.SerialForm.cbox_Phone_Bits.Items.Add("5");
            Parent.SerialForm.cbox_Phone_Bits.Items.Add("7");
            Parent.SerialForm.cbox_Phone_Bits.Items.Add("8");
            Parent.SerialForm.cbox_Phone_Bits.SelectedIndex = 2;//选择8位数据包

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
            Parent.SerialForm.cbox_Phone_Baud.SelectedIndex = 11;//选择最大比特率

            Parent.SerialForm.cbox_Phone_Parity.Items.AddRange(new object[] {
            "Even",
            "Mark",
            "None",
            "Odd",
            "Space"});
            Parent.SerialForm.cbox_Phone_Parity.SelectedIndex = 2;//选中校验位位none表示不设置校验位

            Parent.SerialForm.cbox_Phone_Stop.Items.Add("1");
            Parent.SerialForm.cbox_Phone_Stop.Items.Add("1.5");
            Parent.SerialForm.cbox_Phone_Stop.Items.Add("2");
            Parent.SerialForm.cbox_Phone_Stop.SelectedIndex = 0;//停止位为1
            #endregion
        }
        #endregion

        private void msgFunction_7()//确认端口修改
        { 
            if(SetPhonePort() && SetSensorPort())
                Parent.StatusLabel1.Text = "端口修改成功";
        }
        private void msgFunction_8()//取消端口修改
        { }
        private void msgFunction_9()//变更Sensor端口开关
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
        }
        private void msgFunction_10()//变更Phone端口开关
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
        }
    }
}
