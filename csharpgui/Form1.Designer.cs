namespace csharpgui
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            PictureBox MyImage1;
            lblTitle = new Label();
            tabControl1 = new TabControl();
            tabServer = new TabPage();
            btnStop = new Button();
            btnStart = new Button();
            numPortServer = new NumericUpDown();
            label1 = new Label();
            tabClient = new TabPage();
            btnDisconnect = new Button();
            btnConnect = new Button();
            numPortClient = new NumericUpDown();
            label3 = new Label();
            cboIP = new ComboBox();
            label2 = new Label();
            change_option = new TabPage();
            btnEnableOnline = new Button();
            btnEnableLocal = new Button();
            rtbChatLog = new RichTextBox();
            btnLoad = new Button();
            btnSave = new Button();
            btnClear = new Button();
            btnExit = new Button();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            grpMessage = new GroupBox();
            btnSend = new Button();
            txtMessage = new TextBox();
            label4 = new Label();
            MyImage1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)MyImage1).BeginInit();
            tabControl1.SuspendLayout();
            tabServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPortServer).BeginInit();
            tabClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPortClient).BeginInit();
            change_option.SuspendLayout();
            statusStrip1.SuspendLayout();
            grpMessage.SuspendLayout();
            SuspendLayout();
            // 
            // MyImage1
            // 
            MyImage1.Image = Properties.Resources.jan_kopriva_AV8VyUfPdNM_unsplash;
            MyImage1.Location = new Point(45, 5);
            MyImage1.Margin = new Padding(4, 5, 4, 5);
            MyImage1.Name = "MyImage1";
            MyImage1.Size = new Size(192, 137);
            MyImage1.SizeMode = PictureBoxSizeMode.Zoom;
            MyImage1.TabIndex = 0;
            MyImage1.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Comfortaa SemiBold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(245, 39);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(534, 64);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Simple Chat Application";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabServer);
            tabControl1.Controls.Add(tabClient);
            tabControl1.Controls.Add(change_option);
            tabControl1.Location = new Point(24, 152);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(805, 100);
            tabControl1.TabIndex = 2;
            // 
            // tabServer
            // 
            tabServer.Controls.Add(btnStop);
            tabServer.Controls.Add(btnStart);
            tabServer.Controls.Add(numPortServer);
            tabServer.Controls.Add(label1);
            tabServer.Location = new Point(4, 29);
            tabServer.Margin = new Padding(4, 5, 4, 5);
            tabServer.Name = "tabServer";
            tabServer.Padding = new Padding(4, 5, 4, 5);
            tabServer.Size = new Size(797, 67);
            tabServer.TabIndex = 0;
            tabServer.Text = "Server Mode";
            tabServer.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(635, 18);
            btnStop.Margin = new Padding(4, 5, 4, 5);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(133, 35);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop Service";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(482, 18);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(133, 35);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start Service";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // numPortServer
            // 
            numPortServer.Location = new Point(159, 21);
            numPortServer.Margin = new Padding(7, 12, 7, 12);
            numPortServer.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numPortServer.Name = "numPortServer";
            numPortServer.Size = new Size(191, 27);
            numPortServer.TabIndex = 1;
            numPortServer.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 0;
            label1.Text = "Listen on Port";
            // 
            // tabClient
            // 
            tabClient.Controls.Add(btnDisconnect);
            tabClient.Controls.Add(btnConnect);
            tabClient.Controls.Add(numPortClient);
            tabClient.Controls.Add(label3);
            tabClient.Controls.Add(cboIP);
            tabClient.Controls.Add(label2);
            tabClient.Location = new Point(4, 29);
            tabClient.Margin = new Padding(4, 5, 4, 5);
            tabClient.Name = "tabClient";
            tabClient.Padding = new Padding(4, 5, 4, 5);
            tabClient.Size = new Size(797, 67);
            tabClient.TabIndex = 1;
            tabClient.Text = "Client Mode";
            tabClient.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Enabled = false;
            btnDisconnect.Location = new Point(669, 16);
            btnDisconnect.Margin = new Padding(4, 5, 4, 5);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(120, 35);
            btnDisconnect.TabIndex = 5;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(541, 16);
            btnConnect.Margin = new Padding(4, 5, 4, 5);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(120, 35);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // numPortClient
            // 
            numPortClient.Location = new Point(387, 21);
            numPortClient.Margin = new Padding(7, 12, 7, 12);
            numPortClient.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numPortClient.Name = "numPortClient";
            numPortClient.Size = new Size(143, 27);
            numPortClient.TabIndex = 3;
            numPortClient.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(341, 23);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 2;
            label3.Text = "Port";
            label3.Click += label3_Click;
            // 
            // cboIP
            // 
            cboIP.FormattingEnabled = true;
            cboIP.Items.AddRange(new object[] { "127.0.0.1" });
            cboIP.Location = new Point(160, 20);
            cboIP.Margin = new Padding(4, 5, 4, 5);
            cboIP.Name = "cboIP";
            cboIP.Size = new Size(159, 28);
            cboIP.TabIndex = 1;
            cboIP.Text = "127.0.0.1";
            cboIP.SelectedIndexChanged += cboIP_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 23);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 0;
            label2.Text = "Connect to Server";
            // 
            // change_option
            // 
            change_option.Controls.Add(btnEnableOnline);
            change_option.Controls.Add(btnEnableLocal);
            change_option.Location = new Point(4, 29);
            change_option.Name = "change_option";
            change_option.Padding = new Padding(3);
            change_option.Size = new Size(797, 67);
            change_option.TabIndex = 2;
            change_option.Text = "Change Mode";
            change_option.UseVisualStyleBackColor = true;
            change_option.Click += tabPage1_Click;
            // 
            // btnEnableOnline
            // 
            btnEnableOnline.Location = new Point(205, 16);
            btnEnableOnline.Name = "btnEnableOnline";
            btnEnableOnline.Size = new Size(104, 34);
            btnEnableOnline.TabIndex = 1;
            btnEnableOnline.Text = "Online";
            btnEnableOnline.UseVisualStyleBackColor = true;
            // 
            // btnEnableLocal
            // 
            btnEnableLocal.Location = new Point(95, 16);
            btnEnableLocal.Name = "btnEnableLocal";
            btnEnableLocal.Size = new Size(104, 34);
            btnEnableLocal.TabIndex = 0;
            btnEnableLocal.Text = "Local";
            btnEnableLocal.UseVisualStyleBackColor = true;
            btnEnableLocal.Click += button1_Click;
            // 
            // rtbChatLog
            // 
            rtbChatLog.Location = new Point(28, 262);
            rtbChatLog.Margin = new Padding(4, 5, 4, 5);
            rtbChatLog.Name = "rtbChatLog";
            rtbChatLog.ReadOnly = true;
            rtbChatLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbChatLog.Size = new Size(665, 278);
            rtbChatLog.TabIndex = 3;
            rtbChatLog.Text = "";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(707, 262);
            btnLoad.Margin = new Padding(4, 5, 4, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(123, 62);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Load From File";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(709, 334);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(123, 62);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save To File";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(709, 406);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(123, 62);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(709, 478);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(123, 62);
            btnExit.TabIndex = 7;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 632);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 19, 0);
            statusStrip1.Size = new Size(845, 26);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(292, 20);
            lblStatus.Text = "Status: Connected/Waiting for Connections";
            // 
            // grpMessage
            // 
            grpMessage.Controls.Add(btnSend);
            grpMessage.Controls.Add(txtMessage);
            grpMessage.Controls.Add(label4);
            grpMessage.Location = new Point(19, 550);
            grpMessage.Margin = new Padding(4, 5, 4, 5);
            grpMessage.Name = "grpMessage";
            grpMessage.Padding = new Padding(4, 5, 4, 5);
            grpMessage.Size = new Size(813, 69);
            grpMessage.TabIndex = 8;
            grpMessage.TabStop = false;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(691, 22);
            btnSend.Margin = new Padding(4, 5, 4, 5);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(115, 35);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(104, 25);
            txtMessage.Margin = new Padding(4, 5, 4, 5);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(577, 27);
            txtMessage.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 29);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 0;
            label4.Text = "Text to send";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 658);
            Controls.Add(grpMessage);
            Controls.Add(statusStrip1);
            Controls.Add(btnExit);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(rtbChatLog);
            Controls.Add(tabControl1);
            Controls.Add(lblTitle);
            Controls.Add(MyImage1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Simple Chat";
            ((System.ComponentModel.ISupportInitialize)MyImage1).EndInit();
            tabControl1.ResumeLayout(false);
            tabServer.ResumeLayout(false);
            tabServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPortServer).EndInit();
            tabClient.ResumeLayout(false);
            tabClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPortClient).EndInit();
            change_option.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            grpMessage.ResumeLayout(false);
            grpMessage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPortServer;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPortClient;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox rtbChatLog;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox MyImage1;
        private TabPage change_option;
        private Button btnEnableLocal;
        private Button btnEnableOnline;
    }
}