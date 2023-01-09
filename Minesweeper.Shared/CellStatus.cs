namespace Minesweeper.Shared;

public enum CellStatus
{
    Wrong = -2,
    Flagged = -1,
    Null = 0,
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Bomb = 9,
}

public static class CellStatusExtensions
{
    public static string ToSymbol(this CellStatus cs)
    {
        return cs switch
        {
            CellStatus.Wrong => "X",
            CellStatus.Flagged => "🚩",
            CellStatus.Null => "",
            CellStatus.One => "1",
            CellStatus.Two => "2",
            CellStatus.Three => "3",
            CellStatus.Four => "4",
            CellStatus.Five => "5",
            CellStatus.Six => "6",
            CellStatus.Seven => "7",
            CellStatus.Eight => "8",
            CellStatus.Bomb => "💣",
            _ => throw new ArgumentException("No such CellStatus"),
        };
    }
}