namespace TCPClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lvlName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMismatch = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.btnSend = new TCPClient.RoundedButtons();
            this.btnMatchmake = new TCPClient.RoundedButtons();
            this.roundedButtons2 = new TCPClient.RoundedButtons();
            this.btnConnect = new TCPClient.RoundedButtons();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHelp = new TCPClient.RoundedButtons();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIP.Enabled = false;
            this.txtIP.ForeColor = System.Drawing.Color.White;
            this.txtIP.Location = new System.Drawing.Point(59, 11);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(232, 16);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "127.0.0.1:9000";
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtChat.ForeColor = System.Drawing.Color.White;
            this.txtChat.Location = new System.Drawing.Point(9, 128);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChat.Size = new System.Drawing.Size(384, 267);
            this.txtChat.TabIndex = 2;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.ForeColor = System.Drawing.Color.White;
            this.lblServer.Location = new System.Drawing.Point(12, 11);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(42, 15);
            this.lblServer.TabIndex = 3;
            this.lblServer.Text = "Server:";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(70, 403);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PlaceholderText = "...";
            this.txtMessage.Size = new System.Drawing.Size(323, 16);
            this.txtMessage.TabIndex = 6;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(8, 404);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(56, 15);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "Message:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(59, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(232, 16);
            this.txtName.TabIndex = 8;
            // 
            // lvlName
            // 
            this.lvlName.AutoSize = true;
            this.lvlName.ForeColor = System.Drawing.Color.White;
            this.lvlName.Location = new System.Drawing.Point(12, 43);
            this.lvlName.Name = "lvlName";
            this.lvlName.Size = new System.Drawing.Size(42, 15);
            this.lvlName.TabIndex = 9;
            this.lvlName.Text = "Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(12, 72);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(33, 15);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Pass:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(59, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(232, 16);
            this.txtPassword.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(400, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 442);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // lblMismatch
            // 
            this.lblMismatch.AutoSize = true;
            this.lblMismatch.ForeColor = System.Drawing.Color.White;
            this.lblMismatch.Location = new System.Drawing.Point(934, 88);
            this.lblMismatch.Name = "lblMismatch";
            this.lblMismatch.Size = new System.Drawing.Size(111, 15);
            this.lblMismatch.TabIndex = 14;
            this.lblMismatch.Text = "Match or mismatch";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(934, 110);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(56, 15);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "Time left:";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(934, 62);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 16;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.TimerEvent);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnSend.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnSend.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSend.BorderColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSend.BorderRadius = 15;
            this.btnSend.BorderRadius1 = 15;
            this.btnSend.BorderSize = 1;
            this.btnSend.BorderSize1 = 1;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(315, 424);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(78, 27);
            this.btnSend.TabIndex = 24;
            this.btnSend.Text = "SEND";
            this.btnSend.TextColor = System.Drawing.Color.White;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnMatchmake
            // 
            this.btnMatchmake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnMatchmake.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnMatchmake.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMatchmake.BorderColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMatchmake.BorderRadius = 15;
            this.btnMatchmake.BorderRadius1 = 15;
            this.btnMatchmake.BorderSize = 1;
            this.btnMatchmake.BorderSize1 = 1;
            this.btnMatchmake.FlatAppearance.BorderSize = 0;
            this.btnMatchmake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatchmake.ForeColor = System.Drawing.Color.White;
            this.btnMatchmake.Location = new System.Drawing.Point(932, 31);
            this.btnMatchmake.Name = "btnMatchmake";
            this.btnMatchmake.Size = new System.Drawing.Size(78, 27);
            this.btnMatchmake.TabIndex = 25;
            this.btnMatchmake.Text = "START";
            this.btnMatchmake.TextColor = System.Drawing.Color.White;
            this.btnMatchmake.UseVisualStyleBackColor = false;
            this.btnMatchmake.Click += new System.EventHandler(this.btnMatchmake_Click);
            // 
            // roundedButtons2
            // 
            this.roundedButtons2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.roundedButtons2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.roundedButtons2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.roundedButtons2.BorderColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.roundedButtons2.BorderRadius = 15;
            this.roundedButtons2.BorderRadius1 = 15;
            this.roundedButtons2.BorderSize = 1;
            this.roundedButtons2.BorderSize1 = 1;
            this.roundedButtons2.FlatAppearance.BorderSize = 0;
            this.roundedButtons2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtons2.ForeColor = System.Drawing.Color.White;
            this.roundedButtons2.Location = new System.Drawing.Point(1015, 62);
            this.roundedButtons2.Name = "roundedButtons2";
            this.roundedButtons2.Size = new System.Drawing.Size(78, 27);
            this.roundedButtons2.TabIndex = 26;
            this.roundedButtons2.Text = "SEND";
            this.roundedButtons2.TextColor = System.Drawing.Color.White;
            this.roundedButtons2.UseVisualStyleBackColor = false;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnConnect.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnConnect.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnConnect.BorderColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.btnConnect.BorderRadius = 15;
            this.btnConnect.BorderRadius1 = 15;
            this.btnConnect.BorderSize = 1;
            this.btnConnect.BorderSize1 = 1;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(314, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(79, 27);
            this.btnConnect.TabIndex = 27;
            this.btnConnect.Text = "LOG IN";
            this.btnConnect.TextColor = System.Drawing.Color.White;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnMin
            // 
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.Location = new System.Drawing.Point(1111, -2);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(24, 31);
            this.btnMin.TabIndex = 29;
            this.btnMin.Text = "—";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1141, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 31);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHelp.BackgroundImage")));
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelp.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnHelp.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.btnHelp.BorderRadius = 0;
            this.btnHelp.BorderRadius1 = 0;
            this.btnHelp.BorderSize = 0;
            this.btnHelp.BorderSize1 = 0;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(1087, 6);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(18, 18);
            this.btnHelp.TabIndex = 30;
            this.btnHelp.TextColor = System.Drawing.Color.White;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(1167, 457);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.roundedButtons2);
            this.Controls.Add(this.btnMatchmake);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMismatch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lvlName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.txtIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TCP/IP Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtIP;
        private TextBox txtChat;
        private Label lblServer;
        private TextBox txtMessage;
        private Label lblMessage;
        private TextBox txtName;
        private Label lvlName;
        private Label lblPassword;
        private TextBox txtPassword;
        private PictureBox pictureBox1;
        private Label lblMismatch;
        private Label lblTime;
        private Button btnRestart;
        private System.Windows.Forms.Timer GameTimer;
        private RoundedButtons btnSend;
        private RoundedButtons btnMatchmake;
        private RoundedButtons roundedButtons2;
        private RoundedButtons btnConnect;
        private Button btnMin;
        private Button btnClose;
        private RoundedButtons btnHelp;
    }
}