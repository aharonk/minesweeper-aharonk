namespace Minesweeper.Shared;

public enum GameType
{
    Easy,
    Medium,
    Hard,
}

public static class GameTypeExtensions
{
    public static (int, int) Size(this GameType d)
    {
        return d switch
        {
            GameType.Easy => (8, 10),
            GameType.Medium => (14, 18),
            GameType.Hard => (20, 24),
            _ => (0, 0),
        };
    }

    public static int BombCount(this GameType d)
    {
        return d switch
        {
            GameType.Easy => 10,
            GameType.Medium => 40,
            GameType.Hard => 99,
            _ => 0,
        };
    }
}