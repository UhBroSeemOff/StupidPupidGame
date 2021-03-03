using MyStupidPupidGame.Character.CharacterProperties;
using MyStupidPupidGame.Enums;

namespace MyStupidPupidGame.Services.RulesService.Rules
{
    public interface IRules
    {
        CheckResult Check(int stat);
        CheckResult Check(int stat, EDices dice);
        CheckResult Check(int stat, EDices dice, int diceNumber);
        int ComputeDamage(int stat);
        int ComputeDamage(int stat, int attacksNumber);
        int ComputeDefense(int stat);
        Statistic GetStats(Qualification qualification);
    }
}
