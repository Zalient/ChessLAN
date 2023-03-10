namespace ChessParadigm.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Cell cell, PieceColour colour) : base(cell, colour)
        {
            if (colour == PieceColour.White)
            {
                this.Image = ImageCollection.WHITE_PAWN_IMG;
            }
            else
            {
                this.Image = ImageCollection.BLACK_PAWN_IMG;
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
                    if (board.Cells[i, j].Piece == null) //If no piece on a cell
                    {
                        if (Colour == PieceColour.Black) //If pawn is black
                        {
                            if (board.Cells[i, j].X == pieceCell.X + 1 && board.Cells[i, j].Y == pieceCell.Y) //Move down by 1
                            {
                                list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X, board.Cells[i, j].Y));
                            }
                            if (board.Cells[i, j].X == pieceCell.X + 2 && board.Cells[i, j].Y == pieceCell.Y && pieceCell.X == 1 && board.Cells[i - 1, j].Piece == null) //Move down by 2
                            {
                                list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X, board.Cells[i, j].Y));
                            }
                        }
                        else //If pawn is white 
                        {
                            if (board.Cells[i, j].X == pieceCell.X - 1 && board.Cells[i, j].Y == pieceCell.Y) //Move up by 1
                            {
                                list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X, board.Cells[i, j].Y));
                            }
                            if (board.Cells[i, j].X == pieceCell.X - 2 && board.Cells[i, j].Y == pieceCell.Y && pieceCell.X == 6 && board.Cells[i + 1, j].Piece == null) //Move up by 2
                            { 
                                list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X, board.Cells[i, j].Y));
                            }
                        }
                    }
                    else //If piece detected (not just enemy since I want pawns to defend ally pieces)
                    {
                        if (Colour == PieceColour.Black) //If pawn is black
                        {
                            if (board.Cells[i, j].X == pieceCell.X + 1 && (board.Cells[i, j].Y == pieceCell.Y - 1 || board.Cells[i, j].Y == pieceCell.Y + 1)) //Capture left or right
                            {
                                list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X, board.Cells[i, j].Y));
                            }
                            //if (board.Cells[i, j].X == pieceCell.X && (board.Cells[i, j].Y == pieceCell.Y - 1 || board.Cells[i, j].Y == pieceCell.Y + 1) && board.Cells[i, j].Piece.GetType() == typeof(Pawn)) //En passant
                            //{
                            //    list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X + 1, board.Cells[i, j].Y));
                            //}
                        }
                        else //If pawn is white
                        {
                            if (board.Cells[i, j].X == pieceCell.X - 1 && (board.Cells[i, j].Y == pieceCell.Y - 1 || board.Cells[i, j].Y == pieceCell.Y + 1)) //Capture left or right
                            {
                                list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X, board.Cells[i, j].Y));
                            }
                            //if (board.Cells[i, j].X == pieceCell.X && (board.Cells[i, j].Y == pieceCell.Y - 1 || board.Cells[i, j].Y == pieceCell.Y + 1) && board.Cells[i, j].Piece.GetType() == typeof(Pawn)) //En passant
                            //{
                            //    list.Add(new KeyValuePair<int, int>(board.Cells[i, j].X - 1, board.Cells[i, j].Y));
                            //}
                        }
                    }
                }
            }
            return list;
        }
    }
}
