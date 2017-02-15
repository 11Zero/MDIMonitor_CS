using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Data.SQLite;

namespace MDIMonitor_CS
{
    public class UIThread
    {
        private bool end = false;//结束线程标志
        private bool kill = false;//终结线程标志
        private bool stop = false;//暂停线程标志
        private Thread thread = null;//恢复线程标志
        private Queue<int> msgQueue = null;//存储消息队列
        FrameWin Parent = null;//用于传入其他线程句柄，一般通过线程刷新某个窗口UI,FrameWin是需要控制的窗口类，自行修改
        private bool userStopFlag = false;
        private SQLiteConnection dataBase = null;
        private SQLiteCommand sqlCommand = null;
        public delegate void ChartDelegate(int _ch, DataTable _dataTable, int Form_id);
        public delegate void HisChartDelegate(Chart _Chart, DataTable _dataTable);
        //public delegate void PanelDelegate(Panel _panel, int _grid_id);
        private object[] invokeChartData = new object[3];
        private object[] invokeHisChartData = new object[2];
        //private object[] invokePanelData = new object[2];
        private int totalNode = 4;
        private int[] CH_Node = new int[4];
        private DataTable hisChartData = new DataTable();
        public List<DataTable> userDataTable = new List<DataTable>();
        private DateTime nowtime = new DateTime();//System.DateTime.Now;//new DateTime().TimeOfDay;
        public UIThread(Form parent)
        {
            Parent = (FrameWin)parent;//强制转换
            msgQueue = new Queue<int>();
            sqlCommand = new SQLiteCommand();
            thread = new Thread(new ThreadStart(Run));//真正定义线程
            for (int i = 0; i < 4; i++)
            {
                CH_Node[i] = 4;
            }
            DataTable dt = new DataTable();
            for (int i = 0; i < 4; i++)
            {
                userDataTable.Add(dt); 
            }
        }
        ~UIThread()
        {
            this.End();//析构时结束线程
        }
        public void PostMessage(int id)//id为传入的消息标识
        {
            if (end || kill)//如果线程结束或终止，不执行任何动作
                return;
            if (id > 0)
                msgQueue.Enqueue(id);//将post来的消息添加到消息队列
            if (stop)
                return;//如果线程暂停，将只接受消息，暂不执行，一旦线程恢复，继续执行所接收消息
            if (!this.thread.IsAlive)//如果线程未开启，将启动线程
                this.thread.Start();
        }
        public void Start()
        {
            if (end || kill)//如果线程已被结束或终止，将不执行任何动作
                return;
            if (!this.thread.IsAlive)//如果线程未开启，将启动线程
                thread.Start();
        }
        public void End()
        {
            end = true;//如果线程结束，将结束标识设为真，线程将在消息队列中所有消息执行完后终止
            Console.WriteLine("结束线程");
        }
        public void Kill()
        {
            kill = true;//如果线程终止，将终止标识设为真，线程将不再执行消息队列中剩余消息
            Console.WriteLine("终止线程");
        }
        public void Stop()
        {
            stop = true;//如果线程暂停，将暂停标识设为真，线程将暂不执行消息队列中剩余消息，
            //但是消息队列仍然在接收消息，一旦线程恢复，继续执行所接收消息
            Console.WriteLine("暂停线程");
        }
        public void Resume()
        {
            stop = false;//如果线程恢复，将恢复标识设为真，线程将继续执行消息队列中剩余消息
            Console.WriteLine("恢复线程");
        }
        private void Run()
        {
            while (true)
            {
                if (kill)//如果线程终止，线程函数将立即跳出，消息队列里剩余消息不再执行，此线程结束，无法再开启
                    break;
                if (!stop && msgQueue.Count != 0)//如果线程未被暂停且消息队列中有剩余消息，将顺序执行剩余消息
                {
                    //if (msgQueue.Count > 200 && userStopFlag == false)
                    //{
                    //    this.Parent.thread.Stop();
                    //    userStopFlag =true;
                    //    Parent.statusLabel.Text = String.Format("当前数据采集频率过高，暂缓采集");
                    //}
                    //if (msgQueue.Count <= 200 && userStopFlag == true)
                    //{
                    //    this.Parent.thread.Resume();
                    //    userStopFlag = false;
                    //    Parent.statusLabel.Text = String.Format("数据采集已恢复");
                    //}
                    switch (msgQueue.Peek())//获取当前消息队列中消息，并一一比对执行相应的动作
                    {
                        case 1:
                            {
                                msgFunction_1();//例如消息码为1是，执行msgFunction_1()函数
                            } break;
                        case 2:
                            {
                                msgFunction_2();//例如消息码为2是，执行msgFunction_2()函数
                            } break;
                        case 3:
                            {
                                msgFunction_3();//例如消息码为3是，执行msgFunction_2()函数
                            } break;
                        case 4:
                            {
                                msgFunction_4();//例如消息码为3是，执行msgFunction_2()函数
                            } break;
                        case 5:
                            {
                                msgFunction_5();//例如消息码为3是，执行msgFunction_2()函数
                            } break;
                    }
                    msgQueue.Dequeue();//比对完当前消息并执行相应动作后，消息队列扔掉当前消息
                }
                if (msgQueue.Count == 0 && end)//如果线程被结束时当前消息队列中没有消息，将结束此线程
                    //如果当前消息队列中仍有未执行消息，线程将执行完所有消息后结束
                    break;
                System.Threading.Thread.Sleep(1);//每次循环间隔1ms，我还不知道到底有没有必要
            }
        }

        /// <summary>
        /// 创建并以以节点号_通道号命名数据库，所有数据库存放在以日期命名的数据文件夹下
        /// 每个数据库内部按时间段将该节点该通道的数据存放在不同的表中，表名称以时间段命名
        /// </summary>
        /// <param name="node">节点号</param>
        /// <param name="ch">通道号</param>
        /// <returns></returns>

        private bool CreateDataSQL(int node, int ch)
        {
            return true;
            //string fileName = String.Format("NODE{0}CH{1}", node, ch);
            //string path = "Database";
            //if (Directory.Exists(path) == false)
            //    Directory.CreateDirectory(path);
            //path = path + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd");
            //if (Directory.Exists(path) == false)
            //    Directory.CreateDirectory(path);
            //try
            //{

            //    FileInfo DatabaseFile = new FileInfo(path + "\\" + fileName);
            //    if (!DatabaseFile.Exists)
            //    {
            //        //if (!DatabaseFile.Directory.Exists)
            //        //{
            //        //    DatabaseFile.Directory.Create();
            //        //}
            //        SQLiteConnection.CreateFile(DatabaseFile.FullName);
            //    }
            //    dataBase = new SQLiteConnection("Data Source=" + path + "\\" + fileName + ";Version=3;");
            //    dataBase.Open();
            //    sqlCommand.Connection = dataBase;
            //    string sqlcmd = null;
            //    sqlcmd = String.Format("create table if not exists {0} (NUM integer primary key autoincrement, Count integer)", "TableRows");
            //    sqlCommand.CommandText = sqlcmd;
            //    sqlCommand.ExecuteNonQuery();
            //    for (int i = 0; i < 12; i++)//表名字数据对应当天的时间段,每两小时为一个表
            //    {
            //        string tableName = String.Format("_{0}_00_00", (i * 2).ToString().PadLeft(2, '0'));
            //        sqlcmd = "create table if not exists " + tableName +
            //            "(NUM integer primary key autoincrement, DataTime varchar(50),LMD varchar(20),SensorVal varchar(20),Unit varchar(20),Pos varchar(50))";
            //        sqlCommand.CommandText = sqlcmd;
            //        sqlCommand.ExecuteNonQuery();
            //        sqlcmd = "insert into TableRows (Count) values (0)";
            //        sqlCommand.CommandText = sqlcmd;
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    dataBase.Close();
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.ToString());
            //}
            //return File.Exists(path + "\\" + fileName);
        }
        /// <summary>
        /// 将扫描到的节点数据写入数据库
        /// </summary>
        /// <param name="datastr">8个字符串[节点 通道 感应器名称 时间 灵敏度 测量值 单位 位置]</param>
        /// <returns>是否写入成功</returns>
        public bool WriteDataToSQL(string[] datastr)//
        {
            //string fileName = String.Format("NODE{0}CH{1}", datastr[0], datastr[1]);
            //string path = "Database";
            //if (Directory.Exists(path) == false)
            //    Directory.CreateDirectory(path);
            //path = path + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd");
            //if (Directory.Exists(path) == false)
            //    Directory.CreateDirectory(path);
            //if (!File.Exists(path + "\\" + fileName))
            //{
            //    if (!CreateDataSQL(Convert.ToInt16(datastr[0]), Convert.ToInt16(datastr[1])))
            //        return false;
            //}
            //try
            //{
            //    dataBase = new SQLiteConnection("Data Source=" + path + "\\" + fileName + ";Version=3;");
            //    dataBase.Open();
            //    sqlCommand.Connection = dataBase;
            //    string tableName = String.Format("_{0}_00_00", (Convert.ToInt16(datastr[3].Substring(0, 2)) - (Convert.ToInt16(datastr[3].Substring(0, 2))) % 2).ToString().PadLeft(2, '0'));
            //    string sqlcmd = String.Format("insert into {0} (DataTime,LMD,SensorVal,Unit,Pos) values ('{1}','{2}','{3}','{4}','{5}')", tableName, datastr[3], datastr[4], datastr[5], datastr[6], datastr[7]);
            //    sqlCommand.CommandText = sqlcmd;
            //    sqlCommand.ExecuteNonQuery();
            //    sqlcmd = String.Format("select Count from TableRows where NUM={0}", (Convert.ToInt16(datastr[3].Substring(0, 2))/2));
            //    sqlCommand.CommandText = sqlcmd;
            //    SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            //    string count = null;
            //    while (sqlReader.Read())
            //    {
            //        count = String.Format("{0}", sqlReader[0]);
            //    }
            //    sqlReader.Close();
            //    if (count != null)
            //    {
            //        sqlcmd = String.Format("update TableRows set Count={0} where NUM={1}", Convert.ToInt16(count)+1, (Convert.ToInt16(datastr[3].Substring(0, 2)) / 2));
            //        sqlCommand.CommandText = sqlcmd;
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    dataBase.Close();
            //    Parent.statusLabel.Text = String.Format("数据已写入");
            //    return true;

            //}
            //catch (Exception e)
            //{
            //    Parent.statusLabel.Text = String.Format("数据写入失败");
            return false; ;
            //}
        }


        public void ReadDataSQL()
        {//需要添加判断，浏览当前正使用的数据库时需要暂停监控
            //if (this.Parent.HisForm.openFile != null)
            //{ 
            //    SQLiteDBHelper SQLHelper = new SQLiteDBHelper(fileName);
            //DataTable dt = new DataTable();
            //for (int i = 0; i < totalNode; i++)
            //{
            //    string sqlcmd = String.Format("select * from {0} where NUM='{1}';)", tableName, i + 1);
            //    dt.Merge(SQLHelper.ExecuteDataTable(sqlcmd, null));
            //}
            ////hisChartData
            //}
        }
        private DataTable ReadUserSQL(string fileName, string tableName)
        {
            //string fileName = String.Format("NODE{0}CH{1}", datastr[0], datastr[1]);
            if (!File.Exists(fileName))
            {
                Parent.statusLabel.Text = String.Format("fileName文件未发现");
            }
            //DataTable schemaTable = null;
            //using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + fileName))
            //{
            //    connection.Open();
            //    DataTable table = connection.GetSchema("TABLES");
            //    if (table != null && table.Rows.Count > 0)
            //    {
            //        //string tableName = table.Rows[0]["TABLE_NAME"].ToString();

            //        //SQLiteConnection connection = new SQLiteConnection("Data Source=" + fileName);
            //        IDbCommand cmd = new SQLiteCommand();
            //        cmd.CommandText = string.Format("select * from [{0}]", tableName);
            //        cmd.Connection = connection;
            //        using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.KeyInfo | CommandBehavior.SchemaOnly))
            //        {
            //            schemaTable = reader.GetSchemaTable();
            //        }
            //        //DataTable schemaTable = GetReaderSchema(tableName, conn);
            //        //this.dataGridView1.DataSource = schemaTable;
            //    }
            //}

            //return schemaTable;
            //SQLiteConnection connection = new SQLiteConnection("Data Source="+fileName);
            //connection.Open();
            ////SQLiteCommand command = new SQLiteCommand(String.Format("select * from {0})", tableName),connection);
            ////SQLiteDataReader Reader = command.ExecuteReader();
            ////DataTable dt = Reader.GetSchemaTable();
            //DataTable dt = connection.GetSchema();
            SQLiteDBHelper SQLHelper = new SQLiteDBHelper(fileName);
            DataTable dt = new DataTable();
            for (int i = 0; i < totalNode; i++)
            {
                string sqlcmd = String.Format("select * from {0} where NUM='{1}';)", tableName, i + 1);
                dt.Merge(SQLHelper.ExecuteDataTable(sqlcmd, null));
            }
            //invokeDataGridViewData[0] = this.Parent.UserForm.grid_Userdat;
            //invokeDataGridViewData[1] = dt;
            //invokePanelData[0] = null;
            //invokePanelData[1] = 1;
            //UpdateDataGridView();
            //dataBase = new SQLiteConnection();//
            //dataBase.Open();
            //sqlCommand.Connection = dataBase;
            //string tableName = String.Format("_{00}_00_00", (Convert.ToInt16(datastr[3].Substring(0, 2)) - (Convert.ToInt16(datastr[3].Substring(0, 2))) % 2).ToString().PadLeft(2, '0'));
            //string sqlcmd = String.Format("insert into {0} (Name,Phone) values ('黄德洲','18956155198')", tableName);
            //string sqlcmd = "create table if not exists " + tableName +
            //"(NUM integer primary key autoincrement, Name varchar(20),Phone varchar(20))";
            //string sqlcmd = "create table if not exists " + tableName +
            //"(NUM integer primary key autoincrement,CH1 varchar(20),CH2 varchar(20),CH3 varchar(20),CH4 varchar(20),CH5 varchar(20),CH6 varchar(20))";
            //string sqlcmd = String.Format("insert into {0} (CH1,CH2,CH3,CH4,CH5,CH6) values " +
            //    "('102.5','102.5','102.5','102.5','102.5','102.5')", tableName);
            //string sqlcmd = String.Format("insert into {0} (CH1,CH2,CH3,CH4,CH5,CH6) values " +
            //    "('mm1','mm2','mm3','mm4','mm5','mm6')", tableName);
            //string sqlcmd = "create table if not exists " + tableName +
            //"(NUM integer primary key autoincrement,CH1 varchar(20),Unit1 varchar(20),CH2 varchar(20),Unit2 varchar(20)," +
            //"CH3 varchar(20),Unit3 varchar(20),CH4 varchar(20),Unit4 varchar(20),CH5 varchar(20),Unit5 varchar(20),CH6 varchar(20),Unit6 varchar(20))";
            //string sqlcmd = "";
            //sqlCommand.CommandText = sqlcmd;
            //sqlCommand.ExecuteNonQuery();
            //dataBase.Close();
            return dt;
        }
        private void WriteUserSQL(string fileName)
        {
            Parent.statusLabel.Text = String.Format("user数据库存储中");
            int stage = 1;
            string[] tableName = { "InitialVal", "Sensitivity", "Unit", "WarningVal" };
            //for (int i = 0; i < 4; i++)
            //{
            //    userDataTable[i] = ReadUserSQL("user.dat", String.Format("{0}_{1}", tableName[i], stage));
            //    while (userDataTable[i].Rows.Count > totalNode)
            //        userDataTable[i].Columns.RemoveAt(userDataTable[i].Rows.Count - 1);
            //    this.Parent.UserForm.data_dataGridView[i] = userDataTable[i];
            //    this.Parent.UserForm.databack_dataGridView[i] = userDataTable[i].Copy();
            //}
            SQLiteDBHelper SQLHelper = new SQLiteDBHelper(fileName);
            string sqlcmd = "";
            for (int i = 0; i < userDataTable.Count; i++)
            {
                for (int j = 0; j < userDataTable[i].Rows.Count; j++)
                {
                    sqlcmd = String.Format("update {0}_{8} set CH1='{1}',CH2='{2}',CH3='{3}',CH4='{4}',CH5='{5}',CH6='{6}' where NUM={7}",
                        tableName[i], userDataTable[i].Rows[j][1], userDataTable[i].Rows[j][2],
                        userDataTable[i].Rows[j][3], userDataTable[i].Rows[j][4], userDataTable[i].Rows[j][5], userDataTable[i].Rows[j][6], userDataTable[i].Rows[j][0], stage);
                    if (j+1 > totalNode)
                    {
                        sqlcmd = String.Format("insert into {0}_{8} (CH1,CH2,CH3,CH4,CH5,CH6) values('{1}','{2}','{3}','{4}','{5}','{6}')",
                        tableName[i], userDataTable[i].Rows[j][1], userDataTable[i].Rows[j][2],
                        userDataTable[i].Rows[j][3], userDataTable[i].Rows[j][4], userDataTable[i].Rows[j][5], userDataTable[i].Rows[j][6], userDataTable[i].Rows[j][0], stage);
                    }
                    SQLHelper.ExecuteNonQuery(sqlcmd, null);
                }
            }
            Parent.statusLabel.Text = String.Format("user数据库存储完成");
            return;
        }
        ///// <summary>
        ///// 执行DataGridView委托
        ///// </summary>
        //private void UpdateDataGridView()
        //{
        //    this.Parent.UserForm.grid_Userdat.BeginInvoke(new DataGridViewDelegate(DataGridViewDelegateMethod), invokeDataGridViewData);
        //}

        ///// <summary>
        ///// Panel委托方法
        ///// </summary>
        ///// <param name="_Chart">要更新的Panel控件</param>
        ///// <param name="_dataTable">要写入的数据</param>
        //public void PanelDelegateMethod(Panel _panel, int _grid_id)
        //{
        //    if (_grid_id > 3)
        //        return;
        //    this.Parent.UserForm.cur_dataGrid_id = _grid_id;
        //    this.Parent.UserForm.dataGridView[_grid_id].DataSource = userDataTable[_grid_id];
        //     this.Parent.UserForm.dataGridView[_grid_id].Show();
        //   //this.Parent.UserForm.dataGridView[_grid_id].Size = _panel.Size;
        //    //this.Parent.UserForm.dataGridView[_grid_id].Parent = _panel;
        //    //this.Parent.UserForm.dataGridView[_grid_id].CellBorderStyle = DataGridViewCellBorderStyle.Single;
        //    //this.Parent.UserForm.dataGridView[_grid_id].AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        //}

        ///// <summary>
        ///// 执行Panel委托
        ///// </summary>
        //private void UpdatePanel()
        //{
        //    this.Parent.UserForm.panel_DataGrid.BeginInvoke(new PanelDelegate(PanelDelegateMethod), invokeDataGridViewData);
        //}

        /// <summary>
        /// DataGridView委托方法
        /// </summary>
        /// <param name="_Chart">要更新的DataGridView控件</param>
        /// <param name="_dataTable">要写入的数据</param>
        //public void DataGridViewDelegateMethod(DataGridView _datagrid, DataTable _dataTable)
        //{
        //    this.Parent.UserForm.grid_Userdat.DataSource = _dataTable;
        //}


        /// <summary>
        /// 执行Chart委托
        /// </summary>
        private void UpdateChart(int Form_id,int node,int ch)
        {
            //for (int i = 0; i < 4; i++)
            //{
            if (Parent.CurForm[Form_id].IsHandleCreated == true)
                {
                    if (Parent.CurForm[Form_id].cur_ch == ch && Parent.CurForm[Form_id].cur_node == node)
                    {
                        invokeChartData[0] = ch - 1;
                        invokeChartData[1] = Parent.CurForm[Form_id].dataSet.Tables[ch - 1];
                        invokeChartData[2] = Form_id;
                        Parent.CurForm[Form_id].CurChart.BeginInvoke(new ChartDelegate(ChartDelegateMethod), invokeChartData);
                    }
                }
                
            //}
        }

        /// <summary>
        /// Chart委托方法
        /// </summary>
        /// <param name="_Chart">要更新的Chart控件</param>
        /// <param name="_dataTable">要写入的数据</param>
        public void ChartDelegateMethod(int _ch, DataTable _dataTable,int Form_id)
        {
            //for (int i = 0; i < 4; i++)
            //{
            Parent.CurForm[Form_id].CurChart.Series[_ch].Points.DataBind(_dataTable.AsEnumerable(), _dataTable.Columns[0].ColumnName, _dataTable.Columns[1].ColumnName, "");
                //series[i].Points.DataBind(dataTable.AsEnumerable(), "时间", series[i].Name, "");
                //series[i].ChartType = SeriesChartType.Spline;
                //this.CurChart.Series.Add(series[i]);
            //}
        }

        /// <summary>
        /// 执行HisChart委托
        /// </summary>
        private void UpdateHisChart()
        {
            invokeHisChartData[0] = Parent.HisForm.HisChart;
            invokeHisChartData[1] = Parent.HisForm.dataTable;
            Parent.HisForm.HisChart.BeginInvoke(new HisChartDelegate(HisChartDelegateMethod), invokeHisChartData);
        }

        /// <summary>
        /// HisChart委托方法
        /// </summary>
        /// <param name="_Chart">要更新的HisChart控件</param>
        /// <param name="_dataTable">要写入的数据</param>
        public void HisChartDelegateMethod(Chart _Chart, DataTable _dataTable)
        {
            _Chart.Series[0].Points.DataBind(_dataTable.AsEnumerable(), "时间", "数据", "");
        }
        //private void UpdateXml()
        //{
        //    totalNodeCount = Convert.ToInt16(getXmlValue("NODE", "id", "0", "Count"));
        //    if (totalNodeCount > 0)
        //    {
        //        nodeChNum = new int[totalNodeCount];
        //        for (int i = 0; i < totalNodeCount; i++)
        //        {
        //            nodeChNum[i] = Convert.ToInt16(getXmlValue("NODE", "id", String.Format("{0}", i + 1), "Count"));
        //        }
        //    }
        //}

        private void msgFunction_1()//更新历史chart
        {
            UpdateHisChart();
            //this.Parent.UserForm.InitialGrid();
            //if (true == CreateDataSQL(1, 2))//创建节点1通道2的数据库
            //    Parent.statusLabel.Text = String.Format("数据库文件NODE{0}CH{1}生成成功", 1, 2);
            //else
            //Parent.statusLabel.Text = String.Format("数据库文件NODE{0}CH{1}生成失败", 1, 2);
        }
        private void msgFunction_2()//更新CurForm中的chart控件
        {
            //DateTime stime = new DateTime(2014, 1, 1, 0, 0, 0);
            //DateTime etime = new DateTime(2014, 1, 1, 0, 0, 1);
            //TimeSpan step = new TimeSpan();//
            //Random ran = new Random();
            //step = etime - stime;
            //for (int i = 0; i < 100; i++)
            //{
            //    nowtime = nowtime + step;
            //}
            //nowtime = nowtime + step;
             string[] data = Parent.curDataValue;//上游获取的数据，在此刷入chart
           int ch = Convert.ToInt16(data[1]);
            int node = Convert.ToInt16(data[0]);
            for (int i = 0; i < 4; i++)
            {
                if (Parent.CurForm[i] == null || Parent.CurForm[i].IsDisposed)
                    continue;
                if (Parent.CurForm[i].cur_node == node)
                {
                    if (Parent.CurForm[i].dataTable.Rows.Count > 0)
                        Parent.CurForm[i].dataTable.Rows.RemoveAt(0);
                    if (ch > 4 && ch < 1)
                    {
                        return;
                    }
                    //DateTime nowtime = DateTime.Now;

                    //nowtime = DateTime.Parse(DateTime.Now.ToShortDateString() + " " + data[3]);
                    //time = nowday.ToLongDateString();
                    //time = nowday.ToLongTimeString();
                    Parent.CurForm[i].dataSet.Tables[ch - 1].Rows.Add(data[3], data[5]);
                    this.UpdateChart(i,node, ch);
                }
                
            }
        }
        private void msgFunction_3()//写入Data到SQLite
        {
            WriteDataToSQL(Parent.curDataValue);
        }

        private void msgFunction_4()//读测量参数
        {
            
            Parent.statusLabel.Text = String.Format("载入数据库中");
            int stage = 1;
            //int grid_id = this.Parent.UserForm.cur_dataGrid_id;
            //if (grid_id > 3)
            //    return;
            string[] tableName = { "InitialVal", "Sensitivity", "Unit", "WarningVal" };
            for (int i = 0; i < 4; i++)
            {
                userDataTable[i] = ReadUserSQL("user.dat", String.Format("{0}_{1}", tableName[i], stage));
                while (userDataTable[i].Rows.Count>totalNode)
                    userDataTable[i].Columns.RemoveAt(userDataTable[i].Rows.Count-1);
                this.Parent.UserForm.data_dataGridView[i] = userDataTable[i].Copy();
                this.Parent.UserForm.databack_dataGridView[i] = userDataTable[i].Copy();
            }
            Parent.statusLabel.Text = String.Format("载入完成");
            if (this.Parent.UserForm.data_dataGridView[0].Columns.Count == 0)
            {
                Parent.statusLabel.Text = String.Format("载入未完成");
            }
            //this.Parent.StripContainer.ContentPanel.Controls.Clear();
            //this.Parent.UserForm.Size = this.Parent.StripContainer.ContentPanel.Size;
            //this.Parent.UserForm.Parent = this.Parent.StripContainer.ContentPanel;
            //this.Parent.UserForm.InitialGrid();
            //this.Parent.UserForm.Show();

        }
        private void msgFunction_5()//修改测量参数数据库
        {
            WriteUserSQL("user.dat");
        }
    }
}