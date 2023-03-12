using Chess.Pieces;

namespace Chess
{
    public enum CellColour { White, Black };
    public class Cell : PictureBox
    {
        private ChessClient chessClient = Board.Instance.ChessClient;
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
            
            if (chessClient.Colour != board.PlayerTurn) //Ensures client colour matches player turn
            {
                return;
            }
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
            //Maybe something like Board.Move() here so that i can call move in client as well which would update the current player turn
            //Reason why second device refuses to play moves is because a move has not been sent so it is eternally waiting for its move
            //I.e. find out why move is not being played after being sent!!!!
            Cell targetCell = (Cell)sender;
            Board board = targetCell.BoardPtr;
            Cell pieceCell = board.SelectedCell;
            Board.Instance.Move(pieceCell, targetCell);
            KeyValuePair<int, int> previousMove = new KeyValuePair<int, int>(pieceCell.X, pieceCell.Y);
            KeyValuePair<int, int> newMove = new KeyValuePair<int, int>(targetCell.X, targetCell.Y);
            chessClient.SendMsgToServer($"Move {Helper.CoordinatesToNotation(previousMove)}&{Helper.CoordinatesToNotation(newMove)}"); //Send move
        }
    }
}
