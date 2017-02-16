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
            this.btn_OK = new System.Windows.Forms.Button();
            this.dataGrid_InitialVal = new System.Windows.Forms.DataGridView();
            this.radio_InitialVal = new System.Windows.Forms.RadioButton();
            this.radio_Senitivity = new System.Windows.Forms.RadioButton();
            this.radio_Unit = new System.Windows.Forms.RadioButton();
            this.radio_WarningVal = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radio_Mark = new System.Windows.Forms.RadioButton();
            this.btn_NO = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numeric_measure_step = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_node_num = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numeric_cur_node = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numeric_ch_of_curnode = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_InitialVal)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_measure_step)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_node_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cur_node)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ch_of_curnode)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(735, 44);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "保存";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // dataGrid_InitialVal
            // 
            this.dataGrid_InitialVal.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_InitialVal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid_InitialVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_InitialVal.Location = new System.Drawing.Point(12, 8);
            this.dataGrid_InitialVal.Name = "dataGrid_InitialVal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGrid_InitialVal.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid_InitialVal.RowTemplate.Height = 23;
            this.dataGrid_InitialVal.Size = new System.Drawing.Size(531, 265);
            this.dataGrid_InitialVal.TabIndex = 0;
            // 
            // radio_InitialVal
            // 
            this.radio_InitialVal.AutoSize = true;
            this.radio_InitialVal.Checked = true;
            this.radio_InitialVal.Location = new System.Drawing.Point(21, 13);
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
            this.radio_Senitivity.Location = new System.Drawing.Point(21, 35);
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
            this.radio_Unit.Location = new System.Drawing.Point(21, 57);
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
            this.radio_WarningVal.Location = new System.Drawing.Point(21, 79);
            this.radio_WarningVal.Name = "radio_WarningVal";
            this.radio_WarningVal.Size = new System.Drawing.Size(59, 16);
            this.radio_WarningVal.TabIndex = 3;
            this.radio_WarningVal.Text = "报警值";
            this.radio_WarningVal.UseVisualStyleBackColor = true;
            this.radio_WarningVal.CheckedChanged += new System.EventHandler(this.radio_WarningVal_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radio_Mark);
            this.panel1.Controls.Add(this.radio_InitialVal);
            this.panel1.Controls.Add(this.radio_WarningVal);
            this.panel1.Controls.Add(this.radio_Senitivity);
            this.panel1.Controls.Add(this.radio_Unit);
            this.panel1.Location = new System.Drawing.Point(570, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 140);
            this.panel1.TabIndex = 4;
            // 
            // radio_Mark
            // 
            this.radio_Mark.AutoSize = true;
            this.radio_Mark.Location = new System.Drawing.Point(21, 102);
            this.radio_Mark.Name = "radio_Mark";
            this.radio_Mark.Size = new System.Drawing.Size(59, 16);
            this.radio_Mark.TabIndex = 4;
            this.radio_Mark.TabStop = true;
            this.radio_Mark.Text = "空  白";
            this.radio_Mark.UseVisualStyleBackColor = true;
            this.radio_Mark.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btn_NO
            // 
            this.btn_NO.Location = new System.Drawing.Point(735, 84);
            this.btn_NO.Name = "btn_NO";
            this.btn_NO.Size = new System.Drawing.Size(75, 23);
            this.btn_NO.TabIndex = 1;
            this.btn_NO.Text = "取消";
            this.btn_NO.UseVisualStyleBackColor = true;
            this.btn_NO.Click += new System.EventHandler(this.btn_NO_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "测量时距";
            // 
            // numeric_measure_step
            // 
            this.numeric_measure_step.Location = new System.Drawing.Point(86, 26);
            this.numeric_measure_step.Name = "numeric_measure_step";
            this.numeric_measure_step.Size = new System.Drawing.Size(59, 21);
            this.numeric_measure_step.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "节点数";
            // 
            // numeric_node_num
            // 
            this.numeric_node_num.Location = new System.Drawing.Point(231, 27);
            this.numeric_node_num.Name = "numeric_node_num";
            this.numeric_node_num.Size = new System.Drawing.Size(59, 21);
            this.numeric_node_num.TabIndex = 6;
            this.numeric_node_num.ValueChanged += new System.EventHandler(this.numeric_node_num_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "节点号";
            // 
            // numeric_cur_node
            // 
            this.numeric_cur_node.Location = new System.Drawing.Point(86, 70);
            this.numeric_cur_node.Name = "numeric_cur_node";
            this.numeric_cur_node.Size = new System.Drawing.Size(59, 21);
            this.numeric_cur_node.TabIndex = 6;
            this.numeric_cur_node.ValueChanged += new System.EventHandler(this.numeric_cur_node_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "节点通道数";
            // 
            // numeric_ch_of_curnode
            // 
            this.numeric_ch_of_curnode.Location = new System.Drawing.Point(232, 70);
            this.numeric_ch_of_curnode.Name = "numeric_ch_of_curnode";
            this.numeric_ch_of_curnode.Size = new System.Drawing.Size(59, 21);
            this.numeric_ch_of_curnode.TabIndex = 6;
            this.numeric_ch_of_curnode.ValueChanged += new System.EventHandler(this.numeric_ch_of_curnode_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.numeric_ch_of_curnode);
            this.panel2.Controls.Add(this.numeric_measure_step);
            this.panel2.Controls.Add(this.numeric_cur_node);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.numeric_node_num);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(549, 158);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 115);
            this.panel2.TabIndex = 7;
            // 
            // UserDatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 486);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGrid_InitialVal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_NO);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserDatForm";
            this.Text = "UserDatForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_InitialVal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_measure_step)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_node_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cur_node)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ch_of_curnode)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RadioButton radio_InitialVal;
        public System.Windows.Forms.RadioButton radio_Senitivity;
        public System.Windows.Forms.RadioButton radio_Unit;
        public System.Windows.Forms.RadioButton radio_WarningVal;
        private System.Windows.Forms.DataGridView dataGrid_InitialVal;
        private System.Windows.Forms.Button btn_NO;
        private System.Windows.Forms.RadioButton radio_Mark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numeric_measure_step;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numeric_node_num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numeric_cur_node;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numeric_ch_of_curnode;
        private System.Windows.Forms.Panel panel2;

    }
}