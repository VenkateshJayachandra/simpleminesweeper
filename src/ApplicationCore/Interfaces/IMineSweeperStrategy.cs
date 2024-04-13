
namespace ApplicationCore.Interfaces
{
    public interface IMineSweeperStrategy
    {
        void PlayGame();

        bool InitializeGame();

        void GameLoop();
    }
}

