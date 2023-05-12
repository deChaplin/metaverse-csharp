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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtIP = new TextBox();
            txtChat = new TextBox();
            lblServer = new Label();
            txtMessage = new TextBox();
            lblMessage = new Label();
            txtName = new TextBox();
            lvlName = new Label();
            lblPassword = new Label();
            txtPassword = new TextBox();
            pictureBox1 = new PictureBox();
            lblMismatch = new Label();
            lblTime = new Label();
            btnRestart = new Button();
            GameTimer = new System.Windows.Forms.Timer(components);
            btnSend = new RoundedButtons();
            btnMatchmake = new RoundedButtons();
            roundedButtons2 = new RoundedButtons();
            btnConnect = new RoundedButtons();
            btnMin = new Button();
            btnClose = new Button();
            btnHelp = new RoundedButtons();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtIP
            // 
            txtIP.BackColor = Color.FromArgb(80, 80, 80);
            txtIP.BorderStyle = BorderStyle.None;
            txtIP.Enabled = false;
            txtIP.ForeColor = Color.White;
            txtIP.Location = new Point(59, 11);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(232, 16);
            txtIP.TabIndex = 0;
            txtIP.Text = "127.0.0.1:9000";
            // 
            // txtChat
            // 
            txtChat.BackColor = Color.FromArgb(80, 80, 80);
            txtChat.BorderStyle = BorderStyle.None;
            txtChat.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtChat.ForeColor = Color.White;
            txtChat.Location = new Point(9, 128);
            txtChat.Multiline = true;
            txtChat.Name = "txtChat";
            txtChat.ReadOnly = true;
            txtChat.ScrollBars = ScrollBars.Both;
            txtChat.Size = new Size(384, 267);
            txtChat.TabIndex = 2;
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.ForeColor = Color.White;
            lblServer.Location = new Point(12, 11);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(42, 15);
            lblServer.TabIndex = 3;
            lblServer.Text = "Server:";
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.FromArgb(80, 80, 80);
            txtMessage.BorderStyle = BorderStyle.None;
            txtMessage.ForeColor = Color.White;
            txtMessage.Location = new Point(70, 403);
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "...";
            txtMessage.Size = new Size(323, 16);
            txtMessage.TabIndex = 6;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(8, 404);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(56, 15);
            lblMessage.TabIndex = 7;
            lblMessage.Text = "Message:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(80, 80, 80);
            txtName.BorderStyle = BorderStyle.None;
            txtName.ForeColor = Color.White;
            txtName.Location = new Point(59, 43);
            txtName.Name = "txtName";
            txtName.Size = new Size(232, 16);
            txtName.TabIndex = 8;
            // 
            // lvlName
            // 
            lvlName.AutoSize = true;
            lvlName.ForeColor = Color.White;
            lvlName.Location = new Point(12, 43);
            lvlName.Name = "lvlName";
            lvlName.Size = new Size(42, 15);
            lvlName.TabIndex = 9;
            lvlName.Text = "Name:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(12, 72);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(33, 15);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Pass:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(80, 80, 80);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(59, 72);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(232, 16);
            txtPassword.TabIndex = 10;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(400, 8);
            pictureBox1.Margin = new Padding(1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(2, 442);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // lblMismatch
            // 
            lblMismatch.AutoSize = true;
            lblMismatch.ForeColor = Color.White;
            lblMismatch.Location = new Point(934, 88);
            lblMismatch.Name = "lblMismatch";
            lblMismatch.Size = new Size(111, 15);
            lblMismatch.TabIndex = 14;
            lblMismatch.Text = "Match or mismatch";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(934, 110);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(56, 15);
            lblTime.TabIndex = 15;
            lblTime.Text = "Time left:";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(934, 62);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(75, 23);
            btnRestart.TabIndex = 16;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // GameTimer
            // 
            GameTimer.Interval = 1000;
            GameTimer.Tick += TimerEvent;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(80, 80, 80);
            btnSend.BackgroundColor = Color.FromArgb(80, 80, 80);
            btnSend.BorderColor = SystemColors.ControlDarkDark;
            btnSend.BorderColor1 = SystemColors.ControlDarkDark;
            btnSend.BorderRadius = 15;
            btnSend.BorderRadius1 = 15;
            btnSend.BorderSize = 1;
            btnSend.BorderSize1 = 1;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(315, 424);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(78, 27);
            btnSend.TabIndex = 24;
            btnSend.Text = "SEND";
            btnSend.TextColor = Color.White;
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // btnMatchmake
            // 
            btnMatchmake.BackColor = Color.FromArgb(80, 80, 80);
            btnMatchmake.BackgroundColor = Color.FromArgb(80, 80, 80);
            btnMatchmake.BorderColor = SystemColors.ControlDarkDark;
            btnMatchmake.BorderColor1 = SystemColors.ControlDarkDark;
            btnMatchmake.BorderRadius = 15;
            btnMatchmake.BorderRadius1 = 15;
            btnMatchmake.BorderSize = 1;
            btnMatchmake.BorderSize1 = 1;
            btnMatchmake.FlatAppearance.BorderSize = 0;
            btnMatchmake.FlatStyle = FlatStyle.Flat;
            btnMatchmake.ForeColor = Color.White;
            btnMatchmake.Location = new Point(932, 31);
            btnMatchmake.Name = "btnMatchmake";
            btnMatchmake.Size = new Size(78, 27);
            btnMatchmake.TabIndex = 25;
            btnMatchmake.Text = "START";
            btnMatchmake.TextColor = Color.White;
            btnMatchmake.UseVisualStyleBackColor = false;
            btnMatchmake.Click += btnMatchmake_Click;
            // 
            // roundedButtons2
            // 
            roundedButtons2.BackColor = Color.FromArgb(80, 80, 80);
            roundedButtons2.BackgroundColor = Color.FromArgb(80, 80, 80);
            roundedButtons2.BorderColor = SystemColors.ControlDarkDark;
            roundedButtons2.BorderColor1 = SystemColors.ControlDarkDark;
            roundedButtons2.BorderRadius = 15;
            roundedButtons2.BorderRadius1 = 15;
            roundedButtons2.BorderSize = 1;
            roundedButtons2.BorderSize1 = 1;
            roundedButtons2.FlatAppearance.BorderSize = 0;
            roundedButtons2.FlatStyle = FlatStyle.Flat;
            roundedButtons2.ForeColor = Color.White;
            roundedButtons2.Location = new Point(1015, 62);
            roundedButtons2.Name = "roundedButtons2";
            roundedButtons2.Size = new Size(78, 27);
            roundedButtons2.TabIndex = 26;
            roundedButtons2.Text = "SEND";
            roundedButtons2.TextColor = Color.White;
            roundedButtons2.UseVisualStyleBackColor = false;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.FromArgb(80, 80, 80);
            btnConnect.BackgroundColor = Color.FromArgb(80, 80, 80);
            btnConnect.BorderColor = SystemColors.ControlDarkDark;
            btnConnect.BorderColor1 = SystemColors.ControlDarkDark;
            btnConnect.BorderRadius = 15;
            btnConnect.BorderRadius1 = 15;
            btnConnect.BorderSize = 1;
            btnConnect.BorderSize1 = 1;
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(314, 5);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(79, 27);
            btnConnect.TabIndex = 27;
            btnConnect.Text = "LOG IN";
            btnConnect.TextColor = Color.White;
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnMin
            // 
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMin.ForeColor = Color.White;
            btnMin.Location = new Point(1111, -2);
            btnMin.Name = "btnMin";
            btnMin.Size = new Size(24, 31);
            btnMin.TabIndex = 29;
            btnMin.Text = "—";
            btnMin.UseVisualStyleBackColor = true;
            btnMin.Click += btnMin_Click;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1141, -2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(24, 31);
            btnClose.TabIndex = 28;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.Transparent;
            btnHelp.BackgroundColor = Color.Transparent;
            btnHelp.BackgroundImage = (Image)resources.GetObject("btnHelp.BackgroundImage");
            btnHelp.BackgroundImageLayout = ImageLayout.Stretch;
            btnHelp.BorderColor = Color.PaleVioletRed;
            btnHelp.BorderColor1 = Color.PaleVioletRed;
            btnHelp.BorderRadius = 0;
            btnHelp.BorderRadius1 = 0;
            btnHelp.BorderSize = 0;
            btnHelp.BorderSize1 = 0;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.ForeColor = Color.Transparent;
            btnHelp.Location = new Point(1087, 6);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(18, 18);
            btnHelp.TabIndex = 30;
            btnHelp.TextColor = Color.Transparent;
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(56, 56, 56);
            ClientSize = new Size(1167, 457);
            Controls.Add(btnHelp);
            Controls.Add(btnMin);
            Controls.Add(btnClose);
            Controls.Add(btnConnect);
            Controls.Add(roundedButtons2);
            Controls.Add(btnMatchmake);
            Controls.Add(btnSend);
            Controls.Add(btnRestart);
            Controls.Add(lblTime);
            Controls.Add(lblMismatch);
            Controls.Add(pictureBox1);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lvlName);
            Controls.Add(txtName);
            Controls.Add(lblMessage);
            Controls.Add(txtMessage);
            Controls.Add(lblServer);
            Controls.Add(txtChat);
            Controls.Add(txtIP);
            FormBorderStyle = FormBorderStyle.None;
            HelpButton = true;
            MaximizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "TCP/IP Client";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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