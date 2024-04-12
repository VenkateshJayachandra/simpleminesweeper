using ApplicationCore.Services;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;

public class MinesweeperTests
{
    private IConsole consoleStub;

    public MinesweeperTests()
    {
        consoleStub = new ConsoleWrapper();
    }

    [Fact]
    public void TestRowsGreaterThanZero()
    {
        var game = new MinesweeperStrategy(new MinesweeperOptions { Rows = 1, Cols=    5, Mines= 5 }, consoleStub);
        bool result = game.InitializeGame();
        Assert.True(result);
    }

    [Fact]
    public void TestRowsNotGreaterThanZero()
    {
        var game = new MinesweeperStrategy(new MinesweeperOptions { Rows = 0, Cols = 5, Mines = 5 }, consoleStub);
        bool result = game.InitializeGame();
        Assert.False(result);
    }

    [Fact]
    public void TestColumnsGreaterThanZero()
    {
        var game = new MinesweeperStrategy(new MinesweeperOptions { Rows = 5, Cols = 5, Mines = 1 }, consoleStub);
        bool result = game.InitializeGame();
        Assert.True(result);
    }

    [Fact]
    public void TestColumnsNotGreaterThanZero()
    {
        var game = new MinesweeperStrategy(new MinesweeperOptions { Rows = 5, Cols = 0, Mines = 1 }, consoleStub);
        bool result = game.InitializeGame();
        Assert.False(result);
    }

    [Fact]
    public void TestMineCountGreaterThanZero()
    {
        var game = new MinesweeperStrategy(new MinesweeperOptions { Rows = 5, Cols = 5, Mines = 5 }, consoleStub);
        bool result = game.InitializeGame();
        Assert.True(result);
    }

    [Fact]
    public void TestMineCountNotGreaterThanRowTimesColumns()
    {
        var game = new MinesweeperStrategy(new MinesweeperOptions { Rows = 5, Cols = 0, Mines = 0 }, consoleStub);
        bool result = game.InitializeGame();
        Assert.False(result);
    }

    [Fact]
    public void TestHitMine()
    {
        TestableMinesweeperStrategy testGame = new TestableMinesweeperStrategy(new MinesweeperOptions { Rows = 10, Cols = 10, Mines = 10 }, consoleStub);

        testGame.InitializeGame();
        testGame.InputX = 1;
        testGame.InputY = 1;

        testGame.SetMine(testGame.InputX, testGame.InputX);

        testGame.GameLoop();

        Assert.True(testGame.blown);
    }

    [Fact]
    public void TestNotHittingMine()
    {
        int rows = 10;
        int cols = 10;
        int mines = 10;
        int safeCells = rows * cols - mines;
        int revealedCells = 0;

        TestableMinesweeperStrategy testGame = new TestableMinesweeperStrategy(new MinesweeperOptions { Rows = rows, Cols = cols, Mines = mines }, consoleStub);

        testGame.InitializeGame();
        var result = testGame.FindAllNonMineCoordinates(testGame.GetGrid());

        foreach (var item in result)
        {
            testGame.InputX = item.Item1;
            testGame.InputY = item.Item2;

            testGame.ProcessCell(testGame.InputX, testGame.InputY, ref revealedCells, safeCells);

            Assert.False(testGame.blown);
        }

    }
}

