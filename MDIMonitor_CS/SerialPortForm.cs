using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace MDIMonitor_CS
{
    public partial class SerialPortForm : Form
    {
        FrameWin m_ParentForm = null;
        public bool WarnOpen = false;
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
            this.m_ParentForm.PostMessage(5, 2);
            cbox_warnlist.Items.AddRange(new object[] {
            "音乐1",
            "音乐2",
            "音乐3",
            "音乐4",
            "音乐5",
            "音乐6",
            "静音"});
            trackBar_vol.Minimum = 1;
            trackBar_vol.Maximum = 30;
            check_circulate.Checked = false;
            check_light.Checked = false;
            cbox_warnlist.SelectedIndex = -1;

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

        private void check_WarnPort_CheckedChanged(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(2, 2);//变更Warn端口开关
            check_circulate.Checked = true;
            check_light.Checked = false;
            cbox_warnlist.SelectedIndex = 6;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(2, 0);
        }

        private void btn_do_warn_Click(object sender, EventArgs e)
        {
            //if (cbox_warnlist.SelectedIndex == -1)
            //    return;
            //this.m_ParentForm.thread.Warn_cmd_id = cbox_warnlist.SelectedIndex;
            //this.m_ParentForm.PostMessage(15, 0);
        }


        private void trackBar_vol_Scroll(object sender, EventArgs e)
        {
            if (!WarnOpen)
                return;
            //byte[] tempWarn_cmd = this.m_ParentForm.thread.Warn_cmd_buffer;
            //byte buffer3 = this.m_ParentForm.warningThread.Warn_cmd_buffer[3];
            //byte buffer5 = this.m_ParentForm.warningThread.Warn_cmd_buffer[5];
            //byte buffer6 = this.m_ParentForm.warningThread.Warn_cmd_buffer[6];
            byte[] Warn_cmd_buffer = { 0x7E, 0xFF, 0x06, 0x06, 0x00, 0x00, 0x01, 0xEF };
            //Warn_cmd_buffer[3] = 0x06;
            //Warn_cmd_buffer[5] = 0x00;
            Warn_cmd_buffer[6] = (byte)this.trackBar_vol.Value;
            this.m_ParentForm.warningThread.Warn_cmd_buffer.buffer = Warn_cmd_buffer;
            this.m_ParentForm.PostMessage(4, 2);//向端口发送声音指令
            Thread.Sleep(20);
            this.m_ParentForm.PostMessage(3, 2);//指示端口执行声音指令
            //this.m_ParentForm.thread.Warn_cmd_buffer[3] = buffer3;
            //this.m_ParentForm.thread.Warn_cmd_buffer[5] = buffer5;
            //this.m_ParentForm.thread.Warn_cmd_buffer[6] = buffer6;
            //this.m_ParentForm.PostMessage(15, 0);
        }

        private void cbox_warnlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
            if (!WarnOpen)
                return;
            int selectindex = cbox_warnlist.SelectedIndex;
            if(selectindex==-1)
                return ;
            byte[] Warn_cmd_buffer = this.m_ParentForm.warningThread.Warn_cmd_buffer.buffer;//{ 0x7E, 0xFF, 0x06, 0x3A, 0x00, 0x07, 0x01, 0xEF };
            //string select = cbox_warnlist.ValueMember;
            Warn_cmd_buffer[3] = 0x3A;
            if (check_light.Checked == true)
                Warn_cmd_buffer[6] = 0x01;
            else
                Warn_cmd_buffer[6] = 0x00;
            if (check_circulate.Checked)
            {
                Warn_cmd_buffer[5] = (byte)(0x80 + cbox_warnlist.SelectedIndex + 1);
            }
            else
            {
                Warn_cmd_buffer[5] = (byte)(0x00 + cbox_warnlist.SelectedIndex + 1);
            }   
            //if (selectindex == 0)
            //{
            //    if (check_circulate.Checked == false)
            //        Warn_cmd_buffer[5] = 0x07;
            //    else
            //        Warn_cmd_buffer[5] = 0x87;
            //}
            //else
            //{
            //    if (check_circulate.Checked == false)
            //        Warn_cmd_buffer[5] = Convert.ToByte(selectindex);
            //    else
            //        Warn_cmd_buffer[5] =(byte)(0x80+Convert.ToByte(selectindex));
            //}
            this.m_ParentForm.PostMessage(4, 2);//向端口发送声音指令
            Thread.Sleep(20);
            this.m_ParentForm.PostMessage(3, 2);//指示端口执行声音指令
        }

        private void check_circulate_CheckedChanged(object sender, EventArgs e)
        {
            return;
            if (!WarnOpen)
                return;
            byte[] Warn_cmd_buffer = this.m_ParentForm.warningThread.Warn_cmd_buffer.buffer;//{ 0x7E, 0xFF, 0x06, 0x3A, 0x00, 0x80, 0x01, 0xEF };
            //this.m_ParentForm.thread.Warn_cmd_buffer[3] = 0x3A;
            if (check_circulate.Checked == true)
            {
                if (Warn_cmd_buffer[5] < 0x80)
                {
                    Warn_cmd_buffer[5] = (byte)(Warn_cmd_buffer[5] - 0x80);
                    this.m_ParentForm.PostMessage(4, 2);//向端口发送声音指令
                    Thread.Sleep(20);
                    this.m_ParentForm.PostMessage(3, 2);//指示端口执行声音指令
                }
            }
            else
            {
                if (Warn_cmd_buffer[5] > 0x80)
                {
                    Warn_cmd_buffer[5] = (byte)(Warn_cmd_buffer[5] - 0x80);
                    this.m_ParentForm.PostMessage(4, 2);//向端口发送声音指令
                    Thread.Sleep(20);
                    this.m_ParentForm.PostMessage(3, 2);//指示端口执行声音指令
                }
            }
        }

        private void check_light_CheckedChanged(object sender, EventArgs e)
        {
            return;
            if (!WarnOpen)
                return;
            byte[] Warn_cmd_buffer = this.m_ParentForm.warningThread.Warn_cmd_buffer.buffer;
            //this.m_ParentForm.thread.Warn_cmd_buffer[3] = 0x3A;
            if (check_light.Checked == false)
            {
              Warn_cmd_buffer[6] = 0x01;//闪光开
            }
            else
            {
                Warn_cmd_buffer[6] = 0x00;//闪光关
            }
            this.m_ParentForm.PostMessage(4, 2);//向端口发送声音指令
            Thread.Sleep(20);
            this.m_ParentForm.PostMessage(3, 2);//指示端口执行声音指令
        }

        private void btn_test_warn1_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(6, 2);//发送一级报警指令
        }

        private void btn_test_warn2_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(7, 2);//发送二级报警指令
        }
    }
}
