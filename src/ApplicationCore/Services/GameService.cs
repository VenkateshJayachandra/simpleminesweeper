using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class GameService
    {
        private readonly IGameStrategy _gameStrategy;

        public GameService(IGameStrategy gameStrategy)
        {
            _gameStrategy = gameStrategy;
        }

        public void PlayGame()
        {
            _gameStrategy.PlayGame();
        }
    }
}

