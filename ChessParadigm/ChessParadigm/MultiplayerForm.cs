using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessParadigm
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
            listBoxLobbies.Items.Clear();
            List<string> lobby = await client.GetLobbies();
            listBoxLobbies.Items.AddRange(lobby.ToArray());
        }
        private void btnConnectLobby_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Yes;
            client.ConnectLobby(listBoxLobbies.Items[listBoxLobbies.SelectedIndex].ToString());
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            client.CreateLobby(txtLobbyName.Text);
            //this.DialogResult = DialogResult.OK;
            MessageBox.Show("Waiting...");
        }
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLobbyList();
        }
        private async void btnConnectServer_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected) 
            {
                return;
            }
            client = new ChessClient(); //New client if no client connected already
            if (await client.Connect(txtHostIP.Text)) //If client has connected
            {
                SetConnectionStatus(true);
                RefreshLobbyList();
            }
            else
            {
                SetConnectionStatus(false);
            }
        }
        private void listBoxLobbies_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnectLobby.Enabled = true;
        }
    }
}
