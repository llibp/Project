namespace WinformProject
{
    partial class MdiO1_1窗口互调测试
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMethod_3 = new System.Windows.Forms.Button();
            this.btnMethod_2 = new System.Windows.Forms.Button();
            this.btnMethod_1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 104);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(178, 52);
            this.textBox2.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(178, 52);
            this.textBox1.TabIndex = 8;
            // 
            // btnMethod_3
            // 
            this.btnMethod_3.Location = new System.Drawing.Point(12, 227);
            this.btnMethod_3.Name = "btnMethod_3";
            this.btnMethod_3.Size = new System.Drawing.Size(178, 23);
            this.btnMethod_3.TabIndex = 7;
            this.btnMethod_3.Text = "方法三静态类";
            this.btnMethod_3.UseVisualStyleBackColor = true;
            this.btnMethod_3.Click += new System.EventHandler(this.btnMethod_3_Click);
            // 
            // btnMethod_2
            // 
            this.btnMethod_2.Location = new System.Drawing.Point(12, 197);
            this.btnMethod_2.Name = "btnMethod_2";
            this.btnMethod_2.Size = new System.Drawing.Size(178, 23);
            this.btnMethod_2.TabIndex = 6;
            this.btnMethod_2.Text = "方法二调用委托事件";
            this.btnMethod_2.UseVisualStyleBackColor = true;
            this.btnMethod_2.Click += new System.EventHandler(this.btnMethod_2_Click);
            // 
            // btnMethod_1
            // 
            this.btnMethod_1.Location = new System.Drawing.Point(12, 167);
            this.btnMethod_1.Name = "btnMethod_1";
            this.btnMethod_1.Size = new System.Drawing.Size(178, 23);
            this.btnMethod_1.TabIndex = 5;
            this.btnMethod_1.Text = "方法1窗口传值";
            this.btnMethod_1.UseVisualStyleBackColor = true;
            this.btnMethod_1.Click += new System.EventHandler(this.btnMethod_1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // MdiO1_1窗口互调测试
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnMethod_3);
            this.Controls.Add(this.btnMethod_2);
            this.Controls.Add(this.btnMethod_1);
            this.Name = "MdiO1_1窗口互调测试";
            this.Text = "MdiO窗口互调";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnMethod_3;
        private System.Windows.Forms.Button btnMethod_2;
        private System.Windows.Forms.Button btnMethod_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}