using ChessParadigm.Pieces;

namespace ChessParadigm
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
                picBoxQueen.Image = ImageCollection.WHITE_QUEEN_IMG;
                picBoxRook.Image = ImageCollection.WHITE_ROOK_IMG;
                picBoxBishop.Image = ImageCollection.WHITE_BISHOP_IMG;
                picBoxKnight.Image = ImageCollection.WHITE_KNIGHT_IMG;
            }
            else
            {
                picBoxQueen.Image = ImageCollection.BLACK_QUEEN_IMG;
                picBoxRook.Image = ImageCollection.BLACK_ROOK_IMG;
                picBoxBishop.Image = ImageCollection.BLACK_BISHOP_IMG;
                picBoxKnight.Image = ImageCollection.BLACK_KNIGHT_IMG;
            }
        }
        private PieceColour Colour { get; set; }
        private Cell Cell { get; set; }
        public Piece SelectedPiece { get; private set; }
        private void picBoxQueen_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Queen(this.Cell, this.Colour);
            Close();
        }
        private void picBoxRook_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Rook(this.Cell, this.Colour);
            Close();
        }
        private void picBoxBishop_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Bishop(this.Cell, this.Colour);
            Close();
        }
        private void picBoxKnight_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Knight(this.Cell, this.Colour);
            Close();
        }
    }
}
