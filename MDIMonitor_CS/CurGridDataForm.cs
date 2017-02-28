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
    public partial class CurGridDataForm : Form
    {
        FrameWin m_ParentForm = null;
        public DataTable curGridData = null;
        //public string[] ScanData = null;
        public CurGridDataForm(FrameWin parent)
        {
            InitializeComponent();
            m_ParentForm = parent;
            curGridData = new DataTable();
            Form.CheckForIllegalCrossThreadCalls = false;
            //ScanData = new string[8];
        }

        private void CurGridDataForm_Load(object sender, EventArgs e)
        {
           
            //DataTable dt = new DataTable();
            if (curGridData.Columns.Count < 1)
            {
                curGridData.Columns.Add("节点", typeof(string));
                curGridData.Columns.Add("通道", typeof(string));
                curGridData.Columns.Add("名称", typeof(string));
                curGridData.Columns.Add("时间", typeof(string));
                curGridData.Columns.Add("测量值", typeof(string));
                curGridData.Columns.Add("单位", typeof(string));
                curGridData.Columns.Add("灵敏度", typeof(string));
                curGridData.Columns.Add("初始值", typeof(string));
                curGridData.Columns.Add("位置", typeof(string));
                curGridData.RowChanged += new DataRowChangeEventHandler(curGridData_RowChanged);
            }
            //if (curGridData.Columns.Count > 0)
            //{
            //    dataGrid_curdata.Columns[0].Width = 20;
            //    //dataGrid_curdata.Columns[1].Width = 20;
            //}
            //curGridData.Rows.Add("-","-","-","-","-","-","-");
            //curGridData.Rows[0][0] = "1";
            
            
        }

        private void curGridData_RowChanged(Object sender,DataRowChangeEventArgs e)
        {
            //dataGrid_curdata.DataSource = curGridData;
        }


    }
}
