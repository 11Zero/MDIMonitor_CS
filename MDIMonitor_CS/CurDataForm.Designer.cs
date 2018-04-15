namespace MDIMonitor_CS
{
    partial class CurDataForm
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
            this.CurChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.combox_Node = new System.Windows.Forms.ComboBox();
            this.combox_ch = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CurChart)).BeginInit();
            this.SuspendLayout();
            // 
            // CurChart
            // 
            this.CurChart.Location = new System.Drawing.Point(1, 1);
            this.CurChart.Name = "CurChart";
            this.CurChart.Size = new System.Drawing.Size(762, 831);
            this.CurChart.TabIndex = 4;
            this.CurChart.Text = "chart1";
            this.CurChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CurChart_MouseClick);
            this.CurChart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CurChart_MouseDoubleClick);
            // 
            // combox_Node
            // 
            this.combox_Node.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_Node.FormattingEnabled = true;
            this.combox_Node.Location = new System.Drawing.Point(688, 609);
            this.combox_Node.Name = "combox_Node";
            this.combox_Node.Size = new System.Drawing.Size(45, 20);
            this.combox_Node.TabIndex = 5;
            this.combox_Node.Visible = false;
            this.combox_Node.SelectedIndexChanged += new System.EventHandler(this.combox_Node_SelectedIndexChanged);
            // 
            // combox_ch
            // 
            this.combox_ch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_ch.FormattingEnabled = true;
            this.combox_ch.Location = new System.Drawing.Point(739, 558);
            this.combox_ch.Name = "combox_ch";
            this.combox_ch.Size = new System.Drawing.Size(45, 20);
            this.combox_ch.TabIndex = 6;
            this.combox_ch.Visible = false;
            this.combox_ch.SelectedIndexChanged += new System.EventHandler(this.combox_ch_SelectedIndexChanged);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(739, 605);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(45, 27);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Visible = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // CurDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(794, 834);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.combox_ch);
            this.Controls.Add(this.combox_Node);
            this.Controls.Add(this.CurChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CurDataForm";
            this.Text = "CurDataForm";
            ((System.ComponentModel.ISupportInitialize)(this.CurChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart CurChart;
        public System.Windows.Forms.ComboBox combox_Node;
        public System.Windows.Forms.ComboBox combox_ch;
        private System.Windows.Forms.Button btn_OK;



    }
}