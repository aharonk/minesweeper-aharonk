namespace Minesweeper.Shared;

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