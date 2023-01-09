using System.Runtime.CompilerServices;
using Minesweeper.Shared;

[assembly: InternalsVisibleTo("MinesweeperModel.Test")]

namespace MinesweeperModel
{
    public class MSModel : IMSModel
    {
        private int _height, _width;

        public int Height
        {
            get => _height;
            set => throw new NotImplementedException();
        }

        public int Width
        {
            get => _width;
            set => throw new NotImplementedException();
        }

        private int BombCount { get; set; }
        private Cell[,] Board { get; set; }
        private int FlippedCount { get; set; }

        private static readonly (int, int)[] Directions =
        {
            (0, 1),
            (1, 1),
            (1, 0),
            (1, -1),
            (0, -1),
            (-1, -1),
            (-1, 0),
            (-1, 1)
        };

        public MSModel()
        {
            Init(GameType.Easy);
        }

        public MSModel(GameType gt)
        {
            Init(gt);
        }

        public MSModel(GameSettings gs)
        {
            Init(gs);
        }

        #region Setup

        public void Init(GameType gt)
        {
            Init(GameSettings.GetGameSetting(gt));
        }

        private void Init(GameSettings gs)
        {
            SetSize((gs.SizeY, gs.SizeX));
            SetBombCount(gs.BombCount);

            Board = new Cell[_height, _width];
            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    Board[y, x] = new Cell(y, x);
                }
            }
        }

        internal void SetBombCount(int i)
        {
            BombCount = i;
        }

        internal void SetSize((int, int) size)
        {
            (_height, _width) = size;
        }

        internal void FirstMove(Cell c, Random rand)
        {
            int currentBombs = 0;

            while (currentBombs < BombCount)
            {
                int y = rand.Next(_height), x = rand.Next(_width);

                if (!(x == c.X && y == c.Y) && !Board[y, x].IsBomb())
                {
                    Board[y, x].SetBomb();
                    currentBombs++;
                }
            }
        }

        #endregion

        public Cell[,] GetBoard()
        {
            return (Cell[,]) Board.Clone();
        }

        private List<Cell> _changes = new();

        private bool InBounds(int y, int x)
        {
            return y >= 0 && y < _height && x >= 0 && x < _width;
        }

        private void Flip(Cell c)
        {
            c.Reveal();

            foreach (var (y, x) in Directions)
            {
                if (InBounds(c.Y + y, c.X + x) && Board[c.Y + y, c.X + x].IsBomb())
                    c.AddNeighbor();
            }

            if (c.GetNeighboringBombCount() == 0)
            {
                foreach (var (y, x) in Directions)
                {
                    if (InBounds(c.Y + y, c.X + x))
                    {
                        var next = Board[c.Y + y, c.X + x];
                        if (!next.IsRevealed())
                            Flip(next);
                    }
                }
            }

            _changes.Add(c);
        }

        internal List<Cell> OpenCell(int x, int y, int? seed)
        {
            var c = Board[y, x];

            if (c.IsRevealed())
            {
                throw new ArgumentException("Cell already revealed.");
            }

            if (c.IsFlagged())
            {
                throw new ArgumentException("Cannot flip flagged cell.");
            }

            if (FlippedCount == 0)
            {
                FirstMove(c, seed == null ? new Random() : new Random((int) seed));
            }

            if (c.IsBomb())
            {
                var bombList = new List<Cell>(BombCount + 1) {Cell.NullCell};
                foreach (var cell in Board)
                {
                    if (cell.IsBomb() && !cell.IsFlagged())
                    {
                        cell.Reveal();
                        bombList.Add(cell);
                    }
                    else if (cell.IsFlagged())
                    {
                        bombList.Add(cell);
                    }
                }

                return bombList;
            }

            _changes = new List<Cell>();
            Flip(c);
            FlippedCount += _changes.Count;

            if (_height * _width - FlippedCount == BombCount)
            {
                _changes.Add(Cell.NullCell);
            }

            return _changes;
        }

        // The first element is null if you've landed on a bomb, the final element is null if you've won.
        public List<Cell> OpenCell(int x, int y)
        {
            return OpenCell(x, y, null);
        }

        public void FlagCell(int x, int y)
        {
            if (Board[y, x].IsRevealed())
                throw new InvalidOperationException("Cannot flag a revealed Cell.");

            Board[y, x].Flag();
        }
    }
}