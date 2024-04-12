using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{

    public class MinesweeperStrategy : IGameStrategy
    {
        protected readonly int rows;
        protected readonly int cols;
        protected readonly int mines;
        protected readonly Random rand = new Random();
        protected int[,] grid;
        protected char[,] displayGrid;
        private readonly IConsole console;

        public MinesweeperStrategy(MinesweeperOptions minesweeperOptions, IConsole console)
        {
            this.rows = minesweeperOptions.Rows;
            this.cols = minesweeperOptions.Cols;
            this.mines = minesweeperOptions.Mines;
            this.console = console;
        }

        public bool blown { get; set; }
        public int[,] GetGrid()
        {
            return grid;
        }
        public char[,] GetDisplayGrid()
        {
            return displayGrid;
        }
        protected virtual void Write(string message)
        {
            console.Write(message);
        }

        protected virtual void WriteLine(string message = "")
        {
            console.WriteLine(message);
        }

        protected virtual void Clear()
        {
            console.Clear();
        }

        protected virtual string ReadLine()
        {
            return console.ReadLine();
        }

        protected virtual int ReadLineY()
        {
            int col = int.Parse(console.ReadLine());
            return col;
        }
        protected virtual int ReadLineX()
        {
            int row = int.Parse(console.ReadLine());
            return row;
        }
        protected virtual void ClearConsole()
        {
            console.Clear();
        }

        public bool InitializeGame()
        {
            grid = new int[rows, cols];
            displayGrid = new char[rows, cols];

            if (rows <= 0 || cols <= 0 || mines > rows * cols)
            {
                WriteLine("Rows and Columns Should be greater than zero and there should not be more mines than the cell");
                return false;
            }

            // Place the mines and initialize display grid
            for (int i = 0; i < mines; i++)
            {
                int row, col;
                do
                {
                    row = rand.Next(rows);
                    col = rand.Next(cols);
                } while (grid[row, col] == -1);

                grid[row, col] = -1;

                // Increment the numbers around the mine
                for (int dRow = -1; dRow <= 1; dRow++)
                {
                    for (int dCol = -1; dCol <= 1; dCol++)
                    {
                        int nRow = row + dRow;
                        int nCol = col + dCol;
                        if (nRow >= 0 && nCol >= 0 && nRow < rows && nCol < cols && grid[nRow, nCol] != -1)
                        {
                            grid[nRow, nCol]++;
                        }
                    }
                }
            }

            // Initialize the rest of the display grid with '?'
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    displayGrid[row, col] = '#';
                }
            }

            return true;
        }

        public void GameLoop()
        {
            int safeCells = rows * cols - mines; // Total number of safe cells
            int revealedCells = 0; // Number of revealed safe cells

            while (true)
            {
                ClearConsole();
                PrintGrid(displayGrid);
                Write("X: ");
                int row = ReadLineX();
                Write("Y: ");
                int col = ReadLineY();

                if (row < 0 || row >= rows || col < 0 || col >= cols)
                {
                    throw new ArgumentOutOfRangeException("Coordinates are out of range.");
                }

                bool continueGame = ProcessCell(row, col, ref revealedCells, safeCells);
                if (!continueGame) break;
            }
        }

        public bool ProcessCell(int row, int col, ref int revealedCells, int safeCells)
        {
            if (grid[row, col] == -1)
            {
                Console.WriteLine("Boom! You hit a mine.");
                RevealAll(grid, displayGrid);
                blown = true;
                return false;
            }
            else
            {
                if (displayGrid[row, col] == '#') // Only count the cell if it hasn't been revealed yet
                {
                    revealedCells++;
                }
                RevealCell(grid, displayGrid, row, col);
            }

            // Check if all safe cells are revealed
            if (revealedCells == safeCells)
            {
                Console.WriteLine("Congratulations! You've cleared all safe cells.");
                return false;
            }

            return true;
        }

        protected void RevealAll(int[,] grid, char[,] displayGrid)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == -1)
                    {
                        displayGrid[row, col] = '*';
                    }
                    else
                    {
                        displayGrid[row, col] = char.Parse(grid[row, col].ToString());
                    }
                }
            }
            ClearConsole();
            PrintGrid(displayGrid);
        }

        protected void RevealCell(int[,] grid, char[,] displayGrid, int row, int col)
        {
            if (row < 0 || col < 0 || row >= grid.GetLength(0) || col >= grid.GetLength(1) || displayGrid[row, col] != '#')
            {
                return;
            }

            displayGrid[row, col] = char.Parse(grid[row, col].ToString());

            // If the cell has a value of 0, reveal the neighboring cells
            if (grid[row, col] == 0)
            {
                for (int dRow = -1; dRow <= 1; dRow++)
                {
                    for (int dCol = -1; dCol <= 1; dCol++)
                    {
                        RevealCell(grid, displayGrid, row + dRow, col + dCol);
                    }
                }
            }
        }

        public void PrintGrid(char[,] displayGrid)
        {
            for (int row = 0; row < displayGrid.GetLength(0); row++)
            {
                for (int col = 0; col < displayGrid.GetLength(1); col++)
                {
                    console.Write(displayGrid[row, col]);
                }
                console.WriteLine();
            }
        }
  
        public void PlayGame()
        {
            var isReady = InitializeGame();
            if (isReady)
            {
                GameLoop();
            }
        }
    }
}