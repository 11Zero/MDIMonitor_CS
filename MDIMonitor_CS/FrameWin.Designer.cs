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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.串口设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_SerialForm = new System.Windows.Forms.ToolStripMenuItem();
            this.数据浏览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_CurForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_HisForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ScanPort = new System.Windows.Forms.ToolStripMenuItem();
            this.传感参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Userdat = new System.Windows.Forms.ToolStripMenuItem();
            this.StripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.StripContainer.BottomToolStripPanel.SuspendLayout();
            this.StripContainer.TopToolStripPanel.SuspendLayout();
            this.StripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口设置ToolStripMenuItem,
            this.数据浏览ToolStripMenuItem,
            this.传感参数ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(959, 25);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 串口设置ToolStripMenuItem
            // 
            this.串口设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_SerialForm});
            this.串口设置ToolStripMenuItem.Name = "串口设置ToolStripMenuItem";
            this.串口设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.串口设置ToolStripMenuItem.Text = "串口设置";
            // 
            // menu_SerialForm
            // 
            this.menu_SerialForm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_SerialForm.Name = "menu_SerialForm";
            this.menu_SerialForm.Size = new System.Drawing.Size(124, 22);
            this.menu_SerialForm.Text = "串口参数";
            this.menu_SerialForm.Click += new System.EventHandler(this.menu_SerialForm_Click);
            // 
            // 数据浏览ToolStripMenuItem
            // 
            this.数据浏览ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_CurForm,
            this.menu_HisForm,
            this.menu_ScanPort});
            this.数据浏览ToolStripMenuItem.Name = "数据浏览ToolStripMenuItem";
            this.数据浏览ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据浏览ToolStripMenuItem.Text = "数据浏览";
            // 
            // menu_CurForm
            // 
            this.menu_CurForm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_CurForm.Name = "menu_CurForm";
            this.menu_CurForm.Size = new System.Drawing.Size(124, 22);
            this.menu_CurForm.Text = "实时监控";
            this.menu_CurForm.Click += new System.EventHandler(this.menu_CurForm_Click);
            // 
            // menu_HisForm
            // 
            this.menu_HisForm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_HisForm.Name = "menu_HisForm";
            this.menu_HisForm.Size = new System.Drawing.Size(124, 22);
            this.menu_HisForm.Text = "历史数据";
            // 
            // menu_ScanPort
            // 
            this.menu_ScanPort.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_ScanPort.Name = "menu_ScanPort";
            this.menu_ScanPort.Size = new System.Drawing.Size(124, 22);
            this.menu_ScanPort.Text = "测试按钮";
            this.menu_ScanPort.Click += new System.EventHandler(this.menu_ScanPort_Click);
            // 
            // 传感参数ToolStripMenuItem
            // 
            this.传感参数ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Userdat});
            this.传感参数ToolStripMenuItem.Name = "传感参数ToolStripMenuItem";
            this.传感参数ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.传感参数ToolStripMenuItem.Text = "测量设置";
            // 
            // menu_Userdat
            // 
            this.menu_Userdat.Name = "menu_Userdat";
            this.menu_Userdat.Size = new System.Drawing.Size(124, 22);
            this.menu_Userdat.Text = "测量数值";
            this.menu_Userdat.Click += new System.EventHandler(this.menu_Userdat_Click);
            // 
            // StripContainer
            // 
            // 
            // StripContainer.BottomToolStripPanel
            // 
            this.StripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // StripContainer.ContentPanel
            // 
            this.StripContainer.ContentPanel.Size = new System.Drawing.Size(959, 431);
            this.StripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StripContainer.Location = new System.Drawing.Point(0, 0);
            this.StripContainer.Name = "StripContainer";
            this.StripContainer.Size = new System.Drawing.Size(959, 478);
            this.StripContainer.TabIndex = 5;
            this.StripContainer.Text = "toolStripContainer2";
            // 
            // StripContainer.TopToolStripPanel
            // 
            this.StripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(959, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(56, 17);
            this.statusLabel.Text = "启动完成";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // FrameWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 478);
            this.Controls.Add(this.StripContainer);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FrameWin";
            this.Text = "Form1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.StripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.StripContainer.BottomToolStripPanel.PerformLayout();
            this.StripContainer.TopToolStripPanel.ResumeLayout(false);
            this.StripContainer.TopToolStripPanel.PerformLayout();
            this.StripContainer.ResumeLayout(false);
            this.StripContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 串口设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_SerialForm;
        private System.Windows.Forms.ToolStripMenuItem 数据浏览ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_CurForm;
        private System.Windows.Forms.ToolStripMenuItem menu_HisForm;
        private System.Windows.Forms.ToolStripMenuItem menu_ScanPort;
        private System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem 传感参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_Userdat;
        public System.Windows.Forms.ToolStripContainer StripContainer;
        //private System.Windows.Forms.Panel panel_Frame;
    }
}

