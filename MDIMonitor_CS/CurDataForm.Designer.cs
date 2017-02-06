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
            this.richText_DataRec = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richText_DataRec
            // 
            this.richText_DataRec.Location = new System.Drawing.Point(150, 67);
            this.richText_DataRec.Name = "richText_DataRec";
            this.richText_DataRec.Size = new System.Drawing.Size(250, 83);
            this.richText_DataRec.TabIndex = 0;
            this.richText_DataRec.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据接收口";
            // 
            // CurDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 452);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richText_DataRec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CurDataForm";
            this.Text = "CurDataForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox richText_DataRec;
    }
}