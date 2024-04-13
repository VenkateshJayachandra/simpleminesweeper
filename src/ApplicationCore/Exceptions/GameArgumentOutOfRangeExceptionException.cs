using ApplicationCore.Strategies;
using Microsoft.Extensions.Logging;

namespace ApplicationCore.Exceptions
{
    public class GameArgumentOutOfRangeExceptionException : ArgumentOutOfRangeException
    {
        private readonly ILogger<MinesweeperConsoleStrategy> logger;

        public GameArgumentOutOfRangeExceptionException(string message, ILogger<MinesweeperConsoleStrategy> logger) : base(message)
        {
            this.logger = logger;
            this.logger.LogError(message);
        }
    }
}