using SuperSimpleTcp;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;
        Database db = new Database();

        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Start(); // Starts the TCP server
            txtChat.Text += $"Starting...{Environment.NewLine}";    // Outputs message to chat box
            btnStart.Enabled = false;   // Disables the start button
            btnSend.Enabled = true;    // Enables the send button
            txtChat.Text += $"Server running...{Environment.NewLine}";    // Outputs message to chat box
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db.main();

            btnSend.Enabled= false; // Disables start button
            server = new SimpleTcpServer(txtIP.Text);   // Sets the IP to whatever is in the IP text box
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }

        string name;
        string psw;

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtChat.Text += $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";  // Outputs any message recieved to the chat box
            });

            // Here I send the message to other clients
            string testing = Encoding.UTF8.GetString(e.Data);


            // Using prefixes and a switch statement to handle the packets correctly
            switch (testing.Substring(0, 1))
            {
                case "+":
                    name = testing.Substring(1);
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtChat.Text += $"name: {name}{Environment.NewLine}";
                    });
                    break;
                case "/":
                    psw = testing.Substring(1);
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtChat.Text += $"pass: {psw}{Environment.NewLine}";  // Outputs any message recieved to the chat box
                    });
                    break;

                case "*":
                    relayMessage(testing.Substring(1), $"{e.IpPort}");
                    break;
            }

            if (db.getOnlineStatus(name) == false && name != null && psw != null)
            {
                logging(name, psw, $"{e.IpPort}");
                

                name = null;
                psw = null;
            }



            // Old way... kinda broken
            //var match = testing.IndexOfAny(".".ToCharArray()) != -1;
            //var match2 = testing.IndexOfAny("~".ToCharArray()) != -1;
            //string psw = "";

            /*if (match2 == true && match == false)
            {
                psw = testing.Substring(2);
            }

            if (match == true && match2 == false)
            {
                string temp = testing.Substring(2); // Removes the prefix
                // Assign name to ip address
                //db.checkUserName(temp, "Password", $"{e.IpPort}");
                logging(temp, psw, $"{e.IpPort}");
            }

            if (match == false && match2 == false)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    txtChat.Text += $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";  // Outputs any message recieved to the chat box
                });
                relayMessage(testing, $"{e.IpPort}");
            }*/

            //relayMessage(testing, $"{e.IpPort}");
        }

        // Logging in
        private void logging(string name, string password, string ip)
        {
            int result = 0;


            // Check if the username exists
            // If it does check login details
            // If it doesn't create the user
            result = db.checkUserName(name, password, ip);

            switch (result) 
            {
                case 1:
                    relayMessage($"Server: {name} has connected", "");
                    db.setIp(name, ip);
                    db.setOnlineStatus(ip, "online");
                    break;
                case 2:
                    closeClient(ip);
                    break;
                case 3:
                    server.Send(ip, "Your account has been created!");
                    db.setOnlineStatus(ip, "online");
                    break;
            }
        }

        private void closeClient(string ip)
        {
            server.Send(ip, "Incorrect login details. Please restart the app.");
            server.DisconnectClient(ip);
        }


        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtChat.Text += $"{e.IpPort} disconnected.{Environment.NewLine}";   // Displays a disconnect message
                lstClientIP.Items.Remove(e.IpPort); // Removes the client from the list
            });

            db.setOnlineStatus($"{e.IpPort}", "offline");
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {

            this.Invoke((MethodInvoker)delegate
            {
                txtChat.Text += $"{e.IpPort} connected.{Environment.NewLine}";   // Displays a connect message
                lstClientIP.Items.Add(e.IpPort); // Adds the client to the list
            });
            //server.Send($"{e.IpPort}", $"Please enter your name{Environment.NewLine}");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening) 
            {
                if(!string.IsNullOrEmpty(txtMessage.Text) && lstClientIP.SelectedItem != null) // Checks if the message is empty and a client is selected
                {
                    server.Send(lstClientIP.SelectedItem.ToString(), txtMessage.Text);  // Sends the message to the selected client
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtChat.Text += $"Server: {txtMessage.Text}{Environment.NewLine}";  // Outputs the message in the chat
                    });
                    txtMessage.Text = string.Empty; // Empties the message box
                }
            }
        }

        private void relayMessage(string testing, string senderIP)
        {
            for (int i = 0; i < lstClientIP.Items.Count; i++) 
            {
                if (lstClientIP.Items[i].ToString() != senderIP)
                {
                    server.Send(lstClientIP.Items[i].ToString(), testing);  // Sends the message to the selected client
                }
            };
        }
    }
}