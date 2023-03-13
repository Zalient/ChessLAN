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
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1000, 800);
            _ = new Board(this);
        }

        private void tsMultiplayer_Click(object sender, EventArgs e)
        {
            MultiplayerForm multiplayerForm = new MultiplayerForm();
            multiplayerForm.Show();
        }
    }
}
