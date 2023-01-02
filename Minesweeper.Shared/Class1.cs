namespace Minesweeper.Shared
{
    public enum GameType { Easy, Medium, Hard }
    public class GameSettings
    {
        private static GameSettings[] settings;

        static GameSettings()
        { // static c-tor
            settings = new[] {
            new GameSettings { SizeX = 10 } ,
            new GameSettings { SizeX = 20 , BombCount = 50}};

            settings[0].FinishSetup();
        }


        public static GameSettings GetGameSetting(GameType gt)
        {
            return settings[(int)gt];
        }

        public int SizeX { get; private set; }
        public int SizeY { get; set; }
        public int BombCount { get; set; }

        public void FinishSetup() { }
    }

    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        // ??
    }

    public interface IMSModel
    {
        int Height { get; set; }
        int Width { get; set; }

        // set things up
        void Init(GameType gt);
        // answer questions
        // make moves
        /// <summary>
        /// Retuirns changed Cells
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        List<Cell> OpenCell(int x, int y);
        void FlagCell(int x, int y);
    }
}