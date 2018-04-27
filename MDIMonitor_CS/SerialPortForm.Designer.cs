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
            this.radiobtn_node3 = new System.Windows.Forms.RadioButton();
            this.radiobtn_node2 = new System.Windows.Forms.RadioButton();
            this.radiobtn_node1 = new System.Windows.Forms.RadioButton();
            this.radiobtn_node0 = new System.Windows.Forms.RadioButton();
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
            this.trackBar_vol = new System.Windows.Forms.TrackBar();
            this.label20 = new System.Windows.Forms.Label();
            this.check_circulate = new System.Windows.Forms.CheckBox();
            this.check_light = new System.Windows.Forms.CheckBox();
            this.btn_test_warn1 = new System.Windows.Forms.Button();
            this.btn_test_warn2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_vol)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.btn_Open.Location = new System.Drawing.Point(87, 26);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 2;
            this.btn_Open.Text = "打开串口";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Visible = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(201, 26);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "关闭串口";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Visible = false;
            // 
            // btn_SensorSendData
            // 
            this.btn_SensorSendData.Location = new System.Drawing.Point(87, 59);
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
            this.rich_Send.Location = new System.Drawing.Point(87, 88);
            this.rich_Send.Name = "rich_Send";
            this.rich_Send.Size = new System.Drawing.Size(189, 40);
            this.rich_Send.TabIndex = 3;
            this.rich_Send.Text = "";
            this.rich_Send.Visible = false;
            // 
            // rich_Receive
            // 
            this.rich_Receive.Location = new System.Drawing.Point(87, 137);
            this.rich_Receive.Name = "rich_Receive";
            this.rich_Receive.Size = new System.Drawing.Size(189, 40);
            this.rich_Receive.TabIndex = 3;
            this.rich_Receive.Text = "";
            this.rich_Receive.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "发送窗";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "接收窗";
            this.label7.Visible = false;
            // 
            // btn_test1
            // 
            this.btn_test1.Location = new System.Drawing.Point(300, 38);
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
            this.btn_test2.Location = new System.Drawing.Point(300, 67);
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
            this.btn_endthread.Location = new System.Drawing.Point(300, 97);
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
            this.btn_stopthread.Location = new System.Drawing.Point(300, 129);
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
            this.btn_resumethread.Location = new System.Drawing.Point(300, 159);
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
            this.btn_killthread.Location = new System.Drawing.Point(300, 189);
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
            this.groupBox1.Location = new System.Drawing.Point(302, 12);
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
            this.check_PhonePort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.check_PhonePort_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radiobtn_node3);
            this.groupBox2.Controls.Add(this.radiobtn_node2);
            this.groupBox2.Controls.Add(this.radiobtn_node1);
            this.groupBox2.Controls.Add(this.radiobtn_node0);
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
            this.groupBox2.Location = new System.Drawing.Point(14, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 184);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测量端口";
            // 
            // radiobtn_node3
            // 
            this.radiobtn_node3.AutoSize = true;
            this.radiobtn_node3.Location = new System.Drawing.Point(18, 144);
            this.radiobtn_node3.Name = "radiobtn_node3";
            this.radiobtn_node3.Size = new System.Drawing.Size(53, 16);
            this.radiobtn_node3.TabIndex = 6;
            this.radiobtn_node3.TabStop = true;
            this.radiobtn_node3.Text = "节点4";
            this.radiobtn_node3.UseVisualStyleBackColor = true;
            this.radiobtn_node3.CheckedChanged += new System.EventHandler(this.radiobtn_node3_CheckedChanged);
            // 
            // radiobtn_node2
            // 
            this.radiobtn_node2.AutoSize = true;
            this.radiobtn_node2.Location = new System.Drawing.Point(18, 109);
            this.radiobtn_node2.Name = "radiobtn_node2";
            this.radiobtn_node2.Size = new System.Drawing.Size(53, 16);
            this.radiobtn_node2.TabIndex = 5;
            this.radiobtn_node2.TabStop = true;
            this.radiobtn_node2.Text = "节点3";
            this.radiobtn_node2.UseVisualStyleBackColor = true;
            this.radiobtn_node2.CheckedChanged += new System.EventHandler(this.radiobtn_node2_CheckedChanged);
            // 
            // radiobtn_node1
            // 
            this.radiobtn_node1.AutoSize = true;
            this.radiobtn_node1.Location = new System.Drawing.Point(18, 74);
            this.radiobtn_node1.Name = "radiobtn_node1";
            this.radiobtn_node1.Size = new System.Drawing.Size(53, 16);
            this.radiobtn_node1.TabIndex = 4;
            this.radiobtn_node1.TabStop = true;
            this.radiobtn_node1.Text = "节点2";
            this.radiobtn_node1.UseVisualStyleBackColor = true;
            this.radiobtn_node1.CheckedChanged += new System.EventHandler(this.radiobtn_node1_CheckedChanged);
            // 
            // radiobtn_node0
            // 
            this.radiobtn_node0.AutoSize = true;
            this.radiobtn_node0.Location = new System.Drawing.Point(18, 39);
            this.radiobtn_node0.Name = "radiobtn_node0";
            this.radiobtn_node0.Size = new System.Drawing.Size(53, 16);
            this.radiobtn_node0.TabIndex = 3;
            this.radiobtn_node0.TabStop = true;
            this.radiobtn_node0.Text = "节点1";
            this.radiobtn_node0.UseVisualStyleBackColor = true;
            this.radiobtn_node0.CheckedChanged += new System.EventHandler(this.radiobtn_node0_CheckedChanged);
            // 
            // check_SensorPort
            // 
            this.check_SensorPort.AutoSize = true;
            this.check_SensorPort.Location = new System.Drawing.Point(126, 16);
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
            this.label8.Location = new System.Drawing.Point(79, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "串行口";
            // 
            // cbox_Sensor_PortName
            // 
            this.cbox_Sensor_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Sensor_PortName.FormattingEnabled = true;
            this.cbox_Sensor_PortName.Location = new System.Drawing.Point(126, 38);
            this.cbox_Sensor_PortName.Name = "cbox_Sensor_PortName";
            this.cbox_Sensor_PortName.Size = new System.Drawing.Size(121, 20);
            this.cbox_Sensor_PortName.TabIndex = 0;
            // 
            // cbox_Sensor_Baud
            // 
            this.cbox_Sensor_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Sensor_Baud.FormattingEnabled = true;
            this.cbox_Sensor_Baud.Location = new System.Drawing.Point(126, 64);
            this.cbox_Sensor_Baud.Name = "cbox_Sensor_Baud";
            this.cbox_Sensor_Baud.Size = new System.Drawing.Size(121, 20);
            this.cbox_Sensor_Baud.TabIndex = 0;
            // 
            // cbox_Sensor_Parity
            // 
            this.cbox_Sensor_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Sensor_Parity.FormattingEnabled = true;
            this.cbox_Sensor_Parity.Location = new System.Drawing.Point(126, 90);
            this.cbox_Sensor_Parity.Name = "cbox_Sensor_Parity";
            this.cbox_Sensor_Parity.Size = new System.Drawing.Size(121, 20);
            this.cbox_Sensor_Parity.TabIndex = 0;
            // 
            // cbox_Sensor_Bits
            // 
            this.cbox_Sensor_Bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Sensor_Bits.FormattingEnabled = true;
            this.cbox_Sensor_Bits.Location = new System.Drawing.Point(126, 116);
            this.cbox_Sensor_Bits.Name = "cbox_Sensor_Bits";
            this.cbox_Sensor_Bits.Size = new System.Drawing.Size(121, 20);
            this.cbox_Sensor_Bits.TabIndex = 0;
            // 
            // cbox_Sensor_Stop
            // 
            this.cbox_Sensor_Stop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Sensor_Stop.FormattingEnabled = true;
            this.cbox_Sensor_Stop.Location = new System.Drawing.Point(126, 142);
            this.cbox_Sensor_Stop.Name = "cbox_Sensor_Stop";
            this.cbox_Sensor_Stop.Size = new System.Drawing.Size(121, 20);
            this.cbox_Sensor_Stop.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "波特率";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "校验位";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(79, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "数据位";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(79, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "停止位";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(398, 232);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 9;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(398, 282);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_PhoneSendData
            // 
            this.btn_PhoneSendData.Location = new System.Drawing.Point(201, 59);
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
            this.text_targetphone.Location = new System.Drawing.Point(86, 226);
            this.text_targetphone.Name = "text_targetphone";
            this.text_targetphone.Size = new System.Drawing.Size(127, 21);
            this.text_targetphone.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 229);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "目标号码";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label14.Location = new System.Drawing.Point(33, 256);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "发送内容";
            // 
            // rich_smstext
            // 
            this.rich_smstext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rich_smstext.Location = new System.Drawing.Point(86, 253);
            this.rich_smstext.Name = "rich_smstext";
            this.rich_smstext.Size = new System.Drawing.Size(127, 55);
            this.rich_smstext.TabIndex = 13;
            this.rich_smstext.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 33);
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
            this.groupBox3.Location = new System.Drawing.Point(551, 12);
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
            this.check_WarnPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.check_WarnPort_MouseClick);
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
            this.cbox_warnlist.Location = new System.Drawing.Point(245, 257);
            this.cbox_warnlist.Name = "cbox_warnlist";
            this.cbox_warnlist.Size = new System.Drawing.Size(121, 20);
            this.cbox_warnlist.TabIndex = 15;
            this.cbox_warnlist.SelectedIndexChanged += new System.EventHandler(this.cbox_warnlist_SelectedIndexChanged);
            // 
            // btn_do_warn
            // 
            this.btn_do_warn.Location = new System.Drawing.Point(6, 61);
            this.btn_do_warn.Name = "btn_do_warn";
            this.btn_do_warn.Size = new System.Drawing.Size(75, 23);
            this.btn_do_warn.TabIndex = 16;
            this.btn_do_warn.Text = "报警";
            this.btn_do_warn.UseVisualStyleBackColor = true;
            this.btn_do_warn.Visible = false;
            this.btn_do_warn.Click += new System.EventHandler(this.btn_do_warn_Click);
            // 
            // trackBar_vol
            // 
            this.trackBar_vol.Location = new System.Drawing.Point(267, 226);
            this.trackBar_vol.Name = "trackBar_vol";
            this.trackBar_vol.Size = new System.Drawing.Size(60, 45);
            this.trackBar_vol.TabIndex = 17;
            this.trackBar_vol.Scroll += new System.EventHandler(this.trackBar_vol_Scroll);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(243, 232);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 18;
            this.label20.Text = "音量";
            // 
            // check_circulate
            // 
            this.check_circulate.AutoSize = true;
            this.check_circulate.Location = new System.Drawing.Point(323, 231);
            this.check_circulate.Name = "check_circulate";
            this.check_circulate.Size = new System.Drawing.Size(48, 16);
            this.check_circulate.TabIndex = 19;
            this.check_circulate.Text = "循环";
            this.check_circulate.UseVisualStyleBackColor = true;
            this.check_circulate.CheckedChanged += new System.EventHandler(this.check_circulate_CheckedChanged);
            // 
            // check_light
            // 
            this.check_light.AutoSize = true;
            this.check_light.Location = new System.Drawing.Point(357, 308);
            this.check_light.Name = "check_light";
            this.check_light.Size = new System.Drawing.Size(48, 16);
            this.check_light.TabIndex = 20;
            this.check_light.Text = "闪光";
            this.check_light.UseVisualStyleBackColor = true;
            this.check_light.Visible = false;
            this.check_light.CheckedChanged += new System.EventHandler(this.check_light_CheckedChanged);
            // 
            // btn_test_warn1
            // 
            this.btn_test_warn1.Location = new System.Drawing.Point(254, 286);
            this.btn_test_warn1.Name = "btn_test_warn1";
            this.btn_test_warn1.Size = new System.Drawing.Size(97, 23);
            this.btn_test_warn1.TabIndex = 21;
            this.btn_test_warn1.Text = "一级报警测试";
            this.btn_test_warn1.UseVisualStyleBackColor = true;
            this.btn_test_warn1.Click += new System.EventHandler(this.btn_test_warn1_Click);
            // 
            // btn_test_warn2
            // 
            this.btn_test_warn2.Location = new System.Drawing.Point(254, 315);
            this.btn_test_warn2.Name = "btn_test_warn2";
            this.btn_test_warn2.Size = new System.Drawing.Size(97, 23);
            this.btn_test_warn2.TabIndex = 22;
            this.btn_test_warn2.Text = "二级报警测试";
            this.btn_test_warn2.UseVisualStyleBackColor = true;
            this.btn_test_warn2.Click += new System.EventHandler(this.btn_test_warn2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Open);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_endthread);
            this.panel1.Controls.Add(this.btn_SensorSendData);
            this.panel1.Controls.Add(this.btn_do_warn);
            this.panel1.Controls.Add(this.btn_PhoneSendData);
            this.panel1.Controls.Add(this.rich_Send);
            this.panel1.Controls.Add(this.rich_Receive);
            this.panel1.Controls.Add(this.btn_test1);
            this.panel1.Controls.Add(this.btn_test2);
            this.panel1.Controls.Add(this.btn_stopthread);
            this.panel1.Controls.Add(this.btn_resumethread);
            this.panel1.Controls.Add(this.btn_killthread);
            this.panel1.Location = new System.Drawing.Point(720, 282);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 227);
            this.panel1.TabIndex = 23;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(524, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SerialPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 521);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_test_warn2);
            this.Controls.Add(this.btn_test_warn1);
            this.Controls.Add(this.check_light);
            this.Controls.Add(this.check_circulate);
            this.Controls.Add(this.label20);
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
            this.Controls.Add(this.trackBar_vol);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_vol)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button btn_do_warn;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TrackBar trackBar_vol;
        public System.Windows.Forms.CheckBox check_circulate;
        public System.Windows.Forms.CheckBox check_light;
        public System.Windows.Forms.ComboBox cbox_warnlist;
        private System.Windows.Forms.Button btn_test_warn1;
        private System.Windows.Forms.Button btn_test_warn2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RadioButton radiobtn_node0;
        public System.Windows.Forms.RadioButton radiobtn_node3;
        public System.Windows.Forms.RadioButton radiobtn_node2;
        public System.Windows.Forms.RadioButton radiobtn_node1;
        private System.Windows.Forms.Button button2;
    }
}