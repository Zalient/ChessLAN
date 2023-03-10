namespace Chess
{
    class GameForm : Form
    {
        public GameForm()
        {
            this.Text = "Chess";
            this.Size = new System.Drawing.Size(670, 600);
            _ = new Board(this);
        }
    }
}
