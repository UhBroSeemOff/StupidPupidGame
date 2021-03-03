using System;
using MyStupidPupidGame.Character.CharacterProperties;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.DiceService;

namespace MyStupidPupidGame.Services.RulesService.Rules
{
    public class DungeonsAndDragonsRules : Rules
    {
        public DungeonsAndDragonsRules(IDiceService diceService) : base(diceService)
        {
        }

        public override CheckResult Check(int stat)
        {
            throw new NotImplementedException();
        }

        public override CheckResult Check(int stat, EDices dice)
        {
            throw new NotImplementedException();
        }

        public override CheckResult Check(int stat, EDices dice, int diceNumber)
        {
            throw new NotImplementedException();
        }

        public override int ComputeDamage(int stat)
        {
            throw new NotImplementedException();
        }

        public override int ComputeDamage(int stat, int attacksNumber)
        {
            throw new NotImplementedException();
        }

        public override int ComputeDefense(int stat)
        {
            throw new NotImplementedException();
        }

        public override Statistic GetStats(Qualification qualification)
        {
            throw new NotImplementedException();
        }
    }
}
