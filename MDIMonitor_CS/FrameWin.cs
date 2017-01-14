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
    public partial class FrameWin : Form
    {
        public SerialPortForm SerialForm = null;
        public FrameWin()
        {
            InitializeComponent();
            SerialForm = new SerialPortForm(this);
             //SerialForm.MdiParent = this;
           SerialForm.Location = new Point(0, 0);
           SerialForm.Size = this.splitterRight.Size;
           this.splitterRight.Controls.Add(SerialForm);
            SerialForm.Show();
           
            //SerialForm.ParentForm = (Form)this;
            
        }

    }
}
