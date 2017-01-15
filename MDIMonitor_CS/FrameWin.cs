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
        private UserThread thread = null;
        public FrameWin()
        {
            InitializeComponent();
            thread = new UserThread(this);
            SerialForm = new SerialPortForm(this);
            SerialForm.MdiParent = this;
            SerialForm.Location = new Point(0, 0);
            this.splitContainer.Panel2.Controls.Clear();
            SerialForm.Size = this.splitContainer.Panel2.Size;
            SerialForm.Parent = this.splitContainer.Panel2;
            SerialForm.Show();
        }
        ~FrameWin()
        {
            this.thread.End();
        }
        public void PostMessage(int msgid)
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
    }
}
