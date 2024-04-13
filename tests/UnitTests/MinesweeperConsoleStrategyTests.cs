using ApplicationCore.Base;
using ApplicationCore.Interfaces;
using ApplicationCore.Strategies;
using Microsoft.Extensions.Logging;
using Moq;

public class MinesweeperConsoleStrategyTests
{   
    [Fact]
    public void PlayGame_InitializesGameAndRunsGameLoop()
    {
        var console = new Mock<IConsole>();
        var gameLevel = new Mock<GameLevel>();
        
        var commands = new Mock<ICommand>();
        var logger = new Mock<ILogger<MinesweeperConsoleStrategy>>();
        var strategy = new MinesweeperConsoleStrategy(gameLevel.Object, commands.Object, console.Object, logger.Object);

        int[,] testGrid = new int[,]
        {
                {2, 3, 2},
                {-1, -1, -1},
                {2, 3, 2}
        };
        gameLevel.Setup(g => g.Grid).Returns(testGrid);
        gameLevel.Setup(g => g.Rows).Returns(3);
        gameLevel.Setup(g => g.Columns).Returns(3);
        gameLevel.Setup(g => g.Mines).Returns(3);

        // Setup console to return "1" for row and "1" for column
        console.SetupSequence(c => c.ReadLine()).Returns("1").Returns("1");

        strategy.PlayGame();

        Assert.True(strategy.InitializeGame());
        Assert.True(strategy.blown);
        // Add more assertions to verify the game loop logic
    }

    [Fact]
    public void PlayGame_UserHitsMine_GameEnds()
    {
        var console = new Mock<IConsole>();
        var gameLevel = new Mock<GameLevel>();

        var commands = new Mock<ICommand>();
        var logger = new Mock<ILogger<MinesweeperConsoleStrategy>>();
        var strategy = new MinesweeperConsoleStrategy(gameLevel.Object, commands.Object, console.Object, logger.Object);

        int[,] testGrid = new int[,]
        {
                {2, 3, 2},
                {-1, -1, -1},
                {2, 3, 2}
        };
        gameLevel.Setup(g => g.Grid).Returns(testGrid);
        gameLevel.Setup(g => g.Rows).Returns(3);
        gameLevel.Setup(g => g.Columns).Returns(3);
        gameLevel.Setup(g => g.Mines).Returns(3);

        // Setup console to return "1" for row and "1" for column
        console.SetupSequence(c => c.ReadLine()).Returns("1").Returns("1");

        strategy.PlayGame();

        Assert.True(strategy.InitializeGame());
        Assert.True(strategy.blown);
    }

    [Fact]
    public void PlayGame_UserDoesNotHitMine_GameContinues()
    {
        var console = new Mock<IConsole>();
        var gameLevel = new Mock<GameLevel>();

        var commands = new Mock<ICommand>();
        var logger = new Mock<ILogger<MinesweeperConsoleStrategy>>();
        var strategy = new MinesweeperConsoleStrategy(gameLevel.Object, commands.Object, console.Object, logger.Object);

        int[,] testGrid = new int[,]
        {
                {2, 3, 2},
                {-1, -1, -1},
                {2, 3, 2}
        };

        char[,] testDisplayGrid = new char[,]
        {
                {'#', '#', '#'},
                {'#', '#', '#'},
                {'#', '#', '#'}
        };
        gameLevel.Setup(g => g.Grid).Returns(testGrid);
        gameLevel.Setup(g => g.DisplayGrid).Returns(testDisplayGrid);

        gameLevel.Setup(g => g.Rows).Returns(3);
        gameLevel.Setup(g => g.Columns).Returns(3);
        gameLevel.Setup(g => g.Mines).Returns(3);

        // Setup console to return "1" for row and "1" for column
        console.SetupSequence(c => c.ReadLine())
            .Returns("0").Returns("0")
            .Returns("0").Returns("1")
            .Returns("0").Returns("2")
            .Returns("2").Returns("0")
            .Returns("2").Returns("1")
            .Returns("2").Returns("2");
            
        strategy.PlayGame();

        Assert.True(strategy.InitializeGame());
        Assert.False(strategy.blown);
    }
}
