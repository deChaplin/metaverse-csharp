using SuperSimpleTcp;
using System.Globalization;
using System.IO.Packaging;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        List<int> serverNum = new List<int> ();
        string firstChoice;
        string secondChoice;
        int attempts;
        List<PictureBox> pictureBoxList = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;
        int timeLeft = 60;
        int countDown;
        bool isGameOver = false;
        string opponent;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Win32.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        SimpleTcpClient client;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try 
            {
                // Checks if the username or password is less than 5 characters or contains whitespaces
                if (txtName.Text.Length < 5 || txtPassword.Text.Length < 5 || txtName.Text.Contains(" ") || txtPassword.Text.Contains(" "))
                {
                    if (txtName.Text.Length < 5 || txtPassword.Text.Length < 5)
                    {
                        MessageBox.Show("Username and password must be at least 5 characters long", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (txtName.Text.Contains(" ") || txtPassword.Text.Contains(" "))
                    {
                        MessageBox.Show("Username or password can not contain a whitespace", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    client.Connect();  // Try connecting the client to the IP
                    btnSend.Enabled = true; // Enables send button
                    btnConnect.Enabled = false; // Disables connect button
                    txtName.Enabled = false;    // Disables the name text box
                    txtPassword.Enabled = false;    // Disables the password text box
                    btnMatchmake.Enabled = true;
                    btnRestart.Enabled = true;
                    txtIP.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); // Displays a error message if cannot connect
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected) // Checks if the client is connected
            {
                if (!string.IsNullOrEmpty(txtMessage.Text))     // Doesnt't allow an empty message to be sent
                {
                    client.Send("*" + txtName.Text + ": " + txtMessage.Text);   // Sends the message
                    txtChat.Text += $"Me: {txtMessage.Text}{Environment.NewLine}";  // Outputs it in the chat box
                    txtMessage.Text = string.Empty; // Empties the message box
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new(txtIP.Text);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;
            btnSend.Enabled = false;
            btnMatchmake.Enabled = false;
            btnRestart.Enabled = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                //txtChat.Text += $"{Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";  // Displays any data recieved
                string testing = Encoding.UTF8.GetString(e.Data);

                // Using prefixes and a switch statement to handle the packets correctly
                switch (testing.Substring(0, 1))
                {
                    case "+":
                        txtChat.Text += $"{testing.Substring(1)}{Environment.NewLine}";  // Displays any data recieved
                        break;
                    case "/":
                        txtChat.Text += $"{testing.Substring(1)}{Environment.NewLine}";  // Displays any data recieved
                        MessageBox.Show("The details you have enterred are incorrect. Please try again", "Incorrect details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        client.Dispose();

                        btnSend.Enabled = false; 
                        btnConnect.Enabled = true; 
                        txtName.Enabled = true;    
                        txtPassword.Enabled = true;   
                        break;
                    case "*":
                        // Image position
                        testing = testing.Replace("*", "");
                        int num = int.Parse(testing);
                        serverNum.Add(num);

                        if (serverNum.Count == 16)
                        {
                            setupGame();
                        }
                        break;
                    case "?":
                        opponent = testing.Substring(1);
                        MessageBox.Show($"You're playing against {opponent}. Good luck!");
                        break;
                    case "^":
                        gameOver(testing.Substring(1), false);
                        break;
                }
            });
        }

        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtChat.Text += $"Server disconnected.{Environment.NewLine}";   // Displays a message if the server is disconnected
            });
        }

        private void Events_Connected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtChat.Text += $"Server connected.{Environment.NewLine}";   // Displays a message if the server is connected

                client.Send("+" + txtName.Text);
                Thread.Sleep(1000);
                client.Send("/" + txtPassword.Text);
                Thread.Sleep(1000);
                client.Send("Hi!");
            });
        }

        private void btnMatchmake_Click(object sender, EventArgs e)
        {
            client.Send("#");
            btnMatchmake.Enabled = false;
        }

        //   The game
        //      |
        //      |
        //      V

        private void setupGame()
        {
            loadImages();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            countDown--;
            lblTime.Text = "Time left: " + countDown;

            if (countDown < 1)
            {
                gameOver("Times up!", false);
                foreach (PictureBox x in pictureBoxList)
                {
                    if (x.Tag != null)
                    {
                        x.Image = Image.FromFile("../../../pics/" + (string)x.Tag + ".png");
                    }
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            // Restarts game when button is pressed
            restartGame();
        }

        private void loadImages()
        {
            int leftPos = 480;
            int topPos = 20;
            int rows = 0;
            
            // Dynamically create the picture boxes
            for (int i = 0; i < 16; i++)
            {
                PictureBox newPic = new PictureBox();
                newPic.Height = 80;
                newPic.Width = 80;
                newPic.BackColor = Color.Black;
                newPic.SizeMode = PictureBoxSizeMode.StretchImage;
                newPic.Click += NewPic_Click;
                pictureBoxList.Add(newPic);

                if (rows < 4)
                {
                    rows++;
                    newPic.Left = leftPos;
                    newPic.Top = topPos;
                    this.Controls.Add(newPic);
                    leftPos = leftPos + 100;
                }

                if (rows == 4)
                {
                    leftPos = 480;
                    topPos += 100;
                    rows = 0;
                }
            }
            restartGame();
        }

        private void restartGame()
        {
            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].Image = null;
                pictureBoxList[i].Tag = serverNum[i].ToString();
            }

            attempts = 0;
            lblMismatch.Text = "Mismatched: " + attempts + " times.";
            lblTime.Text = "Time left: " + timeLeft;
            isGameOver = false;
            GameTimer.Start();
            countDown = timeLeft;
        }

        private void NewPic_Click(object? sender, EventArgs e)
        {
            if (isGameOver)
            {
                return;
            }

            if (firstChoice == null) 
            {
                picA = sender as PictureBox;
                if (picA.Tag != null && picA.Image == null)
                {
                    picA.Image = Image.FromFile("../../../pics/"+(string)picA.Tag + ".png");
                    firstChoice = (string)picA.Tag;
                }
            }
            else if (secondChoice == null) 
            {
                picB = sender as PictureBox;

                if (picB.Tag != null && picB.Image == null) 
                {
                    picB.Image = Image.FromFile("../../../pics/" + (string)picB.Tag + ".png");
                    secondChoice = (string)picB.Tag;
                }
            }
            else
            {
                checkPairs(picA, picB);
            }
        }
        
        private void checkPairs(PictureBox A, PictureBox B)
        {
            // Checks if the 2 images selected are correct
            if (firstChoice == secondChoice)
            {
                A.Tag = null;
                B.Tag = null;
            }
            else
            {
                // Updating attempts when wrong image selected
                attempts++;
                lblMismatch.Text = "Mismatched: " + attempts + " times.";
            }

            firstChoice = null;
            secondChoice = null;

            // reset images of picture boxes
            foreach (PictureBox pics in pictureBoxList.ToList()) 
            {
                if (pics.Tag != null) 
                {
                    pics.Image = null;
                }
            }

            if (pictureBoxList.All(o => o.Tag == null))
            {
                gameOver("You finished!", true);

                // Attempting to delete the picture boxes so I can restart the game without a re-log
                foreach (PictureBox pics in pictureBoxList.ToList())
                {
                    pics.Dispose();
                }
            }
        }

        private void gameOver(string msg, bool result)
        {
            GameTimer.Stop();
            isGameOver = true;
            MessageBox.Show(msg + " Click restart to play again.", "WOOHOO!");

            if (result)
            {
                client.Send($"~{opponent}");
            }
            else
            {
                client.Send("£");

                foreach (PictureBox x in pictureBoxList)
                {
                    if (x.Tag != null)
                    {
                        x.Image = Image.FromFile("../../../pics/" + (string)x.Tag + ".png");
                    }
                }
            }

            //pictureBoxList.Clear();
            btnMatchmake.Enabled = true;
            Thread.Sleep(1000);
            pictureBoxList.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}