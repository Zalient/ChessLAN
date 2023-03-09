namespace Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(Cell cell, PieceColour colour) : base(cell, colour)
        {
            if (colour == PieceColour.White)
            {
                this.Image = ImageCollection.WHITE_QUEEN_IMG;
            }
            else
            {
                this.Image = ImageCollection.BLACK_QUEEN_IMG;
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
                            goto Orthogonal;
                        }
                        else if (board.Cells[i, j].Piece.Colour != pieceCell.Piece.Colour)
                        {
                            if (board.Cells[i, j].Piece.GetType() != typeof(King))
                            {
                                list.Add(new KeyValuePair<int, int>(i, j));
                                goto Orthogonal;
                            }
                            else
                            {
                                list.Add(new KeyValuePair<int, int>(i, j));
                            }
                        }
                    }
                }
            }
        Orthogonal:
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
