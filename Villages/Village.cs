using System;
using System.Collections.Generic;
using MyStupidPupidGame.Character;
using MyStupidPupidGame.Character.CharacterProperties;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.DiceService;
using MyStupidPupidGame.Services.RulesService.Rules;
using MyStupidPupidGame.Services.StrategyService;

namespace MyStupidPupidGame.Villages
{
    public class Village : IVillage
    {
        private readonly IDiceService _diceService;
        private readonly IStrategyService _strategyService;
        private readonly IDictionary<EFighterClass, Func<string, Qualification, ICharacter>> _charactersMap;

        public Village(IDiceService diceService, IStrategyService strategyService)
        {
            _diceService = diceService;
            _strategyService = strategyService;

            _charactersMap = new Dictionary<EFighterClass, Func<string, Qualification, ICharacter>>
            {
                {EFighterClass.Warrior, (name, qualification) => new Warrior(name, qualification, _strategyService)},
                {EFighterClass.Ranger, (name, qualification) => new Archer(name, qualification, _strategyService)},
            };
        }

        public ICharacter GetFighter(EFighterClass fighterClass)
        {
            return _charactersMap[fighterClass](
                $"{fighterClass}_{_diceService.RollDice(EDices.Dice100)}",
                new Qualification() { 
                    Agility = 30 + _diceService.RollDice(EDices.Dice10, 2), 
                    Endurance = 30 + _diceService.RollDice(EDices.Dice20, 2),
                    Strength = 30 + _diceService.RollDice(EDices.Dice10, 2)
                });        //TODO: map quals
        }
    }
}
