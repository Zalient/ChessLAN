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
                QueenPB.Image = ImageCollection.WHITE_QUEEN_IMG;
                RookPB.Image = ImageCollection.WHITE_ROOK_IMG;
                BishopPB.Image = ImageCollection.WHITE_BISHOP_IMG;
                KnightPB.Image = ImageCollection.WHITE_KNIGHT_IMG;
            }
            else
            {
                QueenPB.Image = ImageCollection.BLACK_QUEEN_IMG;
                RookPB.Image = ImageCollection.BLACK_ROOK_IMG;
                BishopPB.Image = ImageCollection.BLACK_BISHOP_IMG;
                KnightPB.Image = ImageCollection.BLACK_KNIGHT_IMG;
            }
        }
        private PieceColour Colour { get; set; }
        private Cell Cell { get; set; }
        public Piece SelectedPiece { get; private set; }
        private void QueenPB_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Queen(this.Cell, this.Colour);
            Close();
        }
        private void RookPB_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Rook(this.Cell, this.Colour);
            Close();
        }
        private void BishopPB_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Bishop(this.Cell, this.Colour);
            Close();
        }
        private void KnightPB_Click(object sender, EventArgs e)
        {
            SelectedPiece = new Knight(this.Cell, this.Colour);
            Close();
        }
    }
}
