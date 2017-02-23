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
        public UserThread thread = null;
        public UIThread UIthread = null;
        public WarningThread warningThread = null;
        public MeasureTimer MeasureThread = null;
        public string[] curDataValue = new string[8];
        public int CurFormCount = 0;
        public FrameWin()
        {
            InitializeComponent();
            this.Size = new Size(1039, 561);
            thread = new UserThread(this);
            UIthread = new UIThread(this);
            warningThread = new WarningThread(this);
            MeasureThread = new MeasureTimer(this);

            thread.Start();
            UIthread.Start();
            warningThread.Start();

            menu_auto.Enabled = false;
            menu_auto.Checked = false;
            SerialForm = new SerialPortForm(this);
            SerialForm.MdiParent = this;
            SerialForm.Location = new Point(0, 0);



            CurGridForm = new CurGridDataForm(this);
            CurGridForm.MdiParent = this;
            CurGridForm.Location = new Point(0, 0);
            //for (int i = 0; i < 4; i++)
            //{
            //    if (CurForm[i] != null)
            //        continue;
            //    CurForm[i].MdiParent = this;
            //    CurForm[i].Location = new Point(0, 0);
            //    CurForm[i].Size = this.StripContainer.ContentPanel.Size;
            //    CurForm[i].Parent = this.StripContainer.ContentPanel;
            //}

            HisForm = new HisDataForm(this);
            HisForm.MdiParent = this;
            HisForm.Location = new Point(0, 0);

            UserForm = new UserDatForm(this);
            UserForm.MdiParent = this;
            UserForm.Location = new Point(0, 0);

            this.StripContainer.ContentPanel.Controls.Clear();
            SerialForm.Size = this.StripContainer.ContentPanel.Size;
            SerialForm.Parent = this.StripContainer.ContentPanel;
            //SerialForm.Show();


            HisForm.Size = this.StripContainer.ContentPanel.Size;
            HisForm.Parent = this.StripContainer.ContentPanel;

            CurGridForm.Size = this.StripContainer.ContentPanel.Size;
            CurGridForm.Parent = this.StripContainer.ContentPanel;
            //CurGridForm.Show();

            UserForm.Size = this.StripContainer.ContentPanel.Size;
            UserForm.Parent = this.StripContainer.ContentPanel;
            this.PostMessage(4, 1);

            MeasureThread.PostMessage(1);
            this.statusLabel.Text = "启动完成";


        }
        ~FrameWin()
        {
            this.thread.Kill();
            this.UIthread.Kill();
            this.MeasureThread.Kill();
        }
        public void PostMessage(int msgid, int thread_id)
        {
            if (thread_id == 0)
            {
                if (msgid > 0)
                    this.thread.PostMessage(msgid);
                else if (msgid == -1)
                    this.thread.Stop();
                else if (msgid == -2)
                    this.thread.Resume();
                else if (msgid == -3)
                    this.thread.Kill();
                else if (msgid == -4)
                    this.thread.End();
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
            this.thread.PostMessage(12);//发送消息设置SerialForm窗口控件状态
            SerialForm.Show();
            SerialForm.BringToFront();
            //SerialForm.TopMost = true;
        }

        private void menu_CurForm_Click(object sender, EventArgs e)
        {

            //this.StripContainer.ContentPanel.Controls.Clear();
            //this.StripContainer.ContentPanel.SendToBack();
            if (CurFormCount > 3)
                CurFormCount = 0;
                if (CurForm[CurFormCount] == null || CurForm[CurFormCount].IsDisposed)
                {
                    CurForm[CurFormCount] = new CurDataForm(this);
                    CurForm[CurFormCount].MdiParent = this;
                    CurForm[CurFormCount].Location = new Point(0, 0);
                    CurForm[CurFormCount].Size = this.StripContainer.ContentPanel.Size;
                    CurForm[CurFormCount].Parent = this.StripContainer.ContentPanel;
                }
            //CurForm[CurFormCount].Size = this.StripContainer.ContentPanel.Size;
            //CurForm[CurFormCount].Parent = this.StripContainer.ContentPanel;
                CurForm[CurFormCount].Text = String.Format("监测窗口{0}", CurFormCount+1);
            CurForm[CurFormCount].Show();
            CurForm[CurFormCount].BringToFront();
            CurFormCount++;
            //CurForm[CurFormCount].TopMost = true;
        }

        private void menu_ScanPort_Click(object sender, EventArgs e)
        {
            //this.thread.PostMessage(1);//发送消息主动扫描测量节点内数据
            this.thread.PostMessage(2);//发送消息测试短信发送功能
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
            //HisForm.TopMost = true;
            
        }

        private void FrameWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Kill();
            UIthread.Kill();
            MeasureThread.Kill();
        }

        private void menu_auto_Click(object sender, EventArgs e)
        {
            //this.PostMessage(9, 0);
            menu_auto.Checked = !menu_auto.Checked;
            if(this.thread.auto_measure != menu_auto.Checked)
                this.thread.auto_measure = menu_auto.Checked;
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
            CurGridForm.Show();
            CurGridForm.BringToFront();
        }

    }
}
