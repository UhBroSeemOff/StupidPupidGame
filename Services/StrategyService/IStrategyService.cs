using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.StrategyService.Strategies;

namespace MyStupidPupidGame.Services.StrategyService
{
    public interface IStrategyService
    {
        IStrategy GetStrategy(EStrategies strategyType);
    }
}