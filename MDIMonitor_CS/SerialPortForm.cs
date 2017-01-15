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
            this.m_ParentForm.PostMessage(6);
        }

        private void cbox_Baud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(3);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(4);
        }
        private void btn_SendData_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(5);
        }



        private void btn_test1_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(1);
        }

        private void btn_test2_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(2);
        }


        private void btn_stopthread_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(-1);
        }

        private void btn_resumethread_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(-2);
        }

        private void btn_killthread_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(-3);
        }
        private void btn_endthread_Click(object sender, EventArgs e)
        {
            this.m_ParentForm.PostMessage(-4);
        }

    }
}
