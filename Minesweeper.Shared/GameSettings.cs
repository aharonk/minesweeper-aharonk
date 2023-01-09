using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MinesweeperModel.Test")]
namespace Minesweeper.Shared
{
    public class GameSettings
    {
        public int SizeX { get; }
        public int SizeY { get; }
        public int BombCount { get; }

        private static readonly GameSettings[] Settings;

        static GameSettings()
        {
            Settings = new[]
            {
                new GameSettings(GameType.Easy),
                new GameSettings(GameType.Medium),
                new GameSettings(GameType.Hard)
            };
        }
        private GameSettings(GameType gt)
        {
            (SizeY, SizeX) = gt.Size();
            BombCount = gt.BombCount();
        }

        internal GameSettings ((int, int) size, int nBombs) 
        {
            (SizeY, SizeX) = size;
            BombCount = nBombs;
        }

        public static GameSettings GetGameSetting(GameType gt)
        {
            return Settings[(int) gt];
        }
    }
}