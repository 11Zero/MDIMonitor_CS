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
        public DataGridView[] dataGridView = null;
        public List<DataTable> data_dataGridView = null;
        public int cur_dataGrid_id = new int();
        public UserDatForm(FrameWin parent)
        {
            InitializeComponent();
            m_ParentForm = parent;
            dataGridView = new DataGridView[4];
            data_dataGridView = new List<DataTable>();
            Form_Load();
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
            DataTable dt = new DataTable();
            for (int i = 0; i < 4; i++)
            {
                data_dataGridView.Add(dt);
            }
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
            cur_dataGrid_id = 0;
            dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView(cur_dataGrid_id);
            dataGrid_InitialVal.Visible = true;
            radio_InitialVal.Checked = true;
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

        private void LoadDataGridView(int dataGrid_id)
        {
            if (dataGrid_id > 3)
                return;
            //this.m_ParentForm.PostMessage(4, 1);
            dataGrid_InitialVal.Visible = radio_InitialVal.Checked;
            dataGrid_Sensitivity.Visible = radio_Senitivity.Checked;
            dataGrid_Unit.Visible = radio_Unit.Checked;
            dataGrid_WarningVal.Visible = radio_WarningVal.Checked;



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
        private void btn_OK_Click(object sender, EventArgs e)
        {
        }

        private void radio_InitialVal_CheckedChanged(object sender, EventArgs e)
        {
            cur_dataGrid_id = 0;
            dataGrid_InitialVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView(cur_dataGrid_id);
        }

        private void radio_Senitivity_CheckedChanged(object sender, EventArgs e)
        {
            cur_dataGrid_id = 1;
            dataGrid_Sensitivity.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView(cur_dataGrid_id);

        }

        private void radio_Unit_CheckedChanged(object sender, EventArgs e)
        {
            cur_dataGrid_id = 2;
            dataGrid_Unit.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView(cur_dataGrid_id);
        }

        private void radio_WarningVal_CheckedChanged(object sender, EventArgs e)
        {
            cur_dataGrid_id = 3;
            dataGrid_WarningVal.DataSource = data_dataGridView[cur_dataGrid_id];
            LoadDataGridView(cur_dataGrid_id);
        }
    }
}
