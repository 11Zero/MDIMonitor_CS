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
    public partial class UserDatForm : Form
    {
        FrameWin m_ParentForm = null;
        //public DataGridView[] dataGridView = null;
        public List<DataTable> data_dataGridView = null;
        public List<DataTable> databack_dataGridView = null;
        //public DataView[] dataView = null;
        public int cur_dataGrid_id = new int();
        private bool InitFlag = false;
        public UserDatForm(FrameWin parent)
        {
            InitializeComponent();
            m_ParentForm = parent;
            //dataGridView = new DataGridView[4];
            //dataView = new DataView[4];
            data_dataGridView = new List<DataTable>();
            databack_dataGridView = new List<DataTable>();
            DataTable dt = new DataTable();
            for (int i = 0; i < 4; i++)
            {
                data_dataGridView.Add(dt);
                databack_dataGridView.Add(dt);
            }
            //Form_Load();
            //InitialGrid();
        }

        private void Form_Load()
        {
            //foreach (DataTable item in data_dataGridView)
            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //        item.Columns.Add("Column" + i, typeof(string));
            //        item.Rows.Add("123");
            //    }
            //}
            //int count = data_dataGridView.Count;
            //data_dataGridView[0].Columns.Add("12");
            //data_dataGridView[0].Rows.Add("1");
            //    data_dataGridView[1].Columns.Add("12345");
            //    data_dataGridView[1].Rows.Add("1234");
            //    data_dataGridView[2].Columns.Add("123");
            //    data_dataGridView[2].Rows.Add("12");
            //    data_dataGridView[3].Columns.Add("1234");
            //    data_dataGridView[3].Rows.Add("123");
        }

        public void InitialGrid()
        {
            try
            {
                cur_dataGrid_id = 4;
                //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
                //LoadDataGridView(cur_dataGrid_id, ref dataGrid_InitialVal);
                DataTable dt = new DataTable();
                dt.Columns.Add("预留1");
                dt.Columns.Add("预留2");
                dt.Rows.Add("-","-");
                dataGrid_InitialVal.DataSource = dt;
                //dataGrid_InitialVal.Visible = true;
                radio_Mark.Checked = true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            if (dataGrid_InitialVal.Columns.Count > 0)
            {
                dataGrid_InitialVal.Columns[0].Width = 50;
                dataGrid_InitialVal.Columns[0].HeaderText = "节点";
                dataGrid_InitialVal.Columns[0].Frozen = true;
                dataGrid_InitialVal.Columns[0].ReadOnly = true;
                foreach (DataGridViewColumn item in dataGrid_InitialVal.Columns)
                {
                    item.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            InitXmlValue();
            //numeric_measure_step.Increment = 500;
            //numeric_node_num.Increment = 1;
            //numeric_cur_node.Increment = 1;
            //numeric_ch_of_curnode.Increment = 1;

            //numeric_measure_step.Minimum = 500;
            //numeric_measure_step.Maximum = 20000;
            //if (this.m_ParentForm.MeasureThread.ScanTimeStep <= numeric_measure_step.Maximum)
            //    numeric_measure_step.Value = this.m_ParentForm.MeasureThread.ScanTimeStep;
            //else
            //    numeric_measure_step.Value = numeric_measure_step.Minimum;
            
            //numeric_node_num.Minimum = 0;
            //numeric_node_num.Maximum = 4;
            //if (this.m_ParentForm.thread.totalNodeCount <= numeric_node_num.Maximum)
            //    numeric_node_num.Value = this.m_ParentForm.thread.totalNodeCount;
            //else
            //{
            //    numeric_node_num.Value = 0;
            //    this.m_ParentForm.statusLabel.Text = String.Format("节点数目超过4,请检查config文件");
            //    numeric_cur_node.Value = 0;
            //    numeric_ch_of_curnode.Value = 0;
            //    numeric_cur_node.Enabled = false;
            //    numeric_ch_of_curnode.Enabled = false;
            //    return;
            //}

            //numeric_cur_node.Minimum = 0;
            //numeric_cur_node.Maximum = numeric_node_num.Value;
            //numeric_cur_node.Value = 1;
            //numeric_ch_of_curnode.Value = this.m_ParentForm.thread.nodeChNum[0];


            //numeric_ch_of_curnode.Minimum = 0;
            //numeric_ch_of_curnode.Maximum = 8;

            //if (numeric_node_num.Value == 0)
            //{
            //    numeric_cur_node.Value = 0;
            //    numeric_cur_node.Enabled = false;
            //}
            //else
            //{
            //}
            //SaveDataGridView(0, ref dataGrid_InitialVal);
            //SaveDataGridView(1, ref dataGrid_Sensitivity);
            //SaveDataGridView(2, ref dataGrid_Unit);
            //SaveDataGridView(3, ref dataGrid_WarningVal);
            //radio_Senitivity_CheckedChanged(null,null);
            ////dataGrid_Sensitivity.Visible = true;
            //radio_Senitivity.Checked = true;
            //cur_dataGrid_id = 0;
            //LoadDataGridView(cur_dataGrid_id);
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];

            //cur_dataGrid_id = 1;
            //LoadDataGridView(cur_dataGrid_id);
            //dataGrid_Sensitivity.DataSource = data_dataGridView[cur_dataGrid_id];

            //cur_dataGrid_id = 2;
            //LoadDataGridView(cur_dataGrid_id);
            //dataGrid_Unit.DataSource = data_dataGridView[cur_dataGrid_id];

            //cur_dataGrid_id = 3;
            //LoadDataGridView(cur_dataGrid_id);
            //dataGrid_WarningVal.DataSource = data_dataGridView[cur_dataGrid_id];

            //radio_InitialVal.Checked = true;
            //for (int i = 0; i < 4; i++)
            //{
            //    cur_dataGrid_id = i;
            //    this.m_ParentForm.PostMessage(4, 1);
            //}
            //dataGrid_InitialVal.DataSource = data_dataGridView[0];
            //dataGrid_Sensitivity.DataSource = data_dataGridView[1];
            //dataGrid_Unit.DataSource = data_dataGridView[2];
            //dataGrid_WarningVal.DataSource = data_dataGridView[3];

            //radio_InitialVal.Checked = true;
            //cur_dataGrid_id = 0;
            //LoadDataGridView(cur_dataGrid_id);
            //dataGrid_InitialVal.Visible = radio_InitialVal.Checked;
            //for (int i = 0; i < 4; i++)
            //{
            //    dataGridView[i].DataSource = data_dataGridView[i];
            //    dataGridView[i].Size = this.panel_DataGrid.Size;
            //    dataGridView[i].Parent = this.panel_DataGrid;
            //    dataGridView[i].CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //    dataGridView[i].AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //}
        }

        private void InitXmlValue()
        {
            numeric_measure_step.Increment = 500;
            numeric_node_num.Increment = 1;
            numeric_cur_node.Increment = 1;
            numeric_ch_of_curnode.Increment = 1;

            numeric_measure_step.Minimum = 500;
            numeric_measure_step.Maximum = 20000;
            if (this.m_ParentForm.MeasureThread.ScanTimeStep <= numeric_measure_step.Maximum)
                numeric_measure_step.Value = this.m_ParentForm.MeasureThread.ScanTimeStep;
            else
                numeric_measure_step.Value = numeric_measure_step.Minimum;

            numeric_node_num.Minimum = 0;
            numeric_node_num.Maximum = 4;
            if (this.m_ParentForm.thread.totalNodeCount <= numeric_node_num.Maximum)
                numeric_node_num.Value = this.m_ParentForm.thread.totalNodeCount;
            else
            {
                numeric_node_num.Value = 0;
                this.m_ParentForm.statusLabel.Text = String.Format("节点数目超过4,请检查config文件");
                numeric_cur_node.Value = 0;
                numeric_ch_of_curnode.Value = 0;
                numeric_cur_node.Enabled = false;
                numeric_ch_of_curnode.Enabled = false;
                return;
            }

            numeric_cur_node.Minimum = 0;
            numeric_cur_node.Maximum = numeric_node_num.Value;
            numeric_cur_node.Value = 1;
            numeric_ch_of_curnode.Value = this.m_ParentForm.thread.nodeChNum[0];
        }

        private void LoadDataGridView()
        {
            if (dataGrid_InitialVal.Columns.Count > 0)
            {
                dataGrid_InitialVal.Columns[0].Width = 50;
                dataGrid_InitialVal.Columns[0].HeaderText = "节点";
                dataGrid_InitialVal.Columns[0].Frozen = true;
                dataGrid_InitialVal.Columns[0].ReadOnly = true;
                foreach (DataGridViewColumn item in dataGrid_InitialVal.Columns)
                {
                    item.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            for (int i = 0; i < dataGrid_InitialVal.Rows.Count; i++)
            {
                if (i+1 > this.m_ParentForm.thread.totalNodeCount)
                {
                    dataGrid_InitialVal.Rows[i].ReadOnly = true;
                    dataGrid_InitialVal.Rows[i].DefaultCellStyle.BackColor = Color.BurlyWood;
                }
            }

            //if (dataGrid_id > 3)
            //    return;
            ////this.m_ParentForm.PostMessage(4, 1);
            ////ref DataGridView dataview = dataGrid_InitialVal;
            //if (InitFlag)
            //{
            //    //string str = databack_dataGridView[dataGrid_id].Rows[0][1].ToString();
            //    //str = data_dataGridView[dataGrid_id].Rows[0][1].ToString();
            //    data_dataGridView[dataGrid_id] = databack_dataGridView[dataGrid_id].Copy();//恢复本线程中未修改的数据
            //    //this.m_ParentForm.UIthread.userDataTable[dataGrid_id] = databack_dataGridView[dataGrid_id].Copy();//恢复UI线程中未修改的数据
            //    //str = databack_dataGridView[dataGrid_id].Rows[0][1].ToString();
            //    //str = data_dataGridView[dataGrid_id].Rows[0][1].ToString();

            //}
            //refDataGridView.DataSource = data_dataGridView[dataGrid_id];
            //dataGrid_InitialVal.Visible = true;
            //dataGrid_Sensitivity.Visible = false;
            //dataGrid_Unit.Visible = false;
            //dataGrid_WarningVal.Visible = false;
            ////dataGrid_InitialVal.Visible = radio_InitialVal.Checked;
            ////dataGrid_Sensitivity.Visible = radio_Senitivity.Checked;
            ////dataGrid_Unit.Visible = radio_Unit.Checked;
            ////dataGrid_WarningVal.Visible = radio_WarningVal.Checked;
            //if (refDataGridView.Columns.Count > 0)
            //{
            //    refDataGridView.Columns[0].Width = 50;
            //    refDataGridView.Columns[0].HeaderText = "节点";
            //    refDataGridView.Columns[0].Frozen = true;
            //    refDataGridView.Columns[0].ReadOnly = true;
            //    foreach (DataGridViewColumn item in refDataGridView.Columns)
            //    {
            //        item.SortMode = DataGridViewColumnSortMode.NotSortable;
            //    }
            //}
            //if (dataGrid_Sensitivity.Columns.Count > 0)
            //{
            //    dataGrid_Sensitivity.Columns[0].Frozen = true;
            //    foreach (DataGridViewColumn item in dataGrid_InitialVal.Columns)
            //    {
            //        item.SortMode = DataGridViewColumnSortMode.NotSortable;
            //    }
            //}

            //if (dataGrid_Unit.Columns.Count > 0)
            //{
            //    dataGrid_Unit.Columns[0].Frozen = true;
            //    foreach (DataGridViewColumn item in dataGrid_InitialVal.Columns)
            //    {
            //        item.SortMode = DataGridViewColumnSortMode.NotSortable;
            //    }
            //}

            //if (dataGrid_WarningVal.Columns.Count > 0)
            //{
            //    dataGrid_WarningVal.Columns[0].Frozen = true;
            //    foreach (DataGridViewColumn item in dataGrid_InitialVal.Columns)
            //    {
            //        item.SortMode = DataGridViewColumnSortMode.NotSortable;
            //    }
            //}



            //switch (dataGrid_id)
            //{
            //    case 0:
            //        { 
            //            dataGrid_InitialVal.
            //        }break;

            //    default:
            //        break;
            //}
            //for (int i = 0; i < 4; i++)
            //{

            //}
            //dataGridView[dataGrid_id].Show();
            //dataGridView[dataGrid_id].DataSource = data_dataGridView[dataGrid_id];
            //dataGridView[dataGrid_id].Show();
            //dataGridView[dataGrid_id].Size = this.panel_DataGrid.Size;
            //dataGridView[dataGrid_id].Parent = this.panel_DataGrid;
            //dataGridView[dataGrid_id].CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //dataGridView[dataGrid_id].AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            // panel_DataGrid.Controls.Clear();
        }

        private void SaveDataGridView(int dataGrid_id)
        {
            //string str = data_dataGridView[dataGrid_id].Rows[0][1].ToString();
            //    //refDataGridView.DataSource = data_dataGridView[dataGrid_id];
            //    str = data_dataGridView[dataGrid_id].Rows[0][1].ToString();
            //if (dataGrid_id == 0)
            //{
            //    int i = new int();
            //}
            //refDataGridView.
            //refDataGridView.DataSource = data_dataGridView[dataGrid_id];
            //refDataGridView.DataSource = data_dataGridView[dataGrid_id];
            string str = databack_dataGridView[dataGrid_id].Rows[0][1].ToString();
            str = data_dataGridView[dataGrid_id].Rows[0][1].ToString();
            databack_dataGridView[dataGrid_id] = data_dataGridView[dataGrid_id].Copy();
            str = data_dataGridView[dataGrid_id].Rows[0][1].ToString();
            this.m_ParentForm.UIthread.userDataTable[dataGrid_id] = databack_dataGridView[dataGrid_id].Copy();//更新UI线程中已修改的数据
        }
        private void btn_OK_Click(object sender, EventArgs e)//整条逻辑线上的Datatable都是引用类型赋值的，因此datagridview改变时Datatable自动改变数值
        {

            //this.m_ParentForm.UIthread.userDataTable[0] = ((DataTable)dataGrid_InitialVal.DataSource).Copy();
            //this.m_ParentForm.UIthread.userDataTable[1] = ((DataTable)dataGrid_Sensitivity.DataSource).Copy();
            //this.m_ParentForm.UIthread.userDataTable[2] = ((DataTable)dataGrid_Unit.DataSource).Copy();
            //this.m_ParentForm.UIthread.userDataTable[3] = ((DataTable)dataGrid_WarningVal.DataSource).Copy();
            //cur_dataGrid_id = 0;
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_InitialVal);
            //cur_dataGrid_id = 1;
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_Sensitivity);
            //cur_dataGrid_id = 2;
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_Unit);
            //cur_dataGrid_id = 3;
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_WarningVal);
            SaveDataGridView(0);
            SaveDataGridView(1);
            SaveDataGridView(2);
            SaveDataGridView(3);
            for (int i = 0; i < this.m_ParentForm.UIthread.userDataTable.Count; i++)
            {
                //string str = data_dataGridView[i].Rows[0][1].ToString();
                this.m_ParentForm.UIthread.userDataTable[i] = data_dataGridView[i].Copy();
                //databack_dataGridView[i] = data_dataGridView[i].Copy();
            }
            //numeric_measure_step.Increment = 500;
            //numeric_node_num.Increment = 1;
            //numeric_cur_node.Increment = 1;
            //numeric_ch_of_curnode.Increment = 1;
            if (Convert.ToInt16(numeric_measure_step.Value) < 20000)
                this.m_ParentForm.MeasureThread.ScanTimeStep = Convert.ToInt16(numeric_measure_step.Value);
            else
                this.m_ParentForm.statusLabel.Text = String.Format("配置时距超过20s，配置无效");
            try
            {
                if (numeric_cur_node.Value > 0)
                {
                    this.m_ParentForm.thread.nodeChNum[(int)(numeric_cur_node.Value) - 1] = (int)(numeric_ch_of_curnode.Value);
                    this.m_ParentForm.thread.totalNodeCount = (int)(numeric_node_num.Value);
                    UserThread.setXmlValue("NODE", "id", "0", "Count", String.Format("{0}", (int)(numeric_node_num.Value)));
                    UserThread.setXmlValue("NODE", "id", String.Format("{0}", (int)(numeric_cur_node.Value)), "Count", String.Format("{0}", (int)(numeric_ch_of_curnode.Value)));
                    this.m_ParentForm.statusLabel.Text = String.Format("节点{0}通道数已更改", (int)(numeric_cur_node.Value));
                     //this.m_ParentForm.thread.UpdateXml();
               }
                this.m_ParentForm.PostMessage(5, 1);//发送消息修改数据库
                //data_dataGridView[i]

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_NO_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                data_dataGridView[i] = databack_dataGridView[i];
            }
            dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            for (int i = 0; i < dataGrid_InitialVal.Rows.Count; i++)
            {
                if (i + 1 > this.m_ParentForm.thread.totalNodeCount)
                {
                    dataGrid_InitialVal.Rows[i].ReadOnly = true;
                    dataGrid_InitialVal.Rows[i].DefaultCellStyle.BackColor = Color.BurlyWood;
                }
            }
            InitXmlValue();
            //this.m_ParentForm.PostMessage(4, 1);//发送消息重新读取数据库
            //InitFlag = true;
            //cur_dataGrid_id = 0;
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_InitialVal);
            //cur_dataGrid_id = 1;
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_Sensitivity);
            //cur_dataGrid_id = 2;
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_Unit);
            //cur_dataGrid_id = 3;
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_WarningVal);
            //InitFlag = false;

        }

        private void radio_InitialVal_CheckedChanged(object sender, EventArgs e)
        {
            cur_dataGrid_id = 0;
            dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_InitialVal);
        }

        private void radio_Senitivity_CheckedChanged(object sender, EventArgs e)
        {
            cur_dataGrid_id = 1;
            dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
            //dataGrid_Sensitivity.DataSource = data_dataGridView[cur_dataGrid_id];
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_Sensitivity);

        }

        private void radio_Unit_CheckedChanged(object sender, EventArgs e)
        {
            cur_dataGrid_id = 2;
            dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
            //dataGrid_Unit.DataSource = data_dataGridView[cur_dataGrid_id];
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_Unit);
        }

        private void radio_WarningVal_CheckedChanged(object sender, EventArgs e)
        {
            cur_dataGrid_id = 3;
            dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
            //dataGrid_WarningVal.DataSource = data_dataGridView[cur_dataGrid_id];
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_WarningVal);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cur_dataGrid_id = 4;
            DataTable dt = new DataTable();
            dt.Columns.Add("预留1");
            dt.Columns.Add("预留2");
            dt.Rows.Add("-","-");
            dataGrid_InitialVal.DataSource = dt;
            LoadDataGridView();
        }

        private void numeric_cur_node_ValueChanged(object sender, EventArgs e)
        {
            if (numeric_cur_node.Value > 0)
            {
                numeric_ch_of_curnode.Maximum = 8;
                numeric_ch_of_curnode.Value = this.m_ParentForm.thread.nodeChNum[(int)(numeric_cur_node.Value) - 1];
            }
            else
            {
                numeric_ch_of_curnode.Maximum = 0;
                numeric_ch_of_curnode.Value = 0;
            }
        }

        private void numeric_node_num_ValueChanged(object sender, EventArgs e)
        {
            //if (numeric_node_num.Value > 0)
            //{
                numeric_cur_node.Maximum = numeric_node_num.Value;
            //}
        }

        private void numeric_ch_of_curnode_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
