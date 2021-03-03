using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.DiceService;

namespace MyStupidPupidGame.Services.RulesService.Rules
{
    public abstract class Rules : IRules
    {
        protected IDiceService _diceService;

        protected Rules(IDiceService diceService)
        {
            _diceService = diceService;
        }

        public abstract CheckResult Check(int stat);

        public abstract CheckResult Check(int stat, EDices dice);

        public abstract CheckResult Check(int stat, EDices dice, int diceNumber);
        public abstract int ComputeDamage(int stat);
        public abstract int ComputeDamage(int stat, int attacksNumber);
    }
}
