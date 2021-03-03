using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.DiceService;

namespace MyStupidPupidGame.Services.RulesService.Rules
{
    public class PercentageRules : Rules
    {
        public PercentageRules(IDiceService diceService) : base(diceService)
        {
        }

        public override CheckResult Check(int stat)
        {
            var rollResult = _diceService.RollDice(EDices.Dice100);
            return new CheckResult
            {
                Value = rollResult,
                IsPassed = stat >= rollResult,
                CriticalMistake = rollResult == 100
            };
        }

        public override CheckResult Check(int stat, EDices dice)
        {
            return Check(stat);
        }

        public override CheckResult Check(int stat, EDices dice, int diceNumber)
        {
            return Check(stat);
        }

        public override int ComputeDamage(int stat)
        {
            return _diceService.RollDice(EDices.Dice10) + stat;
        }

        public override int ComputeDamage(int stat, int attacksNumber)
        {
            var result = 0;
            for (var index = 0; index < attacksNumber; index++)
                result += ComputeDamage(stat);

            return result;
        }
    }
}
