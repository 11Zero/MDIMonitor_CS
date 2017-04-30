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
    public partial class UserDatForm : Form
    {
        FrameWin m_ParentForm = null;
        //public DataGridView[] dataGridView = null;
        public List<DataTable> data_dataGridView = null;
        public List<DataTable> databack_dataGridView = null;
        public DataTable AdminTable = null;
        //public DataView[] dataView = null;
        public int cur_dataGrid_id = new int();
        private bool InitFlag = false;
        public int step_flag = 0;
        public int user_flag = 0;
        public UserDatForm(FrameWin parent)
        {
            InitializeComponent();
            m_ParentForm = parent;
            //dataGridView = new DataGridView[4];
            //dataView = new DataView[4];
            data_dataGridView = new List<DataTable>();
            databack_dataGridView = new List<DataTable>();
            AdminTable = new DataTable();
            DataTable dt = new DataTable();
            for (int i = 0; i < 7; i++)
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
                cur_dataGrid_id = 0;
                radio_InitialVal.Checked = true;
                this.m_ParentForm.PostMessage(7, 1);//更新user界面
                //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
                //LoadDataGridView(cur_dataGrid_id, ref dataGrid_InitialVal);
                //DataTable dt = new DataTable();
                //dt.Columns.Add("预留1");
                //dt.Columns.Add("预留2");
                //dt.Rows.Add("-","-");
                //dataGrid_InitialVal.DataSource = dt;
                ////dataGrid_InitialVal.Visible = true;
                //radio_Mark.Checked = true;

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
            this.m_ParentForm.PostMessage(7, 1);//更新user界面
            Thread.Sleep(20);
            if (dataGrid_InitialVal.Columns.Count == 4 )
            {
                dataGrid_InitialVal.Columns[0].Width = 50;
                dataGrid_InitialVal.Columns[0].HeaderText = "序号";
                dataGrid_InitialVal.Columns[0].Frozen = true;
                dataGrid_InitialVal.Columns[0].ReadOnly = true;
                foreach (DataGridViewColumn item in dataGrid_InitialVal.Columns)
                {
                    item.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                return;
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
            for (int i = 0; i < dataGrid_InitialVal.Rows.Count; i++)
            {
                if (i+1 > this.m_ParentForm.thread.totalNodeCount)
                {
                    dataGrid_InitialVal.Rows[i].ReadOnly = true;
                    dataGrid_InitialVal.Rows[i].DefaultCellStyle.BackColor = Color.BurlyWood;
                }
            }


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
            //string str = databack_dataGridView[dataGrid_id].Rows[0][1].ToString();
            //str = data_dataGridView[dataGrid_id].Rows[0][1].ToString();
            databack_dataGridView[dataGrid_id] = data_dataGridView[dataGrid_id].Copy();
            //str = data_dataGridView[dataGrid_id].Rows[0][1].ToString();
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
            SaveDataGridView(4);
            for (int i = 0; i < this.m_ParentForm.UIthread.userDataTable.Count; i++)
            {
                
                //string str = data_dataGridView[i].Rows[0][1].ToString();
                this.m_ParentForm.UIthread.userDataTable[i] = data_dataGridView[i].Copy();
                //databack_dataGridView[i] = data_dataGridView[i].Copy();
            }
            //dataGrid_InitialVal.CellValueChanged
            this.m_ParentForm.UIthread.AdminDataTable = AdminTable.Copy();
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
                this.m_ParentForm.PostMessage(4, 1);//更新user数据库
                this.m_ParentForm.PostMessage(7, 1);//更新user界面
                //data_dataGridView[i]

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_NO_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
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
            user_flag = 0;
            cur_dataGrid_id = 0;
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_InitialVal);
        }

        private void radio_Senitivity_CheckedChanged(object sender, EventArgs e)
        {
            user_flag = 1;
            cur_dataGrid_id = 1;
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
            //dataGrid_Sensitivity.DataSource = data_dataGridView[cur_dataGrid_id];
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_Sensitivity);

        }

        private void radio_Unit_CheckedChanged(object sender, EventArgs e)
        {
            user_flag = 7;
            cur_dataGrid_id = 2;
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
            //dataGrid_Unit.DataSource = data_dataGridView[cur_dataGrid_id];
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_Unit);
        }

        private void radio_WarningVal1_CheckedChanged(object sender, EventArgs e)
        {
            user_flag = 3;
            cur_dataGrid_id = 3;
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
            //dataGrid_WarningVal.DataSource = data_dataGridView[cur_dataGrid_id];
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_WarningVal);
        }

        private void radio_WarningVal2_CheckedChanged(object sender, EventArgs e)
        {
            user_flag = 4;
            cur_dataGrid_id = 4;
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
            //dataGrid_WarningVal.DataSource = data_dataGridView[cur_dataGrid_id];
            //LoadDataGridView(cur_dataGrid_id, ref dataGrid_WarningVal);
        }
        private void radio_Position_CheckedChanged(object sender, EventArgs e)
        {
            user_flag = 5;
            cur_dataGrid_id =5;
            LoadDataGridView();
        }

        private void radio_Name_CheckedChanged(object sender, EventArgs e)
        {
            user_flag = 6;
            cur_dataGrid_id = 6;
            LoadDataGridView();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            user_flag = 2;
            cur_dataGrid_id = 7;
            //DataTable dt = new DataTable();
            //dt.Columns.Add("预留1");
            //dt.Columns.Add("预留2");
            //dt.Rows.Add("-","-");
            //dataGrid_InitialVal.DataSource = dt;
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

        private void radio_stage1_CheckedChanged(object sender, EventArgs e)
        {
            step_flag = 0;
            this.m_ParentForm.UIthread.stage = 1;
            this.m_ParentForm.PostMessage(4, 1);//更新现阶段数据库
            //Thread.Sleep(10);
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
        }

        private void radio_stage2_CheckedChanged(object sender, EventArgs e)
        {
            step_flag = 1;
            this.m_ParentForm.UIthread.stage = 2;
            this.m_ParentForm.PostMessage(4, 1);//更新现阶段数据库
            //Thread.Sleep(10);
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
        }

        private void radio_stage3_CheckedChanged(object sender, EventArgs e)
        {
            step_flag = 2;
            this.m_ParentForm.UIthread.stage = 3;
            this.m_ParentForm.PostMessage(4, 1);//更新现阶段数据库
            //Thread.Sleep(10);
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
        }

        private void radio_stage4_CheckedChanged(object sender, EventArgs e)
        {
            step_flag = 3;
            this.m_ParentForm.UIthread.stage = 4;
            this.m_ParentForm.PostMessage(4, 1);//更新现阶段数据库
            //Thread.Sleep(10);
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
        }

        private void radio_stage5_CheckedChanged(object sender, EventArgs e)
        {
            step_flag = 5;
            this.m_ParentForm.UIthread.stage = 5;
            this.m_ParentForm.PostMessage(4, 1);//更新现阶段数据库
            //Thread.Sleep(10);
            //dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView();
        }

        private void dataGrid_InitialVal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGrid_InitialVal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            if (user_flag == 2)
            {
                dt = AdminTable.Copy();
                dt.Rows.Clear();
                for (int i = 0; i < dataGrid_InitialVal.Rows.Count; i++)
                {
                    string str = dataGrid_InitialVal.Rows[i].Cells[1].Value.ToString();
                    if (dataGrid_InitialVal.Rows[i].Cells[1].ToString() != "")
                    {
                        dt.Rows.Add(i + 1, dataGrid_InitialVal.Rows[i].Cells[1].Value.ToString(),
                            dataGrid_InitialVal.Rows[i].Cells[2].Value.ToString(), dataGrid_InitialVal.Rows[i].Cells[3].Value);
                    }
                }
            }
            AdminTable = dt.Copy();
        }

    }
}
