using System;
using System.Collections.Generic;
using MyStupidPupidGame.Character;
using MyStupidPupidGame.CharacterProperties;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.DiceService;
using MyStupidPupidGame.Services.RulesService.Rules;

namespace MyStupidPupidGame.Villages
{
    public class Village : IVillage
    {
        private readonly IDiceService _diceService;
        private readonly IRules _rules;
        private readonly IDictionary<EFighterClass, Func<string, Qualification, ICharacter>> _charactersMap;

        public Village(IDiceService diceService, IRules rules)
        {
            _diceService = diceService;
            _rules = rules;

            _charactersMap = new Dictionary<EFighterClass, Func<string, Qualification, ICharacter>>
            {
                {EFighterClass.Warrior, (name, qualification) => new Warrior(name, qualification, _rules)},
                {EFighterClass.Ranger, (name, qualification) => new Warrior(name, qualification, _rules)},
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
