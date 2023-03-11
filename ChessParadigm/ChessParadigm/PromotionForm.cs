using Chess.Pieces;

namespace Chess
{
    public partial class PromotionForm : Form
    {
        public PromotionForm(Cell cell)
        {
            this.Colour = cell.Piece.Colour;
            this.Cell = cell;
            Board board = cell.BoardPtr;
            InitializeComponent();

            if (board.PlayerTurn == PieceColour.White)
            {
                pbQueen.Image = ImageCollection.WHITE_QUEEN_IMG;
                pbRook.Image = ImageCollection.WHITE_ROOK_IMG;
                pbBishop.Image = ImageCollection.WHITE_BISHOP_IMG;
                pbKnight.Image = ImageCollection.WHITE_KNIGHT_IMG;
            }
            else
            {
                pbQueen.Image = ImageCollection.BLACK_QUEEN_IMG;
                pbRook.Image = ImageCollection.BLACK_ROOK_IMG;
                pbBishop.Image = ImageCollection.BLACK_BISHOP_IMG;
                pbKnight.Image = ImageCollection.BLACK_KNIGHT_IMG;
            }
        }
        private PieceColour Colour { get; set; }
        private Cell Cell { get; set; }
        public Piece SelectedPiece { get; private set; }
        private void pbQueen_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Queen(this.Cell, this.Colour);
            Close();
        }
        private void pbRook_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Rook(this.Cell, this.Colour);
            Close();
        }
        private void pbBishop_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Bishop(this.Cell, this.Colour);
            Close();
        }
        private void pbKnight_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Knight(this.Cell, this.Colour);
            Close();
        }
    }
}
