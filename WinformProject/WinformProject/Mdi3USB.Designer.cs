namespace WinformProject
{
    partial class Mdi3USB
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
            this.label_time = new System.Windows.Forms.Label();
            this.labelPD = new System.Windows.Forms.Label();
            this.labelVD = new System.Windows.Forms.Label();
            this.tbxProductID = new System.Windows.Forms.TextBox();
            this.tbxVendorID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.chkHexRece = new System.Windows.Forms.CheckBox();
            this.chkHexSend = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbxRece = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxSend = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(44, 313);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(11, 12);
            this.label_time.TabIndex = 25;
            this.label_time.Text = "0";
            // 
            // labelPD
            // 
            this.labelPD.AutoSize = true;
            this.labelPD.Location = new System.Drawing.Point(9, 38);
            this.labelPD.Name = "labelPD";
            this.labelPD.Size = new System.Drawing.Size(107, 12);
            this.labelPD.TabIndex = 3;
            this.labelPD.Text = "Product ID (hex):";
            // 
            // labelVD
            // 
            this.labelVD.AutoSize = true;
            this.labelVD.Location = new System.Drawing.Point(9, 17);
            this.labelVD.Name = "labelVD";
            this.labelVD.Size = new System.Drawing.Size(101, 12);
            this.labelVD.TabIndex = 2;
            this.labelVD.Text = "Vendor ID (hex):";
            // 
            // tbxProductID
            // 
            this.tbxProductID.Location = new System.Drawing.Point(122, 34);
            this.tbxProductID.Name = "tbxProductID";
            this.tbxProductID.Size = new System.Drawing.Size(52, 21);
            this.tbxProductID.TabIndex = 1;
            this.tbxProductID.Text = "5750";
            // 
            // tbxVendorID
            // 
            this.tbxVendorID.Location = new System.Drawing.Point(122, 11);
            this.tbxVendorID.Name = "tbxVendorID";
            this.tbxVendorID.Size = new System.Drawing.Size(52, 21);
            this.tbxVendorID.TabIndex = 0;
            this.tbxVendorID.Text = "0483";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "时间:";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(36, 47);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(65, 12);
            this.stateLabel.TabIndex = 22;
            this.stateLabel.Text = "设备未连接";
            // 
            // chkHexRece
            // 
            this.chkHexRece.AutoSize = true;
            this.chkHexRece.Location = new System.Drawing.Point(202, 313);
            this.chkHexRece.Name = "chkHexRece";
            this.chkHexRece.Size = new System.Drawing.Size(42, 16);
            this.chkHexRece.TabIndex = 21;
            this.chkHexRece.Text = "HEX";
            this.chkHexRece.UseVisualStyleBackColor = true;
            // 
            // chkHexSend
            // 
            this.chkHexSend.AutoSize = true;
            this.chkHexSend.Location = new System.Drawing.Point(202, 179);
            this.chkHexSend.Name = "chkHexSend";
            this.chkHexSend.Size = new System.Drawing.Size(42, 16);
            this.chkHexSend.TabIndex = 20;
            this.chkHexSend.Text = "HEX";
            this.chkHexSend.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(253, 176);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 18;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(253, 309);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "清除接收";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbxRece
            // 
            this.tbxRece.Location = new System.Drawing.Point(10, 204);
            this.tbxRece.Multiline = true;
            this.tbxRece.Name = "tbxRece";
            this.tbxRece.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxRece.Size = new System.Drawing.Size(318, 99);
            this.tbxRece.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelPD);
            this.groupBox2.Controls.Add(this.labelVD);
            this.groupBox2.Controls.Add(this.tbxProductID);
            this.groupBox2.Controls.Add(this.tbxVendorID);
            this.groupBox2.Location = new System.Drawing.Point(140, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 59);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设备ID";
            // 
            // tbxSend
            // 
            this.tbxSend.Location = new System.Drawing.Point(10, 72);
            this.tbxSend.Multiline = true;
            this.tbxSend.Name = "tbxSend";
            this.tbxSend.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxSend.Size = new System.Drawing.Size(318, 99);
            this.tbxSend.TabIndex = 19;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(23, 18);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(91, 23);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "连接设备";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // MdiForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 338);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.chkHexRece);
            this.Controls.Add(this.chkHexSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbxRece);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbxSend);
            this.Controls.Add(this.btnConnect);
            this.Name = "MdiForm3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "USB HID";
            this.Load += new System.EventHandler(this.MdiForm3_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label labelPD;
        private System.Windows.Forms.Label labelVD;
        private System.Windows.Forms.TextBox tbxProductID;
        private System.Windows.Forms.TextBox tbxVendorID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.CheckBox chkHexRece;
        private System.Windows.Forms.CheckBox chkHexSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbxRece;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxSend;
        private System.Windows.Forms.Button btnConnect;
    }
}