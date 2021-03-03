using System.Collections.Generic;
using System.Linq;
using MyStupidPupidGame.Character;
using MyStupidPupidGame.Character.CharacterProperties;
using MyStupidPupidGame.Commands.Battle;
using MyStupidPupidGame.Services.RulesService.Rules;

namespace MyStupidPupidGame.Services.StrategyService.Strategies
{
    public class AggressiveStrategy : Strategy
    {
        public AggressiveStrategy(IRules rules) : base(rules)
        {
        }

        public override void MakeMove(IEnumerable<ICharacter> enemiesList, Statistic stats)
        {
            var target = FindTarget(enemiesList);
            if (target == null)
                return;

            Attack(target, stats, _rules);
        }

        private static void Attack(ICharacter target, Statistic stats,IRules rules)
        {
            var checkResults = rules.Check(stats.Penetration);

            if (!checkResults.IsPassed)
                return;

            var attackCommand = new Attack(target, rules.ComputeDamage(stats.Damage));
            attackCommand.Execute();
        }

        private static ICharacter FindTarget(IEnumerable<ICharacter> enemiesList)
        {
            return enemiesList.OrderBy(target => target.Condition).FirstOrDefault(target => target.IsAlive);
            
        }
    }
}