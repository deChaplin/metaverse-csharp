using SuperSimpleTcp;
using System;
using System.ComponentModel;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        SimpleTcpServer server;
        Database db = new Database();
        string name;
        string psw;
        List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
        List<string> lookingToPlay = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

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

            btnSend.Enabled = false; // Disables start button
            server = new SimpleTcpServer(txtIP.Text);   // Sets the IP to whatever is in the IP text box
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;

            if (db.checkDB())
            {
                db.setAllOffline();
            }

            GameTick.Start();
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            // Here I send the message to other clients
            string testing = Encoding.UTF8.GetString(e.Data);

            // Using prefixes and a switch statement to handle the packets correctly
            switch (testing.Substring(0, 1))
            {
                // Username
                case "+":
                    name = testing.Substring(1);
                    break;
                // Password
                case "/":
                    psw = testing.Substring(1);
                    break;
                // Start game
                case "#":
                    if (lookingToPlay.Contains($"{e.IpPort}"))
                    {
                        break;
                    }
                    else
                    {
                        lookingToPlay.Add($"{e.IpPort}");
                        this.Invoke((MethodInvoker)delegate
                        {
                            txtChat.Text += $"Added {e.IpPort} to looking to play list!{Environment.NewLine}";
                        });
                    }
                    break;
                // Message from client
                case "*":
                    relayMessage(testing.Substring(1), $"{e.IpPort}");
                    break;
                case "~":
                    // A player has won
                    server.Send(db.getIp(testing.Substring(1)), "^Your opponent won!");

                    db.setElo(db.getName($"{e.IpPort}"), true);

                    this.Invoke((MethodInvoker)delegate
                    {
                        txtChat.Text += $"Adding elo!{Environment.NewLine}";
                    });
                    break;
                case "£":
                    // A player has lost
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtChat.Text += $"Removing elo!{Environment.NewLine}";
                    });
                    db.setElo(db.getName($"{e.IpPort}"), false);
                    break;
            }

            if (db.getOnlineStatus(db.getName(e.IpPort)) == false && name != null && psw != null)
            {
                logging(name, psw, $"{e.IpPort}");

                name = null;
                psw = null;
            }
        }

        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtChat.Text += $"{e.IpPort} disconnected.{Environment.NewLine}";   // Displays a disconnect message
                lstClientIP.Items.Remove(e.IpPort); // Removes the client from the list
                lstClientName.Items.Remove(db.getName(e.IpPort));
            });

            db.setOnlineStatus($"{e.IpPort}", "offline");
            relayMessage($"Server: {db.getName(e.IpPort)} has disconnected", "");

            try
            {
                if (lookingToPlay.Count != 0)
                {
                    lookingToPlay.Remove($"{e.IpPort}");  // Removes the client from the looking to play list if they were in it.

                    this.Invoke((MethodInvoker)delegate
                    {
                        txtChat.Text += $"Removed {db.getName(e.IpPort)} from looking to play list{Environment.NewLine}";   // Displays a connect message
                    });
                }
            }
            catch
            {
                MessageBox.Show("Failed to remove client from list");
            }

            sendOnline();
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtChat.Text += $"{e.IpPort} connected.{Environment.NewLine}";   // Displays a connect message
            });

            //sendOnline();
        }

        private void sendOnline()
        {
            List<string> userNames = db.getAllOnline();

            string nameList = String.Join(",", userNames);

            for (int x = 0; x < lstClientIP.Items.Count; x++)
            {
                server.Send(lstClientIP.Items[x].ToString(), "," + nameList);
            }
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
                    this.Invoke((MethodInvoker)delegate
                    {
                        lstClientIP.Items.Add(ip); // Adds the client to the list
                        lstClientName.Items.Add(name);
                    });

                    db.setIp(name, ip);
                    db.setOnlineStatus(ip, "online");
                    sendOnline();
                    break;

                case 2:
                    closeClient(ip, "Incorrect login details. Please restart the app.");
                    break;
                case 3:
                    server.Send(ip, "Your account has been created!");

                    relayMessage($"Server: {name} has connected", "");
                    this.Invoke((MethodInvoker)delegate
                    {
                        lstClientIP.Items.Add(ip); // Adds the client to the list
                        lstClientName.Items.Add(name);
                    });

                    db.setIp(name, ip);
                    db.setOnlineStatus(ip, "online");
                    break;
                case 4:
                    closeClient(ip, "Incorrect login details or account is logged in somewhere else.");
                    break;
            }
        }

        private void GameTick_Tick(object sender, EventArgs e)
        {
            string player1;
            string player2;

            Random rnd = new Random();

            // check if 2 or more players are in the looking to play list
            if (lookingToPlay.Count >= 2)
            {
                // randomly select 2 players
                int index1 = rnd.Next(lookingToPlay.Count);
                int index2;

                // Ensures that the same index isn't chosen twice
                do
                {
                    index2 = rnd.Next(lookingToPlay.Count);
                }
                while (index2 == index1);

                player1 = lookingToPlay[index1];
                player2 = lookingToPlay[index2];

                this.Invoke((MethodInvoker)delegate
                {
                    txtChat.Text += $"{index1}{Environment.NewLine}";   // Displays a connect message
                    txtChat.Text += $"{index2}{Environment.NewLine}";   // Displays a connect message
                });

                // remove selected players from list
                lookingToPlay.Remove(player1);
                lookingToPlay.Remove(player2);

                // selected players 'compete' against each 
                // send each player the others IP for storage
                server.Send(player1, $"?{db.getName(player2)}");
                server.Send(player2, $"?{db.getName(player1)}");

                gameSetup(player1, player2);
                //gameSetup(player2);
            }

            // Update leader board
            dataGridView1.DataSource = db.getLeaderBoard();
            // Set the datagridview to sort by elo
            dataGridView1.Columns["elo"].SortMode = DataGridViewColumnSortMode.Automatic;
            // Set the soft property
            dataGridView1.Sort(dataGridView1.Columns["elo"], ListSortDirection.Descending);
        }

        private void gameSetup(string ip1, string ip2)
        {
            // Send image tags
            // Randomising the list
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            numbers = randomList;
            for (int i = 0; i < numbers.Count; i++)
            {
                server.Send(ip1, $"*{numbers[i]}");
                server.Send(ip2, $"*{numbers[i]}");
                Thread.Sleep(5);
            }
        }

        private void closeClient(string ip, string msg)
        {
            server.Send(ip, "/" + msg);
            Thread.Sleep(600);
            //server.DisconnectClient(ip);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(txtMessage.Text) && lstClientIP.SelectedItem != null) // Checks if the message is empty and a client is selected
                {
                    server.Send(lstClientIP.SelectedItem.ToString(), "+Server: " + txtMessage.Text);  // Sends the message to the selected client
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
                    server.Send(lstClientIP.Items[i].ToString(), "+" + testing);  // Sends the message to the selected client
                }
            };
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (db.checkDB())
            {
                db.setAllOffline();
            }
        }
    }
}