using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SuperSimpleTcp;

namespace TCPClient
{
    public partial class loginForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        SimpleTcpClient client;

        private void loginForm_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        public loginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Win32.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            btnLogIn.Focus();

            client = new("127.0.0.1:9000");
            client.Events.Connected += Events_Connected;
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            client.Send("+" + txtName.Text);
            Thread.Sleep(1000);
            client.Send("/" + txtPassword.Text);
            Thread.Sleep(1000);
        }

        private void lblForgotPsw_Click(object sender, EventArgs e)
        {
            // Popup box
        }

        private void btnLogin_Click(object sender, EventArgs e)
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

                    Form1 f1 = new Form1();
                    f1.Show();

                    client.Dispose();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); // Displays a error message if cannot connect
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
