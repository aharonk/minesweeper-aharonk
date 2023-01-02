using Minesweeper.Shared;

namespace MinesweeperModel
{


    public class MSModel : IMSModel
    {
        public int Height { get => 6; set => throw new NotImplementedException(); }
        public int Width { get => 4 ; set => throw new NotImplementedException(); }

        // use internal fields so that the Test can set values as needed
        public void FlagCell(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void Init(GameType gt)
        {
            throw new NotImplementedException();
        }

        public List<Cell> OpenCell(int x, int y)
        {
            return null;
            //throw new NotImplementedException(); 
        }
    }
}