using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Moq;

public class GameServiceTests
{
    [Fact]
    public void PlayGame_CallsStrategyPlayGame()
    {
        var strategy = new Mock<IMineSweeperStrategy>();
        var service = new GameService(strategy.Object);

        service.PlayGame();
        strategy.Verify(s => s.PlayGame(), Times.Once);
    }
}
