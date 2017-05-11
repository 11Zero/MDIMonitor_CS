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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.HisChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.hScroll_His = new System.Windows.Forms.HScrollBar();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Brower = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.text_path = new System.Windows.Forms.TextBox();
            this.listView_File = new System.Windows.Forms.ListView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.text_time = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_pos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_value = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.text_unit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.HisChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // HisChart
            // 
            this.HisChart.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea1";
            this.HisChart.ChartAreas.Add(chartArea2);
            this.HisChart.Location = new System.Drawing.Point(12, 84);
            this.HisChart.Name = "HisChart";
            this.HisChart.Size = new System.Drawing.Size(770, 404);
            this.HisChart.TabIndex = 0;
            this.HisChart.Text = "chart1";
            this.HisChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HisChart_MouseClick);
            // 
            // hScroll_His
            // 
            this.hScroll_His.Location = new System.Drawing.Point(26, 435);
            this.hScroll_His.Name = "hScroll_His";
            this.hScroll_His.Size = new System.Drawing.Size(741, 15);
            this.hScroll_His.TabIndex = 1;
            this.hScroll_His.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScroll_His_Scroll);
            // 
            // btn_Brower
            // 
            this.btn_Brower.Location = new System.Drawing.Point(497, 24);
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
            this.text_path.Size = new System.Drawing.Size(434, 21);
            this.text_path.TabIndex = 4;
            // 
            // listView_File
            // 
            this.listView_File.GridLines = true;
            this.listView_File.Location = new System.Drawing.Point(561, 12);
            this.listView_File.Name = "listView_File";
            this.listView_File.Size = new System.Drawing.Size(221, 66);
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
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "时间";
            // 
            // text_time
            // 
            this.text_time.Location = new System.Drawing.Point(54, 57);
            this.text_time.Name = "text_time";
            this.text_time.Size = new System.Drawing.Size(120, 21);
            this.text_time.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "位置";
            // 
            // text_pos
            // 
            this.text_pos.Location = new System.Drawing.Point(475, 57);
            this.text_pos.Name = "text_pos";
            this.text_pos.Size = new System.Drawing.Size(65, 21);
            this.text_pos.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "数值";
            // 
            // text_value
            // 
            this.text_value.Location = new System.Drawing.Point(223, 56);
            this.text_value.Name = "text_value";
            this.text_value.Size = new System.Drawing.Size(100, 21);
            this.text_value.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "单位";
            // 
            // text_unit
            // 
            this.text_unit.Location = new System.Drawing.Point(368, 56);
            this.text_unit.Name = "text_unit";
            this.text_unit.Size = new System.Drawing.Size(65, 21);
            this.text_unit.TabIndex = 8;
            // 
            // HisDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(794, 521);
            this.Controls.Add(this.text_unit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_pos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_value);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_time);
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
        private System.Windows.Forms.TextBox text_time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_pos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_unit;

    }
}