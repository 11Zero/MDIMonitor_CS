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
using ClassForecast;

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
        public delegate void ChartDelegate(int _ch, DataTable _dataTable, int Form_id, int _node);
        public delegate void HisChartDelegate(Chart _Chart, DataTable _dataTable);
        public delegate void UserDataDelegate(DataTable _dataTable);
        //public delegate void PanelDelegate(Panel _panel, int _grid_id);
        private object[] invokeChartData = new object[4];
        private object invokeUserGridData = new object();
        private object[] invokeHisChartData = new object[2];
        //private object[] invokePanelData = new object[2];
        public int totalNode = 0;
        private int CH_Node = 0;
        public double[,] init_val = null;
        public int stage = 1;
        public string[] phone_cmd = new string[3];//存储接收到的用户短信号码,时间和指令
        private string[,] data_of_all_node = null;//临时存储当前扫描到的节点通道数据
        public bool smssended = true;//判断需要的短信是否已发送
        //private int data_node_count = 0;
        private DataTable hisChartData = new DataTable();
        public List<DataTable> userDataTable = new List<DataTable>();
        public DataTable AdminDataTable = new DataTable();
        private DateTime nowtime = new DateTime();//System.DateTime.Now;//new DateTime().TimeOfDay;
        public Forecast[,] dataForecast = null;
        public UIThread(Form parent)
        {
            Parent = (FrameWin)parent;//强制转换
            msgQueue = new Queue<int>();
            sqlCommand = new SQLiteCommand();
            thread = new Thread(new ThreadStart(Run));//真正定义线程
            thread.IsBackground = true;
            totalNode = this.Parent.nodeNum;
            init_val = new double[totalNode, 8];
            data_of_all_node = new string[totalNode, 8];
            CH_Node = 8;
            DataTable dt = new DataTable();
            for (int i = 0; i < 7; i++)
            {
                userDataTable.Add(dt);
            }
            //totalNode = this.Parent.thread.totalNodeCount;
            //CH_Node = this.Parent.thread.nodeChNum;
            totalNode = this.Parent.nodeNum;
            CH_Node = this.Parent.thread[0].nodeChNum;
            dataForecast = new Forecast[totalNode, 8];
            for (int i = 0; i < totalNode; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dataForecast[i, j] = new Forecast();
                    dataForecast[i, j].input_col = 3;
                    dataForecast[i, j].input_row = 30;
                    dataForecast[i, j].input_test_row = 5;
                    dataForecast[i, j].sample_num = 5;
                }
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
                            }
                            break;
                        case 2:
                            {
                                msgFunction_2();//例如消息码为2是，执行msgFunction_2()函数
                            }
                            break;
                        case 3:
                            {
                                msgFunction_3();//例如消息码为3是，执行msgFunction_2()函数
                            }
                            break;
                        case 4:
                            {
                                msgFunction_4();//例如消息码为3是，执行msgFunction_2()函数
                            }
                            break;
                        case 5:
                            {
                                msgFunction_5();//例如消息码为3是，执行msgFunction_2()函数
                            }
                            break;
                        case 6:
                            {
                                msgFunction_6();//例如消息码为3是，执行msgFunction_2()函数
                            }
                            break;
                        case 7:
                            {
                                msgFunction_7();//例如消息码为3是，执行msgFunction_2()函数
                            }
                            break;
                        case 8:
                            {
                                msgFunction_8();//例如消息码为3是，执行msgFunction_2()函数
                            }
                            break;
                        case 9:
                            {
                                msgFunction_9();//例如消息码为3是，执行msgFunction_2()函数
                            }
                            break;
                        case 10:
                            {
                                msgFunction_10();//例如消息码为3是，执行msgFunction_2()函数
                            }
                            break;
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
        public DataTable ReadUserSQL(string fileName, string tableName)
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
            if (tableName == "Admin")
            {
                string sqlcmd = String.Format("select * from {0} where NUM>0 and NUM<100;)", tableName);
                dt = SQLHelper.ExecuteDataTable(sqlcmd, null);
                return dt;
            }
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
            //int stage = 1;
            string[] tableName = { "InitialVal", "Sensitivity", "Unit", "WarningVal_1", "WarningVal_2", "Position", "Name" };
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
                    if (j + 1 > totalNode)
                    {
                        sqlcmd = String.Format("insert into {0}_{8} (CH1,CH2,CH3,CH4,CH5,CH6) values('{1}','{2}','{3}','{4}','{5}','{6}')",
                        tableName[i], userDataTable[i].Rows[j][1], userDataTable[i].Rows[j][2],
                        userDataTable[i].Rows[j][3], userDataTable[i].Rows[j][4], userDataTable[i].Rows[j][5], userDataTable[i].Rows[j][6], userDataTable[i].Rows[j][0], stage);
                    }
                    SQLHelper.ExecuteNonQuery(sqlcmd, null);
                }
            }
            DataTable dt = new DataTable();
            sqlcmd = String.Format("select * from Admin where NUM>0 and NUM<100;)");
            dt = SQLHelper.ExecuteDataTable(sqlcmd, null);
            int rowsCount = AdminDataTable.Rows.Count;
            for (int i = 0; i < rowsCount; i++)
            {
                string str = AdminDataTable.Rows[i][1].ToString().Replace(" ", "");
                if (str == "")
                {
                    rowsCount--;
                    AdminDataTable.Rows.RemoveAt(i);
                    i--;
                }
            }

            sqlcmd = String.Format("delete from Admin");
            SQLHelper.ExecuteNonQuery(sqlcmd, null);
            sqlcmd = String.Format("update sqlite_sequence SET seq = 0 where name ='Admin'");
            SQLHelper.ExecuteNonQuery(sqlcmd, null);

            for (int j = 0; j < AdminDataTable.Rows.Count; j++)
            {
                sqlcmd = String.Format("insert into Admin (Name,Phone,Checked) values ('{0}','{1}','{2}')",
                    AdminDataTable.Rows[j][1], AdminDataTable.Rows[j][2], AdminDataTable.Rows[j][3]);
                //if (j + 1 > totalNode)
                //{
                //    sqlcmd = String.Format("insert into {0}_{8} (CH1,CH2,CH3,CH4,CH5,CH6) values('{1}','{2}','{3}','{4}','{5}','{6}')",
                //    tableName[i], userDataTable[i].Rows[j][1], userDataTable[i].Rows[j][2],
                //    userDataTable[i].Rows[j][3], userDataTable[i].Rows[j][4], userDataTable[i].Rows[j][5], userDataTable[i].Rows[j][6], userDataTable[i].Rows[j][0], stage);
                //}
                SQLHelper.ExecuteNonQuery(sqlcmd, null);
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
        private void UpdateChart(int Form_id, int node, int ch)
        {
            //for (int i = 0; i < 4; i++)
            //{
            try
            {
                if (Parent.CurForm[Form_id].IsHandleCreated == true)
                {
                    if (Parent.CurForm[Form_id].cur_node == node)
                    {
                        invokeChartData[0] = ch;
                        invokeChartData[1] = Parent.CurForm[Form_id].dataSet.Tables[ch - 1].Copy();
                        invokeChartData[2] = Form_id;
                        invokeChartData[3] = node;
                        Parent.CurForm[Form_id].CurChart.BeginInvoke(new ChartDelegate(ChartDelegateMethod), invokeChartData);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //}
        }

        /// <summary>
        /// Chart委托方法
        /// </summary>
        /// <param name="_Chart">要更新的Chart控件</param>
        /// <param name="_dataTable">要写入的数据</param>
        public void ChartDelegateMethod(int _ch, DataTable _dataTable, int Form_id, int _node)
        {
            //for (int i = 0; i < 4; i++)
            //{
            try
            {
                //Parent.CurForm[Form_id].CurChart.Series[_ch+3].Points.DataBind(_dataTable.AsEnumerable(), _dataTable.Columns[0].ColumnName, _dataTable.Columns[1].ColumnName, "");
                //*问题，通道一总是出现序列为空
                if (dataForecast[_node - 1, _ch - 1].IsFilled)
                {
                    //if (_ch - 1 == 0)
                    //{
                    //    string str = "";
                    //}
                    DataTable dt = _dataTable.Copy();
                    dt.Merge(dataForecast[_node - 1, _ch - 1].MakeForecast(0).Copy());
                    //this.CurChart.Series[k].MarkerStyle = MarkerStyle.Triangle;
                    Parent.CurForm[Form_id].CurChart.Series[_ch + 3].Points.DataBind(dt.AsEnumerable(), dt.Columns[0].ColumnName, dt.Columns[1].ColumnName, "");
                    Parent.CurForm[Form_id].CurChart.Series[_ch - 1].Points.DataBind(_dataTable.AsEnumerable(), _dataTable.Columns[0].ColumnName, _dataTable.Columns[1].ColumnName, "");
                    //this.CurChart.Series[k].Points.DataBind(dataSet.Tables[k].AsEnumerable(), dataSet.Tables[k].Columns[0].ColumnName, dataSet.Tables[k].Columns[1].ColumnName, "");
                }
                else
                {
                    Parent.CurForm[Form_id].CurChart.Series[_ch - 1].Points.DataBind(_dataTable.AsEnumerable(), _dataTable.Columns[0].ColumnName, _dataTable.Columns[1].ColumnName, "");
                    Parent.CurForm[Form_id].CurChart.Series[_ch + 3].Points.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //series[i].Points.DataBind(dataTable.AsEnumerable(), "时间", series[i].Name, "");
            //series[i].ChartType = SeriesChartType.Spline;
            //this.CurChart.Series.Add(series[i]);
            //}
        }

        private void UpdateUserGrid()
        {
            if (Parent.UserForm.cur_dataGrid_id == 7)
            {
                invokeUserGridData = Parent.UserForm.AdminTable;
                Parent.UserForm.dataGrid_InitialVal.BeginInvoke(new UserDataDelegate(UserDataDelegateMethod), invokeUserGridData);
                return;
            }
            if (Parent.UserForm.cur_dataGrid_id > Parent.UserForm.data_dataGridView.Count - 1)
                return;
            invokeUserGridData = Parent.UserForm.data_dataGridView[Parent.UserForm.cur_dataGrid_id];
            Parent.UserForm.dataGrid_InitialVal.BeginInvoke(new UserDataDelegate(UserDataDelegateMethod), invokeUserGridData);
        }

        private void UserDataDelegateMethod(DataTable _dataTable)
        {
            Parent.UserForm.dataGrid_InitialVal.DataSource = _dataTable;
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
            //if(data_node_count==3)
            //    data_node_count=0;
            //if (ch == 2)
            //{
            //    string str = "";
            //}
            data_of_all_node[ch - 1, node - 1] = data[5] + data[6];
            dataForecast[node - 1, ch - 1].AddDataToSource(double.Parse(data[5]));
            //if (smssended == false)
            //{

            //}

            for (int i = 0; i < Parent.nodeNum; i++)
            {
                if (Parent.CurForm[i] == null || Parent.CurForm[i].IsDisposed)
                    continue;
                if (Parent.CurForm[i].cur_node == node)
                {
                    if (Parent.CurForm[i].dataSet.Tables[ch - 1].Rows.Count > 0)
                        Parent.CurForm[i].dataSet.Tables[ch - 1].Rows.RemoveAt(0);
                    if (ch > 8 || ch < 1)
                    {
                        return;
                    }
                    //DateTime nowtime = DateTime.Now;

                    //nowtime = DateTime.Parse(DateTime.Now.ToShortDateString() + " " + data[3]);
                    //time = nowday.ToLongDateString();
                    //time = nowday.ToLongTimeString();
                    Parent.CurForm[i].dataSet.Tables[ch - 1].Rows.Add(data[3], data[5]);
                    //dataForecast
                    this.UpdateChart(i, node, ch);
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

            //int grid_id = this.Parent.UserForm.cur_dataGrid_id;
            //if (grid_id > 3)
            //    return;
            string[] tableName = { "InitialVal", "Sensitivity", "Unit", "WarningVal_1", "WarningVal_2", "Position", "Name" };
            for (int i = 0; i < 7; i++)
            {
                userDataTable[i] = ReadUserSQL("user.dat", String.Format("{0}_{1}", tableName[i], stage));
                while (userDataTable[i].Rows.Count > totalNode)
                    userDataTable[i].Columns.RemoveAt(userDataTable[i].Rows.Count - 1);
                this.Parent.UserForm.data_dataGridView[i] = userDataTable[i].Copy();
                this.Parent.UserForm.databack_dataGridView[i] = userDataTable[i].Copy();
            }
            for (int i = 0; i < Parent.nodeNum; i++)
            {
                //if (i >= 4)
                //    break;
                for (int j = 0; j < Parent.thread[i].nodeChNum; j++)
                {
                    this.Parent.CurForm[i].unit[j] = userDataTable[2].Rows[i][j].ToString();
                }
            }
            Parent.statusLabel.Text = String.Format("测量参数载入完成");
            if (this.Parent.UserForm.data_dataGridView[0].Columns.Count == 0)
            {
                Parent.statusLabel.Text = String.Format("测量参数载入失败");
            }
            AdminDataTable = ReadUserSQL("user.dat", "Admin");
            AdminDataTable.Rows.Add(AdminDataTable.Rows.Count + 1, "", "", 0);
            this.Parent.UserForm.AdminTable = AdminDataTable.Copy();
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
        private void msgFunction_6()//处理接收到的短信指令
        {
            string smstext = "";
            string number = "";
            if (phone_cmd[2].IndexOf("查询所有节点") >= 0)//查询所有节点通道信息
            {
                for (int i = 0; i < Parent.nodeNum; i++)
                {
                    if (!this.Parent.thread[i].portSensor.IsOpen)
                    {
                        this.Parent.statusLabel_phone.Text = string.Format("测量端口{0}未开启，查询失败", i + 1);
                        return;
                    }
                }
                //totalNode = this.Parent.thread.totalNodeCount;
                //CH_Node = this.Parent.thread.nodeChNum;
                for (int i = 0; i < Parent.nodeNum; i++)
                {
                    for (int j = 0; j < Parent.thread[i].nodeChNum; j++)
                    {
                        smstext += String.Format("节点{0}通道{1}:{2};\n", i + 1, j + 1, data_of_all_node[i, j]);
                    }
                }
                string tempsmstext = "";
                number = phone_cmd[0];
                for (int i = 0; i < Math.Ceiling((smstext.Length) / 119.0); i++)
                {
                    tempsmstext = smstext.Substring(i * 119, 119);
                    
                        this.Parent.PostPhoneMessage(2, number+tempsmstext);//发送短信
                   
                }
                //this.Parent.thread.PhoneCommand(tempsmstext, number);

            }
            else if (phone_cmd[2].IndexOf("查询节点") >= 0)//短信指令【查询节点1】节点号需根据实际连接的节点数目确定
            {
                for (int i = 0; i < Parent.nodeNum; i++)
                {
                    if (!this.Parent.thread[i].portSensor.IsOpen)
                    {
                        this.Parent.statusLabel_phone.Text = string.Format("测量端口{0}未开启，查询失败", i + 1);
                        //return;
                    }
                    int curnode = Convert.ToInt16(phone_cmd[2].Replace("查询节点", ""));
                    if (curnode <= Parent.nodeNum && curnode > 0)
                    {
                        for (int j = 0; j < this.Parent.thread[i].nodeChNum; j++)
                        {
                            smstext += String.Format("节点{0}通道{1}:{2};\n", curnode, j + 1, data_of_all_node[curnode - 1, j]);
                        }
                        string tempsmstext = "";
                        number = phone_cmd[0];
                        for (int j = 0; j < Math.Ceiling((smstext.Length) / 119.0); j++)
                        {
                            tempsmstext = smstext.Substring(j * 119, 119);
                            //this.Parent.thread[i].phone_sms_send[0] = number;
                            //this.Parent.thread[i].phone_sms_send[1] = tempsmstext;
                            this.Parent.PostPhoneMessage(2, number + tempsmstext);
                        }
                    }
                    else
                        this.Parent.statusLabel_phone.Text = "设查询节点信息的短信指令有误，未执行";
                }
            }
            else if (phone_cmd[2].IndexOf("设置施工阶段") >= 0)//短信指令【设置施工阶段1】1 2 3 4 5选其一
            {
                if (Convert.ToInt16(phone_cmd[2].Replace("设置施工阶段", "")) <= 5 && Convert.ToInt16(phone_cmd[2].Replace("设置施工阶段", "")) > 0)
                {
                    stage = Convert.ToInt16(phone_cmd[2].Replace("设置施工阶段", ""));
                    this.Parent.PostMessage(4, 1);//更新现阶段数据库
                    this.Parent.statusLabel.Text = String.Format("施工阶段已更改为阶段{0}", stage);
                }
                else
                    this.Parent.statusLabel_phone.Text = "设置施工阶段的短信指令有误，未执行";
            }
            else if (phone_cmd[2].IndexOf("获取施工状态") >= 0)//短信指令【获取施工状态】
            {
                smstext = String.Format("当前处于施工阶段{0}", stage);
                number = phone_cmd[0];
                this.Parent.PostPhoneMessage(2, number + smstext);

                //for (int i = 0; i < Parent.nodeNum; i++)
                //{
                //    this.Parent.thread[i].phone_sms_send[0] = number;
                //    this.Parent.thread[i].phone_sms_send[1] = smstext;
                //    this.Parent.PostMessage(3, 0, i);
                //}
                //this.Parent.SerialForm.text_targetphone.Text = phone_cmd[0];
                //this.Parent.SerialForm.rich_smstext.Text = smstext;
                //this.Parent.PostMessage(2, 0);
                //this.Parent.SerialForm.rich_smstext.Text = "";
            }
            else if (phone_cmd[2].IndexOf("打开警报器") >= 0)
            {
                this.Parent.PostMessage(8, 2);
            }
            else if (phone_cmd[2].IndexOf("关闭警报器") >= 0)
            {
                this.Parent.PostMessage(9, 2);
            }
        }

        private void msgFunction_7()//刷新user参数界面
        {
            UpdateUserGrid();
        }

        private void msgFunction_8()//调零初始值，并更新数据库
        {
            msgFunction_4();
            for (int i = 0; i < Parent.nodeNum; i++)
            {
                for (int j = 0; j < 8; j++)
                    init_val[i, j] = this.Parent.thread[i].origin_val[j];
            }
            string[] tableName = { "InitialVal" };
            userDataTable[0] = ReadUserSQL("user.dat", String.Format("{0}_{1}", tableName[0], stage));
            DataTable initvaltable = userDataTable[0].Copy();
            for (int i = 0; i < initvaltable.Rows.Count; i++)
            {
                for (int j = 0; j < initvaltable.Columns.Count; j++)
                {
                    if (j == 0)
                        initvaltable.Rows[i][j] = i + 1;
                    else
                        initvaltable.Rows[i][j] = init_val[i, j - 1];
                }
            }
            this.userDataTable[0] = initvaltable.Copy();
            SQLiteDBHelper SQLHelper = new SQLiteDBHelper("user.dat");
            string sqlcmd = "";
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < userDataTable[i].Rows.Count; j++)
                {
                    sqlcmd = String.Format("update {0}_{8} set CH1='{1}',CH2='{2}',CH3='{3}',CH4='{4}',CH5='{5}',CH6='{6}' where NUM={7}",
                        tableName[i], userDataTable[i].Rows[j][1], userDataTable[i].Rows[j][2],
                        userDataTable[i].Rows[j][3], userDataTable[i].Rows[j][4], userDataTable[i].Rows[j][5], userDataTable[i].Rows[j][6], userDataTable[i].Rows[j][0], stage);
                    if (j + 1 > Parent.nodeNum)
                    {
                        sqlcmd = String.Format("insert into {0}_{8} (CH1,CH2,CH3,CH4,CH5,CH6) values('{1}','{2}','{3}','{4}','{5}','{6}')",
                        tableName[i], userDataTable[i].Rows[j][1], userDataTable[i].Rows[j][2],
                        userDataTable[i].Rows[j][3], userDataTable[i].Rows[j][4], userDataTable[i].Rows[j][5], userDataTable[i].Rows[j][6], userDataTable[i].Rows[j][0], stage);
                    }
                    SQLHelper.ExecuteNonQuery(sqlcmd, null);
                }
            }
            //this.Parent.UserForm.databack_dataGridView[0] = initvaltable.Copy();
            //msgFunction_5();//修改测量参数数据库
            msgFunction_4();//读测量参数
            msgFunction_7();//刷新user参数界面
        }
        private void msgFunction_9()//根据选中测量端口，更新显示的端口参数
        {
            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            //循环该计算机上所有串行端口的集合
            Parent.SerialForm.cbox_Sensor_PortName.Items.Clear();
            //Parent.SerialForm.cbox_Phone_PortName.Items.Clear();
            //Parent.SerialForm.cbox_Warn_PortName.Items.Clear();
            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Sensor_PortName.Items.Add(s);
                //Parent.SerialForm.cbox_Phone_PortName.Items.Add(s);
                Parent.SerialForm.cbox_Warn_PortName.Items.Add(s);
            }
            if (this.Parent.SerialForm.radiobtn_node0.Checked == true)
            {
                if (pc.Ports.SerialPortNames.Count > 0)
                {
                    Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = 0;
                }
                if (Parent.SerialForm.cbox_Sensor_PortName.FindString(Parent.thread[0].portSensor.PortName) >= 0)
                {
                    Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(Parent.thread[0].portSensor.PortName);
                }
                Parent.SerialForm.cbox_Sensor_Baud.SelectedIndex = Parent.thread[0].portSensorAttribute[0];//比特率
                Parent.SerialForm.cbox_Sensor_Parity.SelectedIndex = Parent.thread[0].portSensorAttribute[1];//校验位
                Parent.SerialForm.cbox_Sensor_Bits.SelectedIndex = Parent.thread[0].portSensorAttribute[2];//数据位
                Parent.SerialForm.cbox_Sensor_Stop.SelectedIndex = Parent.thread[0].portSensorAttribute[3];//停止位
                Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(string.Format("COM{0}", Parent.thread[0].portSensorAttribute[4]));
            }
            if (this.Parent.SerialForm.radiobtn_node1.Checked == true)
            {
                if (pc.Ports.SerialPortNames.Count > 0)
                {
                    Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = 0;
                }
                if (Parent.SerialForm.cbox_Sensor_PortName.FindString(Parent.thread[1].portSensor.PortName) >= 0)
                {
                    Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(Parent.thread[1].portSensor.PortName);
                }
                Parent.SerialForm.cbox_Sensor_Baud.SelectedIndex = Parent.thread[1].portSensorAttribute[0];//比特率
                Parent.SerialForm.cbox_Sensor_Parity.SelectedIndex = Parent.thread[1].portSensorAttribute[1];//校验位
                Parent.SerialForm.cbox_Sensor_Bits.SelectedIndex = Parent.thread[1].portSensorAttribute[2];//数据位
                Parent.SerialForm.cbox_Sensor_Stop.SelectedIndex = Parent.thread[1].portSensorAttribute[3];//停止位
                Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(string.Format("COM{0}", Parent.thread[1].portSensorAttribute[4]));

            }
            if (this.Parent.SerialForm.radiobtn_node2.Checked == true)
            {
                if (pc.Ports.SerialPortNames.Count > 0)
                {
                    Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = 0;
                }
                if (Parent.SerialForm.cbox_Sensor_PortName.FindString(Parent.thread[2].portSensor.PortName) >= 0)
                {
                    Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(Parent.thread[2].portSensor.PortName);
                }
                Parent.SerialForm.cbox_Sensor_Baud.SelectedIndex = Parent.thread[2].portSensorAttribute[0];//比特率
                Parent.SerialForm.cbox_Sensor_Parity.SelectedIndex = Parent.thread[2].portSensorAttribute[1];//校验位
                Parent.SerialForm.cbox_Sensor_Bits.SelectedIndex = Parent.thread[2].portSensorAttribute[2];//数据位
                Parent.SerialForm.cbox_Sensor_Stop.SelectedIndex = Parent.thread[2].portSensorAttribute[3];//停止位
                Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(string.Format("COM{0}", Parent.thread[2].portSensorAttribute[4]));

            }
            if (this.Parent.SerialForm.radiobtn_node3.Checked == true)
            {
                if (pc.Ports.SerialPortNames.Count > 0)
                {
                    Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = 0;
                }
                if (Parent.SerialForm.cbox_Sensor_PortName.FindString(Parent.thread[3].portSensor.PortName) >= 0)
                {
                    Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(Parent.thread[3].portSensor.PortName);
                }
                Parent.SerialForm.cbox_Sensor_Baud.SelectedIndex = Parent.thread[3].portSensorAttribute[0];//比特率
                Parent.SerialForm.cbox_Sensor_Parity.SelectedIndex = Parent.thread[3].portSensorAttribute[1];//校验位
                Parent.SerialForm.cbox_Sensor_Bits.SelectedIndex = Parent.thread[3].portSensorAttribute[2];//数据位
                Parent.SerialForm.cbox_Sensor_Stop.SelectedIndex = Parent.thread[3].portSensorAttribute[3];//停止位
                Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(string.Format("COM{0}", Parent.thread[3].portSensorAttribute[4]));

            }
        }
        private void msgFunction_10()//更新显示手机和警报端口参数
        {
            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            //循环该计算机上所有串行端口的集合
            Parent.SerialForm.cbox_Warn_PortName.Items.Clear();

            Parent.SerialForm.cbox_Sensor_PortName.Items.Clear();
            Parent.SerialForm.cbox_Sensor_Bits.Items.Clear();
            Parent.SerialForm.cbox_Sensor_Parity.Items.Clear();
            Parent.SerialForm.cbox_Sensor_Stop.Items.Clear();
            Parent.SerialForm.cbox_Sensor_Baud.Items.Clear();

            foreach (string s in pc.Ports.SerialPortNames)
            {
                Parent.SerialForm.cbox_Sensor_PortName.Items.Add(s);
                Parent.SerialForm.cbox_Warn_PortName.Items.Add(s);
            }
            //if (pc.Ports.SerialPortNames.Count > 0)
            //{
            //    //Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = 0;
            //}
            //if(Parent.SerialForm.cbox_Sensor_PortName.FindString(portSensor.PortName)>=0)
            //{
            //    Parent.SerialForm.cbox_Sensor_PortName.SelectedIndex = Parent.SerialForm.cbox_Sensor_PortName.FindString(portSensor.PortName);
            //}
            if (Parent.SerialForm.cbox_Phone_PortName.FindString(Parent.portPhone.PortName) >= 0)
            {
                Parent.SerialForm.cbox_Phone_PortName.SelectedIndex = Parent.SerialForm.cbox_Phone_PortName.FindString(Parent.portPhone.PortName);
            }
            if (Parent.SerialForm.cbox_Warn_PortName.FindString(this.Parent.warningThread.portWarn.PortName) >= 0)
            {
                Parent.SerialForm.cbox_Warn_PortName.SelectedIndex = Parent.SerialForm.cbox_Warn_PortName.FindString(this.Parent.warningThread.portWarn.PortName);
            }



            Parent.SerialForm.cbox_Sensor_Bits.Items.Add("5");
            Parent.SerialForm.cbox_Sensor_Bits.Items.Add("7");
            Parent.SerialForm.cbox_Sensor_Bits.Items.Add("8");

            Parent.SerialForm.cbox_Sensor_Baud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});

            Parent.SerialForm.cbox_Sensor_Parity.Items.AddRange(new object[] {
            "Even",
            "Mark",
            "None",
            "Odd",
            "Space"});

            Parent.SerialForm.cbox_Sensor_Stop.Items.Add("1");
            Parent.SerialForm.cbox_Sensor_Stop.Items.Add("1.5");
            Parent.SerialForm.cbox_Sensor_Stop.Items.Add("2");


            //if (pc.Ports.SerialPortNames.Count > 0)
            //{
            //    Parent.SerialForm.cbox_Phone_Baud.SelectedIndex = Parent.portPhoneAttribute[0];//比特率
            //    Parent.SerialForm.cbox_Phone_Parity.SelectedIndex = Parent.portPhoneAttribute[1];//校验位
            //    Parent.SerialForm.cbox_Phone_Bits.SelectedIndex = Parent.portPhoneAttribute[2];//数据位
            //    Parent.SerialForm.cbox_Phone_Stop.SelectedIndex = Parent.portPhoneAttribute[3];//停止位
            //}

        }
    }
}