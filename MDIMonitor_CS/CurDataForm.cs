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
        private DateTime nowtime = new DateTime();
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
        private void MainFrame_Load()
        {
            
            //this.m_ParentForm.PostMessage(6);
        }
        private void InitChart()//初始化chart
        {
            dataTable.Columns.Add("时间", typeof(String));
            dataTable.Columns.Add("数据", typeof(double));
            Random ran = new Random();
            DateTime stime = new DateTime(2014, 1, 1, 0, 0, 0);
            DateTime etime = new DateTime(2014, 1, 1, 0, 0, 1);
            TimeSpan step = etime - stime;
            nowtime = new DateTime(2014, 1, 1, 0, 0, 0);
            for (int j = 0; j < 100; j++)
            {
                nowtime = nowtime + step;
                dataTable.Rows.Add(nowtime.ToString("无效数据"), 0);
            }
            Series series = new Series("监测1");
            series.Points.DataBind(dataTable.AsEnumerable(), "时间", "数据", "");
            series.ChartType = SeriesChartType.Spline;
            this.CurChart.Series.Add(series);
            CurChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            CurChart.ChartAreas[0].AxisX.ScrollBar.Size = 10;
            CurChart.ChartAreas[0].AxisX.ScaleView.Size = 40;//可视区域数据点数 
            CurChart.ChartAreas[0].AxisX.ScaleView.MinSize = 4;
            CurChart.ChartAreas[0].AxisX.ScaleView.Position = CurChart.Series[0].Points.Count - CurChart.ChartAreas[0].AxisX.ScaleView.Size;
            CurChart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Silver;
            CurChart.ChartAreas[0].AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            //invokeChartData[0] = CurChart;
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
