using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;
using ApplicationCore.Base;

namespace Minesweeper.Game
{
    class Program
    {
        static void Main()
        {
            // Set up DI container 
            // Resolving the GameLevel in singleton as it is shared with both IMineSweeperStrategy and ICommand, by this we can avoid some many params and treat the instance is 
            // for that user 
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConsole, ConsoleWrapper>()
                .AddSingleton<GameLevel>(sp => new SimpleLevel(3, 3, 3)) // Register GameLevel as a singleton
                .AddTransient<ICommand>(sp => new BlackScreenGridCommands(sp.GetService<GameLevel>(), sp.GetService<IConsole>())) // Resolve dependencies manually
                .AddTransient<IMineSweeperStrategy>(sp => new MinesweeperConsoleStrategy(sp.GetService<GameLevel>(), sp.GetService<ICommand>(), sp.GetService<IConsole>())) // Resolve dependencies manually
                .AddTransient<GameService>()
                .BuildServiceProvider();

            // Resolve GameService from DI container
            var gameService = serviceProvider.GetService<GameService>();
            gameService.PlayGame();

        }
    }
}

