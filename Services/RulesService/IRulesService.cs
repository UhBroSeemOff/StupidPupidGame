using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.RulesService.Rules;

namespace MyStupidPupidGame.Services.RulesService
{
    public interface IRulesService
    {
        IRules GetRules(ERules rulesType);
    }
}
