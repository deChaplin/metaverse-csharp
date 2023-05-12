namespace TCPServer
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
            txtIP = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtChat = new TextBox();
            lblServer = new Label();
            btnSend = new Button();
            btnStart = new Button();
            txtMessage = new TextBox();
            lblMessage = new Label();
            lstClientIP = new ListBox();
            lblClientIP = new Label();
            GameTick = new System.Windows.Forms.Timer(components);
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtIP
            // 
            txtIP.Location = new Point(59, 9);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(232, 23);
            txtIP.TabIndex = 0;
            txtIP.Text = "127.0.0.1:9000";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtChat
            // 
            txtChat.Location = new Point(12, 38);
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
            lblServer.Location = new Point(11, 13);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(42, 15);
            lblServer.TabIndex = 3;
            lblServer.Text = "Server:";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(321, 336);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(319, 9);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(73, 311);
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "...";
            txtMessage.Size = new Size(323, 23);
            txtMessage.TabIndex = 6;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(11, 314);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(56, 15);
            lblMessage.TabIndex = 7;
            lblMessage.Text = "Message:";
            // 
            // lstClientIP
            // 
            lstClientIP.ItemHeight = 15;
            lstClientIP.Location = new Point(402, 42);
            lstClientIP.Name = "lstClientIP";
            lstClientIP.Size = new Size(199, 259);
            lstClientIP.TabIndex = 8;
            // 
            // lblClientIP
            // 
            lblClientIP.AutoSize = true;
            lblClientIP.Location = new Point(402, 13);
            lblClientIP.Name = "lblClientIP";
            lblClientIP.Size = new Size(54, 15);
            lblClientIP.TabIndex = 9;
            lblClientIP.Text = "Client IP:";
            // 
            // GameTick
            // 
            GameTick.Interval = 1000;
            GameTick.Tick += GameTick_Tick;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(607, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(244, 259);
            dataGridView1.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 364);
            Controls.Add(dataGridView1);
            Controls.Add(lblClientIP);
            Controls.Add(lstClientIP);
            Controls.Add(lblMessage);
            Controls.Add(txtMessage);
            Controls.Add(btnStart);
            Controls.Add(btnSend);
            Controls.Add(lblServer);
            Controls.Add(txtChat);
            Controls.Add(txtIP);
            Name = "Form1";
            Text = "TCP/IP Server";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIP;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtChat;
        private Label lblServer;
        private Button btnSend;
        private Button btnStart;
        private TextBox txtMessage;
        private Label lblMessage;
        private ListBox lstClientIP;
        private Label lblClientIP;
        private System.Windows.Forms.Timer GameTick;
        private DataGridView dataGridView1;
    }
}