using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Data.SQLite;

namespace MDIMonitor_CS
{
    public partial class HisDataForm : Form
    {
        FrameWin m_ParentForm = null;
        public DataTable dataTable = new DataTable();
        private DataTable sqlDataTable = new DataTable();
        private DateTime nowtime = new DateTime();
        public FileInfo openFile = null;
        public int totalRows = 0;
        //private SQLiteConnection dataBase = null;
        private SQLiteCommand sqlCommand = null;
        private int[] TableRowsCount = new int[12];
        public delegate void delegateChartScroll(ScrollBarEventArgs e);
        //ScrollBarEventArgs scroll_e = null;
        //int wideth = 0;
        //public delegate void ChartDelegate(Chart _Chart, DataTable _dataTable);
        //private object[] invokeChartData = new object[2];
        public HisDataForm(FrameWin parent)
        {
            InitializeComponent();
            m_ParentForm = parent;
            sqlCommand = new SQLiteCommand();
            //openFile = new FileInfo();
            MainFrame_Load();
            InitChart();
            //Form.CheckForIllegalCrossThreadCalls = false;
        }
        private void MainFrame_Load()
        {
            this.Size = new Size(1033, 486);
            hScroll_His.Minimum = 0;
            hScroll_His.Maximum = 100;
            hScroll_His.LargeChange = 35;
            hScroll_His.SmallChange = 1;
            this.listView_File.Columns.Add("文件名", 120, HorizontalAlignment.Left);
            this.listView_File.Columns.Add("大小", 70, HorizontalAlignment.Left);
            this.listView_File.Columns.Add("修改日期", 140, HorizontalAlignment.Left);
            listView_File.GridLines = true;
            listView_File.View = View.Details;
            //listView_File.Clear();
            //listView_File.BeginUpdate();
            //ColumnHeader ch = new ColumnHeader();
            // ch.Text = "文件名";
            // ch.Width = 120;
            // listView_File.Columns.Add(ch);

            //ch = new ColumnHeader();
            //ch.Width = 70;
            // ch.Text = "大小";
            // listView_File.Columns.Add(ch);

            //ch = new ColumnHeader();
            //ch.Text = "修改日期";
            // ch.Width = 140;
            // listView_File.Columns.Add(ch);
            // listView_File.BeginUpdate();
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
                dataTable.Rows.Add(nowtime.ToString("示例数据"), 0);
            }
            Series series = new Series("监测1");
            series.Points.DataBind(dataTable.AsEnumerable(), "时间", "数据", "");
            series.ChartType = SeriesChartType.Spline;
            this.HisChart.Series.Add(series);
            hScroll_His.Enabled = false;
            //HisChart.ChartAreas[0].AxisX.ScrollBar.Axis.Interval = 80;
            //HisChart.AxisScrollBarClicked += new delegateChartScroll(ChartScroll),null);
            //HisChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            //HisChart.ChartAreas[0].AxisX.ScrollBar.Size = 11;
            HisChart.ChartAreas[0].AxisX.ScaleView.Size = 35;//可视区域数据点数 
            HisChart.ChartAreas[0].AxisX.ScaleView.MinSize = 4;
            //HisChart.ChartAreas[0].AxisX.ScaleView.Position = HisChart.Series[0].Points.Count - HisChart.ChartAreas[0].AxisX.ScaleView.Size;
            //HisChart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Silver;
            //HisChart.ChartAreas[0].AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            //scroll_e = new ScrollBarEventArgs(HisChart.ChartAreas[0].AxisX,Control.MousePosition.X,Control.MousePosition.Y,HisChart.ChartAreas[0].AxisX.ScrollBar.)
            //invokeChartData[0] = HisChart;
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

        private void ChartScroll(ScrollBarEventArgs e)
        {
 
        }
        private void hScroll_His_Scroll(object sender, ScrollEventArgs e)
        {
            ReadDataToSQL();
            //m_ParentForm.statusLabel.Text = String.Format("pos={0}", hScroll_His.Value);
        }

        private void btn_Brower_Click(object sender, EventArgs e)
        {
            
            folderBrowser.RootFolder = Environment.SpecialFolder.Desktop;
            if (Directory.Exists(Application.StartupPath + "\\Database"))
            {
                folderBrowser.SelectedPath = Application.StartupPath + "\\Database";
            }
            //if(Application.StartupPath
            //folderBrowser.SelectedPath = Application.StartupPath;

            if (folderBrowser.ShowDialog() == DialogResult.OK && folderBrowser.SelectedPath != "")
            {
                listView_File.Items.Clear();
                text_path.Text = folderBrowser.SelectedPath;
                this.listView_File.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度 
                DirectoryInfo theFolder = new DirectoryInfo(folderBrowser.SelectedPath);
                FileInfo[] thefileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                foreach (FileInfo NextFile in thefileInfo)  //遍历文件
                {
                    ListViewItem lvi = new ListViewItem();

                    //lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标 

                    lvi.Text = NextFile.Name;

                    lvi.SubItems.Add(((NextFile.Length) / 1024).ToString() + "KB");

                    lvi.SubItems.Add(NextFile.LastAccessTime.ToLocalTime().ToString());

                    this.listView_File.Items.Add(lvi);
                    //list.Add(NextFile.FullName);
                }
                this.listView_File.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            }
        }

        private void listView_File_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView_File.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                var videoitem = info.Item as ListViewItem;
                string path = text_path.Text + "\\" + videoitem.Text;
                if (File.Exists(path))
                {
                    hScroll_His.Enabled = true;
                    totalRows = 0;
                    openFile = new FileInfo(path);
                    SQLiteConnection dataBase = new SQLiteConnection("Data Source=" + path + ";Version=3;");
                    SQLiteCommand sqlCommand = new SQLiteCommand();
                    SQLiteDataReader sqlReader = null;
                    dataBase.Open();
                    sqlCommand.Connection = dataBase;
                    //for (int i = 0; i < 12; i++)
                    //{
                    string sqlcmd = String.Format("select Count from {0}", "TableRows");
                    sqlCommand.CommandText = sqlcmd;
                    sqlReader = sqlCommand.ExecuteReader();
                    int count = 0;
                    int i = 0;
                    while (sqlReader.Read())
                    {
                        count = Convert.ToInt16(sqlReader[0]);
                        totalRows += count;
                        if (i < 12)
                            TableRowsCount[i++] = count;
                    }
                    sqlReader.Close();
                    //}
                    //wideth = (int)(HisChart.ChartAreas[0].AxisX.ScrollBar.Size);
                    hScroll_His.Minimum = 1;
                    hScroll_His.Maximum = totalRows;
                    hScroll_His.LargeChange = 35;
                    hScroll_His.Value = 1;
                    ReadDataToSQL();
                }
                else
                    m_ParentForm.statusLabel.Text = String.Format("数据库不存在");
            }
        }

        ///// <summary>
        ///// 执行委托
        ///// </summary>
        //public void UpdateChart()
        //{
        //    HisChart.BeginInvoke(new ChartDelegate(ChartDelegateMethod), invokeChartData);
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

        public bool ReadDataToSQL()//
        {
            if (openFile == null)
            {
                m_ParentForm.statusLabel.Text = String.Format("数据库不存在");
                return false;
            }
            //hScroll_His.Width = wideth;
            int min = hScroll_His.Value;
            int max = hScroll_His.Value + hScroll_His.LargeChange;
            int range = hScroll_His.LargeChange;
            m_ParentForm.statusLabel.Text = String.Format("数据载入中");
            //dataBase = new SQLiteConnection("Data Source=" + openFile.FullName + ";Version=3;");

            //dataBase.Open();
            //sqlCommand.Connection = dataBase;
            ////string tableName = null;
            //string sqlcmd = null;
            //sqlcmd = String.Format("select Count from {0}", "TableRows");
            //sqlCommand.CommandText = sqlcmd;
            //SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            //string count = null;
            //int i = 0;
            //while (sqlReader.Read())
            //{
            //    if (i > 11)
            //        break;
            //    count = null;
            //    count = String.Format("{0}", sqlReader[0]);
            //    if (count != null)
            //        TableRowsCount[i++] = Convert.ToInt16(count);
            //}
            //sqlReader.Close();
            //dataBase.Close();
            //for (i = 0; i < hScroll_His.LargeChange; i++)
            //{
            //if (openFile == null)
            //{
            //    m_ParentForm.statusLabel.Text = String.Format("数据库不存在");
            //    return false;
            //}

            //dataBase = new SQLiteConnection("Data Source=" + openFile.FullName + ";Version=3;");
            //dataBase.Open();
            //sqlCommand.Connection = dataBase;
            //string LMD = null;
            //string Pos = null;
            //string Unit = null;
            //string count = null;
            string tableName = null;
            string sqlcmd = null;
            int dataTableCount = 0;
            int tableRowsCount = 0;
            bool readFlag = false;
            sqlDataTable.Clear();
            //dataGridView1.DataSource = dataTable;
            SQLiteDBHelper SQLHelper = new SQLiteDBHelper(openFile.FullName);
            for (int i = 0; i < 12; i++)
            {
                tableName = String.Format("_{0}_00_00", (i * 2).ToString().PadLeft(2, '0'));
                int nummin = 0;
                int nummax = 0;
                if (TableRowsCount[i] != 0 && min >= tableRowsCount + 1 && min <= tableRowsCount + TableRowsCount[i])//tableRowsCount + TableRowsCount[i]>=min && tableRowsCount < max && 
                {
                    nummin = min - tableRowsCount;
                    nummax = (nummin + range - 1) < TableRowsCount[i] ? (nummin + range - 1) : TableRowsCount[i];
                    readFlag = true;
                    sqlcmd = String.Format("select * from {0} where NUM>={1} and NUM <={2}", tableName, nummin, nummax);
                    sqlDataTable.Merge(SQLHelper.ExecuteDataTable(sqlcmd, null));

                    if (sqlDataTable.Rows.Count >= range)
                        break;
                    //if(dt!=null)
                    //    dataGridView1.DataSource = dt;
                    //count = String.Format("{0}", dt.Rows[1][0]);
                    //count = String.Format("{0}", dt.Rows[1][1]);
                    //count = String.Format("{0}", dt.Rows[1][2]);
                    //count = String.Format("{0}", dt.Rows[1][3]);
                    //count = String.Format("{0}", dt.Rows[1][4]);
                    //dataTableCount++;
                    //if (dataTableCount >= range)
                    //    break;
                    //sqlReader.Close();
                    //if (dataTableCount >= range)
                    //    break;
                    //if (tableRowsCount <= min && tableRowsCount + TableRowsCount[i] >= min)
                    //sqlcmd = String.Format("select * from {0} where NUM>={1} and NUM <={2}", tableName, min - tableRowsCount+1, dataTableCount - tableRowsCount);
                    //sqlCommand.CommandText = sqlcmd;
                    //SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
                }
                //if (readFlag == true)
                //{
                //}
                //tableName = String.Format("_{0}_00_00", (i * 2).ToString().PadLeft(2, '0'));
                if (readFlag == true)
                {
                    nummin = 1;
                    nummax = TableRowsCount[i] < range - dataTableCount ? TableRowsCount[i] : nummin;
                    //sqlCommand.CommandText = sqlcmd;
                    //SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
                    sqlcmd = String.Format("select * from {0} where NUM>={1} and NUM <={2}", tableName, nummin, nummax);
                    //DataTable dt = SQLHelper.ExecuteDataTable(sqlcmd,null);
                    sqlDataTable.Merge(SQLHelper.ExecuteDataTable(sqlcmd, null));

                    //if (dataTable.Rows.Count >= range)
                    //    break;
                }
                tableRowsCount = tableRowsCount + TableRowsCount[i];
                //string count = null;
            }
            if (sqlDataTable.Rows.Count==0)
            {
                m_ParentForm.statusLabel.Text = String.Format("数据库中无有效数据");
                return false;
            }
            if (sqlDataTable.Rows.Count > 0)
            {
                dataTable.Rows.Clear();
                //dataTable.Columns[1].DataType = typeof(double);
                //Random ran = new Random();
                for (int i = 0; i < sqlDataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.NewRow();
                    row["时间"] = sqlDataTable.Rows[i][1];
                    row["数据"] = Convert.ToDouble(sqlDataTable.Rows[i][3]);
                    dataTable.Rows.Add(row);
                }
                this.m_ParentForm.PostMessage(1,1);
                //
                //dataTable.Columns.RemoveAt(5);
                //dataTable.Columns.RemoveAt(4);
                //dataTable.Columns.RemoveAt(2);
                //dataTable.Columns.RemoveAt(0);
                //sqlDataTable.Columns[3].DataType = typeof(double);
                //HisChart.Series[0].Points.DataBind(dataTable.AsEnumerable(), "时间", "数据", "");
                text_lmd.Text = sqlDataTable.Rows[0][2].ToString();
                text_pos.Text = sqlDataTable.Rows[0][5].ToString();
            }
            m_ParentForm.statusLabel.Text = String.Format("数据已载入");
            return true;

            //}
            //catch (Exception e)
            //{
            //    m_ParentForm.statusLabel.Text = String.Format("数据写入失败");
            //    MessageBox.Show(e.Message);
            //    return false; ;
            //}
            
        }
    }

}
