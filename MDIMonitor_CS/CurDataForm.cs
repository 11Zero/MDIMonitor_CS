using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MDIMonitor_CS
{
    public partial class CurDataForm : Form
    {
        FrameWin m_ParentForm = null;
        public DataTable dataTable = new DataTable();
        public DataSet dataSet = new DataSet();
        private DateTime nowtime = new DateTime();
        public int cur_node = -1;
        public int cur_ch = -1;
        public int Form_id = -1;
        //public delegate void ChartDelegate(Chart _Chart, DataTable _dataTable);
        //private object[] invokeChartData = new object[2];
        public CurDataForm(FrameWin parent)
        {
            InitializeComponent();
            m_ParentForm = parent;
            MainFrame_Load();
            InitChart();
            //Form.CheckForIllegalCrossThreadCalls = false;
        }
        public CurDataForm()
        {
            InitializeComponent();
            MainFrame_Load();
            InitChart();
            //Form.CheckForIllegalCrossThreadCalls = false;
        }
        private void MainFrame_Load()
        {
            
            //this.m_ParentForm.PostMessage(6);
        }
        private void InitChart()//初始化chart
        {
            for (int i = 0; i < 4; i++)
            {
                dataSet.Tables.Add(new DataTable(String.Format("table{0}",i)));
                dataSet.Tables[i].Columns.Add("时间", typeof(string));
                dataSet.Tables[i].Columns.Add("数据", typeof(double));
            }
            //dataTable.Columns.Add("时间", typeof(String));
            //dataTable.Columns.Add("数据0", typeof(double));
            //dataTable.Columns.Add("数据1", typeof(double));
            //dataTable.Columns.Add("数据2", typeof(double));
            //dataTable.Columns.Add("数据3", typeof(double));
             for (int i = 0; i < 4; i++)
            {
                Series serie = new Series();
                serie.Name = String.Format("曲线{0}",i);
                //serie.Points.DataBind(dataSet.Tables[i].AsEnumerable(), dataSet.Tables[i].Columns[0].ColumnName, dataSet.Tables[i].Columns[1].ColumnName, "");
                serie.ChartType = SeriesChartType.Spline;
                //serie.XValueType = ChartValueType.DateTime;
                
                this.CurChart.Series.Add(serie);
            }
             Random ran = new Random();
             DateTime stime = new DateTime(2014, 1, 1, 0, 0, 0);
             DateTime etime = new DateTime(2014, 1, 1, 0, 0, 1);
             TimeSpan step = etime - stime;
             DateTime nowtime = DateTime.Now;
             for (int k = 0; k < 4; k++)
             {
                 //for (int j = 0; j < 100; j++)
                 //{
                 //    nowtime = nowtime - step;
                 //}
                 //nowtime = nowtime.AddSeconds(-100);
                 for (int i = 0; i < 50; i++)
                 {
                     nowtime = nowtime.AddSeconds(1);
                     dataSet.Tables[k].Rows.Add(nowtime.ToShortTimeString(), ran.Next(0, 20));
                     //this.CurChart.Series[k].Points.AddXY(nowtime, ran.Next(0, 20));
                 }
                 //this.CurChart.Series[k].XAxisType = AxisType.;
                 //this.CurChart.Series[k].ArgumentDataMember = "Date";
                 //this.CurChart.Series[k].ValueDataMembers[0] = "Value";
                 //this.CurChart.Series[k].DataSource = CreateChartData();
                 //chartControl1.Series.Add(_lineSeries);
                 //chartControl1.SetTimeAxisX(DateTimeMeasurementUnit.Month, DateTimeMeasurementUnit.Month, "yyyy-MM");
                 //if(k==0)
                 this.CurChart.Series[k].Points.DataBind(dataSet.Tables[k].AsEnumerable(), dataSet.Tables[k].Columns[0].ColumnName, dataSet.Tables[k].Columns[1].ColumnName, "");
                 //else
                 //    this.CurChart.Series[k].Points.DataBindY(dataSet.Tables[k].AsEnumerable(), dataSet.Tables[k].Columns[1].ColumnName);
                 nowtime = nowtime.AddSeconds(-50);

                 //this.CurChart.Series[k].Points.AddXY(nowtime, ran.Next(0, 20));
             }
            ////Series[] series = new Series[4];
            ////CurChart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            ////CurChart.ChartAreas[0].AxisX.
            //CurChart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";//
            //CurChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            //CustomLabel label = new CustomLabel();
            //CurChart.ChartAreas[0].AxisX.CustomLabels.Add(label);
            CurChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            CurChart.ChartAreas[0].AxisX.ScrollBar.Size = 11;
            CurChart.ChartAreas[0].AxisX.ScaleView.Size = 35;//可视区域数据点数 
            CurChart.ChartAreas[0].AxisX.ScaleView.MinSize = 4;
            CurChart.ChartAreas[0].AxisX.ScaleView.Position = CurChart.Series[0].Points.Count - CurChart.ChartAreas[0].AxisX.ScaleView.Size;
            CurChart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Silver;
            CurChart.ChartAreas[0].AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            //CurChart.ChartAreas[0].AxisX.ScrollBar.
             //CurChart.ChartAreas[0].AxisX.ScaleView.Size = 10;//可视区域数据点数 
             //CurChart.ChartAreas[0].AxisX.Interval = 2;
             //CurChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
           //CurChart.ChartAreas[0].AxisX.LabelStyle.Interval = 10; 
           //CurChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            //CurChart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            ////CurChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //CurChart.ChartAreas[0].AxisX.ScrollBar.Size = 10;
            //CurChart.ChartAreas[0].AxisX.ScaleView.MinSize = 0.1  ;
            //CurChart.ChartAreas[0].AxisX.ScaleView.Position = CurChart.Series[0].Points.Count - CurChart.ChartAreas[0].AxisX.ScaleView.Size;
            //CurChart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Silver;
            //CurChart.ChartAreas[0].AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            ////invokeChartData[0] = CurChart;
            //invokeChartData[1] = dataTable;

            /*Chart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            Chart.ChartAreas[0].CursorY.AutoScroll = true;
            Chart.ChartAreas[0].CursorY.IsUserEnabled = true;
            Chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            Chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            Chart.ChartAreas[0].AxisY.IsLabelAutoFit = false;
            Chart.ChartAreas[0].AxisY.ScaleView.Position = 0;
            Chart.ChartAreas[0].AxisY.ScaleView.Size = 23;
            Chart.ChartAreas[0].AxisY.ScrollBar.ButtonColor = System.Drawing.Color.Silver;
            Chart.ChartAreas[0].AxisY.ScrollBar.LineColor = System.Drawing.Color.Black;
             */
            int ParentNode = this.m_ParentForm.thread.totalNodeCount;
            for (int i = 0; i < ParentNode; i++)
            {
                combox_Node.Items.Add(i+1);
            }
            if (combox_Node.Items.Count > 0)
                combox_Node.SelectedIndex = 0;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (cur_ch == -1 || cur_ch>3)
                return;
            this.CurChart.Series[cur_ch].Points.DataBind(dataSet.Tables[cur_ch].AsEnumerable(), dataSet.Tables[cur_ch].Columns[0].ColumnName, dataSet.Tables[cur_ch].Columns[1].ColumnName, "");
        }

        private void combox_Node_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combox_Node.SelectedIndex == -1)
            {
                cur_node = -1;
                return;
            }
            combox_ch.Items.Clear();
            cur_node = Convert.ToInt16(combox_Node.SelectedItem);
            int NodeCH = this.m_ParentForm.thread.nodeChNum[cur_node-1];
            for (int i = 0; i < NodeCH; i++)
            {
                combox_ch.Items.Add(i + 1);
            }
            if (combox_ch.Items.Count > 0)
                combox_ch.SelectedIndex = 0;
        }

        private void combox_ch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combox_ch.SelectedIndex == -1)
            {
                cur_ch = -1;
                return;
            }
            cur_ch = Convert.ToInt16(combox_ch.SelectedItem);
        }
        ///// <summary>
        ///// 执行委托
        ///// </summary>
        //public void UpdateChart()
        //{
        //    CurChart.BeginInvoke(new ChartDelegate(ChartDelegateMethod), invokeChartData);
        //}

        ///// <summary>
        ///// 委托方法
        ///// </summary>
        ///// <param name="_Chart">要更新的Chart控件</param>
        ///// <param name="_dataTable">要写入的数据</param>
        //public void ChartDelegateMethod(Chart _Chart, DataTable _dataTable)
        //{
        //    _Chart.Series[0].Points.DataBind(this.dataTable.AsEnumerable(), "时间", "数据", "");
        //}


    }
}
