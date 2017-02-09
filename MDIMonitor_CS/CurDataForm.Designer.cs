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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.CurChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.CurChart)).BeginInit();
            this.SuspendLayout();
            // 
            // CurChart
            // 
            chartArea1.Name = "ChartArea1";
            this.CurChart.ChartAreas.Add(chartArea1);
            this.CurChart.Location = new System.Drawing.Point(33, 23);
            this.CurChart.Name = "CurChart";
            this.CurChart.Size = new System.Drawing.Size(624, 351);
            this.CurChart.TabIndex = 4;
            this.CurChart.Text = "chart1";
            // 
            // CurDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 452);
            this.Controls.Add(this.CurChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CurDataForm";
            this.Text = "CurDataForm";
            ((System.ComponentModel.ISupportInitialize)(this.CurChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart CurChart;



    }
}