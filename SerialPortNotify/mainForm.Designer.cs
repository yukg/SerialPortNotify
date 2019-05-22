namespace SerialPortNotify
{
    partial class mainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.chk_connect = new System.Windows.Forms.CheckBox();
            this.chk_disconnect = new System.Windows.Forms.CheckBox();
            this.num_balloontiptime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cms_notify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_registration = new System.Windows.Forms.Button();
            this.btn_deregistration = new System.Windows.Forms.Button();
            this.lnk_regedit = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_clickeventpath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_clickeventpatharg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_balloontiptime)).BeginInit();
            this.cms_notify.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk_connect
            // 
            this.chk_connect.AutoSize = true;
            this.chk_connect.Checked = true;
            this.chk_connect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_connect.Location = new System.Drawing.Point(35, 39);
            this.chk_connect.Name = "chk_connect";
            this.chk_connect.Size = new System.Drawing.Size(141, 16);
            this.chk_connect.TabIndex = 0;
            this.chk_connect.Text = "Notify when connected";
            this.chk_connect.UseVisualStyleBackColor = true;
            // 
            // chk_disconnect
            // 
            this.chk_disconnect.AutoSize = true;
            this.chk_disconnect.Location = new System.Drawing.Point(35, 61);
            this.chk_disconnect.Name = "chk_disconnect";
            this.chk_disconnect.Size = new System.Drawing.Size(156, 16);
            this.chk_disconnect.TabIndex = 1;
            this.chk_disconnect.Text = "Notify when disconnected";
            this.chk_disconnect.UseVisualStyleBackColor = true;
            // 
            // num_balloontiptime
            // 
            this.num_balloontiptime.Location = new System.Drawing.Point(35, 115);
            this.num_balloontiptime.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.num_balloontiptime.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_balloontiptime.Name = "num_balloontiptime";
            this.num_balloontiptime.Size = new System.Drawing.Size(93, 19);
            this.num_balloontiptime.TabIndex = 2;
            this.num_balloontiptime.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "BalloonTip display time :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "ms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Notify :";
            // 
            // cms_notify
            // 
            this.cms_notify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_exit});
            this.cms_notify.Name = "cms_notify";
            this.cms_notify.Size = new System.Drawing.Size(94, 26);
            // 
            // tsmi_exit
            // 
            this.tsmi_exit.Name = "tsmi_exit";
            this.tsmi_exit.Size = new System.Drawing.Size(93, 22);
            this.tsmi_exit.Text = "Exit";
            this.tsmi_exit.Click += new System.EventHandler(this.Tsmi_exit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Startup :";
            // 
            // btn_registration
            // 
            this.btn_registration.Location = new System.Drawing.Point(35, 172);
            this.btn_registration.Name = "btn_registration";
            this.btn_registration.Size = new System.Drawing.Size(119, 29);
            this.btn_registration.TabIndex = 8;
            this.btn_registration.Text = "Registration";
            this.btn_registration.UseVisualStyleBackColor = true;
            this.btn_registration.Click += new System.EventHandler(this.Btn_registration_Click);
            // 
            // btn_deregistration
            // 
            this.btn_deregistration.Location = new System.Drawing.Point(160, 172);
            this.btn_deregistration.Name = "btn_deregistration";
            this.btn_deregistration.Size = new System.Drawing.Size(119, 29);
            this.btn_deregistration.TabIndex = 9;
            this.btn_deregistration.Text = "Deregistration";
            this.btn_deregistration.UseVisualStyleBackColor = true;
            this.btn_deregistration.Click += new System.EventHandler(this.Btn_deregistration_Click);
            // 
            // lnk_regedit
            // 
            this.lnk_regedit.AutoSize = true;
            this.lnk_regedit.Location = new System.Drawing.Point(63, 147);
            this.lnk_regedit.Name = "lnk_regedit";
            this.lnk_regedit.Size = new System.Drawing.Size(89, 12);
            this.lnk_regedit.TabIndex = 10;
            this.lnk_regedit.TabStop = true;
            this.lnk_regedit.Text = "(Registry editor)";
            this.lnk_regedit.Click += new System.EventHandler(this.Lnk_regedit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 214);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Click Event:";
            // 
            // txt_clickeventpath
            // 
            this.txt_clickeventpath.Location = new System.Drawing.Point(35, 251);
            this.txt_clickeventpath.Name = "txt_clickeventpath";
            this.txt_clickeventpath.Size = new System.Drawing.Size(357, 19);
            this.txt_clickeventpath.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "Argument";
            // 
            // txt_clickeventpatharg
            // 
            this.txt_clickeventpatharg.Location = new System.Drawing.Point(35, 288);
            this.txt_clickeventpatharg.Name = "txt_clickeventpatharg";
            this.txt_clickeventpatharg.Size = new System.Drawing.Size(357, 19);
            this.txt_clickeventpatharg.TabIndex = 15;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 334);
            this.Controls.Add(this.txt_clickeventpatharg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_clickeventpath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lnk_regedit);
            this.Controls.Add(this.btn_deregistration);
            this.Controls.Add(this.btn_registration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_balloontiptime);
            this.Controls.Add(this.chk_disconnect);
            this.Controls.Add(this.chk_connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "SerialPort Notify";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_balloontiptime)).EndInit();
            this.cms_notify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_connect;
        private System.Windows.Forms.CheckBox chk_disconnect;
        private System.Windows.Forms.NumericUpDown num_balloontiptime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cms_notify;
        private System.Windows.Forms.ToolStripMenuItem tsmi_exit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_registration;
        private System.Windows.Forms.Button btn_deregistration;
        private System.Windows.Forms.LinkLabel lnk_regedit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_clickeventpath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_clickeventpatharg;
    }
}

