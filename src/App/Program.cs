using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using ApplicationCore.Entities;

namespace Minesweeper.Game
{
    class Program
    {
        static void Main()
        {
            // Set up DI container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConsole, ConsoleWrapper>()
                .AddSingleton(new MinesweeperOptions { Rows = 5, Cols = 5, Mines = 5 })
                .AddTransient<IGameStrategy, MinesweeperStrategy>()
                .BuildServiceProvider();

            // Resolve IGameStrategy from DI container
            var gameStrategy = serviceProvider.GetService<IGameStrategy>();

            var gameService = new GameService(gameStrategy);
            gameService.PlayGame();
        }
    }
}

