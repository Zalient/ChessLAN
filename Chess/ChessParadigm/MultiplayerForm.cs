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
        public ChessClient client;
        public MultiplayerForm()
        {
            InitializeComponent();
        }
        public void SetConnectionStatus(bool connected)
        {
            if (connected)
            {
                Status.Text = "Connected";
                Status.ForeColor = Color.Green;
                CreateBtn.Enabled = true;
                LobbyNameBox.Enabled = true;
            }
            else
            {
                CreateBtn.Enabled = false;
                LobbyNameBox.Enabled = false;
                Status.Text = "Offline";
                Status.ForeColor = Color.Red;
            }
        }
        private async void RefreshLobbyList()
        {
            LobbyList.Items.Clear();
            List<string> lobby = await client.GetLobbies();
            LobbyList.Items.AddRange(lobby.ToArray());
        }
        private void ConnectLobbyBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            client.ConnectLobby(LobbyList.Items[LobbyList.SelectedIndex].ToString());
        }
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            client.CreateLobby(LobbyNameBox.Text);
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Waiting...");
        }
        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshLobbyList();
        }
        private async void ConnectServerBtn_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected)
                return;
            client = new ChessClient();
            if (await client.Connect(HostIP.Text))
            {
                SetConnectionStatus(true);
                RefreshLobbyList();
            }
            else
            {
                SetConnectionStatus(false);
            }
        }
        private void LobbyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectLobbyBtn.Enabled = true;
        }
    }
}
