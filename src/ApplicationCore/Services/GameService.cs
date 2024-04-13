using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class GameService
    {
        private readonly IMineSweeperStrategy _gameStrategy;

        public GameService(IMineSweeperStrategy gameStrategy)
        {
            _gameStrategy = gameStrategy;
        }

        public void PlayGame()
        {
            _gameStrategy.PlayGame();
        }
    }
}

