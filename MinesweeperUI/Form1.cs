using Minesweeper.Shared;
using MinesweeperModel;
using Timer = System.Windows.Forms.Timer;

namespace MinesweeperUI
{
    public partial class Form1 : Form
    {
        private MSModel Model { get; set; } = new(GameSettings.GetGameSetting(GameType.Easy));
        private CheckBox[,] _buttons = new CheckBox[0, 0];
        private Timer Time { get; set; } = new();
        private GameSettings CurrentProperties { get; set; } = GameSettings.GetGameSetting(GameType.Easy);

        private readonly int _squareSize = 50;

        public Form1()
        {
            InitializeComponent();
            Setup(CurrentProperties);
        }

        public Form1(MSModel model)
        {
            InitializeComponent();
            Setup(GameSettings.GetGameSetting(DiffFromHeight(model.Height)));
        }


        #region GUI Setup and Drawing

        private void Setup(GameSettings gs)
        {
            Model = new MSModel(gs);
            InitializeVariableComponents(gs);
            StartGame();
        }

        private GameType DiffFromHeight(int height)
        {
            return height switch
            {
                8 => GameType.Easy,
                14 => GameType.Medium,
                20 => GameType.Hard,
                _ => throw new ArgumentException(),
            };
        }

        private void InitializeVariableComponents(GameSettings gs)
        {
            CurrentProperties = gs;
            int rows = gs.SizeY, columns = gs.SizeX;
            Size = new Size(columns * _squareSize, rows * _squareSize + menuStrip1.Size.Height);

            // details
            Time = new Timer
            {
                Interval = 1000
            };
            Time.Tick += IncrementTime;
            Time.Tag = 0;
            timeElapsed.Text = "0";

            bombsRemaining.Tag = gs.BombCount;
            bombsRemaining.Text = gs.BombCount.ToString();

            //
            // buttons
            //
            var tempButtons = new CheckBox[rows, columns];
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    tempButtons[r, c] = new CheckBox();
                    var b = tempButtons[r, c];
                    b.Dock = DockStyle.Fill;
                    b.TabIndex = 1 + r * columns + c;
                    b.UseVisualStyleBackColor = true;
                    b.MouseDown += OnClick;
                    b.Tag = new Point(c, r);
                    b.Text = "";
                    b.Appearance = Appearance.Button;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Font = new Font("Arial Unicode MS", 12);
                    b.BackColor = Color.DarkGray;
                }
            }

            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();

            // remove old usages (for restart)
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            foreach (var item in gameToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                    menuItem.Checked = menuItem.Text == DiffFromHeight(gs.SizeY).ToString();
            }

            // 
            // tableLayoutPanel1
            //

            //columns
            tableLayoutPanel1.ColumnCount = columns;
            for (var c = 0; c < columns; c++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columns));
            }

            //controls
            _buttons = tempButtons;
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    tableLayoutPanel1.Controls.Add(_buttons[r, c], c, r);
                }
            }

            //rows
            tableLayoutPanel1.RowCount = rows;
            for (var r = 0; r < rows; r++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / rows));
            }

            //misc
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Size = new Size(1296, 890);
            tableLayoutPanel1.TabIndex = 0;

            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion


        #region Gameplay

        private void OnClick(object? sender, MouseEventArgs e)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender), "sender is null");

            var p = (Point) ((CheckBox) sender).Tag;

            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    if (!Time.Enabled)
                        Time.Start();

                    var result = Model.OpenCell(p.X, p.Y);

                    bool lost = false, won = false;
                    if (result[0].Equals(Cell.NullCell))
                    {
                        lost = true;
                        result.RemoveAt(0);
                    }

                    for (var i = 0; i < result.Count; i++)
                    {
                        if (i == result.Count - 1 && result[i].Equals(Cell.NullCell))
                        {
                            won = true;
                            break;
                        }

                        var c = result[i];
                        var correspondingButton = _buttons[c.Y, c.X];
                        correspondingButton.FlatStyle = FlatStyle.Flat;
                        correspondingButton.BackColor = Color.LightGray;
                        correspondingButton.Text = c.GetRepresentation().ToSymbol();
                    }

                    if (won)
                    {
                        Win();
                    }

                    if (lost)
                    {
                        Lose(result);
                    }
                }

                catch (ArgumentException)
                {
                    //Ignore because there is no effect on game state. Pretend the user did nothing.
                }
            }
            else //  right (or middle) click
            {
                try
                {
                    Model.FlagCell(p.X, p.Y);
                    var c = Model.GetBoard()[p.Y, p.X];
                    _buttons[p.Y, p.X].Text = c.GetRepresentation().ToSymbol();
                    bombsRemaining.Tag = (int) bombsRemaining.Tag + (c.IsFlagged() ? -1 : 1);
                    bombsRemaining.Text = bombsRemaining.Tag.ToString();
                }
                catch (InvalidOperationException)
                {
                    // ignored, see above
                }
            }
        }

        private void Win()
        {
            EndGame();
            MessageBox.Show("You Win!", "Congratulations!");
        }

        private void Lose(List<Cell> bombs)
        {
            EndGame();
            foreach (var c in bombs)
            {
                _buttons[c.Y, c.X].BackColor = Color.DarkGray;
                if (c.IsBomb() && !c.IsFlagged())
                {
                    _buttons[c.Y, c.X].Text = c.GetRepresentation().ToSymbol();
                }
                else if (!c.IsBomb() && c.IsFlagged())
                {
                    _buttons[c.Y, c.X].Text = CellStatus.Wrong.ToSymbol();
                }
            }
        }

        private void EndGame()
        {
            Time.Stop();
            tableLayoutPanel1.Enabled = false;
        }

        private void StartGame()
        {
            tableLayoutPanel1.Enabled = true;
        }

        private void RestartGame()
        {
            Time.Start();
            StartGame();
        }

        private void IncrementTime(object? sender, EventArgs e)
        {
            if ((int) Time.Tag < 999)
            {
                Time.Tag = (int) Time.Tag + 1;
                timeElapsed.Text = Time.Tag.ToString();
            }
        }

        #endregion


        #region New Game

        private void DifficultyClick(object sender, EventArgs e)
        {
            var difficulty = ((ToolStripMenuItem) sender).Text;
            GameSettings gs;

            _ = Enum.TryParse(difficulty, out GameType d);
            gs = GameSettings.GetGameSetting(d);

            Setup(gs);
        }

        private void NewGameShortcut(object? sender, KeyEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.N)
            {
                EndGame();
                Setup(CurrentProperties);
            }
        }

        #endregion
    }
}