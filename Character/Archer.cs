using MyStupidPupidGame.Character.CharacterProperties;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.StrategyService;

namespace MyStupidPupidGame.Character
{
    class Archer : Character
    {
        public Archer(string name, Qualification qualification, IStrategyService strategyService) : base(name, qualification, strategyService)
        {
            _stats.Damage -= 6;
            _stats.Health -= 10;
        }

        protected override void MakeStrategyMove()
        {
            var strategy = _strategyService.GetStrategy(EStrategies.Aggressive);
            strategy.MakeMove(_enemiesList, _stats);
        }

        protected override void ComputeStats()
        {
            _stats.Penetration = 60;
            _stats.Damage = _qualification.Agility / 5;
            _stats.Defense = _qualification.Strength /20;
            _stats.Health = _qualification.Endurance /2;
            _stats.Evasion = _qualification.Agility/5;
        }
    }
}
