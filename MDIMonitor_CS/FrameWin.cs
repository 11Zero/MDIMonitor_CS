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
        public  CurDataForm CurForm = null;
        private UserThread thread = null;
        private UIThread UIthread = null;
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

            this.splitContainer.Panel2.Controls.Clear();
            SerialForm.Size = this.splitContainer.Panel2.Size;
            SerialForm.Parent = this.splitContainer.Panel2;
            SerialForm.Show();

            CurForm.Size = this.splitContainer.Panel2.Size;
            CurForm.Parent = this.splitContainer.Panel2;
        }
        ~FrameWin()
        {
            this.thread.End();
            this.UIthread.End();
        }
        public void PostMessage(int msgid,int thread_id)
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

        private void main_btn_1_Click(object sender, EventArgs e)
        {
            this.splitContainer.Panel2.Controls.Clear();
            SerialForm.Size = this.splitContainer.Panel2.Size;
            SerialForm.Parent = this.splitContainer.Panel2;
            this.thread.PostMessage(12);//发送消息设置SerialForm窗口控件状态
            SerialForm.Show();
        }

        private void btn_CurDataView_Click(object sender, EventArgs e)
        {
            this.splitContainer.Panel2.Controls.Clear();
            CurForm.Size = this.splitContainer.Panel2.Size;
            CurForm.Parent = this.splitContainer.Panel2;
            //this.thread.PostMessage(13);//发送消息设置SerialForm窗口控件状态
            CurForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.thread.PostMessage(1);//发送消息主动扫描测量节点内数据
        }

        private void btn_TestCurData_Click(object sender, EventArgs e)
        {
            this.PostMessage(1,1);
        }
    }
}
