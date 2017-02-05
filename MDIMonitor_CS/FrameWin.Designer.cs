namespace MDIMonitor_CS
{
    partial class FrameWin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.main_btn_1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 456);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(959, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.StatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.main_btn_1);
            this.splitContainer.Size = new System.Drawing.Size(959, 456);
            this.splitContainer.SplitterDistance = 230;
            this.splitContainer.TabIndex = 8;
            // 
            // main_btn_1
            // 
            this.main_btn_1.Location = new System.Drawing.Point(48, 24);
            this.main_btn_1.Name = "main_btn_1";
            this.main_btn_1.Size = new System.Drawing.Size(111, 28);
            this.main_btn_1.TabIndex = 0;
            this.main_btn_1.Text = "串口设置";
            this.main_btn_1.UseVisualStyleBackColor = true;
            this.main_btn_1.Click += new System.EventHandler(this.main_btn_1_Click);
            // 
            // FrameWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 478);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "FrameWin";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel StatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button main_btn_1;


    }
}

