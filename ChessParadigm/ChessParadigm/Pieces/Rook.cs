namespace ChessParadigm.Pieces
{
    public class Rook : Piece
    {
        public Rook(Cell cell, PieceColour colour) : base(cell, colour)
        {
            if (colour == PieceColour.White)
            {
                this.Image = ImageCollection.WHITE_ROOK_IMG;
            }
            else
            {
                this.Image = ImageCollection.BLACK_ROOK_IMG;
            }
        }
        public override List<KeyValuePair<int, int>> FindPossibleMoves(Cell pieceCell)
        {
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            Board board = pieceCell.BoardPtr;
            for (int i = pieceCell.X + 1; i < 8; i++) //Down
            {
                if (board.Cells[i, pieceCell.Y].Piece == null)
                {
                    list.Add(new KeyValuePair<int, int>(i, pieceCell.Y));
                }
                else if (board.Cells[i, pieceCell.Y].Piece.Colour == pieceCell.Piece.Colour)
                {
                    list.Add(new KeyValuePair<int, int>(i, pieceCell.Y));
                    break;
                }
                else if (board.Cells[i, pieceCell.Y].Piece.Colour != pieceCell.Piece.Colour)
                {
                    if (board.Cells[i, pieceCell.Y].Piece.GetType() != typeof(King))
                    {
                        list.Add(new KeyValuePair<int, int>(i, pieceCell.Y));
                        break;
                    }
                    else
                    {
                        list.Add(new KeyValuePair<int, int>(i, pieceCell.Y));
                    }
                }
            }
            for (int i = pieceCell.X - 1; i >= 0; i--) //Up
            {
                if (board.Cells[i, pieceCell.Y].Piece == null)
                {
                    list.Add(new KeyValuePair<int, int>(i, pieceCell.Y));
                }
                else if (board.Cells[i, pieceCell.Y].Piece.Colour == pieceCell.Piece.Colour)
                {
                    list.Add(new KeyValuePair<int, int>(i, pieceCell.Y));
                    break;
                }
                else if (board.Cells[i, pieceCell.Y].Piece.Colour != pieceCell.Piece.Colour)
                {
                    if (board.Cells[i, pieceCell.Y].Piece.GetType() != typeof(King))
                    {
                        list.Add(new KeyValuePair<int, int>(i, pieceCell.Y));
                        break;
                    }
                    else
                    {
                        list.Add(new KeyValuePair<int, int>(i, pieceCell.Y));
                    }
                }
            }
            for (int j = pieceCell.Y + 1; j < 8; j++) //Right
            {
                if (board.Cells[pieceCell.X, j].Piece == null)
                {
                    list.Add(new KeyValuePair<int, int>(pieceCell.X, j));
                }
                else if (board.Cells[pieceCell.X, j].Piece.Colour == pieceCell.Piece.Colour)
                {
                    list.Add(new KeyValuePair<int, int>(pieceCell.X, j));
                    break;
                }
                else if (board.Cells[pieceCell.X, j].Piece.Colour != pieceCell.Piece.Colour)
                {
                    if (board.Cells[pieceCell.X, j].Piece.GetType() != typeof(King))
                    {
                        list.Add(new KeyValuePair<int, int>(pieceCell.X, j));
                        break;
                    }
                    else
                    {
                        list.Add(new KeyValuePair<int, int>(pieceCell.X, j));
                    }
                }
            }
            for (int j = pieceCell.Y - 1; j >= 0; j--) //Left
            {
                if (board.Cells[pieceCell.X, j].Piece == null)
                {
                    list.Add(new KeyValuePair<int, int>(pieceCell.X, j));
                }
                else if (board.Cells[pieceCell.X, j].Piece.Colour == pieceCell.Piece.Colour)
                {
                    list.Add(new KeyValuePair<int, int>(pieceCell.X, j));
                    break;
                }
                else if (board.Cells[pieceCell.X, j].Piece.Colour != pieceCell.Piece.Colour)
                {
                    if (board.Cells[pieceCell.X, j].Piece.GetType() != typeof(King))
                    {
                        list.Add(new KeyValuePair<int, int>(pieceCell.X, j));
                        break;
                    }
                    else
                    {
                        list.Add(new KeyValuePair<int, int>(pieceCell.X, j));
                    }
                }
            }
            return list;
        }
    }
}
