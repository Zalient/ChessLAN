using Chess.Pieces;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Xml;

namespace Chess
{
    public class Board
    {
        public static Board Instance;
        protected int _cellHeight = 70;
        protected int _cellWidth = 70;
        protected Cell[,] _cells = new Cell[8, 8];
        Form _gameForm;

        public Board(Form GameForm)
        {
            if (Instance == null)
            {
                Instance = this;
            }
            this._gameForm = GameForm;
            InitBoard();
        }
        public ChessClient ChessClient { get; set; }
        public Cell SelectedCell { get; set; }
        public bool IsSelecting { get; set; }
        private PieceColour _playerTurn = PieceColour.White;
        public PieceColour PlayerTurn
        {
            get { return _playerTurn; }
            set { _playerTurn = value; }
        }
        public List<Piece> Pieces { get; set; }
        public Cell[,] Cells => _cells; //Read-only
        public Piece this[int i, int j] //Add defined piece to board itself
        {
            get { return _cells[i, j].Piece; } //Access piece at cell location 
            set { _cells[i, j].Piece = value; } //Change piece to value (value forces set property to receive an argument e.g. a Rook)
        }
        public void InitBoard()
        {
            this.Pieces = new List<Piece>();
            int left = 70;
            int top = 50;
            CellColour colour = CellColour.White;

            for (int i = 0; i < 8; i++)
            {
                left = 70;
                for (int j = 0; j < 8; j++)
                {
                    Cell cell = new Cell(i, j, colour, this);
                    cell.Size = new Size(_cellWidth, _cellHeight);
                    cell.Left = left;
                    cell.Top = top;

                    left += _cellWidth; //Move right by 1 column and generate next 8 rows.
                    if (colour == CellColour.White) //Creating vertical component of checkered pattern (columns of alternating colour)
                    {
                        colour = CellColour.Black;
                    }
                    else
                    {
                        colour = CellColour.White;
                    }

                    _cells[i, j] = cell;
                    _gameForm.Controls.Add(_cells[i, j]); //Add cells to form
                }
                top += _cellHeight; //Move down by 1 row and generate next 8 columns
                if (colour == CellColour.White) //Creating horizontal component of checkered pattern (rows of alternating colour)
                {
                    colour = CellColour.Black;
                }
                else
                {
                    colour = CellColour.White;
                }
            }
        }
        public void InitPieces()
        {
            //Add pieces to board

            ////Stalemate check
            //Add_Piece(new King(_cells[7, 7], PieceColour.White), 7, 7, 0);
            //Add_Piece(new King(_cells[0, 0], PieceColour.Black), 0, 0, 0);
            //Add_Piece(new Queen(_cells[3, 2], PieceColour.White), 3, 2, 0);

            //King
            Add_Piece(new King(_cells[7, 4], PieceColour.White), 7, 4, 0);
            Add_Piece(new King(_cells[0, 4], PieceColour.Black), 0, 4, 0);
            //Queen
            Add_Piece(new Queen(_cells[7, 3], PieceColour.White), 7, 3, 0);
            Add_Piece(new Queen(_cells[0, 3], PieceColour.Black), 0, 3, 0);
            //Rook
            Add_Piece(new Rook(_cells[7, 0], PieceColour.White), 7, 0, 0);
            Add_Piece(new Rook(_cells[7, 7], PieceColour.White), 7, 7, 0);
            Add_Piece(new Rook(_cells[0, 0], PieceColour.Black), 0, 0, 0);
            Add_Piece(new Rook(_cells[0, 7], PieceColour.Black), 0, 7, 0);
            //Bishop
            Add_Piece(new Bishop(_cells[7, 2], PieceColour.White), 7, 2, 0);
            Add_Piece(new Bishop(_cells[7, 5], PieceColour.White), 7, 5, 0);
            Add_Piece(new Bishop(_cells[0, 2], PieceColour.Black), 0, 2, 0);
            Add_Piece(new Bishop(_cells[0, 5], PieceColour.Black), 0, 5, 0);
            //Knight
            Add_Piece(new Knight(_cells[7, 1], PieceColour.White), 7, 1, 0);
            Add_Piece(new Knight(_cells[7, 6], PieceColour.White), 7, 6, 0);
            Add_Piece(new Knight(_cells[0, 1], PieceColour.Black), 0, 1, 0);
            Add_Piece(new Knight(_cells[0, 6], PieceColour.Black), 0, 6, 0);
            //Pawn
            for (int i = 0; i < 8; i++)
            {
                Add_Piece(new Pawn(_cells[6, i], PieceColour.White), 6, i, 0);
            }
            for (int i = 0; i < 8; i++)
            {
                Add_Piece(new Pawn(_cells[1, i], PieceColour.Black), 1, i, 0);
            }
        }
        public void Move(Cell pieceCell, Cell targetCell)
        {
            Board board = targetCell.BoardPtr;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (pieceCell.Piece.IsPossibleMove(pieceCell, board.Cells[i, j]) == true)
                    {
                        if (targetCell.Piece == null || targetCell.Piece.Colour != pieceCell.Piece.Colour)
                        {
                            board.Cells[i, j].Colour = board.Cells[i, j].Colour; //Remove colour modifications to cells (like highlighted moves)
                            board.Cells[pieceCell.X, pieceCell.Y].Colour = board.Cells[pieceCell.X, pieceCell.Y].Colour; //Remove SelectedCell highlight                               
                        }
                    }
                }
            }
            if (targetCell.Piece == null || targetCell.Piece.Colour != pieceCell.Piece.Colour) //If no piece at new location or a capture possible at new location
            {
                board.Move_Piece(pieceCell, targetCell);
                pieceCell.IsMoveSelected = false;
                board.IsSelecting = false;

                if (targetCell.Piece.GetType() == typeof(Pawn)) //Check for promotion
                {
                    if (targetCell.X == (targetCell.Piece.Colour == PieceColour.White ? 0 : 7))
                    {
                        Piece newPiece = null;
                        while (newPiece == null)
                        {
                            PromotionForm promotionForm = new PromotionForm(targetCell);
                            promotionForm.ShowDialog();
                            newPiece = promotionForm.SelectedPiece;
                        }
                        board.Remove_Piece(targetCell.Piece, targetCell.X, targetCell.Y); //Capture own piece first
                        board.Add_Piece(newPiece, targetCell.X, targetCell.Y, 0);
                        targetCell.Piece.PossibleMoves = newPiece.FindPossibleMoves(targetCell);
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
                if (board.IsKingInCheck(targetCell) == false)
                {
                    board.Cells[king.Cell.X, king.Cell.Y].Colour = board.Cells[king.Cell.X, king.Cell.Y].Colour;
                }

                board.PlayerTurn = board.PlayerTurn == PieceColour.White ? PieceColour.Black : PieceColour.White; //Change player turn

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
                if (board.IsKingInCheck(targetCell)) //If own king in check
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
            }
        }
        public void Add_Piece(Piece piece, int i, int j, int index)
        {
            this[i, j] = piece;
            this.Pieces.Insert(index, piece);
        }
        public void Remove_Piece(Piece piece, int i, int j)
        {
            this[i, j] = null;
            this.Pieces.Remove(piece);
        }
        public void Move_Piece(Cell previousCell, Cell newCell)
        {
            if (newCell.Piece == null) //Piece moves to empty cell
            {
                previousCell.Piece.Cell = newCell;
                int index = this.Pieces.IndexOf(previousCell.Piece);
                this.Add_Piece(previousCell.Piece, newCell.X, newCell.Y, index);
                this.Remove_Piece(previousCell.Piece, previousCell.X, previousCell.Y);
            }
            else if (newCell.Piece.Colour != previousCell.Piece.Colour && newCell.Piece.GetType() != typeof(King)) //Piece cannot capture own pieces and cannot capture opponent's king
            {
                previousCell.Piece.Cell = newCell;
                int index = this.Pieces.IndexOf(previousCell.Piece);
                this.Remove_Piece(newCell.Piece, newCell.X, newCell.Y);
                this.Add_Piece(previousCell.Piece, newCell.X, newCell.Y, index);
                this.Remove_Piece(previousCell.Piece, previousCell.X, previousCell.Y);
            }
        }
        public bool IsKingInCheck(Cell cell) //Identifies whether player's king is in check on their turn
        {
            Board board = cell.BoardPtr;
            bool isCheck = false;
            var king = board.Pieces.FirstOrDefault(x => x.Colour == board.PlayerTurn && x.GetType() == typeof(King));
            foreach (Piece piece in board.Pieces)
            {
                if (piece.Colour != king.Colour)
                {
                    if (piece.GetType() == typeof(Pawn))
                    {
                        if (piece.Colour == PieceColour.Black)
                        {
                            if (king.Cell.X == piece.Cell.X + 1 && (king.Cell.Y == piece.Cell.Y - 1 || king.Cell.Y == piece.Cell.Y + 1))
                            {
                                isCheck = true;
                            }
                        }
                        else
                        {
                            if (king.Cell.X == piece.Cell.X - 1 && (king.Cell.Y == piece.Cell.Y - 1 || king.Cell.Y == piece.Cell.Y + 1))
                            {
                                isCheck = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (KeyValuePair<int, int> move in piece.PossibleMoves)
                        {
                            if (move.Key == king.Cell.X && move.Value == king.Cell.Y)
                            {
                                isCheck = true;
                            }
                        }
                    }
                }
            }
            return isCheck;
        }
        public void UpdateLegalMoves(Cell cell)
        {
            if (cell.Piece.GetType() == typeof(King)) //King movement cannot run into check
            {
                foreach (Piece piece in this.Pieces)
                {
                    if (piece.Colour != cell.Piece.Colour)
                    {
                        if (piece.GetType() == typeof(Pawn)) //Special case for pawns
                        {
                            for (int k = 0; k < cell.Piece.PossibleMoves.Count; k++)
                            {
                                if (piece.Colour == PieceColour.Black)
                                {
                                    if (cell.Piece.PossibleMoves[k].Key == piece.Cell.X + 1 && (cell.Piece.PossibleMoves[k].Value == piece.Cell.Y - 1 || cell.Piece.PossibleMoves[k].Value == piece.Cell.Y + 1))
                                    {
                                        cell.Piece.PossibleMoves.Remove(cell.Piece.PossibleMoves[k]);
                                    }
                                }
                                else
                                {
                                    if (cell.Piece.PossibleMoves[k].Key == piece.Cell.X - 1 && (cell.Piece.PossibleMoves[k].Value == piece.Cell.Y - 1 || cell.Piece.PossibleMoves[k].Value == piece.Cell.Y + 1))
                                    {
                                        cell.Piece.PossibleMoves.Remove(cell.Piece.PossibleMoves[k]);
                                    }
                                }
                            }                         
                        }
                        else
                        {
                            piece.PossibleMoves = piece.FindPossibleMoves(piece.Cell); //Looks at enemy pieces
                            foreach (KeyValuePair<int, int> move in piece.PossibleMoves)
                            {
                                for (int k = 0; k < cell.Piece.PossibleMoves.Count; k++)
                                {
                                    if (move.Key == cell.Piece.PossibleMoves[k].Key && move.Value == cell.Piece.PossibleMoves[k].Value)
                                    {
                                        cell.Piece.PossibleMoves.Remove(cell.Piece.PossibleMoves[k]);
                                    }
                                }
                            }
                        }                       
                    }
                }
            }
            else
            {
                bool doneRemove = false;
                for (int k = 0; k < cell.Piece.PossibleMoves.Count; k++)
                {
                ResetIJLoop:
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (cell.Piece != null)
                            {
                                if (doneRemove == true)
                                {
                                    doneRemove = false;
                                    goto ResetIJLoop; //Stops board.Cells[i, j] missing PossibleMoves (as i and j might increment past it and escape moveCount for loop)
                                }
                                else if (k == cell.Piece.PossibleMoves.Count) //Stops possible moves index out of range error when removing moves
                                {
                                    goto Finish;
                                }
                                if (this.Cells[i, j].X == cell.Piece.PossibleMoves[k].Key && this.Cells[i, j].Y == cell.Piece.PossibleMoves[k].Value) //Ensures that the possible move matches the current cell (there are multiple current cells for one possible move that make checkvalidmove true)
                                {
                                    int index = 0; 
                                    Piece capturedPiece = null;
                                    bool canCapture = false;
                                    bool isNewCellNull = false;
                                    if (this.Cells[i, j].Piece != null && this.Cells[i, j].Piece.Colour != cell.Piece.Colour) //Capture enemy piece
                                    {
                                        index = this.Pieces.IndexOf(this.Cells[i, j].Piece); //Used for placing piece back in same position as before in list to get around issues with iterating through it
                                        capturedPiece = this.Cells[i, j].Piece;
                                        canCapture = true;
                                    }
                                    if (this.Cells[i, j].Piece == null) //Check if new cell is null before moving pieces
                                    {                                        
                                        isNewCellNull = true;
                                    }
                                    Move_Piece(cell, this.Cells[i, j]); //Move to block/capture                                   
                                    foreach (Piece piece in this.Pieces)
                                    {
                                        if (piece.Colour != this.PlayerTurn) //Looks at enemy pieces
                                        {
                                            piece.PossibleMoves = piece.FindPossibleMoves(piece.Cell);
                                        }
                                    }
                                    if (this.IsKingInCheck(cell)) //If own king in check, remove own moves
                                    {
                                        if (cell.Piece == null) //If original piece has moved
                                        {
                                            if (canCapture == true || isNewCellNull == true) 
                                            {
                                                this.Cells[i, j].Piece.PossibleMoves.Remove(this.Cells[i, j].Piece.PossibleMoves[k]);
                                                doneRemove = true;
                                            }
                                        }
                                        else //Original piece has not moved (due to a king or an ally piece on its new cell)
                                        {
                                            if (canCapture == true || isNewCellNull == true)
                                            {
                                                cell.Piece.PossibleMoves.Remove(cell.Piece.PossibleMoves[k]);
                                                doneRemove = true;
                                            }
                                        }                                        
                                    }
                                    if (this.Cells[i, j].Piece.GetType() != typeof(King))
                                    {
                                        Move_Piece(this.Cells[i, j], cell); //Reset board state to try next move
                                    }
                                    if (canCapture == true)
                                    {
                                        this.Add_Piece(capturedPiece, capturedPiece.Cell.X, capturedPiece.Cell.Y, index); //Respawn captured piece
                                    }
                                }
                            }
                        }
                    }
                }
            Finish:;
            }
        }
        public void HighlightMove(Cell cell, int i, int j)
        {
            if (this.Cells[i, j].Colour == CellColour.Black) //If original cell colour is black
            {
                this.Cells[i, j].BackColor = ColorTranslator.FromHtml("#57945c"); //Darker shade of green to highlight legal moves on dark cells
            }
            else //Cell colour is white
            {
                this.Cells[i, j].BackColor = ColorTranslator.FromHtml("#6db372"); //Lighter shade of green to highlight legal moves on light cells
            }
            if (this.Cells[i, j].Piece != null && this.Cells[i, j].Piece.Colour != cell.Piece.Colour) //Check whether an enemy piece is contained within a piece's moves
            {
                if (this.Cells[i, j].Colour == CellColour.Black)
                {
                    this.Cells[i, j].BackColor = ColorTranslator.FromHtml("#ab4343"); //Darker shade of red to highlight possible captures on dark cells
                }
                else
                {
                    this.Cells[i, j].BackColor = ColorTranslator.FromHtml("#d66767"); //Lighter shade of red to highlight possible captures on light cells
                }
            }
        }
        public void UnhighlightMove(Cell cell, int i, int j)
        {
            var king = this.Pieces.FirstOrDefault(x => x.Colour == this.PlayerTurn && x.GetType() == typeof(King));
            if ((this.SelectedCell.X != king.Cell.X || this.SelectedCell.Y != king.Cell.Y) || king.Colour == this.PlayerTurn)
            {
                this.Cells[this.SelectedCell.X, this.SelectedCell.Y].Colour = this.Cells[this.SelectedCell.X, this.SelectedCell.Y].Colour; //Remove highlight of selected cell when deselecting piece to move
            }
            if (cell.Piece.IsPossibleMove(cell, this.Cells[i, j]) == true)
            {
                this.Cells[i, j].Colour = this.Cells[i, j].Colour; //Remove highlighted moves when deselecting piece to move
            }
            if (this.IsKingInCheck(cell) == true) //Make sure check highlight doesn't disappear until player has moved
            {
                this.Cells[king.Cell.X, king.Cell.Y].BackColor = ColorTranslator.FromHtml("#632d91");
            }
        }
    }
}