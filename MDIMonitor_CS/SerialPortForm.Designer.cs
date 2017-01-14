﻿namespace MDIMonitor_CS
{
    partial class SerialPortForm
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
            this.cbox_PortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_Baud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_Parity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbox_Bits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbox_Stop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_SendData = new System.Windows.Forms.Button();
            this.rich_Send = new System.Windows.Forms.RichTextBox();
            this.rich_Receive = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbox_PortName
            // 
            this.cbox_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_PortName.FormattingEnabled = true;
            this.cbox_PortName.Location = new System.Drawing.Point(76, 22);
            this.cbox_PortName.Name = "cbox_PortName";
            this.cbox_PortName.Size = new System.Drawing.Size(121, 20);
            this.cbox_PortName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号";
            // 
            // cbox_Baud
            // 
            this.cbox_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Baud.FormattingEnabled = true;
            this.cbox_Baud.Location = new System.Drawing.Point(76, 48);
            this.cbox_Baud.Name = "cbox_Baud";
            this.cbox_Baud.Size = new System.Drawing.Size(121, 20);
            this.cbox_Baud.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率";
            // 
            // cbox_Parity
            // 
            this.cbox_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Parity.FormattingEnabled = true;
            this.cbox_Parity.Location = new System.Drawing.Point(76, 74);
            this.cbox_Parity.Name = "cbox_Parity";
            this.cbox_Parity.Size = new System.Drawing.Size(121, 20);
            this.cbox_Parity.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "校验位";
            // 
            // cbox_Bits
            // 
            this.cbox_Bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Bits.FormattingEnabled = true;
            this.cbox_Bits.Location = new System.Drawing.Point(76, 100);
            this.cbox_Bits.Name = "cbox_Bits";
            this.cbox_Bits.Size = new System.Drawing.Size(121, 20);
            this.cbox_Bits.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "数据位";
            // 
            // cbox_Stop
            // 
            this.cbox_Stop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Stop.FormattingEnabled = true;
            this.cbox_Stop.Location = new System.Drawing.Point(76, 126);
            this.cbox_Stop.Name = "cbox_Stop";
            this.cbox_Stop.Size = new System.Drawing.Size(121, 20);
            this.cbox_Stop.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "停止位";
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(290, 18);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 2;
            this.btn_Open.Text = "打开串口";
            this.btn_Open.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(404, 18);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "关闭串口";
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // btn_SendData
            // 
            this.btn_SendData.Location = new System.Drawing.Point(290, 51);
            this.btn_SendData.Name = "btn_SendData";
            this.btn_SendData.Size = new System.Drawing.Size(75, 23);
            this.btn_SendData.TabIndex = 2;
            this.btn_SendData.Text = "发送数据";
            this.btn_SendData.UseVisualStyleBackColor = true;
            // 
            // rich_Send
            // 
            this.rich_Send.Location = new System.Drawing.Point(290, 80);
            this.rich_Send.Name = "rich_Send";
            this.rich_Send.Size = new System.Drawing.Size(189, 40);
            this.rich_Send.TabIndex = 3;
            this.rich_Send.Text = "";
            // 
            // rich_Receive
            // 
            this.rich_Receive.Location = new System.Drawing.Point(290, 129);
            this.rich_Receive.Name = "rich_Receive";
            this.rich_Receive.Size = new System.Drawing.Size(189, 40);
            this.rich_Receive.TabIndex = 3;
            this.rich_Receive.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "发送窗";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "接收窗";
            // 
            // SerialPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 276);
            this.Controls.Add(this.rich_Receive);
            this.Controls.Add(this.rich_Send);
            this.Controls.Add(this.btn_SendData);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbox_Stop);
            this.Controls.Add(this.cbox_Bits);
            this.Controls.Add(this.cbox_Parity);
            this.Controls.Add(this.cbox_Baud);
            this.Controls.Add(this.cbox_PortName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SerialPortForm";
            this.Text = "SerialPortForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_PortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_Baud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_Parity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbox_Bits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbox_Stop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_SendData;
        private System.Windows.Forms.RichTextBox rich_Send;
        private System.Windows.Forms.RichTextBox rich_Receive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

    }
}