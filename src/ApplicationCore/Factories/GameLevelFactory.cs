using ApplicationCore.Base;
using ApplicationCore.Services;

namespace ApplicationCore.Factories
{
    public static class GameLevelFactory
    {
        public static GameLevel CreateGameLevel(string type)
        {
            switch (type)
            {
                case "Intermediate":
                    return new IntermediateLevel();
                default:
                    return new BeginnerLevel();
            }
        }
    }
}