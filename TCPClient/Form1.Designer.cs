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
            lblMismatch = new Label();
            lblTime = new Label();
            GameTimer = new System.Windows.Forms.Timer(components);
            btnSend = new RoundedButtons();
            btnMatchmake = new RoundedButtons();
            btnConnect = new RoundedButtons();
            btnMin = new Button();
            btnClose = new Button();
            btnHelp = new RoundedButtons();
            lblOpponent = new Label();
            loginPanel = new Panel();
            chatPanel = new Panel();
            lstOnline = new ListBox();
            gamePanel = new Panel();
            btnShowChat = new RoundedButtons();
            btnHideChat = new RoundedButtons();
            label1 = new Label();
            loginPanel.SuspendLayout();
            chatPanel.SuspendLayout();
            gamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // txtIP
            // 
            txtIP.BackColor = Color.FromArgb(80, 80, 80);
            txtIP.BorderStyle = BorderStyle.None;
            txtIP.Enabled = false;
            txtIP.ForeColor = Color.White;
            txtIP.Location = new Point(49, 7);
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
            txtChat.Location = new Point(6, 118);
            txtChat.Multiline = true;
            txtChat.Name = "txtChat";
            txtChat.ReadOnly = true;
            txtChat.ScrollBars = ScrollBars.Both;
            txtChat.Size = new Size(381, 267);
            txtChat.TabIndex = 2;
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.ForeColor = Color.White;
            lblServer.Location = new Point(2, 7);
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
            txtMessage.Location = new Point(64, 391);
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "...";
            txtMessage.Size = new Size(323, 16);
            txtMessage.TabIndex = 6;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(2, 392);
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
            txtName.Location = new Point(49, 39);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Username";
            txtName.Size = new Size(232, 16);
            txtName.TabIndex = 8;
            // 
            // lvlName
            // 
            lvlName.AutoSize = true;
            lvlName.ForeColor = Color.White;
            lvlName.Location = new Point(2, 39);
            lvlName.Name = "lvlName";
            lvlName.Size = new Size(42, 15);
            lvlName.TabIndex = 9;
            lvlName.Text = "Name:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(2, 68);
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
            txtPassword.Location = new Point(49, 68);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(232, 16);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblMismatch
            // 
            lblMismatch.AutoSize = true;
            lblMismatch.ForeColor = Color.White;
            lblMismatch.Location = new Point(150, 9);
            lblMismatch.Name = "lblMismatch";
            lblMismatch.Size = new Size(111, 15);
            lblMismatch.TabIndex = 14;
            lblMismatch.Text = "Match or mismatch";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(340, 9);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(56, 15);
            lblTime.TabIndex = 15;
            lblTime.Text = "Time left:";
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
            btnSend.Location = new Point(309, 412);
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
            btnMatchmake.Location = new Point(449, 3);
            btnMatchmake.Name = "btnMatchmake";
            btnMatchmake.Size = new Size(78, 27);
            btnMatchmake.TabIndex = 25;
            btnMatchmake.Text = "START";
            btnMatchmake.TextColor = Color.White;
            btnMatchmake.UseVisualStyleBackColor = false;
            btnMatchmake.Click += btnMatchmake_Click;
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
            btnConnect.Location = new Point(202, 90);
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
            btnMin.Location = new Point(528, 0);
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
            btnClose.Location = new Point(558, 0);
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
            btnHelp.BorderColor = Color.Transparent;
            btnHelp.BorderColor1 = Color.Transparent;
            btnHelp.BorderRadius = 0;
            btnHelp.BorderRadius1 = 0;
            btnHelp.BorderSize = 0;
            btnHelp.BorderSize1 = 0;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnHelp.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.ForeColor = Color.Transparent;
            btnHelp.Location = new Point(9, 8);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(18, 18);
            btnHelp.TabIndex = 30;
            btnHelp.TextColor = Color.Transparent;
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // lblOpponent
            // 
            lblOpponent.AutoSize = true;
            lblOpponent.ForeColor = Color.White;
            lblOpponent.Location = new Point(8, 9);
            lblOpponent.Name = "lblOpponent";
            lblOpponent.Size = new Size(64, 15);
            lblOpponent.TabIndex = 31;
            lblOpponent.Text = "Opponent:";
            // 
            // loginPanel
            // 
            loginPanel.Controls.Add(txtIP);
            loginPanel.Controls.Add(lblServer);
            loginPanel.Controls.Add(txtName);
            loginPanel.Controls.Add(lvlName);
            loginPanel.Controls.Add(txtPassword);
            loginPanel.Controls.Add(btnConnect);
            loginPanel.Controls.Add(lblPassword);
            loginPanel.Location = new Point(145, 162);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(288, 124);
            loginPanel.TabIndex = 32;
            // 
            // chatPanel
            // 
            chatPanel.Controls.Add(label1);
            chatPanel.Controls.Add(lstOnline);
            chatPanel.Controls.Add(txtChat);
            chatPanel.Controls.Add(txtMessage);
            chatPanel.Controls.Add(lblMessage);
            chatPanel.Controls.Add(btnSend);
            chatPanel.Location = new Point(585, 8);
            chatPanel.Name = "chatPanel";
            chatPanel.Size = new Size(390, 441);
            chatPanel.TabIndex = 33;
            // 
            // lstOnline
            // 
            lstOnline.BackColor = Color.FromArgb(80, 80, 80);
            lstOnline.BorderStyle = BorderStyle.None;
            lstOnline.ForeColor = Color.White;
            lstOnline.FormattingEnabled = true;
            lstOnline.ItemHeight = 15;
            lstOnline.Location = new Point(6, 19);
            lstOnline.Name = "lstOnline";
            lstOnline.Size = new Size(381, 90);
            lstOnline.TabIndex = 25;
            // 
            // gamePanel
            // 
            gamePanel.Controls.Add(btnMatchmake);
            gamePanel.Controls.Add(lblMismatch);
            gamePanel.Controls.Add(lblTime);
            gamePanel.Controls.Add(lblOpponent);
            gamePanel.Location = new Point(20, 414);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(532, 35);
            gamePanel.TabIndex = 34;
            // 
            // btnShowChat
            // 
            btnShowChat.BackColor = Color.FromArgb(80, 80, 80);
            btnShowChat.BackgroundColor = Color.FromArgb(80, 80, 80);
            btnShowChat.BorderColor = SystemColors.ControlDarkDark;
            btnShowChat.BorderColor1 = SystemColors.ControlDarkDark;
            btnShowChat.BorderRadius = 15;
            btnShowChat.BorderRadius1 = 15;
            btnShowChat.BorderSize = 1;
            btnShowChat.BorderSize1 = 1;
            btnShowChat.FlatAppearance.BorderSize = 0;
            btnShowChat.FlatStyle = FlatStyle.Flat;
            btnShowChat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnShowChat.ForeColor = Color.White;
            btnShowChat.Location = new Point(553, 71);
            btnShowChat.Name = "btnShowChat";
            btnShowChat.Size = new Size(26, 284);
            btnShowChat.TabIndex = 28;
            btnShowChat.Text = ">";
            btnShowChat.TextAlign = ContentAlignment.MiddleRight;
            btnShowChat.TextColor = Color.White;
            btnShowChat.UseVisualStyleBackColor = false;
            btnShowChat.Click += btnShowChat_Click;
            // 
            // btnHideChat
            // 
            btnHideChat.BackColor = Color.FromArgb(80, 80, 80);
            btnHideChat.BackgroundColor = Color.FromArgb(80, 80, 80);
            btnHideChat.BorderColor = SystemColors.ControlDarkDark;
            btnHideChat.BorderColor1 = SystemColors.ControlDarkDark;
            btnHideChat.BorderRadius = 15;
            btnHideChat.BorderRadius1 = 15;
            btnHideChat.BorderSize = 1;
            btnHideChat.BorderSize1 = 1;
            btnHideChat.FlatAppearance.BorderSize = 0;
            btnHideChat.FlatStyle = FlatStyle.Flat;
            btnHideChat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnHideChat.ForeColor = Color.White;
            btnHideChat.Location = new Point(553, 71);
            btnHideChat.Name = "btnHideChat";
            btnHideChat.Size = new Size(26, 286);
            btnHideChat.TabIndex = 35;
            btnHideChat.Text = "<";
            btnHideChat.TextAlign = ContentAlignment.MiddleRight;
            btnHideChat.TextColor = Color.White;
            btnHideChat.UseVisualStyleBackColor = false;
            btnHideChat.Click += btnHideChat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(2, 1);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 26;
            label1.Text = "Online Players - ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(56, 56, 56);
            ClientSize = new Size(980, 460);
            Controls.Add(btnHideChat);
            Controls.Add(btnShowChat);
            Controls.Add(gamePanel);
            Controls.Add(chatPanel);
            Controls.Add(loginPanel);
            Controls.Add(btnHelp);
            Controls.Add(btnMin);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.None;
            HelpButton = true;
            MaximizeBox = false;
            MinimumSize = new Size(586, 460);
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "TCP/IP Client";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            chatPanel.ResumeLayout(false);
            chatPanel.PerformLayout();
            gamePanel.ResumeLayout(false);
            gamePanel.PerformLayout();
            ResumeLayout(false);
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
        private Label lblMismatch;
        private Label lblTime;
        private System.Windows.Forms.Timer GameTimer;
        private RoundedButtons btnSend;
        private RoundedButtons btnMatchmake;
        private RoundedButtons btnConnect;
        private Button btnMin;
        private Button btnClose;
        private RoundedButtons btnHelp;
        private Label lblOpponent;
        private Panel loginPanel;
        private Panel chatPanel;
        private Panel gamePanel;
        private RoundedButtons btnShowChat;
        private RoundedButtons btnHideChat;
        private ListBox lstOnline;
        private Label label1;
    }
}