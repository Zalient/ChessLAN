using ChessParadigm.Pieces;

namespace ChessParadigm
{
    public enum CellColour { White, Black };
    public class Cell : PictureBox
    {
        public Cell(int x, int y, CellColour colour, Board board, Piece piece = null)
        {
            X = x;
            Y = y;

            this.BoardPtr = board;
            this.Piece = piece;

            this.Colour = colour;
            SizeMode = PictureBoxSizeMode.StretchImage;

            this.MouseDoubleClick += new MouseEventHandler(OnMouse_DoubleClick);
            this.MouseClick += new MouseEventHandler(OnMouse_Click);
        }
        public Board BoardPtr { get; } //Board pointer

        public int X { get; private set; }
        public int Y { get; private set; }

        private CellColour _colour;
        public CellColour Colour
        {
            get { return _colour; }
            set
            {
                _colour = value;
                if (_colour == CellColour.White)
                {
                    this.BackColor = ColorTranslator.FromHtml("#de9964"); //Light brown
                }
                else
                {
                    this.BackColor = ColorTranslator.FromHtml("#824426"); //Dark brown
                }
            }
        }
        protected Piece _piece;
        public Piece Piece
        {
            get { return _piece; }
            set
            {
                _piece = value;
                if (_piece != null)
                {
                    Image = _piece.Image;
                }
                else
                {
                    Image = null;
                }
            }
        }
        protected bool _isMoveSelected;
        public bool IsMoveSelected
        {
            get { return _isMoveSelected; }
            set
            {
                _isMoveSelected = value;

                if (value == true)
                {
                    BoardPtr.SelectedCell = this;
                }
            }
        }
        private void OnMouse_DoubleClick(object sender, MouseEventArgs e)
        {
            Cell cell = (Cell)sender;
            Board board = cell.BoardPtr;

            if (cell.Piece != null) //Only select cells with pieces
            {
                foreach (Piece piece in board.Pieces) //Ensure IsKingInCheck remains true after deselecting a piece that can stop the check (this happens because possiblemoves of the piece are altered)
                {
                    piece.PossibleMoves = piece.FindPossibleMoves(piece.Cell); //This also works as a initalisation for the piece moves 
                }

                if (board.IsSelecting == false && cell.Piece != null) //Select piece to move
                {
                    if (board.PlayerTurn == cell.Piece.Colour) //Ensure that player to move can only move their own pieces
                    {
                        cell.IsMoveSelected = true;
                        board.IsSelecting = true;
                        board.Cells[board.SelectedCell.X, board.SelectedCell.Y].BackColor = ColorTranslator.FromHtml("#edc895"); //Highlight cell of piece to move

                        board.UpdateLegalMoves(cell);
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (cell.Piece.IsPossibleMove(cell, board.Cells[i, j]) == true) 
                                {
                                    if (board.Cells[i, j].Piece == null || board.Cells[i, j].Piece.Colour != cell.Piece.Colour) //Check if ally piece occupies one of selected piece's moves
                                    {
                                        board.HighlightMove(cell, i, j);
                                    }
                                }
                            }
                        }
                    }
                }

                else if (cell.BoardPtr.IsSelecting == true && cell.IsMoveSelected == true && cell.Piece != null) //Deselect piece to move
                {
                    cell.IsMoveSelected = false;
                    cell.BoardPtr.IsSelecting = false;
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            board.UnhighlightMove(cell, i, j);
                        }
                    }
                }
            }
        }
        private void OnMouse_Click(object sender, MouseEventArgs e)
        {
            ChessClient chessClient = new ChessClient();
            Cell cell = (Cell)sender;
            Board board = cell.BoardPtr;
            if (board.IsSelecting == true && cell.IsMoveSelected == false)
            {
                Cell pieceCell = board.SelectedCell;
                if (pieceCell.Piece.IsPossibleMove(pieceCell, cell) == true)
                {
                    if (pieceCell != null)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (pieceCell.Piece.IsPossibleMove(pieceCell, board.Cells[i, j]) == true)
                                {
                                    if (cell.Piece == null || cell.Piece.Colour != pieceCell.Piece.Colour)
                                    {
                                        board.Cells[i, j].Colour = board.Cells[i, j].Colour; //Remove colour modifications to cells (like highlighted moves)
                                        board.Cells[pieceCell.X, pieceCell.Y].Colour = board.Cells[pieceCell.X, pieceCell.Y].Colour; //Remove SelectedCell highlight                               
                                    }
                                }
                            }
                        }
                        if (cell.Piece == null || cell.Piece.Colour != pieceCell.Piece.Colour) //If no piece at new location or a capture possible at new location
                        {
                            board.Move_Piece(pieceCell, cell);
                            pieceCell.IsMoveSelected = false;
                            board.IsSelecting = false;

                            if (cell.Piece.GetType() == typeof(Pawn)) //Check for promotion
                            {                             
                                if (cell.X == (cell.Piece.Colour == PieceColour.White ? 0 : 7))
                                {
                                    Piece newPiece = null;
                                    while (newPiece == null)
                                    {
                                        PromotionForm promotionForm = new PromotionForm(cell);
                                        promotionForm.ShowDialog();
                                        newPiece = promotionForm.SelectedPiece;
                                    }
                                    board.Remove_Piece(cell.Piece, cell.X, cell.Y); //Capture own piece first
                                    board.Add_Piece(newPiece, cell.X, cell.Y, 0);
                                    cell.Piece.PossibleMoves = newPiece.FindPossibleMoves(cell);
                                }
                            }

                            for (int k = 0; k < board.Pieces.Count; k++)
                            {
                                Piece piece = board.Pieces[k];
                                if (piece.Colour != board.PlayerTurn)
                                {
                                    piece.PossibleMoves = piece.FindPossibleMoves(piece.Cell); 
                                }
                            }
                            var king = board.Pieces.FirstOrDefault(x => x.Colour == board.PlayerTurn && x.GetType() == typeof(King));
                            if (board.IsKingInCheck(cell) == false)
                            {
                                board.Cells[king.Cell.X, king.Cell.Y].Colour = board.Cells[king.Cell.X, king.Cell.Y].Colour;
                            }
                            if (board.PlayerTurn == PieceColour.White)
                            {
                                board.PlayerTurn = PieceColour.Black; //Black's turn after white
                            }
                            else
                            {
                                board.PlayerTurn = PieceColour.White; //White's turn after black
                            }
                            for (int k = 0; k < board.Pieces.Count; k++) 
                            {
                                Piece piece = board.Pieces[k];
                                if (piece.Colour == board.PlayerTurn)
                                {
                                    board.UpdateLegalMoves(piece.Cell);
                                }
                            }
                            for (int k = 0; k < board.Pieces.Count; k++) 
                            {
                                Piece piece = board.Pieces[k];
                                if (piece.Colour != board.PlayerTurn) //Looks at enemy pieces
                                {
                                    piece.PossibleMoves = piece.FindPossibleMoves(piece.Cell);
                                }
                            }
                            int moveCount = 0;
                            foreach (Piece piece in board.Pieces)
                            {
                                if (piece.Colour == board.PlayerTurn) //Get ally pieces
                                {
                                    for (int i = 0; i < 8; i++)
                                    {
                                        for (int j = 0; j < 8; j++)
                                        {
                                            if (piece.IsPossibleMove(piece.Cell, board.Cells[i, j]))
                                            {
                                                if (board.Cells[i, j].Piece == null || board.Cells[i, j].Piece.Colour != piece.Colour) //Get number of moves of own team
                                                {
                                                    moveCount++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            king = board.Pieces.FirstOrDefault(x => x.Colour == board.PlayerTurn && x.GetType() == typeof(King)); //Detect checkmate/stalemate
                            if (board.IsKingInCheck(cell)) //If own king in check
                            {
                                board.Cells[king.Cell.X, king.Cell.Y].BackColor = ColorTranslator.FromHtml("#632d91"); //Highlight king location in purple when in check
                                if (moveCount == 0)
                                {
                                    MessageBox.Show(board.PlayerTurn + " loses");
                                }
                            }
                            else
                            {
                                if (moveCount == 0)
                                {
                                    MessageBox.Show("Stalemate");
                                }
                            }
                            KeyValuePair<int, int> previousMove = new KeyValuePair<int, int>(pieceCell.X, pieceCell.Y);
                            KeyValuePair<int, int> newMove = new KeyValuePair<int, int>(cell.X, cell.Y);
                            chessClient.SendMsgToServer($"Move {Board.Instance.CoordinatesToNotation(previousMove)}&{Board.Instance.CoordinatesToNotation(newMove)}");
                        }
                    }
                }
            }
        }
    }
}
