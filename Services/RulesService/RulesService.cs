using System.Collections.Generic;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.DiceService;
using MyStupidPupidGame.Services.RulesService.Rules;

namespace MyStupidPupidGame.Services.RulesService
{
    public class RulesService : IRulesService
    {
        private readonly IDiceService _diceService;
        private readonly IDictionary<ERules, IRules> _rulesMap;

        public RulesService(IDiceService diceService)
        {
            _diceService = diceService;

            _rulesMap = new Dictionary<ERules, IRules>
            {
                {ERules.DungeonsAndDragons, new DungeonsAndDragonsRules(_diceService)},
                {ERules.Percentage, new PercentageRules(_diceService)}
            };
        }

        public IRules GetRules(ERules rulesType)
        {
            return _rulesMap[rulesType];
        }
    }
}
