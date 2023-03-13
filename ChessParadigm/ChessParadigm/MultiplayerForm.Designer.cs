namespace Chess
{
    partial class MultiplayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstLobbies = new ListBox();
            label1 = new Label();
            txtHostIP = new TextBox();
            btnConnectServer = new Button();
            label2 = new Label();
            lblStatus = new Label();
            label3 = new Label();
            txtLobbyName = new TextBox();
            btnCreate = new Button();
            btnConnectLobby = new Button();
            btnRefresh = new Button();
            lblWaiting = new Label();
            SuspendLayout();
            // 
            // lstLobbies
            // 
            lstLobbies.FormattingEnabled = true;
            lstLobbies.ItemHeight = 25;
            lstLobbies.Location = new Point(26, 12);
            lstLobbies.Name = "lstLobbies";
            lstLobbies.Size = new Size(438, 429);
            lstLobbies.TabIndex = 0;
            lstLobbies.SelectedIndexChanged += lstLobbies_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(516, 121);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 1;
            label1.Text = "Host IP:";
            // 
            // txtHostIP
            // 
            txtHostIP.Location = new Point(516, 149);
            txtHostIP.Name = "txtHostIP";
            txtHostIP.Size = new Size(150, 31);
            txtHostIP.TabIndex = 2;
            // 
            // btnConnectServer
            // 
            btnConnectServer.Location = new Point(687, 149);
            btnConnectServer.Name = "btnConnectServer";
            btnConnectServer.Size = new Size(85, 31);
            btnConnectServer.TabIndex = 3;
            btnConnectServer.Text = "Connect";
            btnConnectServer.UseVisualStyleBackColor = true;
            btnConnectServer.Click += btnConnectServer_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(516, 72);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 4;
            label2.Text = "Status:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(577, 72);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(65, 25);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Offline";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(516, 308);
            label3.Name = "label3";
            label3.Size = new Size(121, 25);
            label3.TabIndex = 6;
            label3.Text = "Create Lobby:";
            // 
            // txtLobbyName
            // 
            txtLobbyName.Enabled = false;
            txtLobbyName.Location = new Point(516, 336);
            txtLobbyName.Name = "txtLobbyName";
            txtLobbyName.Size = new Size(150, 31);
            txtLobbyName.TabIndex = 7;
            // 
            // btnCreate
            // 
            btnCreate.Enabled = false;
            btnCreate.Location = new Point(687, 336);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(85, 31);
            btnCreate.TabIndex = 8;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnConnectLobby
            // 
            btnConnectLobby.Enabled = false;
            btnConnectLobby.Location = new Point(516, 207);
            btnConnectLobby.Name = "btnConnectLobby";
            btnConnectLobby.Size = new Size(163, 31);
            btnConnectLobby.TabIndex = 9;
            btnConnectLobby.Text = "Connect to Lobby";
            btnConnectLobby.UseVisualStyleBackColor = true;
            btnConnectLobby.Click += btnConnectLobby_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(687, 207);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(80, 31);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblWaiting
            // 
            lblWaiting.AutoSize = true;
            lblWaiting.Location = new Point(516, 392);
            lblWaiting.Name = "lblWaiting";
            lblWaiting.Size = new Size(0, 25);
            lblWaiting.TabIndex = 11;
            // 
            // MultiplayerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWaiting);
            Controls.Add(btnRefresh);
            Controls.Add(btnConnectLobby);
            Controls.Add(btnCreate);
            Controls.Add(txtLobbyName);
            Controls.Add(label3);
            Controls.Add(lblStatus);
            Controls.Add(label2);
            Controls.Add(btnConnectServer);
            Controls.Add(txtHostIP);
            Controls.Add(label1);
            Controls.Add(lstLobbies);
            Name = "MultiplayerForm";
            Text = "MultiplayerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstLobbies;
        private Label label1;
        private TextBox txtHostIP;
        private Button btnConnectServer;
        private Label label2;
        private Label lblStatus;
        private Label label3;
        private TextBox txtLobbyName;
        private Button btnCreate;
        private Button btnConnectLobby;
        private Button btnRefresh;
        private Label lblWaiting;
    }
}