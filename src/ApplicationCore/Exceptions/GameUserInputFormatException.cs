using ApplicationCore.Strategies;
using Microsoft.Extensions.Logging;

namespace ApplicationCore.Exceptions
{
    public class GameUserInputFormatException : Exception
    {
        private readonly ILogger<MinesweeperConsoleStrategy> logger;

        public GameUserInputFormatException(string message, ILogger<MinesweeperConsoleStrategy> logger) : base(message)
        {
            this.logger = logger;
            this.logger.LogError(message);
        }
    }
}