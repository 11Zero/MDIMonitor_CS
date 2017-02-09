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
        FrameWin m_ParentForm = null;
        public SerialPortForm(FrameWin parent)
        {
            InitializeComponent();
            m_ParentForm = parent;
            MainFrame_Load();
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        private void MainFrame_Load()
        {
            this.m_ParentForm.PostMessage(6, 0);
        }





        private void btn_test1_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(1, 0);
        }

        private void btn_test2_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(2, 0);
        }

        //private void btn_Open_Click(object sender, EventArgs e)
        //{
        //    this.m_ParentForm.PostMessage(3);
        //}

        //private void btn_Close_Click(object sender, EventArgs e)
        //{
        //    this.m_ParentForm.PostMessage(4);
        //}
        private void btn_SensorSendData_Click(object sender, EventArgs e)//发送测量数据
        {
            this.m_ParentForm.PostMessage(5, 0);
        }

        private void btn_PhoneSendData_Click(object sender, EventArgs e)//发送手机数据
        {
            this.m_ParentForm.PostMessage(11, 0);
        }

       private void btn_ok_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(7, 0);//post确认端口修改消息
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(8, 0);//post取消端口修改消息
        }

        private void check_PhonePort_CheckedChanged(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(10, 0);//变更Phone端口开关
        }

        private void check_SensorPort_CheckedChanged(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(9, 0);//变更Sensor端口开关
        }

        private void btn_stopthread_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(-1, 0);
        }

        private void btn_resumethread_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(-2, 0);
        }

        private void btn_killthread_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(-3, 0);
        }
        private void btn_endthread_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(-4, 0);
        }



        private void SerialPortForm_Load(object sender, EventArgs e)
        {

        }


    }
}
