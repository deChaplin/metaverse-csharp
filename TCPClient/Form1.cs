using SuperSimpleTcp;
using System.Text;

namespace TCPClient
{
    public partial class Form1 : Form
    {
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

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}