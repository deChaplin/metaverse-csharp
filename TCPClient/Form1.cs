using SuperSimpleTcp;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
        string firstChoice;
        string secondChoice;
        int attempts;
        List<PictureBox> pictureBoxList = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;
        int timeLeft = 30;
        int countDown;
        bool isGameOver = false;

        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try 
            {
                client.Connect();  // Try connecting the client to the IP
                btnSend.Enabled = true; // Enables send button
                btnConnect.Enabled = false; // Disables connect button
                txtName.Enabled = false;    // Disables the name text box
                txtPassword.Enabled = false;    // Disables the password text box
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

            setupGame();
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtChat.Text += $"{Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";  // Displays any data recieved by the server in the chat box
                //txtChat.Text += $"Server: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";  // Displays any data recieved by the server in the chat box
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
                gameOver("Times up!");
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

        private void NewPic_Click(object? sender, EventArgs e)
        {
            if (isGameOver)
            {
                return;
            }

            if (firstChoice== null) 
            {
                picA = sender as PictureBox;
                if (picA.Tag != null && picA.Image == null)
                {
                    picA.Image = Image.FromFile("../../../pics/"+(string)picA.Tag + ".png");
                    firstChoice = (string)picA.Tag;
                }
            }
            else if (secondChoice== null) 
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

        private void restartGame()
        {
            // Randomising the list
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();

            numbers = randomList;

            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].Image = null;
                pictureBoxList[i].Tag = numbers[i].ToString();
            }

            attempts = 0;
            lblMismatch.Text = "Mismatched: " + attempts + " times.";
            lblTime.Text = "Time left: " + timeLeft;
            isGameOver = false;
            GameTimer.Start();
            countDown = timeLeft;
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

            if (pictureBoxList.All(o => o.Tag != pictureBoxList[0].Tag)) 
            {
                gameOver("You finished in " + timeLeft);
            }
        }

        private void gameOver(string msg)
        {
            GameTimer.Stop();
            isGameOver = true;
            MessageBox.Show(msg + " Click restart to play again.", "WOOHOO!");
        }

    }
}