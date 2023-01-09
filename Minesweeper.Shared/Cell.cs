namespace Minesweeper.Shared
{
    public class Cell
    {
        // Used to flag game win and loss
        public static readonly Cell NullCell = new(-1, -1);

        public readonly int X, Y;
        private int _neighboringBombs;
        private bool _bomb, _revealed, _flagged;

        public Cell(int y, int x)
        {
            Y = y;
            X = x;
        }

        public void AddNeighbor()
        {
            _neighboringBombs++;
        }

        public void SetBomb()
        {
            _bomb = true;
        }

        public void Reveal()
        {
            _revealed = true;
        }

        public void Flag()
        {
            _flagged = !_flagged;
        }

        public int GetNeighboringBombCount()
        {
            return _neighboringBombs;
        }

        public bool IsBomb()
        {
            return _bomb;
        }

        public bool IsRevealed()
        {
            return _revealed;
        }

        public bool IsFlagged()
        {
            return _flagged;
        }

        public CellStatus GetRepresentation()
        {
            if (_revealed)
            {
                return _bomb ? CellStatus.Bomb : (CellStatus)_neighboringBombs;
            }

            return _flagged ? CellStatus.Flagged : CellStatus.Null;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Cell o)
            {
                return X == o.X && Y == o.Y;
            }

            return false;
        }
    }
}
