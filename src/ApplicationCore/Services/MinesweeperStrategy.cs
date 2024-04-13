using ApplicationCore.Base;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{

    public class MinesweeperConsoleStrategy : IMineSweeperStrategy
    {
        IConsole console;
        GameLevel gameLevel;
        ICommand consoleGridCommands;

        public MinesweeperConsoleStrategy(GameLevel gameLevel, ICommand consoleGridCommands, IConsole console)
        {
            this.gameLevel = gameLevel;
            this.console = console;
            this.consoleGridCommands = consoleGridCommands;
        }

        public bool blown { get; set; }

        public void PlayGame()
        {
            var isReady = InitializeGame();
            if (isReady)
            {
                GameLoop();
            }
        }

        public bool InitializeGame()
        {
            gameLevel.GenerateFieldWithMines();
            gameLevel.GenerateUserGridDisplay();
            return true;
        }

        public void GameLoop()
        {
            int safeCells = gameLevel.Rows * gameLevel.Columns - gameLevel.Mines; // Total number of safe cells
            int revealedCells = 0; // Number of revealed safe cells

            while (true)
            {
                console.Clear();

                consoleGridCommands.PrintGrid();

                console.Write("X: ");

                int row = int.Parse(console.ReadLine());

                console.Write("Y: ");

                int col = int.Parse(console.ReadLine());

                if (row < 0 || row >= gameLevel.Rows || col < 0 || col >= gameLevel.Columns)
                {
                    throw new ArgumentOutOfRangeException("Coordinates are out of range.");
                }

                bool continueGame = ProcessCellBussinessLogicSpecificToThisClass(row, col, ref revealedCells, safeCells);
                if (!continueGame) break;
            }
        }

        bool ProcessCellBussinessLogicSpecificToThisClass(int row, int col, ref int revealedCells, int safeCells)
        {
            if (gameLevel.Grid[row, col] == -1)
            {
                console.WriteLine("Boom! You hit a mine.");
                consoleGridCommands.RevealAll();
                blown = true;
                return false;
            }
            else
            {
                if (gameLevel.DisplayGrid[row, col] == '#') // Only count the cell if it hasn't been revealed yet
                {
                    revealedCells++;
                }
                consoleGridCommands.RevealCell(row, col);
            }

            // Check if all safe cells are revealed
            if (revealedCells == safeCells)
            {
                console.WriteLine("Congratulations! You've cleared all safe cells.");
                return false;
            }

            return true;
        }
    }
}