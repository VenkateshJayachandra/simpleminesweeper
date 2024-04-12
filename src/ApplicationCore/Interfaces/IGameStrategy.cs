
namespace ApplicationCore.Interfaces
{
    public interface IGameStrategy
    {
        void PlayGame();
    }

    public interface IGameMineLogic
    {
        bool ProcessCell(int row, int col, ref int revealedCells, int safeCells);

    }
}

