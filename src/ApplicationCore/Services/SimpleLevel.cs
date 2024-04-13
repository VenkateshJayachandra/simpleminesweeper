using ApplicationCore.Base;

namespace ApplicationCore.Services
{
    public class SimpleLevel : GameLevel
    {
        private int rows;

        public override int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private int columns;

        public override int Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        private int mines;

        public override int Mines
        {
            get { return mines; }
            set { mines = value; }
        }

        public SimpleLevel(int rows = 5, int columns = 5,  int mines = 5)
        {
            Rows = rows;
            Columns = columns;
            Mines = mines;
        }

        public override char[,] GenerateUserGridDisplay()
        {
            DisplayGrid = new char[rows, columns];
            // Initialize the rest of the display grid with '?'
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    DisplayGrid[row, col] = '#';
                }
            }

            return DisplayGrid;
        }
        // Simple grid field behavior and properties
        public override int[,] GenerateFieldWithMines()
        {
            Grid = new int[rows, columns];


            if (rows <= 1 || columns <= 1)
            {
                throw new ArgumentOutOfRangeException("Rows and Columns should not be less than or equal to 1");
            }

            // Place the mines and initialize display grid
            for (int i = 0; i < mines; i++)
            {
                int row, col;
                do
                {
                    row = rand.Next(rows);
                    col = rand.Next(columns);
                } while (Grid[row, col] == -1);

                Grid[row, col] = -1;

                // Increment the numbers around the mine
                for (int dRow = -1; dRow <= 1; dRow++)
                {
                    for (int dCol = -1; dCol <= 1; dCol++)
                    {
                        int nRow = row + dRow;
                        int nCol = col + dCol;
                        if (nRow >= 0 && nCol >= 0 && nRow < rows && nCol < columns && Grid[nRow, nCol] != -1)
                        {
                            Grid[nRow, nCol]++;
                        }
                    }
                }
            }

            return Grid;
        }
    }
}