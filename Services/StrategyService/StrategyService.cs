using System.Collections.Generic;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.RulesService.Rules;
using MyStupidPupidGame.Services.StrategyService.Strategies;

namespace MyStupidPupidGame.Services.StrategyService
{
    public class StrategyService : IStrategyService
    {
        private readonly IDictionary<EStrategies, IStrategy> _strategiesMap;

        public StrategyService(IRules rules)
        {
            _strategiesMap = new Dictionary<EStrategies, IStrategy>
            {
                {EStrategies.Aggressive, new AggressiveStrategy(rules)}
            };
        }

        public IStrategy GetStrategy(EStrategies strategyType)
        {
            return _strategiesMap[strategyType];
        }
    }
}