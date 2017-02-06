using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDIMonitor_CS
{
    public partial class CurDataForm : Form
    {
        FrameWin m_ParentForm = null;
        public CurDataForm(FrameWin parent)
        {
            InitializeComponent();
             m_ParentForm = parent;
            MainFrame_Load();
            Form.CheckForIllegalCrossThreadCalls = false;
       }
        private void MainFrame_Load()
        {
            //this.m_ParentForm.PostMessage(6);
        }
    }
}
