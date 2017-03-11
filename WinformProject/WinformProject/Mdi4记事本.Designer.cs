namespace WinformProject
{
    partial class Mdi4记事本
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbxTxt = new System.Windows.Forms.TextBox();
            this.lbxTxt = new System.Windows.Forms.ListBox();
            this.btnSaveOther = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(294, 26);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(62, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "打开文件";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbxTxt
            // 
            this.tbxTxt.Location = new System.Drawing.Point(77, 26);
            this.tbxTxt.Multiline = true;
            this.tbxTxt.Name = "tbxTxt";
            this.tbxTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxTxt.Size = new System.Drawing.Size(210, 210);
            this.tbxTxt.TabIndex = 1;
            // 
            // lbxTxt
            // 
            this.lbxTxt.FormattingEnabled = true;
            this.lbxTxt.ItemHeight = 12;
            this.lbxTxt.Location = new System.Drawing.Point(8, 26);
            this.lbxTxt.Name = "lbxTxt";
            this.lbxTxt.Size = new System.Drawing.Size(65, 208);
            this.lbxTxt.TabIndex = 2;
            this.lbxTxt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxTxt_MouseDoubleClick);
            // 
            // btnSaveOther
            // 
            this.btnSaveOther.Location = new System.Drawing.Point(294, 74);
            this.btnSaveOther.Name = "btnSaveOther";
            this.btnSaveOther.Size = new System.Drawing.Size(62, 23);
            this.btnSaveOther.TabIndex = 3;
            this.btnSaveOther.Text = "另存为";
            this.btnSaveOther.UseVisualStyleBackColor = true;
            this.btnSaveOther.Click += new System.EventHandler(this.btnSaveOther_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(294, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存文件";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(294, 108);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(62, 23);
            this.btnFont.TabIndex = 5;
            this.btnFont.Text = "字体";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "TXT文件列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "TXT文件内容";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(294, 133);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(62, 23);
            this.btnColor.TabIndex = 7;
            this.btnColor.Text = "颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(294, 192);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(294, 167);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(62, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // MdiForm4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 248);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveOther);
            this.Controls.Add(this.lbxTxt);
            this.Controls.Add(this.tbxTxt);
            this.Controls.Add(this.btnOpen);
            this.Name = "MdiForm4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "记事本";
            this.Load += new System.EventHandler(this.MdiForm4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox tbxTxt;
        private System.Windows.Forms.ListBox lbxTxt;
        private System.Windows.Forms.Button btnSaveOther;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRemove;
    }
}