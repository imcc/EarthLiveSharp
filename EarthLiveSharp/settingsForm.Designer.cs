namespace EarthLiveSharp
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.LbtnCheckUpdate = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CbImageSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtUpdateMinutes = new System.Windows.Forms.NumericUpDown();
            this.CbAutoStart = new System.Windows.Forms.CheckBox();
            this.TxtMaxImageNumber = new System.Windows.Forms.NumericUpDown();
            this.BtnApply = new System.Windows.Forms.Button();
            this.LblVersion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LbtnReadMore = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.CbDisplayMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUpdateMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMaxImageNumber)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbtnCheckUpdate
            // 
            this.LbtnCheckUpdate.AutoSize = true;
            this.LbtnCheckUpdate.Location = new System.Drawing.Point(47, 270);
            this.LbtnCheckUpdate.Name = "LbtnCheckUpdate";
            this.LbtnCheckUpdate.Size = new System.Drawing.Size(83, 12);
            this.LbtnCheckUpdate.TabIndex = 7;
            this.LbtnCheckUpdate.TabStop = true;
            this.LbtnCheckUpdate.Text = "check upgrade";
            this.LbtnCheckUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LbtnCheckUpdate_Clicked);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CbImageSource);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtUpdateMinutes);
            this.panel1.Controls.Add(this.CbAutoStart);
            this.panel1.Controls.Add(this.TxtMaxImageNumber);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 123);
            this.panel1.TabIndex = 11;
            this.panel1.Tag = "";
            // 
            // CbImageSource
            // 
            this.CbImageSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbImageSource.FormattingEnabled = true;
            this.CbImageSource.Items.AddRange(new object[] {
            "origin",
            "cdn"});
            this.CbImageSource.Location = new System.Drawing.Point(175, 15);
            this.CbImageSource.Name = "CbImageSource";
            this.CbImageSource.Size = new System.Drawing.Size(98, 20);
            this.CbImageSource.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Image Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Update Interval (minutes)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max Number of Images";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Autostart";
            // 
            // TxtUpdateMinutes
            // 
            this.TxtUpdateMinutes.Location = new System.Drawing.Point(175, 41);
            this.TxtUpdateMinutes.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.TxtUpdateMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtUpdateMinutes.Name = "TxtUpdateMinutes";
            this.TxtUpdateMinutes.ReadOnly = true;
            this.TxtUpdateMinutes.Size = new System.Drawing.Size(98, 21);
            this.TxtUpdateMinutes.TabIndex = 2;
            this.TxtUpdateMinutes.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // CbAutoStart
            // 
            this.CbAutoStart.AutoSize = true;
            this.CbAutoStart.Location = new System.Drawing.Point(175, 99);
            this.CbAutoStart.Name = "CbAutoStart";
            this.CbAutoStart.Size = new System.Drawing.Size(15, 14);
            this.CbAutoStart.TabIndex = 5;
            this.CbAutoStart.UseVisualStyleBackColor = true;
            // 
            // TxtMaxImageNumber
            // 
            this.TxtMaxImageNumber.Location = new System.Drawing.Point(175, 68);
            this.TxtMaxImageNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.TxtMaxImageNumber.Name = "TxtMaxImageNumber";
            this.TxtMaxImageNumber.Size = new System.Drawing.Size(98, 21);
            this.TxtMaxImageNumber.TabIndex = 3;
            this.TxtMaxImageNumber.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // BtnApply
            // 
            this.BtnApply.Location = new System.Drawing.Point(150, 261);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(75, 23);
            this.BtnApply.TabIndex = 6;
            this.BtnApply.Text = "Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(10, 270);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(29, 12);
            this.LblVersion.TabIndex = 12;
            this.LblVersion.Text = "v0.0";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.LbtnReadMore);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.CbDisplayMode);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(14, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 112);
            this.panel2.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "Slideshow: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(275, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "Customized: You can change the display style.";
            // 
            // LbtnReadMore
            // 
            this.LbtnReadMore.AutoSize = true;
            this.LbtnReadMore.Location = new System.Drawing.Point(75, 81);
            this.LbtnReadMore.Name = "LbtnReadMore";
            this.LbtnReadMore.Size = new System.Drawing.Size(65, 12);
            this.LbtnReadMore.TabIndex = 7;
            this.LbtnReadMore.TabStop = true;
            this.LbtnReadMore.Text = "read this.";
            this.LbtnReadMore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LbtnReadMore_Clicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(281, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "Default: Only show the latest image in center.";
            // 
            // CbDisplayMode
            // 
            this.CbDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDisplayMode.DropDownWidth = 200;
            this.CbDisplayMode.FormattingEnabled = true;
            this.CbDisplayMode.Items.AddRange(new object[] {
            "Only latest (Default)",
            "Only latest (Customized Style)",
            "Slideshow  (Customized Style)"});
            this.CbDisplayMode.Location = new System.Drawing.Point(96, 7);
            this.CbDisplayMode.Name = "CbDisplayMode";
            this.CbDisplayMode.Size = new System.Drawing.Size(176, 20);
            this.CbDisplayMode.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Display mode";
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(231, 261);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 14;
            this.BtnOK.Text = "Ok";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LbtnCheckUpdate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Text = "设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUpdateMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMaxImageNumber)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LbtnCheckUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.ComboBox CbImageSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown TxtUpdateMinutes;
        private System.Windows.Forms.CheckBox CbAutoStart;
        private System.Windows.Forms.NumericUpDown TxtMaxImageNumber;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox CbDisplayMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel LbtnReadMore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnOK;
    }
}

