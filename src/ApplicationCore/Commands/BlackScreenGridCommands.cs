using ApplicationCore.Base;
using ApplicationCore.Interfaces;
using System;

namespace ApplicationCore.Commands
{
    public class BlackScreenGridCommands : ICommand
    {
        IConsole console;
        GameLevel gameLevel;

        public BlackScreenGridCommands(GameLevel gameLevel, IConsole console)
        {
            this.console = console;
            this.gameLevel = gameLevel;
        }

        public void PrintGrid()
        {
            for (int row = 0; row < gameLevel.DisplayGrid.GetLength(0); row++)
            {
                for (int col = 0; col < gameLevel.DisplayGrid.GetLength(1); col++)
                {
                    console.Write(gameLevel.DisplayGrid[row, col]);
                }
                console.WriteLine();
            }
        }

        public void RevealAll()
        {
            for (int row = 0; row < gameLevel.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < gameLevel.Grid.GetLength(1); col++)
                {
                    if (gameLevel.Grid[row, col] == -1)
                    {
                        gameLevel.DisplayGrid[row, col] = '*';
                    }
                    else
                    {
                        gameLevel.DisplayGrid[row, col] = char.Parse(gameLevel.Grid[row, col].ToString());
                    }
                }
            }
            console.Clear();
            PrintGrid();
        }

        public void RevealCell(int row, int col)
        {
            if (row < 0 || col < 0 || row >= gameLevel.Grid.GetLength(0) || col >= gameLevel.Grid.GetLength(1) || gameLevel.DisplayGrid[row, col] != '#')
            {
                return;
            }

            gameLevel.DisplayGrid[row, col] = char.Parse(gameLevel.Grid[row, col].ToString());

            // If the cell has a value of 0, reveal the neighboring cells
            if (gameLevel.Grid[row, col] == 0)
            {
                for (int dRow = -1; dRow <= 1; dRow++)
                {
                    for (int dCol = -1; dCol <= 1; dCol++)
                    {
                        RevealCell(row + dRow, col + dCol);
                    }
                }
            }
        }
    }
}