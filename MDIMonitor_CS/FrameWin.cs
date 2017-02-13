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
        public CurDataForm CurForm = null;
        public UserDatForm UserForm = null;
        public UserThread thread = null;
        public UIThread UIthread = null;
        public string[] curDataValue = new string[8];
        public FrameWin()
        {
            InitializeComponent();
            thread = new UserThread(this);
            UIthread = new UIThread(this);

            SerialForm = new SerialPortForm(this);
            SerialForm.MdiParent = this;
            SerialForm.Location = new Point(0, 0);

            CurForm = new CurDataForm(this);
            CurForm.MdiParent = this;
            CurForm.Location = new Point(0, 0);

            UserForm = new UserDatForm(this);
            UserForm.MdiParent = this;
            UserForm.Location = new Point(0, 0);

            this.StripContainer.ContentPanel.Controls.Clear();
            SerialForm.Size = this.StripContainer.ContentPanel.Size;
            SerialForm.Parent = this.StripContainer.ContentPanel;
            SerialForm.Show();

            CurForm.Size = this.StripContainer.ContentPanel.Size;
            CurForm.Parent = this.StripContainer.ContentPanel;

            UserForm.Size = this.StripContainer.ContentPanel.Size;
            UserForm.Parent = this.StripContainer.ContentPanel;
            this.PostMessage(4, 1);


        }
        ~FrameWin()
        {
            this.thread.End();
            this.UIthread.End();
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
        }



        private void btn_TestCurData_Click(object sender, EventArgs e)
        {
            this.PostMessage(1, 1);
        }

        private void menu_SerialForm_Click(object sender, EventArgs e)
        {
            this.StripContainer.ContentPanel.Controls.Clear();
            SerialForm.Size = this.StripContainer.ContentPanel.Size;
            SerialForm.Parent = this.StripContainer.ContentPanel;
            this.thread.PostMessage(12);//发送消息设置SerialForm窗口控件状态
            SerialForm.Show();
        }

        private void menu_CurForm_Click(object sender, EventArgs e)
        {
            this.StripContainer.ContentPanel.Controls.Clear();
            CurForm.Size = this.StripContainer.ContentPanel.Size;
            CurForm.Parent = this.StripContainer.ContentPanel;
            CurForm.Show();

        }

        private void menu_ScanPort_Click(object sender, EventArgs e)
        {
            //this.thread.PostMessage(1);//发送消息主动扫描测量节点内数据
            //this.thread.PostMessage(2);//发送消息测试短信发送功能
            this.PostMessage(1, 1);
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

            this.StripContainer.ContentPanel.Controls.Clear();
            //UserForm.Size = this.StripContainer.ContentPanel.Size;
            UserForm.Parent = this.StripContainer.ContentPanel;
            UserForm.InitialGrid();
            UserForm.Show();
        }
    }
}
