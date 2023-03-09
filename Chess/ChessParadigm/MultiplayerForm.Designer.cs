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
            this.LobbyList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HostIP = new System.Windows.Forms.TextBox();
            this.ConnectServerBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LobbyNameBox = new System.Windows.Forms.TextBox();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.ConnectLobbyBtn = new System.Windows.Forms.Button();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LobbyList
            // 
            this.LobbyList.FormattingEnabled = true;
            this.LobbyList.ItemHeight = 25;
            this.LobbyList.Location = new System.Drawing.Point(26, 12);
            this.LobbyList.Name = "LobbyList";
            this.LobbyList.Size = new System.Drawing.Size(438, 429);
            this.LobbyList.TabIndex = 0;
            this.LobbyList.SelectedIndexChanged += new System.EventHandler(this.LobbyList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host IP:";
            // 
            // HostIP
            // 
            this.HostIP.Location = new System.Drawing.Point(516, 149);
            this.HostIP.Name = "HostIP";
            this.HostIP.Size = new System.Drawing.Size(150, 31);
            this.HostIP.TabIndex = 2;
            // 
            // ConnectServerBtn
            // 
            this.ConnectServerBtn.Location = new System.Drawing.Point(687, 149);
            this.ConnectServerBtn.Name = "ConnectServerBtn";
            this.ConnectServerBtn.Size = new System.Drawing.Size(85, 31);
            this.ConnectServerBtn.TabIndex = 3;
            this.ConnectServerBtn.Text = "Connect";
            this.ConnectServerBtn.UseVisualStyleBackColor = true;
            this.ConnectServerBtn.Click += new System.EventHandler(this.ConnectServerBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status:";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.ForeColor = System.Drawing.Color.Red;
            this.Status.Location = new System.Drawing.Point(577, 72);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(65, 25);
            this.Status.TabIndex = 5;
            this.Status.Text = "Offline";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Create Lobby:";
            // 
            // LobbyNameBox
            // 
            this.LobbyNameBox.Enabled = false;
            this.LobbyNameBox.Location = new System.Drawing.Point(516, 387);
            this.LobbyNameBox.Name = "LobbyNameBox";
            this.LobbyNameBox.Size = new System.Drawing.Size(150, 31);
            this.LobbyNameBox.TabIndex = 7;
            // 
            // CreateBtn
            // 
            this.CreateBtn.Enabled = false;
            this.CreateBtn.Location = new System.Drawing.Point(687, 387);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(85, 31);
            this.CreateBtn.TabIndex = 8;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // ConnectLobbyBtn
            // 
            this.ConnectLobbyBtn.Enabled = false;
            this.ConnectLobbyBtn.Location = new System.Drawing.Point(516, 207);
            this.ConnectLobbyBtn.Name = "ConnectLobbyBtn";
            this.ConnectLobbyBtn.Size = new System.Drawing.Size(163, 31);
            this.ConnectLobbyBtn.TabIndex = 9;
            this.ConnectLobbyBtn.Text = "Connect to Lobby";
            this.ConnectLobbyBtn.UseVisualStyleBackColor = true;
            this.ConnectLobbyBtn.Click += new System.EventHandler(this.ConnectLobbyBtn_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Location = new System.Drawing.Point(687, 207);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(80, 31);
            this.RefreshBtn.TabIndex = 10;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // MultiplayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.ConnectLobbyBtn);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.LobbyNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConnectServerBtn);
            this.Controls.Add(this.HostIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LobbyList);
            this.Name = "MultiplayerForm";
            this.Text = "MultiplayerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox LobbyList;
        private Label label1;
        private TextBox HostIP;
        private Button ConnectServerBtn;
        private Label label2;
        private Label Status;
        private Label label3;
        private TextBox LobbyNameBox;
        private Button CreateBtn;
        private Button ConnectLobbyBtn;
        private Button RefreshBtn;
    }
}