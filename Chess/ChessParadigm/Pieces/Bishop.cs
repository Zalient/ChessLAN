namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Cell cell, PieceColour colour) : base(cell, colour)
        {
            if (colour == PieceColour.White)
            {
                this.Image = ImageCollection.WHITE_BISHOP_IMG;
            }
            else
            {
                this.Image = ImageCollection.BLACK_BISHOP_IMG;
            }
        }
        public override List<KeyValuePair<int, int>> FindPossibleMoves(Cell pieceCell)
        {
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            Board board = pieceCell.BoardPtr;
            int xDist;
            int yDist;
        Diagonal1: //N-W
            for (int i = pieceCell.X - 1; i >= 0; i--)
            {
                for (int j = pieceCell.Y - 1; j >= 0; j--)
                {
                    xDist = Math.Abs(i - pieceCell.X);
                    yDist = Math.Abs(j - pieceCell.Y);
                    if (xDist == yDist)
                    {
                        if (board.Cells[i, j].Piece == null)
                        {
                            list.Add(new KeyValuePair<int, int>(i, j));
                        }
                        else if (board.Cells[i, j].Piece.Colour == pieceCell.Piece.Colour)
                        {
                            list.Add(new KeyValuePair<int, int>(i, j));
                            goto Diagonal2;
                        }
                        else if (board.Cells[i, j].Piece.Colour != pieceCell.Piece.Colour)
                        {
                            if (board.Cells[i, j].Piece.GetType() != typeof(King))
                            {
                                list.Add(new KeyValuePair<int, int>(i, j));
                                goto Diagonal2; //Direction is blocked so first loop stops
                            }
                            else
                            {
                                list.Add(new KeyValuePair<int, int>(i, j));
                            }
                        }
                    }
                }
            }
        Diagonal2: //N-E
            for (int i = pieceCell.X - 1; i >= 0; i--)
            {
                for (int j = pieceCell.Y + 1; j < 8; j++)
                {
                    xDist = Math.Abs(i - pieceCell.X);
                    yDist = Math.Abs(j - pieceCell.Y);
                    if (xDist == yDist)
                    {
                        if (board.Cells[i, j].Piece == null)
                        {
                            list.Add(new KeyValuePair<int, int>(i, j));
                        }
                        else if (board.Cells[i, j].Piece.Colour == pieceCell.Piece.Colour)
                        {
                            list.Add(new KeyValuePair<int, int>(i, j));
                            goto Diagonal3;
                        }
                        else if (board.Cells[i, j].Piece.Colour != pieceCell.Piece.Colour)
                        {
                            if (board.Cells[i, j].Piece.GetType() != typeof(King))
                            {
                                list.Add(new KeyValuePair<int, int>(i, j));
                                goto Diagonal3;
                            }
                            else
                            {
                                list.Add(new KeyValuePair<int, int>(i, j));
                            }
                        }
                    }
                }
            }
        Diagonal3: //S-W
            for (int i = pieceCell.X + 1; i < 8; i++)
            {
                for (int j = pieceCell.Y - 1; j >= 0; j--)
                {
                    xDist = Math.Abs(i - pieceCell.X);
                    yDist = Math.Abs(j - pieceCell.Y);
                    if (xDist == yDist)
                    {
                        if (board.Cells[i, j].Piece == null)
                        {
                            list.Add(new KeyValuePair<int, int>(i, j));
                        }
                        else if (board.Cells[i, j].Piece.Colour == pieceCell.Piece.Colour)
                        {
                            list.Add(new KeyValuePair<int, int>(i, j));
                            goto Diagonal4;
                        }
                        else if (board.Cells[i, j].Piece.Colour != pieceCell.Piece.Colour)
                        {
                            if (board.Cells[i, j].Piece.GetType() != typeof(King))
                            {
                                list.Add(new KeyValuePair<int, int>(i, j));
                                goto Diagonal4;
                            }
                            else
                            {
                                list.Add(new KeyValuePair<int, int>(i, j));
                            }
                        }
                    }
                }
            }
        Diagonal4: //S-E
            for (int i = pieceCell.X + 1; i < 8; i++)
            {
                for (int j = pieceCell.Y + 1; j < 8; j++)
                {
                    xDist = Math.Abs(i - pieceCell.X);
                    yDist = Math.Abs(j - pieceCell.Y);
                    if (xDist == yDist)
                    {
                        if (board.Cells[i, j].Piece == null)
                        {
                            list.Add(new KeyValuePair<int, int>(i, j));
                        }
                        else if (board.Cells[i, j].Piece.Colour == pieceCell.Piece.Colour)
                        {
                            list.Add(new KeyValuePair<int, int>(i, j));
                            goto Finish;
                        }
                        else if (board.Cells[i, j].Piece.Colour != pieceCell.Piece.Colour)
                        {
                            if (board.Cells[i, j].Piece.GetType() != typeof(King))
                            {
                                list.Add(new KeyValuePair<int, int>(i, j));
                                goto Finish;
                            }
                            else
                            {
                                list.Add(new KeyValuePair<int, int>(i, j));
                            }
                        }
                    }
                }
            }
        Finish:
            return list;
        }
    }
}
