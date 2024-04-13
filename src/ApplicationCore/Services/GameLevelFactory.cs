using ApplicationCore.Base;

namespace ApplicationCore.Services
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