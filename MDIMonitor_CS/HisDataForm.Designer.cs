namespace MDIMonitor_CS
{
    partial class HisDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.HisChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.hScroll_His = new System.Windows.Forms.HScrollBar();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Brower = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.text_path = new System.Windows.Forms.TextBox();
            this.listView_File = new System.Windows.Forms.ListView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.text_lmd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_pos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.HisChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // HisChart
            // 
            this.HisChart.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.HisChart.ChartAreas.Add(chartArea1);
            this.HisChart.Location = new System.Drawing.Point(12, 84);
            this.HisChart.Name = "HisChart";
            this.HisChart.Size = new System.Drawing.Size(770, 404);
            this.HisChart.TabIndex = 0;
            this.HisChart.Text = "chart1";
            // 
            // hScroll_His
            // 
            this.hScroll_His.Location = new System.Drawing.Point(26, 436);
            this.hScroll_His.Name = "hScroll_His";
            this.hScroll_His.Size = new System.Drawing.Size(741, 10);
            this.hScroll_His.TabIndex = 1;
            this.hScroll_His.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScroll_His_Scroll);
            // 
            // btn_Brower
            // 
            this.btn_Brower.Location = new System.Drawing.Point(532, 25);
            this.btn_Brower.Name = "btn_Brower";
            this.btn_Brower.Size = new System.Drawing.Size(43, 23);
            this.btn_Brower.TabIndex = 2;
            this.btn_Brower.Text = "浏览";
            this.btn_Brower.UseVisualStyleBackColor = true;
            this.btn_Brower.Click += new System.EventHandler(this.btn_Brower_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "路径";
            // 
            // text_path
            // 
            this.text_path.Location = new System.Drawing.Point(53, 26);
            this.text_path.Name = "text_path";
            this.text_path.Size = new System.Drawing.Size(464, 21);
            this.text_path.TabIndex = 4;
            // 
            // listView_File
            // 
            this.listView_File.GridLines = true;
            this.listView_File.Location = new System.Drawing.Point(581, 12);
            this.listView_File.Name = "listView_File";
            this.listView_File.Size = new System.Drawing.Size(201, 66);
            this.listView_File.TabIndex = 5;
            this.listView_File.UseCompatibleStateImageBehavior = false;
            this.listView_File.View = System.Windows.Forms.View.List;
            this.listView_File.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_File_MouseDoubleClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(718, 468);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(80, 50);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "灵敏度";
            // 
            // text_lmd
            // 
            this.text_lmd.Location = new System.Drawing.Point(63, 57);
            this.text_lmd.Name = "text_lmd";
            this.text_lmd.Size = new System.Drawing.Size(100, 21);
            this.text_lmd.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "位  置";
            // 
            // text_pos
            // 
            this.text_pos.Location = new System.Drawing.Point(241, 56);
            this.text_pos.Name = "text_pos";
            this.text_pos.Size = new System.Drawing.Size(100, 21);
            this.text_pos.TabIndex = 8;
            // 
            // HisDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(794, 521);
            this.Controls.Add(this.text_pos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_lmd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listView_File);
            this.Controls.Add(this.text_path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Brower);
            this.Controls.Add(this.hScroll_His);
            this.Controls.Add(this.HisChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HisDataForm";
            this.Text = "HisDataForm";
            ((System.ComponentModel.ISupportInitialize)(this.HisChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart HisChart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button btn_Brower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_path;
        private System.Windows.Forms.ListView listView_File;
        public System.Windows.Forms.HScrollBar hScroll_His;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_lmd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_pos;

    }
}