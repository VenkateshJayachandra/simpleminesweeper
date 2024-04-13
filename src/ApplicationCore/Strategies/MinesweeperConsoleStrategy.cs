using ApplicationCore.Base;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace ApplicationCore.Strategies
{
    public class MinesweeperConsoleStrategy : IMineSweeperStrategy
    {
        IConsole console;
        GameLevel gameLevel;
        ICommand consoleGridCommands;
        private readonly ILogger<MinesweeperConsoleStrategy> logger;

        public MinesweeperConsoleStrategy(GameLevel gameLevel, ICommand consoleGridCommands, IConsole console, ILogger<MinesweeperConsoleStrategy> logger)
        {
            this.gameLevel = gameLevel;
            this.console = console;
            this.consoleGridCommands = consoleGridCommands;
            this.logger = logger;
        }

        public bool blown { get; set; }

        public void PlayGame()
        {
            var isReady = InitializeGame();

            if (isReady)
            {
                logger.LogInformation("Game Initialized successfully");
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

                if (!int.TryParse(console.ReadLine(), out int row))
                {
                    throw new GameUserInputFormatException("Invalid input. Please enter a number.", logger);
                }

                console.Write("Y: ");

                if (!int.TryParse(console.ReadLine(), out int col))
                {
                    throw new GameUserInputFormatException("Invalid input. Please enter a number.", logger);
                }

                if (row < 0 || row >= gameLevel.Rows || col < 0 || col >= gameLevel.Columns)
                {
                    throw new GameArgumentOutOfRangeExceptionException("Coordinates are out of range.", logger);
                }

                bool continueGame = ProcessCellBussinessLogicSpecificToThisClass(row, col, ref revealedCells, safeCells);
                if (!continueGame) break;
            }
        }

        bool ProcessCellBussinessLogicSpecificToThisClass(int row, int col, ref int revealedCells, int safeCells)
        {
            if (gameLevel.Grid[row, col] == -1)
            {
                logger.LogInformation("Boom! You hit a mine.");
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
                logger.LogInformation("Congratulations! You've cleared all safe cells.");
                console.WriteLine("Congratulations! You've cleared all safe cells.");
                return false;
            }

            return true;
        }
    }
}