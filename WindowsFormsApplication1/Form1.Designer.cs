namespace WindowsFormsApplication1 {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.buttonSelectBluetooth = new System.Windows.Forms.Button();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonSelectRecDir = new System.Windows.Forms.Button();
            this.buttonListen = new System.Windows.Forms.Button();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelRecDir = new System.Windows.Forms.Label();
            this.labelRecInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSelectBluetooth
            // 
            this.buttonSelectBluetooth.Location = new System.Drawing.Point(395, 30);
            this.buttonSelectBluetooth.Name = "buttonSelectBluetooth";
            this.buttonSelectBluetooth.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectBluetooth.TabIndex = 0;
            this.buttonSelectBluetooth.Text = "选择蓝牙";
            this.buttonSelectBluetooth.UseVisualStyleBackColor = true;
            this.buttonSelectBluetooth.Click += new System.EventHandler(this.buttonSelectBluetooth_Click);
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(395, 59);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile.TabIndex = 1;
            this.buttonSelectFile.Text = "选择文件";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(395, 88);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonSelectRecDir
            // 
            this.buttonSelectRecDir.Location = new System.Drawing.Point(395, 117);
            this.buttonSelectRecDir.Name = "buttonSelectRecDir";
            this.buttonSelectRecDir.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectRecDir.TabIndex = 3;
            this.buttonSelectRecDir.Text = "接收目录";
            this.buttonSelectRecDir.UseVisualStyleBackColor = true;
            this.buttonSelectRecDir.Click += new System.EventHandler(this.buttonselectRecDir_Click);
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(395, 146);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(75, 23);
            this.buttonListen.TabIndex = 4;
            this.buttonListen.Text = "监听";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(48, 35);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(41, 12);
            this.labelAddress.TabIndex = 5;
            this.labelAddress.Text = "设备名";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(48, 64);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(53, 12);
            this.labelPath.TabIndex = 6;
            this.labelPath.Text = "本地文件";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(48, 93);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(29, 12);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "状态";
            // 
            // labelRecDir
            // 
            this.labelRecDir.AutoSize = true;
            this.labelRecDir.Location = new System.Drawing.Point(48, 122);
            this.labelRecDir.Name = "labelRecDir";
            this.labelRecDir.Size = new System.Drawing.Size(53, 12);
            this.labelRecDir.TabIndex = 8;
            this.labelRecDir.Text = "接收目录";
            // 
            // labelRecInfo
            // 
            this.labelRecInfo.AutoSize = true;
            this.labelRecInfo.Location = new System.Drawing.Point(48, 151);
            this.labelRecInfo.Name = "labelRecInfo";
            this.labelRecInfo.Size = new System.Drawing.Size(53, 12);
            this.labelRecInfo.TabIndex = 9;
            this.labelRecInfo.Text = "停止监听";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(395, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 393);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelRecInfo);
            this.Controls.Add(this.labelRecDir);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.buttonListen);
            this.Controls.Add(this.buttonSelectRecDir);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.buttonSelectBluetooth);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectBluetooth;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonSelectRecDir;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelRecDir;
        private System.Windows.Forms.Label labelRecInfo;
        private System.Windows.Forms.Button button1;

    }
}

