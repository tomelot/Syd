using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using Microsoft.VisualBasic;

namespace YoutubePlayer
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Player VideoPlayer;
        Networking IP = new Networking();
        Server server;
        Client client;
        Boolean clientconnect = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void Navigate_Click(object sender, EventArgs e)
        {
            VideoPlayer.PlayURL(URLtb.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VideoPlayer = new Player(player, play, TimeBar, Time, FullTime);

        }

        private void CreateAServer_Click(object sender, EventArgs e)
        {
            if (CreateAServer.Text == "Create a Room")
            {
                MessageBox.Show(IP.GetComputer_InternetIP());
                MessageBox.Show(IP.GetComputer_LanIP());
                server = new Server();
                CreateAServer.Text = "Stop The Room";
                ConnectAClient.Enabled = false;
            }
            else
            {
                MessageBox.Show("Stopped the Room");
                server.ServerStop();
                CreateAServer.Text = "Create a Room";
                ConnectAClient.Enabled = true;
            }
        }

        private void ConnectAClient_Click(object sender, EventArgs e)
        {
            if (clientconnect)
            {
                client.Clientstop();
                clientconnect = false;
            }
            string IP = Interaction.InputBox("Enter Server's IP", "Connect");
            client = new Client(IP);
            clientconnect = true;
        }
    }
}
