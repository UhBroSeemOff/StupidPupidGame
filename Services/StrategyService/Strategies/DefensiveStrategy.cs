using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyStupidPupidGame.Character;
using MyStupidPupidGame.Character.CharacterProperties;
using MyStupidPupidGame.Services.RulesService.Rules;

namespace MyStupidPupidGame.Services.StrategyService.Strategies
{
    class DefensiveStrategy : Strategy
    {
        public DefensiveStrategy(IRules rules) : base(rules)
        {
        }

        public override void MakeMove(IEnumerable<ICharacter> enemiesList, Statistic stats)
        {
            stats.BonusDefense = _rules.ComputeDefense(stats.Defense);
        }
    }
}
