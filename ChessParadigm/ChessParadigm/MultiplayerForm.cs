using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class MultiplayerForm : Form
    {
        private ChessClient _client;
        public static MultiplayerForm Instance;
        public MultiplayerForm()
        {
            InitializeComponent();
            if (Instance == null)
            {
                Instance = this;
            }
        }
        public void SetConnectionStatus(bool connected)
        {
            if (connected)
            {
                lblStatus.Text = "Connected";
                lblStatus.ForeColor = Color.Green;
                btnCreate.Enabled = true;
                txtLobbyName.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
                txtLobbyName.Enabled = false;
                lblStatus.Text = "Offline";
                lblStatus.ForeColor = Color.Red;
            }
        }
        private async void RefreshLobbyList()
        {
            lstLobbies.Items.Clear();
            List<string> lobby = await _client.GetLobbies();
            lstLobbies.Items.AddRange(lobby.ToArray());
        }
        private void btnConnectLobby_Click(object sender, EventArgs e)
        {
            _client.ConnectLobby(lstLobbies.Items[lstLobbies.SelectedIndex].ToString());
            _client.Colour = PieceColour.Black;
            Helper.ChessClient = _client;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            _client.CreateLobby(txtLobbyName.Text);
            _client.Colour = PieceColour.White;
            Helper.ChessClient = _client;
            lblWaiting.Text = "Waiting for second player...";
        }
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLobbyList();
        }
        private async void btnConnectServer_Click(object sender, EventArgs e)
        {
            if (_client != null && _client.IsConnected)
            {
                return;
            }
            _client = new ChessClient(); //New client if no client connected already
            if (await _client.Connect(txtHostIP.Text)) //If client has connected
            {
                SetConnectionStatus(true);
                RefreshLobbyList();
            }
            else
            {
                SetConnectionStatus(false);
            }
        }
        private void lstLobbies_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnectLobby.Enabled = true;
        }
    }
}
