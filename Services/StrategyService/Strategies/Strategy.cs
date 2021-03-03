using System.Collections.Generic;
using MyStupidPupidGame.Character;
using MyStupidPupidGame.Character.CharacterProperties;
using MyStupidPupidGame.Services.RulesService.Rules;

namespace MyStupidPupidGame.Services.StrategyService.Strategies
{
    public abstract class Strategy : IStrategy
    {
        protected readonly IRules _rules;

        protected Strategy(IRules rules)
        {
            _rules = rules;
        }

        public abstract void MakeMove(IEnumerable<ICharacter> enemiesList, Statistic stats);
    }
}