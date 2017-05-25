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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrameWin));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.数据浏览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_CurForm = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_monitor1 = new System.Windows.Forms.ToolStripMenuItem();
            this.监控MenuItem_monitor2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_monitor3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_monitor4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_CurDataForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_HisForm = new System.Windows.Forms.ToolStripMenuItem();
            this.传感参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Userdat = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_auto = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_single_measure = new System.Windows.Forms.ToolStripMenuItem();
            this.串口设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_SerialForm = new System.Windows.Forms.ToolStripMenuItem();
            this.用户帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Registr = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_About = new System.Windows.Forms.ToolStripMenuItem();
            this.StripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_warning = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_phone = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu_zeros = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.StripContainer.BottomToolStripPanel.SuspendLayout();
            this.StripContainer.TopToolStripPanel.SuspendLayout();
            this.StripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据浏览ToolStripMenuItem,
            this.传感参数ToolStripMenuItem,
            this.串口设置ToolStripMenuItem,
            this.用户帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(794, 25);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 数据浏览ToolStripMenuItem
            // 
            this.数据浏览ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_CurForm,
            this.menu_CurDataForm,
            this.menu_HisForm});
            this.数据浏览ToolStripMenuItem.Name = "数据浏览ToolStripMenuItem";
            this.数据浏览ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据浏览ToolStripMenuItem.Text = "数据浏览";
            // 
            // menu_CurForm
            // 
            this.menu_CurForm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_CurForm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_monitor1,
            this.监控MenuItem_monitor2,
            this.MenuItem_monitor3,
            this.MenuItem_monitor4});
            this.menu_CurForm.Name = "menu_CurForm";
            this.menu_CurForm.Size = new System.Drawing.Size(152, 22);
            this.menu_CurForm.Text = "曲线监控";
            this.menu_CurForm.Click += new System.EventHandler(this.menu_CurForm_Click);
            // 
            // MenuItem_monitor1
            // 
            this.MenuItem_monitor1.Name = "MenuItem_monitor1";
            this.MenuItem_monitor1.Size = new System.Drawing.Size(107, 22);
            this.MenuItem_monitor1.Text = "监控1";
            this.MenuItem_monitor1.Click += new System.EventHandler(this.MenuItem_monitor1_Click);
            // 
            // 监控MenuItem_monitor2
            // 
            this.监控MenuItem_monitor2.Name = "监控MenuItem_monitor2";
            this.监控MenuItem_monitor2.Size = new System.Drawing.Size(107, 22);
            this.监控MenuItem_monitor2.Text = "监控2";
            this.监控MenuItem_monitor2.Click += new System.EventHandler(this.监控MenuItem_monitor2_Click);
            // 
            // MenuItem_monitor3
            // 
            this.MenuItem_monitor3.Name = "MenuItem_monitor3";
            this.MenuItem_monitor3.Size = new System.Drawing.Size(107, 22);
            this.MenuItem_monitor3.Text = "监控3";
            this.MenuItem_monitor3.Click += new System.EventHandler(this.MenuItem_monitor3_Click);
            // 
            // MenuItem_monitor4
            // 
            this.MenuItem_monitor4.Name = "MenuItem_monitor4";
            this.MenuItem_monitor4.Size = new System.Drawing.Size(107, 22);
            this.MenuItem_monitor4.Text = "监控4";
            this.MenuItem_monitor4.Click += new System.EventHandler(this.MenuItem_monitor4_Click);
            // 
            // menu_CurDataForm
            // 
            this.menu_CurDataForm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_CurDataForm.Name = "menu_CurDataForm";
            this.menu_CurDataForm.Size = new System.Drawing.Size(152, 22);
            this.menu_CurDataForm.Text = "表格监控";
            this.menu_CurDataForm.Click += new System.EventHandler(this.menu_CurDataForm_Click);
            // 
            // menu_HisForm
            // 
            this.menu_HisForm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_HisForm.Name = "menu_HisForm";
            this.menu_HisForm.Size = new System.Drawing.Size(152, 22);
            this.menu_HisForm.Text = "历史数据";
            this.menu_HisForm.Click += new System.EventHandler(this.menu_HisForm_Click);
            // 
            // 传感参数ToolStripMenuItem
            // 
            this.传感参数ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Userdat,
            this.menu_auto,
            this.menu_single_measure,
            this.menu_zeros});
            this.传感参数ToolStripMenuItem.Name = "传感参数ToolStripMenuItem";
            this.传感参数ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.传感参数ToolStripMenuItem.Text = "测量设置";
            // 
            // menu_Userdat
            // 
            this.menu_Userdat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_Userdat.Name = "menu_Userdat";
            this.menu_Userdat.Size = new System.Drawing.Size(152, 22);
            this.menu_Userdat.Text = "测量数值";
            this.menu_Userdat.Click += new System.EventHandler(this.menu_Userdat_Click);
            // 
            // menu_auto
            // 
            this.menu_auto.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_auto.Checked = true;
            this.menu_auto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menu_auto.Name = "menu_auto";
            this.menu_auto.Size = new System.Drawing.Size(152, 22);
            this.menu_auto.Text = "自动测量";
            this.menu_auto.Click += new System.EventHandler(this.menu_auto_Click);
            // 
            // menu_single_measure
            // 
            this.menu_single_measure.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_single_measure.Name = "menu_single_measure";
            this.menu_single_measure.Size = new System.Drawing.Size(152, 22);
            this.menu_single_measure.Text = "单次测量";
            this.menu_single_measure.Click += new System.EventHandler(this.menu_single_measure_Click);
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
            this.menu_SerialForm.Size = new System.Drawing.Size(152, 22);
            this.menu_SerialForm.Text = "串口参数";
            this.menu_SerialForm.Click += new System.EventHandler(this.menu_SerialForm_Click);
            // 
            // 用户帮助ToolStripMenuItem
            // 
            this.用户帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Help,
            this.menu_Registr,
            this.menu_About});
            this.用户帮助ToolStripMenuItem.Name = "用户帮助ToolStripMenuItem";
            this.用户帮助ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.用户帮助ToolStripMenuItem.Text = "用户帮助";
            // 
            // menu_Help
            // 
            this.menu_Help.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_Help.Name = "menu_Help";
            this.menu_Help.Size = new System.Drawing.Size(152, 22);
            this.menu_Help.Text = "操作指南";
            this.menu_Help.Click += new System.EventHandler(this.menu_Help_Click);
            // 
            // menu_Registr
            // 
            this.menu_Registr.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_Registr.Name = "menu_Registr";
            this.menu_Registr.Size = new System.Drawing.Size(152, 22);
            this.menu_Registr.Text = "注册管理";
            this.menu_Registr.Click += new System.EventHandler(this.menu_Registr_Click);
            // 
            // menu_About
            // 
            this.menu_About.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_About.Name = "menu_About";
            this.menu_About.Size = new System.Drawing.Size(152, 22);
            this.menu_About.Text = "关于我们";
            this.menu_About.Click += new System.EventHandler(this.menu_About_Click);
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
            this.StripContainer.ContentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StripContainer.ContentPanel.BackgroundImage")));
            this.StripContainer.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StripContainer.ContentPanel.Size = new System.Drawing.Size(794, 521);
            this.StripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StripContainer.Location = new System.Drawing.Point(0, 0);
            this.StripContainer.Name = "StripContainer";
            this.StripContainer.Size = new System.Drawing.Size(794, 572);
            this.StripContainer.TabIndex = 5;
            this.StripContainer.Text = "toolStripContainer2";
            // 
            // StripContainer.TopToolStripPanel
            // 
            this.StripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusLabel_warning,
            this.statusLabel_phone});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(794, 26);
            this.statusStrip.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(250, 21);
            this.statusLabel.Text = "暂无通知";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // statusLabel_warning
            // 
            this.statusLabel_warning.AutoSize = false;
            this.statusLabel_warning.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusLabel_warning.Name = "statusLabel_warning";
            this.statusLabel_warning.Size = new System.Drawing.Size(250, 21);
            this.statusLabel_warning.Text = "暂无报警信息";
            this.statusLabel_warning.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // statusLabel_phone
            // 
            this.statusLabel_phone.AutoSize = false;
            this.statusLabel_phone.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusLabel_phone.Name = "statusLabel_phone";
            this.statusLabel_phone.Size = new System.Drawing.Size(250, 21);
            this.statusLabel_phone.Text = "暂无通信指令";
            this.statusLabel_phone.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // menu_zeros
            // 
            this.menu_zeros.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu_zeros.Name = "menu_zeros";
            this.menu_zeros.Size = new System.Drawing.Size(152, 22);
            this.menu_zeros.Text = "监测归零";
            this.menu_zeros.Click += new System.EventHandler(this.menu_zeros_Click);
            // 
            // FrameWin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.StripContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrameWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "碗扣式满堂支架预警系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrameWin_FormClosing);
            this.MouseEnter += new System.EventHandler(this.FrameWin_MouseEnter);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.StripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.StripContainer.TopToolStripPanel.ResumeLayout(false);
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
        private System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem 传感参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_Userdat;
        public System.Windows.Forms.ToolStripContainer StripContainer;
        public System.Windows.Forms.ToolStripMenuItem menu_single_measure;
        public System.Windows.Forms.ToolStripMenuItem menu_auto;
        public System.Windows.Forms.ToolStripStatusLabel statusLabel_warning;
        public System.Windows.Forms.ToolStripStatusLabel statusLabel_phone;
        private System.Windows.Forms.ToolStripMenuItem menu_CurDataForm;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_monitor1;
        private System.Windows.Forms.ToolStripMenuItem 监控MenuItem_monitor2;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_monitor3;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_monitor4;
        public System.String FromTitle;
        private System.Windows.Forms.ToolStripMenuItem 用户帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_Help;
        private System.Windows.Forms.ToolStripMenuItem menu_Registr;
        private System.Windows.Forms.ToolStripMenuItem menu_About;
        private System.Windows.Forms.ToolStripMenuItem menu_zeros;
        //private System.Windows.Forms.Panel panel_Frame;
    }
}

