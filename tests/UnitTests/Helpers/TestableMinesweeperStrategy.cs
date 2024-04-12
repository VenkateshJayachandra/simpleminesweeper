using ApplicationCore.Services;
using ApplicationCore.Interfaces;
using System.Text;
using ApplicationCore.Entities;

public class TestableMinesweeperStrategy : MinesweeperStrategy
{
    private Queue<string> inputs = new Queue<string>();

    public TestableMinesweeperStrategy(MinesweeperOptions minesweeperOptions, IConsole console) : base(minesweeperOptions, console)
    {
    }

    public void AddInput(string input)
    {
        inputs.Enqueue(input);
    }

    protected override string ReadLine()
    {
        return inputs.Dequeue();
    }

    public int InputX { get; set; }
    public int InputY { get; set; }

    protected override void ClearConsole()
    {
        // Do nothing for testing
    }
    public void SetMine(int row, int col)
    {
        grid[row, col] = -1;
    }

    protected override int ReadLineX()
    {
        return InputX;
    }

    protected override int ReadLineY()
    {
        return InputY;
    }

    public StringBuilder ConsoleOutput { get; private set; } = new StringBuilder();

    public List<(int, int)> FindAllNonMineCoordinates(int[,] grid)
    {
        var nonMineCoordinates = new List<(int, int)>();

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] != -1)
                {
                    nonMineCoordinates.Add((i, j));
                }
            }
        }

        return nonMineCoordinates; // Return the list of non-mine coordinates
    }

}