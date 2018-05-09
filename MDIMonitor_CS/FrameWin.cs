using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MDIMonitor_CS
{
    public partial class FrameWin : Form
    {
        public SerialPortForm SerialForm = null;
        public CurDataForm[] CurForm = new CurDataForm[4];
        public UserDatForm UserForm = null;
        public HisDataForm HisForm = null;
        public CurGridDataForm CurGridForm = null;
        public UserThread[] thread = null;
        public System.IO.Ports.SerialPort portPhone = null;
        public int[] portPhoneAttribute = new int[4];
        public int[] portWarnAttribute = new int[4];

        public UIThread UIthread = null;
        public PhoneThread phoneThread = null;
        public WarningThread warningThread = null;
        public MeasureTimer MeasureThread = null;
        public string[] curDataValue = new string[9];
        public int CurFormCount = 0;
        public int nodeNum = 4;
        Thread _readThread;
        public FrameWin()
        {
            WelcomeForm welcome = new WelcomeForm();
            welcome.Show();
            Thread.Sleep(2000);
            welcome.Close();
            InitializeComponent();


            this.Size = new Size(1039, 561);
            //portPhone = new System.IO.Ports.SerialPort();
            thread = new UserThread[nodeNum];
            for (int i = 0; i < nodeNum; i++)
            {
                thread[i] = new UserThread(this, i);
                //thread[i].portPhone = portPhone;
            }
            //thread[4] = { new UserThread(this), new UserThread(this), new UserThread(this), new UserThread(this) };
            UIthread = new UIThread(this);
            phoneThread = new PhoneThread(this);
            warningThread = new WarningThread(this);
            MeasureThread = new MeasureTimer(this);

            for (int i = 0; i < nodeNum; i++)
            {
                thread[i].Start();
            }
            //thread.Start();
            //UIthread.Start();
            //warningThread.Start();

            //menu_auto.Enabled = false;
            menu_auto.Checked = false;
            SerialForm = new SerialPortForm(this);
            SerialForm.MdiParent = this;
            SerialForm.Location = new Point(0, 0);



            CurGridForm = new CurGridDataForm(this);
            CurGridForm.MdiParent = this;
            CurGridForm.Location = new Point(0, 0);
            for (int i = 0; i < nodeNum; i++)
            {
                if (CurForm[i] != null)
                    continue;
                CurForm[i] = new CurDataForm(this);
                CurForm[i].MdiParent = this;
                CurForm[i].Location = new Point(0, 0);
                CurForm[i].Size = this.StripContainer.ContentPanel.Size;
                CurForm[i].Parent = this.StripContainer.ContentPanel;
                CurForm[i].Show();
                CurForm[i].Visible = false;
                CurForm[i].cur_node = i + 1;
            }

            HisForm = new HisDataForm(this);
            HisForm.MdiParent = this;
            HisForm.Location = new Point(0, 0);

            UserForm = new UserDatForm(this);
            UserForm.MdiParent = this;
            UserForm.Location = new Point(0, 0);

            this.StripContainer.ContentPanel.Controls.Clear();
            SerialForm.Size = this.StripContainer.ContentPanel.Size;
            SerialForm.Parent = this.StripContainer.ContentPanel;
            SerialForm.Show();
            SerialForm.Visible = false;

            //this.PostMessage(6, 0);
            //SerialForm.Show();
            //SerialForm.Visible = false;


            HisForm.Size = this.StripContainer.ContentPanel.Size;
            HisForm.Parent = this.StripContainer.ContentPanel;

            CurGridForm.Size = this.StripContainer.ContentPanel.Size;
            CurGridForm.Parent = this.StripContainer.ContentPanel;
            CurGridForm.Show();
            CurGridForm.Visible = false;

            UserForm.Size = this.StripContainer.ContentPanel.Size;
            UserForm.Parent = this.StripContainer.ContentPanel;
            this.PostMessage(4, 1);

            MeasureThread.PostMessage(1);
            this.statusLabel.Text = "启动完成";


        }
        ~FrameWin()
        {
            //this.thread.Kill();
            //this.UIthread.Kill();
            //this.MeasureThread.Kill();
        }

        public void PostMessage(int msgid, int thread_id, int node_id)
        {
            if (thread_id == 0)
            {
                if (msgid > 0)
                {
                    thread[node_id].PostMessage(msgid);
                }
                else if (msgid == -1)
                {

                    thread[node_id].Stop();

                }
                else if (msgid == -2)
                {

                    thread[node_id].Resume();

                }
                else if (msgid == -3)
                {

                    thread[node_id].Kill();

                }
                else if (msgid == -4)
                {

                    thread[node_id].End();

                }
            }
        }
        public void PostMessage(int msgid, int thread_id)
        {
            if (thread_id == 0)
            {
                if (msgid > 0)
                {
                    for (int i = 0; i < nodeNum; i++)
                    {
                        thread[i].PostMessage(msgid);
                    }
                }
                else if (msgid == -1)
                {
                    for (int i = 0; i < nodeNum; i++)
                    {
                        thread[i].Stop();
                    }
                }
                else if (msgid == -2)
                {
                    for (int i = 0; i < nodeNum; i++)
                    {
                        thread[i].Resume();
                    }
                }
                else if (msgid == -3)
                {
                    for (int i = 0; i < nodeNum; i++)
                    {
                        thread[i].Kill();
                    }
                }
                else if (msgid == -4)
                {
                    for (int i = 0; i < nodeNum; i++)
                    {
                        thread[i].End();
                    }
                }
            }
            if (thread_id == 1)
            {
                if (msgid > 0)
                    this.UIthread.PostMessage(msgid);
                else if (msgid == -1)
                    this.UIthread.Stop();
                else if (msgid == -2)
                    this.UIthread.Resume();
                else if (msgid == -3)
                    this.UIthread.Kill();
                else if (msgid == -4)
                    this.UIthread.End();

            }
            if (thread_id == 2)
            {
                if (msgid > 0)
                    this.warningThread.PostMessage(msgid);
                else if (msgid == -1)
                    this.warningThread.Stop();
                else if (msgid == -2)
                    this.warningThread.Resume();
                else if (msgid == -3)
                    this.warningThread.Kill();
                else if (msgid == -4)
                    this.warningThread.End();

            }
        }
        public void PostPhoneMessage(int msgid, string msginfo = null)
        {
            if (msgid > 0)
                this.phoneThread.PostMessage(msgid, msginfo);
            else if (msgid == -1)
                this.phoneThread.Stop();
            else if (msgid == -2)
                this.phoneThread.Resume();
            else if (msgid == -3)
                this.phoneThread.Kill();
            else if (msgid == -4)
                this.phoneThread.End();
        }



        private void btn_TestCurData_Click(object sender, EventArgs e)
        {
            //this.PostMessage(1, 1);
        }

        private void menu_SerialForm_Click(object sender, EventArgs e)
        {
            //this.StripContainer.ContentPanel.Controls.Clear();
            //this.StripContainer.ContentPanel.SendToBack();
            SerialForm.Size = this.StripContainer.ContentPanel.Size;
            SerialForm.Parent = this.StripContainer.ContentPanel;
            SerialForm.Show();
            SerialForm.BringToFront();
            this.Text = FromTitle + " - 串口设置";
            this.PostMessage(10, 1);//发送消息设置SerialForm窗口控件状态
            this.PostPhoneMessage(3);

            //SerialForm.TopMost = true;
        }

        private void menu_CurForm_Click(object sender, EventArgs e)
        {

            //this.StripContainer.ContentPanel.Controls.Clear();
            //this.StripContainer.ContentPanel.SendToBack();
            //if (CurFormCount > 3)
            //    CurFormCount = 0;
            //    if (CurForm[CurFormCount] == null || CurForm[CurFormCount].IsDisposed)
            //    {
            //        CurForm[CurFormCount] = new CurDataForm(this);
            //        CurForm[CurFormCount].MdiParent = this;
            //        CurForm[CurFormCount].Location = new Point(0, 0);
            //        CurForm[CurFormCount].Size = this.StripContainer.ContentPanel.Size;
            //        CurForm[CurFormCount].Parent = this.StripContainer.ContentPanel;
            //    }
            ////CurForm[CurFormCount].Size = this.StripContainer.ContentPanel.Size;
            ////CurForm[CurFormCount].Parent = this.StripContainer.ContentPanel;
            //    CurForm[CurFormCount].Text = String.Format("监测窗口{0}", CurFormCount+1);
            //CurForm[CurFormCount].Show();
            //CurForm[CurFormCount].BringToFront();
            //CurFormCount++;
            //CurForm[CurFormCount].TopMost = true;
        }

        private void menu_ScanPort_Click(object sender, EventArgs e)
        {
            //this.thread.PostMessage(1);//发送消息主动扫描测量节点内数据
            this.PostMessage(2, 0, 0);//发送消息测试短信发送功能
            //this.PostMessage(1, 0);
        }

        private void menu_Userdat_Click(object sender, EventArgs e)
        {
            this.PostMessage(4, 1);
            //while (UserForm.data_dataGridView[0].Columns.Count ==0)
            //{
            //    statusLabel.Text = String.Format("载入中...");
            //    Thread.Sleep(5);
            //}
            //statusLabel.Text = String.Format("载入完成");

            //this.StripContainer.ContentPanel.Controls.Clear();
            //this.StripContainer.ContentPanel.SendToBack();
            UserForm.Size = this.StripContainer.ContentPanel.Size;
            UserForm.Parent = this.StripContainer.ContentPanel;
            UserForm.InitialGrid();
            UserForm.Show();
            UserForm.BringToFront();
            this.Text = FromTitle + " - 用户配置";
            //UserForm.TopMost = true;
        }

        private void menu_HisForm_Click(object sender, EventArgs e)
        {
            //this.StripContainer.ContentPanel.Controls.Clear();
            //this.StripContainer.ContentPanel.SendToBack();
            HisForm.Size = this.StripContainer.ContentPanel.Size;
            HisForm.Parent = this.StripContainer.ContentPanel;
            HisForm.Show();
            HisForm.BringToFront();
            this.Text = FromTitle + " - 历史数据浏览";
            //HisForm.TopMost = true;

        }

        private void FrameWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (phoneThread.portPhone.IsOpen)
                phoneThread.portPhone.Close();
            for (int i = 0; i < nodeNum; i++)
            {
                if (thread[i].portSensor.IsOpen)
                    thread[i].portSensor.Close();
            }
            if (warningThread.portWarn.IsOpen)
                warningThread.portWarn.Close();
            //thread.portPhone.
            //thread.Kill();
            //UIthread.Kill();
            //MeasureThread.Kill();
        }

        private void menu_auto_Click(object sender, EventArgs e)
        {
            //this.PostMessage(9, 0);
            menu_auto.Checked = !menu_auto.Checked;
            for (int i = 0; i < nodeNum; i++)
            {
                if (this.thread[i].auto_measure != menu_auto.Checked)
                    this.thread[i].auto_measure = menu_auto.Checked;
                if (menu_auto.Checked == false)
                {
                    this.thread[i].Clear();
                }
            }
            if (menu_auto.Checked == false)
            {
                this.statusLabel.Text = "自动测量已关闭";
            }
            else
            {
                MeasureThread.Start();
                this.statusLabel.Text = "自动测量已开启";
            }
        }

        private void menu_measure_step_Click(object sender, EventArgs e)
        {

        }

        private void menu_single_measure_Click(object sender, EventArgs e)
        {
            this.PostMessage(1, 0);
        }

        private void FrameWin_MouseEnter(object sender, EventArgs e)
        {
            //ToolTip tip = new ToolTip();
            //tip.ShowAlways = true;
            //tip.SetToolTip(this.statusLabel, statusLabel.Text);
        }

        private void menu_CurDataForm_Click(object sender, EventArgs e)
        {
            CurGridForm.Size = this.StripContainer.ContentPanel.Size;
            CurGridForm.Parent = this.StripContainer.ContentPanel;
            CurGridForm.Visible = true;
            CurGridForm.Show();
            CurGridForm.BringToFront();
            this.Text = FromTitle + " - 实时数据流";
        }

        private void MenuItem_monitor1_Click(object sender, EventArgs e)
        {
            CurForm[0].Text = String.Format("监测窗口1");
            CurForm[0].Size = this.StripContainer.ContentPanel.Size;
            CurForm[0].Parent = this.StripContainer.ContentPanel;
            CurForm[0].Show();
            CurForm[0].BringToFront();
            this.Text = FromTitle + " - 监测窗口1";
        }

        private void 监控MenuItem_monitor2_Click(object sender, EventArgs e)
        {
            CurForm[1].Text = String.Format("监测窗口2");
            CurForm[1].Size = this.StripContainer.ContentPanel.Size;
            CurForm[1].Parent = this.StripContainer.ContentPanel;
            CurForm[1].Show();
            CurForm[1].BringToFront();
            this.Text = FromTitle + " - 监测窗口2";
        }

        private void MenuItem_monitor3_Click(object sender, EventArgs e)
        {
            CurForm[2].Text = String.Format("监测窗口3");
            CurForm[2].Size = this.StripContainer.ContentPanel.Size;
            CurForm[2].Parent = this.StripContainer.ContentPanel;
            CurForm[2].Show();
            CurForm[2].BringToFront();
            this.Text = FromTitle + " - 监测窗口3";
        }

        private void MenuItem_monitor4_Click(object sender, EventArgs e)
        {
            CurForm[3].Text = String.Format("监测窗口4");
            CurForm[3].Size = this.StripContainer.ContentPanel.Size;
            CurForm[3].Parent = this.StripContainer.ContentPanel;
            CurForm[3].Show();
            CurForm[3].BringToFront();
            this.Text = FromTitle + " - 监测窗口4";
        }

        private void menu_Help_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath.ToString() + "\\help.chm");
        }

        private void menu_Registr_Click(object sender, EventArgs e)
        {

        }

        private void menu_About_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }


        private void menu_zeros_Click(object sender, EventArgs e)
        {
            PostMessage(8, 1);
        }

        private void menu_test_Click(object sender, EventArgs e)
        {
            if (_readThread == null)
            {
                _readThread = new Thread(WriteTestData);
                _readThread.Start();
            }
            else
            {
                _readThread.Abort();
                _readThread = null;
                for (int i = 0; i < nodeNum; i++)
                {
                    this.thread[i].Clear(); 
                }
            }
        }

        public void WriteTestData()
        {
            while (true)
            {
                this.PostMessage(15,0,0);
                Thread.Sleep(1000);
            }
        }
    }
}
