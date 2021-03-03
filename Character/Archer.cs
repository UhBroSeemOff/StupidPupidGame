using MyStupidPupidGame.Character.CharacterProperties;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.RulesService.Rules;
using MyStupidPupidGame.Services.StrategyService;

namespace MyStupidPupidGame.Character
{
    class Archer : Character
    {
        public Archer(string name, Qualification qualification, IStrategyService strategyService, IRules rules) : 
            base(name, qualification, strategyService, rules)
        {
        }

        protected override void MakeStrategyMove()
        {
            var strategy = _strategyService.GetStrategy(EStrategies.Aggressive);
            strategy.MakeMove(_enemiesList, _stats);
        }
    }
}
