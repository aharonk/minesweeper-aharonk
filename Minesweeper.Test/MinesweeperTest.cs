using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Shared;

namespace MinesweeperModel.Test;

public class MinesweeperTest
{
    [TestClass]
    public class ModelTest
    {
        private readonly GameSettings _gs = new((3, 3), 1);
        private MSModel _model = new(new GameSettings((3, 3), 1));

        [TestMethod]
        public void Test0GameSetup()
        {
            var board = _model.GetBoard();
            board.GetLength(0).Should().Be(3);
            board.GetLength(1).Should().Be(3);
        }

        [TestMethod]
        public void Test1BoardSetup()
        {
            var result = _model.OpenCell(2, 2);
            result[0].Should().NotBe(null);
        }

        // 000
        // 011
        // 01B
        [TestMethod]
        public void Test2DeterminedLoss()
        {
            _model = new MSModel(_gs);
            _model.FirstMove(new Cell(0, 0), new Random(0));
            _model.OpenCell(2, 2)[0].Should().Be(Cell.NullCell);
        }

        [TestMethod]
        public void Test2DeterminedWin()
        {
            _model = new MSModel(_gs);
            var result = _model.OpenCell(0, 0, 0);
            var b = _model.GetBoard();
            b[0, 0].IsBomb().Should().Be(false);
            b[0, 1].IsBomb().Should().Be(false);
            b[0, 2].IsBomb().Should().Be(false);
            b[1, 0].IsBomb().Should().Be(false);
            b[1, 1].IsBomb().Should().Be(false);
            b[1, 2].IsBomb().Should().Be(false);
            b[2, 0].IsBomb().Should().Be(false);
            b[2, 1].IsBomb().Should().Be(false);
            b[2, 2].IsBomb().Should().Be(true);

            result[^1].Should().Be(Cell.NullCell);

            var board = _model.GetBoard();
            result.Should().Contain(board[0, 0]).And.Contain(board[1, 1]);
            result.Should().NotContain(board[2, 2]);
        }

        [TestMethod]
        public void Test2DeterminedContinue()
        {
            _model = new MSModel(_gs);
            _model.FirstMove(_model.GetBoard()[0, 0], new Random(0));
            var result = _model.OpenCell(1, 1);
            result[0].Should().NotBe(null);
            result[^1].Should().NotBe(null);

            var board = _model.GetBoard();
            result.Count.Should().Be(1);
            result.Should().Contain(board[1, 1]);
        }
    }
}