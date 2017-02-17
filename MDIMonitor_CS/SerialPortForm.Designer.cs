namespace MDIMonitor_CS
{
    partial class SerialPortForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbox_Phone_PortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_Phone_Baud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_Phone_Parity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbox_Phone_Bits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbox_Phone_Stop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_SensorSendData = new System.Windows.Forms.Button();
            this.rich_Send = new System.Windows.Forms.RichTextBox();
            this.rich_Receive = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_test1 = new System.Windows.Forms.Button();
            this.btn_test2 = new System.Windows.Forms.Button();
            this.btn_endthread = new System.Windows.Forms.Button();
            this.btn_stopthread = new System.Windows.Forms.Button();
            this.btn_resumethread = new System.Windows.Forms.Button();
            this.btn_killthread = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check_PhonePort = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.check_SensorPort = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbox_Sensor_PortName = new System.Windows.Forms.ComboBox();
            this.cbox_Sensor_Baud = new System.Windows.Forms.ComboBox();
            this.cbox_Sensor_Parity = new System.Windows.Forms.ComboBox();
            this.cbox_Sensor_Bits = new System.Windows.Forms.ComboBox();
            this.cbox_Sensor_Stop = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_PhoneSendData = new System.Windows.Forms.Button();
            this.text_targetphone = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.rich_smstext = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.check_WarnPort = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbox_Warn_PortName = new System.Windows.Forms.ComboBox();
            this.cbox_Warn_Baud = new System.Windows.Forms.ComboBox();
            this.cbox_Warn_Parity = new System.Windows.Forms.ComboBox();
            this.cbox_Warn_Bits = new System.Windows.Forms.ComboBox();
            this.cbox_Warn_Stop = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbox_warnlist = new System.Windows.Forms.ComboBox();
            this.btn_do_warn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbox_Phone_PortName
            // 
            this.cbox_Phone_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Phone_PortName.FormattingEnabled = true;
            this.cbox_Phone_PortName.Location = new System.Drawing.Point(80, 35);
            this.cbox_Phone_PortName.Name = "cbox_Phone_PortName";
            this.cbox_Phone_PortName.Size = new System.Drawing.Size(121, 20);
            this.cbox_Phone_PortName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串行口";
            // 
            // cbox_Phone_Baud
            // 
            this.cbox_Phone_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Phone_Baud.FormattingEnabled = true;
            this.cbox_Phone_Baud.Location = new System.Drawing.Point(80, 61);
            this.cbox_Phone_Baud.Name = "cbox_Phone_Baud";
            this.cbox_Phone_Baud.Size = new System.Drawing.Size(121, 20);
            this.cbox_Phone_Baud.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率";
            // 
            // cbox_Phone_Parity
            // 
            this.cbox_Phone_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Phone_Parity.FormattingEnabled = true;
            this.cbox_Phone_Parity.Location = new System.Drawing.Point(80, 87);
            this.cbox_Phone_Parity.Name = "cbox_Phone_Parity";
            this.cbox_Phone_Parity.Size = new System.Drawing.Size(121, 20);
            this.cbox_Phone_Parity.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "校验位";
            // 
            // cbox_Phone_Bits
            // 
            this.cbox_Phone_Bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Phone_Bits.FormattingEnabled = true;
            this.cbox_Phone_Bits.Location = new System.Drawing.Point(80, 113);
            this.cbox_Phone_Bits.Name = "cbox_Phone_Bits";
            this.cbox_Phone_Bits.Size = new System.Drawing.Size(121, 20);
            this.cbox_Phone_Bits.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "数据位";
            // 
            // cbox_Phone_Stop
            // 
            this.cbox_Phone_Stop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Phone_Stop.FormattingEnabled = true;
            this.cbox_Phone_Stop.Location = new System.Drawing.Point(80, 139);
            this.cbox_Phone_Stop.Name = "cbox_Phone_Stop";
            this.cbox_Phone_Stop.Size = new System.Drawing.Size(121, 20);
            this.cbox_Phone_Stop.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "停止位";
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(670, 262);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 2;
            this.btn_Open.Text = "打开串口";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Visible = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(784, 262);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "关闭串口";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Visible = false;
            // 
            // btn_SensorSendData
            // 
            this.btn_SensorSendData.Location = new System.Drawing.Point(670, 295);
            this.btn_SensorSendData.Name = "btn_SensorSendData";
            this.btn_SensorSendData.Size = new System.Drawing.Size(75, 23);
            this.btn_SensorSendData.TabIndex = 2;
            this.btn_SensorSendData.Text = "发送测量数据";
            this.btn_SensorSendData.UseVisualStyleBackColor = true;
            this.btn_SensorSendData.Visible = false;
            this.btn_SensorSendData.Click += new System.EventHandler(this.btn_SensorSendData_Click);
            // 
            // rich_Send
            // 
            this.rich_Send.Location = new System.Drawing.Point(670, 324);
            this.rich_Send.Name = "rich_Send";
            this.rich_Send.Size = new System.Drawing.Size(189, 40);
            this.rich_Send.TabIndex = 3;
            this.rich_Send.Text = "";
            this.rich_Send.Visible = false;
            // 
            // rich_Receive
            // 
            this.rich_Receive.Location = new System.Drawing.Point(670, 373);
            this.rich_Receive.Name = "rich_Receive";
            this.rich_Receive.Size = new System.Drawing.Size(189, 40);
            this.rich_Receive.TabIndex = 3;
            this.rich_Receive.Text = "";
            this.rich_Receive.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(623, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "发送窗";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(623, 378);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "接收窗";
            this.label7.Visible = false;
            // 
            // btn_test1
            // 
            this.btn_test1.Location = new System.Drawing.Point(883, 274);
            this.btn_test1.Name = "btn_test1";
            this.btn_test1.Size = new System.Drawing.Size(75, 23);
            this.btn_test1.TabIndex = 4;
            this.btn_test1.Text = "写入xml";
            this.btn_test1.UseVisualStyleBackColor = true;
            this.btn_test1.Visible = false;
            this.btn_test1.Click += new System.EventHandler(this.btn_test1_Click);
            // 
            // btn_test2
            // 
            this.btn_test2.Location = new System.Drawing.Point(883, 303);
            this.btn_test2.Name = "btn_test2";
            this.btn_test2.Size = new System.Drawing.Size(75, 23);
            this.btn_test2.TabIndex = 4;
            this.btn_test2.Text = "读取xml";
            this.btn_test2.UseVisualStyleBackColor = true;
            this.btn_test2.Visible = false;
            this.btn_test2.Click += new System.EventHandler(this.btn_test2_Click);
            // 
            // btn_endthread
            // 
            this.btn_endthread.Location = new System.Drawing.Point(883, 333);
            this.btn_endthread.Name = "btn_endthread";
            this.btn_endthread.Size = new System.Drawing.Size(75, 23);
            this.btn_endthread.TabIndex = 2;
            this.btn_endthread.Text = "结束线程";
            this.btn_endthread.UseVisualStyleBackColor = true;
            this.btn_endthread.Visible = false;
            this.btn_endthread.Click += new System.EventHandler(this.btn_endthread_Click);
            // 
            // btn_stopthread
            // 
            this.btn_stopthread.Location = new System.Drawing.Point(883, 365);
            this.btn_stopthread.Name = "btn_stopthread";
            this.btn_stopthread.Size = new System.Drawing.Size(75, 23);
            this.btn_stopthread.TabIndex = 5;
            this.btn_stopthread.Text = "暂停线程";
            this.btn_stopthread.UseVisualStyleBackColor = true;
            this.btn_stopthread.Visible = false;
            this.btn_stopthread.Click += new System.EventHandler(this.btn_stopthread_Click);
            // 
            // btn_resumethread
            // 
            this.btn_resumethread.Location = new System.Drawing.Point(883, 395);
            this.btn_resumethread.Name = "btn_resumethread";
            this.btn_resumethread.Size = new System.Drawing.Size(75, 23);
            this.btn_resumethread.TabIndex = 6;
            this.btn_resumethread.Text = "恢复线程";
            this.btn_resumethread.UseVisualStyleBackColor = true;
            this.btn_resumethread.Visible = false;
            this.btn_resumethread.Click += new System.EventHandler(this.btn_resumethread_Click);
            // 
            // btn_killthread
            // 
            this.btn_killthread.Location = new System.Drawing.Point(883, 425);
            this.btn_killthread.Name = "btn_killthread";
            this.btn_killthread.Size = new System.Drawing.Size(75, 23);
            this.btn_killthread.TabIndex = 7;
            this.btn_killthread.Text = "终止线程";
            this.btn_killthread.UseVisualStyleBackColor = true;
            this.btn_killthread.Visible = false;
            this.btn_killthread.Click += new System.EventHandler(this.btn_killthread_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.check_PhonePort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbox_Phone_PortName);
            this.groupBox1.Controls.Add(this.cbox_Phone_Baud);
            this.groupBox1.Controls.Add(this.cbox_Phone_Parity);
            this.groupBox1.Controls.Add(this.cbox_Phone_Bits);
            this.groupBox1.Controls.Add(this.cbox_Phone_Stop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 184);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "手机端口";
            // 
            // check_PhonePort
            // 
            this.check_PhonePort.AutoSize = true;
            this.check_PhonePort.Location = new System.Drawing.Point(80, 13);
            this.check_PhonePort.Name = "check_PhonePort";
            this.check_PhonePort.Size = new System.Drawing.Size(48, 16);
            this.check_PhonePort.TabIndex = 2;
            this.check_PhonePort.Text = "打开";
            this.check_PhonePort.UseVisualStyleBackColor = true;
            this.check_PhonePort.CheckedChanged += new System.EventHandler(this.check_PhonePort_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.check_SensorPort);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbox_Sensor_PortName);
            this.groupBox2.Controls.Add(this.cbox_Sensor_Baud);
            this.groupBox2.Controls.Add(this.cbox_Sensor_Parity);
            this.groupBox2.Controls.Add(this.cbox_Sensor_Bits);
            this.groupBox2.Controls.Add(this.cbox_Sensor_Stop);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(280, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 184);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测量端口";
            // 
            // check_SensorPort
            // 
            this.check_SensorPort.AutoSize = true;
            this.check_SensorPort.Location = new System.Drawing.Point(80, 13);
            this.check_SensorPort.Name = "check_SensorPort";
            this.check_SensorPort.Size = new System.Drawing.Size(48, 16);
            this.check_SensorPort.TabIndex = 2;
            this.check_SensorPort.Text = "打开";
            this.check_SensorPort.UseVisualStyleBackColor = true;
            this.check_SensorPort.CheckedChanged += new System.EventHandler(this.check_SensorPort_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "串行口";
            // 
            // cbox_Sensor_PortName
            // 
            this.cbox_Sensor_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Sensor_PortName.FormattingEnabled = true;
            this.cbox_Sensor_PortName.Location = new System.Drawing.Point(80, 35);
            this.cbox_Sensor_PortName.Name = "cbox_Sensor_PortName";
            this.cbox_Sensor_PortName.Size = new System.Drawing.Size(121, 20);
            this.cbox_Sensor_PortName.TabIndex = 0;
            // 
            // cbox_Sensor_Baud
            // 
            this.cbox_Sensor_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Sensor_Baud.FormattingEnabled = true;
            this.cbox_Sensor_Baud.Location = new System.Drawing.Point(80, 61);
            this.cbox_Sensor_Baud.Name = "cbox_Sensor_Baud";
            this.cbox_Sensor_Baud.Size = new System.Drawing.Size(121, 20);
            this.cbox_Sensor_Baud.TabIndex = 0;
            // 
            // cbox_Sensor_Parity
            // 
            this.cbox_Sensor_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Sensor_Parity.FormattingEnabled = true;
            this.cbox_Sensor_Parity.Location = new System.Drawing.Point(80, 87);
            this.cbox_Sensor_Parity.Name = "cbox_Sensor_Parity";
            this.cbox_Sensor_Parity.Size = new System.Drawing.Size(121, 20);
            this.cbox_Sensor_Parity.TabIndex = 0;
            // 
            // cbox_Sensor_Bits
            // 
            this.cbox_Sensor_Bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Sensor_Bits.FormattingEnabled = true;
            this.cbox_Sensor_Bits.Location = new System.Drawing.Point(80, 113);
            this.cbox_Sensor_Bits.Name = "cbox_Sensor_Bits";
            this.cbox_Sensor_Bits.Size = new System.Drawing.Size(121, 20);
            this.cbox_Sensor_Bits.TabIndex = 0;
            // 
            // cbox_Sensor_Stop
            // 
            this.cbox_Sensor_Stop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Sensor_Stop.FormattingEnabled = true;
            this.cbox_Sensor_Stop.Location = new System.Drawing.Point(80, 139);
            this.cbox_Sensor_Stop.Name = "cbox_Sensor_Stop";
            this.cbox_Sensor_Stop.Size = new System.Drawing.Size(121, 20);
            this.cbox_Sensor_Stop.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "波特率";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "校验位";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "数据位";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "停止位";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(514, 91);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 9;
            this.btn_ok.Text = "应用";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(514, 125);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_PhoneSendData
            // 
            this.btn_PhoneSendData.Location = new System.Drawing.Point(784, 295);
            this.btn_PhoneSendData.Name = "btn_PhoneSendData";
            this.btn_PhoneSendData.Size = new System.Drawing.Size(75, 23);
            this.btn_PhoneSendData.TabIndex = 2;
            this.btn_PhoneSendData.Text = "发送手机数据";
            this.btn_PhoneSendData.UseVisualStyleBackColor = true;
            this.btn_PhoneSendData.Visible = false;
            this.btn_PhoneSendData.Click += new System.EventHandler(this.btn_PhoneSendData_Click);
            // 
            // text_targetphone
            // 
            this.text_targetphone.Location = new System.Drawing.Point(92, 212);
            this.text_targetphone.Name = "text_targetphone";
            this.text_targetphone.Size = new System.Drawing.Size(166, 21);
            this.text_targetphone.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "目标号码";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label14.Location = new System.Drawing.Point(39, 242);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "发送内容";
            // 
            // rich_smstext
            // 
            this.rich_smstext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rich_smstext.Location = new System.Drawing.Point(92, 239);
            this.rich_smstext.Name = "rich_smstext";
            this.rich_smstext.Size = new System.Drawing.Size(166, 55);
            this.rich_smstext.TabIndex = 13;
            this.rich_smstext.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 70);
            this.button1.TabIndex = 14;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.check_WarnPort);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cbox_Warn_PortName);
            this.groupBox3.Controls.Add(this.cbox_Warn_Baud);
            this.groupBox3.Controls.Add(this.cbox_Warn_Parity);
            this.groupBox3.Controls.Add(this.cbox_Warn_Bits);
            this.groupBox3.Controls.Add(this.cbox_Warn_Stop);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Location = new System.Drawing.Point(625, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 184);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "警报端口";
            // 
            // check_WarnPort
            // 
            this.check_WarnPort.AutoSize = true;
            this.check_WarnPort.Location = new System.Drawing.Point(80, 13);
            this.check_WarnPort.Name = "check_WarnPort";
            this.check_WarnPort.Size = new System.Drawing.Size(48, 16);
            this.check_WarnPort.TabIndex = 2;
            this.check_WarnPort.Text = "打开";
            this.check_WarnPort.UseVisualStyleBackColor = true;
            this.check_WarnPort.CheckedChanged += new System.EventHandler(this.check_WarnPort_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(33, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "串行口";
            // 
            // cbox_Warn_PortName
            // 
            this.cbox_Warn_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Warn_PortName.FormattingEnabled = true;
            this.cbox_Warn_PortName.Location = new System.Drawing.Point(80, 35);
            this.cbox_Warn_PortName.Name = "cbox_Warn_PortName";
            this.cbox_Warn_PortName.Size = new System.Drawing.Size(121, 20);
            this.cbox_Warn_PortName.TabIndex = 0;
            // 
            // cbox_Warn_Baud
            // 
            this.cbox_Warn_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Warn_Baud.FormattingEnabled = true;
            this.cbox_Warn_Baud.Location = new System.Drawing.Point(80, 61);
            this.cbox_Warn_Baud.Name = "cbox_Warn_Baud";
            this.cbox_Warn_Baud.Size = new System.Drawing.Size(121, 20);
            this.cbox_Warn_Baud.TabIndex = 0;
            // 
            // cbox_Warn_Parity
            // 
            this.cbox_Warn_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Warn_Parity.FormattingEnabled = true;
            this.cbox_Warn_Parity.Location = new System.Drawing.Point(80, 87);
            this.cbox_Warn_Parity.Name = "cbox_Warn_Parity";
            this.cbox_Warn_Parity.Size = new System.Drawing.Size(121, 20);
            this.cbox_Warn_Parity.TabIndex = 0;
            // 
            // cbox_Warn_Bits
            // 
            this.cbox_Warn_Bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Warn_Bits.FormattingEnabled = true;
            this.cbox_Warn_Bits.Location = new System.Drawing.Point(80, 113);
            this.cbox_Warn_Bits.Name = "cbox_Warn_Bits";
            this.cbox_Warn_Bits.Size = new System.Drawing.Size(121, 20);
            this.cbox_Warn_Bits.TabIndex = 0;
            // 
            // cbox_Warn_Stop
            // 
            this.cbox_Warn_Stop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Warn_Stop.FormattingEnabled = true;
            this.cbox_Warn_Stop.Location = new System.Drawing.Point(80, 139);
            this.cbox_Warn_Stop.Name = "cbox_Warn_Stop";
            this.cbox_Warn_Stop.Size = new System.Drawing.Size(121, 20);
            this.cbox_Warn_Stop.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "波特率";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(33, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 1;
            this.label17.Text = "校验位";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(33, 116);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 1;
            this.label18.Text = "数据位";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(33, 142);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 1;
            this.label19.Text = "停止位";
            // 
            // cbox_warnlist
            // 
            this.cbox_warnlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_warnlist.FormattingEnabled = true;
            this.cbox_warnlist.Location = new System.Drawing.Point(410, 234);
            this.cbox_warnlist.Name = "cbox_warnlist";
            this.cbox_warnlist.Size = new System.Drawing.Size(121, 20);
            this.cbox_warnlist.TabIndex = 15;
            // 
            // btn_do_warn
            // 
            this.btn_do_warn.Location = new System.Drawing.Point(441, 260);
            this.btn_do_warn.Name = "btn_do_warn";
            this.btn_do_warn.Size = new System.Drawing.Size(75, 23);
            this.btn_do_warn.TabIndex = 16;
            this.btn_do_warn.Text = "报警";
            this.btn_do_warn.UseVisualStyleBackColor = true;
            this.btn_do_warn.Click += new System.EventHandler(this.btn_do_warn_Click);
            // 
            // SerialPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 486);
            this.Controls.Add(this.btn_do_warn);
            this.Controls.Add(this.cbox_warnlist);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rich_smstext);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.text_targetphone);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_killthread);
            this.Controls.Add(this.btn_resumethread);
            this.Controls.Add(this.btn_stopthread);
            this.Controls.Add(this.btn_test2);
            this.Controls.Add(this.btn_test1);
            this.Controls.Add(this.rich_Receive);
            this.Controls.Add(this.rich_Send);
            this.Controls.Add(this.btn_PhoneSendData);
            this.Controls.Add(this.btn_SensorSendData);
            this.Controls.Add(this.btn_endthread);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SerialPortForm";
            this.Text = "SerialPortForm";
            this.Load += new System.EventHandler(this.SerialPortForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbox_Phone_PortName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbox_Phone_Baud;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbox_Phone_Parity;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbox_Phone_Bits;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbox_Phone_Stop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_SensorSendData;
        public System.Windows.Forms.RichTextBox rich_Send;
        public System.Windows.Forms.RichTextBox rich_Receive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_test1;
        private System.Windows.Forms.Button btn_test2;
        private System.Windows.Forms.Button btn_endthread;
        private System.Windows.Forms.Button btn_stopthread;
        private System.Windows.Forms.Button btn_resumethread;
        private System.Windows.Forms.Button btn_killthread;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cbox_Sensor_PortName;
        public System.Windows.Forms.ComboBox cbox_Sensor_Baud;
        public System.Windows.Forms.ComboBox cbox_Sensor_Parity;
        public System.Windows.Forms.ComboBox cbox_Sensor_Bits;
        public System.Windows.Forms.ComboBox cbox_Sensor_Stop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        public System.Windows.Forms.CheckBox check_PhonePort;
        public System.Windows.Forms.CheckBox check_SensorPort;
        private System.Windows.Forms.Button btn_PhoneSendData;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox text_targetphone;
        public System.Windows.Forms.RichTextBox rich_smstext;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox check_WarnPort;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.ComboBox cbox_Warn_PortName;
        public System.Windows.Forms.ComboBox cbox_Warn_Baud;
        public System.Windows.Forms.ComboBox cbox_Warn_Parity;
        public System.Windows.Forms.ComboBox cbox_Warn_Bits;
        public System.Windows.Forms.ComboBox cbox_Warn_Stop;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbox_warnlist;
        private System.Windows.Forms.Button btn_do_warn;

    }
}