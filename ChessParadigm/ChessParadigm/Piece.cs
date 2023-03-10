namespace ChessParadigm
{
    public enum PieceColour { White, Black };
    public class Piece
    {
        public Piece(Cell cell, PieceColour colour)
        {
            _colour = colour;
            _cell = cell;
        }
        public Image Image { get; protected set; }
        public List<KeyValuePair<int, int>> PossibleMoves { get; set; }

        protected PieceColour _colour;
        public PieceColour Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }
        protected Cell _cell;
        public Cell Cell
        {
            get { return _cell; }
            set { _cell = value; }
        }
        public bool IsPossibleMove(Cell pieceCell, Cell targetCell)
        {
            foreach (KeyValuePair<int, int> cellInList in pieceCell.Piece.PossibleMoves)
            {
                if (targetCell.X == cellInList.Key && targetCell.Y == cellInList.Value)
                {
                    return true;
                }
            }
            return false;
        }
        public virtual List<KeyValuePair<int, int>> FindPossibleMoves(Cell pieceCell)
        {
            return PossibleMoves;
        }
    }
}

