namespace MDIMonitor_CS
{
    partial class UserDatForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid_Userdat = new System.Windows.Forms.DataGridView();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel_DataGrid = new System.Windows.Forms.Panel();
            this.dataGrid_WarningVal = new System.Windows.Forms.DataGridView();
            this.dataGrid_Unit = new System.Windows.Forms.DataGridView();
            this.dataGrid_Sensitivity = new System.Windows.Forms.DataGridView();
            this.dataGrid_InitialVal = new System.Windows.Forms.DataGridView();
            this.radio_InitialVal = new System.Windows.Forms.RadioButton();
            this.radio_Senitivity = new System.Windows.Forms.RadioButton();
            this.radio_Unit = new System.Windows.Forms.RadioButton();
            this.radio_WarningVal = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Userdat)).BeginInit();
            this.panel_DataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WarningVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Unit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Sensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_InitialVal)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_Userdat
            // 
            this.grid_Userdat.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grid_Userdat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Userdat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Userdat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Userdat.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Userdat.Location = new System.Drawing.Point(658, 85);
            this.grid_Userdat.Name = "grid_Userdat";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Userdat.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_Userdat.RowTemplate.Height = 23;
            this.grid_Userdat.Size = new System.Drawing.Size(96, 106);
            this.grid_Userdat.TabIndex = 0;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(604, 35);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "button1";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // panel_DataGrid
            // 
            this.panel_DataGrid.Controls.Add(this.dataGrid_WarningVal);
            this.panel_DataGrid.Controls.Add(this.dataGrid_Unit);
            this.panel_DataGrid.Controls.Add(this.dataGrid_Sensitivity);
            this.panel_DataGrid.Controls.Add(this.dataGrid_InitialVal);
            this.panel_DataGrid.Location = new System.Drawing.Point(22, 12);
            this.panel_DataGrid.Name = "panel_DataGrid";
            this.panel_DataGrid.Size = new System.Drawing.Size(519, 296);
            this.panel_DataGrid.TabIndex = 2;
            // 
            // dataGrid_WarningVal
            // 
            this.dataGrid_WarningVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_WarningVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_WarningVal.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_WarningVal.Name = "dataGrid_WarningVal";
            this.dataGrid_WarningVal.RowTemplate.Height = 23;
            this.dataGrid_WarningVal.Size = new System.Drawing.Size(519, 296);
            this.dataGrid_WarningVal.TabIndex = 3;
            // 
            // dataGrid_Unit
            // 
            this.dataGrid_Unit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_Unit.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_Unit.Name = "dataGrid_Unit";
            this.dataGrid_Unit.RowTemplate.Height = 23;
            this.dataGrid_Unit.Size = new System.Drawing.Size(519, 296);
            this.dataGrid_Unit.TabIndex = 2;
            // 
            // dataGrid_Sensitivity
            // 
            this.dataGrid_Sensitivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Sensitivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_Sensitivity.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_Sensitivity.Name = "dataGrid_Sensitivity";
            this.dataGrid_Sensitivity.RowTemplate.Height = 23;
            this.dataGrid_Sensitivity.Size = new System.Drawing.Size(519, 296);
            this.dataGrid_Sensitivity.TabIndex = 1;
            // 
            // dataGrid_InitialVal
            // 
            this.dataGrid_InitialVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_InitialVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_InitialVal.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_InitialVal.Name = "dataGrid_InitialVal";
            this.dataGrid_InitialVal.RowTemplate.Height = 23;
            this.dataGrid_InitialVal.Size = new System.Drawing.Size(519, 296);
            this.dataGrid_InitialVal.TabIndex = 0;
            // 
            // radio_InitialVal
            // 
            this.radio_InitialVal.AutoSize = true;
            this.radio_InitialVal.Checked = true;
            this.radio_InitialVal.Location = new System.Drawing.Point(15, 31);
            this.radio_InitialVal.Name = "radio_InitialVal";
            this.radio_InitialVal.Size = new System.Drawing.Size(59, 16);
            this.radio_InitialVal.TabIndex = 3;
            this.radio_InitialVal.TabStop = true;
            this.radio_InitialVal.Text = "初始值";
            this.radio_InitialVal.UseVisualStyleBackColor = true;
            this.radio_InitialVal.CheckedChanged += new System.EventHandler(this.radio_InitialVal_CheckedChanged);
            // 
            // radio_Senitivity
            // 
            this.radio_Senitivity.AutoSize = true;
            this.radio_Senitivity.Location = new System.Drawing.Point(15, 53);
            this.radio_Senitivity.Name = "radio_Senitivity";
            this.radio_Senitivity.Size = new System.Drawing.Size(59, 16);
            this.radio_Senitivity.TabIndex = 3;
            this.radio_Senitivity.Text = "敏感度";
            this.radio_Senitivity.UseVisualStyleBackColor = true;
            this.radio_Senitivity.CheckedChanged += new System.EventHandler(this.radio_Senitivity_CheckedChanged);
            // 
            // radio_Unit
            // 
            this.radio_Unit.AutoSize = true;
            this.radio_Unit.Location = new System.Drawing.Point(15, 75);
            this.radio_Unit.Name = "radio_Unit";
            this.radio_Unit.Size = new System.Drawing.Size(59, 16);
            this.radio_Unit.TabIndex = 3;
            this.radio_Unit.Text = "单  位";
            this.radio_Unit.UseVisualStyleBackColor = true;
            this.radio_Unit.CheckedChanged += new System.EventHandler(this.radio_Unit_CheckedChanged);
            // 
            // radio_WarningVal
            // 
            this.radio_WarningVal.AutoSize = true;
            this.radio_WarningVal.Location = new System.Drawing.Point(15, 97);
            this.radio_WarningVal.Name = "radio_WarningVal";
            this.radio_WarningVal.Size = new System.Drawing.Size(59, 16);
            this.radio_WarningVal.TabIndex = 3;
            this.radio_WarningVal.Text = "报警值";
            this.radio_WarningVal.UseVisualStyleBackColor = true;
            this.radio_WarningVal.CheckedChanged += new System.EventHandler(this.radio_WarningVal_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radio_InitialVal);
            this.panel1.Controls.Add(this.radio_WarningVal);
            this.panel1.Controls.Add(this.radio_Senitivity);
            this.panel1.Controls.Add(this.radio_Unit);
            this.panel1.Location = new System.Drawing.Point(554, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 159);
            this.panel1.TabIndex = 4;
            // 
            // UserDatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 337);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_DataGrid);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.grid_Userdat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserDatForm";
            this.Text = "UserDatForm";
            ((System.ComponentModel.ISupportInitialize)(this.grid_Userdat)).EndInit();
            this.panel_DataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WarningVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Unit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Sensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_InitialVal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView grid_Userdat;
        private System.Windows.Forms.Button btn_OK;
        public System.Windows.Forms.Panel panel_DataGrid;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RadioButton radio_InitialVal;
        public System.Windows.Forms.RadioButton radio_Senitivity;
        public System.Windows.Forms.RadioButton radio_Unit;
        public System.Windows.Forms.RadioButton radio_WarningVal;
        private System.Windows.Forms.DataGridView dataGrid_WarningVal;
        private System.Windows.Forms.DataGridView dataGrid_Unit;
        private System.Windows.Forms.DataGridView dataGrid_Sensitivity;
        private System.Windows.Forms.DataGridView dataGrid_InitialVal;

    }
}