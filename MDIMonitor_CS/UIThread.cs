﻿using System;
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
        private SQLiteConnection dataBase = null;
        private SQLiteCommand sqlCommand = null;
        private DateTime nowtime = new DateTime();//System.DateTime.Now;//new DateTime().TimeOfDay;
        public UIThread(Form parent)
        {
            Parent = (FrameWin)parent;//强制转换
            msgQueue = new Queue<int>();
            sqlCommand = new SQLiteCommand();
            thread = new Thread(new ThreadStart(Run));//真正定义线程
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
            string fileName = String.Format("NODE{0}CH{1}", node, ch);
            string path = "Database";
           if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
           path = path+"\\"+DateTime.Now.Date.ToString("yyyy-MM-dd");
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
            try
            {

                FileInfo DatabaseFile = new FileInfo(path + "\\" + fileName);
                if (!DatabaseFile.Exists)
                {
                    //if (!DatabaseFile.Directory.Exists)
                    //{
                    //    DatabaseFile.Directory.Create();
                    //}
                    SQLiteConnection.CreateFile(DatabaseFile.FullName);
                }
                dataBase = new SQLiteConnection("Data Source=" + path + "\\" + fileName + ";Version=3;");
                dataBase.Open();
                sqlCommand.Connection = dataBase;
                for (int i = 0; i < 12; i++)//表名字数据对应当天的时间段,每两小时为一个表
                {
                    string tableName = String.Format("_{0}_00_00",(i*2).ToString().PadLeft(2,'0'));
                    string sqlcmd = "create table if not exists " + tableName +
                        "(NUM integer primary key autoincrement, DataTime varchar(50),LMD varchar(20),SensorVal varchar(20),Unit varchar(20),Pos varchar(50))";
                    sqlCommand.CommandText = sqlcmd;
                    sqlCommand.ExecuteNonQuery();
                }
                dataBase.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return File.Exists(path + "\\" + fileName);
        }
        /// <summary>
        /// 将扫描到的节点数据写入数据库
        /// </summary>
        /// <param name="datastr">8个字符串[节点 通道 感应器名称 时间 灵敏度 测量值 单位 位置]</param>
        /// <returns>是否写入成功</returns>
        public bool WriteDataToSQL(string[] datastr)//
        {
            return true;
        }

        private void msgFunction_1()//对应消息码为1的时要执行的函数
        {
            if (true == CreateDataSQL(1, 2))//创建节点1通道2的数据库
                Parent.StatusLabel1.Text = String.Format("数据库文件NODE{0}CH{1}生成成功", 1, 2);
            else
                Parent.StatusLabel1.Text = String.Format("数据库文件NODE{0}CH{1}生成失败", 1, 2);
        }
        private void msgFunction_2()//更新CurForm中的chart控件
        {
            DateTime stime = new DateTime(2014, 1, 1, 0, 0, 0);
            DateTime etime = new DateTime(2014, 1, 1, 0, 0, 1);
            TimeSpan step = new TimeSpan();//
            Random ran = new Random();

            step = etime - stime;
            for (int i = 0; i < 100; i++)
            {
                nowtime = nowtime + step;
            }
            nowtime = nowtime + step;
            if (Parent.CurForm.dataTable.Rows.Count > 0)
                Parent.CurForm.dataTable.Rows.RemoveAt(0);
            Parent.CurForm.dataTable.Rows.Add(nowtime.ToString("HH:mm:ss"), ran.Next(0, 20));
            //Parent.CurForm.CurChart.Series[0].Points.DataBind(Parent.CurForm.dataTable.AsEnumerable(), "日期", "数据", "");
            Parent.CurForm.UpdateChart();
        }
    }
}