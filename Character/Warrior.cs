using MyStupidPupidGame.Character.CharacterProperties;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.RulesService.Rules;
using MyStupidPupidGame.Services.StrategyService;
using MyStupidPupidGame.Services.StrategyService.Strategies;

namespace MyStupidPupidGame.Character
{
    public class Warrior : Character
    {
        #region Fields

        private IStrategy _currentStrategy; 

        #endregion


        #region Constructors

        public Warrior(string name, Qualification qualification, IStrategyService strategyService, IRules rules) : 
            base(name, qualification, strategyService, rules)
        {
            _currentStrategy = _strategyService.GetStrategy(EStrategies.Aggressive);
        }

        #endregion

        #region Methods

        protected override void MakeStrategyMove()
        {
            _currentStrategy.MakeMove(_enemiesList, _stats);
            _currentStrategy = _strategyService.GetStrategy(EStrategies.Aggressive);
        }

        protected override void OnConditionChanged()
        {
            _currentStrategy = _strategyService.GetStrategy(EStrategies.Defensive);
        }

        #endregion
    }
}
