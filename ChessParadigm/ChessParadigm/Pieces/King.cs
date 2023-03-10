namespace ChessParadigm.Pieces
{
    public class King : Piece
    {
        public King(Cell cell, PieceColour colour) : base(cell, colour)
        {
            if (colour == PieceColour.White)
            {
                this.Image = ImageCollection.WHITE_KING_IMG;
            }
            else
            {
                this.Image = ImageCollection.BLACK_KING_IMG;
            }
        }
        public override List<KeyValuePair<int, int>> FindPossibleMoves(Cell pieceCell)
        {
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            Board board = pieceCell.BoardPtr;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.Cells[i, j].X != pieceCell.X || board.Cells[i, j].Y != pieceCell.Y)
                    {
                        if (board.Cells[i, j].X == pieceCell.X - 1 && (board.Cells[i, j].Y == pieceCell.Y - 1 || board.Cells[i, j].Y == pieceCell.Y || board.Cells[i, j].Y == pieceCell.Y + 1))
                        {
                            list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X, board.Cells[i, j].Y));
                        }
                        if (board.Cells[i, j].X == pieceCell.X && (board.Cells[i, j].Y == pieceCell.Y - 1 || board.Cells[i, j].Y == pieceCell.Y || board.Cells[i, j].Y == pieceCell.Y + 1))
                        {
                            list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X, board.Cells[i, j].Y));
                        }
                        if (board.Cells[i, j].X == pieceCell.X + 1 && (board.Cells[i, j].Y == pieceCell.Y - 1 || board.Cells[i, j].Y == pieceCell.Y || board.Cells[i, j].Y == pieceCell.Y + 1))
                        {
                            list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X, board.Cells[i, j].Y));
                        }
                    }
                }
            }
            return list;
        }
    }
}
